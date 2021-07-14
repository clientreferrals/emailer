using Backgrounder;
using BusniessLayer;
using Models.DTO;
using NetMail.Utility;
using System;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EditEmailAccount : Form
    {
        private readonly EmailDTO emailAccount;
        private readonly BackgroundHelper bgHelper;
        private readonly EmailSettingService emailSettingService;

        public EditEmailAccount(EmailDTO emailAccount)
        {
            try
            {
                InitializeComponent();

                emailSettingService = new EmailSettingService();

                bgHelper = new BackgroundHelper();

                if (emailAccount.Port == 0)
                {
                    emailAccount.Port = 587;
                }
                if (emailAccount.Host == null || emailAccount.Host != "smtp.gmail.com")
                {
                    emailAccount.Host = "smtp.gmail.com";
                }
                if (emailAccount.IMAPPort == 0)
                {
                    emailAccount.IMAPPort = 993;
                }
                if (emailAccount.IMAPHost == null || emailAccount.IMAPHost != "imap.gmail.com")
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
                int port = 0;
                int dailyLimit = 0;

                int.TryParse(tbxPort.Text, out port);
                int.TryParse(tbxDailyLimit.Text, out dailyLimit);
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
                emailSettingService.Save(
                    emailAccount.Id,
                    tbxHostAddress.Text,
                    port,
                    tbxAddress.Text,
                    tbxPassword.Text,
                    tbxHostAddress.Text,
                    tbxFromAlias.Text,
                    dailyLimit,
                    Convert.ToInt32(popPortNoTbx.Text),
                    popHostAddressTbx.Text

                );

                this.Close();
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
