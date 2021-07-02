﻿using Backgrounder;
using NetEmail.Entity;
using NetMail.Business;
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
    public enum CustomersWindowType
    {
        LIST,
        SELECT
    }

    public partial class Customers : Form
    {
        BackgroundHelper bgHelper;
        public List<Customer> CustomerRecords = new List<Customer>();
        CustomersWindowType CurrentWindowType = CustomersWindowType.LIST;
        public bool IsCustomersSelected = false;

        public Customers(CustomersWindowType type = CustomersWindowType.LIST)
        {
            try
            {
                InitializeComponent();

                CurrentWindowType = type;

                bgHelper = new BackgroundHelper();

                RefreshCustomersTable();
                UpdateWindowType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateWindowType()
        {
            try
            {
                if (CurrentWindowType == CustomersWindowType.LIST)
                {
                    btnSelectCustomers.Visible = false;
                }
                else
                {
                    btnDeleteAll.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void RefreshCustomersTable()
        {
            bgHelper.Background(() =>
            {
                try
                {
                    CustomerRecords = CustomerBusiness.Instance.GetCustomers(tbxName.Text, tbxSurname.Text, tbxTag.Text);

                    bgHelper.Foreground(() =>
                    {
                        dataGridCustomers.DataSource = CustomerRecords;
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                EditCustomer f2 = new EditCustomer(new Customer());
                f2.ShowDialog();

                RefreshCustomersTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EditCustomer f2 = new EditCustomer(CustomerRecords[e.RowIndex]);
                f2.ShowDialog();

                RefreshCustomersTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            RefreshCustomersTable();
        }

        private void btnDownloadSampleCSV_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = @"explorer";

                string path = System.AppDomain.CurrentDomain.BaseDirectory + "Files";
                process.StartInfo.Arguments = path;

                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddCsv_Click(object sender, EventArgs e)
        {
            try
            {
                UploadCustomerCSV form = new UploadCustomerCSV();
                form.ShowDialog();

                RefreshCustomersTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure to delete all customer records?", "Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    CustomerBusiness.Instance.DeleteAll();

                    RefreshCustomersTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectCustomers_Click(object sender, EventArgs e)
        {
            IsCustomersSelected = true;
            Close();
        }
    }
}
