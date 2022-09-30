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
        /// Fills the data set.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="parameters">The parameters.</param>
        public void FillDataSet(ref DataSet dataSet, string commandText, CommandType commandType
            , String tableName, DbParameter[] parameters = null)
        {
            Boolean allowLocalTransaction = false;
            try
            {
                this.PrepareAll(commandText
                    , commandType
                    , command: null
                    , parametersWithValue: parameters
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.RepeatableRead);
                this._dataAdapter = Factory.CreateDataAdapter(this.Provider, this.Command);
                this._dataAdapter.Fill(dataSet, tableName);
                if (allowLocalTransaction)
                    this.CommitTransaction();
            }
            catch (Exception ex)
            {
                if (allowLocalTransaction)
                    this.RollbackTransaction();
            }
            finally
            {
                this.CloseConnection();
            }
        }
        /// <summary>
        /// Fills the data set.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <param name="dataSet">The table name.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public void FillDataSet(ref DataSet dataSet, string tableName, string procedureName, string parametersInput,
                    params  object[] parameterValues)
        {
            Boolean allowLocalTransaction = false;
            try
            {
                parametersInput = parametersInput.Replace(" ", "");

                DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                DbParameter[] mainParameters = null;
                if (parametersInput != "" && parameterValues != null)
                {
                    mainParameters = Factory.CreateParameters(this.Provider, parameterValues.Length);
                    DetermineUsefullParameters(ref mainParameters, parametersInput, cacheParameters);
                    AssignParameterValues(ref mainParameters, parameterValues);
                }
                this.PrepareAll(procedureName
                    , CommandType.StoredProcedure
                    , command: null
                    , parametersWithValue: mainParameters
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.RepeatableRead);
                DbDataAdapter dataAdapter = Factory.CreateDataAdapter(this.Provider);
                dataAdapter.SelectCommand = this.Command;
                //
                if (String.IsNullOrWhiteSpace(tableName))
                    dataAdapter.Fill(dataSet);
                else
                    dataAdapter.Fill(dataSet, tableName);
                //
                if (allowLocalTransaction)
                    this.CommitTransaction();//hoan tat giao tac

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

        }
        /// <summary>
        /// Fills the data table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public void FillDataTable(out DataTable table, string procedureName, string parametersInput,
            params  object[] parameterValues)
        {
            Boolean allowLocalTransaction = false;
            try
            {

                parametersInput = parametersInput.Replace(" ", "");
                DataSet ds = new DataSet();
                DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                DbParameter[] mainParameters = null;
                if (parametersInput != "" && parameterValues != null)
                {
                    mainParameters = Factory.CreateParameters(this.Provider, parameterValues.Length);
                    DetermineUsefullParameters(ref mainParameters, parametersInput, cacheParameters);
                    AssignParameterValues(ref mainParameters, parameterValues);
                }
                this.PrepareAll(procedureName
                    , CommandType.StoredProcedure
                    , command: null
                    , parametersWithValue: mainParameters
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.RepeatableRead);
                DbDataAdapter dataAdapter = Factory.CreateDataAdapter(this.Provider);
                dataAdapter.SelectCommand = this.Command;
                dataAdapter.Fill(ds);
                if (allowLocalTransaction)
                    this.CommitTransaction();//hoan tat giao tac
                table = ds.Tables[0];
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

        }
        /// <summary>
        /// Fills the data table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="preCommandText">The pre command text.</param>
        public void FillDataTable(out DataTable table, string commandText, string tableName, string preCommandText = "")
        {//ham co ban
            DataTable tmpTable = null;
            Boolean allowLocalTransaction = false;
            if (commandText != "")
            {
                if (tableName != "")
                {

                    // Create DataSet object.
                    DataSet dsData = new DataSet();
                    //"Set DateFormat DMY "
                    commandText = (preCommandText.CompareTo("") == 0 ? "" : preCommandText + " ") + commandText;
                    try
                    {
                        this.PrepareAll(commandText
                            , CommandType.Text
                            , initTransaction: allowLocalTransaction
                            , isolationLevel: IsolationLevel.RepeatableRead);
                        // A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
                        _dataAdapter = Factory.CreateDataAdapter(this.Provider, this.Command);

                        // Create a new DataSet and fill its first DataTable.
                        dsData = new DataSet();
                        // Set data from DB into DataSet object.
                        _dataAdapter.Fill(dsData, tableName);
                        if (allowLocalTransaction)
                            this.CommitTransaction();
                        // Set data from DataSet to DataTable
                        if (tableName == "")
                        {
                            tmpTable = dsData.Tables[0];
                        }
                        else
                        {
                            tmpTable = dsData.Tables[tableName];
                        }
                        //objOutLog.WriteError("CommandText = " + strCmdText + "\r\n" + strLogPath, strLogPath);
                    }
                    catch (Exception ex)
                    {
                        if (allowLocalTransaction)
                            this.RollbackTransaction();
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                }
                else
                {
                    throw new Exception("tableName is Empty");
                }
            }
            else
            {
                throw new Exception("commandText is Empty");
            }

            table = tmpTable;
        }

    }
}
