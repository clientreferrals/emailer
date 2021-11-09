using Backgrounder;
using BusniessLayer;
using BusniessLayer.Utility;
using Models.DTO;
using NetMail.Utility;
using S22.Imap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectEmailResults.View
{
    public partial class Inbox : Form
    {
        private readonly BlockListEmailService blockListEmailService;
        private readonly EmailSettingService emailSettingService;

        private List<BlockListEmailDto> blackListEmailRecords = new List<BlockListEmailDto>();
        private List<EmailDTO> ourEmailRecords;
        private int totalEmailNumber = 0;
        private int perEmailCount = 25;

        private List<ViewEmailFromDataDto> unReadEmails = new List<ViewEmailFromDataDto>();
        private DataTable datatable;

        private ViewEmailDto _currentInboxEmail;
        private string _templateContent = "";
        private string viewEmailBody = "";
        private readonly BackgroundHelper bgHelper;
        private List<InboxLogsModel> emailLogs = new List<InboxLogsModel>();
        private readonly List<string> bccEmailsList = new List<string>();
        private readonly List<string> ccEmailsList = new List<string>();
        private readonly InboxEmailService inboxEmailService;
        private readonly ApplicationSettingServices applicationSettingServices;
        public Inbox()
        {

            InitializeComponent();
            blockListEmailService = new BlockListEmailService();
            emailSettingService = new EmailSettingService();
            applicationSettingServices = new ApplicationSettingServices();

            string bccEmail = applicationSettingServices.GetValue(ConstantKey.BccEmails);
            string[] bccEmailAddress = bccEmail.Split(',');
            for (int i = 0; i < bccEmailAddress.Length; i++)
            {
                if (!bccEmailsList.Any(x => x == bccEmailAddress[i]))
                {
                    bccEmailsList.Add(bccEmailAddress[i]);
                }
            }

            string ccEmail = applicationSettingServices.GetValue(ConstantKey.CcEmails);
            string[] ccEmailAddress = ccEmail.Split(',');
            for (int i = 0; i < ccEmailAddress.Length; i++)
            {
                if (!ccEmailsList.Any(x => x == ccEmailAddress[i]))
                {
                    ccEmailsList.Add(ccEmailAddress[i]);
                }
            }

            blackListEmailRecords = blockListEmailService.GetBlackListEmails();
            CreateGridView();

            unReadEmails = new List<ViewEmailFromDataDto>();
            totalEmailNumber = 0;
            downloadLablel.Text = "";


            bgHelper = new BackgroundHelper();

            string editorUrl = AppDomain.CurrentDomain.BaseDirectory + "Files\\Editor\\Editor.html";
            webBrowser1.Navigate(editorUrl);

            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;

            viewEmailWebBrowser.Navigate(editorUrl);

            viewEmailWebBrowser.DocumentCompleted += viewEmailWebBrowser_DocumentCompleted;

            fromDateTimePicker.MinDate = DateTime.Now.AddYears(-10);
            fromDateTimePicker.MaxDate = DateTime.Now;
            toDateTimePicker.MaxDate = DateTime.Now;

            inboxEmailService = new InboxEmailService();
            ShowHideReplySection(false);
            RefreshEmailsTable();

        }
        #region Feild Methods


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
            ReadAndViewEmail(e.RowIndex);
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

            _templateContent = GetElementByClassName("note-editable").InnerHtml;
            if (string.IsNullOrEmpty(_templateContent) || _templateContent == "<br>")
            {
                MessageBox.Show("Please enter the email body", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            replyButton.Enabled = false;
            SendMail();

        }


        private void rowNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                .ReplyTo(_templateContent, _currentInboxEmail.CurrentCompleteEmail, bccEmailsList, ccEmailsList);

                replyButton.Enabled = true;

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


        private void ReadFromDatabaseEmails()
        {

            emailLogs = new List<InboxLogsModel>();
            bgHelper.Background(() =>
            {
                bgHelper.Foreground(() =>
                {

                    downloadEmailButton.Enabled = false;
                    dataGridEmails.Enabled = false;
                    fromDateTimePicker.Enabled = false;
                    toDateTimePicker.Enabled = false;
                    downloadLablel.Text = "Loading....";
                });
                int srNo = 1;
                foreach (var item in ourEmailRecords)
                {
                    try
                    {
                        DateTime toDateTime = DateTime.Now;
                        DateTime fromDateTime = toDateTime.AddDays(-5);
                        
                        var getEmailFromDataBase = inboxEmailService.GetEmailOfRange(item.Address, fromDateTime, toDateTime);
                        foreach (var emailItem in getEmailFromDataBase)
                        {
                            ViewEmailFromDataDto _currentEmail = new ViewEmailFromDataDto
                            {
                                SrNo = srNo,
                                DateOfEmail = emailItem.DateOfEmail,
                                Subject = emailItem.Subject,
                                FromEmailAddress = emailItem.FromEmailAddress,
                                OurEmailAddress = emailItem.OurEmailAddress, 
                                Body = emailItem.Body,
                                CurrentUserEmail = item,
                                UID = emailItem.UID,
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
                    catch (Exception ex)
                    {
                        var emailLog = new InboxLogsModel()
                        {
                            EmailAddress = item.Address,
                            Password = item.Password,
                            ErrorMessage = ex.ToString()
                        };
                        emailLogs.Add(emailLog);
                        bgHelper.Foreground(() =>
                        {
                            errorRichTextBox.Text = "Error while downloading emails for " + item.Address + " " + ex.ToString();
                        });
                    }
                }// end of for each loop for Our email list to download 
                bgHelper.Foreground(() =>
                {
                    dataGridEmails.Enabled = true;
                    downloadEmailButton.Enabled = true;
                    fromDateTimePicker.Enabled = true;
                    toDateTimePicker.Enabled = true;

                    dataGridEmails.ReadOnly = false;
                    downloadLablel.Text = "Completed";
                    datatable.Rows.Clear();

                    unReadEmails = unReadEmails.OrderByDescending(x => x.DateOfEmail).ToList();
                    srNo = 1;
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

        //private void DownloadEmails()
        //{

        //    emailLogs = new List<InboxLogsModel>();
        //    bgHelper.Background(() =>
        //    {
        //        bgHelper.Foreground(() =>
        //        {

        //            downloadEmailButton.Enabled = false;
        //            dataGridEmails.Enabled = false;
        //            perEmailCountTextBox.Enabled = false;
        //            fromDateTimePicker.Enabled = false;
        //            toDateTimePicker.Enabled = false;
        //            downloadLablel.Text = "Downloading....";
        //        });
        //        int srNo = 1;
        //        foreach (var item in ourEmailRecords)
        //        {
        //            try
        //            {
        //                using (ImapClient client = new ImapClient(item.IMAPHost, item.IMAPPort, true))
        //                {
        //                    // Login
        //                    client.Login(item.Address, item.Password, AuthMethod.Auto);
        //                    SearchCondition searchFrom = SearchCondition.SentSince(fromDateTimePicker.Value);
        //                    SearchCondition searchTo = SearchCondition.SentBefore(toDateTimePicker.Value.AddDays(1));

        //                    IEnumerable<uint> uids = client.Search(searchFrom.And(searchTo));
        //                    List<uint> newList = uids.Skip(0).Take(perEmailCount).ToList();

        //                    foreach (var uid in newList)
        //                    {
        //                        MailMessage mailMessage = client.GetMessage(uid);
        //                        if (blackListEmailRecords.Where(x => x.EmailAddress == mailMessage.From.Address).Any())
        //                        {
        //                            client.DeleteMessage(uid);
        //                        }
        //                        else
        //                        {
        //                            ViewEmailDto _currentEmail = new ViewEmailDto
        //                            {
        //                                SrNo = srNo,
        //                                CurrentCompleteEmail = mailMessage,
        //                                DateOfEmail = mailMessage.Date(),
        //                                Subject = mailMessage.Subject,
        //                                FromEmailAddress = mailMessage.From.Address.ToString(),
        //                                Body = mailMessage.Body,
        //                                CurrentUserEmail = item,
        //                                UID = uid,
        //                            };
        //                            srNo++;
        //                            unReadEmails.Add(_currentEmail);
        //                            bgHelper.Foreground(() =>
        //                            {
        //                                // add to Grid View  
        //                                AddNewRow(_currentEmail);
        //                            });
        //                            Thread.Sleep(2000);
        //                        }
        //                    }
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                var emailLog = new InboxLogsModel()
        //                {
        //                    EmailAddress = item.Address,
        //                    Password = item.Password,
        //                    ErrorMessage = ex.ToString()
        //                };
        //                emailLogs.Add(emailLog);
        //                bgHelper.Foreground(() =>
        //                {
        //                    failedCount.Text = emailLogs.Count().ToString();
        //                    errorRichTextBox.Text = "Error while downloading emails for " + item.Address + " " + ex.ToString();
        //                });
        //            }
        //        }// end of for each loop for Our email list to download 
        //        bgHelper.Foreground(() =>
        //        {
        //            dataGridEmails.Enabled = true;
        //            downloadEmailButton.Enabled = true;

        //            perEmailCountTextBox.Enabled = true;
        //            fromDateTimePicker.Enabled = true;
        //            toDateTimePicker.Enabled = true;

        //            dataGridEmails.ReadOnly = false;
        //            downloadLablel.Text = "Completed";
        //            totalLabel.Text = unReadEmails.Count().ToString();
        //            datatable.Rows.Clear();

        //            unReadEmails = unReadEmails.OrderByDescending(x => x.DateOfEmail).ToList();
        //            srNo = 1;
        //            foreach (var email in unReadEmails)
        //            {
        //                DataRow row = this.datatable.NewRow();
        //                row["SrNo"] = srNo;
        //                row["Subject"] = email.Subject;
        //                row["DateOfEmail"] = email.DateOfEmail;
        //                datatable.Rows.Add(row);
        //                srNo++;
        //            }
        //            dataGridEmails.DataSource = datatable;

        //        });
        //    });

        //}

        private void AddNewRow(ViewEmailFromDataDto currentEmail)
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
        }
        private void RefreshEmailsTable()
        {
            try
            {
                ourEmailRecords = emailSettingService.GetActiveEmails();
                unReadEmails = new List<ViewEmailFromDataDto>();
                totalEmailNumber = 0;
                downloadLablel.Text = "";
                CreateGridView();
                ReadFromDatabaseEmails();
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

        #endregion

        private void viewLogsButton_Click(object sender, EventArgs e)
        {
            if (emailLogs.Count == 0)
            {
                MessageBox.Show("No logs found");
                return;
            }
            ViewInboxLogs form = new ViewInboxLogs(emailLogs);
            form.Show();
        }


        private void ReadAndViewEmail(int index)
        {
            try
            {
                ShowHideReplySection(false);
                // Need to do this 
                //_currentInboxEmail = unReadEmails[index];
                viewEmailBody = _currentInboxEmail.Body;
                fromEmailTextBox.Text = unReadEmails[index].OurEmailAddress;
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


    }//end of class 
}//end of namespace 
