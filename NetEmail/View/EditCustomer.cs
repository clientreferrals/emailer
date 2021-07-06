using NetEmail.Entity;
using NetMail.Business;
using System;
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
                tbxPhoneNo.Text = CustomerRecord.PhoneNo;
                tbxTags.Text = CustomerRecord.Tags;
                txbWebsite.Text = CustomerRecord.Website;
                txbState.Text = CustomerRecord.State;
                txbCity.Text = CustomerRecord.City;
                tbxName.Focus();
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
                CustomerBusiness.Instance.Save(CustomerRecord.Id, tbxName.Text.Trim(),
                    tbxPhoneNo.Text.Trim(), tbxTags.Text.Trim(), tbxEmail.Text.Trim(), txbWebsite.Text.Trim(), txbState.Text.Trim(), txbCity.Text.Trim());

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
