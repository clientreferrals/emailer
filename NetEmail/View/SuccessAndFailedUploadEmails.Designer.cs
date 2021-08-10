
namespace DirectEmailResults.View
{
    partial class SuccessAndFailedUploadEmails
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
            this.failedUploadedEmailDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.failedUploadedEmailDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // failedUploadedEmailDataGridView
            // 
            this.failedUploadedEmailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.failedUploadedEmailDataGridView.Location = new System.Drawing.Point(12, 12);
            this.failedUploadedEmailDataGridView.Name = "failedUploadedEmailDataGridView";
            this.failedUploadedEmailDataGridView.Size = new System.Drawing.Size(609, 487);
            this.failedUploadedEmailDataGridView.TabIndex = 0;
            // 
            // SuccessAndFailedUploadEmails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 511);
            this.Controls.Add(this.failedUploadedEmailDataGridView);
            this.Name = "SuccessAndFailedUploadEmails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emails ";
            ((System.ComponentModel.ISupportInitialize)(this.failedUploadedEmailDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView failedUploadedEmailDataGridView;
    }
}