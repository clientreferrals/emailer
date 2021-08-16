
using BusniessLayer;
using BusniessLayer.Utility;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EditCustomer : Form
    {
        readonly CustomerDto CustomerRecord = null;
        private readonly CustomerService customerService;
        private readonly EmailValidationService emailValidationService;
        private readonly List<string> notAllowedList = new List<string>();
        private readonly List<string> alreadyValidEmailList = new List<string>();
        public EditCustomer(CustomerDto customer)
        {
            try
            {
                InitializeComponent();
                customerService = new CustomerService();
                CustomerRecord = customer;

                emailValidationService = new EmailValidationService();
                notAllowedList = emailValidationService.GetNotAllowList();
                alreadyValidEmailList = emailValidationService.GetValidEmails();

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
                string _email = tbxEmail.Text.Trim();
                bool valid = true;

                btnOK.Enabled = false;
                if (notAllowedList.Any(x => _email.ToLower().Contains(x.ToLower())))

                {
                    valid = false;
                }
                else if (alreadyValidEmailList.Any(x => _email.ToLower().Contains(x.ToLower())))
                {
                    valid = true;
                }
                else if (ValidateEmailUsingAPI.EmailValidationUsingAPI(_email).Result == false)
                {
                    valid = false;
                }

                if (valid == false)
                {
                    MessageBox.Show("There some keyword which are not allowed to enter or the email is not valid.");
                    btnOK.Enabled = true;
                    return;
                }
                else
                {
                    bool isSave = customerService.Save(tbxName.Text.Trim(), tbxPhoneNo.Text.Trim(), tbxTags.Text.Trim(), _email,
                        txbWebsite.Text.Trim(), txbState.Text.Trim(), txbCity.Text.Trim(), zipCodeTextBox.Text.Trim());
                    if (isSave)
                    {
                        emailValidationService.SaveNewRecord(_email, valid);
                    }
                }


                Close();
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
