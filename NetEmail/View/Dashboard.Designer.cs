namespace NetEmail.View
{
    partial class Dashboard
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnCampaigns = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnTemplates = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prgQueue = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblProcessed = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.emailQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showQueueLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRemainingLimitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unifiedInboxButton = new System.Windows.Forms.Button();
            this.blackEmailsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCustomers
            // 
            this.btnCustomers.Location = new System.Drawing.Point(200, 176);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(160, 60);
            this.btnCustomers.TabIndex = 0;
            this.btnCustomers.Text = "Contacts";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnCampaigns
            // 
            this.btnCampaigns.Location = new System.Drawing.Point(384, 176);
            this.btnCampaigns.Name = "btnCampaigns";
            this.btnCampaigns.Size = new System.Drawing.Size(160, 60);
            this.btnCampaigns.TabIndex = 1;
            this.btnCampaigns.Text = "Campaings";
            this.btnCampaigns.UseVisualStyleBackColor = true;
            this.btnCampaigns.Click += new System.EventHandler(this.btnCampaigns_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(384, 242);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(160, 60);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnTemplates
            // 
            this.btnTemplates.Location = new System.Drawing.Point(11, 242);
            this.btnTemplates.Name = "btnTemplates";
            this.btnTemplates.Size = new System.Drawing.Size(160, 60);
            this.btnTemplates.TabIndex = 3;
            this.btnTemplates.Text = "Templates";
            this.btnTemplates.UseVisualStyleBackColor = true;
            this.btnTemplates.Click += new System.EventHandler(this.btnTemplates_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.prgQueue);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Email Queue";
            // 
            // prgQueue
            // 
            this.prgQueue.Location = new System.Drawing.Point(7, 107);
            this.prgQueue.Name = "prgQueue";
            this.prgQueue.Size = new System.Drawing.Size(519, 23);
            this.prgQueue.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblRemaining);
            this.groupBox4.Location = new System.Drawing.Point(372, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 80);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remaining";
            // 
            // lblRemaining
            // 
            this.lblRemaining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRemaining.Location = new System.Drawing.Point(3, 16);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(114, 61);
            this.lblRemaining.TabIndex = 1;
            this.lblRemaining.Text = "0";
            this.lblRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblProcessed);
            this.groupBox3.Location = new System.Drawing.Point(188, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 80);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Processed";
            // 
            // lblProcessed
            // 
            this.lblProcessed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProcessed.Location = new System.Drawing.Point(3, 16);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(114, 61);
            this.lblProcessed.TabIndex = 1;
            this.lblProcessed.Text = "0";
            this.lblProcessed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Location = new System.Drawing.Point(7, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 80);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotal.Location = new System.Drawing.Point(3, 16);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 61);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailQueueToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // emailQueueToolStripMenuItem
            // 
            this.emailQueueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshQueueToolStripMenuItem,
            this.startProcessingToolStripMenuItem,
            this.stopProcessingToolStripMenuItem,
            this.showQueueLogToolStripMenuItem,
            this.showRemainingLimitsToolStripMenuItem});
            this.emailQueueToolStripMenuItem.Name = "emailQueueToolStripMenuItem";
            this.emailQueueToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.emailQueueToolStripMenuItem.Text = "Email Queue";
            // 
            // refreshQueueToolStripMenuItem
            // 
            this.refreshQueueToolStripMenuItem.Name = "refreshQueueToolStripMenuItem";
            this.refreshQueueToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.refreshQueueToolStripMenuItem.Text = "Refresh Queue";
            this.refreshQueueToolStripMenuItem.Click += new System.EventHandler(this.refreshQueueToolStripMenuItem_Click);
            // 
            // startProcessingToolStripMenuItem
            // 
            this.startProcessingToolStripMenuItem.Name = "startProcessingToolStripMenuItem";
            this.startProcessingToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.startProcessingToolStripMenuItem.Text = "Start Processing";
            this.startProcessingToolStripMenuItem.Click += new System.EventHandler(this.startProcessingToolStripMenuItem_Click);
            // 
            // stopProcessingToolStripMenuItem
            // 
            this.stopProcessingToolStripMenuItem.Name = "stopProcessingToolStripMenuItem";
            this.stopProcessingToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.stopProcessingToolStripMenuItem.Text = "Stop Processing";
            this.stopProcessingToolStripMenuItem.Click += new System.EventHandler(this.stopProcessingToolStripMenuItem_Click);
            // 
            // showQueueLogToolStripMenuItem
            // 
            this.showQueueLogToolStripMenuItem.Name = "showQueueLogToolStripMenuItem";
            this.showQueueLogToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.showQueueLogToolStripMenuItem.Text = "Show Queue Log";
            this.showQueueLogToolStripMenuItem.Click += new System.EventHandler(this.showQueueLogToolStripMenuItem_Click);
            // 
            // showRemainingLimitsToolStripMenuItem
            // 
            this.showRemainingLimitsToolStripMenuItem.Name = "showRemainingLimitsToolStripMenuItem";
            this.showRemainingLimitsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.showRemainingLimitsToolStripMenuItem.Text = "Show Remaining Limits";
            this.showRemainingLimitsToolStripMenuItem.Click += new System.EventHandler(this.showRemainingLimitsToolStripMenuItem_Click);
            // 
            // unifiedInboxButton
            // 
            this.unifiedInboxButton.Location = new System.Drawing.Point(11, 176);
            this.unifiedInboxButton.Name = "unifiedInboxButton";
            this.unifiedInboxButton.Size = new System.Drawing.Size(160, 60);
            this.unifiedInboxButton.TabIndex = 6;
            this.unifiedInboxButton.Text = "Inbox";
            this.unifiedInboxButton.UseVisualStyleBackColor = true;
            this.unifiedInboxButton.Click += new System.EventHandler(this.unifiedInboxButton_Click);
            // 
            // blackEmailsButton
            // 
            this.blackEmailsButton.Location = new System.Drawing.Point(11, 308);
            this.blackEmailsButton.Name = "blackEmailsButton";
            this.blackEmailsButton.Size = new System.Drawing.Size(160, 60);
            this.blackEmailsButton.TabIndex = 7;
            this.blackEmailsButton.Text = "Blocked";
            this.blackEmailsButton.UseVisualStyleBackColor = true;
            this.blackEmailsButton.Click += new System.EventHandler(this.blackEmailsButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 60);
            this.button1.TabIndex = 8;
            this.button1.Text = "Failed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(146, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.blackEmailsButton);
            this.Controls.Add(this.unifiedInboxButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTemplates);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnCampaigns);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inbox Emailer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnCampaigns;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnTemplates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar prgQueue;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblProcessed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem emailQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showQueueLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRemainingLimitsToolStripMenuItem;
        private System.Windows.Forms.Button unifiedInboxButton;
        private System.Windows.Forms.Button blackEmailsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

