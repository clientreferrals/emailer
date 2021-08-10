using Backgrounder;
using BusniessLayer;
using BusniessLayer.Utility;
using Models.DTO;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class UploadCustomerCSV : Form
    {
        private readonly BackgroundHelper bgHelper;
        private readonly CustomerService customerService;
        private readonly EmailValidationService emailValidationService;
        private readonly List<string> notAllowedList = new List<string>();
        public List<UploadCsvModel> failedEmailsList = new List<UploadCsvModel>();
        public List<UploadCsvModel> successUploadedList = new List<UploadCsvModel>();

        public UploadCustomerCSV()
        {
            try
            {
                InitializeComponent();
                customerService = new CustomerService();

                emailValidationService = new EmailValidationService();
                notAllowedList = emailValidationService.GetNotAllowList();

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
                        DataTable dtCustomers = FileHelper.Instance.GetDataTableFromCSVFile(tbxPath.Text, ",");


                        bgHelper.Foreground(() =>
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = dtCustomers.Rows.Count;
                            progressBar1.Value = 0;
                        });

                        int i = 0;
                        if (dtCustomers.Rows.Count > 0)
                        {
                            failedEmailsList = new List<UploadCsvModel>();
                            successUploadedList = new List<UploadCsvModel>(); 
                            foreach (DataRow row in dtCustomers.Rows)
                            {
                                string _email = row["email"].ToString().Trim();
                                if (!string.IsNullOrEmpty(_email))
                                {
                                    UploadCsvModel uploadCsvModel = new UploadCsvModel
                                    {
                                        Name = row["name"].ToString(),
                                        Phone = row["phone"].ToString(),
                                        Email = _email,
                                        Tag = tbxTag.Text,
                                        URL = row["url"].ToString(),
                                        State = row["state"].ToString(),
                                        City = row["city"].ToString(),
                                        ZipCode = row["zipCode"].ToString()
                                    };
                                    if (notAllowedList.Any(x => _email.ToLower().Contains(x.ToLower()))
                                         || ValidateEmailUsingAPI.EmailValidationUsingAPI(_email).Result == false)
                                    {
                                        failedEmailsList.Add(uploadCsvModel);
                                    }
                                    else
                                    {
                                        customerService.Save(
                                         uploadCsvModel.Name,
                                         uploadCsvModel.Phone,
                                         _email,
                                         uploadCsvModel.Tag,
                                         uploadCsvModel.URL,
                                         uploadCsvModel.State,
                                         uploadCsvModel.City,
                                         uploadCsvModel.ZipCode
                                      );
                                        successUploadedList.Add(uploadCsvModel);
                                    }

                                }

                                i++;

                                bgHelper.Foreground(() =>
                                {
                                    progressBar1.Value = i;
                                });
                            }
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
