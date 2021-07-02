using DirectEmailResults.DTO;
using DirectEmailResults.Entity;
using NetMail.Entity;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectEmailResults.Business
{
    public class BlackListEmailBusiness : Singleton<BlackListEmailBusiness>
    {
        public BlackListEmailBusiness()
        {
            CheckTables();
        }
        #region
        private void CheckTables()
        {
            if (IsTableExists("BlackListEmails") == false)
            {
                using (var db = new NetEmailContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                    create table BlackListEmails 
                    (
                        Id INTEGER AUTO INCREMENT PRIMARY KEY, 
                        EmailAddress VARCHAR NOT NULL 
                    )
                    ");
                }
            }
            //else
            //{
            //    using (var db = new NetEmailContext())
            //    {
            //        db.Database.ExecuteSqlCommand(@"
            //        delete from BlackListEmails 
            //        ");
            //    }
            //}
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

        public List<BlackListEmailDto> GetBlackListEmails()
        {
            using (var db = new NetEmailContext())
            {
                return (from e in db.BlackListEmails
                        select new BlackListEmailDto
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
                using (var db = new NetEmailContext())
                {
                    int maxId = 0;
                    if (db.BlackListEmails.Count() > 0)
                    {
                        maxId = db.BlackListEmails.Max(x => x.Id);
                    }

                    BlackListEmails record = new BlackListEmails()
                    {
                        Id = maxId + 1,
                        EmailAddress = emailAddress,
                    };

                    db.BlackListEmails.Add(record);
                    db.SaveChanges();

                    return true;
                }
            }
            else
            {
                using (var db = new NetEmailContext())
                {
                    var record = db.BlackListEmails.Where(x => x.Id == id).FirstOrDefault();

                    record.EmailAddress = emailAddress;

                    db.SaveChanges();
                    return true;
                }
            }

        }

        public bool Delete(int id)
        {
            using (var db = new NetEmailContext())
            {
                var record = db.BlackListEmails.Where(x => x.Id == id).FirstOrDefault();

                db.BlackListEmails.Remove(record);
                db.SaveChanges();

                return true;
            }
        }

        #endregion
    }
}
