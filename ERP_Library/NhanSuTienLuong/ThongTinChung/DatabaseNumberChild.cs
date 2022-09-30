
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DatabaseNumberChild : Csla.ReadOnlyBase<DatabaseNumberChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _databaseNumber = 0;
        private string _tenDatabase = string.Empty;
        private string _ghiChu = string.Empty;
        private string _ten = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int DatabaseNumber
        {
            get
            {
                return _databaseNumber;
            }
        }

        public string TenDatabase
        {
            get
            {
                return _tenDatabase;
            }
        }

        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
        }

        public string Ten
        {
            get
            {
                return _ten;
            }
        }

        protected override object GetIdValue()
        {
            return _databaseNumber;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static DatabaseNumberChild GetDatabaseNumberChild(SafeDataReader dr)
        {
            return new DatabaseNumberChild(dr);
        }

        private DatabaseNumberChild(SafeDataReader dr)
        {
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _databaseNumber = dr.GetInt32("DatabaseNumber");
            _tenDatabase = dr.GetString("TenDatabase");
            _ghiChu = dr.GetString("GhiChu");
            _ten = dr.GetString("Ten");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
