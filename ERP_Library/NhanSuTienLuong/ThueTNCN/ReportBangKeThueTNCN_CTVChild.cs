
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangKeThueTNCN_CTVChild : Csla.ReadOnlyBase<BangKeThueTNCN_CTVChild>
    {
        #region Business Properties and Methods

        //declare members
        private string _hoTen = string.Empty;
        private string _mst = string.Empty;
        private string _cmnd = string.Empty;
        private decimal _thuNhapChiuThue = 0;
        private decimal _thueDaKhauTru = 0;
        private string _soChungTu = string.Empty;
        private DateTime _ngayLap = DateTime.Today;
        private string _nguoiLap = string.Empty;
        private string _dienGiai = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public string HoTen
        {
            get
            {
                return _hoTen;
            }
        }

        public string Mst
        {
            get
            {
                return _mst;
            }
        }

        public string Cmnd
        {
            get
            {
                return _cmnd;
            }
        }

        public decimal ThuNhapChiuThue
        {
            get
            {
                return _thuNhapChiuThue;
            }
        }

        public decimal ThueDaKhauTru
        {
            get
            {
                return _thueDaKhauTru;
            }
        }

        public string SoChungTu
        {
            get
            {
                return _soChungTu;
            }
        }
        public DateTime NgayLap
        {
            get
            {
                return _ngayLap;
            }
        }
        public string NguoiLap
        {
            get
            {
                return _nguoiLap;
            }
        }

        public string DienGiai
        {
            get
            {
                return _dienGiai;
            }
        }
        protected override object GetIdValue()
        {
            return _hoTen;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static BangKeThueTNCN_CTVChild GetBangKeThueTNCN_CTVChild(SafeDataReader dr)
        {
            return new BangKeThueTNCN_CTVChild(dr);
        }

        private BangKeThueTNCN_CTVChild(SafeDataReader dr)
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
            _hoTen = dr.GetString("HoTen");
            _mst = dr.GetString("MST");
            _cmnd = dr.GetString("CMND");
            _thuNhapChiuThue = dr.GetDecimal("ThuNhapChiuThue");
            _thueDaKhauTru = dr.GetDecimal("ThueDaKhauTru");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayLap = dr.GetDateTime("NgayLap");
            _nguoiLap = dr.GetString("NguoiLap");
            _dienGiai = dr.GetString("DienGiai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
