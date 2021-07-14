
namespace DirectEmailResults.View
{
    partial class BalckListEmails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalckListEmails));
            this.addEmailToBlackListButton = new System.Windows.Forms.Button();
            this.blackListEmailsDataGridView = new System.Windows.Forms.DataGridView();
            this.emailAddressTxb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.blackListEmailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addEmailToBlackListButton
            // 
            this.addEmailToBlackListButton.Location = new System.Drawing.Point(269, 14);
            this.addEmailToBlackListButton.Name = "addEmailToBlackListButton";
            this.addEmailToBlackListButton.Size = new System.Drawing.Size(116, 23);
            this.addEmailToBlackListButton.TabIndex = 0;
            this.addEmailToBlackListButton.Text = "Add Emails to Block";
            this.addEmailToBlackListButton.UseVisualStyleBackColor = true;
            this.addEmailToBlackListButton.Click += new System.EventHandler(this.addEmailToBlackListButton_Click);
            // 
            // blackListEmailsDataGridView
            // 
            this.blackListEmailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blackListEmailsDataGridView.Location = new System.Drawing.Point(37, 64);
            this.blackListEmailsDataGridView.Name = "blackListEmailsDataGridView";
            this.blackListEmailsDataGridView.Size = new System.Drawing.Size(348, 374);
            this.blackListEmailsDataGridView.TabIndex = 2;
            this.blackListEmailsDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.blackListEmailsDataGridView_CellContentDoubleClick);
            // 
            // emailAddressTxb
            // 
            this.emailAddressTxb.Location = new System.Drawing.Point(37, 16);
            this.emailAddressTxb.Name = "emailAddressTxb";
            this.emailAddressTxb.Size = new System.Drawing.Size(203, 20);
            this.emailAddressTxb.TabIndex = 1;
            // 
            // BalckListEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 450);
            this.Controls.Add(this.emailAddressTxb);
            this.Controls.Add(this.blackListEmailsDataGridView);
            this.Controls.Add(this.addEmailToBlackListButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BalckListEmails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show New Emails";
            ((System.ComponentModel.ISupportInitialize)(this.blackListEmailsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addEmailToBlackListButton;
        private System.Windows.Forms.DataGridView blackListEmailsDataGridView;
        private System.Windows.Forms.TextBox emailAddressTxb;
    }
}