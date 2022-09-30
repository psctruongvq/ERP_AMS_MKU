using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using System.Collections;
namespace PSC_ERP_Common.Ado.Net
{
    public partial class SpeedDataAccess
    {
        /// <summary>
        /// Gets the DB server date time.
        /// </summary>
        /// <returns></returns>
        public DateTime GetDBServerDateTime()
        {
            try
            {
                return Convert.ToDateTime(this.ExecuteScalar(Factory.GetDBServerDateTimeCommandText(this.Provider)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Gets the data columns.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public DataColumn[] GetDataColumns(String tableName)
        {
            DataColumn[] dataColumns = null;
            DataTable table = this.GetListByCommandText("select top 1 * from " + tableName, tableName);
            table.Columns.CopyTo(dataColumns, 0);

            return dataColumns;
        }
        /// <summary>
        /// Gets the data column colection.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public DataColumnCollection GetDataColumnColection(String tableName)
        {
            DataColumnCollection colection = null;
            DataTable table = this.GetListByCommandText("select top 1 * from " + tableName, tableName);
            colection = table.Columns;

            return colection;
        }

        /// <summary>
        /// Gets the list by store procedure.
        /// </summary>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public DataTable GetListByStoreProcedure(String procedureName, string parametersInput,
                    params  object[] parametersValue)
        {
            Boolean allowLocalTransaction = false;
            try
            {
                parametersInput = parametersInput.Replace(" ", "");
                DataSet ds = new DataSet();
                DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                DbParameter[] mainParameters = null;
                if (parametersInput != "" && parametersValue != null)
                {
                    char[] splitChars = { ',' };
                    string[] paraNames = parametersInput.Split(splitChars);
                    mainParameters = Factory.CreateParameters(this.Provider, paraNames.Length);
                    DetermineUsefullParameters(ref mainParameters, paraNames, cacheParameters);

                    AssignParameterValues(ref mainParameters, paraNames, parametersValue);
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
                return ds.Tables[0];
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
        /// Gets the list by store procedure.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public DataTable GetListByStoreProcedure(out Hashtable outPut, string procedureName, string parametersInput,
                    params  object[] parametersValue)
        {
            Boolean allowLocalTransaction = false;
            outPut = null;
            try
            {
                parametersInput = parametersInput.Replace(" ", "");
                DataSet ds = new DataSet();
                DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                DbParameter[] mainParameters = null;
                if (!String.IsNullOrEmpty(parametersInput) && parametersValue != null)
                {
                    char[] splitChars = { ',' };
                    string[] paraNames = parametersInput.Split(splitChars);
                    mainParameters = Factory.CreateParameters(this.Provider, paraNames.Length);
                    DetermineUsefullParameters(ref mainParameters, paraNames, cacheParameters);

                    AssignParameterValues(ref mainParameters, paraNames, parametersValue);
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
                this.FillValueForOutPut(outPut);
                return ds.Tables[0];
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
        //moi them vao

        /// <summary>
        /// Gets the list by store procedure.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersName">Name of the parameters.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public DataTable GetListByStoreProcedure(out Hashtable outPut, string procedureName, string[] parametersName, params  object[] parametersValue)
        {
            Boolean allowLocalTransaction = false;
            outPut = null;
            try
            {
                using (DataSet ds = new DataSet())
                {
                    DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                    DbParameter[] mainParameters = null;
                    if (parametersName != null && parametersValue != null)
                    {
                        for (int i = 0; i < parametersName.Length; i++)
                        {
                            parametersName[i] = parametersName[i].Replace("@", "");
                        }
                        mainParameters = Factory.CreateParameters(this.Provider, parametersName.Length);
                        DetermineUsefullParameters(ref mainParameters, parametersName, cacheParameters);
                        AssignParameterValues(ref mainParameters, parametersName, parametersValue);
                    }
                    this.PrepareAll(procedureName, CommandType.StoredProcedure, command: null, parametersWithValue: mainParameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.RepeatableRead);
                    DbDataAdapter dataAdapter = Factory.CreateDataAdapter(this.Provider);
                    dataAdapter.SelectCommand = this.Command;
                    dataAdapter.Fill(ds);
                    if (allowLocalTransaction)
                        this.CommitTransaction();
                    //hoan tat giao tac
                    this.FillValueForOutPut(outPut);
                    return ds.Tables[0];
                }
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
        /// Gets the list by command text.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public DataTable GetListByCommandText(string commandText, string parametersInput,
                    params  object[] parametersValue)
        {
            Boolean allowLocalTransaction = false;
            try
            {
                parametersInput = parametersInput.Replace(" ", "");
                using (DataSet ds = new DataSet())
                {
                    //DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                    DbParameter[] mainParameters = null;
                    if (parametersInput != "" && parametersValue != null)
                    {
                        char[] splitChars = { ',' };
                        string[] paraNames = parametersInput.Split(splitChars);
                        mainParameters = Factory.CreateParameters(this.Provider, paraNames.Length);
                        for (int i = 0; i < paraNames.Length; i++)
                        {
                            mainParameters[i].ParameterName = "@" + paraNames[i];
                        }
                        AssignParameterValues(ref mainParameters, paraNames, parametersValue);
                    }
                    this.PrepareAll(commandText, CommandType.Text, command: null, parametersWithValue: mainParameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.RepeatableRead);
                    DbDataAdapter dataAdapter = Factory.CreateDataAdapter(this.Provider);
                    dataAdapter.SelectCommand = this.Command;
                    dataAdapter.Fill(ds);
                    if (allowLocalTransaction)
                        this.CommitTransaction();
                    //hoan tat giao tac
                    return ds.Tables[0];
                }
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
        //moi them vao
        /// <summary>
        /// Gets the list by command text.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parametersName">Name of the parameters.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public DataTable GetListByCommandText(string commandText, string[] parametersName,
                    params  object[] parametersValue)
        {
            Boolean allowLocalTransaction = false;
            try
            {
                using (DataSet ds = new DataSet())
                {
                    //DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                    DbParameter[] mainParameters = null;
                    if (parametersName != null && parametersValue != null)
                    {
                        for (int i = 0; i < parametersName.Length; i++)
                        {
                            parametersName[i] = parametersName[i].Replace("@", "");
                        }
                        mainParameters = Factory.CreateParameters(this.Provider, parametersName.Length);
                        for (int i = 0; i < parametersName.Length; i++)
                        {
                            mainParameters[i].ParameterName = "@" + parametersName[i];
                        }
                        AssignParameterValues(ref mainParameters, parametersName, parametersValue);
                    }
                    this.PrepareAll(commandText, CommandType.Text, command: null, parametersWithValue: mainParameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.RepeatableRead);
                    DbDataAdapter dataAdapter = Factory.CreateDataAdapter(this.Provider);
                    dataAdapter.SelectCommand = this.Command;
                    dataAdapter.Fill(ds);
                    if (allowLocalTransaction)
                        this.CommitTransaction();
                    //hoan tat giao tac
                    return ds.Tables[0];
                }
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
        /// Gets the list by command text.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public DataTable GetListByCommandText(string commandText)
        {
            return GetListByCommandText(commandText, tableName:"", preCommandText: String.Empty);
        }

        /// <summary>
        /// Gets the list by command text.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public DataTable GetListByCommandText(string commandText, string tableName)
        {
            return GetListByCommandText(commandText, tableName, preCommandText: String.Empty);
        }
        /// <summary>
        /// Gets the list by command text.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public DataTable GetListByCommandText(string commandText, string tableName, string preCommandText = "")
        {//ham co ban
            DataTable returnValue = null;
            Boolean allowLocalTransaction = false;
            if (commandText != "")
            {
                //if (tableName != "")
                {
                    returnValue = new DataTable();
                    // Create DataSet object.
                    DataSet dsData = new DataSet();
                    ///////////"Set DateFormat DMY "
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
                        if (tableName == null || tableName == "")
                        {
                            _dataAdapter.Fill(dsData);
                        }
                        else
                        {
                            _dataAdapter.Fill(dsData, tableName);
                        }
                        if (allowLocalTransaction)
                            this.CommitTransaction();
                        // Set data from DataSet to DataTable
                        if (tableName == null || tableName == "")
                        {
                            returnValue = dsData.Tables[0];
                        }
                        else
                        {
                            returnValue = dsData.Tables[tableName];
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
                //else
                {
                    //throw new Exception("tableName is Empty");
                }
            }
            else
            {
                throw new Exception("commandText is Empty");
            }
            // Return the filled DataSet
            return returnValue;
        }
        /// <summary>
        /// Gets the list by table name with filter and order by.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="preCommandText">The pre command text.</param>
        /// <returns></returns>
        public DataTable GetListByTableNameWithFilterAndOrderBy(string tableName, string filter = "", string orderBy = "", string preCommandText = "")
        {
            DataTable returnValue = null;
            if (tableName != "")
            {
                string commandText = "Select * From " + Factory.ProtectName(tableName)
                    + (filter.CompareTo("") == 0 ? "" : " Where " + filter)
                    + (orderBy.CompareTo("") == 0 ? "" : " order by " + orderBy);
                returnValue = this.GetListByCommandText(commandText, tableName, preCommandText);
            }
            else
            {
                throw new Exception("TableName is Empty");
            }
            return returnValue;
        }
        /// <summary>
        /// Gets the name of all by table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public DataTable GetAllByTableName(String tableName, String orderBy = "")
        {
            DataTable returnValue = null;
            const String filter = "";
            returnValue = this.GetListByTableNameWithFilterAndOrderBy(tableName, filter, orderBy);
            return returnValue;
        }
        /// <summary>
        /// Gets the list by table name and code.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="code">The code.</param>
        /// <param name="value">The value.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public DataTable GetListByTableNameAndCode(string tableName, string code, string value, string orderBy = "")
        {
            DataTable returnValue = null;
            String filter = String.Format("{0} = '{1}'", Factory.ProtectName(code), value);
            returnValue = this.GetListByTableNameWithFilterAndOrderBy(tableName, filter, orderBy);
            return returnValue;
        }
    }
}
