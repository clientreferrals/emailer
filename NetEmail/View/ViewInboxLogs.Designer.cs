
namespace DirectEmailResults.View
{
    partial class ViewInboxLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewInboxLogs));
            this.logsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // logsGridView
            // 
            this.logsGridView.AllowUserToAddRows = false;
            this.logsGridView.AllowUserToDeleteRows = false;
            this.logsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logsGridView.Location = new System.Drawing.Point(3, 12);
            this.logsGridView.Name = "logsGridView";
            this.logsGridView.Size = new System.Drawing.Size(785, 436);
            this.logsGridView.TabIndex = 3;
            // 
            // ViewInboxLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logsGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewInboxLogs";
            this.Text = "ViewInboxLogs";
            ((System.ComponentModel.ISupportInitialize)(this.logsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView logsGridView;
    }
}