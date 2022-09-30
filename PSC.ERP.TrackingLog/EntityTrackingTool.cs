using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_TrackingLog
{
    public class EntityTrackingTool
    {
        private Log4netCustom2.ILog _log = null;//log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static Object SyncLock = new Object();
        public static void ConfigLog(String connectionString)
        {
            Log4netCustom2.Config.XmlConfigurator.Configure();
            ChangeConnectionString(connectionString);


        }

        public static String ConnectionString
        {
            get
            {
                return GetConnectionString();
            }

            set
            {
                ChangeConnectionString(value);
            }
        }
        #region Helper Method
        private static String GetConnectionString()
        {


            String connectionString = null;
            Log4netCustom2.Repository.Hierarchy.Hierarchy hier = Log4netCustom2.LogManager.GetLoggerRepository() as Log4netCustom2.Repository.Hierarchy.Hierarchy;
            if (hier != null)
            {
                //get ADONetAppender
                Log4netCustom2.Appender.IAppender[] appenders = hier.GetAppenders();
                Log4netCustom2.Appender.IAppender appender = (from p in appenders where p.Name.Equals("AdoNetAppender") select p).FirstOrDefault();
                Log4netCustom2.Appender.AdoNetAppender adoAppender =
    (Log4netCustom2.Appender.AdoNetAppender)appender;
                if (adoAppender != null)
                {
                    connectionString = adoAppender.ConnectionString;
                }



                //            //////
                //            Log4netCustom2.Appender.IAppender[] appendersX = hier.GetAppenders();
                //            Log4netCustom2.Appender.IAppender appenderX = (from p in appenders where p.Name.Equals("AdoNetAppenderX") select p).FirstOrDefault();
                //            Log4netCustom2.Appender.AdoNetAppender adoAppenderX =
                //(Log4netCustom2.Appender.AdoNetAppender)appender;
                //            if (adoAppender != null)
                //            {
                //                connectionString = adoAppenderX.ConnectionString;
                //            }
            }

            return connectionString;

        }
        private static void ChangeConnectionString(String connectionString)
        {
            Log4netCustom2.Repository.Hierarchy.Hierarchy hier = Log4netCustom2.LogManager.GetLoggerRepository() as Log4netCustom2.Repository.Hierarchy.Hierarchy;
            if (hier != null)
            {
                //get ADONetAppender
                Log4netCustom2.Appender.IAppender[] appenders = hier.GetAppenders();
                Log4netCustom2.Appender.IAppender appender = (from p in appenders where p.Name.Equals("AdoNetAppender") select p).FirstOrDefault();
                Log4netCustom2.Appender.AdoNetAppender adoAppender =
    (Log4netCustom2.Appender.AdoNetAppender)appender;
                if (adoAppender != null)
                {
                    adoAppender.ConnectionString = connectionString;//PSC_ERP.Entity.Info.Database.ConnectionStringForLog4net;
                    adoAppender.ActivateOptions(); //refresh settings of appender
                }
            }
        }


        #endregion
        public static void ClearAllAnotherInfo()
        {
            Log4netCustom2.MDC.Clear();
        }
        public static void RemoveAnotherInfo(AnotherTrackingLogKeys key)
        {
            String strKey = key.ToString();
            Log4netCustom2.MDC.Remove(strKey);
        }
        public static void SetAnotherInfo(AnotherTrackingLogKeys key, String value)
        {
            String strKey = key.ToString();
            Log4netCustom2.MDC.Set(strKey, value);
        }


        /// //////////////////



        #region Constructor
        public EntityTrackingTool(Type loggerType)
        {
            _log = Log4netCustom2.LogManager.GetLogger(loggerType);
        }
        public EntityTrackingTool(String loggerName)
        {
            _log = Log4netCustom2.LogManager.GetLogger(loggerName);
        }
        #endregion

        #region Log Method
        //public void Fatal(String message, String uniqueMark = null, Exception exception = null)
        //{
        //    //if (uniqueMark != null) SetAnotherInfo(AnotherLogKeys.UniqueMark, uniqueMark);
        //    //
        //    if (exception == null)
        //        this._log.Fatal(message);
        //    else this._log.Fatal(message, exception);
        //    //
        //    //if (uniqueMark != null) RemoveAnotherInfo(AnotherLogKeys.UniqueMark);
        //}
        //public void Error(String message, String uniqueMark = null, Exception exception = null)
        //{

        //    //if (uniqueMark != null) SetAnotherInfo(AnotherLogKeys.UniqueMark, uniqueMark);
        //    //
        //    if (exception == null)
        //        this._log.Error(message);
        //    else this._log.Error(message, exception);
        //    //
        //    //if (uniqueMark != null) RemoveAnotherInfo(AnotherLogKeys.UniqueMark);
        //}
        //public void Warn(String message, String uniqueMark = null, Exception exception = null)
        //{
        //    //if (uniqueMark != null) SetAnotherInfo(AnotherLogKeys.UniqueMark, uniqueMark);
        //    //
        //    if (exception == null)
        //        this._log.Warn(message);
        //    else this._log.Warn(message, exception);
        //    //
        //    //if (uniqueMark == null) RemoveAnotherInfo(AnotherLogKeys.UniqueMark);
        //}

        //public void Info(String message, Int32 UserID, Exception exception = null)
        //{
        //    SetAnotherInfo(AnotherLogKeys.UserID, UserID.ToString());
        //    //if (uniqueMark != null) SetAnotherInfo(AnotherLogKeys.UniqueMark, uniqueMark);
        //    //
        //    if (exception == null)
        //        this._log.Info(message);
        //    else this._log.Info(message, exception);
        //    //
        //    RemoveAnotherInfo(AnotherLogKeys.UserID);
        //    //if (uniqueMark != null) RemoveAnotherInfo(AnotherLogKeys.UniqueMark);
        //}
        public void EntityTracking(String businessCode, String message, Int32 UserID, String entityKeys, String currentPropertyValues, String oldPropertyValues, String newPropertyValues, String logType, String entitySet, String objectSet, String userNetworkIP, Exception exception = null)
        {
            lock (SyncLock)
            {
                //Log4netCustom2.GlobalContext.Properties["MyColumn"] = "MyValue";
                //Log4netCustom2.ThreadContext.Properties["MyColumn"] = "MyValue";

                //Log4netCustom2.NDC.Push("hihihehe");//Log4netCustom2.ThreadContext.Stacks["NDC"].Push("hihihehe");
                //Log4netCustom2.NDC.Push("huhuhichic");

                //using(new AutoTrackingLogProperty("MyColumn","day la gia tri"))
                {
                    //AutoTrackingLogProperty custom = new KeyValuePair<String, String>("MyColumn", "day la gi tri xx");

                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.UserID, UserID.ToString());
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.EntityKeys, entityKeys);
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.CurrentPropertyValues, currentPropertyValues);
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.OldPropertyValues, oldPropertyValues);
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.NewPropertyValues, newPropertyValues);
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.LogType, logType);
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.EntitySet, entitySet);
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.ObjectSet, objectSet);
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.UserNetworkIP, userNetworkIP);
                    new AutoTrackingLogMDC(AnotherTrackingLogKeys.BusinessCode, businessCode);

                    //if (UserID != 0) SetAnotherInfo(AnotherTrackingLogKeys.UserID, UserID.ToString());
                    //if (entityKeys != null) SetAnotherInfo(AnotherTrackingLogKeys.EntityKeys, entityKeys);
                    //if (currentPropertyValues != null) SetAnotherInfo(AnotherTrackingLogKeys.CurrentPropertyValues, currentPropertyValues);
                    //if (oldPropertyValues != null) SetAnotherInfo(AnotherTrackingLogKeys.OldPropertyValues, oldPropertyValues);
                    //if (newPropertyValues != null) SetAnotherInfo(AnotherTrackingLogKeys.NewPropertyValues, newPropertyValues);
                    //if (logType != null) SetAnotherInfo(AnotherTrackingLogKeys.LogType, logType);
                    //if (entitySet != null) SetAnotherInfo(AnotherTrackingLogKeys.EntitySet, entitySet);
                    //if (objectSet != null) SetAnotherInfo(AnotherTrackingLogKeys.ObjectSet, objectSet);
                    //if (userNetworkIP != null) SetAnotherInfo(AnotherTrackingLogKeys.UserNetworkIP, userNetworkIP);

                    //if (uniqueMark != null) SetAnotherInfo(AnotherLogKeys.UniqueMark, uniqueMark);
                    //

                    //ghi log
                    if (exception == null)
                        this._log.Info(message);
                    else this._log.Info(message, exception);
                    //
                    //if (UserID != 0) RemoveAnotherInfo(AnotherTrackingLogKeys.UserID);
                    //if (entityKeys != null) RemoveAnotherInfo(AnotherTrackingLogKeys.EntityKeys);
                    //if (currentPropertyValues != null) RemoveAnotherInfo(AnotherTrackingLogKeys.CurrentPropertyValues);
                    //if (oldPropertyValues != null) RemoveAnotherInfo(AnotherTrackingLogKeys.OldPropertyValues);
                    //if (newPropertyValues != null) RemoveAnotherInfo(AnotherTrackingLogKeys.NewPropertyValues);
                    //if (logType != null) RemoveAnotherInfo(AnotherTrackingLogKeys.LogType);
                    //if (entitySet != null) RemoveAnotherInfo(AnotherTrackingLogKeys.EntitySet);
                    //if (objectSet != null) RemoveAnotherInfo(AnotherTrackingLogKeys.ObjectSet);
                    //if (userNetworkIP != null) RemoveAnotherInfo(AnotherTrackingLogKeys.UserNetworkIP);

                    //if (uniqueMark != null) RemoveAnotherInfo(AnotherLogKeys.UniqueMark);

                }
                //Log4netCustom2.NDC.Pop();
                //Log4netCustom2.NDC.Pop();
            }
        }
        //public void Debug(String message, Exception exception = null)
        //{
        //    //if (uniqueMark != null) SetAnotherInfo(AnotherLogKeys.UniqueMark, uniqueMark);
        //    //
        //    if (exception == null)
        //        this._log.Debug(message);
        //    else this._log.Debug(message, exception);
        //    //
        //    //if (uniqueMark != null) RemoveAnotherInfo(AnotherLogKeys.UniqueMark);
        //}


        #endregion


    }
}
