using System;
using System.Windows.Forms;

namespace NetEmail.View
{
    public partial class EditEmailAccountTestEmailAddress : Form
    {
        public string ReturnValue = "";

        public EditEmailAccountTestEmailAddress()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ReturnValue = tbxEmailAddress.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
