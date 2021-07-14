using Backgrounder;
using BusniessLayer;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class Settings : Form
    {
        private readonly BackgroundHelper bgHelper;
        private List<EmailDTO> ourEmailRecords = new List<EmailDTO>();
        private DataTable datatable;

        private readonly EmailSettingService emailSettingService;
        private readonly OurEmailListMaxPerDayService ourEmailListMaxPerDayService;
        private readonly ApplicationSettingServices applicationSettingServices;
        public Settings()
        {
            try
            {
                InitializeComponent();

                bgHelper = new BackgroundHelper();
                emailSettingService = new EmailSettingService();
                ourEmailListMaxPerDayService = new OurEmailListMaxPerDayService();
                applicationSettingServices = new ApplicationSettingServices();
                tbxFromWaitTime.Text = applicationSettingServices.GetValue("WaitFromTime");
                tbxToWaitTime.Text = applicationSettingServices.GetValue("WaitToTime");
                maxEmailTextBox.Text = applicationSettingServices.GetValue("MaxSendsPerDay");
                bccEmailsTextBox.Text = applicationSettingServices.GetValue("BccEmails");
                if(bccEmailsTextBox.Text == "0")
                {
                    bccEmailsTextBox.Text = "";
                }
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
                int.TryParse(maxEmailTextBox.Text, out int maxSendsPerDay);
                if (waitFromTime == 0)
                {
                    MessageBox.Show("Please enter the From seconds");
                    return;
                }
                if (waitToTime == 0)
                {
                    MessageBox.Show("Please enter the To seconds");
                    return;
                }
                string bccEmail = bccEmailsTextBox.Text;

                if (!string.IsNullOrEmpty(bccEmail.Trim()))
                { 
                    string[] bccEmailAddress = bccEmail.Split(',');
                    for (int i = 0; i < bccEmailAddress.Length; i++)
                    {
                        if (!IsValidEmail(bccEmailAddress[i]))
                        {
                            MessageBox.Show("Invalid BCC emails", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                applicationSettingServices.AddUpdate("WaitFromTime", waitFromTime.ToString());
                applicationSettingServices.AddUpdate("WaitToTime", waitToTime.ToString());
                applicationSettingServices.AddUpdate("MaxSendsPerDay", maxSendsPerDay.ToString());
                if (!string.IsNullOrEmpty(bccEmail.Trim()))
                {
                    applicationSettingServices.AddUpdate("BccEmails", bccEmail); 
                }

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
                    ourEmailListMaxPerDayService.ResetCount();
                    ourEmailRecords = emailSettingService.GetEmails();
                    
                    bgHelper.Foreground(() =>
                    {
                        datatable = (DataTable)tableEmails.DataSource;
                        if (datatable == null)
                        {
                            datatable = new DataTable();
                            datatable.Columns.Add(new DataColumn("ID"));
                            datatable.Columns.Add(new DataColumn("TodaySentCount"));
                            datatable.Columns.Add(new DataColumn("TotalSentCount"));
                            datatable.Columns.Add(new DataColumn("Address"));
                            datatable.Columns.Add(new DataColumn("FromAlias"));

                        }
                        // for refresh button
                        if (datatable.Rows.Count > 0)
                        {
                            datatable.Rows.Clear();
                        }

                        foreach (var email in ourEmailRecords)
                        {
                            DataRow row = this.datatable.NewRow();
                            row["ID"] = email.Id.ToString();
                            row["TodaySentCount"] = email.TodaySent.ToString();
                            row["TotalSentCount"] = email.SentCount.ToString();
                            row["Address"] = email.Address;
                            row["FromAlias"] = email.FromAlias;
                            datatable.Rows.Add(row);
                        }
                        tableEmails.DataSource = datatable;
                        if (tableEmails.Rows.Count > 0)
                        {
                            tableEmails.Columns[0].Width = 50;
                            tableEmails.Columns[1].Width = 50;
                            tableEmails.Columns[2].Width = 50;
                            tableEmails.Columns[3].Width = 200;
                            tableEmails.Columns[4].Width = 200;
                        }
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

        private void tableEmails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var emailRecord = ourEmailRecords[e.RowIndex];

                EditEmailAccount f2 = new EditEmailAccount(emailRecord);
                f2.ShowDialog();

                RefreshEmailsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch  
            {
                return false;
            }
        }
    }
}
