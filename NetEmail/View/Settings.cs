using Backgrounder;
using NetEmail.DTO;
using NetMail.Business;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class Settings : Form
    {
        BackgroundHelper bgHelper;
        List<EmailDTO> EmailRecords = new List<EmailDTO>();

        public Settings()
        {
            try
            {
                InitializeComponent();

                bgHelper = new BackgroundHelper();

                tbxFromWaitTime.Text = SettingsBusiness.Instance.GetValue("WaitFromTime");
                tbxToWaitTime.Text = SettingsBusiness.Instance.GetValue("WaitToTime");
                tbxTryAgain.Text = SettingsBusiness.Instance.GetValue("TryAgainCount");

                RefreshEmailsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(tbxFromWaitTime.Text, out int waitFromTime);
                int.TryParse(tbxToWaitTime.Text, out int waitToTime);

                SettingsBusiness.Instance.Set("WaitFromTime", waitFromTime.ToString());
                SettingsBusiness.Instance.Set("WaitToTime", waitToTime.ToString());
                SettingsBusiness.Instance.Set("TryAgainCount", tbxTryAgain.Text);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RefreshEmailsTable()
        {
            bgHelper.Background(() =>
            {
                try
                {
                    EmailRecords = EmailSettingsBusiness.Instance.GetEmails();

                    bgHelper.Foreground(() =>
                    {
                        tableEmails.DataSource = EmailRecords;

                        tableEmails.Columns["Password"].Visible = false;
                        tableEmails.Columns["RemainingLimit"].Visible = false;
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            try
            {
                EditEmailAccount f2 = new EditEmailAccount(new EmailDTO()
                {
                    Id = 0
                });
                f2.ShowDialog();

                RefreshEmailsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tableEmails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tableEmails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var emailRecord = EmailRecords[e.RowIndex];
               
                EditEmailAccount f2 = new EditEmailAccount(emailRecord);
                f2.ShowDialog();

                RefreshEmailsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

         
    }
}
