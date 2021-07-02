using NetEmail.Entity;
using NetMail.Entity;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetEmail.Business
{
    class TemplateBusiness : Singleton<TemplateBusiness>
    {
        #region Constructor

        public TemplateBusiness()
        {
            CheckTables();
        }

        private void CheckTables()
        {
            if (IsTableExists("Template") == false)
            {
                using (var db = new NetEmailContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                    create table Template 
                    (
                        Id INTEGER AUTO INCREMENT PRIMARY KEY, 
                        Name VARCHAR NOT NULL,
                        Content TEXT NOT NULL
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

        public List<Template> GetTemplates()
        {
            using (var db = new NetEmailContext())
            {
                return db.Templates.ToList();

            }
        }

        public Template Save(int id, string name, string content)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new Exception("Template name cannot be empty. Please control and try again.");
            }

            if (id == 0)
            {
                using (var db = new NetEmailContext())
                {
                    int maxId = 0;
                    if (db.Templates.Count() > 0)
                    {
                        maxId = db.Templates.Max(x => x.Id);
                    }

                    Template record = new Template()
                    {
                        Id = maxId + 1,
                        Name = name,
                        Content = content
                    };

                    db.Templates.Add(record);
                    db.SaveChanges();

                    return record;
                }
            }
            else
            {
                using (var db = new NetEmailContext())
                {
                    var record = db.Templates.Where(x => x.Id == id).FirstOrDefault();

                    record.Name = name;
                    record.Content = content;

                    db.SaveChanges();

                    return record;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new NetEmailContext())
            {
                var record = db.Templates.Where(x => x.Id == id).FirstOrDefault();

                db.Templates.Remove(record);
                db.SaveChanges();

                return true;
            }
        }

        #endregion
    }
}
