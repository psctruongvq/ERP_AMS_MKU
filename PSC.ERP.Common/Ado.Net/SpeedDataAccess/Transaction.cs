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
        //public void BeginTransaction()
        //{
        //    if (this.Connection != null && this.Connection.State == ConnectionState.Open && _trans == null)
        //        _trans = this.Connection.BeginTransaction();
        //    else
        //    {
        //        this.Open();
        //        _trans = this.Connection.BeginTransaction();
        //    }
        //}

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="level">The level.</param>
        public void BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            if (this.Connection != null && this.Connection.State == ConnectionState.Open && _trans == null)
                _trans = this.Connection.BeginTransaction(level);
            else
            {
                this.OpenConnection();
                _trans = this.Connection.BeginTransaction(level);
            }
        }
        /// <summary>
        /// Lưu lại những thay đổi lên database
        /// </summary>
        public void CommitTransaction()
        {
            if (_trans != null)
                _trans.Commit();
            _trans = null;
            this.CloseConnection();
        }
        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        public void RollbackTransaction()
        {
            if (_trans != null)
                _trans.Rollback();
            _trans = null;
            this.CloseConnection();
        }
        /// <summary>
        /// Determines whether [is in transaction].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is in transaction]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInTransaction()
        {
            return (_trans != null);
        }
    }
}
