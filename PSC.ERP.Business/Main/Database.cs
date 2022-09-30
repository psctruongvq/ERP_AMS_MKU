using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.EntityClient;

using System.Xml;
using System.Reflection;
using PSC_ERP_Business.Main.Model.Context;

namespace PSC_ERP_Business.Main
{
    public class Database
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly String NormalConnectionStringFormat = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}";
        private static readonly String EntityConnectionStringFormat = "metadata=res://*/Main.Model.MainModel.csdl|res://*/Main.Model.MainModel.ssdl|res://*/Main.Model.MainModel.msl;provider=System.Data.SqlClient;provider connection string='Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True'";
        public static string ServerName = null;
        public static string DatabaseName = null;
        public static string Username = null;
        public static string Password = null;

        public static Entities NewEntities()
        {
            Entities context = new Entities(EntityConnectionString);
            context.CommandTimeout = 60 * 10;
            return context;
        }
        private static String _entityConnectionString = null;
        private static String _normalConnectionString = null;
        public static String NormalConnectionString
        {
            get
            {
                GetConnectionString();
                return _normalConnectionString;
            }
        }
        private static string EntityConnectionString
        {
            get
            {
                //return "metadata=res://*;"

                //        + "provider=System.Data.SqlClient;"

                //        + "provider connection string='"

                //        + "Data Source=ADMIN-PC;Initial Catalog=PSC_ERP;"

                //        + "Persist Security Info=True;"

                //        + "User ID=sa;Password=123;"

                //        + "MultipleActiveResultSets=True'";


                GetConnectionString();

                return _entityConnectionString;
            }
        }

        private static void GetConnectionString()
        {
            if (String.IsNullOrWhiteSpace(_entityConnectionString))
            {
                Boolean standAloneSolution = false;
                if (standAloneSolution)
                {
                    PSC_ERP_Util.XML.EasyXml xmlTool = new PSC_ERP_Util.XML.EasyXml();
                    xmlTool.LoadFile(Assembly.GetExecutingAssembly().GetName().Name + ".dll.config");
                    XmlNode node = xmlTool.SelectSingleNode("/configuration/connectionStrings/add[@name='Entities']");
                    String connectionString = node.Attributes["connectionString"].Value;
                    _entityConnectionString = connectionString;
                    ///////////////////////////////////////

                    String[] somePartsOfConnectionString = connectionString.Split(';');
                    String prefixDataSource = "provider connection string=\"Data Source=";
                    String prefixInitialCatalog = "Initial Catalog=";
                    String prefixUserID = "User ID=";
                    String prefixPassword = "Password=";
                    ServerName = (from s in somePartsOfConnectionString where s.StartsWith(prefixDataSource) select s).Single().Replace(prefixDataSource, "");
                    DatabaseName = (from s in somePartsOfConnectionString where s.StartsWith(prefixInitialCatalog) select s).Single().Replace(prefixInitialCatalog, "");
                    Username = (from s in somePartsOfConnectionString where s.StartsWith(prefixUserID) select s).Single().Replace(prefixUserID, "");
                    Password = (from s in somePartsOfConnectionString where s.StartsWith(prefixPassword) select s).Single().Replace(prefixPassword, "");

                    _normalConnectionString = String.Format(NormalConnectionStringFormat, ServerName, DatabaseName, Username, Password);

                }
                else
                {
                    _normalConnectionString = ERP_Library.Database.ERP_Connection;
                    //Data Source=SERVERERP1\SQL2008;Initial Catalog=ERP_HTV;Persist Security Info=True;User ID=sa;Password=pscvietnam
                    String[] somePartsOfConnectionString = _normalConnectionString.Split(';');
                    String prefixDataSource = "Data Source=";
                    String prefixInitialCatalog = "Initial Catalog=";
                    String prefixUserID = "User ID=";
                    String prefixPassword = "Password=";
                    ServerName = (from s in somePartsOfConnectionString where s.ToLower().StartsWith(prefixDataSource.ToLower(), StringComparison.Ordinal) select s).Single().Replace(prefixDataSource, "");
                    DatabaseName = (from s in somePartsOfConnectionString where s.ToLower().StartsWith(prefixInitialCatalog.ToLower(), StringComparison.Ordinal) select s).Single().Replace(prefixInitialCatalog, "");
                    Username = (from s in somePartsOfConnectionString where s.ToLower().StartsWith(prefixUserID.ToLower(), StringComparison.Ordinal) select s).Single().Replace(prefixUserID, "");
                    Password = (from s in somePartsOfConnectionString where s.ToLower().StartsWith(prefixPassword.ToLower(), StringComparison.Ordinal) select s).Single().Replace(prefixPassword, "");

                    _entityConnectionString = String.Format(EntityConnectionStringFormat, ServerName, DatabaseName, Username, Password);
                }
                //
                PSC_ERP_Global.Main.NormalConnectionString = _normalConnectionString;
            }
        }

    }
}
