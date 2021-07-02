using NetMail.Entity;
using NetMail.Utility;
using System;
using System.Linq;

namespace NetMail.Business
{
    class SettingsBusiness : Singleton<SettingsBusiness>
    {
        #region Constructor

        public SettingsBusiness()
        {
            CheckTables();
        }

        private void CheckTables()
        {
            if(IsTableExists("Setting") == false)
            {
                using (var db = new NetEmailContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                    create table Setting 
                    (
                        Id INTEGER AUTO INCREMENT PRIMARY KEY, 
                        Key VARCHAR NOT NULL, 
                        Value TEXT
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

        public bool Set(string key, string value)
        {
            if(Get(key) == null)
            {
                Add(key, value);
            }
            else
            {
                Update(key, value);
            }

            return true;
        }

        public Setting Get(string key)
        {
            using (var db = new NetEmailContext())
            {
                return db.Settings.Where(s => s.Key == key).FirstOrDefault();
            }
        }

        public string GetValue(string key)
        {
            using (var db = new NetEmailContext())
            {
                var ss = db.Settings.Where(s => s.Key == key).FirstOrDefault();
                if (ss == null) return String.Empty;
                else return ss.Value;
            }
        }

        #endregion

        #region Private Methods

        private Setting Add(string key, string value)
        {
            using (var db = new NetEmailContext())
            {
                int maxId = 0;
                if (db.Settings.Count() > 0)
                {
                    maxId = db.Settings.Max(x => x.Id);
                }

                Setting s = new Setting()
                {
                    Id = maxId + 1,
                    Key = key,
                    Value = value
                };

                db.Settings.Add(s);
                db.SaveChanges();

                return s;
            }
        }

        private Setting Update(string key, string value)
        {
            using (var db = new NetEmailContext())
            {
                Setting s = db.Settings.Where(x => x.Key == key).FirstOrDefault();

                s.Value = value;

                db.SaveChanges();

                return s;
            }
        }

        #endregion
    }
}
