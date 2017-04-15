using System;
using ITAdvices.Business;
using System.Collections.Generic;
using System.Linq;
using ITAdvices.UserControls;

namespace ITAdvices.Pages
{
    public partial class Default : UBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblprova.Text = new UtentiPresenter().GetUtente(Guid.Empty).ToString();
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