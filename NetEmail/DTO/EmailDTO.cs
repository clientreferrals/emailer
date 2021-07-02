namespace NetEmail.DTO
{
    public class EmailDTO
    {
        public int Id { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public string FromAddress { get; set; }

        public string FromAlias { get; set; }

        public int DailyLimit { get; set; }

        public int RemainingLimit { get; set; }


        public string PopHost { get; set; }

        public int PopPort { get; set; }

    }
}
