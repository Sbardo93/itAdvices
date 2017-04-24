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
        public static void TryLogin(string email, string password)
        {
            if(UtentiPresenter.TryLogin(email, password))
            {

            }
        }
    }
}