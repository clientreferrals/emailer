using DataAccessLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusniessLayer
{
    public class EmailTemplateService
    {
        #region Public Methods

        public List<EmailTemplate> GetTemplates()
        {
            using (var db = new DirectEmailContext())
            {
                return db.EmailTemplates.Select(x=>x).ToList();

            }
        }

        public EmailTemplate Save(int id, string name, string content)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Template name cannot be empty. Please control and try again.");
            }

            if (id == 0)
            {
                using (var db = new DirectEmailContext())
                {

                    EmailTemplate record = new EmailTemplate()
                    {
                        TemplateContent = content,
                        TemplateName = name,
                        CreatedDateTime = DateTime.Now
                    };

                    db.EmailTemplates.Add(record);
                    db.SaveChanges();

                    return record;
                }
            }
            else
            {
                using (var db = new DirectEmailContext())
                {
                    var record = db.EmailTemplates.Where(x => x.Id == id).FirstOrDefault();

                    record.TemplateName = name;
                    record.TemplateContent = content;
                    record.EditedDateTime = DateTime.Now;

                    db.SaveChanges();

                    return record;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DirectEmailContext())
            {
                var record = db.EmailTemplates.Where(x => x.Id == id).FirstOrDefault();

                db.EmailTemplates.Remove(record);
                db.SaveChanges();

                return true;
            }
        }

        #endregion
    }
}
