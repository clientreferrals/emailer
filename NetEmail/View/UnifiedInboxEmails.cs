using Backgrounder;
using DirectEmailResults.Business;
using DirectEmailResults.DTO;
using NetEmail.DTO;
using NetMail.Business;
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

        private List<BlackListEmailDto> blackListEmailRecords = new List<BlackListEmailDto>();


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
            blackListEmailRecords = BlackListEmailBusiness.Instance.GetBlackListEmails();
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
                emailRecords = EmailSettingsBusiness.Instance.GetEmails();
                unReadEmails = new List<ViewEmailDto>();
                totalEmailNumber = 0;
                downloadLable.Text = "Downloading Emails please wait....";
                CreateGridView();
                _ = DownloadEmails();
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
                using (ImapClient client = new ImapClient(_currentInboxEmail.CurrentUserEmail.PopHost,
                    Convert.ToInt32(_currentInboxEmail.CurrentUserEmail.PopPort), true))
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

        private async Task DownloadEmails()
        {
            this.refreshButtonEmails.Enabled = false;
            this.dataGridEmails.Enabled = false;
            foreach (var item in emailRecords)
            {
                try
                {
                    using (ImapClient client = new ImapClient(item.PopHost, Convert.ToInt32(item.PopPort), true))
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
                                // add to Grid View  
                                AddNewRow(_currentEmail);
                                await Task.Delay(5);
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
            this.dataGridEmails.Enabled = true;
            refreshButtonEmails.Enabled = true;
            this.dataGridEmails.ReadOnly = false;
            downloadLable.Text = "Download Completed";

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

        private void deleteButton_Click(object sender, EventArgs e)
        {

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
            _templateContent = GetElementByClassName("note-editable").InnerHtml;
            if (string.IsNullOrEmpty(_templateContent))
            {
                MessageBox.Show("Please enter the email body", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                replyButton.Enabled = false;
                SendMail();
            }
        }
        private Response<bool> SendMail()
        {
            try
            {
                Response<bool> sendResult = EmailHelper.Instance.SetCredentials(_currentInboxEmail.CurrentUserEmail.Host,
                _currentInboxEmail.CurrentUserEmail.Port,
                _currentInboxEmail.CurrentUserEmail.Address,
                _currentInboxEmail.CurrentUserEmail.Password,
                _currentInboxEmail.CurrentUserEmail.FromAddress,
                _currentInboxEmail.CurrentUserEmail.FromAlias)
                .ReplyTo(_templateContent, _currentInboxEmail.CurrentCompleteEmail);
                replyButton.Enabled = true;
                _templateContent = "";
                SetContent();
                ShowHideReplySection(false);
                if (sendResult.Success)
                {
                    MessageBox.Show("Email send sucsessfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }//end of class 
}//end of namespace 
