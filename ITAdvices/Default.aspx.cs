using System;
using BusinessLogic.Presenter;
using System.Collections.Generic;

namespace ITAdvices
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblprova.Text = new UtentiPresenter().GetUtente(Guid.Empty).ToString();
            this.ucSmartGrid.LoadSmartGrid(new UtilsPresenter().GetAllLog(), true, false,
                new List<ucSmartGrid.ButtonTypeEnum>()
                { ucSmartGrid.ButtonTypeEnum.Excel, ucSmartGrid.ButtonTypeEnum.Pdf, ucSmartGrid.ButtonTypeEnum.Print },
                "Log");
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public static ucSmartGrid.SmartGridData GetObjects()
        {
            return ucSmartGrid.GetObjects();
        }
    }
}