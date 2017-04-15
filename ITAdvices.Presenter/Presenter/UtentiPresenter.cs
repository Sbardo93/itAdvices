using ITAdvices.Entity.DB;
using System;

namespace ITAdvices.Business
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
