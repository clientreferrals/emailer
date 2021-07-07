using Backgrounder;
using BusniessLayer;
using DataAccessLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class Templates : Form
    {
        private readonly BackgroundHelper bgHelper;
        List<EmailTemplate> TemplateRecords = new List<EmailTemplate>();
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
                    TemplateRecords = emailTemplateService.GetTemplates();

                    bgHelper.Foreground(() =>
                    {
                        dataGridTemplates.DataSource = TemplateRecords;
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
                EditTemplate form = new EditTemplate(TemplateRecords[e.RowIndex]);
                form.ShowDialog();

                RefreshTemplates();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
