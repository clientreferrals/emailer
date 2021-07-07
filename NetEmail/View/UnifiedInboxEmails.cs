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

        private List<ViewEmailDto> unReadEmails = new List<ViewEmailDto>();
        private DataTable datatable;

        private ViewEmailDto _currentInboxEmail;
        private string _templateContent = "";
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
            downloadLable.Text = "Downloading Emails please wait....";


            bgHelper = new BackgroundHelper();

            string editorUrl = AppDomain.CurrentDomain.BaseDirectory + "Files\\Editor\\Editor.html";
            webBrowser1.Navigate(editorUrl);

            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;

            ShowHideReplySection(false);
        }
        private void RefreshEmailsTable()
        {
            try
            {
                emailRecords = emailSettingService.GetEmails();
                unReadEmails = new List<ViewEmailDto>();
                totalEmailNumber = 0;
                downloadLable.Text = "Downloading Emails please wait....";
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

        private void dataGridCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _currentInboxEmail = unReadEmails[e.RowIndex];
                viewUserEmailRichTextBox.Text = _currentInboxEmail.Body;
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

        private void DownloadEmails()
        {
            this.refreshButtonEmails.Enabled = false;
            this.dataGridEmails.Enabled = false;
            downloadLable.Text = "Downloading Emails please wait....";
            foreach (var item in emailRecords)
            {
                bgHelper.Background(() =>
                {
                    try
                    {
                        using (ImapClient client = new ImapClient(item.IMAPHost, item.IMAPPort, true))
                        {
                            // Login
                            client.Login(item.Address, item.Password, AuthMethod.Auto);

                            IEnumerable<uint> uids = client.Search(SearchCondition.Unseen());

                            foreach (var uid in uids)
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
                                        CurrentCompleteEmail = mailMessage,
                                        DateOfEmail = mailMessage.Date(),
                                        Subject = mailMessage.Subject,
                                        FromEmailAddress = mailMessage.From.Address.ToString(),
                                        Body = mailMessage.Body,
                                        CurrentUserEmail = item,
                                        UID = uid
                                    };
                                    unReadEmails.Add(_currentEmail);
                                    bgHelper.Foreground(() =>
                                    {
                                        // add to Grid View  
                                        AddNewRow(_currentEmail);
                                    });
                                }
                            }
                        }
                        bgHelper.Foreground(() =>
                        {
                            this.dataGridEmails.Enabled = true;
                            refreshButtonEmails.Enabled = true;
                            this.dataGridEmails.ReadOnly = false;
                            downloadLable.Text = "Download Completed";
                            totalLabel.Text = unReadEmails.Count().ToString();
                            datatable.Rows.Clear();

                            unReadEmails = unReadEmails.OrderByDescending(x => x.DateOfEmail).ToList();
                            foreach (var email in unReadEmails)
                            {
                                DataRow row = this.datatable.NewRow();
                                row["Subject"] = email.Subject;
                                row["DateOfEmail"] = email.DateOfEmail;
                                datatable.Rows.Add(row);
                            }
                            dataGridEmails.DataSource = datatable;
                        });
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString(), "Error while downloading emails for " + item.Address,
                        //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }
        private void AddNewRow(ViewEmailDto currentEmail)
        {
            DataRow row = this.datatable.NewRow();
            row["Subject"] = currentEmail.Subject;
            row["DateOfEmail"] = currentEmail.DateOfEmail;
            datatable.Rows.Add(row);
            if (datatable.Rows.Count > 0)
            {
                dataGridEmails.Columns[0].Width = 350;
                dataGridEmails.Columns[1].Width = 140;
            }
            totalEmailNumber += 1;
            totalLabel.Text = totalEmailNumber.ToString();
        }

        private void UnifiedInboxEmails_Load(object sender, EventArgs e)
        {
            this.Activated += AfterLoading;
        }
        private void AfterLoading(object sender, EventArgs e)
        {
            this.Activated -= AfterLoading;
            RefreshEmailsTable();
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

        private void ShowHideReplySection(bool condition)
        {
            groupBox1.Visible = condition;
            groupBox3.Visible = condition;
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
    }//end of class 
}//end of namespace 
