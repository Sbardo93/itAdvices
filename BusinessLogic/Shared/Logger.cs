using System;
using System.Diagnostics;
using System.Configuration;
using log4net;


namespace BusinessLogic
{
    /// <summary>
    /// Summary description for Logger.
    /// </summary>
    public class Logger
    {
        public const string LogDefault = "Default";
        public const string LogError = "Error";
        private const string LoggerName = "ItAdvices";
        private static EventLogEntryType DefaultLogLevel = EventLogEntryType.Error;

        protected static string log_level;
        protected static string cs = string.Empty;
        protected static string connstring;

        static Logger()
        {
            //
            // TODO: Add constructor logic here
            //
            Trace.WriteLine("Logger contructor");

            connstring = ConfigurationManager.ConnectionStrings["DBLog"].ConnectionString;
            if (connstring.Length == 0)
            {
                Trace.WriteLine("Errore impostazione connection string DB LOG", CommonUtils.LOG_CATEGORY);
                return;
            }


            log4net.Config.XmlConfigurator.Configure();

            log4net.Repository.Hierarchy.Hierarchy hier =
            log4net.LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;

            if (hier != null)
            {
                //get ADONetAppender
                log4net.Appender.AdoNetAppender adoAppender =
                  (log4net.Appender.AdoNetAppender)hier.GetLogger(LoggerName,
                    hier.LoggerFactory).GetAppender("AdoNetAppender");
                if (adoAppender != null)
                {
                    adoAppender.ConnectionString =
                      connstring;
                    adoAppender.ActivateOptions(); //refresh settings of appender
                }
            }

            log_level = ConfigurationManager.AppSettings["log_level"] + "";

            try
            {
                DefaultLogLevel = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), log_level, true);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString(), CommonUtils.LOG_CATEGORY);
            }

            cs = (ConfigurationManager.AppSettings["log_cat"] + string.Empty);

        }

        private static void setData(string LogCategory)
        {
            //set user to log4net context, so we can use %X{user} in the appenders
            //if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            //    MDC.Set("user", HttpContext.Current.User.Identity.Name);
            
            string sessionid = string.Empty;
            string sessionstate = string.Empty;

            // Sono i parametri utilizzati nella log scritta su web.config
            LogicalThreadContext.Properties["sessionid"] = sessionid + string.Empty;
            LogicalThreadContext.Properties["category"] = LogCategory;
        }

        //WriteToLog(Logger.LogDefault,"Errore Print: " + ex.ToString(),System.Diagnostics.EventLogEntryType.Error);									
        public static void WriteToLog(string LogCategory, string LogMessage,
            System.Diagnostics.EventLogEntryType LogType)
        {

            log4net.ILog logger = LogManager.GetLogger(LoggerName);

            switch (LogType)
            {

                case EventLogEntryType.Error:
                    if (logger.IsErrorEnabled)
                    {
                        setData(LogCategory);
                        logger.Error(LogMessage); //now log error
                    }
                    break;
                case EventLogEntryType.Information:
                    if (logger.IsInfoEnabled)
                    {
                        setData(LogCategory);
                        logger.Info(LogMessage);
                    }
                    break;

                case EventLogEntryType.Warning:
                    if (logger.IsWarnEnabled)
                    {
                        setData(LogCategory);
                        logger.Warn(LogMessage);
                    }
                    break;

                default:
                    if (logger.IsDebugEnabled)
                    {
                        setData(LogCategory);
                        logger.Debug(LogMessage);
                    }

                    break;
            }
        }
        public static void LogException(Exception ex)
        {
            Exception tex = ex;
            int i = 0;
            while (tex != null && i <= 4)
            {
                WriteToLog(LogError, GetCurrentMethodName() + ". " + tex.ToString(), EventLogEntryType.Error);

                tex = tex.InnerException;
                i++;
            }
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static string GetCurrentMethodName()
        {
            string name = string.Empty;
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                System.Diagnostics.StackFrame sf = st.GetFrame(2);
                name = sf.GetMethod().Name;
            }
            catch (Exception)
            {
                name = "Method";
            }
            return "Exception in Method: " + name;
        }

        public static void WriteError(string p)
        {
            WriteToLog("Errore", p, EventLogEntryType.Error);
        }
    }
}
