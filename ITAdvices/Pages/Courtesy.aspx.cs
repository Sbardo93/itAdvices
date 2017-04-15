using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITAdvices.Entity.Common;
using ITAdvices.Business;

namespace ITAdvices.Pages
{
    public partial class Courtesy : UBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ManageCourtesy();
        }

        private void ManageCourtesy()
        {
            lblMsg.Text = Messages.All_GenericError;
            Enums.Courtesy courtesy = Enums.Courtesy.Default;
            try
            {
                courtesy = SessionHelper.GetValue<Enums.Courtesy>(SessionKeys.Courtesy);
            }
            catch (Exception) { }

            switch (courtesy)
            {
                case Enums.Courtesy.SessioneDuplicata:
                    divSessioneDuplicata.Visible = true;
                    lblSessioneDuplicata.Text = Messages.Courtesy_SessioneDuplicata;
                    SessionHelper.Set(SessionKeys.SESSION_DUPLICATED, Keys.SI);
                    break;
                case Enums.Courtesy.SessioneScaduta:
                    divSessioneScaduta.Visible = true;
                    lblSessioneScaduta.Text = Messages.Courtesy_SessioneScaduta;
                    break;
                default:
                    divDefault.Visible = true;
                    lblMsg.Text = SessionHelper.GetValue(SessionKeys.Courtesy_Error);
                    break;
            }

            SessionHelper.Delete(SessionKeys.Courtesy);
            SessionHelper.Delete(SessionKeys.Courtesy_Error);
        }
    }
}