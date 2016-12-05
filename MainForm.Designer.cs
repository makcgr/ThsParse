namespace ParseTHSMsg
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMsgRegex = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsTemplates = new System.Data.DataSet();
            this.tTemplates = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateRegex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCallIdFilter = new System.Windows.Forms.TextBox();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.cbAddDirectionArrows = new System.Windows.Forms.CheckBox();
            this.cbFilterByCallId = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tcSpecific = new System.Windows.Forms.TabControl();
            this.tpTHS = new System.Windows.Forms.TabPage();
            this.cbIncludeHeartbeat = new System.Windows.Forms.CheckBox();
            this.cbIncludeSIP200 = new System.Windows.Forms.CheckBox();
            this.cbIncludePresenceMsgs = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAddLine = new System.Windows.Forms.CheckBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.lblSourceTextStatus = new System.Windows.Forms.Label();
            this.lblResultToBufferStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPastedPreview = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblParsedPreview = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbGenSipCC = new System.Windows.Forms.RichTextBox();
            this.btnGenSIPCCFIles = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbAutoFilterCallId = new System.Windows.Forms.TextBox();
            this.cbAutoFilterCallId = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbPickedFolder = new System.Windows.Forms.RichTextBox();
            this.btnPickFolder = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTemplates)).BeginInit();
            this.tcSpecific.SuspendLayout();
            this.tpTHS.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 42);
            this.button1.TabIndex = 14;
            this.button1.Text = "&Parse messages and copy to clipboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMsgRegex
            // 
            this.txtMsgRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgRegex.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Regex", true));
            this.txtMsgRegex.Location = new System.Drawing.Point(118, 127);
            this.txtMsgRegex.Multiline = true;
            this.txtMsgRegex.Name = "txtMsgRegex";
            this.txtMsgRegex.Size = new System.Drawing.Size(254, 41);
            this.txtMsgRegex.TabIndex = 8;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Templates";
            this.bindingSource1.DataSource = this.dsTemplates;
            // 
            // dsTemplates
            // 
            this.dsTemplates.DataSetName = "TemplatesDS";
            this.dsTemplates.Tables.AddRange(new System.Data.DataTable[] {
            this.tTemplates});
            // 
            // tTemplates
            // 
            this.tTemplates.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8});
            this.tTemplates.TableName = "Templates";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Regex";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "DisplayName";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "DirectionInRegex";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "DirectionOutRegex";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "AddLineAfter";
            this.dataColumn6.DataType = typeof(bool);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "DateTimeRegex";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "CallIdRegex";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Msg match &regex";
            // 
            // txtDateRegex
            // 
            this.txtDateRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateRegex.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "DateTimeRegex", true));
            this.txtDateRegex.Location = new System.Drawing.Point(118, 169);
            this.txtDateRegex.Name = "txtDateRegex";
            this.txtDateRegex.Size = new System.Drawing.Size(254, 20);
            this.txtDateRegex.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Date regex";
            // 
            // txtCallIdFilter
            // 
            this.txtCallIdFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCallIdFilter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "CallIdRegex", true));
            this.txtCallIdFilter.Location = new System.Drawing.Point(118, 195);
            this.txtCallIdFilter.Name = "txtCallIdFilter";
            this.txtCallIdFilter.Size = new System.Drawing.Size(254, 20);
            this.txtCallIdFilter.TabIndex = 12;
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTemplate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSource1, "DisplayName", true));
            this.cmbTemplate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource1, "Id", true));
            this.cmbTemplate.DataSource = this.bindingSource1;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(433, 126);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(335, 21);
            this.cmbTemplate.TabIndex = 3;
            this.cmbTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbMsgRegex_SelectedIndexChanged);
            // 
            // cbAddDirectionArrows
            // 
            this.cbAddDirectionArrows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAddDirectionArrows.AutoSize = true;
            this.cbAddDirectionArrows.Location = new System.Drawing.Point(435, 150);
            this.cbAddDirectionArrows.Name = "cbAddDirectionArrows";
            this.cbAddDirectionArrows.Size = new System.Drawing.Size(122, 17);
            this.cbAddDirectionArrows.TabIndex = 4;
            this.cbAddDirectionArrows.Text = "&Add direction arrows";
            this.cbAddDirectionArrows.UseVisualStyleBackColor = true;
            // 
            // cbFilterByCallId
            // 
            this.cbFilterByCallId.AutoSize = true;
            this.cbFilterByCallId.Location = new System.Drawing.Point(18, 197);
            this.cbFilterByCallId.Name = "cbFilterByCallId";
            this.cbFilterByCallId.Size = new System.Drawing.Size(94, 17);
            this.cbFilterByCallId.TabIndex = 11;
            this.cbFilterByCallId.Text = "Filter by &Call-Id";
            this.cbFilterByCallId.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Mode";
            // 
            // tcSpecific
            // 
            this.tcSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSpecific.Controls.Add(this.tpTHS);
            this.tcSpecific.Location = new System.Drawing.Point(436, 183);
            this.tcSpecific.Name = "tcSpecific";
            this.tcSpecific.SelectedIndex = 0;
            this.tcSpecific.Size = new System.Drawing.Size(333, 107);
            this.tcSpecific.TabIndex = 6;
            // 
            // tpTHS
            // 
            this.tpTHS.Controls.Add(this.cbIncludeHeartbeat);
            this.tpTHS.Controls.Add(this.cbIncludeSIP200);
            this.tpTHS.Controls.Add(this.cbIncludePresenceMsgs);
            this.tpTHS.Location = new System.Drawing.Point(4, 22);
            this.tpTHS.Name = "tpTHS";
            this.tpTHS.Padding = new System.Windows.Forms.Padding(3);
            this.tpTHS.Size = new System.Drawing.Size(325, 81);
            this.tpTHS.TabIndex = 0;
            this.tpTHS.Text = "THS log";
            this.tpTHS.UseVisualStyleBackColor = true;
            // 
            // cbIncludeHeartbeat
            // 
            this.cbIncludeHeartbeat.AutoSize = true;
            this.cbIncludeHeartbeat.Location = new System.Drawing.Point(10, 58);
            this.cbIncludeHeartbeat.Name = "cbIncludeHeartbeat";
            this.cbIncludeHeartbeat.Size = new System.Drawing.Size(129, 17);
            this.cbIncludeHeartbeat.TabIndex = 2;
            this.cbIncludeHeartbeat.Text = "Include HEARTBEAT";
            this.cbIncludeHeartbeat.UseVisualStyleBackColor = true;
            // 
            // cbIncludeSIP200
            // 
            this.cbIncludeSIP200.AutoSize = true;
            this.cbIncludeSIP200.Location = new System.Drawing.Point(10, 35);
            this.cbIncludeSIP200.Name = "cbIncludeSIP200";
            this.cbIncludeSIP200.Size = new System.Drawing.Size(120, 17);
            this.cbIncludeSIP200.TabIndex = 1;
            this.cbIncludeSIP200.Text = "Include SIP 200 OK";
            this.cbIncludeSIP200.UseVisualStyleBackColor = true;
            // 
            // cbIncludePresenceMsgs
            // 
            this.cbIncludePresenceMsgs.AutoSize = true;
            this.cbIncludePresenceMsgs.Location = new System.Drawing.Point(10, 12);
            this.cbIncludePresenceMsgs.Name = "cbIncludePresenceMsgs";
            this.cbIncludePresenceMsgs.Size = new System.Drawing.Size(158, 17);
            this.cbIncludePresenceMsgs.TabIndex = 0;
            this.cbIncludePresenceMsgs.Text = "Include presence messages";
            this.cbIncludePresenceMsgs.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Specific";
            // 
            // cbAddLine
            // 
            this.cbAddLine.AutoSize = true;
            this.cbAddLine.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource1, "AddLineAfter", true));
            this.cbAddLine.Location = new System.Drawing.Point(15, 260);
            this.cbAddLine.Name = "cbAddLine";
            this.cbAddLine.Size = new System.Drawing.Size(199, 17);
            this.cbAddLine.TabIndex = 13;
            this.cbAddLine.Text = "&Add additional line for each message";
            this.cbAddLine.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(15, 6);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(267, 42);
            this.btnPaste.TabIndex = 0;
            this.btnPaste.Text = "P&aste from clipboard";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // lblSourceTextStatus
            // 
            this.lblSourceTextStatus.AutoSize = true;
            this.lblSourceTextStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSourceTextStatus.Location = new System.Drawing.Point(336, 13);
            this.lblSourceTextStatus.Name = "lblSourceTextStatus";
            this.lblSourceTextStatus.Size = new System.Drawing.Size(16, 24);
            this.lblSourceTextStatus.TabIndex = 1;
            this.lblSourceTextStatus.Text = "-";
            // 
            // lblResultToBufferStatus
            // 
            this.lblResultToBufferStatus.AutoSize = true;
            this.lblResultToBufferStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResultToBufferStatus.Location = new System.Drawing.Point(336, 306);
            this.lblResultToBufferStatus.Name = "lblResultToBufferStatus";
            this.lblResultToBufferStatus.Size = new System.Drawing.Size(16, 24);
            this.lblResultToBufferStatus.TabIndex = 13;
            this.lblResultToBufferStatus.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPastedPreview);
            this.panel1.Location = new System.Drawing.Point(18, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 69);
            this.panel1.TabIndex = 14;
            // 
            // lblPastedPreview
            // 
            this.lblPastedPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPastedPreview.Location = new System.Drawing.Point(4, 0);
            this.lblPastedPreview.Name = "lblPastedPreview";
            this.lblPastedPreview.Size = new System.Drawing.Size(743, 67);
            this.lblPastedPreview.TabIndex = 0;
            this.lblPastedPreview.Text = "<no text pasted>";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblParsedPreview);
            this.panel2.Location = new System.Drawing.Point(15, 346);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 69);
            this.panel2.TabIndex = 14;
            // 
            // lblParsedPreview
            // 
            this.lblParsedPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParsedPreview.Location = new System.Drawing.Point(4, 0);
            this.lblParsedPreview.Name = "lblParsedPreview";
            this.lblParsedPreview.Size = new System.Drawing.Size(750, 67);
            this.lblParsedPreview.TabIndex = 0;
            this.lblParsedPreview.Text = "<no text parsed>";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.MinimumSize = new System.Drawing.Size(640, 480);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(828, 480);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnPaste);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.txtMsgRegex);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.txtDateRegex);
            this.tabPage1.Controls.Add(this.lblResultToBufferStatus);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblSourceTextStatus);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtCallIdFilter);
            this.tabPage1.Controls.Add(this.cbAddLine);
            this.tabPage1.Controls.Add(this.cmbTemplate);
            this.tabPage1.Controls.Add(this.tcSpecific);
            this.tabPage1.Controls.Add(this.cbAddDirectionArrows);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbFilterByCallId);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(820, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(820, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Auto mode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rtbGenSipCC);
            this.groupBox3.Controls.Add(this.btnGenSIPCCFIles);
            this.groupBox3.Location = new System.Drawing.Point(377, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 327);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // rtbGenSipCC
            // 
            this.rtbGenSipCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbGenSipCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbGenSipCC.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.rtbGenSipCC.Location = new System.Drawing.Point(6, 48);
            this.rtbGenSipCC.Name = "rtbGenSipCC";
            this.rtbGenSipCC.ReadOnly = true;
            this.rtbGenSipCC.Size = new System.Drawing.Size(377, 273);
            this.rtbGenSipCC.TabIndex = 3;
            this.rtbGenSipCC.Text = "-";
            // 
            // btnGenSIPCCFIles
            // 
            this.btnGenSIPCCFIles.Location = new System.Drawing.Point(6, 19);
            this.btnGenSIPCCFIles.Name = "btnGenSIPCCFIles";
            this.btnGenSIPCCFIles.Size = new System.Drawing.Size(127, 23);
            this.btnGenSIPCCFIles.TabIndex = 0;
            this.btnGenSIPCCFIles.Text = "&Generate SIP CC files";
            this.btnGenSIPCCFIles.UseVisualStyleBackColor = true;
            this.btnGenSIPCCFIles.Click += new System.EventHandler(this.btnGenSIPCCFIles_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbAutoFilterCallId);
            this.groupBox2.Controls.Add(this.cbAutoFilterCallId);
            this.groupBox2.Location = new System.Drawing.Point(377, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // tbAutoFilterCallId
            // 
            this.tbAutoFilterCallId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAutoFilterCallId.Location = new System.Drawing.Point(106, 17);
            this.tbAutoFilterCallId.Name = "tbAutoFilterCallId";
            this.tbAutoFilterCallId.Size = new System.Drawing.Size(277, 20);
            this.tbAutoFilterCallId.TabIndex = 0;
            // 
            // cbAutoFilterCallId
            // 
            this.cbAutoFilterCallId.AutoSize = true;
            this.cbAutoFilterCallId.Location = new System.Drawing.Point(6, 19);
            this.cbAutoFilterCallId.Name = "cbAutoFilterCallId";
            this.cbAutoFilterCallId.Size = new System.Drawing.Size(94, 17);
            this.cbAutoFilterCallId.TabIndex = 10;
            this.cbAutoFilterCallId.Text = "&Filter by Call-Id";
            this.cbAutoFilterCallId.UseVisualStyleBackColor = true;
            this.cbAutoFilterCallId.CheckedChanged += new System.EventHandler(this.cbAutoFilterCallId_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rtbPickedFolder);
            this.groupBox1.Controls.Add(this.btnPickFolder);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 405);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Log Files";
            // 
            // rtbPickedFolder
            // 
            this.rtbPickedFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPickedFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbPickedFolder.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.rtbPickedFolder.Location = new System.Drawing.Point(6, 48);
            this.rtbPickedFolder.Name = "rtbPickedFolder";
            this.rtbPickedFolder.ReadOnly = true;
            this.rtbPickedFolder.Size = new System.Drawing.Size(353, 351);
            this.rtbPickedFolder.TabIndex = 2;
            this.rtbPickedFolder.Text = "-";
            // 
            // btnPickFolder
            // 
            this.btnPickFolder.Location = new System.Drawing.Point(6, 19);
            this.btnPickFolder.Name = "btnPickFolder";
            this.btnPickFolder.Size = new System.Drawing.Size(127, 23);
            this.btnPickFolder.TabIndex = 0;
            this.btnPickFolder.Text = "&Pick a folder...";
            this.btnPickFolder.UseVisualStyleBackColor = true;
            this.btnPickFolder.Click += new System.EventHandler(this.btnPickFolder_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(784, 448);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parse messages";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTemplates)).EndInit();
            this.tcSpecific.ResumeLayout(false);
            this.tpTHS.ResumeLayout(false);
            this.tpTHS.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMsgRegex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDateRegex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCallIdFilter;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.CheckBox cbAddDirectionArrows;
        private System.Windows.Forms.CheckBox cbFilterByCallId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tcSpecific;
        private System.Windows.Forms.TabPage tpTHS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbIncludePresenceMsgs;
        private System.Windows.Forms.CheckBox cbAddLine;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Data.DataSet dsTemplates;
        private System.Data.DataTable tTemplates;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Label lblSourceTextStatus;
        private System.Windows.Forms.Label lblResultToBufferStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPastedPreview;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblParsedPreview;
        private System.Windows.Forms.CheckBox cbIncludeSIP200;
        private System.Windows.Forms.CheckBox cbIncludeHeartbeat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPickFolder;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnGenSIPCCFIles;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbAutoFilterCallId;
        private System.Windows.Forms.CheckBox cbAutoFilterCallId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbGenSipCC;
        private System.Windows.Forms.RichTextBox rtbPickedFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

