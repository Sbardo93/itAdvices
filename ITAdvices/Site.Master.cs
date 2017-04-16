using ITAdvices.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITAdvices
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MenuHandler menu = new MenuHandler(null);
            ulMenu.InnerHtml = menu.RenderMenu();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}