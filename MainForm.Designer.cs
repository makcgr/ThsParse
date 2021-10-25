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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnManualModeParse = new System.Windows.Forms.Button();
            this.txtMsgRegex = new System.Windows.Forms.TextBox();
            this.bsLogParserSettingsByType = new System.Windows.Forms.BindingSource(this.components);
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
            this.tpAuto = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.llReport = new System.Windows.Forms.LinkLabel();
            this.rtbGenSipCC = new System.Windows.Forms.RichTextBox();
            this.btnGenReport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.cbDateTo = new System.Windows.Forms.CheckBox();
            this.cbDateFrom = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTraceSetDescription = new System.Windows.Forms.TextBox();
            this.tbAutoFilterCallId = new System.Windows.Forms.TextBox();
            this.cbCreateSeparateMsgLists = new System.Windows.Forms.CheckBox();
            this.cbAutoIncludePresense = new System.Windows.Forms.CheckBox();
            this.cbAutoFilterCallId = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.clbFoundLogTypes = new System.Windows.Forms.CheckedListBox();
            this.rtbPickedFolder = new System.Windows.Forms.RichTextBox();
            this.btnPickFolder = new System.Windows.Forms.Button();
            this.tpManual = new System.Windows.Forms.TabPage();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ttCallId = new System.Windows.Forms.ToolTip(this.components);
            this.cbIncludeSIP200OK = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogParserSettingsByType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTemplates)).BeginInit();
            this.tcSpecific.SuspendLayout();
            this.tpTHS.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpAuto.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnManualModeParse
            // 
            this.btnManualModeParse.Location = new System.Drawing.Point(20, 367);
            this.btnManualModeParse.Margin = new System.Windows.Forms.Padding(4);
            this.btnManualModeParse.Name = "btnManualModeParse";
            this.btnManualModeParse.Size = new System.Drawing.Size(352, 52);
            this.btnManualModeParse.TabIndex = 14;
            this.btnManualModeParse.Text = "&Parse messages and copy to clipboard";
            this.btnManualModeParse.UseVisualStyleBackColor = true;
            this.btnManualModeParse.Click += new System.EventHandler(this.btnManualModeParse_Click);
            // 
            // txtMsgRegex
            // 
            this.txtMsgRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgRegex.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLogParserSettingsByType, "Regex", true));
            this.txtMsgRegex.Location = new System.Drawing.Point(157, 156);
            this.txtMsgRegex.Margin = new System.Windows.Forms.Padding(4);
            this.txtMsgRegex.Multiline = true;
            this.txtMsgRegex.Name = "txtMsgRegex";
            this.txtMsgRegex.Size = new System.Drawing.Size(337, 50);
            this.txtMsgRegex.TabIndex = 8;
            // 
            // bsLogParserSettingsByType
            // 
            this.bsLogParserSettingsByType.DataMember = "Templates";
            this.bsLogParserSettingsByType.DataSource = this.dsTemplates;
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
            this.label1.Location = new System.Drawing.Point(20, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Msg match &regex";
            // 
            // txtDateRegex
            // 
            this.txtDateRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateRegex.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLogParserSettingsByType, "DateTimeRegex", true));
            this.txtDateRegex.Location = new System.Drawing.Point(157, 208);
            this.txtDateRegex.Margin = new System.Windows.Forms.Padding(4);
            this.txtDateRegex.Name = "txtDateRegex";
            this.txtDateRegex.Size = new System.Drawing.Size(337, 22);
            this.txtDateRegex.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 213);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Date regex";
            // 
            // txtCallIdFilter
            // 
            this.txtCallIdFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCallIdFilter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLogParserSettingsByType, "CallIdRegex", true));
            this.txtCallIdFilter.Location = new System.Drawing.Point(157, 240);
            this.txtCallIdFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtCallIdFilter.Name = "txtCallIdFilter";
            this.txtCallIdFilter.Size = new System.Drawing.Size(337, 22);
            this.txtCallIdFilter.TabIndex = 12;
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTemplate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bsLogParserSettingsByType, "DisplayName", true));
            this.cmbTemplate.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsLogParserSettingsByType, "Id", true));
            this.cmbTemplate.DataSource = this.bsLogParserSettingsByType;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(577, 155);
            this.cmbTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(445, 24);
            this.cmbTemplate.TabIndex = 3;
            this.cmbTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbMsgRegex_SelectedIndexChanged);
            // 
            // cbAddDirectionArrows
            // 
            this.cbAddDirectionArrows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAddDirectionArrows.AutoSize = true;
            this.cbAddDirectionArrows.Location = new System.Drawing.Point(584, 185);
            this.cbAddDirectionArrows.Margin = new System.Windows.Forms.Padding(4);
            this.cbAddDirectionArrows.Name = "cbAddDirectionArrows";
            this.cbAddDirectionArrows.Size = new System.Drawing.Size(159, 21);
            this.cbAddDirectionArrows.TabIndex = 4;
            this.cbAddDirectionArrows.Text = "&Add direction arrows";
            this.cbAddDirectionArrows.UseVisualStyleBackColor = true;
            // 
            // cbFilterByCallId
            // 
            this.cbFilterByCallId.AutoSize = true;
            this.cbFilterByCallId.Location = new System.Drawing.Point(24, 242);
            this.cbFilterByCallId.Margin = new System.Windows.Forms.Padding(4);
            this.cbFilterByCallId.Name = "cbFilterByCallId";
            this.cbFilterByCallId.Size = new System.Drawing.Size(123, 21);
            this.cbFilterByCallId.TabIndex = 11;
            this.cbFilterByCallId.Text = "Filter by &Call-Id";
            this.cbFilterByCallId.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Mode";
            // 
            // tcSpecific
            // 
            this.tcSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSpecific.Controls.Add(this.tpTHS);
            this.tcSpecific.Location = new System.Drawing.Point(581, 225);
            this.tcSpecific.Margin = new System.Windows.Forms.Padding(4);
            this.tcSpecific.Name = "tcSpecific";
            this.tcSpecific.SelectedIndex = 0;
            this.tcSpecific.Size = new System.Drawing.Size(444, 132);
            this.tcSpecific.TabIndex = 6;
            // 
            // tpTHS
            // 
            this.tpTHS.Controls.Add(this.cbIncludeHeartbeat);
            this.tpTHS.Controls.Add(this.cbIncludeSIP200);
            this.tpTHS.Controls.Add(this.cbIncludePresenceMsgs);
            this.tpTHS.Location = new System.Drawing.Point(4, 25);
            this.tpTHS.Margin = new System.Windows.Forms.Padding(4);
            this.tpTHS.Name = "tpTHS";
            this.tpTHS.Padding = new System.Windows.Forms.Padding(4);
            this.tpTHS.Size = new System.Drawing.Size(436, 103);
            this.tpTHS.TabIndex = 0;
            this.tpTHS.Text = "THS log";
            this.tpTHS.UseVisualStyleBackColor = true;
            // 
            // cbIncludeHeartbeat
            // 
            this.cbIncludeHeartbeat.AutoSize = true;
            this.cbIncludeHeartbeat.Location = new System.Drawing.Point(13, 71);
            this.cbIncludeHeartbeat.Margin = new System.Windows.Forms.Padding(4);
            this.cbIncludeHeartbeat.Name = "cbIncludeHeartbeat";
            this.cbIncludeHeartbeat.Size = new System.Drawing.Size(162, 21);
            this.cbIncludeHeartbeat.TabIndex = 2;
            this.cbIncludeHeartbeat.Text = "Include HEARTBEAT";
            this.cbIncludeHeartbeat.UseVisualStyleBackColor = true;
            // 
            // cbIncludeSIP200
            // 
            this.cbIncludeSIP200.AutoSize = true;
            this.cbIncludeSIP200.Location = new System.Drawing.Point(13, 43);
            this.cbIncludeSIP200.Margin = new System.Windows.Forms.Padding(4);
            this.cbIncludeSIP200.Name = "cbIncludeSIP200";
            this.cbIncludeSIP200.Size = new System.Drawing.Size(152, 21);
            this.cbIncludeSIP200.TabIndex = 1;
            this.cbIncludeSIP200.Text = "Include SIP 200 OK";
            this.cbIncludeSIP200.UseVisualStyleBackColor = true;
            // 
            // cbIncludePresenceMsgs
            // 
            this.cbIncludePresenceMsgs.AutoSize = true;
            this.cbIncludePresenceMsgs.Location = new System.Drawing.Point(13, 15);
            this.cbIncludePresenceMsgs.Margin = new System.Windows.Forms.Padding(4);
            this.cbIncludePresenceMsgs.Name = "cbIncludePresenceMsgs";
            this.cbIncludePresenceMsgs.Size = new System.Drawing.Size(206, 21);
            this.cbIncludePresenceMsgs.TabIndex = 0;
            this.cbIncludePresenceMsgs.Text = "Include presence messages";
            this.cbIncludePresenceMsgs.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 230);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Specific";
            // 
            // cbAddLine
            // 
            this.cbAddLine.AutoSize = true;
            this.cbAddLine.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsLogParserSettingsByType, "AddLineAfter", true));
            this.cbAddLine.Location = new System.Drawing.Point(20, 320);
            this.cbAddLine.Margin = new System.Windows.Forms.Padding(4);
            this.cbAddLine.Name = "cbAddLine";
            this.cbAddLine.Size = new System.Drawing.Size(263, 21);
            this.cbAddLine.TabIndex = 13;
            this.cbAddLine.Text = "&Add additional line for each message";
            this.cbAddLine.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(20, 7);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(4);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(356, 52);
            this.btnPaste.TabIndex = 0;
            this.btnPaste.Text = "P&aste from clipboard";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // lblSourceTextStatus
            // 
            this.lblSourceTextStatus.AutoSize = true;
            this.lblSourceTextStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSourceTextStatus.Location = new System.Drawing.Point(448, 16);
            this.lblSourceTextStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSourceTextStatus.Name = "lblSourceTextStatus";
            this.lblSourceTextStatus.Size = new System.Drawing.Size(21, 29);
            this.lblSourceTextStatus.TabIndex = 1;
            this.lblSourceTextStatus.Text = "-";
            // 
            // lblResultToBufferStatus
            // 
            this.lblResultToBufferStatus.AutoSize = true;
            this.lblResultToBufferStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResultToBufferStatus.Location = new System.Drawing.Point(448, 377);
            this.lblResultToBufferStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultToBufferStatus.Name = "lblResultToBufferStatus";
            this.lblResultToBufferStatus.Size = new System.Drawing.Size(21, 29);
            this.lblResultToBufferStatus.TabIndex = 13;
            this.lblResultToBufferStatus.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPastedPreview);
            this.panel1.Location = new System.Drawing.Point(24, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 84);
            this.panel1.TabIndex = 14;
            // 
            // lblPastedPreview
            // 
            this.lblPastedPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPastedPreview.Location = new System.Drawing.Point(5, 0);
            this.lblPastedPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPastedPreview.Name = "lblPastedPreview";
            this.lblPastedPreview.Size = new System.Drawing.Size(991, 82);
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
            this.panel2.Location = new System.Drawing.Point(20, 426);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1001, 84);
            this.panel2.TabIndex = 14;
            // 
            // lblParsedPreview
            // 
            this.lblParsedPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParsedPreview.Location = new System.Drawing.Point(5, 0);
            this.lblParsedPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParsedPreview.Name = "lblParsedPreview";
            this.lblParsedPreview.Size = new System.Drawing.Size(1000, 82);
            this.lblParsedPreview.TabIndex = 0;
            this.lblParsedPreview.Text = "<no text parsed>";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpAuto);
            this.tabControl1.Controls.Add(this.tpManual);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.MinimumSize = new System.Drawing.Size(853, 591);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1102, 734);
            this.tabControl1.TabIndex = 16;
            // 
            // tpAuto
            // 
            this.tpAuto.Controls.Add(this.groupBox3);
            this.tpAuto.Controls.Add(this.groupBox2);
            this.tpAuto.Controls.Add(this.groupBox1);
            this.tpAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tpAuto.Location = new System.Drawing.Point(4, 25);
            this.tpAuto.Margin = new System.Windows.Forms.Padding(4);
            this.tpAuto.Name = "tpAuto";
            this.tpAuto.Padding = new System.Windows.Forms.Padding(4);
            this.tpAuto.Size = new System.Drawing.Size(1094, 705);
            this.tpAuto.TabIndex = 1;
            this.tpAuto.Text = "Auto mode";
            this.tpAuto.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Controls.Add(this.llReport);
            this.groupBox3.Controls.Add(this.rtbGenSipCC);
            this.groupBox3.Controls.Add(this.btnGenReport);
            this.groupBox3.Location = new System.Drawing.Point(501, 333);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(519, 316);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(209, 30);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "<STATUS>";
            this.lblStatus.Visible = false;
            // 
            // llReport
            // 
            this.llReport.AutoSize = true;
            this.llReport.Location = new System.Drawing.Point(304, 30);
            this.llReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llReport.Name = "llReport";
            this.llReport.Size = new System.Drawing.Size(154, 17);
            this.llReport.TabIndex = 2;
            this.llReport.TabStop = true;
            this.llReport.Text = "Open generated report";
            this.llReport.Visible = false;
            this.llReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llReport_LinkClicked);
            // 
            // rtbGenSipCC
            // 
            this.rtbGenSipCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbGenSipCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbGenSipCC.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.rtbGenSipCC.Location = new System.Drawing.Point(8, 59);
            this.rtbGenSipCC.Margin = new System.Windows.Forms.Padding(4);
            this.rtbGenSipCC.Name = "rtbGenSipCC";
            this.rtbGenSipCC.ReadOnly = true;
            this.rtbGenSipCC.Size = new System.Drawing.Size(501, 254);
            this.rtbGenSipCC.TabIndex = 1;
            this.rtbGenSipCC.Text = "-";
            // 
            // btnGenReport
            // 
            this.btnGenReport.Location = new System.Drawing.Point(8, 23);
            this.btnGenReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenReport.Name = "btnGenReport";
            this.btnGenReport.Size = new System.Drawing.Size(169, 28);
            this.btnGenReport.TabIndex = 0;
            this.btnGenReport.Text = "&Generate Messages Report";
            this.btnGenReport.UseVisualStyleBackColor = true;
            this.btnGenReport.Click += new System.EventHandler(this.btnGenReport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtpDateTo);
            this.groupBox2.Controls.Add(this.dtpDateTimeFrom);
            this.groupBox2.Controls.Add(this.cbDateTo);
            this.groupBox2.Controls.Add(this.cbDateFrom);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbTraceSetDescription);
            this.groupBox2.Controls.Add(this.tbAutoFilterCallId);
            this.groupBox2.Controls.Add(this.cbCreateSeparateMsgLists);
            this.groupBox2.Controls.Add(this.cbIncludeSIP200OK);
            this.groupBox2.Controls.Add(this.cbAutoIncludePresense);
            this.groupBox2.Controls.Add(this.cbAutoFilterCallId);
            this.groupBox2.Location = new System.Drawing.Point(501, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(519, 318);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(169, 161);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(340, 23);
            this.dtpDateTo.TabIndex = 16;
            // 
            // dtpDateTimeFrom
            // 
            this.dtpDateTimeFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateTimeFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpDateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTimeFrom.Location = new System.Drawing.Point(169, 119);
            this.dtpDateTimeFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateTimeFrom.Name = "dtpDateTimeFrom";
            this.dtpDateTimeFrom.Size = new System.Drawing.Size(340, 23);
            this.dtpDateTimeFrom.TabIndex = 14;
            // 
            // cbDateTo
            // 
            this.cbDateTo.AutoSize = true;
            this.cbDateTo.Location = new System.Drawing.Point(8, 165);
            this.cbDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.cbDateTo.Name = "cbDateTo";
            this.cbDateTo.Size = new System.Drawing.Size(135, 21);
            this.cbDateTo.TabIndex = 15;
            this.cbDateTo.Text = "Filter by Date &To";
            this.cbDateTo.UseVisualStyleBackColor = true;
            // 
            // cbDateFrom
            // 
            this.cbDateFrom.AutoSize = true;
            this.cbDateFrom.Location = new System.Drawing.Point(8, 123);
            this.cbDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.cbDateFrom.Name = "cbDateFrom";
            this.cbDateFrom.Size = new System.Drawing.Size(150, 21);
            this.cbDateFrom.TabIndex = 13;
            this.cbDateFrom.Text = "Filter by Date &From";
            this.cbDateFrom.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Trace set &description";
            // 
            // tbTraceSetDescription
            // 
            this.tbTraceSetDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTraceSetDescription.Location = new System.Drawing.Point(171, 27);
            this.tbTraceSetDescription.Margin = new System.Windows.Forms.Padding(4);
            this.tbTraceSetDescription.Multiline = true;
            this.tbTraceSetDescription.Name = "tbTraceSetDescription";
            this.tbTraceSetDescription.Size = new System.Drawing.Size(339, 45);
            this.tbTraceSetDescription.TabIndex = 0;
            // 
            // tbAutoFilterCallId
            // 
            this.tbAutoFilterCallId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAutoFilterCallId.Location = new System.Drawing.Point(171, 80);
            this.tbAutoFilterCallId.Margin = new System.Windows.Forms.Padding(4);
            this.tbAutoFilterCallId.Name = "tbAutoFilterCallId";
            this.tbAutoFilterCallId.Size = new System.Drawing.Size(339, 23);
            this.tbAutoFilterCallId.TabIndex = 2;
            this.ttCallId.SetToolTip(this.tbAutoFilterCallId, "Enter a Call-ID or several ones using comma as a separator");
            // 
            // cbCreateSeparateMsgLists
            // 
            this.cbCreateSeparateMsgLists.AutoSize = true;
            this.cbCreateSeparateMsgLists.Location = new System.Drawing.Point(8, 283);
            this.cbCreateSeparateMsgLists.Margin = new System.Windows.Forms.Padding(4);
            this.cbCreateSeparateMsgLists.Name = "cbCreateSeparateMsgLists";
            this.cbCreateSeparateMsgLists.Size = new System.Drawing.Size(300, 21);
            this.cbCreateSeparateMsgLists.TabIndex = 19;
            this.cbCreateSeparateMsgLists.Text = "C&reate separate message lists for each log";
            this.cbCreateSeparateMsgLists.UseVisualStyleBackColor = true;
            this.cbCreateSeparateMsgLists.CheckedChanged += new System.EventHandler(this.cbAutoFilterCallId_CheckedChanged);
            // 
            // cbAutoIncludePresense
            // 
            this.cbAutoIncludePresense.AutoSize = true;
            this.cbAutoIncludePresense.Location = new System.Drawing.Point(8, 204);
            this.cbAutoIncludePresense.Margin = new System.Windows.Forms.Padding(4);
            this.cbAutoIncludePresense.Name = "cbAutoIncludePresense";
            this.cbAutoIncludePresense.Size = new System.Drawing.Size(232, 21);
            this.cbAutoIncludePresense.TabIndex = 17;
            this.cbAutoIncludePresense.Text = "&Include presence and wcc-notify";
            this.cbAutoIncludePresense.UseVisualStyleBackColor = true;
            this.cbAutoIncludePresense.CheckedChanged += new System.EventHandler(this.cbAutoFilterCallId_CheckedChanged);
            // 
            // cbAutoFilterCallId
            // 
            this.cbAutoFilterCallId.AutoSize = true;
            this.cbAutoFilterCallId.Location = new System.Drawing.Point(8, 82);
            this.cbAutoFilterCallId.Margin = new System.Windows.Forms.Padding(4);
            this.cbAutoFilterCallId.Name = "cbAutoFilterCallId";
            this.cbAutoFilterCallId.Size = new System.Drawing.Size(123, 21);
            this.cbAutoFilterCallId.TabIndex = 1;
            this.cbAutoFilterCallId.Text = "Filter by &Call-Id";
            this.cbAutoFilterCallId.UseVisualStyleBackColor = true;
            this.cbAutoFilterCallId.CheckedChanged += new System.EventHandler(this.cbAutoFilterCallId_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.clbFoundLogTypes);
            this.groupBox1.Controls.Add(this.rtbPickedFolder);
            this.groupBox1.Controls.Add(this.btnPickFolder);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(485, 642);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Log Files";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(454, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Detected traces list. Choose which ones you want to include to a report";
            // 
            // clbFoundLogTypes
            // 
            this.clbFoundLogTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbFoundLogTypes.FormattingEnabled = true;
            this.clbFoundLogTypes.Location = new System.Drawing.Point(8, 455);
            this.clbFoundLogTypes.Name = "clbFoundLogTypes";
            this.clbFoundLogTypes.Size = new System.Drawing.Size(467, 184);
            this.clbFoundLogTypes.TabIndex = 2;
            // 
            // rtbPickedFolder
            // 
            this.rtbPickedFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPickedFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbPickedFolder.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.rtbPickedFolder.Location = new System.Drawing.Point(8, 59);
            this.rtbPickedFolder.Margin = new System.Windows.Forms.Padding(4);
            this.rtbPickedFolder.Name = "rtbPickedFolder";
            this.rtbPickedFolder.ReadOnly = true;
            this.rtbPickedFolder.Size = new System.Drawing.Size(467, 360);
            this.rtbPickedFolder.TabIndex = 1;
            this.rtbPickedFolder.Text = "-";
            // 
            // btnPickFolder
            // 
            this.btnPickFolder.Location = new System.Drawing.Point(8, 23);
            this.btnPickFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnPickFolder.Name = "btnPickFolder";
            this.btnPickFolder.Size = new System.Drawing.Size(169, 28);
            this.btnPickFolder.TabIndex = 0;
            this.btnPickFolder.Text = "&Pick a folder...";
            this.btnPickFolder.UseVisualStyleBackColor = true;
            this.btnPickFolder.Click += new System.EventHandler(this.btnPickFolder_Click);
            // 
            // tpManual
            // 
            this.tpManual.Controls.Add(this.btnPaste);
            this.tpManual.Controls.Add(this.btnManualModeParse);
            this.tpManual.Controls.Add(this.panel2);
            this.tpManual.Controls.Add(this.txtMsgRegex);
            this.tpManual.Controls.Add(this.panel1);
            this.tpManual.Controls.Add(this.txtDateRegex);
            this.tpManual.Controls.Add(this.lblResultToBufferStatus);
            this.tpManual.Controls.Add(this.label1);
            this.tpManual.Controls.Add(this.lblSourceTextStatus);
            this.tpManual.Controls.Add(this.label2);
            this.tpManual.Controls.Add(this.txtCallIdFilter);
            this.tpManual.Controls.Add(this.cbAddLine);
            this.tpManual.Controls.Add(this.cmbTemplate);
            this.tpManual.Controls.Add(this.tcSpecific);
            this.tpManual.Controls.Add(this.cbAddDirectionArrows);
            this.tpManual.Controls.Add(this.label4);
            this.tpManual.Controls.Add(this.cbFilterByCallId);
            this.tpManual.Controls.Add(this.label3);
            this.tpManual.Location = new System.Drawing.Point(4, 25);
            this.tpManual.Margin = new System.Windows.Forms.Padding(4);
            this.tpManual.Name = "tpManual";
            this.tpManual.Padding = new System.Windows.Forms.Padding(4);
            this.tpManual.Size = new System.Drawing.Size(1094, 645);
            this.tpManual.TabIndex = 0;
            this.tpManual.Text = "Manual mode";
            this.tpManual.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // cbIncludeSIP200OK
            // 
            this.cbIncludeSIP200OK.AutoSize = true;
            this.cbIncludeSIP200OK.Location = new System.Drawing.Point(8, 243);
            this.cbIncludeSIP200OK.Margin = new System.Windows.Forms.Padding(4);
            this.cbIncludeSIP200OK.Name = "cbIncludeSIP200OK";
            this.cbIncludeSIP200OK.Size = new System.Drawing.Size(176, 21);
            this.cbIncludeSIP200OK.TabIndex = 18;
            this.cbIncludeSIP200OK.Text = "Inc&lude SIP/2.0 200 OK";
            this.cbIncludeSIP200OK.UseVisualStyleBackColor = true;
            this.cbIncludeSIP200OK.CheckedChanged += new System.EventHandler(this.cbAutoFilterCallId_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1043, 695);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1061, 680);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACSParse - ACS messages parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsLogParserSettingsByType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTemplates)).EndInit();
            this.tcSpecific.ResumeLayout(false);
            this.tpTHS.ResumeLayout(false);
            this.tpTHS.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpAuto.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpManual.ResumeLayout(false);
            this.tpManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnManualModeParse;
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
        private System.Windows.Forms.BindingSource bsLogParserSettingsByType;
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
        private System.Windows.Forms.TabPage tpManual;
        private System.Windows.Forms.TabPage tpAuto;
        private System.Windows.Forms.Button btnPickFolder;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnGenReport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbAutoFilterCallId;
        private System.Windows.Forms.CheckBox cbAutoFilterCallId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbGenSipCC;
        private System.Windows.Forms.RichTextBox rtbPickedFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTraceSetDescription;
        private System.Windows.Forms.DateTimePicker dtpDateTimeFrom;
        private System.Windows.Forms.CheckBox cbDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.CheckBox cbDateTo;
        private System.Windows.Forms.CheckBox cbAutoIncludePresense;
        private System.Windows.Forms.ToolTip ttCallId;
        private System.Windows.Forms.LinkLabel llReport;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox cbCreateSeparateMsgLists;
        private System.Windows.Forms.CheckedListBox clbFoundLogTypes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbIncludeSIP200OK;
    }
}

