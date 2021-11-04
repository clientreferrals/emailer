using Backgrounder;
using BusniessLayer;
using BusniessLayer.Utility;
using Models.DTO;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EditEmailAccount : Form
    {
        private readonly EmailDTO emailAccount;
        private readonly BackgroundHelper bgHelper;
        private readonly EmailSettingService emailSettingService;
        private readonly EmailValidationService emailValidationService;
        private readonly List<string> notAllowedList = new List<string>();
        private readonly List<string> alreadyValidEmailList = new List<string>();
        public EditEmailAccount(EmailDTO emailAccount)
        {
            try
            {
                InitializeComponent();

                emailSettingService = new EmailSettingService();
                emailValidationService = new EmailValidationService();
                notAllowedList = emailValidationService.GetNotAllowList();
                alreadyValidEmailList = emailValidationService.GetValidEmails();
                bgHelper = new BackgroundHelper();

                if (emailAccount.Port == 0)
                {
                    emailAccount.Port = 587;
                }
                if (string.IsNullOrEmpty(emailAccount.Host))
                {
                    emailAccount.Host = "smtp.gmail.com";
                }
                if (emailAccount.IMAPPort == 0)
                {
                    emailAccount.IMAPPort = 993;
                }
                if (string.IsNullOrEmpty(emailAccount.IMAPHost))
                {
                    emailAccount.IMAPHost = "imap.gmail.com";
                }
                if (emailAccount.DailyLimit == 0)
                {
                    tbxDailyLimit.Text = 500.ToString();
                }
                else
                {
                    tbxDailyLimit.Text = emailAccount.DailyLimit.ToString();
                }
                tbxAddress.Text = emailAccount.Address;
                tbxFromAlias.Text = emailAccount.FromAlias;
                tbxPassword.Text = emailAccount.Password;
                tbxPort.Text = emailAccount.Port.ToString();
                tbxHostAddress.Text = emailAccount.Host;
                popHostAddressTbx.Text = emailAccount.IMAPHost;
                popPortNoTbx.Text = emailAccount.IMAPPort.ToString();

                this.emailAccount = emailAccount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                int.TryParse(tbxPort.Text, out int port);
                int.TryParse(tbxDailyLimit.Text, out int dailyLimit);
                if (!IsValidEmail(tbxAddress.Text))
                {
                    MessageBox.Show("Please enter a valid email.");
                    return;
                }
                if (string.IsNullOrEmpty(tbxPassword.Text.Trim()))
                {
                    MessageBox.Show("Please enter a password.");

                    return;
                }
                if (string.IsNullOrEmpty(tbxFromAlias.Text.Trim()))
                {
                    MessageBox.Show("Please enter From Alias.");
                    return;
                }

                btnOK.Enabled = false;
                bool valid = true;

                if (notAllowedList.Any(x => tbxAddress.Text.ToLower().Contains(x.ToLower())))

                {
                    valid = false;
                }
                else if (alreadyValidEmailList.Any(x => tbxAddress.Text.ToLower().Contains(x.ToLower())))
                {
                    valid = true;
                }
                else if (ValidateEmailUsingAPI.EmailValidationUsingAPI(tbxAddress.Text).Result == false)
                {
                    valid = false;
                }

                if (valid == false)
                {
                    MessageBox.Show("There some keyword which are not allowed to enter or the email is not valid.");
                    btnOK.Enabled = true;
                    return;
                }
                valid = emailSettingService.Save(
                  emailAccount.Id,
                  tbxHostAddress.Text,
                  port,
                  tbxAddress.Text,
                  tbxPassword.Text,
                  tbxFromAlias.Text,
                  dailyLimit,
                  Convert.ToInt32(popPortNoTbx.Text),
                  popHostAddressTbx.Text

              );
                if (valid)
                {
                    emailValidationService.SaveNewRecord(tbxAddress.Text, valid);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                EditEmailAccountTestEmailAddress f2 = new EditEmailAccountTestEmailAddress();

                var testAddressResult = f2.ShowDialog();

                if (testAddressResult == DialogResult.OK)
                {
                    btnTest.Text = "Testing...";

                    bgHelper.Background(() =>
                    {
                        try
                        {
                            var result = EmailHelper.Instance.SetCredentials(tbxHostAddress.Text,
                                                Int32.Parse(tbxPort.Text),
                                                tbxAddress.Text,
                                                tbxPassword.Text,
                                                tbxFromAlias.Text
                                                )
                                                .Send(new System.Collections.Generic.List<string>() { f2.ReturnValue }, "Test email", "This is a test email.");

                            string message = "";

                            if (result.Success == true)
                            {
                                message = "Email is sent successfully.";
                            }
                            else
                            {
                                message = result.Message;
                            }

                            bgHelper.Foreground(() =>
                        {
                            btnTest.Text = "Test";
                            MessageBox.Show(message);
                        });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ?", "Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    emailSettingService.Delete(emailAccount.Id);
                    this.Close();
                }
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
