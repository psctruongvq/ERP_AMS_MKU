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

        #region "ExecuteNonQuery"
        /// <summary>
        /// Execute non query.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public Int32 ExecuteNonQuery(string commandText)
        {
            Int32 intResult = Int32.MinValue;
            intResult = ExecuteNonQuery(commandText: commandText, parametersInput: null, parametersValue: null);
            return intResult;
        }
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public Int32 ExecuteNonQuery(string commandText, string parametersInput, params  object[] parametersValue)
        {
            Int32 intResult = Int32.MinValue;
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
                
                this.PrepareAll(commandText, CommandType.Text, command: null, parametersWithValue: mainParameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                intResult = this.Command.ExecuteNonQuery();
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
            return intResult;
        }
        //moi them vao
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="parametersName">Name of the parameters.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public Int32 ExecuteNonQuery(string commandText, string[] parametersName, params  object[] parametersValue)
        {
            Int32 intResult = Int32.MinValue;
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

                this.PrepareAll(commandText, CommandType.Text, command: null, parametersWithValue: mainParameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                intResult = this.Command.ExecuteNonQuery();
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
            return intResult;
        }


        /// <summary>
        /// Executes the non query store.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersWithValue">The parameters with value.</param>
        /// <returns></returns>
        public Int32 ExecuteNonQueryStore(out Hashtable outPut, string procedureName, DbParameter[] parametersWithValue = null)
        {
            Int32 intResult = Int32.MinValue;
            Boolean allowLocalTransaction = false;
            outPut = null;
            try
            {

                this.PrepareAll(procedureName, CommandType.StoredProcedure, command: null, parametersWithValue: parametersWithValue, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                intResult = this.Command.ExecuteNonQuery();
                if (allowLocalTransaction)
                    this.CommitTransaction();
                foreach (DbParameter para in this.Command.Parameters)
                {
                    if (para.Direction == ParameterDirection.InputOutput
                        || para.Direction == ParameterDirection.Output
                        || para.Direction == ParameterDirection.ReturnValue)
                    {
                        String key = para.ParameterName.Replace("@", "");
                        outPut.Add(key, para.Value);
                    }
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
            return intResult;
        }
        /// <summary>
        /// Executes the non query store.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public Int32 ExecuteNonQueryStore(out Hashtable outPut, string procedureName, params  object[] parametersValue)
        {
            Int32 intResult = Int32.MinValue;
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
                intResult = this.Command.ExecuteNonQuery();
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
            return intResult;
        }


        /// <summary>
        /// Executes the non query store.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersInput">The parameters input.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public Int32 ExecuteNonQueryStore(out Hashtable outPut, string procedureName, string parametersInput, params  object[] parametersValue)
        {
            Int32 intResult = Int32.MinValue;
            Boolean allowLocalTransaction = false;
            outPut = null;
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
                this.PrepareAll(procedureName, CommandType.StoredProcedure, command: null, parametersWithValue: mainParameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                intResult = this.Command.ExecuteNonQuery();
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
            return intResult;
        }
        //moi them vao
        /// <summary>
        /// Executes the non query store.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="parametersName">Name of the parameters.</param>
        /// <param name="parametersValue">The parameters value.</param>
        /// <returns></returns>
        public Int32 ExecuteNonQueryStore(out Hashtable outPut, string procedureName, string[] parametersName, params  object[] parametersValue)
        {
            Int32 intResult = Int32.MinValue;
            Boolean allowLocalTransaction = false;
            outPut = null;
            try
            {

                DbParameter[] cacheParameters = Cache.GetSpParameterSet(this.Provider, this.ConnectionString, procedureName);
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
                this.PrepareAll(procedureName, CommandType.StoredProcedure, command: null, parametersWithValue: mainParameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.ReadCommitted);
                intResult = this.Command.ExecuteNonQuery();
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
            return intResult;
        }

        #endregion
    }
}
