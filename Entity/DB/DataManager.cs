﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ITAdvices.Entity.DB
{
    public static class DataManager<T> where T : class
    {

        #region Get
        public static T GetById(int id)
        {
            try
            {
                using (DataService<T> db = new DataService<T>())
                {
                    var result = db.Get(id);
                    return result;
                }
            }
            catch (Exception ex) { Logger.LogException(ex); }
            return null;
        }
        public static T GetByGuid(Guid guid)
        {
            try
            {
                using (DataService<T> db = new DataService<T>())
                {
                    var result = db.Get(guid);
                    return result;
                }
            }
            catch (Exception ex) { Logger.LogException(ex); }
            return null;
        }
        public static List<T> GetAll()
        {
            try
            {
                using (DataService<T> db = new DataService<T>())
                {
                    var result = db.GetAll();
                    if (result != null)
                        return result.ToList();
                }
            }
            catch (Exception ex) { Logger.LogException(ex); }
            return null;
        }
        #endregion

        #region Delete
        public static bool DeleteById(int id)
        {
            try
            {
                using (DataService<T> db = new DataService<T>())
                {
                    T entity = GetById(id);
                    Delete(entity);
                    return true;
                }
            }
            catch (Exception ex) { Logger.LogException(ex); }
            return false;
        }
        public static bool DeleteByGuid(Guid guid)
        {
            try
            {
                using (DataService<T> db = new DataService<T>())
                {
                    T entity = GetByGuid(guid);
                    Delete(entity);
                    return true;
                }
            }
            catch (Exception ex) { Logger.LogException(ex); }
            return false;
        }
        private static bool Delete(T entity)
        {
            try
            {
                using (DataService<T> db = new DataService<T>())
                {
                    db.Delete(entity);
                    return true;
                }
            }
            catch (Exception ex) { Logger.LogException(ex); }
            return false;
        }
        #endregion

        #region Find
        public static bool Find(Expression<Func<T, bool>> match, ref T entity)
        {
            try
            {
                using (DataService<T> db = new DataService<T>())
                {
                    entity = db.Find(match);
                    return entity != null;
                }
            }
            catch (Exception ex) { Logger.LogException(ex); }
            return false;
        }
        public static bool FindAll(Expression<Func<T, bool>> match, ref List<T> entity)
        {
            try
            {
                using (DataService<T> db = new DataService<T>())
                {
                    entity = db.FindAll(match).ToList();
                    return true;
                }
            }
            catch (Exception ex) { Logger.LogException(ex); }
            return false;
        }
        #endregion
    }
}
