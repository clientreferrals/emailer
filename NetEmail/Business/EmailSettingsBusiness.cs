using NetEmail.DTO;
using NetEmail.Entity;
using NetMail.Entity;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMail.Business
{
    class EmailSettingsBusiness : Singleton<EmailSettingsBusiness>
    {
        #region Constructor

        public EmailSettingsBusiness()
        {
            CheckTables();
        }

        private void CheckTables()
        {
            if (IsTableExists("Email") == false)
            {
                using (var db = new NetEmailContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                    create table Email 
                    (
                        Id INTEGER AUTO INCREMENT PRIMARY KEY, 
                        Host VARCHAR NOT NULL,
                        Port INTEGER NOT NULL, 
                        Address VARCHAR NOT NULL,
                        Password VARCHAR NOT NULL,
                        FromAddress VARCHAR NULL,
                        FromAlias VARCHAR NULL,
                        DailyLimit INTEGER NOT NULL, 
                        PopHost VARCHAR NOT NULL,
                        PopPort INTEGER NOT NULL )
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

        public List<EmailDTO> GetEmails()
        {
            using (var db = new NetEmailContext())
            {
                return (from e in db.Emails
                        select new EmailDTO
                        {
                            Address = e.Address,
                            DailyLimit = e.DailyLimit,
                            FromAddress = e.FromAddress,
                            FromAlias = e.FromAlias,
                            Host = e.Host,
                            Id = e.Id,
                            Password = e.Password,
                            Port = e.Port,
                            RemainingLimit = e.DailyLimit,
                            PopHost = e.PopHost,
                            PopPort = e.PopPort
                        }).ToList();
            }
        }

        public Email Save(int id, string host, int port, string address, string password, string fromAddress, string fromAlias, int dailyLimit, int popPort, string popHost)
        {
            if (id == 0)
            {
                using (var db = new NetEmailContext())
                {
                    int maxId = 0;
                    if (db.Emails.Count() > 0)
                    {
                        maxId = db.Emails.Max(x => x.Id);
                    }

                    Email record = new Email()
                    {
                        Id = maxId + 1,
                        Host = host,
                        Port = port,
                        Address = address,
                        Password = password,
                        FromAddress = fromAddress,
                        FromAlias = fromAlias,
                        DailyLimit = dailyLimit,
                        PopHost = popHost,
                        PopPort = popPort
                    };

                    db.Emails.Add(record);
                    db.SaveChanges();

                    return record;
                }
            }
            else
            {
                using (var db = new NetEmailContext())
                {
                    var record = db.Emails.Where(x => x.Id == id).FirstOrDefault();

                    record.Host = host;
                    record.Port = port;
                    record.Address = address;
                    record.Password = password;
                    record.FromAddress = fromAddress;
                    record.FromAlias = fromAlias;
                    record.DailyLimit = dailyLimit;
                    record.PopHost = popHost;
                    record.PopPort = popPort;

                    db.SaveChanges();

                    return record;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new NetEmailContext())
            {
                var record = db.Emails.Where(x => x.Id == id).FirstOrDefault();

                db.Emails.Remove(record);
                db.SaveChanges();

                return true;
            }
        }

        #endregion
    }
}
