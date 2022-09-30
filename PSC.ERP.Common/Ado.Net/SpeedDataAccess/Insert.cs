using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
namespace PSC_ERP_Common.Ado.Net
{
    public partial class SpeedDataAccess
    {
        /// <summary>
        /// Inserts the row.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public Object InsertRow(DataRow dataRow, string tableName, String preCommandText = "")
        {
            Boolean allowLocalTransaction = false;
            // Create object variable for checking executing result.
            Object valueOfFirstColumnOfFirstRow = null;


            //Insert command text.
            string commandText;
            if (preCommandText != "")
                commandText = String.Format("{0} INSERT INTO {1}(", preCommandText, Factory.ProtectName(tableName));
            else
                commandText = String.Format("INSERT INTO {0}(", Factory.ProtectName(tableName));
            string columnNames = "";
            string values = "";
            //string where = " WHERE (";
            string[] primaryKeys;

            try
            {
                // Get all primary-keys of this tables from DB.
                primaryKeys = Schema.PrimaryKeys(tableName);
                // A DbCommand object is used to execute the SQL commands.
                DbCommand dbCommand = Factory.CreateCommand(Provider);
                foreach (DataColumn dataColumn in dataRow.Table.Columns)
                {
                    DbParameter dbParameter = Factory.CreateParameter(Provider);
                    string columnName = "";
                    columnName = dataColumn.ColumnName;
                    if (dataRow[columnName] != DBNull.Value)
                    {
                        columnNames += Factory.ProtectName(columnName) + ", ";
                        values += String.Format("@{0}, ", columnName);

                    }
                    // Add param and set value for it
                    dbParameter.ParameterName = "@" + columnName;
                    dbParameter.Value = dataRow[columnName];

                    dbCommand.Parameters.Add(dbParameter);
                }
                // Remove last comma and space characters
                columnNames = columnNames.Substring(0, columnNames.Length - 2);
                values = values.Substring(0, values.Length - 2);


                commandText += String.Format("{0}) VALUES({1})", columnNames, values);

                PrepareAll(commandText, CommandType.Text, command: dbCommand, initTransaction: allowLocalTransaction);


                // Execute Insert/Update/Delete SMS data.
                valueOfFirstColumnOfFirstRow = Command.ExecuteScalar();
                if (allowLocalTransaction)
                    CommitTransaction();
            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    RollbackTransaction();
                // Output Log info into file.

                throw ex;
            }
            finally
            {
                // Close connection.
                CloseConnection();
            }

            // Return result value.
            return valueOfFirstColumnOfFirstRow;
        }
        /// <summary>
        /// Inserts the row.
        /// </summary>
        /// <param name="dataGridViewRow">The data grid view row.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public Object InsertRow(DataGridViewRow dataGridViewRow, string tableName, String preCommandText = "")
        {
            Boolean allowLocalTransaction = false;
            // Create object variable for checking executing result.
            Object valueOfFirstColumnOfFirstRow = null;


            // Insert command text.
            string commandText;
            if (preCommandText != "")
                commandText = String.Format("{0} {1}", preCommandText, String.Format("INSERT INTO {0}(", tableName));
            else
                commandText = String.Format("INSERT INTO {0}(", tableName);
            string columnNames = "";
            string values = "";
            //string where = " WHERE (";
            string[] primaryKeys;

            try
            {
                // Get all primary-keys of this tables from DB.
                primaryKeys = Schema.PrimaryKeys(tableName);
                // A SqlCommand object is used to execute the SQL commands.
                DbCommand dbCommand = Factory.CreateCommand(Provider);
                foreach (DataGridViewColumn viewColumn in dataGridViewRow.DataGridView.Columns)
                {
                    DbParameter dbParameter = Factory.CreateParameter(Provider);
                    string columnName = "";
                    columnName = viewColumn.Name;
                    if (dataGridViewRow.Cells[columnName].Value != DBNull.Value)
                    {
                        columnNames += Factory.ProtectName(columnName) + ", ";
                        values += String.Format("@{0}, ", columnName);

                    }
                    // Add param and set value for it
                    dbParameter.ParameterName = "@" + columnName;
                    dbParameter.Value = dataGridViewRow.Cells[columnName].Value;

                    dbCommand.Parameters.Add(dbParameter);
                }
                // Remove last comma and space characters
                columnNames = columnNames.Substring(0, columnNames.Length - 2);
                values = values.Substring(0, values.Length - 2);


                commandText += String.Format("{0}) VALUES({1})", columnNames, values);

                PrepareAll(commandText, CommandType.Text, command: dbCommand, initTransaction: allowLocalTransaction);


                // Execute Insert/Update/Delete SMS data.
                valueOfFirstColumnOfFirstRow = Command.ExecuteScalar();
                if (allowLocalTransaction)
                    CommitTransaction();

            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    RollbackTransaction();

                throw ex;
            }
            finally
            {
                // Close connection.
                CloseConnection();
            }

            // Return result value.
            return valueOfFirstColumnOfFirstRow;
        }
    }
}
