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

namespace ParseTHSMsg
{
    public partial class MainForm : Form
    {
        StringBuilder sbSourceText = new StringBuilder();
        
        static readonly Dictionary<Guid, string> DictRegexMsg = new Dictionary<Guid, string>();

        string sDtRegCommon = @"(?<Year>(?:\d{4}))-(?<Month>\d{2})-(?<Day>\d{2})\s\d{2}:\d{2}:\d{2},\d{6}\s";

        string sDtRegCommon2 = @"(?<Day>\d{2})\s(?<Month>\D{3})\s(?<Year>\d{4})\s(?<Time>\d{2}:\d{2}:\d{2},\d{3}\s)";

        string sCallIdRegCommon = @"Call-ID:\s";

        List<Message> messages = new List<Message>();

        public MainForm()
        {
            InitializeComponent();

            DataTable dt = tTemplates;            

            dt.LoadDataRow(new object[] { 1, @"(Sent\smessage\sto|Received\smessage\sfrom)", "For THS log messages", @"Received\smessage", @"Sent\smessage", false, sDtRegCommon, sCallIdRegCommon }, true);
            dt.LoadDataRow(new object[] { 2, @"(SENDING\sMESSAGE\sTO\s|RECEIVED\sMESSAGE\sFROM\s)", "For buddyconsole log messages", @"RECEIVED\sMESSAGE", @"SENDING\sMESSAGE", false, sDtRegCommon , sCallIdRegCommon }, true);

            dt.LoadDataRow(new object[] { 3, @"(tns\s-\s=====|tns\s-\sMessage)", "For TNS", @"tns\s-\s=====", @"tns\s-\sMessage", false, sDtRegCommon, sCallIdRegCommon }, true);
            dt.LoadDataRow(new object[] { 4, @"(Sending\s|Received\s)", "For tp240dvr", @"Sending\s", @"Received\s", false, sDtRegCommon, sCallIdRegCommon }, true);

            dt.LoadDataRow(new object[] { 5, @"(Sending\smessage\sto\sXMPP\sDomain|Parsed\sXMPP\smessage)", "For XMPP messages", @"Parsed\sXMPP\smessage", @"Sending\smessage\sto\sXMPP\sDomain", false, sDtRegCommon , sCallIdRegCommon }, true);
            

            dt.LoadDataRow(new object[] { 6, @"onReceiveEvent\sRTSMCallEvent", "For chameleon RTSMCallEvent messages", @"", @"", true, sDtRegCommon2, @"callRef:\s" }, true);
            dt.LoadDataRow(new object[] { 7, @"ServerInterface.UpdateCall", "OTC_PC log - ServerInterface.UpdateCall", @"", @"", true, sDtRegCommon2, @"" }, true);

            cmbTemplate.DisplayMember = "DisplayName";
            cmbTemplate.ValueMember = "Regex";

            bindingSource1.DataSource = dt;   
        }
        
        private void button1_Click(object sender, EventArgs e)
        {          

            var sb = this.sbSourceText;
            var sbResult = new StringBuilder();

            var regLine = new Regex(txtMsgRegex.Text);
            var regDateStamp = new Regex(txtDateRegex.Text);

            var isFilterByCallId = cbFilterByCallId.Checked;
            var regCallId = isFilterByCallId ? new Regex(txtCallIdFilter.Text) : null ;

            var regHeartbeat = cbIncludeHeartbeat.Checked ? null : new Regex("HEARTBEAT");

            var regSIP200OK = cbIncludeSIP200.Checked ? null : new Regex("SIP/2.0 200 OK");

            var count = sb.ToString().Lines();

            //11
            
            try
            {
                using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()))))
                {
                    for (int i = 0; i < count; i++)
                    {
                        var sbMsg = new StringBuilder();

                        var s = sr.ReadLine() ?? "";
                        
                        if (regLine.IsMatch(s))
                        {
                            sbMsg.Append(s);

                            var isCallIdMatch = !isFilterByCallId;
                            var hasPresenceLine = false;

                            var checkNextLine = true;
                            while (checkNextLine && i < count)
                            {
                                s = sr.ReadLine() ?? ""; i++;
                                if (isFilterByCallId && !isCallIdMatch)
                                {
                                    isCallIdMatch = regCallId.IsMatch(s);
                                }
                                if (s.Contains("<presence>") || s.Contains("<presence_update>"))
                                    hasPresenceLine = true;

                                if (!regDateStamp.IsMatch(s))
                                    sbMsg.Append(Environment.NewLine + s);
                                else
                                    checkNextLine = false;
                            }

                            //check user filters

                            //callId filter
                            if (isFilterByCallId && !isCallIdMatch)
                                continue;                                       

                            //"include presence" filter                            
                            if (tcSpecific.Enabled && !cbIncludePresenceMsgs.Checked)
                            {
                                if (hasPresenceLine)
                                    continue;
                            }

                            string txtReceived = null;
                            string txtSent = null;

                            var msg = sbMsg.ToString();

                            if (regSIP200OK != null)
                            {
                                if (regSIP200OK.IsMatch(msg))
                                    continue;
                            }

                            if (regHeartbeat != null)
                            {
                                if (regHeartbeat.IsMatch(msg))
                                    continue;
                            }

                            if (cbAddDirectionArrows.Checked)
                            {
                                DataRowView view = (bindingSource1.Current as DataRowView);
                                if (view != null)
                                {
                                    string sRec = (string)view["DirectionInRegex"];
                                    string sSent = (string)view["DirectionOutRegex"];
                                    if (!string.IsNullOrEmpty(sRec) && !string.IsNullOrEmpty(sSent))
                                    {

                                        var regReceived = new Regex((string)tTemplates.Rows[cmbTemplate.SelectedIndex]["DirectionInRegex"]);
                                        var regSent = new Regex((string)tTemplates.Rows[cmbTemplate.SelectedIndex]["DirectionOutRegex"]);

                                        txtReceived = regReceived.IsMatch(msg)
                                            ? "<----------------------------" + Environment.NewLine
                                            : null;
                                        txtSent = regSent.IsMatch(msg)
                                            ? "---------------------------->" + Environment.NewLine
                                            : null;
                                    }
                                }


                            }

                            sbResult.Append(string.Concat(txtReceived, txtSent, msg, Environment.NewLine));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            string strRes = sbResult.ToString();
            if(!string.IsNullOrEmpty(strRes)) Clipboard.SetText(strRes);
            this.lblResultToBufferStatus.Text = "Result copied to clipboard " + DateTime.Now.ToLongTimeString();
            this.lblParsedPreview.Text = strRes.GetFirstNLines(10);
        }


        

        private void cmbMsgRegex_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.txtMsgRegex.Text = Convert.ToString(cmbMsgRegex.SelectedValue);
            DataRowView view = (bindingSource1.Current as DataRowView);
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

            if (!string.IsNullOrWhiteSpace(ofd.FileName))
            {
                sDirectorySelected = ofd.FileName;
                var files = Directory.GetFiles(sDirectorySelected).OrderBy(f => f);

                this.rtbPickedFolder.Text = "";
                //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                foreach (string fname in files)
                {
                    var logType = GetLogFileType(fname);
                    if (logType != SourceType.Unknown)
                    { 
                        mLogsToProcess.Add(new ACSLogFile() { LogFileName = fname, SourceType = logType, LogInfo = logTypeInfo[logType] }) ;

                        this.rtbPickedFolder.Text +=
                            string.Concat(
                                string.Format("Type:       {0}{1}", logType, Environment.NewLine),
                                string.Format("FileName:   {0}{1}{1}", fname, Environment.NewLine)
                                );
                        this.rtbPickedFolder.ScrollToCaret();
                    }
                }
            }
        }

        private SourceType GetLogFileType(string fname)
        {
            foreach(SourceType t in Enum.GetValues(typeof(SourceType)))
            {
                if (t == SourceType.Unknown)
                    continue;

                var rgx = logTypeInfo[t].LogFileNameRgx;
                if (rgx != null && rgx.IsMatch(fname))
                    return t;
            }
            return SourceType.Unknown;
        }

        

        private Dictionary<SourceType, ACSLogFileTypeInfo> logTypeInfo = new Dictionary<SourceType, ACSLogFileTypeInfo>()
        {
            { SourceType.Tpdrv, new ACSLogFileTypeInfo(@"tp240dvr\.log", @"(Sending\s|Received\s)",@"Received\s", @"Sending\s")},
            { SourceType.Ths, new ACSLogFileTypeInfo(@"ths\.log",@"(Sent\smessage\sto|Received\smessage\sfrom)",@"Received\smessage\sfrom",@"Sent\smessage\sto") },
            { SourceType.Tns, new ACSLogFileTypeInfo(@"tns\.log",@"(tns\s-\s=====|tns\s-\sMessage)",@"tns\s-\s=====",@"tns\s-\sMessage") },
            { SourceType.Buddy, new ACSLogFileTypeInfo(@"buddy\.log",@"(SENDING\sMESSAGE\sTO\s|RECEIVED\sMESSAGE\sFROM\s)",@"RECEIVED\sMESSAGE\sFROM\s",@"SENDING\sMESSAGE\sTO\s") }
        };

        private void btnGenSIPCCFIles_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLogsToProcess.Count == 0)
                {
                    MessageBox.Show("No files to process!");
                    return;
                }

                this.rtbGenSipCC.Text = "";

                //create dir            
                var timeNow = DateTime.Now;
                var sDateTime = timeNow.ToString("dd-MM-yyyy_hh-mm-ss");
                var sOptionalParam = cbAutoFilterCallId.Checked ? 
                    string.Format("_Call-ID_{0}_", tbAutoFilterCallId.Text) : null;
                
                string directory = Path.Combine(this.sDirectorySelected, 
                    string.Concat("SIPCC_", sDateTime, sOptionalParam, Guid.NewGuid()));
                Directory.CreateDirectory(directory);

                messages.Clear();
                foreach (var logFile in mLogsToProcess)
                {
                    var isFilterByCallId = cbAutoFilterCallId.Checked;

                    var settings = LogProcessor.CreateSettingsFromACSLogFile(logFile);
                    settings.CallIdFilterText = isFilterByCallId ? Constants.CallIdRegCommon + tbAutoFilterCallId.Text : null;
                    var lp = new LogProcessor();
                    var resultPath = lp.ProcessLogFile(directory, settings, m=>messages.Add(m) );
                    this.rtbGenSipCC.Text += string.Format("Generated file:{0}{1}{0}{0}", 
                        Environment.NewLine, resultPath);

                    System.GC.Collect(); 
                    GC.WaitForPendingFinalizers();
                }


                var tempXmlPath = Path.Combine(directory,String.Concat(Guid.NewGuid(),".xml"));
                var msgList = new MessageList(messages.OrderBy(m => m.Timestamp));
                using (StreamWriter streamWriter = System.IO.File.CreateText(tempXmlPath))
                {
                    var xmlSerializer = new XmlSerializer(msgList.GetType());
                    xmlSerializer.Serialize(streamWriter, msgList);
                }
                this.rtbGenSipCC.Text += string.Format(
                    "Generated temporary xml file:{0}{1}{0}{0}", Environment.NewLine, tempXmlPath);

                //TODO: load XML\transform.xsl, give it intermediate xml and produce final html output
                {
                    var htmlOutputPath = Path.Combine(directory, "output.html");

                    // Create a reader to read temp xml
                    using (XmlReader reader = XmlReader.Create(tempXmlPath))
                    // Create a writer for writing the transformed file.
                    using (XmlWriter writer = XmlWriter.Create(htmlOutputPath))
                    {
                        // Create and load the transform with script execution enabled.
                        XslCompiledTransform transform = new XslCompiledTransform();
                        XsltSettings settings = new XsltSettings();
                        settings.EnableScript = true;
                        transform.Load(Path.Combine(Application.StartupPath, @"XML\transform.xsl"), settings, null);

                        // Execute the transformation.
                        transform.Transform(reader, writer);
                    }
                }

                //Copy styles file to the same directory
                File.Copy(
                    Path.Combine(Application.StartupPath, @"XML\style.css"), 
                    Path.Combine(directory, "style.css"));

                this.rtbGenSipCC.Text +=
                string.Format("{0}{1}{0}{2}{0}{3}{0}{4}",
                    Environment.NewLine,
                    "READY!",
                    string.Format("Generated {0} SIP CC files ", mLogsToProcess.Count),
                    string.Format("Generated html representation for {0} SIP CC messages", msgList.Messages.Count),
                    string.Format("Finished {0}",DateTime.Now.ToLongTimeString()));
                this.rtbGenSipCC.ScrollToCaret();
            }
            catch (Exception ex)
            {
                this.rtbGenSipCC.Text = "ERROR!";
                MessageBox.Show("An error occured: " + ex);                
            }
            
        }

        

        private void cbAutoFilterCallId_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                this.tbAutoFilterCallId.Focus();
                this.tbAutoFilterCallId.SelectAll();
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



