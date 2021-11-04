namespace Models.DTO
{
    public class UploadContactDto
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FromAlias { get; set; }
        public int DailyLimit { get; set; }
        public int IMAPPort { get; set; }
        public string IMAPHost { get; set; }
       
        public int SentCount { get; set; }
        public bool? Active { get; set; }
    }
}
