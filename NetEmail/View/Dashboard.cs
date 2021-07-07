using Backgrounder;
using BusniessLayer;
using DirectEmailResults.View;
using Models.DTO;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class Dashboard : Form
    {
        BackgroundHelper bgHelper;
        List<EmailQueueItem> QueueItems = new List<EmailQueueItem>();
        bool IsQueueActive = false;
        List<EmailDTO> Emails = new List<EmailDTO>();
        Random myRandom = new Random();
        private readonly EmailSettingService emailSettingService;
        private readonly EmailQueueLogService emailQueueLogService;
        private readonly ApplicationSettingServices applicationSettingServices;
        private readonly CampaignService campaignService;
        private readonly OurEmailListMaxPerDayService ourEmailListMaxPerDayService;
        public Dashboard()
        {
            try
            {

                InitializeComponent();
                emailSettingService = new EmailSettingService();
                emailQueueLogService = new EmailQueueLogService();
                applicationSettingServices = new ApplicationSettingServices();
                ourEmailListMaxPerDayService = new OurEmailListMaxPerDayService();
                ourEmailListMaxPerDayService.ResetCount();

                campaignService = new CampaignService();
                bgHelper = new BackgroundHelper();
                stopProcessingToolStripMenuItem.Enabled = false;

                RefreshQueue();
                GetEmails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetEmails()
        {
            bgHelper.Background(() =>
            {
                try
                {
                    Emails = emailSettingService.GetEmails();
                }
                catch (Exception ex)
                {
                    string inner = ex.InnerException == null ? "Inner exception is null" : ex.InnerException.ToString();
                    MessageBox.Show(ex.Message + " Inner Exception." + inner);
                }

            });
        }

        private void RefreshQueue()
        {
            bgHelper.Background(() =>
            {
                try
                {
                    QueueItems = emailQueueLogService.GetEmailQueueItems();

                    bgHelper.Foreground(() =>
                    {
                        lblTotal.Text = QueueItems.Count.ToString();
                        lblRemaining.Text = QueueItems.Count.ToString();
                        lblProcessed.Text = "0";
                        prgQueue.Value = 0;
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Settings f2 = new Settings();
                f2.ShowDialog();

                RefreshQueue();
                GetEmails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                Customers f2 = new Customers();
                f2.ShowDialog();

                RefreshQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnTemplates_Click(object sender, EventArgs e)
        {
            try
            {
                Templates form = new Templates();
                form.ShowDialog();

                RefreshQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCampaigns_Click(object sender, EventArgs e)
        {
            try
            {
                Campaigns form = new Campaigns();
                form.ShowDialog();

                RefreshQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void startProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                startProcessingToolStripMenuItem.Enabled = false;
                stopProcessingToolStripMenuItem.Enabled = true;
                QueueItems = emailQueueLogService.GetEmailQueueItems();
                lblTotal.Text = QueueItems.Count.ToString();
                lblRemaining.Text = QueueItems.Count.ToString();
                lblProcessed.Text = "0";
                prgQueue.Minimum = 0;
                prgQueue.Maximum = QueueItems.Count;
                prgQueue.Value = 0;
                IsQueueActive = true;
                int waitFromTimeBetweenMails = Convert.ToInt32(applicationSettingServices.GetValue("WaitFromTime"));
                int waitToTimeBetweenMails = Convert.ToInt32(applicationSettingServices.GetValue("WaitToTime"));
                int maxSendsPerDay = Convert.ToInt32(applicationSettingServices.GetValue("MaxSendsPerDay"));

                bgHelper.Background(() =>
                {
                    try
                    {


                        List<EmailDTO> availableEmails = Emails.Where(x => x.RemainingLimit > 0).ToList();
                        int index = 0;
                        foreach (EmailQueueItem item in QueueItems)
                        {
                            if (index == availableEmails.Count)
                            {
                                index = 0;
                            }
                            if (IsQueueActive == false) break;

                            if (Emails.Count == 0)
                            {
                                emailQueueLogService.SaveEmailQueueLog(item, "", "", "No emails defined in settings. Please define emails in settings.", false);
                                return;
                            }
                            if (availableEmails.Count < 1)
                            {
                                emailQueueLogService.SaveEmailQueueLog(item, "", "", "Sent limit reached for all email addresses. Please increase email limits in settings and restart the program.", false);
                                return;
                            }
                            bool isEmailSend = false;
                            while (isEmailSend == false)
                            {
                                int alreadySentCount = ourEmailListMaxPerDayService.GetSentCount(availableEmails[index].Id);
                                if (maxSendsPerDay > alreadySentCount)
                                {
                                    isEmailSend = SendMail(item, availableEmails[index]).Success;
                                    if (isEmailSend)
                                    {
                                        ourEmailListMaxPerDayService.AddUpdate(availableEmails[index].Id);
                                        bgHelper.Foreground(() =>
                                        {
                                            lblRemaining.Text = (Convert.ToInt32(lblRemaining.Text) - 1).ToString();
                                            lblProcessed.Text = (Convert.ToInt32(lblProcessed.Text) + 1).ToString();
                                            prgQueue.Value += 1;
                                        });
                                    }
                                }
                                if (index == availableEmails.Count - 1)
                                {
                                    isEmailSend = true;
                                    index = 0;
                                }
                                else
                                {
                                    index++;
                                }
                            }


                            int threadSleepTime = myRandom.Next(waitFromTimeBetweenMails, waitToTimeBetweenMails);
                            Thread.Sleep(TimeSpan.FromSeconds(threadSleepTime));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private Response<bool> SendMail(EmailQueueItem item, EmailDTO emailAccount)
        {
            try
            {

                if (item.CustomerEmail.Contains("@fake.com") == false)
                {
                    string title = item.MailSubject.Replace("@Name@", item.CustomerName);
                    string message = item.TemplateContent.Replace("@Name@", item.CustomerName);

                    Response<bool> sendResult = EmailHelper.Instance.SetCredentials(emailAccount.Host,
                    emailAccount.Port,
                    emailAccount.Address,
                    emailAccount.Password,
                    emailAccount.FromAlias)
                    .Send(new List<string>() { item.CustomerEmail }, title, message);

                    if (sendResult.Success == false)
                    {
                        emailQueueLogService.SaveEmailQueueLog(item, emailAccount.Address, "", sendResult.Message, false);

                    }
                }

                campaignService.SetAsSent(item.CampaignCustomerId);
                emailQueueLogService.SaveEmailQueueLog(item, emailAccount.Address, item.TemplateContent, "", true);
                emailAccount.RemainingLimit -= 1;

                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(ex);
            }

        }

        private void stopProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsQueueActive = false;
            startProcessingToolStripMenuItem.Enabled = true;
            stopProcessingToolStripMenuItem.Enabled = false;
        }

        private void refreshQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshQueue();
        }

        private void showQueueLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EmailQueueLogViews form = new EmailQueueLogViews();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void showRemainingLimitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("Remaining email sending quota limits for this session are as follows:");
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                foreach (var email in Emails)
                {
                    sb.AppendFormat(" >>> {0}: {1}{2}", email.Address, email.RemainingLimit, Environment.NewLine);
                }

                MessageBox.Show(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void unifiedInboxButton_Click(object sender, EventArgs e)
        {

            try
            {
                UnifiedInboxEmails form = new UnifiedInboxEmails();
                form.ShowDialog();
                RefreshQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //end of function 

        private void blackEmailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                BalckListEmails form = new BalckListEmails();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FailedEmailAccounts form = new FailedEmailAccounts();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }//end of name 

}//end of namespace 
