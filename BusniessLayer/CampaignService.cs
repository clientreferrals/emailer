using DataAccessLayer.DataBase;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusniessLayer
{
    public class CampaignService
    {

        public List<CampaignDTO> GetCampaigns()
        {
            using (var db = new DirectEmailerEntities())
            {
                List<CampaignDTO> result = (from c in db.Campaigns
                                            join t in db.EmailTemplates on c.TemplateId equals t.Id into ts
                                            from t in ts.DefaultIfEmpty()
                                            select new CampaignDTO()
                                            {
                                                Id = c.Id,
                                                Name = c.Name,
                                                IsActive = c.IsActive,
                                                TemplateId = c.TemplateId,
                                                TemplateName = t.TemplateName,
                                                MailSubject = c.MailSubject,
                                                PendingCount = db.CampaignCustomers.Where(cc => cc.CampaignId == c.Id && !cc.IsSent).Count(),
                                                SentCount = db.CampaignCustomers.Where(cc => cc.CampaignId == c.Id && cc.IsSent).Count()
                                            }).ToList();

                return result;
            }
        }

        public CampaignDTO GetCampaign(int campaignId)
        {
            using (var db = new DirectEmailerEntities())
            {
                CampaignDTO result = (from c in db.Campaigns
                                      join t in db.EmailTemplates on c.TemplateId equals t.Id into ts
                                      from t in ts.DefaultIfEmpty()
                                      where c.Id == campaignId
                                      select new CampaignDTO()
                                      {
                                          Id = c.Id,
                                          Name = c.Name,
                                          IsActive = c.IsActive,
                                          TemplateId = c.TemplateId,
                                          TemplateName = t.TemplateName,
                                          MailSubject = c.MailSubject,
                                          PendingCount = db.CampaignCustomers.Where(cc => cc.CampaignId == c.Id && !cc.IsSent).Count(),
                                          SentCount = db.CampaignCustomers.Where(cc => cc.CampaignId == c.Id && cc.IsSent).Count()
                                      }
                                    ).FirstOrDefault();

                return result;
            }
        }

        public List<CampaignCustomerDTO> GetCampaignCustomers(int campaignId)
        {
            using (var db = new DirectEmailerEntities())
            {
                List<CampaignCustomerDTO> result = (from cc in db.CampaignCustomers
                                                    join c in db.Customers on cc.CustomerId equals c.Id
                                                    where cc.CampaignId == campaignId
                                                    select new CampaignCustomerDTO()
                                                    {
                                                        Id = cc.Id,
                                                        Name = c.Name,
                                                        PhoneNo = c.PhoneNo,
                                                        Tags = c.Tags,
                                                        Email = c.Email,
                                                        IsSent = cc.IsSent
                                                    }
                                                    ).ToList();

                return result;
            }
        }

        public CampaignDTO SaveCampaign(int id, string name, int templateId, string mailSubject, List<int> customerIds)
        {
            if (id == 0)
            {
                using (var db = new DirectEmailerEntities())
                {
                    Campaign record = new Campaign()
                    {
                        Name = name,
                        IsActive = false,
                        TemplateId = templateId,
                        MailSubject = mailSubject,
                        CreatedDateTime = DateTime.Now
                    };

                    db.Campaigns.Add(record);
                    db.SaveChanges();

                    int nextCustomerId = 0;
                    if (db.CampaignCustomers.Count() > 0)
                    {
                        nextCustomerId = db.CampaignCustomers.Max(x => x.Id);
                    }

                    foreach (int customerId in customerIds)
                    {
                        nextCustomerId += 1;
                        CampaignCustomer newRecord = new CampaignCustomer()
                        {
                            Id = nextCustomerId,
                            CampaignId = record.Id,
                            CustomerId = customerId,
                            IsSent = false, 
                            CreatedDateTime = DateTime.Now, 
                            
                        };

                        db.CampaignCustomers.Add(newRecord);
                    }

                    db.SaveChanges();

                    return GetCampaign(record.Id);
                }
            }
            else
            {
                using (var db = new DirectEmailerEntities())
                {
                    var campaignRecord = db.Campaigns.Where(x => x.Id == id).FirstOrDefault();

                    campaignRecord.Name = name;
                    campaignRecord.TemplateId = templateId;
                    campaignRecord.MailSubject = mailSubject;
                    campaignRecord.EditedDateTime = DateTime.Now;

                    db.SaveChanges();

                    List<int> existingCustomerIds = db.CampaignCustomers.Where(cc => cc.CampaignId == id).Select(cc => cc.Id).ToList();

                    List<int> customersToAdd = customerIds.Except(existingCustomerIds).ToList();
                    List<int> customersToRemove = existingCustomerIds.Except(customerIds).ToList();

                    if (customersToRemove.Count > 0)
                    {
                        List<CampaignCustomer> campaignCustomersToRemove = db.CampaignCustomers
                        .Where(cc => cc.CampaignId == id && customersToRemove.Contains(cc.CustomerId))
                        .Select(cc => cc).ToList();
                        foreach (var cRemove in campaignCustomersToRemove)
                        {
                            db.CampaignCustomers.Remove(cRemove);
                        }
                         
                        db.SaveChanges();
                    }

                    if (customersToAdd.Count > 0)
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
                                IsSent = false, 
                                CreatedDateTime = DateTime.Now
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
            using (var db = new DirectEmailerEntities())
            {
                var record = db.Campaigns.Where(x => x.Id == id).FirstOrDefault();

                List<CampaignCustomer> customersToRemove = db.CampaignCustomers.Where(cc => cc.CampaignId == id).ToList();
                foreach (var item in customersToRemove)
                {
                    db.CampaignCustomers.Remove(item);
                }


                if (record != null) db.Campaigns.Remove(record);

                db.SaveChanges();

                return true;
            }
        }

        public bool StartCampaign(int id)
        {
            using (var db = new DirectEmailerEntities())
            {
                var record = db.Campaigns.Where(x => x.Id == id).FirstOrDefault();

                record.IsActive = true;
                record.EditedDateTime = DateTime.Now;
                db.SaveChanges();

                return true;
            }
        }

        public bool StopCampaign(int id)
        {
            using (var db = new DirectEmailerEntities())
            {
                var record = db.Campaigns.Where(x => x.Id == id).FirstOrDefault();

                record.IsActive = false;
                record.EditedDateTime = DateTime.Now;
                db.SaveChanges();

                return true;
            }
        }

        public bool DeleteCampaignCustomer(int id)
        {
            using (var db = new DirectEmailerEntities())
            {
                var record = db.CampaignCustomers.Where(x => x.Id == id).FirstOrDefault();

                if (record != null) db.CampaignCustomers.Remove(record);

                db.SaveChanges();

                return true;
            }
        }

        public bool DeleteAllCampaignCustomers(int campaignId)
        {
            using (var db = new DirectEmailerEntities())
            {
                var records = db.CampaignCustomers.Where(x => x.CampaignId == campaignId).ToList();
                foreach (var item in records)
                {
                    db.CampaignCustomers.Remove(item);
                }

                db.SaveChanges();

                return true;
            }
        }

        public bool SetAsSent(int campaignCustomerId)
        {
            using (DirectEmailerEntities db = new DirectEmailerEntities())
            {
                var record = db.CampaignCustomers.FirstOrDefault(c => c.Id == campaignCustomerId);

                record.IsSent = true;
                record.EditedDateTime = DateTime.Now;
                db.SaveChanges();

                return true;
            }
        }

    }
}
