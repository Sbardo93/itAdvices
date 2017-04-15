using System.Text;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Specialized;
using System;
using ITAdvices.Business;
using ITAdvices.Entity.DB;
using System.Security.Principal;
using ITAdvices.Entity.Common;
using System.Web.UI;
//using Unicarpe.Pages.Domanda;

namespace ITAdvices.Shared
{
    public class UBasePage : System.Web.UI.Page, IBasePageView
    {
        private readonly BasePagePresenter presenter;


        public UBasePage()
        {
            presenter = new BasePagePresenter();
            presenter.View = this;
        }

        public bool inManutenzione
        {
            get
            {
                bool ret = false;
                try
                {
                    ret = (bool)SessionHelper.Get(SessionKeys.InManutenzione);
                }
                catch
                {
                }
                return ret;
            }
        }

        public List<Parametri> ListaParametri
        {
            get
            {
                UtilsPresenter presenter = new UtilsPresenter();
                try
                {
                    return presenter.GetAllParametri();
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                    return new List<Parametri>();
                }
            }
        }

        private List<string> _menu;
        public List<string> menu
        {
            get
            {
                return _menu;
            }
            set
            {
                _menu = value;
            }
        }

        private List<string> _news;
        public List<string> news
        {
            get { return _news; }
            set { _news = value; }
        }

        private List<string> _errors;
        public List<string> errors
        {
            get
            {
                if (_errors == null)
                {
                    _errors = new List<string>();
                }

                return _errors;
            }
            set
            {
                _errors = value;
            }
        }

        private List<string> _messages;
        public List<string> messages
        {
            get
            {
                if (_messages == null)
                {
                    _messages = new List<string>();
                }

                return _messages;
            }
            set
            {
                _messages = value;
            }
        }
        private bool _isValid;
        public bool isValid
        {
            get
            {
                if (_errors != null)
                {
                    if (_errors.Count() > 0) return false;
                }
                return _isValid;
            }
            set
            {
                _isValid = value;
            }
        }

        public IPrincipal Utente
        {
            get
            {
                return (IPrincipal)Context.User;
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            if (!Utility.IsCorrectGET(Request))
            {
                HideForm(this);
                return;
            }

            SessionHelper.Delete(SessionKeys.Courtesy);

            string currentPage = Utility.GetCurrentPageName(System.Web.HttpContext.Current.Request);

            switch (currentPage)
            {
                case Keys.Pages.Default:
                    SessionHelper.SetValue(SessionKeys.SESSION_ALIVE, Keys.SI);
                    break;
                default:
                    if (Utility.IsSessionExpired())
                    {
                        SessionHelper.Set(SessionKeys.Courtesy, Enums.Courtesy.SessioneScaduta);
                        Response.Redirect(Utility.GetUrl(Keys.Pages.Courtesy), true);
                        return;
                    }
                    break;
            }

            if (Utility.IsNoJavascript())
            {
                ResetGuid();
            }

            //if (!IsUserAbilitato())
            //{
            //    SessionHelper.Set(SessionKeys.Courtesy, Enums.Courtesy.Default);
            //    SessionHelper.SetValue(SessionKeys.Courtesy_Error, Messages.UtenteNonAbilitato);
            //    Response.Redirect(Pages.GetUrl(Pages.Courtesy), true);
            //    return;
            //}

            if (!Utility.CheckXSS(this.Request))
            {
                SessionHelper.Set(SessionKeys.Courtesy, Enums.Courtesy.Default);
                SessionHelper.SetValue(SessionKeys.Courtesy_Error, Messages.XSS);
                Response.Redirect(Utility.GetUrl(Keys.Pages.Courtesy), true);
                return;
            }

            if (!Utility.CheckXSS(this))
            {
                SessionHelper.Set(SessionKeys.Courtesy, Enums.Courtesy.Default);
                SessionHelper.SetValue(SessionKeys.Courtesy_Error, Messages.XSS);
                Response.Redirect(Utility.GetUrl(Keys.Pages.Courtesy), true);
                return;
            }

            if (IsOffline())
            {
                SessionHelper.Set(SessionKeys.Courtesy, Enums.Courtesy.Default);
                SessionHelper.SetValue(SessionKeys.Courtesy_Error, Messages.Offline);
                Response.Redirect(Utility.GetUrl(Keys.Pages.Courtesy), true);
                return;
            }

            switch (currentPage)
            {
                case Keys.Pages.Default:
                    break;
                default:
                    if (!CheckNessunaUtenza())
                    {
                        SessionHelper.Set(SessionKeys.Courtesy, Enums.Courtesy.Default);
                        SessionHelper.SetValue(SessionKeys.Courtesy_Error, Messages.NessunaUtenza);
                        Response.Redirect(Utility.GetUrl(Keys.Pages.Courtesy), true);
                        return;
                    }
                    break;
            }

            Utility.MantainScroll(this, true);
            base.OnLoad(e);
        }

        #region private members
        private bool IsSessioneDuplicata()
        {
            string sessionGuid = SessionHelper.GetValue(SessionKeys.GUID);
            string viewStateGuid = ViewState[SessionKeys.GUID.Value] + string.Empty;
            if (!string.IsNullOrEmpty(viewStateGuid) &&
                sessionGuid != viewStateGuid)
                return true;
            return false;
        }

        private void ResetGuid()
        {
            SessionHelper.SetValue(SessionKeys.GUID, Guid.NewGuid().ToString());
            ViewState[SessionKeys.GUID.Value] = SessionHelper.GetValue(SessionKeys.GUID);
        }

        private bool IsOffline()
        {
            return UtilsPresenter.IsOffline();
        }

        private bool CheckNessunaUtenza()
        {
            Utente datiUtente = SessionHelper.GetValue<Utente>(SessionKeys.UtenteCorrente);
            return datiUtente != null;
        }

        private void HideForm(Control Controlli)
        {
            if (Controlli != null && Controlli.Controls != null && Controlli.Controls.Count > 0)
            {
                foreach (Control ctrl in Controlli.Controls)
                {
                    HideForm(ctrl);
                    switch (ctrl.GetType().Name)
                    {
                        case "Panel":
                        case "TextBox":
                        case "CheckBox":
                        case "RadioButton":
                        case "Button":
                        case "DropDownList":
                        case "LinkButton":
                        case "ImageButton":
                        case "HtmlGenericControl":
                            ctrl.Visible = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        #endregion
    }
}
