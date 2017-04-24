using ITAdvices.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITAdvices.UserControl
{
    public partial class Menu : UBaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuHandler menu = new MenuHandler(null);
            ulMenu.InnerHtml = menu.RenderMenu();

        }
    }
}