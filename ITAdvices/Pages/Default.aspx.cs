using System;
using ITAdvices.Business;
using System.Collections.Generic;
using System.Linq;
using ITAdvices.UserControls;
using ITAdvices.Entity.DB;

namespace ITAdvices.Pages
{
    public partial class Default : Shared.UBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utente u = SessionHelper.GetValue<Utente>(SessionKeys.UtenteCorrente);
            if (u != null)
                lblprova.Text = u.Username;
            //this.ucSmartGrid.LoadSmartGrid(new UtilsPresenter().GetAllLog().Select(x => new SmartGridEntity.Log(x)).ToList(), true, false,
            //    new List<ucSmartGrid.ButtonTypeEnum>()
            //    { ucSmartGrid.ButtonTypeEnum.Excel, ucSmartGrid.ButtonTypeEnum.Pdf, ucSmartGrid.ButtonTypeEnum.Print },
            //    "Log");


        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public static ucSmartGrid.SmartGridData GetObjects()
        {
            return ucSmartGrid.GetObjects();
        }
    }
}