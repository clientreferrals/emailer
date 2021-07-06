using Backgrounder;
using NetEmail.Business;
using NetEmail.DTO;
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
    public partial class CampaignsEdit : Form
    {
        BackgroundHelper bgHelper;
        List<Template> Templates = new List<Template>();
        CampaignDTO CurrentCampaign = new CampaignDTO();
        List<CampaignCustomerDTO> CurrentCustomers = new List<CampaignCustomerDTO>();

        public CampaignsEdit(CampaignDTO campaign)
        {
            try
            {
                CurrentCampaign = campaign;

                InitializeComponent();

                bgHelper = new BackgroundHelper();

                lblStatus.Text = "Passive";
                btnStartCampaign.Text = "Start Campaign";
                lblProcessing.Visible = false;

                bgHelper.Background(() =>
                {
                    try
                    {
                        Templates = TemplateBusiness.Instance.GetTemplates();
                        RefreshCampaign();

                        bgHelper.Foreground(() =>
                    {
                        lbxTemplates.DataSource = Templates;
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

        private void RefreshCampaign()
        {
            try
            {
                if (CurrentCampaign.Id > 0)
                {
                    bgHelper.Background(() =>
                    {
                        try
                        {
                            CurrentCampaign = CampaignBusiness.Instance.GetCampaign(CurrentCampaign.Id);
                            CurrentCustomers = CampaignBusiness.Instance.GetCampaignCustomers(CurrentCampaign.Id);

                            bgHelper.Foreground(() =>
                            {
                                lblStatus.Text = CurrentCampaign.IsActive ? "Active" : "Passive";
                                tbxName.Text = CurrentCampaign.Name;
                                tbxMailSubject.Text = CurrentCampaign.MailSubject;
                                lbxTemplates.SelectedItem = Templates.Where(t => t.Id == CurrentCampaign.TemplateId).FirstOrDefault();
                                lblTotal.Text = CurrentCampaign.TotalCount.ToString();
                                lblWaiting.Text = CurrentCampaign.PendingCount.ToString();
                                lblSent.Text = CurrentCampaign.SentCount.ToString();

                                if (CurrentCampaign.IsActive == true)
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
            if (CurrentCampaign.Id > 0)
            {
                bgHelper.Background(() =>
                {
                    try
                    {
                        CurrentCustomers = CampaignBusiness.Instance.GetCampaignCustomers(CurrentCampaign.Id);

                        bgHelper.Foreground(() =>
                        {
                            gridCustomers.DataSource = CurrentCustomers;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
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

                Template selectedTemplate = (Template)lbxTemplates.SelectedItem;

                try
                {
                    CampaignBusiness.Instance.SaveCampaign(CurrentCampaign.Id, tbxName.Text, selectedTemplate.Id, tbxMailSubject.Text, CurrentCustomers.Select(s => s.Id).ToList());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnStartCampaign_Click(object sender, EventArgs e)
        {
            try
            {
                bgHelper.Background(() =>
                {
                    if (CurrentCampaign.IsActive == true)
                    {
                        CampaignBusiness.Instance.StopCampaign(CurrentCampaign.Id);
                    }
                    else
                    {
                        CampaignBusiness.Instance.StartCampaign(CurrentCampaign.Id);
                    }

                    RefreshCampaign();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Customers form = new Customers(CustomersWindowType.SELECT);
                form.ShowDialog();

                lblProcessing.Visible = true;

                bgHelper.Background(() =>
                {
                    try
                    {
                        if (form.IsCustomersSelected == true && form.CustomerRecords != null && form.CustomerRecords.Count > 0)
                        {
                            CampaignDTO campaign = CampaignBusiness.Instance.SaveCampaign(CurrentCampaign.Id, CurrentCampaign.Name, CurrentCampaign.TemplateId, tbxMailSubject.Text, form.CustomerRecords.Select(c => c.Id).ToList());

                            CurrentCampaign = campaign;
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
                        CampaignBusiness.Instance.DeleteAllCampaignCustomers(CurrentCampaign.Id);

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
                        CampaignBusiness.Instance.DeleteCampaign(CurrentCampaign.Id);

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
