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
        /// Deletes the row.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public int DeleteRow(DataRow dataRow, string tableName, string preCommandText = "")
        {
            Boolean allowLocalTransaction = false;
            // Create integer variable for checking executing result.
            int intRows = -1;
            // The SqlConnection class allows you to communicate with SQL Server.
            ///SqlConnection sqlConn = new SqlConnection(m_strConn);

            // SQL UPDATE command text.
            string commandText = "DELETE FROM" + tableName;
            commandText = (preCommandText.CompareTo("") == 0 ? "" : preCommandText + " ") + commandText;
            //string commandText = "UPDATE " + strTableName + " SET ";
            //string strColAndValue = "";
            string where = " WHERE (";
            string[] primaryKeys;

            try
            {
                // Get all primary-keys of this tables from DB.
                primaryKeys = Schema.PrimaryKeys(tableName);

                DbCommand dbCommand = Factory.CreateCommand(this.Provider);
                foreach (DataColumn dataColumn in dataRow.Table.Columns)
                {

                    DbParameter dbParameter = Factory.CreateParameter(this.Provider);
                    string columnName = "";
                    columnName = dataColumn.ColumnName;
                    if (dataRow[columnName] != DBNull.Value)
                    {
                        //if ((primaryKeys.IndexOf("[" + columnName + "]") >= 0))
                        if (Array.Exists(primaryKeys, s => s.Contains(columnName)))
                        {
                            // Primary Keys
                            where += "(" + Factory.ProtectName(columnName) + " = "
                                        + "@" + columnName + ") AND ";

                        }
                    }
                    // Add param and set value for it
                    dbParameter.ParameterName = "@" + columnName;
                    dbParameter.Value = dataRow[columnName];

                    dbCommand.Parameters.Add(dbParameter);
                }
                // Remove last comma and space characters
                //strColAndValue = strColAndValue.Substring(0, strColAndValue.Length - 2);
                where = where.Substring(0, where.Length - 5);

                commandText += where + ")";

                this.PrepareAll(commandText
                    , CommandType.Text
                    , command: dbCommand
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.ReadCommitted);
                // Execute Insert/Update/Delete SMS data.
                intRows = this.Command.ExecuteNonQuery();
                if (allowLocalTransaction)
                    this.CommitTransaction();
            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    this.RollbackTransaction();
                // Output Log info into file.

                throw ex;
            }
            finally
            {
                // Close connection.
                this.CloseConnection();
            }

            // Return result value.
            return intRows;
        }

        /// <summary>
        /// Deletes the row.
        /// </summary>
        /// <param name="dataGridViewRow">The data grid view row.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public int DeleteRow(DataGridViewRow dataGridViewRow, string tableName, string preCommandText = "")
        {
            Boolean allowLocalTransaction = false;
            // Create integer variable for checking executing result.
            int intRows = -1;


            // SQL DELETE command text.
            string commandText = "DELETE FROM " + tableName;
            commandText = (preCommandText.CompareTo("") == 0 ? "" : preCommandText + " ") + commandText;
            string where = " WHERE (";
            string[] primaryKeys;

            try
            {
                // Get all primary-keys of this tables from DB.
                primaryKeys = this.Schema.PrimaryKeys(tableName);
                DbCommand dbCommand = Factory.CreateCommand(this.Provider);
                // Creates the list column-value pairs for UPDATE sql sentence.
                foreach (DataGridViewColumn viewColumn in dataGridViewRow.DataGridView.Columns)
                {


                    DbParameter dbParameter = Factory.CreateParameter(this.Provider);
                    string columnName = "";
                    columnName = viewColumn.Name;
                    if (dataGridViewRow.Cells[columnName].Value != DBNull.Value)
                    {
                        //if ((primaryKeys.IndexOf("[" + columnName + "]") >= 0))
                        if (Array.Exists(primaryKeys, s => s.Contains(columnName)))
                        {

                            // Primary Keys
                            where += "(" + Factory.ProtectName(columnName) + " = "
                                        + "@" + columnName + ") AND ";

                        }
                    }
                    // Add param and set value for it
                    dbParameter.ParameterName = "@" + columnName;
                    dbParameter.Value = dataGridViewRow.Cells[columnName].Value;

                    dbCommand.Parameters.Add(dbParameter);
                }
                // Remove last comma and space characters

                where = where.Substring(0, where.Length - 5);

                commandText += where + ")";

                this.PrepareAll(commandText
                    , CommandType.Text
                    , command: dbCommand
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.ReadCommitted);
                // Execute Insert/Update/Delete SMS data.
                intRows = this.Command.ExecuteNonQuery();
                if (allowLocalTransaction)
                    this.CommitTransaction();
            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    this.RollbackTransaction();
                // Output Log info into file.

                throw ex;
            }
            finally
            {
                // Close connection.
                this.CloseConnection();
            }

            // Return result value.
            return intRows;
        }
    }
}
