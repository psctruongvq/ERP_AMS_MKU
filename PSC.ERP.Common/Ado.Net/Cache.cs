using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data.OleDb;
//using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Collections;

namespace PSC_ERP_Common.Ado.Net
{
    public sealed class Cache : IDisposable
    {
        private Cache() { }

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        //*********************************************************************
        //
        // resolve at run time the appropriate set of SqlParameters for a stored procedure
        // 
        // param name="connectionString" a valid connection string for a SqlConnection 
        // param name="spName" the name of the stored procedure 
        // param name="includeReturnValueParameter" whether or not to include their return value parameter 
        //
        //*********************************************************************

        /// <summary>
        /// Discovers the sp parameter set.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="spName">Name of the sp.</param>
        /// <param name="includeReturnValueParameter">if set to <c>true</c> [include return value parameter].</param>
        /// <returns></returns>
        private static DbParameter[] DiscoverSpParameterSet(DataProvider dataType, string connectionString, string spName, bool includeReturnValueParameter)
        {
            //SqlConnection cn = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand(spName,cn);
            //SqlParameter[] discoveredParameters;

            DbConnection cn = Factory.CreateConnection(connectionString, dataType);
            DbCommand cmd = Factory.CreateCommand(dataType);
            DbParameter[] discoveredParameters;

            try
            {
                cn.ConnectionString = connectionString;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.CommandText = spName;
                //SqlCommandBuilder.DeriveParameters(cmd);
                switch (dataType)
                {
                    case DataProvider.SQLServer:
                        SqlCommandBuilder.DeriveParameters((SqlCommand)cmd);
                        break;
                    case DataProvider.Oracle:
                        break;
                    case DataProvider.Odbc:
                        OdbcCommandBuilder.DeriveParameters((OdbcCommand)cmd);
                        break;
                    case DataProvider.OleDb:
                        OleDbCommandBuilder.DeriveParameters((OleDbCommand)cmd);
                        break;
                    default:
                        break;
                }


                if (!includeReturnValueParameter)
                {
                    cmd.Parameters.RemoveAt(0);
                }

                //discoveredParameters = new SqlParameter[cmd.Parameters.Count];;
                discoveredParameters = new DbParameter[cmd.Parameters.Count]; ;
                cmd.Parameters.CopyTo(discoveredParameters, 0);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                cn.Close();
                cmd.Dispose();
            }

            return discoveredParameters;
        }

        /// <summary>
        /// Clones the parameters.
        /// </summary>
        /// <param name="originalParameters">The original parameters.</param>
        /// <returns></returns>
        private static IDbDataParameter[] CloneParameters(IDbDataParameter[] originalParameters)
        {
            //deep copy of cached SqlParameter array
            IDbDataParameter[] clonedParameters = new IDbDataParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (IDbDataParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        //*********************************************************************
        //
        // add parameter array to the cache
        //
        // param name="connectionString" a valid connection string for a SqlConnection 
        // param name="commandText" the stored procedure name or T-SQL command 
        // param name="commandParameters" an array of SqlParamters to be cached 
        //
        //*********************************************************************

        /// <summary>
        /// Caches the parameter set.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandParameters">The command parameters.</param>
        public static void CacheParameterSet(string connectionString, string commandText, params IDbDataParameter[] commandParameters)
        {
            string hashKey = String.Format("{0}:{1}", connectionString, commandText);

            paramCache[hashKey] = commandParameters;
        }

        //*********************************************************************
        //
        // Retrieve a parameter array from the cache
        // 
        // param name="connectionString" a valid connection string for a SqlConnection 
        // param name="commandText" the stored procedure name or T-SQL command 
        // returns an array of SqlParamters
        //
        //*********************************************************************

        /// <summary>
        /// Gets the cached parameter set.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static IDbDataParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            string hashKey = String.Format("{0}:{1}", connectionString, commandText);

            IDbDataParameter[] cachedParameters = (IDbDataParameter[])paramCache[hashKey];

            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        //*********************************************************************
        //
        // Retrieves the set of SqlParameters appropriate for the stored procedure
        // 
        // This method will query the database for this information, and then store it in a cache for future requests.
        // 
        // param name="connectionString" a valid connection string for a SqlConnection 
        // param name="spName" the name of the stored procedure 
        // returns an array of SqlParameters
        //
        //*********************************************************************

        /// <summary>
        /// Gets the sp parameter set.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <returns></returns>
        public static DbParameter[] GetSpParameterSet(DataProvider dataType, string connectionString, string storeProcedureName)
        {
            return GetSpParameterSet(dataType, connectionString, storeProcedureName, false);
        }

        //*********************************************************************
        //
        // Retrieves the set of SqlParameters appropriate for the stored procedure
        // 
        // This method will query the database for this information, and then store it in a cache for future requests.
        // 
        // param name="connectionString" a valid connection string for a SqlConnection 
        // param name="spName" the name of the stored procedure 
        // param name="includeReturnValueParameter" a bool value indicating whether the return value parameter should be included in the results 
        // returns an array of SqlParameters
        //
        //*********************************************************************

        /// <summary>
        /// Gets the sp parameter set.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="includeReturnValueParameter">if set to <c>true</c> [include return value parameter].</param>
        /// <returns></returns>
        public static DbParameter[] GetSpParameterSet(DataProvider dataType, string connectionString, string storeProcedureName, bool includeReturnValueParameter)
        {
            string hashKey = String.Format("{0}:{1}{2}", connectionString, storeProcedureName, (includeReturnValueParameter ? ":include ReturnValue Parameter" : ""));

            DbParameter[] cachedParameters = (DbParameter[])paramCache[hashKey];

            if (cachedParameters == null)
            {
                cachedParameters = (DbParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(dataType, connectionString, storeProcedureName, includeReturnValueParameter));
            }

            return CloneParameters(cachedParameters);
        }
        /// <summary>
        /// Clones the parameters.
        /// </summary>
        /// <param name="originalParameters">The original parameters.</param>
        /// <returns></returns>
        private static DbParameter[] CloneParameters(DbParameter[] originalParameters)
        {
            //deep copy of cached SqlParameter array
            DbParameter[] clonedParameters = new DbParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (DbParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }
        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
