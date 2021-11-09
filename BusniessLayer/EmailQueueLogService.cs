using DataAccessLayer.DataBase;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusniessLayer
{
    public class EmailQueueLogService
    {
        #region Public Methods

        public List<EmailQueueItem> GetEmailQueueItems()
        {
            using (var db = new DirectEmailerEntities())
            {
                string sql = @"
                            select 
                                cc.Id as CampaignCustomerId,
                                c.Name as CampaignName,
                                t.TemplateName as TemplateName,
                                t.TemplateContent as TemplateContent,
                                cu.Name as CustomerName,
                                cu.PhoneNo as CustomerPhoneNo,
                                cu.Email as CustomerEmail,
                                c.MailSubject as MailSubject
                            from CampaignCustomer cc
                            join Campaign c on cc.CampaignId = c.Id
                            join EmailTemplate t on c.TemplateId = t.Id
                            join Customer cu on cc.CustomerId = cu.Id
                            where cc.IsSent = 0
                            and c.IsActive = 1
                        ";

                var data = db.Database.SqlQuery<EmailQueueItem>(sql).ToList();

                return data;
            }
        }

        public List<EmailForLogs> GetUniqueEmail()
        {
            using (var db = new DirectEmailerEntities())
            {
                return db.EmailQueueLogs.Where(x => !string.IsNullOrEmpty(x.ErrorLog)).Select(x => x.FromAddress).Distinct().Select(x => new EmailForLogs()
                {
                    Email = x
                }).ToList();
            }
        }

        public bool SaveEmailQueueLog(EmailQueueItem item, string fromEmailAddress, string mail, string errorLog, bool isEmailSent)
        {
            using (var db = new DirectEmailerEntities())
            {
                EmailQueueLog log = new EmailQueueLog()
                {
                    Campaign = item.CampaignName,
                    Template = item.TemplateName,
                    CustomerName = item.CustomerName,
                    FromAddress = fromEmailAddress,
                    ToAddress = item.CustomerEmail,
                    MailContent = mail,
                    ErrorLog = errorLog,
                    CreatedDateTime = DateTime.Now,
                };

                db.EmailQueueLogs.Add(log);
                db.SaveChanges();

                if (isEmailSent)
                {
                    var email = db.OurEmailLists.Where(x => x.EmailAddress == fromEmailAddress).FirstOrDefault();
                    if (email != null)
                    {
                        email.SentCount += 1;
                        db.SaveChanges();
                    }
                }
            }

            return true;
        }

        public List<EmailLogs> GetLogsByEmail(string email)
        {
            using (var db = new DirectEmailerEntities())
            {
                return db.EmailQueueLogs.Where(x => x.FromAddress == email && !string.IsNullOrEmpty(x.ErrorLog))
                    .Distinct().Select(x => new EmailLogs()
                    {
                        DateTime = x.CreatedDateTime,
                        Error = x.ErrorLog
                    }).ToList();
            }
        }

        public List<EmailQueueLog> GetEmailQueueLogs()
        {
            using (var db = new DirectEmailerEntities())
            {
                return db.EmailQueueLogs.OrderByDescending(l => l.Id).ToList();
            }
        }

        public bool DeleteAllLogs()
        {
            using (var db = new DirectEmailerEntities())
            {
                string sql = @"delete from EmailQueueLog";

                var data = db.Database.ExecuteSqlCommand(sql);

                return true;
            }
        }

        #endregion
    }
}
