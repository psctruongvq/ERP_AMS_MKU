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
        /// Fills the value for out put.
        /// </summary>
        /// <param name="outPut">The out put.</param>
        private void FillValueForOutPut(Hashtable outPut)
        {
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
        /// <summary>
        /// Removes the SQL injection.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string RemoveSQLInjection(string data)
        {
            if (data.Equals(""))
            { return data; }
            string replaceData = data;
            replaceData = replaceData.Replace("'", "''");
            replaceData = replaceData.Replace("--", "");
            return replaceData;
        }
        private static Object GetMinOrNullValueOfSomeDotNetType(String dotNetTypeName)
        {//dang test
            Object returnValue = null;


            switch (dotNetTypeName)
            {
                case "System.Single":
                    returnValue = System.Single.MinValue;
                    break;
                case "System.Double":
                    returnValue = System.Double.MinValue;
                    break;
                case "System.Decimal":
                    returnValue = System.Decimal.MinValue;
                    break;
                case "System.DateTime":
                    returnValue = System.DateTime.MinValue;
                    break;
                case "System.DateTimeOffset":
                    returnValue = System.DateTimeOffset.MinValue;
                    break;
                case "System.TimeSpan":
                    returnValue = System.TimeSpan.MinValue;
                    break;
                case "System.Byte":
                    returnValue = System.Byte.MinValue;
                    break;
                case "System.SByte":
                    returnValue = System.SByte.MinValue;
                    break;
                case "System.Int16":
                    returnValue = System.Int16.MinValue;
                    break;
                case "System.Int32":
                    returnValue = System.Int32.MinValue;
                    break;
                case "System.Int64":
                    returnValue = System.Int64.MinValue;
                    break;
                case "System.UInt16":
                    returnValue = System.UInt16.MinValue;
                    break;
                case "System.UInt32":
                    returnValue = System.UInt32.MinValue;
                    break;
                case "System.UInt64":
                    returnValue = System.UInt64.MinValue;
                    break;
                default:
                    break;
            }


            return returnValue;
        }


        private static void DetermineUsefullParameters(ref DbParameter[] mainParameters, string parametersInput, DbParameter[] cacheParameters)
        {
            char[] splitChars = { ',', ';', '|' };
            string[] strArr = parametersInput.Split(splitChars);
            int index = 0;
            foreach (DbParameter par in cacheParameters)
                foreach (string s in strArr)
                    if (s.Replace("@", "").ToLower() == par.ParameterName.Replace("@", "").ToLower())
                    {
                        mainParameters[index].ParameterName = par.ParameterName;
                        mainParameters[index].Size = par.Size;
                        mainParameters[index].Direction = par.Direction;
                        mainParameters[index++].DbType = par.DbType;
                    }
        }

        /// <summary>
        /// Determines the usefull parameters.
        /// </summary>
        /// <param name="mainParameters">The main parameters.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="cacheParameters">The cache parameters.</param>
        private static void DetermineUsefullParameters(ref DbParameter[] mainParameters, string[] parameterName, DbParameter[] cacheParameters)
        {
            int index = 0;//cai nay rat quan trong
            for (int i = 0; i < cacheParameters.Length; i++)
            {
                for (int j = 0; j < parameterName.Length; j++)
                {
                    if (parameterName[j].Replace("@", "").ToLower() == cacheParameters[i].ParameterName.Replace("@", "").ToLower())
                    {
                        mainParameters[index].ParameterName = cacheParameters[i].ParameterName;
                        mainParameters[index].Size = cacheParameters[i].Size;
                        mainParameters[index].Direction = cacheParameters[i].Direction;
                        mainParameters[index++].DbType = cacheParameters[i].DbType;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Assigns the parameter values.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="parametersWithValue">The parameters with value.</param>
        private static void AssignParameterValues(ref DbParameter[] parameters, DbParameter[] parametersWithValue)
        {
            if ((parameters != null) && (parametersWithValue != null))
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    for (int j = 0; j < parametersWithValue.Length; j++)
                    {
                        if (parameters[i].ParameterName.ToLower() == parametersWithValue[j].ParameterName.ToLower())
                        {
                            parameters[i].Value = parametersWithValue[i].Value;
                            break;
                        }
                        else
                            parameters[i].Value = DBNull.Value;
                    }
                }
            }
            else
            {
                throw new Exception("khong the assign value");
            }
        }

        /// <summary>
        /// Assigns the parameter values.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="parametersValue">The parameters value.</param>
        private static void AssignParameterValues(ref DbParameter[] parameters, object[] parametersValue)
        {
            if ((parameters != null) && (parametersValue != null))
            {
                if (parameters.Length <= parametersValue.Length)
                {
                    //gan thuoc tinh value cho tat ca phan tu trong parameters
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i].Value = parametersValue[i];
                    }
                }
                else
                {
                    int i = 0;//bien nay rat quan trong
                    for (i = 0; i < parametersValue.Length; i++)
                    {
                        parameters[i].Value = parametersValue[i];
                    }
                    //phan du thua cua parametes can duoc gan thuoc tinh value = null;
                    if (i < parameters.Length)
                        for (; i < parameters.Length; i++)
                            parameters[i].Value = DBNull.Value;
                }
            }
            else
            {
                throw new Exception("khong the assign value");
            }
        }

        /// <summary>
        /// Assigns the parameter values.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="parametersName">Name of the parameters.</param>
        /// <param name="parametersValue">The parameters value.</param>
        private static void AssignParameterValues(ref DbParameter[] parameters, String[] parametersName, object[] parametersValue)
        {
            if ((parameters != null) && (parametersValue != null) && parametersName != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    for (int j = 0; j < parametersName.Length; j++)
                    {
                        if (parameters[i].ParameterName.Replace("@", "").ToLower() == parametersName[j].Replace("@", "").ToLower())
                        {
                            if (j < parametersValue.Length)
                            {
                                parameters[i].Value = parametersValue[j];
                            }
                            break;//thoat khoi vong lap j
                        }
                        else
                        {
                            parameters[i].Value = DBNull.Value;
                        }
                    }

                }
            }
            else
            {
                throw new Exception("khong the assign value");
            }
        }
    }
}
