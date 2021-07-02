namespace NetEmail.View
{
    partial class EditEmailAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEmailAccount));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxHostAddress = new System.Windows.Forms.TextBox();
            this.tbxDailyLimit = new System.Windows.Forms.TextBox();
            this.tbxFromAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxFromAlias = new System.Windows.Forms.TextBox();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.popPortNoTbx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.popHostAddressTbx = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxHostAddress);
            this.groupBox1.Controls.Add(this.tbxDailyLimit);
            this.groupBox1.Controls.Add(this.tbxFromAddress);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxFromAlias);
            this.groupBox1.Controls.Add(this.tbxPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SMTP";
            // 
            // tbxHostAddress
            // 
            this.tbxHostAddress.Location = new System.Drawing.Point(147, 44);
            this.tbxHostAddress.Name = "tbxHostAddress";
            this.tbxHostAddress.ReadOnly = true;
            this.tbxHostAddress.Size = new System.Drawing.Size(229, 20);
            this.tbxHostAddress.TabIndex = 4;
            this.tbxHostAddress.Text = "smtp.gmail.com";
            // 
            // tbxDailyLimit
            // 
            this.tbxDailyLimit.Location = new System.Drawing.Point(148, 126);
            this.tbxDailyLimit.Name = "tbxDailyLimit";
            this.tbxDailyLimit.ReadOnly = true;
            this.tbxDailyLimit.Size = new System.Drawing.Size(229, 20);
            this.tbxDailyLimit.TabIndex = 7;
            this.tbxDailyLimit.Text = "500";
            // 
            // tbxFromAddress
            // 
            this.tbxFromAddress.Location = new System.Drawing.Point(147, 70);
            this.tbxFromAddress.Name = "tbxFromAddress";
            this.tbxFromAddress.Size = new System.Drawing.Size(229, 20);
            this.tbxFromAddress.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Host address";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Limit in one cycle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "From address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "From alias";
            // 
            // tbxFromAlias
            // 
            this.tbxFromAlias.Location = new System.Drawing.Point(148, 96);
            this.tbxFromAlias.Name = "tbxFromAlias";
            this.tbxFromAlias.Size = new System.Drawing.Size(229, 20);
            this.tbxFromAlias.TabIndex = 6;
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(147, 19);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.ReadOnly = true;
            this.tbxPort.Size = new System.Drawing.Size(229, 20);
            this.tbxPort.TabIndex = 3;
            this.tbxPort.Text = "587";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Address";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(149, 45);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(229, 20);
            this.tbxPassword.TabIndex = 2;
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(149, 19);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(229, 20);
            this.tbxAddress.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(320, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(239, 366);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(99, 366);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 366);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.popPortNoTbx);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.popHostAddressTbx);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(13, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 91);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IMAP";
            // 
            // popPortNoTbx
            // 
            this.popPortNoTbx.Location = new System.Drawing.Point(149, 19);
            this.popPortNoTbx.Name = "popPortNoTbx";
            this.popPortNoTbx.ReadOnly = true;
            this.popPortNoTbx.Size = new System.Drawing.Size(229, 20);
            this.popPortNoTbx.TabIndex = 8;
            this.popPortNoTbx.Text = "993";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Port";
            // 
            // popHostAddressTbx
            // 
            this.popHostAddressTbx.Location = new System.Drawing.Point(149, 45);
            this.popHostAddressTbx.Name = "popHostAddressTbx";
            this.popHostAddressTbx.ReadOnly = true;
            this.popHostAddressTbx.Size = new System.Drawing.Size(229, 20);
            this.popHostAddressTbx.TabIndex = 9;
            this.popHostAddressTbx.Text = "imap.gmail.com";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Host address";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbxAddress);
            this.groupBox3.Controls.Add(this.tbxPassword);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 80);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Credentials";
            // 
            // EditEmailAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 401);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditEmailAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Email Account";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxFromAlias;
        private System.Windows.Forms.TextBox tbxFromAddress;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxDailyLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox tbxHostAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox popPortNoTbx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox popHostAddressTbx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}