using ITAdvices.Entity.DB;
using System;
using System.Collections.Generic;

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
    }
}
