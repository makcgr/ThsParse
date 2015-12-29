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

namespace ParseTHSMsg
{
    public partial class Form1 : Form
    {
        
        static readonly Dictionary<Guid, string> DictRegexMsg = new Dictionary<Guid, string>();

        public Form1()
        {
            InitializeComponent();

            DataTable dt = tTemplates;

            string sDtRegCommon = @"(?<Year>(?:\d{4}))-(?<Month>\d{2})-(?<Day>\d{2})\s\d{2}:\d{2}:\d{2},\d{6}\s";

            string sDtRegCommon2 = @"(?<Day>\d{2})\s(?<Month>\D{3})\s(?<Year>\d{4})\s(?<Time>\d{2}:\d{2}:\d{2},\d{3}\s)";

            string sCallIdRegCommon = @"Call-ID:\s";

            dt.LoadDataRow(new object[] { 1, @"(Sent\smessage\sto|Received\smessage\sfrom)", "For THS log messages", @"Received\smessage", @"Sent\smessage", false, sDtRegCommon, sCallIdRegCommon }, true);
            dt.LoadDataRow(new object[] { 2, @"(SENDING\sMESSAGE\sTO\s|RECEIVED\sMESSAGE\sFROM\s)", "For buddyconsole log messages", @"RECEIVED\sMESSAGE", @"SENDING\sMESSAGE", false, sDtRegCommon , sCallIdRegCommon }, true);
            dt.LoadDataRow(new object[] { 3, @"(Sending\smessage\sto\sXMPP\sDomain|Parsed\sXMPP\smessage)", "For XMPP messages", @"Parsed\sXMPP\smessage", @"Sending\smessage\sto\sXMPP\sDomain", false, sDtRegCommon , sCallIdRegCommon }, true);
            dt.LoadDataRow(new object[] { 4, @"onReceiveEvent\sRTSMCallEvent", "For chameleon RTSMCallEvent messages", @"", @"", true, sDtRegCommon2, @"callRef:\s" }, true);
            dt.LoadDataRow(new object[] { 4, @"ServerInterface.UpdateCall", "OTC_PC log - ServerInterface.UpdateCall", @"", @"", true, sDtRegCommon2, @"" }, true);

            cmbTemplate.DisplayMember = "DisplayName";
            cmbTemplate.ValueMember = "Regex";

            bindingSource1.DataSource = dt;   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtResults.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = rtbSource.Text;
            var sb = new StringBuilder();

            var regLine = new Regex(txtMsgRegex.Text);
            var regDateStamp = new Regex(txtDateRegex.Text);

            var isFilterByCallId = cbFilterByCallId.Checked;
            var regCallId = isFilterByCallId ? new Regex(txtCallIdFilter.Text) : null ;

            var count = rtbSource.Lines.Length;
            
            try
            {
                using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(text))))
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
                                if (s.Contains("<presence>")||s.Contains("<presence_update>"))
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
                            if (cbAddDirectionArrows.Checked)
                            {
                                DataRowView view = (bindingSource1.Current as DataRowView);
                                if (view != null)
                                {
                                    string sRec = (string) view["DirectionInRegex"];
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

                            sb.Append(string.Concat(txtReceived, txtSent, msg, Environment.NewLine));
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            rtResults.Text = sb.ToString();
            Clipboard.SetText(rtResults.Text);
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
            this.rtbSource.Text = Clipboard.GetText();
        }
    }
}
