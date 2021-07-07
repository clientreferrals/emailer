using Backgrounder;
using BusniessLayer;
using DataAccessLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EmailQueueLogViews : Form
    {
        private readonly BackgroundHelper bgHelper;
        private readonly EmailQueueLogService emailQueueLogService;

        private List<EmailQueueLog> logRecords = new List<EmailQueueLog>();
        public EmailQueueLogViews()
        {
            try
            {
                InitializeComponent();
                emailQueueLogService = new EmailQueueLogService();
                bgHelper = new BackgroundHelper();

                RefreshLogs();

                Timer refreshTimer = new Timer();
                refreshTimer.Interval = 5000; //5 seconds
                refreshTimer.Tick += new EventHandler(refreshTimerTick);
                refreshTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void refreshTimerTick(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void RefreshLogs()
        {
            Console.WriteLine("Refresh called");
            bgHelper.Background(() =>
            {
                try
                {
                    logRecords = emailQueueLogService.GetEmailQueueLogs();

                    bgHelper.Foreground(() =>
                    {
                        dataGridLogs.DataSource = logRecords;
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLogs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete all log items?", "Delete", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                bgHelper.Background(() =>
                {
                    try
                    {
                        emailQueueLogService.DeleteAllLogs();
                        RefreshLogs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });
            }
        }
    }
}
