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
        #region ExecuteReader
        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.Text
            , CommandBehavior commandBehavior = CommandBehavior.CloseConnection, DbParameter[] parameters = null)
        {
            DbDataReader returnValue = null;
            Boolean allowLocalTransaction = false;
            try
            {
                //chu y khong duoc su dung transaction trong ham nay
                this.PrepareAll(commandText, commandType, command: null, parametersWithValue: parameters, initTransaction: allowLocalTransaction, isolationLevel: IsolationLevel.RepeatableRead);
                returnValue = this.Command.ExecuteReader(commandBehavior);
                if (allowLocalTransaction)
                    this.CommitTransaction();

            }
            catch (Exception ex)
            {
                this.CloseConnection();

            }
            finally
            {
                //không được đóng kết nối tại đây, vì kết quả trả về cần kết nối để truy vấn tiếp ở các hàm gọi ExecDataReader này

            }
            return returnValue;
        }
        #endregion

    }
}
