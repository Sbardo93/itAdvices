using BusinessLogic.DB;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class DataManager
    {
        const string dbService = "ITADVICES";
        public static List<Utenti> getUsers()
        {
            using (DBEntities db = new DBEntities())
            {
                var res = (from u
                           in db.Utenti
                           select u).ToList();
                return res;
            }
            return null;
        }
    }
}
