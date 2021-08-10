namespace NetEmail.View
{
    partial class Customers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customers));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.txbCity = new System.Windows.Forms.TextBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.websiteLbl = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTag = new System.Windows.Forms.TextBox();
            this.tbxPhoneNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uploadResponseGB = new System.Windows.Forms.GroupBox();
            this.failedCountLabel = new System.Windows.Forms.Label();
            this.uploadedCountLabel = new System.Windows.Forms.Label();
            this.viewFailedListButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSelectCustomers = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDownloadSampleCSV = new System.Windows.Forms.Button();
            this.dataGridCustomers = new System.Windows.Forms.DataGridView();
            this.btnAddCsv = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.viewUploadedButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.uploadResponseGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cityLabel);
            this.groupBox1.Controls.Add(this.txbCity);
            this.groupBox1.Controls.Add(this.txtWebsite);
            this.groupBox1.Controls.Add(this.websiteLbl);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxTag);
            this.groupBox1.Controls.Add(this.tbxPhoneNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(203, 67);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(24, 13);
            this.cityLabel.TabIndex = 10;
            this.cityLabel.Text = "City";
            // 
            // txbCity
            // 
            this.txbCity.Location = new System.Drawing.Point(206, 83);
            this.txbCity.Name = "txbCity";
            this.txbCity.Size = new System.Drawing.Size(177, 20);
            this.txbCity.TabIndex = 5;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(10, 84);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(177, 20);
            this.txtWebsite.TabIndex = 4;
            // 
            // websiteLbl
            // 
            this.websiteLbl.AutoSize = true;
            this.websiteLbl.Location = new System.Drawing.Point(7, 67);
            this.websiteLbl.Name = "websiteLbl";
            this.websiteLbl.Size = new System.Drawing.Size(46, 13);
            this.websiteLbl.TabIndex = 7;
            this.websiteLbl.Text = "Website";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(407, 81);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tag";
            // 
            // tbxTag
            // 
            this.tbxTag.Location = new System.Drawing.Point(407, 36);
            this.tbxTag.Name = "tbxTag";
            this.tbxTag.Size = new System.Drawing.Size(177, 20);
            this.tbxTag.TabIndex = 3;
            // 
            // tbxPhoneNo
            // 
            this.tbxPhoneNo.Location = new System.Drawing.Point(211, 37);
            this.tbxPhoneNo.Name = "tbxPhoneNo";
            this.tbxPhoneNo.Size = new System.Drawing.Size(177, 20);
            this.tbxPhoneNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PhoneNo";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(10, 37);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(177, 20);
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
            this.groupBox2.Controls.Add(this.uploadResponseGB);
            this.groupBox2.Controls.Add(this.btnSelectCustomers);
            this.groupBox2.Controls.Add(this.btnDeleteAll);
            this.groupBox2.Controls.Add(this.btnDownloadSampleCSV);
            this.groupBox2.Controls.Add(this.dataGridCustomers);
            this.groupBox2.Controls.Add(this.btnAddCsv);
            this.groupBox2.Controls.Add(this.btnAddNew);
            this.groupBox2.Location = new System.Drawing.Point(13, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 352);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customers";
            // 
            // uploadResponseGB
            // 
            this.uploadResponseGB.Controls.Add(this.viewUploadedButton);
            this.uploadResponseGB.Controls.Add(this.failedCountLabel);
            this.uploadResponseGB.Controls.Add(this.uploadedCountLabel);
            this.uploadResponseGB.Controls.Add(this.viewFailedListButton);
            this.uploadResponseGB.Controls.Add(this.label5);
            this.uploadResponseGB.Controls.Add(this.label4);
            this.uploadResponseGB.Controls.Add(this.groupBox4);
            this.uploadResponseGB.Location = new System.Drawing.Point(169, 9);
            this.uploadResponseGB.Name = "uploadResponseGB";
            this.uploadResponseGB.Size = new System.Drawing.Size(351, 51);
            this.uploadResponseGB.TabIndex = 13;
            this.uploadResponseGB.TabStop = false;
            this.uploadResponseGB.Text = "Upload Response";
            // 
            // failedCountLabel
            // 
            this.failedCountLabel.AutoSize = true;
            this.failedCountLabel.ForeColor = System.Drawing.Color.Red;
            this.failedCountLabel.Location = new System.Drawing.Point(191, 31);
            this.failedCountLabel.Name = "failedCountLabel";
            this.failedCountLabel.Size = new System.Drawing.Size(13, 13);
            this.failedCountLabel.TabIndex = 18;
            this.failedCountLabel.Text = "0";
            // 
            // uploadedCountLabel
            // 
            this.uploadedCountLabel.AutoSize = true;
            this.uploadedCountLabel.ForeColor = System.Drawing.Color.Lime;
            this.uploadedCountLabel.Location = new System.Drawing.Point(8, 32);
            this.uploadedCountLabel.Name = "uploadedCountLabel";
            this.uploadedCountLabel.Size = new System.Drawing.Size(13, 13);
            this.uploadedCountLabel.TabIndex = 17;
            this.uploadedCountLabel.Text = "0";
            // 
            // viewFailedListButton
            // 
            this.viewFailedListButton.Location = new System.Drawing.Point(262, 10);
            this.viewFailedListButton.Name = "viewFailedListButton";
            this.viewFailedListButton.Size = new System.Drawing.Size(89, 35);
            this.viewFailedListButton.TabIndex = 16;
            this.viewFailedListButton.Text = "View Failed";
            this.viewFailedListButton.UseVisualStyleBackColor = true;
            this.viewFailedListButton.Click += new System.EventHandler(this.viewFailedListButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(190, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Failed Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(7, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Uploaded Count";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(199, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // btnSelectCustomers
            // 
            this.btnSelectCustomers.Location = new System.Drawing.Point(462, 319);
            this.btnSelectCustomers.Name = "btnSelectCustomers";
            this.btnSelectCustomers.Size = new System.Drawing.Size(135, 23);
            this.btnSelectCustomers.TabIndex = 11;
            this.btnSelectCustomers.Text = "Select Customers";
            this.btnSelectCustomers.UseVisualStyleBackColor = true;
            this.btnSelectCustomers.Click += new System.EventHandler(this.btnSelectCustomers_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(6, 318);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 12;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDownloadSampleCSV
            // 
            this.btnDownloadSampleCSV.Location = new System.Drawing.Point(526, 19);
            this.btnDownloadSampleCSV.Name = "btnDownloadSampleCSV";
            this.btnDownloadSampleCSV.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadSampleCSV.TabIndex = 9;
            this.btnDownloadSampleCSV.Text = "Sample CSV";
            this.btnDownloadSampleCSV.UseVisualStyleBackColor = true;
            this.btnDownloadSampleCSV.Click += new System.EventHandler(this.btnDownloadSampleCSV_Click);
            // 
            // dataGridCustomers
            // 
            this.dataGridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomers.Location = new System.Drawing.Point(6, 68);
            this.dataGridCustomers.Name = "dataGridCustomers";
            this.dataGridCustomers.Size = new System.Drawing.Size(592, 244);
            this.dataGridCustomers.TabIndex = 2;
            this.dataGridCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCustomers_CellDoubleClick);
            // 
            // btnAddCsv
            // 
            this.btnAddCsv.Location = new System.Drawing.Point(88, 18);
            this.btnAddCsv.Name = "btnAddCsv";
            this.btnAddCsv.Size = new System.Drawing.Size(75, 23);
            this.btnAddCsv.TabIndex = 8;
            this.btnAddCsv.Text = "Add CSV";
            this.btnAddCsv.UseVisualStyleBackColor = true;
            this.btnAddCsv.Click += new System.EventHandler(this.btnAddCsv_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(6, 19);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 7;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // viewUploadedButton
            // 
            this.viewUploadedButton.Location = new System.Drawing.Point(95, 9);
            this.viewUploadedButton.Name = "viewUploadedButton";
            this.viewUploadedButton.Size = new System.Drawing.Size(89, 35);
            this.viewUploadedButton.TabIndex = 19;
            this.viewUploadedButton.Text = "View Uploaded";
            this.viewUploadedButton.UseVisualStyleBackColor = true;
            this.viewUploadedButton.Click += new System.EventHandler(this.viewUploadedButton_Click);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 511);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.uploadResponseGB.ResumeLayout(false);
            this.uploadResponseGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTag;
        private System.Windows.Forms.TextBox tbxPhoneNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddCsv;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView dataGridCustomers;
        private System.Windows.Forms.Button btnDownloadSampleCSV;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnSelectCustomers;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox txbCity;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label websiteLbl;
        private System.Windows.Forms.GroupBox uploadResponseGB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label failedCountLabel;
        private System.Windows.Forms.Label uploadedCountLabel;
        private System.Windows.Forms.Button viewFailedListButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button viewUploadedButton;
    }
}