using Backgrounder;
using NetEmail.Business;
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
    public partial class Templates : Form
    {
        BackgroundHelper bgHelper;
        List<Template> TemplateRecords = new List<Template>();

        public Templates()
        {
            try
            {
                InitializeComponent();

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
                    TemplateRecords = TemplateBusiness.Instance.GetTemplates();

                    bgHelper.Foreground(() =>
                    {
                        dataGridTemplates.DataSource = TemplateRecords;
                        dataGridTemplates.Columns["Content"].Visible = false;
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
                EditTemplate form = new EditTemplate(new Template());
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
