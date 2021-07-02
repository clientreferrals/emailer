using NetEmail.DTO;
using NetEmail.Entity;
using NetMail.Entity;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetEmail.Business
{
    class CampaignBusiness : Singleton<CampaignBusiness>
    {
        #region Constructor

        public CampaignBusiness()
        {
            CheckTables();
        }

        private void CheckTables()
        {
            if (IsTableExists("Campaign") == false)
            {
                using (var db = new NetEmailContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                    create table Campaign 
                    (
                        Id INTEGER AUTO INCREMENT PRIMARY KEY, 
                        Name VARCHAR NOT NULL,
                        IsActive INTEGER NOT NULL,
                        TemplateId INTEGER NOT NULL,
                        MailSubject TEXT NOT NULL
                    )
                    ");
                }
            }

            if (IsTableExists("CampaignCustomer") == false)
            {
                using (var db = new NetEmailContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                    create table CampaignCustomer 
                    (
                        Id INTEGER AUTO INCREMENT PRIMARY KEY, 
                        CampaignId INTEGER NOT NULL,
                        CustomerId INTEGER NOT NULL,
                        IsSent INTEGER NOT NULL
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

        public List<CampaignDTO> GetCampaigns()
        {
            using (var db = new NetEmailContext())
            {
                List<CampaignDTO> result = (from c in db.Campaigns
                                            join t in db.Templates on c.TemplateId equals t.Id into ts
                                            from t in ts.DefaultIfEmpty()
                                            select new CampaignDTO()
                                            {
                                                Id = c.Id,
                                                Name = c.Name,
                                                IsActive = c.IsActive == 1 ? true : false,
                                                TemplateId = c.TemplateId,
                                                TemplateName = t.Name,
                                                MailSubject = c.MailSubject,
                                                PendingCount = (from cc in db.CampaignCustomers where cc.CampaignId == c.Id && cc.IsSent == 0 select cc.Id).Count(),
                                                SentCount = (from cc in db.CampaignCustomers where cc.CampaignId == c.Id && cc.IsSent == 1 select cc.Id).Count()
                                            }
                                            ).ToList();

                return result;
            }
        }

        public CampaignDTO GetCampaign(int campaignId)
        {
            using (var db = new NetEmailContext())
            {
                CampaignDTO result = (from c in db.Campaigns
                                      join t in db.Templates on c.TemplateId equals t.Id into ts
                                      from t in ts.DefaultIfEmpty()
                                      where c.Id == campaignId
                                      select new CampaignDTO()
                                      {
                                          Id = c.Id,
                                          Name = c.Name,
                                          IsActive = c.IsActive == 1 ? true : false,
                                          TemplateId = c.TemplateId,
                                          TemplateName = t.Name,
                                          MailSubject = c.MailSubject,
                                          PendingCount = (from cc in db.CampaignCustomers where cc.CampaignId == c.Id && cc.IsSent == 0 select cc.Id).Count(),
                                          SentCount = (from cc in db.CampaignCustomers where cc.CampaignId == c.Id && cc.IsSent == 1 select cc.Id).Count()
                                      }
                                    ).FirstOrDefault();

                return result;
            }
        }

        public List<CampaignCustomerDTO> GetCampaignCustomers(int campaignId)
        {
            using (var db = new NetEmailContext())
            {
                List<CampaignCustomerDTO> result = (from cc in db.CampaignCustomers
                                                    join c in db.Customers on cc.CustomerId equals c.Id
                                                    where cc.CampaignId == campaignId
                                                    select new CampaignCustomerDTO()
                                                    {
                                                        Id = cc.Id,
                                                        Name = c.Name,
                                                        Surname = c.Surname,
                                                        Tags = c.Tags,
                                                        Email = c.Email,
                                                        IsSent = cc.IsSent == 1 ? true : false
                                                    }
                                                    ).ToList();

                return result;
            }
        }

        public CampaignDTO SaveCampaign(int id, string name, int templateId, string mailSubject, List<int> customerIds)
        {
            if (id == 0)
            {
                using (var db = new NetEmailContext())
                {
                    int maxId = 0;
                    if (db.Campaigns.Count() > 0)
                    {
                        maxId = db.Campaigns.Max(x => x.Id);
                    }

                    Campaign record = new Campaign()
                    {
                        Id = maxId + 1,
                        Name = name,
                        IsActive = 0,
                        TemplateId = templateId,
                        MailSubject = mailSubject
                    };

                    db.Campaigns.Add(record);
                    db.SaveChanges();

                    int nextCustomerId = 0;
                    if(db.CampaignCustomers.Count() > 0)
                    {
                        nextCustomerId = db.CampaignCustomers.Max(x => x.Id);
                    }

                    foreach(int customerId in customerIds)
                    {
                        nextCustomerId += 1;
                        CampaignCustomer newRecord = new CampaignCustomer()
                        {
                            Id = nextCustomerId,
                            CampaignId = record.Id,
                            CustomerId = customerId,
                            IsSent = 0
                        };

                        db.CampaignCustomers.Add(newRecord);
                    }

                    db.SaveChanges();

                    return GetCampaign(record.Id);
                }
            }
            else
            {
                using (var db = new NetEmailContext())
                {
                    var campaignRecord = db.Campaigns.Where(x => x.Id == id).FirstOrDefault();

                    campaignRecord.Name = name;
                    campaignRecord.TemplateId = templateId;
                    campaignRecord.MailSubject = mailSubject;

                    db.SaveChanges();

                    List<int> existingCustomerIds = db.CampaignCustomers.Where(cc => cc.CampaignId == id).Select(cc => cc.Id).ToList();

                    List<int> customersToAdd = customerIds.Except(existingCustomerIds).ToList();
                    List<int> customersToRemove = existingCustomerIds.Except(customerIds).ToList();

                    if(customersToRemove.Count > 0)
                    {
                        List<CampaignCustomer> campaignCustomersToRemove = db.CampaignCustomers
                        .Where(cc => cc.CampaignId == id && customersToRemove.Contains(cc.CustomerId))
                        .Select(cc => cc).ToList();

                        db.CampaignCustomers.RemoveRange(campaignCustomersToRemove);

                        db.SaveChanges();
                    }

                    if(customersToAdd.Count > 0)
                    {
                        int nextCampaignCustomerId = 0;
                        if (db.CampaignCustomers.Count() > 0)
                        {
                            nextCampaignCustomerId = db.CampaignCustomers.Max(x => x.Id);
                        }

                        foreach (int newCustomerId in customersToAdd)
                        {
                            nextCampaignCustomerId += 1;
                            CampaignCustomer newRecord = new CampaignCustomer()
                            {
                                Id = nextCampaignCustomerId,
                                CampaignId = id,
                                CustomerId = newCustomerId,
                                IsSent = 0
                            };

                            db.CampaignCustomers.Add(newRecord);
                        }

                        db.SaveChanges();
                    }

                    return GetCampaign(campaignRecord.Id);
                }
            }
        }

        public bool DeleteCampaign(int id)
        {
            using (var db = new NetEmailContext())
            {
                var record = db.Campaigns.Where(x => x.Id == id).FirstOrDefault();

                List<CampaignCustomer> customersToRemove = db.CampaignCustomers.Where(cc => cc.CampaignId == id).ToList();

                if (customersToRemove.Count > 0) db.CampaignCustomers.RemoveRange(customersToRemove);

                if(record != null) db.Campaigns.Remove(record);

                db.SaveChanges();

                return true;
            }
        }

        public bool StartCampaign(int id)
        {
            using (var db = new NetEmailContext())
            {
                var record = db.Campaigns.Where(x => x.Id == id).FirstOrDefault();

                record.IsActive = 1;

                db.SaveChanges();

                return true;
            }
        }

        public bool StopCampaign(int id)
        {
            using (var db = new NetEmailContext())
            {
                var record = db.Campaigns.Where(x => x.Id == id).FirstOrDefault();

                record.IsActive = 0;

                db.SaveChanges();

                return true;
            }
        }

        public bool DeleteCampaignCustomer(int id)
        {
            using (var db = new NetEmailContext())
            {
                var record = db.CampaignCustomers.Where(x => x.Id == id).FirstOrDefault();

                if (record != null) db.CampaignCustomers.Remove(record);

                db.SaveChanges();

                return true;
            }
        }

        public bool DeleteAllCampaignCustomers(int campaignId)
        {
            using (var db = new NetEmailContext())
            {
                var records = db.CampaignCustomers.Where(x => x.CampaignId == campaignId).ToList();

                db.CampaignCustomers.RemoveRange(records);

                db.SaveChanges();

                return true;
            }
        }

        public bool SetAsSent(int campaignCustomerId)
        {
            using (NetEmailContext db = new NetEmailContext())
            {
                var record = db.CampaignCustomers.FirstOrDefault(c => c.Id == campaignCustomerId);

                record.IsSent = 1;

                db.SaveChanges();

                return true;
            }
        }

        #endregion
    }
}
