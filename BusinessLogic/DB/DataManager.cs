using BusinessLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public static class DataManager<T> where T : class
    {
        const string dbService = "ITADVICES";
        public static List<Utenti> getUsers()
        {
            try
            {
                using (DBEntities db = new DBEntities())
                {
                    var res = (from u
                               in db.Utenti
                               select u).ToList();
                    return res;
                }
            }
            catch (Exception) { }
            return null;
        }
        public static T GetById(int id)
        {
            try
            {
                using (DBService<T> db = new DBService<T>())
                {
                    var result = db.Get(id);
                    return result;
                }
            }
            catch (Exception) { }
            return null;
        }
        public static T GetByGuid(Guid guid)
        {
            try
            {
                using (DBService<T> db = new DBService<T>())
                {
                    var result = db.Get(guid);
                    return result;
                }
            }
            catch (Exception) { }
            return null;
        }
        public static List<T> GetAll()
        {
            try
            {
                using (DBService<T> db = new DBService<T>())
                {
                    var result = db.GetAll();
                    if (result != null)
                        return result.ToList();
                }
            }
            catch (Exception) { }
            return null;
        }
    }
}
