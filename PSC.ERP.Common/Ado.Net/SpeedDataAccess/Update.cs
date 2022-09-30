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
        /// Updates the date table using command builder.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public bool UpdateDateTableUsingCommandBuilder(DataTable dataTable, String tableName)
        {//pass
            bool returnValue = false;
            DataRow[] rows = new DataRow[dataTable.Rows.Count];
            dataTable.Rows.CopyTo(rows, 0);

            returnValue = this.UpdateDateRowsUsingCommandBuilder(rows, tableName);
            return returnValue;
        }
        /// <summary>
        /// Updates the date rows using command builder.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public bool UpdateDateRowsUsingCommandBuilder(DataRow[] dataRows, String tableName)
        {//pass
            bool returnValue = false;
            Boolean allowLocalTransaction = false;
            try
            {
                this._dataAdapter = Factory.CreateDataAdapter(this.Provider);
                DbCommandBuilder builder = Factory.CreateCommandBuilder(this.Provider, ref this._dataAdapter);
                this.OpenConnection();
                this._dataAdapter.SelectCommand = Factory.CreateCommand("select * from " + tableName, CommandType.Text, this.CommandTimeout, this.Provider);
                this._dataAdapter.SelectCommand.Connection = this.Connection;
                if (allowLocalTransaction)
                    this.BeginTransaction(IsolationLevel.ReadCommitted);
                this._dataAdapter.SelectCommand.Transaction = this._trans;
                this._dataAdapter.Update(dataRows);
                if (allowLocalTransaction)
                    this.CommitTransaction();
                returnValue = true;
            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    this.RollbackTransaction();
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
            return returnValue;
        }

        /// <summary>
        /// Updates all table from data set using command builder.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <returns></returns>
        public bool UpdateAllTableFromDataSetUsingCommandBuilder(DataSet dataSet)
        {//pass
            bool returnValue = false;
            Boolean allowLocalTransaction = false;
            try
            {
                this._dataAdapter = Factory.CreateDataAdapter(this.Provider);
                DbCommandBuilder builder = Factory.CreateCommandBuilder(this.Provider, ref this._dataAdapter);
                this.OpenConnection();

                foreach (DataTable table in dataSet.Tables)
                {
                    this._dataAdapter.SelectCommand = Factory.CreateCommand("select * from " + table.TableName, CommandType.Text, this.CommandTimeout, this.Provider, parameters: null);
                    this._dataAdapter.SelectCommand.Connection = this.Connection;
                    if (allowLocalTransaction)
                        this.BeginTransaction(IsolationLevel.ReadCommitted);
                    this._dataAdapter.SelectCommand.Transaction = this._trans;
                    this._dataAdapter.Update(dataSet, table.TableName);
                    if (allowLocalTransaction)
                        this.CommitTransaction();
                }

                returnValue = true;
            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    this.RollbackTransaction();
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
            return returnValue;
        }
        /// <summary>
        /// Updates the table from data set using command builder.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public bool UpdateTableFromDataSetUsingCommandBuilder(DataSet dataSet, string tableName)
        {//pass
            bool returnValue = false;
            Boolean allowLocalTransaction = false;
            try
            {
                this._dataAdapter = Factory.CreateDataAdapter(this.Provider);
                DbCommandBuilder builder = Factory.CreateCommandBuilder(this.Provider, ref this._dataAdapter);
                this.OpenConnection();

                this._dataAdapter.SelectCommand = Factory.CreateCommand("select * from " + tableName, CommandType.Text, this.CommandTimeout, this.Provider, parameters: null);
                this._dataAdapter.SelectCommand.Connection = this.Connection;
                if (allowLocalTransaction)
                    this.BeginTransaction(IsolationLevel.ReadCommitted);
                this._dataAdapter.SelectCommand.Transaction = this._trans;
                this._dataAdapter.Update(dataSet, tableName);
                if (allowLocalTransaction)
                    this.CommitTransaction();
                returnValue = true;
            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    this.RollbackTransaction();
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
            return returnValue;
        }
        /// <summary>
        /// Updates the row.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public int UpdateRow(DataRow dataRow, string tableName, string preCommandText = "")
        {
            Boolean allowLocalTransaction = false;
            // Create integer variable for checking executing result.
            int intRows = -1;
            // The SqlConnection class allows you to communicate with SQL Server.
            ///SqlConnection sqlConn = new SqlConnection(m_strConn);

            // SQL UPDATE command text.
            string commandText = String.Format("UPDATE {0} SET ", Factory.ProtectName(tableName));
            commandText = (preCommandText.CompareTo("") == 0 ? "" : preCommandText + " ") + commandText;
            //string commandText = "UPDATE " + strTableName + " SET ";
            string strColAndValue = "";
            string where = "WHERE (";
            string[] primaryKeys;
            try
            {
                // Get all primary-keys of this tables from DB.
                primaryKeys = this.Schema.PrimaryKeys(tableName);
                // A SqlCommand object is used to execute the SQL commands.
                DbCommand dbCommand = Factory.CreateCommand(this.Provider);
                foreach (DataColumn dataColumn in dataRow.Table.Columns)
                {

                    DbParameter dbParameter = Factory.CreateParameter(this.Provider);
                    string columnName = "";
                    columnName = dataColumn.ColumnName;
                    if (dataRow[columnName] != DBNull.Value)
                    {
                        //if (!(strPrimaryKeys.IndexOf("[" + strColName + "]") >= 0))
                        if (!Array.Exists(primaryKeys, s => s.Contains(columnName)))
                        {
                            // Normal columns
                            strColAndValue += Factory.ProtectName(columnName) + " = "
                                        + "@" + columnName + ", ";

                        }
                        else
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
                strColAndValue = strColAndValue.Substring(0, strColAndValue.Length - 2);
                where = where.Substring(0, where.Length - 5);

                commandText += String.Format("{0} {1})", strColAndValue, where);

                this.PrepareAll(commandText, CommandType.Text, command: dbCommand, initTransaction: allowLocalTransaction);

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
        /// Updates the row.
        /// </summary>
        /// <param name="dataGridViewRow">The data grid view row.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public int UpdateRow(DataGridViewRow dataGridViewRow, string tableName, string preCommandText = "")
        {
            Boolean allowLocalTransaction = false;
            // Create integer variable for checking executing result.
            int intRows = -1;

            // SQL UPDATE command text.
            string commandText = String.Format("UPDATE {0} SET ", tableName);
            commandText = (preCommandText.CompareTo("") == 0 ? "" : preCommandText + " ") + commandText;
            //string commandText = "UPDATE " + strTableName + " SET ";
            string strColAndValue = "";
            string where = "WHERE (";
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
                        //if (!(strPrimaryKeys.IndexOf("[" + strColName + "]") >= 0))
                        if (!Array.Exists(primaryKeys, s => s.Contains(columnName)))
                        {
                            // Normal columns
                            strColAndValue += Factory.ProtectName(columnName) + " = "
                                        + "@" + columnName + ", ";
                        }
                        else
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
                strColAndValue = strColAndValue.Substring(0, strColAndValue.Length - 2);
                where = where.Substring(0, where.Length - 5);
                commandText += String.Format("{0} {1})", strColAndValue, where);
                this.PrepareAll(commandText, CommandType.Text, command: dbCommand, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                // Execute Insert/Update/Delete data.
                intRows = this.Command.ExecuteNonQuery();
                if (allowLocalTransaction)
                    this.CommitTransaction();
            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    this.RollbackTransaction();
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
            return intRows;
        }
    }
}
