using Backgrounder;
using BusniessLayer;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class Campaigns : Form
    {
        private readonly BackgroundHelper bgHelper;
        List<CampaignDTO> campaignRecords = new List<CampaignDTO>();
        private readonly CampaignService campaignService;
        public Campaigns()
        {
            try
            {
                InitializeComponent();
                campaignService = new CampaignService();
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
                    campaignRecords = campaignService.GetCampaigns();

                    bgHelper.Foreground(() =>
                    {
                        try
                        {
                            dataGridCampaigns.DataSource = campaignRecords;
                            dataGridCampaigns.Columns["TemplateId"].Visible = false;
                            dataGridCampaigns.Columns["Name"].Visible = false;
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
                    Name = ""
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
                CampaignsEdit form = new CampaignsEdit(campaignRecords[e.RowIndex]);
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


        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow[] selectedRows = dataGridCampaigns.SelectedRows
            .OfType<DataGridViewRow>()
            .Where(row => !row.IsNewRow)
            .ToArray();
                var confirmResult = MessageBox.Show("Are you sure to remove " + selectedRows.Length.ToString() + " from black list?", "Delete",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    foreach (var row in selectedRows)
                    {
                        campaignService.DeleteCampaign(int.Parse(row.Cells[0].Value.ToString()));
                    }

                    RefreshCampaigns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
