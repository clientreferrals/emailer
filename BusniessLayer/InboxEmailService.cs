
using DataAccessLayer.DataBase;
using Models.DTO;
using S22.Imap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web.Script.Serialization;

namespace BusniessLayer
{
    public partial class InboxEmailService
    {
        private readonly BlockListEmailService blockListEmailService;
        private readonly List<BlockListEmailDto> blackListEmailRecords = new List<BlockListEmailDto>();

        public InboxEmailService()
        {
            blockListEmailService = new BlockListEmailService();
            blackListEmailRecords = blockListEmailService.GetBlackListEmails();
        }

        public void DownloadEmails(List<EmailDTO> ourEmailRecords)
        {
            foreach (var item in ourEmailRecords)
            {
                try
                {
                    using (ImapClient client = new ImapClient(item.IMAPHost, item.IMAPPort, true))
                    {
                        // Login
                        client.Login(item.Address, item.Password, AuthMethod.Auto);
                        SearchCondition searchFrom = SearchCondition.SentSince(DateTime.Now);
                        SearchCondition searchTo = SearchCondition.SentBefore(DateTime.Now.AddDays(1));

                        IEnumerable<uint> uids = client.Search(searchFrom.And(searchTo));
                        foreach (var uid in uids)
                        {
                            MailMessage mailMessage = client.GetMessage(uid);
                            if (blackListEmailRecords.Where(x => x.EmailAddress == mailMessage.From.Address).Any())
                            {
                                client.DeleteMessage(uid);
                            }
                            else
                            {
                                ViewEmailDto _currentEmail = new ViewEmailDto
                                {
                                    CurrentCompleteEmail = mailMessage,
                                    DateOfEmail = mailMessage.Date(),
                                    Subject = mailMessage.Subject,
                                    FromEmailAddress = mailMessage.From.Address.ToString(),
                                    OurEmailAddress = item.Address,
                                    Body = mailMessage.Body,
                                    CurrentUserEmail = item,
                                    UID = uid,
                                };
                                SaveUpdateEmail(_currentEmail);
                                Thread.Sleep(2000);
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    var emailLog = new InboxLogsModel()
                    {
                        EmailAddress = item.Address,
                        Password = item.Password,
                        ErrorMessage = ex.ToString()
                    };
                }
            }// end of for each loop for Our email list to download
        }
        private bool SaveUpdateEmail(ViewEmailDto input)
        {
            using (var db = new DirectEmailerEntities())
            {
                InboxEmail record = db.InboxEmails.Where(x => x.OurEmailAddress == input.OurEmailAddress

                && x.Uid == input.UID).FirstOrDefault();

                var encodedCurrentUserEmail = new JavaScriptSerializer().Serialize(input.CurrentUserEmail);
                MailInDatabase mailInDatabase = new MailInDatabase()
                {
                    DateTimeOfEmail = input.CurrentCompleteEmail.Date(),
                    Subject = input.CurrentCompleteEmail.Subject
                };
                var encodedCurrentCompleteEmail = new JavaScriptSerializer().Serialize(mailInDatabase);

                if (record == null)
                {
                    record = new InboxEmail()
                    {
                        FromEmailAddress = input.FromEmailAddress,
                        Body = input.Body,
                        CurrentUserEmail = encodedCurrentUserEmail,
                        CurrentEmail = encodedCurrentCompleteEmail,
                        DateEmail = input.DateOfEmail,
                        OurEmailAddress = input.OurEmailAddress,
                        Subject = input.Subject,
                        Uid = (int)input.UID,
                        CreatedDateTime = DateTime.Now,
                    };
                    db.InboxEmails.Add(record);
                }
                else
                {
                    record.FromEmailAddress = input.FromEmailAddress;
                    record.OurEmailAddress = input.OurEmailAddress;
                    record.Body = input.Body;
                    record.CurrentUserEmail = encodedCurrentUserEmail;
                    record.CurrentEmail = encodedCurrentCompleteEmail;
                    record.DateEmail = input.DateOfEmail;
                    record.Subject = input.Subject;
                    record.Uid = (int)input.UID;
                    record.EditedDateTime = DateTime.Now;
                }

                db.SaveChanges();
                return true;
            }
        }
        public List<ViewEmailDto> GetEmailOfRange(string address, DateTime fromDateTime, DateTime toDateTime)
        {
            try
            {
                using (var db = new DirectEmailerEntities())
                {
                    List<InboxEmail> records = db.InboxEmails
                        .Where(x => x.OurEmailAddress == address
                        && x.DateEmail >= fromDateTime
                        && x.DateEmail <= toDateTime).ToList();
                    List<ViewEmailDto> returnList = new List<ViewEmailDto>();
                    foreach (var item in records)
                    {
                        var decodedCurrentUserEmail = new JavaScriptSerializer().DeserializeObject(item.CurrentUserEmail) as EmailDTO;
                        var decodedCurrentCompleteEmail = new JavaScriptSerializer().DeserializeObject(item.CurrentEmail) as MailMessage;

                        ViewEmailDto obj = new ViewEmailDto()
                        {


                            FromEmailAddress = item.FromEmailAddress,
                            Body = item.Body,
                            CurrentUserEmail = decodedCurrentUserEmail,
                            CurrentCompleteEmail = decodedCurrentCompleteEmail,
                            DateOfEmail = item.DateEmail,
                            Subject = item.Subject,
                            UID = (uint)item.Uid,
                        };
                        returnList.Add(obj);
                    }


                    return returnList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<ViewEmailDto>();
            }

        }


    }

}
