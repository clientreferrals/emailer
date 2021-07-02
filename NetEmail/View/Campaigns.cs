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
    public partial class Campaigns : Form
    {
        BackgroundHelper bgHelper;
        List<CampaignDTO> CampaignRecords = new List<CampaignDTO>();

        public Campaigns()
        {
            try
            {
                InitializeComponent();

                bgHelper = new BackgroundHelper();

                RefreshCampaigns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RefreshCampaigns()
        {
            bgHelper.Background(() =>
            {
                try
                {
                    CampaignRecords = CampaignBusiness.Instance.GetCampaigns();

                    bgHelper.Foreground(() =>
                    {
                        try
                        {
                            dataGridCampaigns.DataSource = CampaignRecords;
                            dataGridCampaigns.Columns["TemplateId"].Visible = false;
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

            });

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                CampaignsEdit form = new CampaignsEdit(new CampaignDTO()
                {
                    Name = "New Campaign"
                });
                form.ShowDialog();

                RefreshCampaigns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridTemplates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CampaignsEdit form = new CampaignsEdit(CampaignRecords[e.RowIndex]);
                form.ShowDialog();

                RefreshCampaigns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            RefreshCampaigns();
        }

        private void dataGridCampaigns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
