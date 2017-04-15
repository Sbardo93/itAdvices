using System;
using System.Collections.Generic;
using Sessione = System.Web.HttpContext;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Globalization;
using System.Threading;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Reflection;
using ITAdvices.Entity.Common;
using ITAdvices.Business;

namespace ITAdvices.Shared
{
    public class Utility
    {
        #region Javascript
        public static bool IsNoJavascript()
        {
            if (SessionHelper.GetValue(SessionKeys.NoJavascript) == Keys.SI)
                return true;
            else
                return false;
        }

        public static bool IsCorrectGET(HttpRequest request)
        {
            if (Utility.IsNoJavascript() && request.HttpMethod == "GET" && request.QueryString["jsdisabled"] == null)
                return false;
            return true;
        }

        #endregion
        #region XSS
        public static bool CheckXSS(Control Controlli)
        {
            if (Controlli.Controls.Count > 0)
            {
                foreach (Control ctrl in Controlli.Controls)
                {
                    if (!CheckXSS(ctrl))
                        return false;
                }
            }

            if (Controlli.GetType().Name == "TextBox")
            {
                TextBox txt = Controlli as TextBox;
                string valore = txt.Text;
                if (!CheckXSS(ref valore))
                    return false;
                txt.Text = valore;
            }

            return true;
        }
        public static bool CheckXSS(HttpRequest richiesta)
        {
            if (richiesta != null)
            {
                for (int i = 0; i < richiesta.QueryString.Count; i++)
                {
                    if (richiesta.QueryString[i] != null && richiesta.QueryString.Keys[i] != Keys.SecureTableParams)
                    {
                        string queryString = richiesta.QueryString[i].ToString();
                        if (!CheckXSS(ref queryString))
                            return false;
                        if (queryString != richiesta.QueryString[i].ToString())
                            return false;
                    }
                }
            }
            return true;
        }
        private static bool CheckXSS(ref string valore)
        {
            try
            {
                if (valore.Contains("|") ||
                        valore.Contains("&") ||
                        valore.Contains(";") ||
                        valore.Contains("$") ||
                        valore.Contains("%") ||
                        valore.Contains("\'") ||
                        valore.Contains("\"") ||
                        valore.Contains("<") ||
                        valore.Contains(">") ||
                        valore.Contains("(") ||
                        valore.Contains(")") ||
                        valore.Contains("+") ||
                        valore.Contains("\\") ||
                        valore.Contains("<CR") ||
                        valore.Contains("<LF") ||
                        valore.Contains("CR>") ||
                        valore.Contains("LF>"))
                {
                    valore = valore.Replace("|", " ")
                    .Replace("&", " ")
                    .Replace(";", " ")
                    .Replace("$", " ")
                    .Replace("%", " ")
                    .Replace("\'", " ")
                    .Replace("\"", " ")
                    .Replace("<", " ")
                    .Replace(">", " ")
                    .Replace("(", " ")
                    .Replace(")", " ")
                    .Replace("+", " ")
                    .Replace("\\", " ")
                    .Replace("<CR", " ")
                    .Replace("<LF", " ")
                    .Replace("CR>", " ")
                    .Replace("LF>", " ");
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        #endregion
        #region Scroll
        public static void MantainScroll(Page page, bool isMaintained)
        {
            if (isMaintained || Utility.IsNoJavascript())
                page.MaintainScrollPositionOnPostBack = isMaintained;
            else
                page.ClientScript.RegisterStartupScript(page.GetType(), "scrollTopPage", "ScrollTopPage();", true);
        }
        #endregion
        #region HttpRequest
        internal static string GetCurrentPageName(HttpRequest request)
        {
            string sPath = request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }
        private static string GetBrowser(HttpRequest request)
        {
            string browser = string.Empty;
            try
            {
                browser = "Type = " + request.Browser.Type + ", "
             + "Name = " + request.Browser.Browser + ", "
             + "Version = " + request.Browser.Version + ", "
             + "Major Version = " + request.Browser.MajorVersion + ", "
             + "Minor Version = " + request.Browser.MinorVersion + ", "
             + "Platform = " + request.Browser.Platform + ", "
             + "Is Beta = " + request.Browser.Beta + ", "
             + "Is Crawler = " + request.Browser.Crawler + ", "
             + "Is AOL = " + request.Browser.AOL + ", "
             + "Is Win16 = " + request.Browser.Win16 + ", "
             + "Is Win32 = " + request.Browser.Win32 + ", "
             + "Supports Frames = " + request.Browser.Frames + ", "
             + "Supports Tables = " + request.Browser.Tables + ", "
             + "Supports Cookies = " + request.Browser.Cookies + ", "
             + "Supports VBScript = " + request.Browser.VBScript + ", "
             + "Supports JavaScript = " +
                 request.Browser.EcmaScriptVersion.ToString() + ", "
             + "Supports Java Applets = " + request.Browser.JavaApplets + ", "
             + "Supports ActiveX Controls = " + request.Browser.ActiveXControls;
            }
            catch (Exception) { }
            return browser;
        }
        #endregion
        #region Conversion
        public static string GetSI_NO(bool? value)
        {
            return value != null && value.GetValueOrDefault() ? Keys.SI : Keys.NO;
        }

        public static bool GetBoolFromSI_NO(string si_no)
        {
            return !String.IsNullOrEmpty(si_no) ? si_no == Keys.SI ? true : false : false;
        }

        #endregion
        #region AppSettings
        public static string GetValueFromAppSettings(string key)
        {
            string value = string.Empty;
            if (ConfigurationManager.AppSettings[key] != null)
                value = ConfigurationManager.AppSettings[key].ToString();
            return value;
        }
        #endregion
        #region Session
        public static bool IsSessionExpired()
        {
            bool bSessionExpired = false;
            if (string.IsNullOrEmpty(SessionHelper.GetValue(SessionKeys.SESSION_ALIVE)))
                bSessionExpired = true;

            return bSessionExpired;
        }
        #endregion

        #region Pages
        public static string GetUrl(string page)
        {
            return "~/" + Keys.PrefixPage + page + AttachJSDisabled();
        }
        private static string AttachJSDisabled()
        {
            return IsNoJavascript() ? "?jsdisabled=true" : string.Empty;
        }
        #endregion
    }

}
