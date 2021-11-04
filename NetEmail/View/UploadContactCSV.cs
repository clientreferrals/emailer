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

namespace DirectEmailResults.View
{
    public partial class UploadContactCSV : Form
    {
        private readonly BackgroundHelper bgHelper;
        private readonly EmailSettingService emailSettingService;
        private readonly EmailValidationService emailValidationService;
        private readonly List<string> notAllowedList = new List<string>();
        private readonly List<string> alreadyValidEmailList = new List<string>();
        public List<UploadContactDto> failedEmailsList = new List<UploadContactDto>();
        public List<UploadContactDto> successUploadedList = new List<UploadContactDto>();
        public UploadContactCSV()
        {
            try
            {
                InitializeComponent();
            emailSettingService = new EmailSettingService();

            emailValidationService = new EmailValidationService();
            notAllowedList = emailValidationService.GetNotAllowList();
            alreadyValidEmailList = emailValidationService.GetValidEmails();

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
                            btnOK.Enabled = false;
                        });

                        int i = 0;
                        if (dtCustomers.Rows.Count > 0)
                        {
                            failedEmailsList = new List<UploadContactDto>();
                            successUploadedList = new List<UploadContactDto>();
                            foreach (DataRow row in dtCustomers.Rows)
                            {
                                string _emailAddress = row["emailAddress"].ToString().Trim();
                                string _password = row["password"].ToString().Trim();
                                string _fromAlias = row["fromAlias"].ToString().Trim();
                                if (!string.IsNullOrEmpty(_emailAddress)
                                && !string.IsNullOrEmpty(_password)
                                && !string.IsNullOrEmpty(_fromAlias))
                                {
                                    UploadContactDto uploadContactDto = new UploadContactDto
                                    {
                                        EmailAddress = _emailAddress,
                                        Password = _password,
                                        FromAlias = _fromAlias,
                                        Active = true,
                                        DailyLimit = 500,
                                        Host = "", 
                                        Port = 0,
                                        IMAPHost ="",
                                        IMAPPort = 0, 
                                        
                                        
                                    };
                                    bool valid = true;
                                    if (notAllowedList.Any(x => _emailAddress.ToLower().Contains(x.ToLower())))

                                    {
                                        valid = false;
                                    }
                                    else if (alreadyValidEmailList.Any(x => _emailAddress.ToLower().Contains(x.ToLower())))
                                    {
                                        valid = true;
                                    }
                                    else if (ValidateEmailUsingAPI.EmailValidationUsingAPI(_emailAddress).Result == false)
                                    {
                                        valid = false;
                                    }

                                    if (valid == false)
                                    {
                                        failedEmailsList.Add(uploadContactDto);
                                    }
                                    else
                                    {
                                        bool isSave = emailSettingService.Save(
                                          0,
                                          uploadContactDto.Host,
                                          uploadContactDto.Port,
                                          uploadContactDto.EmailAddress,
                                          uploadContactDto.Password,
                                          uploadContactDto.FromAlias,
                                          uploadContactDto.DailyLimit,
                                          uploadContactDto.IMAPPort,
                                          uploadContactDto.IMAPHost

                                             );

                                        if (isSave)
                                        {
                                            emailValidationService.SaveNewRecord(_emailAddress, valid);
                                        }
                                        successUploadedList.Add(uploadContactDto);
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
                            btnOK.Enabled = true;
                            this.Close();
                        });
                    }
                    catch (Exception ex)
                    {
                        bgHelper.Foreground(() =>
                        {
                            btnOK.Enabled = true;
                        });
                        MessageBox.Show(ex.Message);

                    }
                });
            }
            catch (Exception ex)
            {
                bgHelper.Foreground(() =>
                {
                    btnOK.Enabled = true;
                });
                MessageBox.Show(ex.Message);
            }
        }
    }
}
