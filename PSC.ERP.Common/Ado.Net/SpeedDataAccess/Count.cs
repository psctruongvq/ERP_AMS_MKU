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
        /// Counts the records.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="fillter">The fillter.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public Int64 CountRecords(String tableName, string fillter = "", String preCommandText = "")
        {
            if (fillter == "" && tableName == "")
            {
                throw new Exception("commandText and tableName are Empty");
            }
            // The SqlConnection class allows you to communicate with SQL Server.
            //SqlConnection sqlConn = new SqlConnection(m_strConn);
            String commandText = "select count(*) as [count] from " + tableName;
            if (fillter != string.Empty)
            {
                //fillter = fillter.Replace("where ", "");
                //fillter = fillter.Replace("Where ", "");
                //fillter = fillter.Replace("WHERE ", "");
                commandText += " where " + fillter;
            }
            // Create integer variable for checking executing result.
            Int64 intRows = -1;
            try
            {
                ///////////
                DataTable tmpTable = this.GetListByCommandText(commandText, tableName, preCommandText);
                // Execute [SELECT COUNT(*) FROM...] statement.
                intRows = Convert.ToInt64(tmpTable.Rows[0]["count"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            // Return result value.
            return intRows;
        }



    }
}
