using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PSC_ERP_Common.Ado.Net
{

    public partial class Factory
    {
        //Lop long ben trong //////////////////////////////////////////////////////////////
        #region Inner class
        /// <summary>
        /// Convert a base data type to another base data type
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        ////////////public sealed class TypeConvertor
        ////////////{

        ////////////private struct TypeMapping
        ////////////{
        ////////////    public Type Type;
        ////////////    public DbType DbType;
        ////////////    public SqlDbType SqlDbType;
        ////////////    public TypeMapping(Type dotNetType, DbType dbType, SqlDbType sqlDbType)
        ////////////    {
        ////////////        this.Type = dotNetType;
        ////////////        this.DbType = dbType;
        ////////////        this.SqlDbType = sqlDbType;
        ////////////    }

        ////////////};

        ////////////private static ArrayList _DbTypeList = new ArrayList();



        #region Constructors
        //////////////////////static TypeConvertor()
        //////////////////////{
        //////////////////////    TypeMapping dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(bool), DbType.Boolean, SqlDbType.Bit);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(byte), DbType.Double, SqlDbType.TinyInt);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(byte[]), DbType.Binary, SqlDbType.Image);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(DateTime), DbType.DateTime, SqlDbType.DateTime);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(Decimal), DbType.Decimal, SqlDbType.Decimal);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(double), DbType.Double, SqlDbType.Float);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(Guid), DbType.Guid, SqlDbType.UniqueIdentifier);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(Int16), DbType.Int16, SqlDbType.SmallInt);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(Int32), DbType.Int32, SqlDbType.Int);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(Int64), DbType.Int64, SqlDbType.BigInt);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(object), DbType.Object, SqlDbType.Variant);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);

        //////////////////////    dbTypeMapEntry
        //////////////////////    = new TypeMapping(typeof(string), DbType.String, SqlDbType.VarChar);
        //////////////////////    _DbTypeList.Add(dbTypeMapEntry);


        //////////////////////}
        //////////////////////private TypeConvertor()
        //////////////////////{
        //////////////////////}
        #endregion



        #region Methods

        /////////////// <summary>
        /////////////// Convert db type to .Net data type
        /////////////// </summary>
        /////////////// <param name="dbType"></param>
        /////////////// <returns></returns>
        ////////////public static Type ToDotNetType(DbType dbType)
        ////////////{
        ////////////    TypeMapping entry = Find(dbType);
        ////////////    return entry.Type;
        ////////////}


        /////////////// <summary>
        /////////////// Convert TSQL type to .Net data type
        /////////////// </summary>
        /////////////// <param name="sqlDbType"></param>
        /////////////// <returns></returns>
        ////////////public static Type ToDotNetType(SqlDbType sqlDbType)
        ////////////{
        ////////////    TypeMapping entry = Find(sqlDbType);
        ////////////    return entry.Type;
        ////////////}

        /////////////// <summary>
        /////////////// Convert .Net type to Db type
        /////////////// </summary>
        /////////////// <param name="type"></param>
        /////////////// <returns></returns>
        ////////////public static DbType ToDbType(Type type)
        ////////////{
        ////////////    TypeMapping entry = Find(type);
        ////////////    return entry.DbType;
        ////////////}

        /////////////// <summary>
        /////////////// Convert TSQL data type to DbType
        /////////////// </summary>
        /////////////// <param name="sqlDbType"></param>
        /////////////// <returns></returns>
        ////////////public static DbType ToDbType(SqlDbType sqlDbType)
        ////////////{
        ////////////    TypeMapping entry = Find(sqlDbType);
        ////////////    return entry.DbType;
        ////////////}


        /////////////// <summary>
        /////////////// Convert .Net type to TSQL data type
        /////////////// </summary>
        /////////////// <param name="type"></param>
        /////////////// <returns></returns>
        ////////////public static SqlDbType ToSqlDbType(Type type)
        ////////////{
        ////////////    TypeMapping entry = Find(type);
        ////////////    return entry.SqlDbType;
        ////////////}


        /////////////// <summary>
        /////////////// Convert DbType type to TSQL data type
        /////////////// </summary>
        /////////////// <param name="dbType"></param>
        /////////////// <returns></returns>
        ////////////public static SqlDbType ToSqlDbType(DbType dbType)
        ////////////{
        ////////////    TypeMapping entry = Find(dbType);
        ////////////    return entry.SqlDbType;
        ////////////}


        ////////////private static TypeMapping Find(Type type)
        ////////////{
        ////////////    object retObj = null;
        ////////////    for (int i = 0; i < _DbTypeList.Count; i++)
        ////////////    {
        ////////////        TypeMapping entry = (TypeMapping)_DbTypeList[i];
        ////////////        if (entry.Type == type)
        ////////////        {
        ////////////            retObj = entry;
        ////////////            break;
        ////////////        }
        ////////////    }
        ////////////    if (retObj == null)
        ////////////    {
        ////////////        throw
        ////////////        new ApplicationException("Referenced an unsupported Type");
        ////////////    }

        ////////////    return (TypeMapping)retObj;
        ////////////}

        ////////////private static TypeMapping Find(DbType dbType)
        ////////////{
        ////////////    object retObj = null;
        ////////////    for (int i = 0; i < _DbTypeList.Count; i++)
        ////////////    {
        ////////////        TypeMapping entry = (TypeMapping)_DbTypeList[i];
        ////////////        if (entry.DbType == dbType)
        ////////////        {
        ////////////            retObj = entry;
        ////////////            break;
        ////////////        }
        ////////////    }
        ////////////    if (retObj == null)
        ////////////    {
        ////////////        throw
        ////////////        new ApplicationException("Referenced an unsupported DbType");
        ////////////    }

        ////////////    return (TypeMapping)retObj;
        ////////////}
        ////////////private static TypeMapping Find(SqlDbType sqlDbType)
        ////////////{
        ////////////    object retObj = null;
        ////////////    for (int i = 0; i < _DbTypeList.Count; i++)
        ////////////    {
        ////////////        TypeMapping entry = (TypeMapping)_DbTypeList[i];
        ////////////        if (entry.SqlDbType == sqlDbType)
        ////////////        {
        ////////////            retObj = entry;
        ////////////            break;
        ////////////        }
        ////////////    }
        ////////////    if (retObj == null)
        ////////////    {
        ////////////        throw
        ////////////        new ApplicationException("Referenced an unsupported SqlDbType");
        ////////////    }

        ////////////    return (TypeMapping)retObj;
        ////////////}

        #endregion
        //////////////////}
        #endregion


        public static SpeedDataAccess CreateSpeedDataAccess()
        {
            return new SpeedDataAccess(PSC_ERP_Global.Main.NormalConnectionString);
        }

        /// <summary>
        /// Creates the command builder.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DbCommandBuilder CreateCommandBuilder(DataProvider provider)
        {
            DbCommandBuilder returnValue = null;
            switch (provider)
            {
                case DataProvider.SQLServer:
                    returnValue = new SqlCommandBuilder();
                    break;
                case DataProvider.Oracle:
                    //returnValue = new OracleCommandBuilder();
                    break;
                case DataProvider.Odbc:
                    returnValue = new OdbcCommandBuilder();
                    break;
                case DataProvider.OleDb:
                    returnValue = new OleDbCommandBuilder();
                    break;
                default:
                    break;
            }
            return returnValue;
        }
        /// <summary>
        /// Gets the name of the data provider by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static DataProvider GetDataProviderByName(String name)
        {
            DataProvider provider = DataProvider.SQLServer;
            switch (name)
            {
                case "SQLServer":
                    provider = DataProvider.SQLServer;
                    break;
                case "Oracle":
                    provider = DataProvider.Oracle;
                    break;
                case "Odbc":
                    provider = DataProvider.Odbc;
                    break;
                case "OleDb":
                    provider = DataProvider.OleDb;
                    break;
                default:
                    break;
            }

            return provider;
        }
        /// <summary>
        /// Creates the command builder.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="adapter">The adapter.</param>
        /// <returns></returns>
        public static DbCommandBuilder CreateCommandBuilder(DataProvider provider, ref DbDataAdapter adapter)
        {
            DbCommandBuilder returnValue = null;
            switch (provider)
            {
                case DataProvider.SQLServer:
                    returnValue = new SqlCommandBuilder((SqlDataAdapter)adapter);
                    break;
                case DataProvider.Oracle:
                    //returnValue = new OracleCommandBuilder((OracleDataAdapter)adapter);
                    break;
                case DataProvider.Odbc:
                    returnValue = new OdbcCommandBuilder((OdbcDataAdapter)adapter);
                    break;
                case DataProvider.OleDb:
                    returnValue = new OleDbCommandBuilder((OleDbDataAdapter)adapter);
                    break;
                default:
                    break;
            }
            return returnValue;
        }
        /// <summary>
        /// Protects the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static String ProtectName(String name)
        {
            String returnValue = name;
            returnValue = name.Replace("[", "");
            returnValue = name.Replace("]", "");
            returnValue = String.Format("[{0}]", returnValue);
            return returnValue;
        }
        /// <summary>
        /// Covers the command text with transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public static String CoverCommandTextWithTransaction(String commandText)
        {
            String returnValue = "";
            returnValue = String.Format("BEGIN TRY BEGIN TRANSACTION MainTransaction;{0}; IF (@@ERROR = 0) Begin COMMIT TRANSACTION MainTransaction; End ELSE Begin ROLLBACK TRANSACTION MainTransaction; End END TRY BEGIN CATCH ROLLBACK TRANSACTION MainTransaction; END CATCH", commandText);
            return returnValue;
        }
        /// <summary>
        /// Covers the command text with transaction.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="resultName">Name of the result.</param>
        /// <returns></returns>
        public static String CoverCommandTextWithTransaction(String commandText, String resultName)
        {
            String returnValue = "";

            if (resultName.StartsWith("@"))
            {
                resultName = resultName.Remove(0, 1);
            }
            returnValue = String.Format("BEGIN TRY BEGIN TRANSACTION MainTransaction;{0}; IF (@@ERROR = 0) Begin COMMIT TRANSACTION MainTransaction; SET @{1} = 1; End ELSE Begin ROLLBACK TRANSACTION MainTransaction; SET @{1} = 0; End END TRY BEGIN CATCH ROLLBACK TRANSACTION MainTransaction; SET @{1} = 0; END CATCH", commandText, resultName);
            return returnValue;
        }
        /// <summary>
        /// Creates the param struct.
        /// </summary>
        /// <param name="ParamName">Name of the param.</param>
        /// <param name="DataType">Type of the data.</param>
        /// <param name="value">The value.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="sourceColumn">The source column.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static ParameterStruct CreateParamStruct(string ParamName, DbType DataType, object value, ParameterDirection direction, string sourceColumn, short size)
        {
            ParameterStruct ps;
            ps.ParamName = ParamName;
            ps.DataType = DataType;
            ps.value = value;
            ps.direction = direction;
            ps.sourceColumn = sourceColumn;
            ps.size = size;
            return ps;
        }
        /// <summary>
        /// Gets the format date command text.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static String GetFormatDateCommandText(DataProvider provider)
        {
            String returnValue = "";
            switch (provider)
            {
                case DataProvider.SQLServer:
                    returnValue = "Set DateFormat DMY";
                    break;
                case DataProvider.Oracle:
                    throw new Exception("");
                    break;
                case DataProvider.Odbc:
                    throw new Exception("");
                    break;
                case DataProvider.OleDb:
                    throw new Exception("");
                    break;
                default:
                    break;
            }

            return returnValue;
        }
        /// <summary>
        /// Gets the DB server date time command text.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static String GetDBServerDateTimeCommandText(DataProvider provider)
        {
            String returnValue = "";
            switch (provider)
            {
                case DataProvider.SQLServer:
                    returnValue = "SELECT getdate()";
                    break;
                case DataProvider.Oracle:
                    throw new Exception("");
                    break;
                case DataProvider.Odbc:
                    throw new Exception("");
                    break;
                case DataProvider.OleDb:
                    throw new Exception("");
                    break;
                default:
                    break;
            }

            return returnValue;
        }
        /// <summary>
        /// Creates the data adapter.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DbDataAdapter CreateDataAdapter(DataProvider provider)
        {
            DbDataAdapter returnValue = null;
            switch (provider)
            {
                case DataProvider.SQLServer:
                    returnValue = new SqlDataAdapter();
                    break;
                case DataProvider.Oracle:
                    //returnValue = new OracleDataAdapter();
                    break;
                case DataProvider.Odbc:
                    returnValue = new OdbcDataAdapter();
                    break;
                case DataProvider.OleDb:
                    returnValue = new OleDbDataAdapter();
                    break;
                default:
                    break;
            }

            return returnValue;
        }
        /// <summary>
        /// Creates the data adapter.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public static DbDataAdapter CreateDataAdapter(DataProvider provider, DbCommand command)
        {
            DbDataAdapter dataAdapter = null;
            switch (provider)
            {
                case DataProvider.SQLServer:
                    dataAdapter = new SqlDataAdapter((SqlCommand)command);
                    break;
                case DataProvider.Oracle:
                    //dataAdapter = new OracleDataAdapter((OracleCommand)command);
                    break;
                case DataProvider.Odbc:
                    dataAdapter = new OdbcDataAdapter((OdbcCommand)command);
                    break;
                case DataProvider.OleDb:
                    dataAdapter = new OleDbDataAdapter((OleDbCommand)command);
                    break;
                default:
                    break;
            }

            return dataAdapter;
        }
        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DbCommand CreateCommand(DataProvider provider)
        {
            DbCommand cmd = null;

            switch (provider)
            {
                case DataProvider.SQLServer:
                    cmd = new SqlCommand();
                    break;
                case DataProvider.Oracle:
                    //cmd = new OracleCommand();
                    break;
                case DataProvider.Odbc:
                    cmd = new OdbcCommand();
                    break;
                case DataProvider.OleDb:
                    cmd = new OleDbCommand();
                    break;
                default:
                    break;
            }
            return cmd;
        }
        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="strCmdText">The STR CMD text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="connection">The connection.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static DbCommand CreateCommand(string strCmdText, CommandType commandType, int commandTimeout, DataProvider provider, DbConnection connection = null, DbParameter[] parameters = null)
        {
            //tao command tho
            DbCommand cmd = CreateCommand(provider);
            //gan cac thuoc tinh can thiet
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            cmd.CommandType = commandType;
            cmd.CommandText = strCmdText;
            cmd.CommandTimeout = commandTimeout;
            //connection phai duoc open truoc khi goi vao ham nay
            cmd.Connection = connection;

            return cmd;
        }
        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="parameterStructs">The parameter structs.</param>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
        public static DbCommand CreateCommand(DataProvider provider, string commandText
            , CommandType commandType, int commandTimeout
            , ParameterStruct[] parameterStructs = null, DbConnection connection = null)
        {
            DbCommand cmd = CreateCommand(provider);


            if (parameterStructs != null)
            {
                for (int i = 0; i <= parameterStructs.Length - 1; i++)
                {
                    ParameterStruct paraStruct = parameterStructs[i];

                    DbParameter parameter = CreateParameter(paraStruct.ParamName
                        , paraStruct.direction, paraStruct.value
                        , paraStruct.DataType, paraStruct.sourceColumn, paraStruct.size, provider);
                    cmd.Parameters.Add(parameter);
                }
            }
            cmd.CommandType = commandType;
            cmd.CommandText = commandText;
            cmd.CommandTimeout = commandTimeout;
            cmd.Connection = connection;

            return cmd;
        }
        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DbConnection CreateConnection(String connectionString, DataProvider provider)
        {
            DbConnection connection = null;
            switch (provider)
            {
                case DataProvider.SQLServer:
                    connection = new SqlConnection(connectionString);
                    break;
                case DataProvider.Oracle:
                    //connection = new OracleConnection(connectionString);
                    break;
                case DataProvider.Odbc:
                    connection = new OdbcConnection(connectionString);
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection(connectionString);
                    break;
                default:
                    break;
            }


            return connection;
        }
        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// Trả về Parameter tùy thuộc vào provider of Database
        /// </returns>
        public static DbParameter CreateParameter(DataProvider provider)
        {
            DbParameter param = null;
            switch (provider)
            {
                case DataProvider.SQLServer:
                    param = new SqlParameter();
                    param.Direction = ParameterDirection.InputOutput;
                    break;
                case DataProvider.Oracle:
                    //param = new OracleParameter();
                    break;
                case DataProvider.Odbc:
                    param = new OdbcParameter();
                    param.Direction = ParameterDirection.InputOutput;
                    break;
                case DataProvider.OleDb:
                    param = new OleDbParameter();
                    param.Direction = ParameterDirection.InputOutput;
                    break;
                default:
                    break;
            }
            return param;
        }
        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="parameterDirection">The parameter direction.</param>
        /// <param name="objValue">The obj value.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="sourceColumn">The source column.</param>
        /// <param name="size">The size.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DbParameter CreateParameter(string paramName, ParameterDirection parameterDirection
            , object objValue, DbType dbType, string sourceColumn, short size, DataProvider provider)
        {
            DbParameter param = CreateParameter(provider);
            param.ParameterName = paramName;
            param.DbType = dbType;
            if (size > 0)
            {
                param.Size = size;
            }
            if (objValue != null)
            {
                param.Value = objValue;
            }
            param.Direction = parameterDirection;
            if (sourceColumn != "")
            {
                param.SourceColumn = sourceColumn;
            }
            return param;
        }
        /// <summary>
        /// Gets the type of the db.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Type GetDbType(DataProvider provider)
        {
            Type returnType = null;
            switch (provider)
            {
                case DataProvider.SQLServer:
                    returnType = typeof(SqlDbType);
                    break;
                case DataProvider.Oracle:
                    //returnType = typeof(OracleType);
                    break;
                case DataProvider.Odbc:
                    returnType = typeof(OdbcType);
                    break;
                case DataProvider.OleDb:
                    returnType = typeof(OleDbType);
                    break;
                default:
                    break;
            }

            return returnType;
        }
        /// <summary>
        /// Creates the parameters.
        /// </summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="paramCount">The param count.</param>
        /// <returns></returns>
        public static DbParameter[] CreateParameters(DataProvider dataType, int paramCount)
        {
            DbParameter[] param = new DbParameter[paramCount];
            int i = 0;
            switch (dataType)
            {
                case DataProvider.SQLServer:
                    for (i = 0; i < paramCount; i++)
                    {
                        param[i] = new SqlParameter();
                        param[i].Direction = ParameterDirection.InputOutput;
                    }
                    break;
                case DataProvider.Oracle:
                    break;
                case DataProvider.Odbc:
                    for (i = 0; i < paramCount; i++)
                    {
                        param[i] = new OdbcParameter();
                        param[i].Direction = ParameterDirection.InputOutput;
                    }
                    break;
                case DataProvider.OleDb:
                    for (i = 0; i < paramCount; i++)
                    {
                        param[i] = new OleDbParameter();
                        param[i].Direction = ParameterDirection.InputOutput;
                    }
                    break;
                default:
                    break;
            }

            return param;
        }

        /// <summary>
        /// Converts the dot net type to SQL db type.
        /// </summary>
        /// <param name="dotNetType">Type of the dot net.</param>
        /// <returns></returns>
        public static SqlDbType ConvertDotNetTypeToSqlDbType(Type dotNetType)
        {
            SqlParameter param = new SqlParameter();
            System.ComponentModel.TypeConverter tc;
            tc = System.ComponentModel.TypeDescriptor.GetConverter(param.SqlDbType);

            if (tc.CanConvertFrom(dotNetType))
                param.SqlDbType = (SqlDbType)tc.ConvertFrom(dotNetType.Name);
            else
            {
                try
                {
                    param.SqlDbType = (SqlDbType)tc.ConvertFrom(dotNetType.Name);
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("Không thể chuyển đổi kiểu {0} sang SqlDbType", dotNetType), ex);
                }
            }

            return param.SqlDbType;
        }

        /// <summary>
        /// Converts the dot net type to db type.
        /// </summary>
        /// <param name="dotNetType">Type of the dot net.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DbType ConvertDotNetTypeToDbType(Type dotNetType, DataProvider provider)
        {
            DbParameter param = CreateParameter(provider);
            System.ComponentModel.TypeConverter tc;
            tc = System.ComponentModel.TypeDescriptor.GetConverter(param.DbType);

            if (tc.CanConvertFrom(dotNetType))
                param.DbType = (DbType)tc.ConvertFrom(dotNetType.Name);
            else
            {
                try
                {
                    param.DbType = (DbType)tc.ConvertFrom(dotNetType.Name);
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("Không thể chuyển đổi kiểu {0} sang DbType", dotNetType), ex);
                }
            }

            return param.DbType;
        }
        /// <summary>
        /// Gets the type by name.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static Type GetTypeByName(string typeName)
        {
            Type returnValue = Type.GetType(typeName);

            return returnValue;
        }


    }
}
