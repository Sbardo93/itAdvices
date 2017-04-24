using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITAdvices.Entity.Common;
using System.Text;

namespace ITAdvices.Shared
{
    public class MenuHandler
    {
        public MenuHandler(Entity.DB.Ruolo ruolo)
        {
        }
        //<li class="nav-item active">
        //            <a class="nav-link" href="#">Home<span class="sr-only">(current)</span></a>
        //        </li>
        //        <li class="nav-item">
        //            <a class="nav-link" href="#">Link</a>
        //        </li>
        //        <li class="nav-item">
        //            <a class="nav-link disabled" href="#">Disabled</a>
        //        </li>
        //        <li class="nav-item dropdown">
        //            <a class="nav-link dropdown-toggle" href="http://example.com" id="dropdown01" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dropdown</a>
        //            <div class="dropdown-menu" aria-labelledby="dropdown01">
        //                <a class="dropdown-item" href="#">Action</a>
        //                <a class="dropdown-item" href="#">Another action</a>
        //                <a class="dropdown-item" href="#">Something else here</a>
        //            </div>
        //        </li>

        private const string link = "<a class=\"nav-link{3}\" href=\"{0}\"{4}>{1}{2}</a>";
        private const string srOnly = "<span class=\"sr-only\">(current)</span>";
        private static string RenderLink(string href, string nomePagina, bool active, bool enabled)
        {
            if (!enabled)
                return string.Format(link, "#", nomePagina, "", " disabled", " onclick=\"return false;\"");
            else
                return string.Format(link, href, nomePagina, active ? srOnly : "", "", "");
        }

        public string RenderMenu()
        {
            List<Menu> ListaMenu = new List<Menu>();

            switch (Utility.GetCurrentPageName(HttpContext.Current.Request))
            {
                case Keys.Pages.Default:
                    ListaMenu.Add(new Menu(Keys.Pages.DefaultPage, true, true));
                    ListaMenu.Add(new Menu(Keys.Pages.LoginPage, true, false));
                    break;
                case Keys.Pages.Login:
                    ListaMenu.Add(new Menu(Keys.Pages.DefaultPage, true, false));
                    ListaMenu.Add(new Menu(Keys.Pages.LoginPage, true, true));
                    break;
                case Keys.Pages.Courtesy:
                    break;
                default:
                    break;
            }
            
            StringBuilder menuResult = new StringBuilder();
            ListaMenu.ForEach(
                x =>
                {
                    menuResult.AppendLine(x.ToString());
                });
            return menuResult.ToString();
        }
        protected class Menu
        {
            private string Nome { get; set; }
            private string hRef { get; set; }
            private bool Enabled { get; set; }
            private bool Active { get; set; }

            public Menu(Keys.Pages page, bool enabled, bool active)
            {
                Nome = page.Nome;
                hRef = Utility.GetAbsoluteUrl(page.Pagina);
                Enabled = enabled;
                Active = active;
            }

            public override string ToString()
            {
                StringBuilder menu = new StringBuilder();
                if (Active)
                    menu.AppendLine("<li class=\"nav-item active\">");
                else
                    menu.AppendLine("<li class=\"nav-item\">");
                menu.AppendLine(RenderLink(hRef, Nome, Active, Enabled));
                menu.AppendLine("</li>");

                return menu.ToString();
            }
        }
    }
}