namespace Models.DTO
{
    public class EmailValidationApiResponseModel
    {
        public string result { get; set; }
        public string message { get; set; }
        public string email { get; set; }
        public string user { get; set; }
        public string domain { get; set; }
        public int accept_all { get; set; }
        public int role { get; set; }
        public int free_email { get; set; }
        public int disposable { get; set; }
        public int spamtrap { get; set; }
        public bool success { get; set; }
    }
}
