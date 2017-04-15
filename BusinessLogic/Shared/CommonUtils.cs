using System;
using System.Globalization;
using System.Net.Mail;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;

namespace ITAdvices.BusinessLogic
{
    /// <summary>
    /// Summary description for CommonUtils.
    /// </summary>
    public class CommonConstants
	{
    }

    public class CommonEnums
    {
        public enum TipoErrore { OK, KO, Warning, Info };

        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public enum Courtesy
        {
            Default,
            SessioneScaduta,
            SessioneDuplicata
        }

        public enum FormatoData
        {
            [Description("dd/MM/yyyy")]
            DDmmYYYY,
            [Description("MM/yyyy")]
            mmYYYY,
            [Description("yyyy/MM/dd")]
            YYYYmmDD
        }

        public enum Data
        {
            Empty,
            DataGenerica,
            DataFutura
        }

        public enum DisplayStyle
        {
            [Description("block")]
            Block,
            [Description("none")]
            None,
        }

        public enum PulsantiFullScreen
        {
            NESSUNO = 0,
            OK,
            ANNULLA_CONFERMA
        }
    }

    public class CommonKeys
    {
    }
}
