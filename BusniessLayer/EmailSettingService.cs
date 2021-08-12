using DataAccessLayer.DataBase;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusniessLayer
{
    public class EmailSettingService
    {
        #region Public Methods

        public List<EmailDTO> GetEmails()
        {
            using (var db = new DirectEmailContext())
            {
                return (from e in db.OurEmailLists
                        select new EmailDTO
                        {
                            Address = e.EmailAddress,
                            DailyLimit = e.DailyLimit,
                            FromAlias = e.FromAlias,
                            Host = e.Host,
                            Id = e.Id,
                            Password = e.Password,
                            Port = e.Port,
                            IMAPHost = e.IMAPHost,
                            IMAPPort = e.IMAPPort,
                            SentCount = e.SentCount,
                            Active = e.Active,
                            TodaySent = db.OurEmailListMaxPerDays.Where(x => x.EmailId == e.Id).Select(x => x.SentCount).FirstOrDefault(),
                            RemainingLimit = e.DailyLimit - db.OurEmailListMaxPerDays.Where(x => x.EmailId == e.Id).Select(x => x.SentCount).FirstOrDefault()
                        }).ToList();
            }
        }

        public bool Save(int id, string host, int port, string address, string password, string fromAddress, string fromAlias, int dailyLimit, int popPort, string popHost)
        {
            if (id == 0)
            {
                using (var db = new DirectEmailContext())
                {
                    OurEmailList record = new OurEmailList()
                    {
                        Host = host,
                        Port = port,
                        Active = true,
                        EmailAddress = address,
                        Password = password,
                        FromAlias = fromAlias,
                        DailyLimit = dailyLimit,
                        IMAPHost = popHost,
                        IMAPPort = popPort,
                        CreatedDateTime = DateTime.Now
                    };
                    db.OurEmailLists.Add(record);
                    db.SaveChanges();

                    return true;
                }
            }
            else
            {
                using (var db = new DirectEmailContext())
                {
                    var record = db.OurEmailLists.Where(x => x.Id == id).FirstOrDefault();
                    if (record != null)
                    {
                        record.Host = host;
                        record.Port = port; 
                        record.EmailAddress = address;
                        record.Password = password;
                        record.FromAlias = fromAlias;
                        record.DailyLimit = dailyLimit;
                        record.IMAPHost = popHost;
                        record.IMAPPort = popPort;
                        record.EditedDateTime = DateTime.Now;

                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DirectEmailContext())
            {
                var record = db.OurEmailLists.Where(x => x.Id == id).FirstOrDefault();

                db.OurEmailLists.Remove(record);
                db.SaveChanges();

                return true;
            }
        }
        public void MarkActiveInActiveById(int id)
        {
            using (var db = new DirectEmailContext())
            {
                var record = db.OurEmailLists.Where(x => x.Id == id).FirstOrDefault();
                if(record!= null)
                {
                    record.Active = !record.Active;
                    db.SaveChanges();
                }
               
            }
        }
        public void MarkAllActiveInActive(bool condition)
        {
            using (var db = new DirectEmailContext())
            {
                foreach (var item in db.OurEmailLists.ToList())
                {
                    item.Active = condition;
                }
                db.SaveChanges();
            }
        }

        #endregion
    }
}
