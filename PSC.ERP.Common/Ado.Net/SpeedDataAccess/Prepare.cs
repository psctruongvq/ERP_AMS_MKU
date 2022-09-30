using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace PSC_ERP_Common.Ado.Net
{
    partial class SpeedDataAccess
    {
        /// <summary>
        /// Prepares all.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="command">The command.</param>
        /// <param name="parametersWithValue">The parameters with value.</param>
        /// <param name="initTransaction">if set to <c>true</c> [init transaction].</param>
        /// <param name="isolationLevel">The isolation level.</param>
        protected void PrepareAll(string commandText
            , CommandType commandType
            , DbCommand command = null, DbParameter[] parametersWithValue = null
            , bool initTransaction = false
            , IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            //mo ket noi truoc
            this.OpenConnection();
            if (command == null)
            {
                //tao moi command
                this.Command = Factory.CreateCommand(commandText, commandType, this.CommandTimeout, this.Provider, this.Connection, parametersWithValue);
            }
            else//command != null
            {
                //xai cai da co, gan thuoc tinh moi
                this.Command = command;
                this.Command.CommandText = commandText;
                this.Command.CommandType = commandType;
                this.Command.CommandTimeout = this.CommandTimeout;
                this.Command.Connection = this.Connection;
                if (parametersWithValue != null)
                {
                    //DbParameter[] range = new DbParameter[parametersWithValue.Length];
                    //parametersWithValue.CopyTo(range, 0);
                    ////chuan hoa du lieu
                    //for (int i = 0; i < range.Length; i++)
                    //{
                    //    String paraType = range[i].Value.GetType().ToString();
                    //    Object minOrNullValue = this.GetMinOrNullValueOfSomeDotNetType(paraType);
                    //    if (Equals(range[i].Value, minOrNullValue))
                    //    {
                    //        range[i].Value = DBNull.Value;
                    //    }
                    //}
                    //this.Command.Parameters.AddRange(range);


                    this.Command.Parameters.AddRange(parametersWithValue);
                }
            }
            if (initTransaction == true)
            {
                this.BeginTransaction(isolationLevel);
                this.Command.Transaction = this._trans;
            }
        }
    }
}
