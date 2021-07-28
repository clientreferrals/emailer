
using BusniessLayer;
using DataAccessLayer.DataBase;
using Models.DTO;
using System;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EditCustomer : Form
    {
        readonly CustomerDto CustomerRecord = null;
        private readonly CustomerService customerService;
        public EditCustomer(CustomerDto customer)
        {
            try
            {
                InitializeComponent();
                customerService = new CustomerService();
                CustomerRecord = customer;

                tbxEmail.Text = CustomerRecord.Email;
                tbxName.Text = CustomerRecord.Name;
                tbxPhoneNo.Text = CustomerRecord.PhoneNo;
                tbxTags.Text = CustomerRecord.Tags;
                txbWebsite.Text = CustomerRecord.Website;
                txbState.Text = CustomerRecord.State;
                txbCity.Text = CustomerRecord.City;
                zipCodeTextBox.Text = CustomerRecord.ZipCode;
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
                customerService.Save(tbxName.Text.Trim(),tbxPhoneNo.Text.Trim(), tbxTags.Text.Trim(), tbxEmail.Text.Trim(),
                    txbWebsite.Text.Trim(), txbState.Text.Trim(), txbCity.Text.Trim(), zipCodeTextBox.Text.Trim());

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
                    customerService.Delete(CustomerRecord.Id);
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
