
namespace DirectEmailResults.View
{
    partial class Inbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inbox));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.viewLogsButton = new System.Windows.Forms.Button();
            this.errorRichTextBox = new System.Windows.Forms.RichTextBox();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.downloadLablel = new System.Windows.Forms.Label();
            this.downloadEmailButton = new System.Windows.Forms.Button();
            this.dataGridEmails = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.viewEmailWebBrowser = new System.Windows.Forms.WebBrowser();
            this.userEmailTextBox = new System.Windows.Forms.TextBox();
            this.fromEmailTextBox = new System.Windows.Forms.TextBox();
            this.userEmailAddressLabel = new System.Windows.Forms.Label();
            this.fromEmailAddress = new System.Windows.Forms.Label();
            this.replyButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.viewLogsButton);
            this.groupBox2.Controls.Add(this.errorRichTextBox);
            this.groupBox2.Controls.Add(this.toDateTimePicker);
            this.groupBox2.Controls.Add(this.fromDateTimePicker);
            this.groupBox2.Controls.Add(this.downloadLablel);
            this.groupBox2.Controls.Add(this.downloadEmailButton);
            this.groupBox2.Controls.Add(this.dataGridEmails);
            this.groupBox2.Location = new System.Drawing.Point(12, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 695);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inbox";
            // 
            // viewLogsButton
            // 
            this.viewLogsButton.Location = new System.Drawing.Point(418, 109);
            this.viewLogsButton.Name = "viewLogsButton";
            this.viewLogsButton.Size = new System.Drawing.Size(135, 23);
            this.viewLogsButton.TabIndex = 6;
            this.viewLogsButton.Text = "View Logs";
            this.viewLogsButton.UseVisualStyleBackColor = true;
            this.viewLogsButton.Click += new System.EventHandler(this.viewLogsButton_Click);
            // 
            // errorRichTextBox
            // 
            this.errorRichTextBox.Location = new System.Drawing.Point(6, 88);
            this.errorRichTextBox.Name = "errorRichTextBox";
            this.errorRichTextBox.ReadOnly = true;
            this.errorRichTextBox.Size = new System.Drawing.Size(406, 44);
            this.errorRichTextBox.TabIndex = 5;
            this.errorRichTextBox.Text = "";
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
            // downloadLablel
            // 
            this.downloadLablel.AutoSize = true;
            this.downloadLablel.Location = new System.Drawing.Point(15, 24);
            this.downloadLablel.Name = "downloadLablel";
            this.downloadLablel.Size = new System.Drawing.Size(0, 13);
            this.downloadLablel.TabIndex = 4;
           
            // 
            // dataGridEmails
            // 
            this.dataGridEmails.AllowUserToAddRows = false;
            this.dataGridEmails.AllowUserToDeleteRows = false;
            this.dataGridEmails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmails.Location = new System.Drawing.Point(6, 138);
            this.dataGridEmails.Name = "dataGridEmails";
            this.dataGridEmails.ReadOnly = true;
            this.dataGridEmails.Size = new System.Drawing.Size(547, 551);
            this.dataGridEmails.TabIndex = 2;
            this.dataGridEmails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEmails_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.viewEmailWebBrowser);
            this.groupBox1.Controls.Add(this.userEmailTextBox);
            this.groupBox1.Controls.Add(this.fromEmailTextBox);
            this.groupBox1.Controls.Add(this.userEmailAddressLabel);
            this.groupBox1.Controls.Add(this.fromEmailAddress);
            this.groupBox1.Location = new System.Drawing.Point(577, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 331);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Email";
            // 
            // viewEmailWebBrowser
            // 
            this.viewEmailWebBrowser.Location = new System.Drawing.Point(9, 46);
            this.viewEmailWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.viewEmailWebBrowser.Name = "viewEmailWebBrowser";
            this.viewEmailWebBrowser.Size = new System.Drawing.Size(680, 269);
            this.viewEmailWebBrowser.TabIndex = 24;
            // 
            // userEmailTextBox
            // 
            this.userEmailTextBox.Location = new System.Drawing.Point(463, 18);
            this.userEmailTextBox.Name = "userEmailTextBox";
            this.userEmailTextBox.Size = new System.Drawing.Size(224, 20);
            this.userEmailTextBox.TabIndex = 24;
            // 
            // fromEmailTextBox
            // 
            this.fromEmailTextBox.Location = new System.Drawing.Point(112, 18);
            this.fromEmailTextBox.Name = "fromEmailTextBox";
            this.fromEmailTextBox.Size = new System.Drawing.Size(230, 20);
            this.fromEmailTextBox.TabIndex = 23;
            // 
            // userEmailAddressLabel
            // 
            this.userEmailAddressLabel.AutoSize = true;
            this.userEmailAddressLabel.Location = new System.Drawing.Point(348, 21);
            this.userEmailAddressLabel.Name = "userEmailAddressLabel";
            this.userEmailAddressLabel.Size = new System.Drawing.Size(110, 13);
            this.userEmailAddressLabel.TabIndex = 22;
            this.userEmailAddressLabel.Text = "Sender Email Address";
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
            // replyButton
            // 
            this.replyButton.Location = new System.Drawing.Point(572, 16);
            this.replyButton.Name = "replyButton";
            this.replyButton.Size = new System.Drawing.Size(95, 23);
            this.replyButton.TabIndex = 17;
            this.replyButton.Text = "Reply";
            this.replyButton.UseVisualStyleBackColor = true;
            this.replyButton.Click += new System.EventHandler(this.replyButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.replyButton);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.Location = new System.Drawing.Point(577, 349);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(695, 344);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reply to user";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Email Content";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(9, 43);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(658, 295);
            this.webBrowser1.TabIndex = 1;
            // 
            // Inbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inbox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inbox";
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
        private System.Windows.Forms.Label downloadLablel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button replyButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Label userEmailAddressLabel;
        private System.Windows.Forms.Label fromEmailAddress;
        private System.Windows.Forms.TextBox userEmailTextBox;
        private System.Windows.Forms.TextBox fromEmailTextBox;
        private System.Windows.Forms.WebBrowser viewEmailWebBrowser;
        private System.Windows.Forms.RichTextBox errorRichTextBox;
        private System.Windows.Forms.Button viewLogsButton;
        private System.Windows.Forms.Button downloadEmailButton;
    }
}