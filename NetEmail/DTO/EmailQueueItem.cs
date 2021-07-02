namespace NetEmail.DTO
{
    public class EmailQueueItem
    {
        public int CampaignCustomerId { get; set; }
        public string CampaignName { get; set; }
        public string TemplateName { get; set; }
        public string TemplateContent { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string MailSubject { get; set; }

    }
}
