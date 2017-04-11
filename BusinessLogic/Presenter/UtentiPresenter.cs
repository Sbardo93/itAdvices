using System;
using BusinessLogic;
using BusinessLogic.DB;

namespace BusinessLogic.Presenter
{
    public class UtentiPresenter
    {
        public UtentiPresenter()
        { }
        public Utente GetUtente(Guid guidUtente)
        {
            return DataManager<Utente>.GetByGuid(guidUtente);
        }
    }
}
