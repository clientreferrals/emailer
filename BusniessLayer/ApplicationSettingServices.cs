using DataAccessLayer.DataBase;
using System;
using System.Linq;

namespace BusniessLayer
{
    public class ApplicationSettingServices
    {
        public string GetValue(string key)
        {

            using (var db = new DirectEmailerEntities())
            {
                ApplicationSetting applicationSetting = db.ApplicationSettings.Where(x => x.SettingKey == key).FirstOrDefault();
                if (applicationSetting == null)
                {
                    return "0";
                }
                return applicationSetting.SettingValue;
            }
        }

        public ApplicationSetting AddUpdate(string key, string value)
        {

            using (var db = new DirectEmailerEntities())
            {
                ApplicationSetting applicationSetting = db.ApplicationSettings.Where(x => x.SettingKey == key).FirstOrDefault();
                if (applicationSetting == null)
                {
                    applicationSetting = new ApplicationSetting()
                    {
                        SettingKey = key,
                        SettingValue = value,
                        CreatedDateTime = DateTime.Now
                    };
                    db.ApplicationSettings.Add(applicationSetting);
                    db.SaveChanges();

                    return applicationSetting;
                }

                applicationSetting.SettingValue = value;
                applicationSetting.EditedDateTime = DateTime.Now;
                db.SaveChanges();

                return applicationSetting;
            }
        }

    }
}
