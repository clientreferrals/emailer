﻿namespace NetEmail.View
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MarkAllInActive = new System.Windows.Forms.Button();
            this.makeAllActivateButton = new System.Windows.Forms.Button();
            this.btnAddEmail = new System.Windows.Forms.Button();
            this.tableEmails = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activecheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TodaySentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFromWaitTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxToWaitTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeSpanDropdown = new System.Windows.Forms.ComboBox();
            this.bccEmailsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxEmailTextBox = new System.Windows.Forms.TextBox();
            this.MaxSendsPerDay = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEmails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(359, 509);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(444, 509);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MarkAllInActive);
            this.groupBox2.Controls.Add(this.makeAllActivateButton);
            this.groupBox2.Controls.Add(this.btnAddEmail);
            this.groupBox2.Controls.Add(this.tableEmails);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 366);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Email Accounts";
            // 
            // MarkAllInActive
            // 
            this.MarkAllInActive.Location = new System.Drawing.Point(227, 337);
            this.MarkAllInActive.Name = "MarkAllInActive";
            this.MarkAllInActive.Size = new System.Drawing.Size(116, 23);
            this.MarkAllInActive.TabIndex = 3;
            this.MarkAllInActive.Text = "Make All In Active";
            this.MarkAllInActive.UseVisualStyleBackColor = true;
            this.MarkAllInActive.Click += new System.EventHandler(this.MarkAllInActive_Click);
            // 
            // makeAllActivateButton
            // 
            this.makeAllActivateButton.Location = new System.Drawing.Point(97, 337);
            this.makeAllActivateButton.Name = "makeAllActivateButton";
            this.makeAllActivateButton.Size = new System.Drawing.Size(116, 23);
            this.makeAllActivateButton.TabIndex = 2;
            this.makeAllActivateButton.Text = "Make All Active";
            this.makeAllActivateButton.UseVisualStyleBackColor = true;
            this.makeAllActivateButton.Click += new System.EventHandler(this.makeAllActivateButton_Click);
            // 
            // btnAddEmail
            // 
            this.btnAddEmail.Location = new System.Drawing.Point(6, 337);
            this.btnAddEmail.Name = "btnAddEmail";
            this.btnAddEmail.Size = new System.Drawing.Size(75, 23);
            this.btnAddEmail.TabIndex = 1;
            this.btnAddEmail.Text = "Add";
            this.btnAddEmail.UseVisualStyleBackColor = true;
            this.btnAddEmail.Click += new System.EventHandler(this.btnAddEmail_Click);
            // 
            // tableEmails
            // 
            this.tableEmails.AllowUserToAddRows = false;
            this.tableEmails.AllowUserToDeleteRows = false;
            this.tableEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableEmails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Activecheckbox,
            this.TodaySentCount,
            this.TotalSentCount,
            this.Address,
            this.FromAlias});
            this.tableEmails.Location = new System.Drawing.Point(0, 19);
            this.tableEmails.Name = "tableEmails";
            this.tableEmails.ReadOnly = true;
            this.tableEmails.Size = new System.Drawing.Size(493, 311);
            this.tableEmails.TabIndex = 0;
            this.tableEmails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableEmails_CellContentClick);
            this.tableEmails.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableEmails_CellContentDoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Activecheckbox
            // 
            this.Activecheckbox.HeaderText = "Active";
            this.Activecheckbox.Name = "Activecheckbox";
            this.Activecheckbox.ReadOnly = true;
            // 
            // TodaySentCount
            // 
            this.TodaySentCount.HeaderText = "Today Sent Count";
            this.TodaySentCount.Name = "TodaySentCount";
            this.TodaySentCount.ReadOnly = true;
            // 
            // TotalSentCount
            // 
            this.TotalSentCount.HeaderText = "Total Sent Count";
            this.TotalSentCount.Name = "TotalSentCount";
            this.TotalSentCount.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // FromAlias
            // 
            this.FromAlias.HeaderText = "From Alias";
            this.FromAlias.Name = "FromAlias";
            this.FromAlias.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // tbxFromWaitTime
            // 
            this.tbxFromWaitTime.Location = new System.Drawing.Point(41, 17);
            this.tbxFromWaitTime.Name = "tbxFromWaitTime";
            this.tbxFromWaitTime.Size = new System.Drawing.Size(60, 20);
            this.tbxFromWaitTime.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // tbxToWaitTime
            // 
            this.tbxToWaitTime.Location = new System.Drawing.Point(133, 17);
            this.tbxToWaitTime.Name = "tbxToWaitTime";
            this.tbxToWaitTime.Size = new System.Drawing.Size(60, 20);
            this.tbxToWaitTime.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeSpanDropdown);
            this.groupBox1.Controls.Add(this.bccEmailsTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.maxEmailTextBox);
            this.groupBox1.Controls.Add(this.MaxSendsPerDay);
            this.groupBox1.Controls.Add(this.tbxToWaitTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxFromWaitTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic";
            // 
            // timeSpanDropdown
            // 
            this.timeSpanDropdown.FormattingEnabled = true;
            this.timeSpanDropdown.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours"});
            this.timeSpanDropdown.Location = new System.Drawing.Point(200, 17);
            this.timeSpanDropdown.Name = "timeSpanDropdown";
            this.timeSpanDropdown.Size = new System.Drawing.Size(91, 21);
            this.timeSpanDropdown.TabIndex = 8; 
            // 
            // bccEmailsTextBox
            // 
            this.bccEmailsTextBox.Location = new System.Drawing.Point(41, 61);
            this.bccEmailsTextBox.Name = "bccEmailsTextBox";
            this.bccEmailsTextBox.Size = new System.Drawing.Size(464, 20);
            this.bccEmailsTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "BCC";
            // 
            // maxEmailTextBox
            // 
            this.maxEmailTextBox.Location = new System.Drawing.Point(428, 19);
            this.maxEmailTextBox.Name = "maxEmailTextBox";
            this.maxEmailTextBox.Size = new System.Drawing.Size(77, 20);
            this.maxEmailTextBox.TabIndex = 3;
            // 
            // MaxSendsPerDay
            // 
            this.MaxSendsPerDay.AutoSize = true;
            this.MaxSendsPerDay.Location = new System.Drawing.Point(315, 22);
            this.MaxSendsPerDay.Name = "MaxSendsPerDay";
            this.MaxSendsPerDay.Size = new System.Drawing.Size(107, 13);
            this.MaxSendsPerDay.TabIndex = 5;
            this.MaxSendsPerDay.Text = "Max Sends Per Day: ";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 544);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableEmails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tableEmails;
        private System.Windows.Forms.Button btnAddEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxFromWaitTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxToWaitTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox maxEmailTextBox;
        private System.Windows.Forms.Label MaxSendsPerDay;
        private System.Windows.Forms.TextBox bccEmailsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activecheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn TodaySentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromAlias;
        private System.Windows.Forms.Button makeAllActivateButton;
        private System.Windows.Forms.Button MarkAllInActive;
        private System.Windows.Forms.ComboBox timeSpanDropdown;
    }
}