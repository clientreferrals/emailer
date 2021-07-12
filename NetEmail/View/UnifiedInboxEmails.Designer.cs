
namespace DirectEmailResults.View
{
    partial class UnifiedInboxEmails
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.perEmailCountTextBox = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.downloadLable = new System.Windows.Forms.Label();
            this.downloadEmailButton = new System.Windows.Forms.Button();
            this.dataGridEmails = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.viewUserEmailRichTextBox = new System.Windows.Forms.RichTextBox();
            this.replyButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.ComposeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.fromEmailAddress = new System.Windows.Forms.Label();
            this.userEmailAddressLabel = new System.Windows.Forms.Label();
            this.fromEmailTextBox = new System.Windows.Forms.TextBox();
            this.userEmailTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toDateTimePicker);
            this.groupBox2.Controls.Add(this.fromDateTimePicker);
            this.groupBox2.Controls.Add(this.perEmailCountTextBox);
            this.groupBox2.Controls.Add(this.totalLabel);
            this.groupBox2.Controls.Add(this.downloadLable);
            this.groupBox2.Controls.Add(this.downloadEmailButton);
            this.groupBox2.Controls.Add(this.dataGridEmails);
            this.groupBox2.Location = new System.Drawing.Point(12, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 643);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unified Email Inbox";
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Location = new System.Drawing.Point(205, 61);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(207, 20);
            this.toDateTimePicker.TabIndex = 3;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Location = new System.Drawing.Point(7, 61);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(192, 20);
            this.fromDateTimePicker.TabIndex = 2;
            // 
            // perEmailCountTextBox
            // 
            this.perEmailCountTextBox.Location = new System.Drawing.Point(376, 21);
            this.perEmailCountTextBox.Name = "perEmailCountTextBox";
            this.perEmailCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.perEmailCountTextBox.TabIndex = 1;
            this.perEmailCountTextBox.Text = "25";
            this.perEmailCountTextBox.TextChanged += new System.EventHandler(this.perEmailCountTextBox_TextChanged);
            this.perEmailCountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.perEmailCountTextBox_KeyPress);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(196, 24);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(13, 13);
            this.totalLabel.TabIndex = 4;
            this.totalLabel.Text = "0";
            // 
            // downloadLable
            // 
            this.downloadLable.AutoSize = true;
            this.downloadLable.Location = new System.Drawing.Point(15, 24);
            this.downloadLable.Name = "downloadLable";
            this.downloadLable.Size = new System.Drawing.Size(0, 13);
            this.downloadLable.TabIndex = 4;
            // 
            // downloadEmailButton
            // 
            this.downloadEmailButton.Location = new System.Drawing.Point(418, 61);
            this.downloadEmailButton.Name = "downloadEmailButton";
            this.downloadEmailButton.Size = new System.Drawing.Size(121, 23);
            this.downloadEmailButton.TabIndex = 4;
            this.downloadEmailButton.Text = "Download";
            this.downloadEmailButton.UseVisualStyleBackColor = true;
            this.downloadEmailButton.Click += new System.EventHandler(this.refreshEmails_Click);
            // 
            // dataGridEmails
            // 
            this.dataGridEmails.AllowUserToAddRows = false;
            this.dataGridEmails.AllowUserToDeleteRows = false;
            this.dataGridEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmails.Location = new System.Drawing.Point(6, 90);
            this.dataGridEmails.Name = "dataGridEmails";
            this.dataGridEmails.ReadOnly = true;
            this.dataGridEmails.Size = new System.Drawing.Size(533, 547);
            this.dataGridEmails.TabIndex = 2;
            this.dataGridEmails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCustomers_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userEmailTextBox);
            this.groupBox1.Controls.Add(this.fromEmailTextBox);
            this.groupBox1.Controls.Add(this.userEmailAddressLabel);
            this.groupBox1.Controls.Add(this.fromEmailAddress);
            this.groupBox1.Controls.Add(this.viewUserEmailRichTextBox);
            this.groupBox1.Location = new System.Drawing.Point(577, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 272);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Email";
            // 
            // viewUserEmailRichTextBox
            // 
            this.viewUserEmailRichTextBox.Location = new System.Drawing.Point(4, 45);
            this.viewUserEmailRichTextBox.Name = "viewUserEmailRichTextBox";
            this.viewUserEmailRichTextBox.ReadOnly = true;
            this.viewUserEmailRichTextBox.Size = new System.Drawing.Size(591, 221);
            this.viewUserEmailRichTextBox.TabIndex = 20;
            this.viewUserEmailRichTextBox.Text = "";
            // 
            // replyButton
            // 
            this.replyButton.Location = new System.Drawing.Point(500, 14);
            this.replyButton.Name = "replyButton";
            this.replyButton.Size = new System.Drawing.Size(95, 23);
            this.replyButton.TabIndex = 17;
            this.replyButton.Text = "Reply";
            this.replyButton.UseVisualStyleBackColor = true;
            this.replyButton.Click += new System.EventHandler(this.replyButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.emailTextBox);
            this.groupBox3.Controls.Add(this.ComposeButton);
            this.groupBox3.Controls.Add(this.replyButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.Location = new System.Drawing.Point(577, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(601, 357);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reply to user";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(166, 16);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(187, 20);
            this.emailTextBox.TabIndex = 23;
            // 
            // ComposeButton
            // 
            this.ComposeButton.Location = new System.Drawing.Point(370, 14);
            this.ComposeButton.Name = "ComposeButton";
            this.ComposeButton.Size = new System.Drawing.Size(95, 23);
            this.ComposeButton.TabIndex = 22;
            this.ComposeButton.Text = "Compose";
            this.ComposeButton.UseVisualStyleBackColor = true;
            this.ComposeButton.Click += new System.EventHandler(this.ComposeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Please enter you email";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(9, 49);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(586, 302);
            this.webBrowser1.TabIndex = 1;
            // 
            // fromEmailAddress
            // 
            this.fromEmailAddress.AutoSize = true;
            this.fromEmailAddress.Location = new System.Drawing.Point(6, 20);
            this.fromEmailAddress.Name = "fromEmailAddress";
            this.fromEmailAddress.Size = new System.Drawing.Size(99, 13);
            this.fromEmailAddress.TabIndex = 21;
            this.fromEmailAddress.Text = "From Email Address";
            // 
            // userEmailAddressLabel
            // 
            this.userEmailAddressLabel.AutoSize = true;
            this.userEmailAddressLabel.Location = new System.Drawing.Point(315, 20);
            this.userEmailAddressLabel.Name = "userEmailAddressLabel";
            this.userEmailAddressLabel.Size = new System.Drawing.Size(98, 13);
            this.userEmailAddressLabel.TabIndex = 22;
            this.userEmailAddressLabel.Text = "User Email Address";
            // 
            // fromEmailTextBox
            // 
            this.fromEmailTextBox.Location = new System.Drawing.Point(112, 18);
            this.fromEmailTextBox.Name = "fromEmailTextBox";
            this.fromEmailTextBox.Size = new System.Drawing.Size(197, 20);
            this.fromEmailTextBox.TabIndex = 23;
            // 
            // userEmailTextBox
            // 
            this.userEmailTextBox.Location = new System.Drawing.Point(419, 18);
            this.userEmailTextBox.Name = "userEmailTextBox";
            this.userEmailTextBox.Size = new System.Drawing.Size(176, 20);
            this.userEmailTextBox.TabIndex = 24;
            // 
            // UnifiedInboxEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 659);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "UnifiedInboxEmails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unified Inbox Emails";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridEmails;
        private System.Windows.Forms.Label downloadLable;
        private System.Windows.Forms.Button downloadEmailButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox viewUserEmailRichTextBox;
        private System.Windows.Forms.Button replyButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button ComposeButton;
        private System.Windows.Forms.TextBox perEmailCountTextBox;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Label userEmailAddressLabel;
        private System.Windows.Forms.Label fromEmailAddress;
        private System.Windows.Forms.TextBox userEmailTextBox;
        private System.Windows.Forms.TextBox fromEmailTextBox;
    }
}