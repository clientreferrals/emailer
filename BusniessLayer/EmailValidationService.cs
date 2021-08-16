using DataAccessLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusniessLayer
{
    public class EmailValidationService
    {
        public List<string> GetNotAllowList()
        {
            List<string> returnList = new List<string>();
            using (var db = new DirectEmailContext())
            {
                returnList = db.NotAllowedEmails.Select(x => x.NotAllowedString).ToList();
            }
            return returnList;
        }
        public List<string> GetValidEmails()
        {
            List<string> returnList = new List<string>();
            using (var db = new DirectEmailContext())
            {
                returnList = db.ValidEmailAddresses.Select(x => x.ValidEmailAddresses).ToList();
            }
            return returnList;
        }

        public void SaveNewRecord(string text, bool condition)
        {
            using (var db = new DirectEmailContext())
            {
                ValidEmailAddress record = db.ValidEmailAddresses.Where(x => x.ValidEmailAddresses == text).FirstOrDefault();
                if (record == null)
                {
                    record = new ValidEmailAddress()
                    {
                        ValidEmailAddresses = text,
                        IsValid = condition,
                        CreateDateTime = DateTime.Now,
                    };
                    db.ValidEmailAddresses.Add(record);
                }
                else
                {
                    record.IsValid = condition;
                    record.EditDateTime = DateTime.Now;
                }

                db.SaveChanges();
            }
        }
    }
}
