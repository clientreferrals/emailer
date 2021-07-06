using Backgrounder;
using NetEmail.DTO;
using NetMail.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class Settings : Form
    {
        BackgroundHelper bgHelper;
        List<EmailDTO> EmailRecords = new List<EmailDTO>();
        private DataTable datatable;
        public Settings()
        {
            try
            {
                InitializeComponent();

                bgHelper = new BackgroundHelper();

                tbxFromWaitTime.Text = SettingsBusiness.Instance.GetValue("WaitFromTime");
                tbxToWaitTime.Text = SettingsBusiness.Instance.GetValue("WaitToTime");
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
                SettingsBusiness.Instance.Set("WaitFromTime", waitFromTime.ToString());
                SettingsBusiness.Instance.Set("WaitToTime", waitToTime.ToString());

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
                    datatable = (DataTable)tableEmails.DataSource;
                    if (datatable == null)
                    {
                        datatable = new DataTable();
                        datatable.Columns.Add(new DataColumn("ID"));
                        datatable.Columns.Add(new DataColumn("Address"));
                        datatable.Columns.Add(new DataColumn("FromAlias"));

                    }
                    // for refresh button
                    if (datatable.Rows.Count > 0)
                    {
                        datatable.Rows.Clear();
                    }

                    EmailRecords = EmailSettingsBusiness.Instance.GetEmails();

                    bgHelper.Foreground(() =>
                    {

                        foreach (var email in EmailRecords)
                        {
                            DataRow row = this.datatable.NewRow();
                            row["ID"] = email.Id.ToString();
                            row["Address"] = email.Address;
                            row["FromAlias"] = email.FromAddress;
                            datatable.Rows.Add(row);
                        }
                        tableEmails.DataSource = datatable; 
                        if (tableEmails.Rows.Count > 0)
                        {
                            tableEmails.Columns[0].Width = 50;
                            tableEmails.Columns[1].Width = 200;
                            tableEmails.Columns[2].Width = 200;
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
