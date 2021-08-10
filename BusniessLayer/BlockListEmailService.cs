using DataAccessLayer.DataBase;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusniessLayer
{
    public class BlockListEmailService
    {
        public List<BlockListEmailDto> GetBlackListEmails()
        {
            using (var db = new DirectEmailContext())
            {
                return (from e in db.BlockListEmails
                        select new BlockListEmailDto
                        {
                            EmailAddress = e.EmailAddress,
                            Id = e.Id
                        }).ToList();
            }
        }

        public bool Save(int id, string emailAddress)
        {
            if (id == 0)
            {
                using (var db = new DirectEmailContext())
                {
                    BlockListEmail record = new BlockListEmail()
                    {
                        EmailAddress = emailAddress,
                        CreatedDateTime = DateTime.Now
                    };

                    db.BlockListEmails.Add(record);
                    db.SaveChanges();

                    return true;
                }
            }
            else
            {
                using (var db = new DirectEmailContext())
                {
                    var record = db.BlockListEmails.Where(x => x.Id == id).FirstOrDefault();

                    record.EmailAddress = emailAddress;
                    record.EditedDateTime = DateTime.Now;

                    db.SaveChanges();
                    return true;
                }
            }

        }

        public bool Delete(int id)
        {
            using (var db = new DirectEmailContext())
            {
                var record = db.BlockListEmails.Where(x => x.Id == id).FirstOrDefault();

                db.BlockListEmails.Remove(record);
                db.SaveChanges();

                return true;
            }
        }
    }
}
