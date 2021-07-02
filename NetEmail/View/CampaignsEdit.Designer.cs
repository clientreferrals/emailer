namespace NetEmail.View
{
    partial class CampaignsEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CampaignsEdit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxMailSubject = new System.Windows.Forms.TextBox();
            this.lblMailSubject = new System.Windows.Forms.Label();
            this.lblSent = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWaiting = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxTemplates = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.btnDeleteAllCustomers = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.gridCustomers = new System.Windows.Forms.DataGridView();
            this.btnDeleteCampaign = new System.Windows.Forms.Button();
            this.btnStartCampaign = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxMailSubject);
            this.groupBox1.Controls.Add(this.lblMailSubject);
            this.groupBox1.Controls.Add(this.lblSent);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblWaiting);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbxTemplates);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(10, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "You can use @Name@ and @Surname@ tags.";
            // 
            // tbxMailSubject
            // 
            this.tbxMailSubject.Location = new System.Drawing.Point(10, 84);
            this.tbxMailSubject.Name = "tbxMailSubject";
            this.tbxMailSubject.Size = new System.Drawing.Size(261, 20);
            this.tbxMailSubject.TabIndex = 13;
            // 
            // lblMailSubject
            // 
            this.lblMailSubject.AutoSize = true;
            this.lblMailSubject.Location = new System.Drawing.Point(10, 68);
            this.lblMailSubject.Name = "lblMailSubject";
            this.lblMailSubject.Size = new System.Drawing.Size(71, 13);
            this.lblMailSubject.TabIndex = 12;
            this.lblMailSubject.Text = "Email Subject";
            // 
            // lblSent
            // 
            this.lblSent.AutoSize = true;
            this.lblSent.Location = new System.Drawing.Point(206, 156);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(13, 13);
            this.lblSent.TabIndex = 11;
            this.lblSent.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sent";
            // 
            // lblWaiting
            // 
            this.lblWaiting.AutoSize = true;
            this.lblWaiting.Location = new System.Drawing.Point(132, 157);
            this.lblWaiting.Name = "lblWaiting";
            this.lblWaiting.Size = new System.Drawing.Size(13, 13);
            this.lblWaiting.TabIndex = 9;
            this.lblWaiting.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Waiting";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(43, 157);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(50, 133);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(85, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Active / Passive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status";
            // 
            // lbxTemplates
            // 
            this.lbxTemplates.FormattingEnabled = true;
            this.lbxTemplates.Location = new System.Drawing.Point(281, 38);
            this.lbxTemplates.Name = "lbxTemplates";
            this.lbxTemplates.Size = new System.Drawing.Size(291, 134);
            this.lbxTemplates.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(10, 37);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(261, 20);
            this.tbxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblProcessing);
            this.groupBox2.Controls.Add(this.btnDeleteAllCustomers);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnAddCustomer);
            this.groupBox2.Controls.Add(this.gridCustomers);
            this.groupBox2.Location = new System.Drawing.Point(13, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 343);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customers";
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(89, 31);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(127, 13);
            this.lblProcessing.TabIndex = 4;
            this.lblProcessing.Text = "Processing, please wait...";
            // 
            // btnDeleteAllCustomers
            // 
            this.btnDeleteAllCustomers.Location = new System.Drawing.Point(7, 311);
            this.btnDeleteAllCustomers.Name = "btnDeleteAllCustomers";
            this.btnDeleteAllCustomers.Size = new System.Drawing.Size(138, 23);
            this.btnDeleteAllCustomers.TabIndex = 3;
            this.btnDeleteAllCustomers.Text = "Delete All Customers";
            this.btnDeleteAllCustomers.UseVisualStyleBackColor = true;
            this.btnDeleteAllCustomers.Click += new System.EventHandler(this.btnDeleteAllCustomers_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(496, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(7, 26);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // gridCustomers
            // 
            this.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomers.Location = new System.Drawing.Point(7, 55);
            this.gridCustomers.Name = "gridCustomers";
            this.gridCustomers.Size = new System.Drawing.Size(565, 249);
            this.gridCustomers.TabIndex = 0;
            // 
            // btnDeleteCampaign
            // 
            this.btnDeleteCampaign.Location = new System.Drawing.Point(12, 548);
            this.btnDeleteCampaign.Name = "btnDeleteCampaign";
            this.btnDeleteCampaign.Size = new System.Drawing.Size(118, 23);
            this.btnDeleteCampaign.TabIndex = 2;
            this.btnDeleteCampaign.Text = "Delete Campaign";
            this.btnDeleteCampaign.UseVisualStyleBackColor = true;
            this.btnDeleteCampaign.Click += new System.EventHandler(this.btnDeleteCampaign_Click);
            // 
            // btnStartCampaign
            // 
            this.btnStartCampaign.Location = new System.Drawing.Point(136, 548);
            this.btnStartCampaign.Name = "btnStartCampaign";
            this.btnStartCampaign.Size = new System.Drawing.Size(134, 23);
            this.btnStartCampaign.TabIndex = 3;
            this.btnStartCampaign.Text = "Start Campaign";
            this.btnStartCampaign.UseVisualStyleBackColor = true;
            this.btnStartCampaign.Click += new System.EventHandler(this.btnStartCampaign_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(516, 548);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(435, 548);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CampaignsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 583);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStartCampaign);
            this.Controls.Add(this.btnDeleteCampaign);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CampaignsEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Campaign Details";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxTemplates;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gridCustomers;
        private System.Windows.Forms.Button btnDeleteAllCustomers;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnDeleteCampaign;
        private System.Windows.Forms.Button btnStartCampaign;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProcessing;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWaiting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMailSubject;
        private System.Windows.Forms.Label lblMailSubject;
        private System.Windows.Forms.Label label7;
    }
}