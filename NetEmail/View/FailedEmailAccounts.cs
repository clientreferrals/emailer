using Backgrounder;
using BusniessLayer;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DirectEmailResults.View
{
    public partial class FailedEmailAccounts : Form

    {
        BackgroundHelper bgHelper;
        List<EmailForLogs> emails = new List<EmailForLogs>();
        List<EmailLogs> logsOfEmail = new List<EmailLogs>();
        private readonly EmailQueueLogService emailQueueLogService;
        public FailedEmailAccounts()
        {
            InitializeComponent();
            emailQueueLogService = new EmailQueueLogService();
            bgHelper = new BackgroundHelper();
            RefreshEmails();
        }
        private void RefreshEmails()
        {
            Console.WriteLine("Refresh called");
            bgHelper.Background(() =>
            {
                try
                {
                    emails = emailQueueLogService.GetUniqueEmail(); 
                    bgHelper.Foreground(() =>
                    {
                        emailsDataGridView.DataSource = emails;
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

        }

        private void emailsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var email = emails[e.RowIndex];
            bgHelper.Background(() =>
            {
                try
                {
                    logsOfEmail = emailQueueLogService.GetLogsByEmail(email.Email);
                    bgHelper.Foreground(() =>
                    {
                        logsDataGridView.DataSource = logsOfEmail;
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

        }
    }
}
