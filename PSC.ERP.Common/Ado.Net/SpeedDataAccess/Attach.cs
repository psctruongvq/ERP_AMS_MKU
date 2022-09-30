using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace PSC_ERP_Common.Ado.Net
{
    public partial class SpeedDataAccess
    {
        /// <summary>
        /// Exists the data base.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns></returns>
        public bool ExistsDataBase(string databaseName)
        {
            string commandText = String.Format("DECLARE @return_value int if EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'{0}') set @return_value =1 else set @return_value =0 select @return_value", databaseName);
            object obj = this.ExecuteScalar(commandText);
            if (obj != Convert.DBNull && Convert.ToInt32(obj) == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Attaches the specified MDF file.
        /// </summary>
        /// <param name="mdfFile">The MDF file.</param>
        /// <param name="ldfFile">The LDF file.</param>
        /// <param name="database">The database.</param>
        /// <returns></returns>
        public bool Attach(string mdfFile, string ldfFile, string database)
        {

            if (!this.ExistsDataBase(database))
            {
                string commandText = string.Concat(new string[]
		{
			"EXEC sp_attach_db @dbname = N'", 
			database, 
			"',@filename1 = N'", 
			mdfFile, 
			"',@filename2 = N'", 
			ldfFile, 
			"'"
		});
                this.ExecuteNonQuery(commandText);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deattaches the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns></returns>
        public bool Deattach(string database)
        {

            if (this.ExistsDataBase(database))
            {
                string commandText = string.Concat(new string[]
		                                            {
					                                            "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'", 
			                                            database, 
			                                            "') BEGIN  EXEC sp_detach_db @dbname = N'", 
			                                            database, 
			                                            "' END "
		                                            });
                this.ExecuteNonQuery(commandText);
                return true;
            }
            return false;
        }

    }
}
