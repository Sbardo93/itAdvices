using System;
using BusinessLogic;
using BusinessLogic.DB;
using System.Collections.Generic;

namespace BusinessLogic.Presenter
{
    public class UtilsPresenter
    {
        public UtilsPresenter()
        { }
        public List<Log> GetAllLog()
        {
            return DataManager<Log>.GetAll();
        }
    }
}
