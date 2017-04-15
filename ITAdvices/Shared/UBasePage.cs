using System.Text;
using System.Linq;
using System.Web;
using Unicarpe.Shared;
using System.Collections.Generic;
using Unicarpe;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Specialized;
using System;
using ITAdvices.Business;
using ITAdvices.Entity.DB;
using System.Security.Principal;
//using Unicarpe.Pages.Domanda;

namespace ITAdvices
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
        protected override void OnPreLoad(System.EventArgs e)
        {
            base.OnPreLoad(e);

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
                catch(Exception ex)
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

        private bool _isStoricizzato;
        public bool isStoricizzato
        {
            get { return _isStoricizzato; }
            set { _isStoricizzato = value; }
        }

        private bool _isEnpalsStoricizzato;
        public bool isEnpalsStoricizzato
        {
            get { return _isEnpalsStoricizzato; }
            set { _isEnpalsStoricizzato = value; }
        }

        private bool _isSupplementoConfermato;
        public bool isSupplementoConfermato
        {
            get { return _isSupplementoConfermato; }
            set { _isSupplementoConfermato = value; }
        }

        public IPrincipal Utente
        {
            get
            {
                return (IPrincipal)Context.User;
            }
        }
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);

            if (Context.Session != null)
            {
                //if (!string.IsNullOrEmpty((string)SessionHelper.Get(SessionKeys.IdMenuExt)))
                //{
                //    return;
                //}
                //Tested and the IsNewSession is more advanced then simply checking if 
                // a cookie is present, it does take into account a session timeout, because 
                // I tested a timeout and it did show as a new session
                if (Session.IsNewSession)
                {
                    // If it says it is a new session, but an existing cookie exists, then it must 
                    // have timed out (can't use the cookie collection because even on first 
                    // request it already contains the cookie (request and response
                    // seem to share the collection)
                    string szCookieHeader = Request.Headers["Cookie"];
                    if ((null != szCookieHeader) && (szCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        //if (VerificaApplicationState())
                        //{
                        //    HttpContext.Current.Response.Redirect("~/Pages/Shared/SessionTimeOut.aspx");
                        //}
                    }
                }
            }
        }
       
        protected void RegisterAvantiOnClick(string key)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), key,
                        @"$(document).ready(function(){   
                            $('#btnAvanti').click();
                        });
                    ", true);
        }
    }
}
