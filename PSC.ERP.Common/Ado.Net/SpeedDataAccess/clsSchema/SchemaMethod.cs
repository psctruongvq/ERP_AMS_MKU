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
        public partial class ClsSchema
        {

            /// <summary>
            /// Dot net type of column.
            /// </summary>
            /// <param name="columnName">Name of the column.</param>
            /// <param name="tableName">Name of the table.</param>
            /// <returns></returns>
            public Type DotNetTypeOfColumn(string columnName, string tableName)
            {
                Type returnValue = null;
                DataTable fullSchemaStable = this.SchemaOfTable(tableName);
                DataRow[] rows = fullSchemaStable.Select(String.Format("ColumnName='{0}'", columnName));
                String dataTypeNameSpace = rows[0]["DataType"].ToString();
                returnValue = Type.GetType(dataTypeNameSpace);
                return returnValue;
            }
            /// <summary>
            /// List of table on current database (base table and view)
            /// </summary>
            /// <returns></returns>
            public DataTable SchemaTables()
            {
                DataTable returnValue = this.SchemaBySchemaColection(SchemaColection.Tables);
                return returnValue;
            }
            /// <summary>
            /// Schemas the base tables.
            /// </summary>
            /// <returns></returns>
            public DataTable SchemaBaseTables()
            {
                
                DataTable returnValue = this.SchemaBySchemaColection(SchemaColection.Tables);
                DataRow[] oldRows = new DataRow[returnValue.Rows.Count];
                returnValue.Rows.CopyTo(oldRows, 0);
                DataRow[] useful = returnValue.Select("TABLE_TYPE='BASE TABLE'");

                
                useful.CopyToDataTable<DataRow>(returnValue, System.Data.LoadOption.OverwriteChanges);
                foreach (DataRow r in oldRows)
                {
                    returnValue.Rows.Remove(r);
                }

                
                return returnValue;
            }
            /// <summary>
            /// Base table names of DB.
            /// </summary>
            /// <returns></returns>
            public String[] BaseTableNamesOfDB()
            {//ham co ban
                String[] returnValue = null;
                String tableNames = "";
                DataTable schema = this.SchemaBySchemaColection(SchemaColection.Tables);
                DataRow[] rows = schema.Select("TABLE_TYPE = 'BASE TABLE'");
                foreach (DataRow row in rows)
                {
                    tableNames += row["TABLE_NAME"].ToString() + ",";
                }
                if (tableNames != "")
                {
                    tableNames = tableNames.Substring(0, tableNames.Length - 1);
                    returnValue = tableNames.Split(',');
                }
                return returnValue;
            }
            /// <summary>
            /// All databases.
            /// </summary>
            /// <returns></returns>
            public String[] AllDatabases()
            {
                String[] returnValue = null;
                DataTable schema = this.SchemaByColectionName("Databases");
                String databaseNames = "";
                foreach (DataRow row in schema.Rows)
                {
                    databaseNames += row["database_name"] + ", ";
                }
                databaseNames = databaseNames.Substring(0, databaseNames.Length - 2);
                returnValue = databaseNames.Split(',');
                return returnValue;
            }
            /// <summary>
            /// List of database on current server
            /// </summary>
            /// <returns></returns>
            public DataTable SchemaOfDatabases()
            {
                DataTable returnValue = this.SchemaBySchemaColection(SchemaColection.Databases);
                return returnValue;
            }

            /// <summary>
            /// Schemas by colection name.
            /// </summary>
            /// <param name="colectionName">AllColumns
            /// Columns
            /// ColumnSetColumns
            /// Databases
            /// DataSourceInformation
            /// DataTypes
            /// ForeignKeys
            /// IndexColumns
            /// Indexes
            /// MetaDataCollections
            /// ProcedureParameters
            /// Procedures
            /// ReservedWords
            /// Restrictions
            /// StructuredTypeMembers
            /// Tables//base table and view
            /// UserDefinedTypes
            /// Users
            /// ViewColumns
            /// Views</param>
            /// <returns></returns>
            public DataTable SchemaByColectionName(string colectionName)
            {
                DataTable returnValue = null;
                try
                {
                    this._dataAccess.OpenConnection();
                    returnValue = new DataTable();
                    returnValue = this._dataAccess.Connection.GetSchema(colectionName);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    this._dataAccess.CloseConnection();
                }
                return returnValue;
            }
            public DataTable SchemaBySchemaColection(SchemaColection schemaColection)
            {
                DataTable returnValue = SchemaByColectionName(schemaColection.ToString());
                return returnValue;
            }
            public DataColumn[] DataColumnsOfTable(String tableName)
            {
                DataColumn[] dataColumns = null;
                String[] columnNamesArr = null;
                String columnNames = "";
                DataTable schema = this.SchemaOfTable(tableName);
                foreach (DataRow row in schema.Rows)
                {
                    columnNames += row["ColumnName"] + ",";
                }
                if (columnNames != "")
                {
                    columnNames = columnNames.Substring(0, columnNames.Length - 1);
                    columnNamesArr = columnNames.Split(',');
                }
                dataColumns = new DataColumn[columnNamesArr.Length];
                for (int i = 0; i < dataColumns.Length; i++)
                {
                    dataColumns[i].ColumnName = columnNamesArr[i];
                }

                return dataColumns;
            }
            public String[] ColumnNamesOfTable(String tableName)
            {//ham co ban
                String[] returnValue = null;
                String columnNames = "";
                DataTable schema = this.SchemaOfTable(tableName);
                foreach (DataRow row in schema.Rows)
                {
                    columnNames += row["ColumnName"].ToString() + ",";
                }
                if (columnNames != "")
                {
                    columnNames = columnNames.Substring(0, columnNames.Length - 1);
                    returnValue = columnNames.Split(',');
                }
                return returnValue;
            }
            public String[] ColumnNamesOfKeyInfos(KeyInfo[] keyInfos)
            {
                String[] returnValue = null;
                String columnNames = "";
                for (int i = 0; i < keyInfos.Length; i++)
                {
                    columnNames += keyInfos[i].KeyName + ",";
                }
                if (columnNames != "")
                {
                    columnNames = columnNames.Substring(0, columnNames.Length - 1);
                    returnValue = columnNames.Split(',');
                }
                return returnValue;
            }

            public KeyInfo[] KeyInfosOfTable(string tableName)
            {
                KeyInfo[] keyInfos = null;

                DataTable shema = this.SchemaOfTable(tableName);
                keyInfos = new KeyInfo[shema.Rows.Count];
                int index = 0;
                foreach (DataRow row in shema.Rows)
                {
                    keyInfos[index].KeyName = row["ColumnName"].ToString();
                    keyInfos[index].ColumnSize = (Int32)row["ColumnSize"];
                    keyInfos[index].DBTypeName = row["DataTypeName"].ToString();
                    keyInfos[index].DotNetTypeName = row["DataType"].ToString();
                    keyInfos[index].DotNetType = Factory.GetTypeByName(row["DataType"].ToString());
                    keyInfos[index].IsPrimaryKey = (Boolean)row["IsKey"];
                    keyInfos[index].IsIdentity = (Boolean)row["IsIdentity"];
                    keyInfos[index].AllowDBNull = (Boolean)row["AllowDBNull"];
                    keyInfos[index].NumericPrecision =Int32.Parse(row["NumericPrecision"].ToString());
                    keyInfos[index].NumericScale = Int32.Parse(row["NumericScale"].ToString());

                    if (CheckIsForeignkey(tableName, row["ColumnName"].ToString()))
                    {
                        keyInfos[index].IsForeignKey = true;
                        keyInfos[index].FKeyInfo = this.InfoOfForeignKey(tableName, fKey: row["ColumnName"].ToString());
                    }
                    else
                    {
                        keyInfos[index].IsForeignKey = false;
                    }
                    //
                    index++;

                }




                return keyInfos;
            }

            public String[] IdentityKeys(string tableName)
            {
                String[] returnValue = null;
                try
                {
                    String isIdentityKeys = "";
                    DataTable isIdentitySchemaTable = this.SchemaOfTable(tableName);
                    DataRow[] isIdentityRows = isIdentitySchemaTable.Select("IsIdentity='True'");
                    foreach (DataRow row in isIdentityRows)
                    {
                        isIdentityKeys += row["ColumnName"] + ",";
                    }
                    if (isIdentityKeys != "")
                    {
                        isIdentityKeys = isIdentityKeys.Substring(0, isIdentityKeys.Length - 1);
                        returnValue = isIdentityKeys.Split(',');
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                return returnValue;
            }
            /// <summary>
            /// Ham co ban
            /// </summary>
            /// <param name="tableName"></param>
            /// <returns></returns>
            public DataTable SchemaOfTable(string tableName)
            {//ham co ban
                DataSet ds = new DataSet();
                DataTable schema = new DataTable();
                DbDataReader reader = null;
                String commandText = "select * from " + Factory.ProtectName(tableName);
                try
                {
                    reader = (DbDataReader)this._dataAccess.ExecuteReader(commandText, CommandType.Text, CommandBehavior.KeyInfo);
                    schema = reader.GetSchemaTable();// fill tat ca cac column
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    reader.Close();
                }
                return schema;
            }

        }

    }
}
