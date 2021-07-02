namespace NetEmail.DTO
{
    public class CampaignCustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tags { get; set; }
        public string Email { get; set; }
        public bool IsSent { get; set; }
    }
}
