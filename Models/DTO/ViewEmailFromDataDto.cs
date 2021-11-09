using System;

namespace Models.DTO
{

    public class ViewEmailFromDataDto
    {
        public int SrNo { get; set; } 
        public EmailDTO CurrentUserEmail { get; set; }
        public uint UID { get; set; }
        public string FromEmailAddress { get; set; }
        public string OurEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? DateOfEmail { get; set; }
    }
}
