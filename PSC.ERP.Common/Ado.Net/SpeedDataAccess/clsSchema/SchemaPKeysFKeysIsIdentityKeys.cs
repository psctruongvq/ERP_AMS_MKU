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
            public struct KeyInfo
            {
                public String KeyName;
                public Int32 ColumnSize;
                public String DBTypeName;
                public String DotNetTypeName;
                public Type DotNetType;
                public Boolean IsPrimaryKey;
                public Boolean IsIdentity;
                public Boolean IsForeignKey;
                public Boolean AllowDBNull;
                public Int32 NumericPrecision;
                public Int32 NumericScale;
                public ForeignKeyInfo FKeyInfo;
            }
            /// <summary>
            /// Luu thong tin cua mot foreign key
            /// </summary>
            public struct ForeignKeyInfo
            {
                public String FKCOLUMN_NAME;
                public String FKTABLE_NAME;

                public String PKCOLUMN_NAME;
                public String PKTABLE_NAME;
            }
            public ForeignKeyInfo InfoOfForeignKey(String tableName, string fKey)
            {
                ForeignKeyInfo returnValue = new ForeignKeyInfo();
                DataTable table = this.SchemaFKeysLinkToOtherTable(tableName);
                DataRow[] rows = table.Select(String.Format("FKCOLUMN_NAME='{0}'", fKey));
                if (rows.Length > 0)
                {
                    DataRow row = rows[0];
                    returnValue.FKCOLUMN_NAME = row["FKCOLUMN_NAME"].ToString();
                    returnValue.FKTABLE_NAME = row["FKTABLE_NAME"].ToString();
                    returnValue.PKCOLUMN_NAME = row["PKCOLUMN_NAME"].ToString();
                    returnValue.PKTABLE_NAME = row["PKTABLE_NAME"].ToString();
                }
                return returnValue;
            }
            public ForeignKeyInfo[] ForeignKeysLinkToOtherTable(String tableName, string anything)
            {
                ForeignKeyInfo[] returnValue = null;
                DataTable schema = this.SchemaFKeysLinkToOtherTable(tableName);
                returnValue = new ForeignKeyInfo[schema.Rows.Count];
                for (int i = 0; i < schema.Rows.Count; i++)
                {
                    returnValue[i].FKCOLUMN_NAME = schema.Rows[i]["FKCOLUMN_NAME"].ToString();
                    returnValue[i].FKTABLE_NAME = schema.Rows[i]["FKTABLE_NAME"].ToString();

                    returnValue[i].PKCOLUMN_NAME = schema.Rows[i]["PKCOLUMN_NAME"].ToString();
                    returnValue[i].PKTABLE_NAME = schema.Rows[i]["PKTABLE_NAME"].ToString();


                }
                return returnValue;
            }
            public ForeignKeyInfo[] ForeignKeysLinkToThisTable(String tableName, string anything)
            {
                ForeignKeyInfo[] returnValue = null;
                DataTable schema = this.SchemaFKeysLinkToThisTable(tableName);
                returnValue = new ForeignKeyInfo[schema.Rows.Count];
                for (int i = 0; i < schema.Rows.Count; i++)
                {
                    returnValue[i].FKCOLUMN_NAME = schema.Rows[i]["FKCOLUMN_NAME"].ToString();
                    returnValue[i].FKTABLE_NAME = schema.Rows[i]["FKTABLE_NAME"].ToString();

                    returnValue[i].PKCOLUMN_NAME = schema.Rows[i]["PKCOLUMN_NAME"].ToString();
                    returnValue[i].PKTABLE_NAME = schema.Rows[i]["PKTABLE_NAME"].ToString();


                }
                return returnValue;
            }
            public DataTable SchemaFKeysLinkToOtherTable(String tableName)
            {
                DataTable returnValue = this._dataAccess.GetListByStoreProcedure("sp_fkeys", "fktable_name", tableName);
                return returnValue;
            }
            public DataTable SchemaFKeysLinkToThisTable(String tableName)
            {
                DataTable returnValue = this._dataAccess.GetListByStoreProcedure("sp_fkeys", "pktable_name", tableName);
                return returnValue;
            }
            public String[] PrimaryKeys(string tableName)
            {
                String[] returnValue = null;
                try
                {
                    String primaryKeys = "";
                    DataTable isKeySchemaTable = this.SchemaOfTable(tableName);
                    DataRow[] primaryRows = isKeySchemaTable.Select("IsKey='True'");
                    foreach (DataRow row in primaryRows)
                    {
                        primaryKeys += row["ColumnName"] + ",";
                    }
                    if (primaryKeys != "")
                    {
                        primaryKeys = primaryKeys.Substring(0, primaryKeys.Length - 1);
                        returnValue = primaryKeys.Split(',');
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return returnValue;
            }
            public bool CheckIsForeignkey(String tableName, String key)
            {

                DataTable schema = this._dataAccess.GetListByStoreProcedure("sp_fkeys", "fktable_name", tableName);
                //kiem tra
                DataRow[] rows = schema.Select(String.Format("FKCOLUMN_NAME='{0}'", key));
                if (rows.Length > 0)
                {
                    return true;
                }
                //kiem tra kieu khac
                //foreach (DataRow row in schema.Rows)
                //{
                //    if (row["FKCOLUMN_NAME"].ToString().ToUpper() == key.ToUpper())
                //    {
                //        return true;
                //    }
                //}
                return false;
            }
            public bool CheckIsPrimaryKey(string tableName, string columnName, DataTable primarySchema = null)
            {
                bool returnValue = false;
                try
                {
                    DataTable primarySchemaTable = null;
                    if (primarySchema != null)
                    {
                        primarySchemaTable = primarySchema;
                    }
                    else
                    {
                        primarySchemaTable = this.SchemaOfTable(tableName);
                    }

                    DataRow[] isIdentityRows = primarySchemaTable.Select(String.Format("IsKey='True' and ColumnName='{0}'", columnName));
                    if (isIdentityRows != null && isIdentityRows.Length > 0)
                    {
                        returnValue = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return returnValue;
            }
            public bool CheckIsIdentityKey(string tableName, string columnName, DataTable isIdentitySchema = null)
            {
                bool returnValue = false;
                try
                {
                    DataTable isIdentitySchemaTable = null;
                    if (isIdentitySchema != null)
                    {
                        isIdentitySchemaTable = isIdentitySchema;
                    }
                    else
                    {
                        isIdentitySchemaTable = this.SchemaOfTable(tableName);
                    }

                    DataRow[] isIdentityRows = isIdentitySchemaTable.Select(String.Format("IsIdentity='True' and ColumnName='{0}'", columnName));
                    if (isIdentityRows != null && isIdentityRows.Length > 0)
                    {
                        returnValue = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return returnValue;
            }
        }
    }
}