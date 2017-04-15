using ITAdvices.Entity.Common;
using System;
using System.Collections.Generic;
using ITAdvices.Entity.DB;

namespace ITAdvices.Business
{
    public class UtilsPresenter
    {
        public UtilsPresenter()
        { }
        public List<Log> GetAllLog()
        {
            return DataManager<Log>.GetAll();
        }
        public List<Parametri> GetAllParametri()
        {
            return DataManager<Parametri>.GetAll();
        }
        public static bool IsOffline()
        {
            Parametri p = null;
            if (DataManager<Parametri>.Find(x => x.Dominio == Keys.DominioParametri.OFFLINE, ref p))
            {
                if (p != null && p.Codifica == Keys.SI)
                    return true;
            }
            return false;
        }
    }
}
