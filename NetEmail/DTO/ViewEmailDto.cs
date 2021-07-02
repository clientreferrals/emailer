
using NetEmail.DTO;
using System;
using System.Net.Mail;

namespace DirectEmailResults.DTO
{
    public class ViewEmailDto
    {
       public MailMessage CurrentCompleteEmail { get; set; }
        public EmailDTO CurrentUserEmail { get; set; }
        public uint UID { get; set; }
        public string FromEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? DateOfEmail { get; set; } 
    }
}
