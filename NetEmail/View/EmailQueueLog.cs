﻿using Backgrounder;
using NetEmail.Business;
using NetEmail.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EmailQueueLog : Form
    {
        BackgroundHelper bgHelper;
        List<Entity.EmailQueueLog> LogRecords = new List<Entity.EmailQueueLog>();

        public EmailQueueLog()
        {
            try
            {
                InitializeComponent();

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
                    LogRecords = EmailQueueBusiness.Instance.GetEmailQueueLogs();

                    bgHelper.Foreground(() =>
                    {
                        dataGridLogs.DataSource = LogRecords;
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
                        EmailQueueBusiness.Instance.DeleteAllLogs();
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
