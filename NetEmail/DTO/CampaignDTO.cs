namespace NetEmail.DTO
{
    public class CampaignDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string MailSubject { get; set; }
        public int PendingCount { get; set; }
        public int SentCount { get; set; }
        public int TotalCount { get { return PendingCount + SentCount; } }
    }
}
