using Backgrounder;
using BusniessLayer;
using Models.DTO;
using NetMail.Utility;
using S22.Imap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectEmailResults.View
{
    public partial class UnifiedInboxEmails : Form
    {
        private readonly BlockListEmailService blockListEmailService;
        private readonly EmailSettingService emailSettingService;

        private List<BlockListEmailDto> blackListEmailRecords = new List<BlockListEmailDto>();
        private List<EmailDTO> emailRecords = new List<EmailDTO>();
        private int totalEmailNumber = 0;
        private int perEmailCount = 25;

        private List<ViewEmailDto> unReadEmails = new List<ViewEmailDto>();
        private DataTable datatable;

        private ViewEmailDto _currentInboxEmail;
        private string _templateContent = "";
        private string viewEmailBody = "";
        private readonly BackgroundHelper bgHelper;
        public UnifiedInboxEmails()
        {

            InitializeComponent();
            blockListEmailService = new BlockListEmailService();
            emailSettingService = new EmailSettingService();

            blackListEmailRecords = blockListEmailService.GetBlackListEmails();
            CreateGridView();

            unReadEmails = new List<ViewEmailDto>();
            totalEmailNumber = 0;
            downloadLable.Text = "";


            bgHelper = new BackgroundHelper();

            string editorUrl = AppDomain.CurrentDomain.BaseDirectory + "Files\\Editor\\Editor.html";
            webBrowser1.Navigate(editorUrl);

            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted; 

            viewEmailWebBrowser.Navigate(editorUrl);

            viewEmailWebBrowser.DocumentCompleted += viewEmailWebBrowser_DocumentCompleted;
            perEmailCountTextBox.Text = perEmailCount.ToString();
            fromDateTimePicker.MinDate = DateTime.Now.AddYears(-10);
            fromDateTimePicker.MaxDate = DateTime.Now;
            toDateTimePicker.MaxDate = DateTime.Now;


            ShowHideReplySection(false);
        }
        #region Feild Methods
        private void perEmailCountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (perEmailCountTextBox.Text == "")
            {
                perEmailCountTextBox.Text = "0";
            }
            perEmailCount = int.Parse(perEmailCountTextBox.Text);
            if (perEmailCount > 500)
            {
                MessageBox.Show("Value should not be greater than 500");
                perEmailCount = 500;
                perEmailCountTextBox.Text = perEmailCount.ToString();
            }
        }

        private void perEmailCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dataGridEmails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _currentInboxEmail = unReadEmails[e.RowIndex];
                viewEmailBody = _currentInboxEmail.Body;
                fromEmailTextBox.Text = _currentInboxEmail.CurrentUserEmail.Address;
                userEmailTextBox.Text = _currentInboxEmail.FromEmailAddress;
                SetViewContent();
                ShowHideReplySection(true);
                using (ImapClient client = new ImapClient(_currentInboxEmail.CurrentUserEmail.IMAPHost,
                    _currentInboxEmail.CurrentUserEmail.IMAPPort, true))
                {
                    // Login
                    client.Login(_currentInboxEmail.CurrentUserEmail.Address, _currentInboxEmail.CurrentUserEmail.Password, AuthMethod.Auto);

                    client.RemoveMessageFlags(_currentInboxEmail.UID, null, MessageFlag.Seen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void refreshEmails_Click(object sender, EventArgs e)
        {
            RefreshEmailsTable();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                Task.Delay(1000).ContinueWith(t => SetContent());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void viewEmailWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                Task.Delay(1000).ContinueWith(t => SetViewContent());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void replyButton_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("Please enter valid email address");
                return;
            }
            _templateContent = GetElementByClassName("note-editable").InnerHtml;
            if (string.IsNullOrEmpty(_templateContent) || _templateContent == "<br>")
            {
                MessageBox.Show("Please enter the email body", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ComposeButton.Enabled = false;
            replyButton.Enabled = false;
            emailTextBox.Enabled = false;
            SendMail();

        }

        #endregion

        #region Private Methods
        private void SetContent()
        {
            bgHelper.Foreground(() =>
            {
                try
                {
                    webBrowser1.Document.InvokeScript("setContent", new String[] { _templateContent });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
        }

        private void SetViewContent()
        {
            bgHelper.Foreground(() =>
            {
                try
                {
                    viewEmailWebBrowser.Document.InvokeScript("setContent", new String[] { viewEmailBody });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
        }
        private HtmlElement GetElementByClassName(string className)
        {
            var elements = webBrowser1.Document.GetElementsByTagName("div");
            foreach (HtmlElement div in elements)
            {
                if (div.GetAttribute("className") == className)
                {
                    return div;
                }
            }

            return null;
        }
        private Response<bool> SendMail()
        {
            try
            {
                Response<bool> sendResult = EmailHelper.Instance.SetCredentials(_currentInboxEmail.CurrentUserEmail.Host,
                _currentInboxEmail.CurrentUserEmail.Port,
                _currentInboxEmail.CurrentUserEmail.Address,
                _currentInboxEmail.CurrentUserEmail.Password,
                _currentInboxEmail.CurrentUserEmail.FromAlias)
                .ReplyTo(_templateContent, _currentInboxEmail.CurrentCompleteEmail);
                ComposeButton.Enabled = true;
                replyButton.Enabled = true;
                emailTextBox.Enabled = true;

                if (sendResult.Success)
                {
                    MessageBox.Show("Email send sucsessfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _templateContent = "";
                    SetContent();
                    ShowHideReplySection(false);
                }
                else
                {
                    MessageBox.Show("Unable to send the email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(ex);
            }

        }

        private void DownloadEmails()
        {


            bgHelper.Background(() =>
            {
                bgHelper.Foreground(() =>
                {

                    this.downloadEmailButton.Enabled = false;
                    this.dataGridEmails.Enabled = false;
                    this.perEmailCountTextBox.Enabled = false;
                    this.fromDateTimePicker.Enabled = false;
                    this.toDateTimePicker.Enabled = false;
                    downloadLable.Text = "Downloading Emails please wait....";
                });
                foreach (var item in emailRecords)
                {
                    try
                    {
                        using (ImapClient client = new ImapClient(item.IMAPHost, item.IMAPPort, true))
                        {
                            // Login
                            client.Login(item.Address, item.Password, AuthMethod.Auto);
                            SearchCondition searchFrom = SearchCondition.SentSince(fromDateTimePicker.Value);
                            SearchCondition searchTo = SearchCondition.SentBefore(toDateTimePicker.Value.AddDays(1));

                            IEnumerable<uint> uids = client.Search(searchFrom.And(searchTo));
                            List<uint> newList = uids.Skip(0).Take(perEmailCount).ToList();
                            int srNo = 1;
                            foreach (var uid in newList)
                            {
                                MailMessage mailMessage = client.GetMessage(uid);
                                if (blackListEmailRecords.Where(x => x.EmailAddress == mailMessage.From.Address).Any())
                                {
                                    client.DeleteMessage(uid);
                                }
                                else
                                {
                                    ViewEmailDto _currentEmail = new ViewEmailDto
                                    {
                                        SrNo = srNo,
                                        CurrentCompleteEmail = mailMessage,
                                        DateOfEmail = mailMessage.Date(),
                                        Subject = mailMessage.Subject,
                                        FromEmailAddress = mailMessage.From.Address.ToString(),
                                        Body = mailMessage.Body,
                                        CurrentUserEmail = item,
                                        UID = uid,
                                    };
                                    srNo++;
                                    unReadEmails.Add(_currentEmail);
                                    bgHelper.Foreground(() =>
                                    {
                                        // add to Grid View  
                                        AddNewRow(_currentEmail);
                                    });
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString(), "Error while downloading emails for " + item.Address,
                        //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                bgHelper.Foreground(() =>
                {
                    dataGridEmails.Enabled = true;
                    downloadEmailButton.Enabled = true;

                    perEmailCountTextBox.Enabled = true;
                    fromDateTimePicker.Enabled = true;
                    toDateTimePicker.Enabled = true;

                    dataGridEmails.ReadOnly = false;
                    downloadLable.Text = "Download Completed";
                    totalLabel.Text = unReadEmails.Count().ToString();
                    datatable.Rows.Clear();

                    unReadEmails = unReadEmails.OrderByDescending(x => x.DateOfEmail).ToList();
                    int srNo = 1;
                    foreach (var email in unReadEmails)
                    {
                        DataRow row = this.datatable.NewRow();
                        row["SrNo"] = srNo;
                        row["Subject"] = email.Subject;
                        row["DateOfEmail"] = email.DateOfEmail;
                        datatable.Rows.Add(row);
                        srNo++;
                    }
                    dataGridEmails.DataSource = datatable;
                });
            });

        }
        private void AddNewRow(ViewEmailDto currentEmail)
        {
            DataRow row = this.datatable.NewRow();
            row["SrNo"] = currentEmail.SrNo;
            row["Subject"] = currentEmail.Subject;
            row["DateOfEmail"] = currentEmail.DateOfEmail;
            datatable.Rows.Add(row);
            if (datatable.Rows.Count > 0)
            {
                dataGridEmails.Columns[0].Width = 30;
                dataGridEmails.Columns[1].Width = 350;
                dataGridEmails.Columns[2].Width = 140;
            }
            totalEmailNumber += 1;
            totalLabel.Text = totalEmailNumber.ToString();
        }
        private void RefreshEmailsTable()
        {
            try
            {
                emailRecords = emailSettingService.GetEmails();
                unReadEmails = new List<ViewEmailDto>();
                totalEmailNumber = 0;
                downloadLable.Text = "";
                CreateGridView();
                DownloadEmails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateGridView()
        {
            datatable = (DataTable)dataGridEmails.DataSource;
            if (datatable == null)
            {
                datatable = new DataTable();
                datatable.Columns.Add(new DataColumn("SrNo"));
                datatable.Columns.Add(new DataColumn("Subject"));
                datatable.Columns.Add(new DataColumn("DateOfEmail"));

            }
            // for refresh button
            if (datatable.Rows.Count > 0)
            {
                datatable.Rows.Clear();
            }
            dataGridEmails.DataSource = datatable;
        }

        private void ShowHideReplySection(bool condition)
        {
            groupBox1.Visible = condition;
            groupBox3.Visible = condition;
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
        private void ComposeButton_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("Please enter valid email address");
                return;
            }
            _templateContent = GetElementByClassName("note-editable").InnerHtml;
            if (string.IsNullOrEmpty(_templateContent) || _templateContent == "<br>")
            {
                MessageBox.Show("Please enter the email body", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ComposeButton.Enabled = false;
            replyButton.Enabled = false;
            emailTextBox.Enabled = false;
            Response<bool> sendResult = EmailHelper.Instance.SetCredentials(_currentInboxEmail.CurrentUserEmail.Host,
                  _currentInboxEmail.CurrentUserEmail.Port,
                  _currentInboxEmail.CurrentUserEmail.Address,
                  _currentInboxEmail.CurrentUserEmail.Password,
                  _currentInboxEmail.CurrentUserEmail.FromAlias)
                .Send(new List<string>() { emailTextBox.Text }, _currentInboxEmail.CurrentCompleteEmail.Subject, _templateContent);
            if (sendResult.Success)
            {
                MessageBox.Show("Email send sucsessfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _templateContent = "";
                emailTextBox.Text = "";
                SetContent();
                ShowHideReplySection(false);
            }
            else
            {
                MessageBox.Show("Unable to send the email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ComposeButton.Enabled = true;
            replyButton.Enabled = true;
            emailTextBox.Enabled = true;

        }

        #endregion

    }//end of class 
}//end of namespace 
