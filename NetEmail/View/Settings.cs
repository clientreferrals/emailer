using Backgrounder;
using BusniessLayer;
using BusniessLayer.Utility;
using DirectEmailResults.View;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class Settings : Form
    {
        private readonly BackgroundHelper bgHelper;
        private List<EmailDTO> ourEmailRecords = new List<EmailDTO>();
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

                SendRateTextBox.Text = applicationSettingServices.GetValue(ConstantKey.SendRateValue);
                int selectedIndex = 0;
                var databaseValue = applicationSettingServices.GetValue(ConstantKey.SendRateKey);
                if (databaseValue != "")
                {
                    selectedIndex = Convert.ToInt32(databaseValue);
                }
                timeSpanDropdown.SelectedIndex = selectedIndex;

                var checkBox = applicationSettingServices.GetValue(ConstantKey.SelectedDelay);
                if (checkBox == "1")
                {
                    TimeDelayGroupBox.Enabled = true;
                    TimeDelayCheckBox.Checked = true;
                    SendRateGroupBox.Enabled = false;
                } else if (checkBox == "2")
                {
                    SendRateGroupBox.Enabled = true;
                    SendRateCheckBox.Checked = true;
                    TimeDelayGroupBox.Enabled = false;
                }

                tbxFromWaitTime.Text = applicationSettingServices.GetValue(ConstantKey.WaitFromTime);
                tbxToWaitTime.Text = applicationSettingServices.GetValue(ConstantKey.WaitToTime);
                maxEmailTextBox.Text = applicationSettingServices.GetValue(ConstantKey.MaxSendsPerDay);
                bccEmailsTextBox.Text = applicationSettingServices.GetValue(ConstantKey.BccEmails);

                if (bccEmailsTextBox.Text == "0")
                {
                    bccEmailsTextBox.Text = "";
                }

                ccTextBox.Text = applicationSettingServices.GetValue(ConstantKey.CcEmails);

                if (ccTextBox.Text == "0")
                {
                    ccTextBox.Text = "";
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
            Close();
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
                string ccEmail = ccTextBox.Text;

                if (!string.IsNullOrEmpty(ccEmail.Trim()))
                {
                    string[] ccEmailAddress = ccEmail.Split(',');
                    for (int i = 0; i < ccEmailAddress.Length; i++)
                    {
                        if (!IsValidEmail(ccEmailAddress[i]))
                        {
                            MessageBox.Show("Invalid CC emails", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                var checkBoxValue = 0;
                if (TimeDelayCheckBox.Checked)
                {
                    checkBoxValue = 1;
                }
                else if (SendRateCheckBox.Checked)
                {
                    checkBoxValue = 2;
                }
                else
                {
                    MessageBox.Show("Please select the Time Delay or Send Rate", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var index = timeSpanDropdown.SelectedIndex;
                applicationSettingServices.AddUpdate(ConstantKey.SendRateKey, index.ToString());
                applicationSettingServices.AddUpdate(ConstantKey.SendRateValue, SendRateTextBox.Text.ToString());
                applicationSettingServices.AddUpdate(ConstantKey.SelectedDelay, checkBoxValue.ToString());



                applicationSettingServices.AddUpdate(ConstantKey.WaitFromTime, waitFromTime.ToString());
                applicationSettingServices.AddUpdate(ConstantKey.WaitToTime, waitToTime.ToString());
                applicationSettingServices.AddUpdate(ConstantKey.MaxSendsPerDay, maxSendsPerDay.ToString());
                if (!string.IsNullOrEmpty(bccEmail.Trim()))
                {
                    applicationSettingServices.AddUpdate(ConstantKey.BccEmails, bccEmail);
                }
                if (!string.IsNullOrEmpty(ccEmail.Trim()))
                {
                    applicationSettingServices.AddUpdate(ConstantKey.CcEmails, ccEmail);
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
                    ourEmailRecords = ourEmailRecords.OrderBy(x => x.Address.ToLower().EndsWith("@gmail.com".ToLower())).ToList();

                    bgHelper.Foreground(() =>
                    {
                        tableEmails.Rows.Clear();
                        foreach (var item in ourEmailRecords)
                        {
                            tableEmails.Rows.Add(item.Id.ToString(), item.Active, item.TodaySent.ToString(),
                                item.SentCount.ToString(), item.Address, item.FromAlias);
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

        private void tableEmails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    var emailRecord = ourEmailRecords[e.RowIndex];
                    // no need to save the email because this on for Active and In Active
                    emailSettingService.MarkActiveInActiveById(
                       emailRecord.Id);

                    RefreshEmailsTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void makeAllActivateButton_Click(object sender, EventArgs e)
        {
            try
            {
                emailSettingService.MarkAllActiveInActive(true);

                RefreshEmailsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MarkAllInActive_Click(object sender, EventArgs e)
        {
            try
            {
                emailSettingService.MarkAllActiveInActive(false);

                RefreshEmailsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TimeDelayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TimeDelayCheckBox.Checked)
            {
                SendRateGroupBox.Enabled = false; 
                TimeDelayGroupBox.Enabled = true;
            }
            else
            { 
                SendRateGroupBox.Enabled = true;
                TimeDelayGroupBox.Enabled = true; 
            }
        }

        private void SendRateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SendRateCheckBox.Checked)
            {
                SendRateGroupBox.Enabled = true;
                TimeDelayGroupBox.Enabled = false;
            }
            else
            {
                SendRateGroupBox.Enabled = true;
                TimeDelayGroupBox.Enabled = true; 
            }
        }

        private void btnAddCsv_Click(object sender, EventArgs e)
        {
            try
            {
                UploadContactCSV form = new UploadContactCSV();
                form.ShowDialog();
                RefreshEmailsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}