using Backgrounder;
using BusniessLayer;
using NetMail.Utility;
using System;
using System.Data;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class UploadCustomerCSV : Form
    {
        private readonly BackgroundHelper bgHelper;
        private readonly CustomerService customerService;
        public UploadCustomerCSV()
        {
            try
            {
                InitializeComponent(); 
                customerService = new CustomerService();

                bgHelper = new BackgroundHelper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "|*.csv";
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    tbxPath.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxTag.Text) == true)
            {
                MessageBox.Show("Please enter a tag for these customers.");
                return;
            }

            try
            {
                bgHelper.Background(() =>
                {
                    try
                    {
                        DataTable dtCustomers = FileHelper.Instance.GetDataTableFromCSVFile(tbxPath.Text, ";");

                        bgHelper.Foreground(() =>
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = dtCustomers.Rows.Count;
                            progressBar1.Value = 0;
                        });

                        int i = 0;
                        if (dtCustomers.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtCustomers.Rows)
                            {
                                customerService.Save(
                                    id: 0,
                                    name: row["Name"].ToString(),
                                    phoneNo: row["phoneNo"].ToString(),
                                    email: row["Email"].ToString(),
                                    tags: tbxTag.Text,
                                    website: row["Website"].ToString(),
                                    state: row["State"].ToString(),
                                    city: row["City"].ToString()
                                );
                                i++;

                                bgHelper.Foreground(() =>
                                {
                                    progressBar1.Value = i;
                                });
                            };
                        }

                        bgHelper.Foreground(() =>
                        {
                            this.Close();
                        });
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
    }
}
