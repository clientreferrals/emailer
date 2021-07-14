using Backgrounder;
using BusniessLayer;
using DataAccessLayer.DataBase;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class CampaignsEdit : Form
    {
        BackgroundHelper bgHelper;
        List<EmailTemplate> templates = new List<EmailTemplate>();
        CampaignDTO currentCampaign = new CampaignDTO();
        List<CampaignCustomerDTO> currentCustomers = new List<CampaignCustomerDTO>();
        private readonly EmailTemplateService emailTemplateService;
        private readonly CampaignService campaignService;

        public CampaignsEdit(CampaignDTO campaign)
        {
            try
            {
                currentCampaign = campaign;

                InitializeComponent();
                emailTemplateService = new EmailTemplateService();
                campaignService = new CampaignService();

                bgHelper = new BackgroundHelper();

                lblStatus.Text = "Passive";
                btnStartCampaign.Text = "Start Campaign";
                lblProcessing.Visible = false;

                bgHelper.Background(() =>
                {
                    try
                    {
                        templates = emailTemplateService.GetTemplates();

                        List<ViewTemplateDto> viewTemplateDtos = templates.Select(x => new ViewTemplateDto()
                        {
                            Id = x.Id,
                            TemplateName = x.TemplateName
                        }).ToList();

                        bgHelper.Foreground(() =>
                        {
                            lbxTemplates.SelectedItem = templates.FirstOrDefault();
                            lbxTemplates.DataSource = viewTemplateDtos;
                        });
                        RefreshCampaign();


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

        private void RefreshCampaign()
        {
            try
            {
                if (currentCampaign.Id > 0)
                {
                    bgHelper.Background(() =>
                    {
                        try
                        {
                            currentCampaign = campaignService.GetCampaign(currentCampaign.Id);
                            currentCustomers = campaignService.GetCampaignCustomers(currentCampaign.Id);

                            bgHelper.Foreground(() =>
                            {
                                lblStatus.Text = currentCampaign.IsActive ? "Active" : "Passive";
                                tbxName.Text = currentCampaign.Name;
                                tbxMailSubject.Text = currentCampaign.MailSubject;
                                if (currentCampaign.TemplateId > 0)
                                {
                                    lbxTemplates.SelectedItem = templates.Where(t => t.Id == currentCampaign.TemplateId).FirstOrDefault(); 
                                }
                                lblTotal.Text = currentCampaign.TotalCount.ToString();
                                lblWaiting.Text = currentCampaign.PendingCount.ToString();
                                lblSent.Text = currentCampaign.SentCount.ToString();

                                if (currentCampaign.IsActive == true)
                                {
                                    btnStartCampaign.Text = "Stop Campaign";
                                }
                                else
                                {
                                    btnStartCampaign.Text = "Start Campaign";
                                }
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    });
                }
                else
                {
                    bgHelper.Foreground(() =>
                    {
                        if (tbxName.Text == "") tbxName.Text = "";
                        if (tbxMailSubject.Text == "") tbxMailSubject.Text = "";
                    });
                }

                RefreshCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void RefreshCustomers()
        {
            if (currentCampaign.Id > 0)
            {
                bgHelper.Background(() =>
                {
                    try
                    {
                        currentCustomers = campaignService.GetCampaignCustomers(currentCampaign.Id);

                        bgHelper.Foreground(() =>
                        {
                            gridCustomers.DataSource = currentCustomers;
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnStartCampaign_Click(object sender, EventArgs e)
        {
            if (currentCampaign.Id == 0)
            {
                MessageBox.Show("Unable to find the Campaign, please add users");
                return;
            }
            try
            {
                bgHelper.Background(() =>
                {
                    if (currentCampaign.IsActive == true)
                    {
                        campaignService.StopCampaign(currentCampaign.Id);
                        RefreshCampaign();
                    }
                    else
                    {
                        campaignService.StartCampaign(currentCampaign.Id);
                        bgHelper.Foreground(() =>
                        {
                            this.Close();
                        });
                    }

                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxName.Text) == true)
            {
                MessageBox.Show("Please enter a valid name for this campaign.");
                return;
            }

            if (string.IsNullOrEmpty(tbxMailSubject.Text) == true)
            {
                MessageBox.Show("Please enter a valid mail subject for this campaign.");
                return;
            }

            if (lbxTemplates.SelectedItem == null)
            {
                MessageBox.Show("Please select a template for this campaign.");
                return;
            }
            if(currentCampaign.TemplateId == 0)
            {
                ViewTemplateDto selectedViewTemplate = (ViewTemplateDto)lbxTemplates.SelectedItem;  
                currentCampaign.TemplateId = templates.Where(x => x.Id == selectedViewTemplate.Id).Select(x => x.Id).FirstOrDefault();
            }

            try
            {
                Customers form = new Customers(CustomersWindowType.SELECT);
                form.ShowDialog();

                lblProcessing.Visible = true;

                bgHelper.Background(() =>
                {
                    try
                    {
                        if (form.IsCustomersSelected == true && form.customerRecords != null && form.customerRecords.Count > 0)
                        {
                            CampaignDTO campaign = campaignService.SaveCampaign(currentCampaign.Id, tbxName.Text, currentCampaign.TemplateId, tbxMailSubject.Text, form.customerRecords.Select(c => c.Id).ToList());

                            currentCampaign = campaign;
                        }

                        bgHelper.Foreground(() =>
                        {
                            lblProcessing.Visible = false;
                        });

                        RefreshCampaign();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });

                RefreshCampaign();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCampaign();
        }

        private void btnDeleteAllCustomers_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete all customers?", "Delete", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                lblProcessing.Visible = true;

                bgHelper.Background(() =>
                {
                    try
                    {
                        campaignService.DeleteAllCampaignCustomers(currentCampaign.Id);

                        RefreshCampaign();

                        bgHelper.Foreground(() =>
                        {
                            lblProcessing.Visible = false;
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                });
            }
        }

        private void btnDeleteCampaign_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this campaign?", "Delete", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                lblProcessing.Visible = true;

                bgHelper.Background(() =>
                {
                    try
                    {
                        campaignService.DeleteCampaign(currentCampaign.Id);

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
        }

       
    }
}
