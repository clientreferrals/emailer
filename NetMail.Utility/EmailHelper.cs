using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace NetMail.Utility
{
    public class EmailHelper : Singleton<EmailHelper>
    {
        private string host;
        private int port;
        private string mailAddress;
        private string password;
        private string fromAlias;

        public EmailHelper SetCredentials(string _host, int _port, string _mailAddress, string _password, string _fromAlias)
        {
            host = _host;
            port = _port;
            mailAddress = _mailAddress;
            password = _password;
            fromAlias = _fromAlias;

            return this;
        }

        public Response<bool> Send(List<string> recepients, string subject, string message)
        {
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(mailAddress, password)
                };

                MailAddress from = new MailAddress(mailAddress, fromAlias);
                string body = message + "<footer> <p> Call Referrals<br>1500 Chestnut St, Suite #1626, Philadelphia, PA 19102</p></footer>";
                MailMessage mail = new MailMessage
                {
                    From = from,
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                recepients.ForEach(r => mail.To.Add(r));

                client.Send(mail);

                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(ex);
            }
        }

        public Response<bool> ReplyTo(string message, MailMessage source, List<string> bccEmails)
        {
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(mailAddress, password)
                };

                MailMessage replyMessage = new MailMessage(new MailAddress(mailAddress, "Sender"), source.From);

                // Get message id and add 'In-Reply-To' header
                string id = source.Headers["Message-ID"];
                replyMessage.Headers.Add("In-Reply-To", id);

                // Try to get 'References' header from the source and add it to the reply
                string references = source.Headers["References"];

                if (!string.IsNullOrEmpty(references))
                    references += ' ';

                replyMessage.Headers.Add("References", references + id);

                // Add subject
                if (!source.Subject.StartsWith("Re:", StringComparison.OrdinalIgnoreCase))
                    replyMessage.Subject = "Re: ";

                replyMessage.Subject += source.Subject;

                foreach (var item in bccEmails)
                {
                    replyMessage.Bcc.Add(item);
                } 
                replyMessage.Body = message.ToString();
                replyMessage.IsBodyHtml = true;


                client.Send(replyMessage);

                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(ex);
            }
        }
    }
}
