using DataAccessLayer.DataBase;
using System;
using System.Linq;

namespace BusniessLayer
{
    public class OurEmailListMaxPerDayService
    {
        public bool AddUpdate(int emailId)
        {
            using (var db = new DirectEmailContext())
            {
                var entity = (from e in db.OurEmailListMaxPerDays
                              where e.EmailId == emailId
                              select e).FirstOrDefault();
                if (entity == null)
                {
                    entity = new OurEmailListMaxPerDay()
                    {
                        CreatedDateTime = DateTime.Now,
                        EmailId = emailId,
                        SentCount = 1
                    };
                    db.OurEmailListMaxPerDays.Add(entity);
                    db.SaveChanges();
                    return true;
                }
                entity.EditedDateTime = DateTime.Now;
                entity.SentCount += 1;

                db.SaveChanges(); 
                return true;

            }
        }
        public void ResetCount()
        {
            using (var db = new DirectEmailContext())
            {
                var entities = (from e in db.OurEmailListMaxPerDays 
                              select e).ToList();
                foreach (var entity in entities)
                { 
                    bool isReset = false;
                    if (entity.EditedDateTime != null)
                    {
                        if (DateTime.Now.Date != entity.EditedDateTime.Value.Date)
                        {
                            isReset = true;
                        }
                    }
                    // this is else is only for one time 
                    else
                    {
                        entity.EditedDateTime = DateTime.Now;
                        if (DateTime.Now.Date != entity.CreatedDateTime.Date)
                        {
                            isReset = true;
                        }
                    }
                    if (isReset)
                    {
                        entity.SentCount = 0;
                    } 
                    db.SaveChanges(); 
                } 
            }
        }
        public int GetSentCount(int emailId)
        {

            using (var db = new DirectEmailContext())
            {
                return (from e in db.OurEmailListMaxPerDays
                        where e.EmailId == emailId
                        select e.SentCount).FirstOrDefault();
            }
        }
    }
}
