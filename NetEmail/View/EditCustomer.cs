using NetEmail.Entity;
using NetMail.Business;
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
    public partial class EditCustomer : Form
    {
        Customer CustomerRecord = null;

        public EditCustomer(Customer customer)
        {
            try
            {
                InitializeComponent();

                CustomerRecord = customer;

                tbxEmail.Text = CustomerRecord.Email;
                tbxName.Text = CustomerRecord.Name;
                tbxSurname.Text = CustomerRecord.Surname;
                tbxTags.Text = CustomerRecord.Tags;
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
                CustomerBusiness.Instance.Save(CustomerRecord.Id, tbxName.Text, tbxSurname.Text, tbxTags.Text, tbxEmail.Text);

                this.Close();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??", "Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    CustomerBusiness.Instance.Delete(CustomerRecord.Id);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
