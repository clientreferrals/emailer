using DataAccessLayer.DataBase;
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
    }
}
