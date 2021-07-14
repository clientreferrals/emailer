using Backgrounder;
using BusniessLayer;
using DataAccessLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class Templates : Form
    {
        private readonly BackgroundHelper bgHelper;
        List<EmailTemplate> templateRecords = new List<EmailTemplate>();
        private readonly EmailTemplateService emailTemplateService;
        public Templates()
        {
            try
            {
                InitializeComponent();
                emailTemplateService = new EmailTemplateService();
                bgHelper = new BackgroundHelper();

                RefreshTemplates();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RefreshTemplates()
        {
            bgHelper.Background(() =>
            {
                try
                {
                    templateRecords = emailTemplateService.GetTemplates();

                    bgHelper.Foreground(() =>
                    {
                        dataGridTemplates.DataSource = templateRecords;
                        dataGridTemplates.Columns["TemplateContent"].Visible = false;
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
                EditTemplate form = new EditTemplate(new EmailTemplate());
                form.ShowDialog();

                RefreshTemplates();
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
                EditTemplate form = new EditTemplate(templateRecords[e.RowIndex]);
                form.ShowDialog();

                RefreshTemplates();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow[] selectedRows = dataGridTemplates.SelectedRows
            .OfType<DataGridViewRow>()
            .Where(row => !row.IsNewRow)
            .ToArray();
                var confirmResult = MessageBox.Show("Are you sure to remove " + selectedRows.Length.ToString() + " from black list?", "Delete",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                { 
                    foreach (var row in selectedRows)
                    {
                        emailTemplateService.Delete(int.Parse(row.Cells[0].Value.ToString()));
                    }

                    RefreshTemplates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
