using ITAdvices.Entity.Common;
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
        public static Utente TryLogin(string username, string passWord)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new CustomException(Messages.Login_UsernameNonInserita);
                }
                if (string.IsNullOrWhiteSpace(passWord))
                {
                    throw new CustomException(Messages.Login_PasswordNonInserita);
                }
                Utente u = null;
                if (DataManager<Utente>.Find(x => x.Username == username, ref u) && u.Username == passWord)
                {
                    return u;
                }
                throw new CustomException(Messages.Login_UsernamePasswordErrate);
            }
            catch (CustomException cEx) { throw cEx; }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                throw new Exception(Messages.Login_Errore);
            }
        }
    }
}
