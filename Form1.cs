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
        static readonly DataTable DtRegexMsg = new DataTable();
        static readonly Dictionary<Guid, string> DictRegexMsg = new Dictionary<Guid, string>();

        public Form1()
        {
            InitializeComponent();

            DtRegexMsg.Columns.Add("Id", typeof(int));
            DtRegexMsg.Columns.Add("Regex", typeof(string));
            DtRegexMsg.Columns.Add("DisplayName", typeof(string));
            DtRegexMsg.Columns.Add("DirectionInRegex", typeof(string));
            DtRegexMsg.Columns.Add("DirectionOutRegex", typeof(string));    

            DtRegexMsg.LoadDataRow(new object[] { 0, "", "None", "", "" }, false);
            DtRegexMsg.LoadDataRow(new object[] { 1, @"(Sent\smessage\sto|Received\smessage\sfrom)", "For THS log messages", @"Received\smessage", @"Sent\smessage" }, false);
            DtRegexMsg.LoadDataRow(new object[] { 2, @"(SENDING\sMESSAGE\sTO\s|RECEIVED\sMESSAGE\sFROM\s)", "For buddyconsole log messages", @"RECEIVED\sMESSAGE", @"SENDING\sMESSAGE" }, false);
            DtRegexMsg.LoadDataRow(new object[] { 3, @"(Sending\smessage\sto\sXMPP\sDomain|Parsed\sXMPP\smessage)", "For XMPP messages", @"Parsed\sXMPP\smessage", @"Sending\smessage\sto\sXMPP\sDomain" }, false);

            cmbMsgRegex.DisplayMember = "DisplayName";
            cmbMsgRegex.ValueMember = "Regex";
            cmbMsgRegex.DataSource = DtRegexMsg;

            cmbMsgRegex.SelectedIndex = 1;
            cbAddDirectionArrows.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = richTextBox1.Text;
            var sb = new StringBuilder();

            var regLine = new Regex(txtMsgRegex.Text);
            var regDateStamp = new Regex(txtDateRegex.Text);

            var isFilterByCallId = cbFilterByCallId.Checked;
            var regCallId = isFilterByCallId ? new Regex(txtCallIdFilter.Text) : null ;

            var count = richTextBox1.Lines.Length;
            
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
                                var regReceived = new Regex((string) DtRegexMsg.Rows[cmbMsgRegex.SelectedIndex]["DirectionInRegex"]);
                                var regSent = new Regex((string) DtRegexMsg.Rows[cmbMsgRegex.SelectedIndex]["DirectionOutRegex"]);

                                txtReceived = regReceived.IsMatch(msg)
                                    ? "<----------------------------" + Environment.NewLine
                                    : null;
                                txtSent = regSent.IsMatch(msg)
                                    ? "---------------------------->" + Environment.NewLine
                                    : null;
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

            richTextBox2.Text = sb.ToString();
        }

        private void cmbMsgRegex_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtMsgRegex.Text = Convert.ToString(cmbMsgRegex.SelectedValue);
            this.tcSpecific.Enabled = Convert.ToInt32(cmbMsgRegex.SelectedIndex) == 1; // for THS
            if(Convert.ToInt32(cmbMsgRegex.SelectedIndex) == 1)
            {
                tcSpecific.SelectTab(tpTHS);
            }
            
        }
    }
}
