using Models.DTO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DirectEmailResults.View
{
    public partial class SuccessAndFailedUploadEmails : Form
    { 
        public SuccessAndFailedUploadEmails(List<UploadCsvModel> input)
        {
            InitializeComponent(); 
            failedUploadedEmailDataGridView.DataSource = input;
        }
    }
}
