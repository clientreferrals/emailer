using Backgrounder;
using NetEmail.DTO;
using NetMail.Business;
using NetMail.Utility;
using System;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EditEmailAccount : Form
    {
        private readonly EmailDTO emailAccount;
        private readonly BackgroundHelper bgHelper;

        public EditEmailAccount(EmailDTO emailAccount)
        {
            try
            {
                InitializeComponent();

                bgHelper = new BackgroundHelper();


                if (emailAccount.Port == 0)
                {
                    emailAccount.Port = 587;
                }
                if (emailAccount.Host == null || emailAccount.Host != "smtp.gmail.com")
                {
                    emailAccount.Host = "smtp.gmail.com";
                }
                if (emailAccount.PopPort == 0)
                {
                    emailAccount.PopPort = 993;
                }
                if (emailAccount.PopHost == null || emailAccount.PopHost != "imap.gmail.com")
                {
                    emailAccount.PopHost = "imap.gmail.com";
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

                popHostAddressTbx.Text = emailAccount.PopHost;
                popPortNoTbx.Text = emailAccount.PopPort.ToString();

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

                EmailSettingsBusiness.Instance.Save(
                    emailAccount.Id,
                    tbxHostAddress.Text,
                    port,
                    tbxAddress.Text,
                    tbxPassword.Text,
                    tbxFromAddress.Text,
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
                                                tbxFromAddress.Text,
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
                    EmailSettingsBusiness.Instance.Delete(emailAccount.Id);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
