
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NgayTinhThueTamThuChild : Csla.ReadOnlyBase<NgayTinhThueTamThuChild>
    {
        #region Business Properties and Methods

        //declare members
        private DateTime _ngayLap = DateTime.Today;

        [System.ComponentModel.DataObjectField(true, false)]
        public DateTime NgayLap
        {
            get
            {
                return _ngayLap.Date;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public string NgayLapString
        {
            get
            {
                return _ngayLap.ToString("dd/MM/yyyy");
            }
        }

        protected override object GetIdValue()
        {
            return _ngayLap;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static NgayTinhThueTamThuChild GetNgayTinhThueTamThuChild(SafeDataReader dr)
        {
            return new NgayTinhThueTamThuChild(dr);
        }

        private NgayTinhThueTamThuChild(SafeDataReader dr)
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
            _ngayLap = dr.GetDateTime("NgayLap");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
