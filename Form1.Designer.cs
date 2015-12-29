namespace ParseTHSMsg
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMsgRegex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateRegex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCallIdFilter = new System.Windows.Forms.TextBox();
            this.cmbMsgRegex = new System.Windows.Forms.ComboBox();
            this.cbAddDirectionArrows = new System.Windows.Forms.CheckBox();
            this.cbFilterByCallId = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tcSpecific = new System.Windows.Forms.TabControl();
            this.tpTHS = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIncludePresenceMsgs = new System.Windows.Forms.CheckBox();
            this.tcSpecific.SuspendLayout();
            this.tpTHS.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(815, 159);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(269, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(301, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Parse messages";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 422);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(815, 161);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "Result";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(301, 589);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Copy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtMsgRegex
            // 
            this.txtMsgRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgRegex.Location = new System.Drawing.Point(115, 180);
            this.txtMsgRegex.Multiline = true;
            this.txtMsgRegex.Name = "txtMsgRegex";
            this.txtMsgRegex.Size = new System.Drawing.Size(297, 41);
            this.txtMsgRegex.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Msg match regex";
            // 
            // txtDateRegex
            // 
            this.txtDateRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateRegex.Location = new System.Drawing.Point(115, 222);
            this.txtDateRegex.Name = "txtDateRegex";
            this.txtDateRegex.Size = new System.Drawing.Size(297, 20);
            this.txtDateRegex.TabIndex = 3;
            this.txtDateRegex.Text = "(?<Year>(?:\\d{4}))-(?<Month>\\d{2})-(?<Day>\\d{2})\\s\\d{2}:\\d{2}:\\d{2},\\d{6}\\s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date regex";
            // 
            // txtCallIdFilter
            // 
            this.txtCallIdFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCallIdFilter.Location = new System.Drawing.Point(115, 248);
            this.txtCallIdFilter.Name = "txtCallIdFilter";
            this.txtCallIdFilter.Size = new System.Drawing.Size(297, 20);
            this.txtCallIdFilter.TabIndex = 5;
            this.txtCallIdFilter.Text = "Call-ID:\\s";
            // 
            // cmbMsgRegex
            // 
            this.cmbMsgRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMsgRegex.FormattingEnabled = true;
            this.cmbMsgRegex.Location = new System.Drawing.Point(473, 179);
            this.cmbMsgRegex.Name = "cmbMsgRegex";
            this.cmbMsgRegex.Size = new System.Drawing.Size(354, 21);
            this.cmbMsgRegex.TabIndex = 6;
            this.cmbMsgRegex.SelectedIndexChanged += new System.EventHandler(this.cmbMsgRegex_SelectedIndexChanged);
            // 
            // cbAddDirectionArrows
            // 
            this.cbAddDirectionArrows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAddDirectionArrows.AutoSize = true;
            this.cbAddDirectionArrows.Location = new System.Drawing.Point(475, 203);
            this.cbAddDirectionArrows.Name = "cbAddDirectionArrows";
            this.cbAddDirectionArrows.Size = new System.Drawing.Size(122, 17);
            this.cbAddDirectionArrows.TabIndex = 7;
            this.cbAddDirectionArrows.Text = "Add direction arrows";
            this.cbAddDirectionArrows.UseVisualStyleBackColor = true;
            // 
            // cbFilterByCallId
            // 
            this.cbFilterByCallId.AutoSize = true;
            this.cbFilterByCallId.Location = new System.Drawing.Point(15, 250);
            this.cbFilterByCallId.Name = "cbFilterByCallId";
            this.cbFilterByCallId.Size = new System.Drawing.Size(94, 17);
            this.cbFilterByCallId.TabIndex = 8;
            this.cbFilterByCallId.Text = "Filter by Call-Id";
            this.cbFilterByCallId.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mode";
            // 
            // tcSpecific
            // 
            this.tcSpecific.Controls.Add(this.tpTHS);
            this.tcSpecific.Location = new System.Drawing.Point(473, 236);
            this.tcSpecific.Name = "tcSpecific";
            this.tcSpecific.SelectedIndex = 0;
            this.tcSpecific.Size = new System.Drawing.Size(354, 109);
            this.tcSpecific.TabIndex = 10;
            // 
            // tpTHS
            // 
            this.tpTHS.Controls.Add(this.cbIncludePresenceMsgs);
            this.tpTHS.Location = new System.Drawing.Point(4, 22);
            this.tpTHS.Name = "tpTHS";
            this.tpTHS.Padding = new System.Windows.Forms.Padding(3);
            this.tpTHS.Size = new System.Drawing.Size(346, 83);
            this.tpTHS.TabIndex = 0;
            this.tpTHS.Text = "THS log";
            this.tpTHS.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Specific";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 619);
            this.Controls.Add(this.tcSpecific);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilterByCallId);
            this.Controls.Add(this.cbAddDirectionArrows);
            this.Controls.Add(this.cmbMsgRegex);
            this.Controls.Add(this.txtCallIdFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDateRegex);
            this.Controls.Add(this.txtMsgRegex);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Parse messages";
            this.tcSpecific.ResumeLayout(false);
            this.tpTHS.ResumeLayout(false);
            this.tpTHS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtMsgRegex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDateRegex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCallIdFilter;
        private System.Windows.Forms.ComboBox cmbMsgRegex;
        private System.Windows.Forms.CheckBox cbAddDirectionArrows;
        private System.Windows.Forms.CheckBox cbFilterByCallId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tcSpecific;
        private System.Windows.Forms.TabPage tpTHS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbIncludePresenceMsgs;
    }
}

