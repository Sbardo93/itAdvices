using System;
using ITAdvices.Business;
using System.Collections.Generic;
using System.Linq;
using ITAdvices.UserControls;
using ITAdvices.Entity.DB;

namespace ITAdvices.Pages
{
    public partial class Login : Shared.UBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        [System.Web.Services.WebMethod(true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static string TryLogin(string username, string password)
        {
            Utente utente = UtentiPresenter.TryLogin(username, password);
            if (utente != null)
            {
                SessionHelper.Set(SessionKeys.UtenteCorrente, utente);
            }
            return "Login effettuato";
        }
    }
}