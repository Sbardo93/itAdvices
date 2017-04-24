using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAdvices.Entity.Common
{
    public class Keys
    {
        public const string NO = "NO";
        public const string SI = "SI";
        public const string PrefixPage = "Pages/";
        public const string SecureTableParams = "SecureTableParams";

        public class DominioParametri
        {
            public const string OFFLINE = "OFFLINE";
        }

        public class Pages
        {
            public const string Default = "Default.aspx";
            public const string Login = "Login.aspx";
            public const string Courtesy = "Courtesy.aspx";
            public static readonly Pages DefaultPage = new Pages("HomePage", Default, "");
            public static readonly Pages LoginPage = new Pages("Login", Login, "");
            public static readonly Pages CourtesyPage = new Pages("Errore", Courtesy, "");

            public string Nome { get; private set; }
            public string Pagina { get; private set; }
            public string LivelloAuth { get; private set; }

            public Pages(string nome, string pagina, string livAuth)
            {
                Nome = nome;
                Pagina = pagina;
                LivelloAuth = livAuth;
            }
        }
    }
}
