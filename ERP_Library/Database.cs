using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using ERP_Library;
using System.Data;
using System.Data.SqlClient;
//Along test TFS

namespace ERP_Library
{
    //ttttvvv
    public static class Database
    {

        static int number;
        static string databaseName = "ERP_HTV";
        static string DatabaseName_Digital = "ERP_HTV_Digital";
        public static string ServerName = null;
        public static string DatabaseName = null;
        public static string Username = null;
        public static string Password = null;
        //static string databaseName = "NSG";    
        private static String _entityConnectionString = null;
        private static String _normalConnectionString = null;
        private static readonly String NormalConnectionStringFormat = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}";
        private static readonly String EntityConnectionStringFormat = "metadata=res://*/Main.Model.MainModel.csdl|res://*/Main.Model.MainModel.ssdl|res://*/Main.Model.MainModel.msl;provider=System.Data.SqlClient;provider connection string='Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True'";
        public static string ERP_Connection
        {
            get
            {
                ServerName = Security_GetConFig.DecryptString(AppSettingUtil.GetAppSettingKey(Security_GetConFig.ServerKey));
                DatabaseName = Security_GetConFig.DecryptString(AppSettingUtil.GetAppSettingKey(Security_GetConFig.DatabaseNameKey));
                Username = Security_GetConFig.DecryptString(AppSettingUtil.GetAppSettingKey(Security_GetConFig.UsernameKey));
                Password = Security_GetConFig.DecryptString(AppSettingUtil.GetAppSettingKey(Security_GetConFig.PasswordKey));
                _entityConnectionString = String.Format(EntityConnectionStringFormat, ServerName, DatabaseName, Username, Password);
                _normalConnectionString = String.Format(NormalConnectionStringFormat, ServerName, DatabaseName, Username, Password);
                return _normalConnectionString;
                    //ConfigurationManager.ConnectionStrings["PSC_ERP.Properties.Settings.HTVConnection"].ConnectionString;
            }
        }

        public static string ERP_Connection_Digital
        {
            get
            {
                //return ConfigurationManager.ConnectionStrings
                //  ["PSC_ERP.Properties.Settings.HTVConnection_Digital"].ConnectionString;
                return ConfigurationManager.ConnectionStrings
                  ["PSC_ERP.Properties.Settings.HTVConnection"].ConnectionString;
            }
        }

        public static string SecurityConnection
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["Security"].ConnectionString; }
        }

        public static string TenMayChoReport
        {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["TenMayChoReport"].ConnectionString; }
        }
      
        //public static string ERP_Connection
        //{   
        //    //get
        //    //{
        //    //  //  return "Data Source=ServerTaiChinh;Initial Catalog=" + databaseName + ";User ID=sa;password=admin123";
        //    //  //   return "Data Source=OANH\\NSG;Initial Catalog=" + databaseName + ";User ID=sa;password=pscvietnam";
        //    //    return "Data Source=ERP-PC;Initial Catalog=" + databaseName + ";Integrated Security=SSPI;Connection Timeout=0 ;User ID=sa;password=pscvietnam";
        //    //  //  return "Data Source=ServerERP;Initial Catalog=" + databaseName + ";User ID=sa;password=pscvietnam";
        //    //}

        
        // }

        //public static string ERP_Connection_Digital
        //{
        //    get
        //    {
        //       // return "Data Source=ServerTaiChinh;Initial Catalog=" + databaseName + "; Integrated Security=SSPI;Connection Timeout=0;User ID=sa;password=admin123";
        //        // return "Data Source=OANH\\NSG;Initial Catalog=" + databaseName + ";User ID=sa;password=pscvietnam";
        //        //return "Data Source=ServerTaiChinh;Initial Catalog=" + DatabaseName_Digital + ";User ID=sa;password=admin123";
        //        return "Data Source=ERP-PC;Initial Catalog=" + DatabaseName_Digital + ";User ID=sa;password=pscvietnam";
        //    }
        //}

        /// <summary>
        /// Lay so cua Database; 1: PSC_ERPHTV; 18:PSC_ERPTTDV ; 22: ERP_HTVTFS; 26: ERP_HTVHTVC
        /// </summary>
        public static int DatabaseNumber
        {

            get
            { 
                if (databaseName == "PSC_ERPHTV")
                {
                    number = 1;//PSC_ERPHTV  
                }
                else if (databaseName == "PSC_ERPTTDV")
                {
                    number = 18;//PSC_ERPTTDV
                }
                else if (databaseName == "ERP_HTVTFS")
                {
                    number = 22;//ERP_HTVTFS
                }
                else if (databaseName == "ERP_HTVHTVC")
                {
                    number = 26;//ERP_HTVHTVC
                }
                return number;
            }
        }

        //public static string SecurityConnection
        //{
        //    get { return System.Configuration.ConfigurationManager.ConnectionStrings["Security"].ConnectionString; }
        //}

        //public static string TenMayChoReport
        //{
        //    get { return System.Configuration.ConfigurationManager.ConnectionStrings["TenMayChoReport"].ConnectionString; }
        //}



    }
}
