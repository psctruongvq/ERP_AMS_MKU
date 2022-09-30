
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChamNgoaiGioChuaDuyetChild : Csla.ReadOnlyBase<ChamNgoaiGioChuaDuyetChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKyTinhLuong = 0;
        private int _maBoPhan = 0;
        private int _maKyChamCong = 0;
        private string _kyLuong = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _kyCham = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaKyTinhLuong
        {
            get
            {
                return _maKyTinhLuong;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaKyChamCong
        {
            get
            {
                return _maKyChamCong;
            }
        }

        public string KyLuong
        {
            get
            {
                return _kyLuong;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public string KyCham
        {
            get
            {
                return _kyCham;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}:{2}:{3}", _maKyTinhLuong, _maBoPhan, _maKyChamCong, _kyCham);
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChamNgoaiGioChuaDuyetChild GetChamNgoaiGioChuaDuyetChild(SafeDataReader dr)
        {
            return new ChamNgoaiGioChuaDuyetChild(dr);
        }

        private ChamNgoaiGioChuaDuyetChild(SafeDataReader dr)
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
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maKyChamCong = dr.GetInt32("MaKyChamCong");
            _kyLuong = dr.GetString("KyLuong");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _kyCham = dr.GetString("KyCham");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
