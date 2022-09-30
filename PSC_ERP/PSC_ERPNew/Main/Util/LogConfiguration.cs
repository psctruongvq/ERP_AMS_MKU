using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main;

namespace PSC_ERPNew.Main.Util
{
    public class LogConfiguration
    {

        public static void Config()
        {
            PSC_ERP_TrackingLog.EntityTrackingTool.ConfigLog(Database.NormalConnectionString);
            ChangeLog4netCustomConnectionString(Database.NormalConnectionString);
        }
        private static void ChangeLog4netCustomConnectionString(String connectionString)
        {
            Log4netCustom.Repository.Hierarchy.Hierarchy hier = Log4netCustom.LogManager.GetLoggerRepository() as Log4netCustom.Repository.Hierarchy.Hierarchy;
            if (hier != null)
            {
                //get ADONetAppender
                Log4netCustom.Appender.IAppender[] appenders = hier.GetAppenders();
                Log4netCustom.Appender.IAppender appender = (from p in appenders where p.Name.Equals("AdoNetAppender") select p).FirstOrDefault();
                Log4netCustom.Appender.AdoNetAppender adoAppender =
    (Log4netCustom.Appender.AdoNetAppender)appender;
                if (adoAppender != null)
                {
                    adoAppender.ConnectionString = connectionString;//PSC_ERP.Entity.Info.Database.ConnectionStringForLog4net;
                    adoAppender.ActivateOptions(); //refresh settings of appender
                }
            }
        }
      
    }
}
