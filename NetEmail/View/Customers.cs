using Backgrounder;
using BusniessLayer;
using DataAccessLayer.DataBase;
using System;
using System.Collections.Generic;
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
        private readonly BackgroundHelper bgHelper;
        public List<Customer> customerRecords = new List<Customer>();
        CustomersWindowType currentWindowType = CustomersWindowType.LIST;
        public bool IsCustomersSelected = false;
        private readonly CustomerService customerService;
        public Customers(CustomersWindowType type = CustomersWindowType.LIST)
        {
            try
            {
                InitializeComponent();
                customerService = new CustomerService();
                currentWindowType = type;

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
                if (currentWindowType == CustomersWindowType.LIST)
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
                    customerRecords = customerService.GetCustomers(tbxName.Text, tbxPhoneNo.Text, tbxTag.Text, txtWebsite.Text, txbCity.Text);

                    bgHelper.Foreground(() =>
                    {
                        dataGridCustomers.DataSource = customerRecords;
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
                EditCustomer f2 = new EditCustomer(customerRecords[e.RowIndex]);
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
                    customerService.DeleteAll();

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
