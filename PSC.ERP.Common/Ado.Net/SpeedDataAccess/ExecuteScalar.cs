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
        #region ExecuteScalar
        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public Object ExecuteScalar(string commandText)
        {
            Boolean allowLocalTransaction = false;
            Object valueOfFirstColumnOfFirstRow = null;
            try
            {
                this.PrepareAll(commandText, CommandType.Text, null, null, allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                valueOfFirstColumnOfFirstRow = this.Command.ExecuteScalar();
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
            return valueOfFirstColumnOfFirstRow;
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public Object ExecuteScalar(string commandText, string parametersInput, params  object[] parametersValue)
        {
            Object valueOfFirstColumnOfFirstRow = null;
            Boolean allowLocalTransaction = false;
            try
            {
                parametersInput = parametersInput.Replace(" ", "").Replace("@", "");
                DbParameter[] mainParameters = null;
                if (!String.IsNullOrEmpty(parametersInput) && parametersValue != null)
                {
                    char[] splitChars = { ',' };
                    string[] paraNames = parametersInput.Split(splitChars);
                    mainParameters = Factory.CreateParameters(this.Provider, paraNames.Length);

                    for (int i = 0; i < paraNames.Length; i++)
                    {
                        mainParameters[i].ParameterName = "@" + paraNames[i];
                    }
                    AssignParameterValues(ref mainParameters, parametersValue);
                }
                this.PrepareAll(commandText
                    , CommandType.Text
                    , command: null
                    , parametersWithValue: mainParameters
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.ReadCommitted);
                valueOfFirstColumnOfFirstRow = this.Command.ExecuteScalar();
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
            return valueOfFirstColumnOfFirstRow;
        }
        public Object ExecuteScalar(string commandText,  DbParameter[] mainParameters)//object[] parametersValue, string parametersInput)
        {
            Object valueOfFirstColumnOfFirstRow = null;
            Boolean allowLocalTransaction = false;
            try
            {
                //parametersInput = parametersInput.Replace(" ", "").Replace("@", "");
                //DbParameter[] mainParameters = null;
                //if (!String.IsNullOrEmpty(parametersInput) && parametersValue != null)
                //{
                    //char[] splitChars = { ',' };
                    //string[] paraNames = parametersInput.Split(splitChars);
                    //mainParameters = Factory.CreateParameters(this.Provider, paraNames.Length);

                    //for (int i = 0; i < paraNames.Length; i++)
                    //{
                        //mainParameters[i].ParameterName = "@" + paraNames[i];
                    //}
                    //AssignParameterValues(ref mainParameters, parametersValue);
                //}
                this.PrepareAll(commandText
                    , CommandType.Text
                    , command: null
                    , parametersWithValue: mainParameters
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.ReadCommitted);
                valueOfFirstColumnOfFirstRow = this.Command.ExecuteScalar();
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
            return valueOfFirstColumnOfFirstRow;
        }
        //moi them vao
        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parametersName">Name of the parameters.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public Object ExecuteScalar(string commandText, string[] parametersName, params  object[] parametersValue)
        {
            Object valueOfFirstColumnOfFirstRow = null;
            Boolean allowLocalTransaction = false;
            try
            {
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
                    AssignParameterValues(ref mainParameters, parametersValue);
                }
                this.PrepareAll(commandText
                    , CommandType.Text
                    , command: null
                    , parametersWithValue: mainParameters
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.ReadCommitted);
                valueOfFirstColumnOfFirstRow = this.Command.ExecuteScalar();
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
            return valueOfFirstColumnOfFirstRow;
        }

        /// <summary>
        /// Executes the scalar store.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersWithValue">The parameters with value.</param>
        /// <returns></returns>
        public Object ExecuteScalarStore(out Hashtable outPut, string procedureName, DbParameter[] parametersWithValue = null)
        {
            Object valueOfFirstColumnOfFirstRow = null;
            Boolean allowLocalTransaction = false;
            outPut = null;
            try
            {
                DbParameter[] mainParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                if (mainParameters != null && mainParameters.Length > 0)
                {
                    SpeedDataAccess.AssignParameterValues(ref mainParameters, parametersWithValue);
                }
                this.PrepareAll(procedureName, CommandType.StoredProcedure, command: null, parametersWithValue: parametersWithValue, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                valueOfFirstColumnOfFirstRow = this.Command.ExecuteScalar();
                if (allowLocalTransaction)
                    this.CommitTransaction();
                this.FillValueForOutPut(outPut);
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
            return valueOfFirstColumnOfFirstRow;
        }
        public Object ExecuteScalarStore(out Hashtable outPut, string procedureName, params  object[] parametersValue)
        {
            Object valueOfFirstColumnOfFirstRow = null;
            Boolean allowLocalTransaction = false;
            outPut = null;
            try
            {
                DbParameter[] mainParameters = Cache.GetSpParameterSet(this.Provider, ConnectionString, procedureName);
                if (mainParameters != null && mainParameters.Length > 0)
                {
                    SpeedDataAccess.AssignParameterValues(ref mainParameters, parametersValue);
                }

                this.PrepareAll(procedureName, CommandType.StoredProcedure, command: null, parametersWithValue: mainParameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                valueOfFirstColumnOfFirstRow = this.Command.ExecuteScalar();
                if (allowLocalTransaction)
                    this.CommitTransaction();
                this.FillValueForOutPut(outPut);
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
            return valueOfFirstColumnOfFirstRow;
        }
        /// <summary>
        /// Executes the scalar store.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public Object ExecuteScalarStore(out Hashtable outPut, string procedureName, string parametersInput, params object[] parametersValue)
        {
            Object valueOfFirstColumnOfFirstRow = null;
            Boolean allowLocalTransaction = false;
            outPut = new Hashtable();
            try
            {
                parametersInput = parametersInput.Replace(" ", "").Replace("@", "");
                DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, this.ConnectionString, procedureName);
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
                    , isolationLevel: IsolationLevel.ReadCommitted);
                valueOfFirstColumnOfFirstRow = this.Command.ExecuteScalar();
                if (allowLocalTransaction)
                    this.CommitTransaction();
                this.FillValueForOutPut(outPut);
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
            return valueOfFirstColumnOfFirstRow;
        }
        //moi them vao
        public Object ExecuteScalarStore(out Hashtable outPut, string procedureName, string[] parameterName, params object[] parametersValue)
        {
            Object valueOfFirstColumnOfFirstRow = null;
            Boolean allowLocalTransaction = false;
            outPut = new Hashtable();
            try
            {
                DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, this.ConnectionString, procedureName);
                DbParameter[] mainParameters = null;
                if (parameterName != null && parametersValue != null)
                {
                    for (int i = 0; i < parameterName.Length; i++)
                    {
                        parameterName[i] = parameterName[i].Replace("@", "");
                    }

                    mainParameters = Factory.CreateParameters(this.Provider, parameterName.Length);
                    DetermineUsefullParameters(ref mainParameters, parameterName, cacheParameters);


                    AssignParameterValues(ref mainParameters, parameterName, parametersValue);
                }
                this.PrepareAll(procedureName
                    , CommandType.StoredProcedure
                    , command: null
                    , parametersWithValue: mainParameters
                    , initTransaction: allowLocalTransaction
                    , isolationLevel: IsolationLevel.ReadCommitted);
                valueOfFirstColumnOfFirstRow = this.Command.ExecuteScalar();
                if (allowLocalTransaction)
                    this.CommitTransaction();
                this.FillValueForOutPut(outPut);
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
            return valueOfFirstColumnOfFirstRow;
        }
        #endregion end ExecuteScalar

    }
}
