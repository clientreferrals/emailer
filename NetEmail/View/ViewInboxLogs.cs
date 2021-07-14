using Models.DTO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DirectEmailResults.View
{
    public partial class ViewInboxLogs : Form
    {
        List<InboxLogsModel> logs = new List<InboxLogsModel>();
        public ViewInboxLogs(List<InboxLogsModel> logs)
        {
            InitializeComponent();
            this.logs = logs;
            logsGridView.DataSource = logs;
        }
    }
}
