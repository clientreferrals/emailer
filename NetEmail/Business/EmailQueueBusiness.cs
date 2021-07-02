using NetEmail.DTO;
using NetEmail.Entity;
using NetMail.Business;
using NetMail.Entity;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetEmail.Business
{
    class EmailQueueBusiness : Singleton<EmailQueueBusiness>
    {
        #region Constructor

        public EmailQueueBusiness()
        {
            CampaignBusiness.Instance.GetType();
            TemplateBusiness.Instance.GetType();
            CustomerBusiness.Instance.GetType();

            CheckTables();
        }

        private void CheckTables()
        {
            if (IsTableExists("EmailQueueLog") == false)
            {
                using (var db = new NetEmailContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                    create table EmailQueueLog 
                    (
                        Id INTEGER AUTO INCREMENT PRIMARY KEY, 
                        Campaign VARCHAR NOT NULL,
                        Template VARCHAR NOT NULL,
                        Customer VARCHAR NOT NULL,
                        [From] VARCHAR NOT NULL,
                        [To] VARCHAR NOT NULL,
                        [Date] VARCHAR NOT NULL,
                        Mail TEXT NOT NULL,
                        ErrorLog TEXT NOT NULL
                    )
                    ");
                }
            }
        }

        private bool IsTableExists(String tableName)
        {
            using (var db = new NetEmailContext())
            {
                int a = db.Database.SqlQuery<int>(
                    "select count(*) from sqlite_master where type = 'table' and name = {0}",
                    tableName)
                    .FirstOrDefault();

                if (a > 0) return true;
                else return false;
            }
        }

        #endregion

        #region Public Methods

        public List<EmailQueueItem> GetEmailQueueItems()
        {
            using (NetEmailContext db = new NetEmailContext())
            {
                string sql = @"
                            select 
                                cc.Id as CampaignCustomerId,
                                c.Name as CampaignName,
                                t.Name as TemplateName,
                                t.Content as TemplateContent,
                                cu.Name as CustomerName,
                                cu.Surname as CustomerSurname,
                                cu.Email as CustomerEmail,
                                c.MailSubject as MailSubject
                            from CampaignCustomer cc
                            join Campaign c on cc.CampaignId = c.Id
                            join Template t on c.TemplateId = t.Id
                            join Customer cu on cc.CustomerId = cu.Id
                            where cc.IsSent = 0
                            and c.IsActive = 1
                        ";

                var data = db.Database.SqlQuery<EmailQueueItem>(sql).ToList();

                return data;
            }
        }

        public bool SaveEmailQueueLog(EmailQueueItem item, string from, string mail, string errorLog)
        {
            using (NetEmailContext db = new NetEmailContext())
            {
                int maxId = 0;
                if (db.EmailQueueLogs.Count() > 0)
                {
                    maxId = db.EmailQueueLogs.Max(x => x.Id);
                }

                EmailQueueLog log = new EmailQueueLog()
                {
                    Id = maxId + 1,
                    Campaign = item.CampaignName,
                    Template = item.TemplateName,
                    Customer = item.CustomerName + " " + item.CustomerSurname,
                    From = from,
                    To = item.CustomerEmail,
                    Mail = mail,
                    Date = DateTime.Now.ToLongDateString(),
                    ErrorLog = errorLog
                };

                db.EmailQueueLogs.Add(log);
                db.SaveChanges();
            }

            return true;
        }

        public List<EmailQueueLog> GetEmailQueueLogs()
        {
            using (NetEmailContext db = new NetEmailContext())
            {
                return db.EmailQueueLogs.OrderByDescending(l => l.Id).ToList();
            }
        }

        public bool DeleteAllLogs()
        {
            using (NetEmailContext db = new NetEmailContext())
            {
                string sql = @"delete from EmailQueueLog";

                var data = db.Database.ExecuteSqlCommand(sql);

                return true;
            }
        }

        #endregion
    }
}
