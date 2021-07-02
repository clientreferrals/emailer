using DirectEmailResults.Business;
using DirectEmailResults.DTO;
using S22.Imap;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Windows.Forms;

namespace DirectEmailResults.View
{
    public partial class BalckListEmails : Form
    {
        private List<BlackListEmailDto> emailRecords = new List<BlackListEmailDto>();

        public BalckListEmails()
        {
            InitializeComponent();
            emailRecords = BlackListEmailBusiness.Instance.GetBlackListEmails();
            GetBlackListEmails();
        }
        public void GetBlackListEmails()
        {
            emailRecords = BlackListEmailBusiness.Instance.GetBlackListEmails();
            blackListEmailsDataGridView.DataSource = emailRecords;
        }

        private void addEmailToBlackListButton_Click(object sender, EventArgs e)
        {
            try
            {
                var email = emailAddressTxb.Text.Trim();
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter the email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    emailAddressTxb.Text = "";
                    emailAddressTxb.Focus();
                    return;
                }
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Please enter the valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (BlackListEmailBusiness.Instance.Save(0, email))
                {
                    emailAddressTxb.Text = "";
                    emailAddressTxb.Focus();
                    GetBlackListEmails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void blackListEmailsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var email = emailRecords[e.RowIndex];
                
                var confirmResult = MessageBox.Show("Are you sure to remove " + email.EmailAddress + " from black list?", "Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    BlackListEmailBusiness.Instance.Delete(email.Id);

                    GetBlackListEmails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }//end of class 
}//end of namespace 
