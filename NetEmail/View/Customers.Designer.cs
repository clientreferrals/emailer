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
            this.btnApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTag = new System.Windows.Forms.TextBox();
            this.tbxSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectCustomers = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDownloadSampleCSV = new System.Windows.Forms.Button();
            this.dataGridCustomers = new System.Windows.Forms.DataGridView();
            this.btnAddCsv = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxTag);
            this.groupBox1.Controls.Add(this.tbxSurname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(10, 63);
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
            this.tbxTag.TabIndex = 4;
            // 
            // tbxSurname
            // 
            this.tbxSurname.Location = new System.Drawing.Point(211, 37);
            this.tbxSurname.Name = "tbxSurname";
            this.tbxSurname.Size = new System.Drawing.Size(177, 20);
            this.tbxSurname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surname";
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
            this.groupBox2.Controls.Add(this.btnSelectCustomers);
            this.groupBox2.Controls.Add(this.btnDeleteAll);
            this.groupBox2.Controls.Add(this.btnDownloadSampleCSV);
            this.groupBox2.Controls.Add(this.dataGridCustomers);
            this.groupBox2.Controls.Add(this.btnAddCsv);
            this.groupBox2.Controls.Add(this.btnAddNew);
            this.groupBox2.Location = new System.Drawing.Point(13, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 332);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customers";
            // 
            // btnSelectCustomers
            // 
            this.btnSelectCustomers.Location = new System.Drawing.Point(466, 299);
            this.btnSelectCustomers.Name = "btnSelectCustomers";
            this.btnSelectCustomers.Size = new System.Drawing.Size(135, 23);
            this.btnSelectCustomers.TabIndex = 5;
            this.btnSelectCustomers.Text = "Select Customers";
            this.btnSelectCustomers.UseVisualStyleBackColor = true;
            this.btnSelectCustomers.Click += new System.EventHandler(this.btnSelectCustomers_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(10, 298);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 4;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDownloadSampleCSV
            // 
            this.btnDownloadSampleCSV.Location = new System.Drawing.Point(527, 20);
            this.btnDownloadSampleCSV.Name = "btnDownloadSampleCSV";
            this.btnDownloadSampleCSV.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadSampleCSV.TabIndex = 3;
            this.btnDownloadSampleCSV.Text = "Sample CSV";
            this.btnDownloadSampleCSV.UseVisualStyleBackColor = true;
            this.btnDownloadSampleCSV.Click += new System.EventHandler(this.btnDownloadSampleCSV_Click);
            // 
            // dataGridCustomers
            // 
            this.dataGridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomers.Location = new System.Drawing.Point(10, 48);
            this.dataGridCustomers.Name = "dataGridCustomers";
            this.dataGridCustomers.Size = new System.Drawing.Size(592, 244);
            this.dataGridCustomers.TabIndex = 2;
            this.dataGridCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCustomers_CellDoubleClick);
            // 
            // btnAddCsv
            // 
            this.btnAddCsv.Location = new System.Drawing.Point(89, 19);
            this.btnAddCsv.Name = "btnAddCsv";
            this.btnAddCsv.Size = new System.Drawing.Size(75, 23);
            this.btnAddCsv.TabIndex = 1;
            this.btnAddCsv.Text = "Add CSV";
            this.btnAddCsv.UseVisualStyleBackColor = true;
            this.btnAddCsv.Click += new System.EventHandler(this.btnAddCsv_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(7, 20);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 482);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTag;
        private System.Windows.Forms.TextBox tbxSurname;
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
    }
}