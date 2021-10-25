using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Xsl;
using System.Globalization;
using System.Diagnostics;
using ParseTHSMsg.ClipboardParsing;
using ParseTHSMsg.AutomaticParsing;
using ParseTHSMsg.ReportCreation;
using System.Threading;

namespace ParseTHSMsg
{
    public partial class MainForm : Form
    {
        StringBuilder sbSourceText = new StringBuilder();
        
        static readonly Dictionary<Guid, string> DictRegexMsg = new Dictionary<Guid, string>();

        string sLastReportUrl = null;

        List<Message> messages = new List<Message>();



        public MainForm()
        {
            InitializeComponent();

            #region Init of Manual Parser
            ClipboardParserSettings.FillData(tTemplates);

            cmbTemplate.DisplayMember = "DisplayName";
            cmbTemplate.ValueMember = "Regex";

            bsLogParserSettingsByType.DataSource = tTemplates;
            #endregion

            dictMatchingSettingsByType = SettingsEntry.ReadFromFile(@"AutomaticParsing\Settings\LogMatchingSettings.xml");
            var sbRegexText = new StringBuilder();
            var settings = dictMatchingSettingsByType.Values;

            foreach(var s in settings)
            {
                sbRegexText.AppendFormat("({0})",s.LogFileNameMask);
                if (s != settings.Last())
                    sbRegexText.Append("|");
            }
           
            this.rgxMatchFilenames = new Regex(sbRegexText.ToString());
        }

        private void btnManualModeParse_Click(object sender, EventArgs e)
        {           
            var sRegexLine = txtMsgRegex.Text;
            var sRegexDate = txtDateRegex.Text;
            var isFilterByCallId = cbFilterByCallId.Checked;
            var sCallIdFilter = txtCallIdFilter.Text;
            var bIncludeHeartbeat = cbIncludeHeartbeat.Checked;
            var bIncludeSIP200 = cbIncludeSIP200.Checked;
            var bIncludePresenceMsgs = tcSpecific.Enabled && cbIncludePresenceMsgs.Checked;
            var bDecorateWithDirectionArrows = cbAddDirectionArrows.Checked;
            var sArrowDecorationIn = "<----------------------------";
            var sArrowDecorationOut = "---------------------------->";


            string strDirectionInRegex = GetRegexSetting("DirectionInRegex");
            string strDirectionOutRegex = GetRegexSetting("DirectionOutRegex");

            StringBuilder sbResult = null;
            try
            {
                sbResult = ClipboardParser.ParseMessages(
                    this.sbSourceText,
                    sRegexLine,
                    sRegexDate,
                    isFilterByCallId,
                    sCallIdFilter,
                    bIncludeHeartbeat,
                    bIncludeSIP200,
                    bIncludePresenceMsgs,
                    bDecorateWithDirectionArrows,
                    sArrowDecorationIn,
                    sArrowDecorationOut,
                    strDirectionInRegex, 
                    strDirectionOutRegex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                return;
            }

            string strRes = sbResult.ToString();
            if(!string.IsNullOrEmpty(strRes)) Clipboard.SetText(strRes);
            this.lblResultToBufferStatus.Text = "Result copied to clipboard " + DateTime.Now.ToLongTimeString();
            this.lblParsedPreview.Text = strRes.GetFirstNLines(10);
        }
        
        private string GetRegexSetting(string settingName)
        {
            DataRowView view = (bsLogParserSettingsByType.Current as DataRowView);
            return (view == null ? null : (string)view[settingName]);            
        }
        

        private void cmbMsgRegex_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.txtMsgRegex.Text = Convert.ToString(cmbMsgRegex.SelectedValue);
            DataRowView view = (bsLogParserSettingsByType.Current as DataRowView);
            if(view!=null)
            {
                int ix = (int)view["Id"];
                this.tcSpecific.Enabled = ix == 1; // for THS
                if (ix == 1)
                {
                    tcSpecific.SelectTab(tpTHS);
                }
            }           
            
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTemplate.SelectedIndex = 0;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            //this.rtbSource.Text = Clipboard.GetText();

            this.sbSourceText.Clear();
            string s = Clipboard.GetText();
            this.sbSourceText.Append(s);
            this.lblSourceTextStatus.Text = "Pasted " + DateTime.Now.ToLongTimeString();
            string strPrev = s.GetFirstNLines(10);
            
            
            this.lblPastedPreview.Text = strPrev;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor prev = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                System.GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            finally
            {
                this.Cursor = prev;
            }
        }

        List<ACSLogFile> mLogsToProcess = new List<ACSLogFile>() { };
        string sDirectorySelected = "";
        private void btnPickFolder_Click(object sender, EventArgs e)
        {
            mLogsToProcess.Clear();
            sDirectorySelected = "";
            this.rtbPickedFolder.Text = "-";
            this.clbFoundLogTypes.Items.Clear();
            

            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //DialogResult result = fbd.ShowDialog();

            CommonOpenFileDialog ofd = new CommonOpenFileDialog();
            ofd.IsFolderPicker = true;            
            CommonFileDialogResult result = ofd.ShowDialog();
            
            if (result != CommonFileDialogResult.Ok)
            {
                MessageBox.Show("No Folder selected");
                return;
            }            

            if (!string.IsNullOrWhiteSpace(ofd.FileName) && rgxMatchFilenames!=null)
            {
                sDirectorySelected = ofd.FileName;                

                var files = Directory.EnumerateFiles(sDirectorySelected, "*.*", SearchOption.AllDirectories)
                    .Where(f => rgxMatchFilenames.IsMatch(f))
                    .OrderBy(f => f);                

                this.rtbPickedFolder.Text = "";
                this.clbFoundLogTypes.Items.Clear();

                //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                foreach (string fname in files)
                {
                    var logType = GetLogFileType(fname);
                    if (logType != SourceType.Unknown)
                    { 
                        mLogsToProcess.Add(new ACSLogFile() { LogFileName = fname, SourceType = logType, MatcherSettings = dictMatchingSettingsByType[logType] }) ;
                        
                        this.rtbPickedFolder.Text +=
                            string.Concat(
                                string.Format("Type:       {0}{1}",
                                    logType, 
                                    Environment.NewLine),
                                string.Format("FileName:   {0}{1}{1}", fname, Environment.NewLine)
                                );
                        this.rtbPickedFolder.ScrollToCaret();
                    }
                }
                var distinctLogTypes = mLogsToProcess.GroupBy(log => log.SourceType).Select(g => g.First().SourceType).ToArray();
                foreach(var item in distinctLogTypes)
                {
                    clbFoundLogTypes.Items.Add(item.ToString());
                }
            }
        }

        private SourceType GetLogFileType(string fname)
        {
            foreach(SourceType t in Enum.GetValues(typeof(SourceType)))
            {
                if (t == SourceType.Unknown)
                    continue;

                var rgx = new Regex(dictMatchingSettingsByType[t].LogFileNameMask);
                if (rgx != null && rgx.IsMatch(fname))
                    return t;
            }
            return SourceType.Unknown;
        }



        private Dictionary<SourceType, MessageMatcherSettings> dictMatchingSettingsByType = null;
        private Regex rgxMatchFilenames = null;

        private void btnGenReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.llReport.Visible = false;
                this.lblStatus.Visible = true;
                this.lblStatus.Text = "Working...";

                if (mLogsToProcess.Count == 0)
                {
                    MessageBox.Show("No files to process!");
                    return;
                }

                this.rtbGenSipCC.Text = "";

                string directory = null;
                if (!ReportCreator.TryCreateDirectory(sDirectorySelected,out directory))
                {
                    MessageBox.Show("Error: can't create report directory!");
                    return;
                }

                var settUIFilters = CreateUIFilterSettings();
                var doCreateSeparateMessageLists = cbCreateSeparateMsgLists.Checked;

                messages.Clear();

                var logTypeSelection = new List<SourceType>();
                for(int i=0; i< clbFoundLogTypes.Items.Count; i++)
                {
                    var item = clbFoundLogTypes.Items[i];
                    SourceType parsed = SourceType.Unknown;
                    Enum.TryParse<SourceType>(item.ToString(), out parsed);
                    if (parsed != SourceType.Unknown && clbFoundLogTypes.GetItemChecked(i))
                        logTypeSelection.Add(parsed);
                }

                var logFilesToProcess = logTypeSelection.Count == 0
                        ? mLogsToProcess.AsEnumerable()
                        : mLogsToProcess.Where(l => logTypeSelection.Contains(l.SourceType));             

                try
                {
                    ReportCreator.ExtractMessagesFromFiles(logFilesToProcess, directory, messages, settUIFilters, 
                        doCreateSeparateMessageLists, UpdateUI);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());                        
                }

                var msgList = new MessageList(messages.OrderBy(m => m.Timestamp));


                var messagesSerializedToXmlPath = ReportCreator.SerializeMessagesToXmlReport(msgList, tbTraceSetDescription.Text, directory);
                this.rtbGenSipCC.Text += string.Format(
                    "Generated temporary xml file:{0}{1}{0}{0}", Environment.NewLine, messagesSerializedToXmlPath);

                //create HTML report using XSL template applied to messages XML representation

                var xslPath = Path.Combine(Application.StartupPath, @"XML\transform.xsl");

                // Report creator will need the chosen source types list to generate html columns markup
                // Do not show columns without messages
                var distinctTypesFromMessages = messages.GroupBy(m => m.SourceType).Select(g => g.First().SourceType).OrderBy(st => (int) st);
                var htmlOutputPath = ReportCreator.CreateHtmlMessagesReport(distinctTypesFromMessages, directory, 
                    xslPath, messagesSerializedToXmlPath, msgList.Messages.Count);

                //Copy styles file to the same directory

                File.Copy(
                    Path.Combine(Application.StartupPath, @"XML\style.css"),
                    Path.Combine(directory, "style.css"));

                Clipboard.SetText(htmlOutputPath);
                this.sLastReportUrl = htmlOutputPath;
                this.llReport.Visible = true;
                this.lblStatus.Text = "READY!";

                this.rtbGenSipCC.Text +=
                string.Format("{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                    Environment.NewLine,
                    "READY!",
                     doCreateSeparateMessageLists ? string.Format("▤ Generated {0} message file(s) ", mLogsToProcess.Count) : "",
                    string.Format("✿ Generated html representation for {0} message(s):{1}{2}", 
                        msgList.Messages.Count, Environment.NewLine, htmlOutputPath),
                    "✎ HTML report path copied to clipboard",
                    string.Format("✔ Finished {0}", DateTime.Now.ToLongTimeString()));
                this.rtbGenSipCC.Focus();       
                this.rtbGenSipCC.ScrollToCaret();
            }
            catch (Exception ex)
            {
                this.rtbGenSipCC.Text = "ERROR!";
                MessageBox.Show("An error occured: " + ex);                
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            
        }       

        public void UpdateUI(string statusInfo)
        {
            Invoke(new Action(() => this.rtbGenSipCC.Text += statusInfo));
        }

        private UIFilterSettings CreateUIFilterSettings()
        {
            var settUIFilters = new UIFilterSettings();

            settUIFilters.IncludePresenceMsgs = this.cbAutoIncludePresense.Checked;
            settUIFilters.ExcludeThsMonitorMessages = true;
            
            if (cbAutoFilterCallId.Checked)
            {
                string sCallIdRegex = @"Call-ID:\s";
                if (tbAutoFilterCallId.Text.Contains(","))
                {
                    sCallIdRegex +=
                        string.Concat(
                            "(",
                            string.Join("|", tbAutoFilterCallId.Text.Split(',').Select(s => Regex.Escape(s.Trim())).ToArray()),
                            ")");
                }
                else
                {
                    sCallIdRegex += tbAutoFilterCallId.Text;
                }
                settUIFilters.CallIdFilterText = sCallIdRegex;
            }

            settUIFilters.DateTimeFrom = cbDateFrom.Checked
                ? DateTime.ParseExact(dtpDateTimeFrom.Text,
                    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)
                : (DateTime?)null;

            settUIFilters.DateTimeTo = cbDateTo.Checked
                ? DateTime.ParseExact(dtpDateTo.Text,
                    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal)
                : (DateTime?)null;

            settUIFilters.IncludeSIP200 = cbIncludeSIP200OK.Checked;

            return settUIFilters;
        }

        private void cbAutoFilterCallId_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                this.tbAutoFilterCallId.Focus();
                this.tbAutoFilterCallId.SelectAll();
            }
        }

        private void llReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(sLastReportUrl!=null)
            { 
                Process.Start(sLastReportUrl);
            }
        }
    }
    static class ExtensionMethods
    {
        /// <summary>
        /// Returns the number of lines in a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long Lines(this string s)
        {
            long count = 1;
            int position = 0;
            while ((position = s.IndexOf('\n', position)) != -1)
            {
                count++;
                position++;         // Skip this occurrence!
            }
            return count;
        }

        public static string GetFirstNLines(this string s, long LinesCount)
        {
            long count = 1;
            int position = 0;
            int curPos = 0;
            StringBuilder sbRes = new StringBuilder();
            while ((position = s.IndexOf('\n', position)) != -1 && LinesCount>count)
            {
                string curStr = s.Substring(curPos, position - curPos);
                sbRes.Append(curStr);
                curPos = position;

                count++;
                position++;         // Skip this occurrence!
            }
            return sbRes.ToString();
        }
    }
}
