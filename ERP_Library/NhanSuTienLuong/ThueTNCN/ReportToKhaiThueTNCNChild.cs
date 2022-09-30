
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ToKhaiThueTNCNChild : Csla.ReadOnlyBase<ToKhaiThueTNCNChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maCongTy = 0;
        private string _tenCongTy = string.Empty;
        private string _maSoThue = string.Empty;
        private string _diaChi = string.Empty;
        private string _dienThoai = string.Empty;
        private string _fax = string.Empty;
        private decimal _tongtnctNv = 0;
        private decimal _tongtnctNvkhautru = 0;
        private decimal _thuetncnNv = 0;
        private decimal _tongtnctCtv = 0;
        private decimal _tongtnctCtvkhautru = 0;
        private decimal _thuetncnCtv = 0;
        private string _nguoiky = "";
        private int _tongSoNVnCoKhauTruThue = 0;

        public int TongSoNVnCoKhauTruThue
        {
            get { return _tongSoNVnCoKhauTruThue; }
            set { _tongSoNVnCoKhauTruThue = value; }
        }


        private int _tongSoNhanVien = 0;

        public int TongSoNhanVien
        {
            get { return _tongSoNhanVien; }
            set { _tongSoNhanVien = value; }
        }

        private decimal _tongTNCTCoKhauTruThue = 0;

        public decimal TongTNCTCoKhauTruThue
        {
            get { return _tongTNCTCoKhauTruThue; }
            set { _tongTNCTCoKhauTruThue = value; }
        }
        [System.ComponentModel.DataObjectField(true, false)]
        public int MaCongTy
        {
            get
            {
                return _maCongTy;
            }
        }

        public string TenCongTy
        {
            get
            {
                return _tenCongTy;
            }
        }

        public string MaSoThue
        {
            get
            {
                return _maSoThue;
            }
        }

        public string DiaChi
        {
            get
            {
                return _diaChi;
            }
        }

        public string DienThoai
        {
            get
            {
                return _dienThoai;
            }
        }

        public string Fax
        {
            get
            {
                return _fax;
            }
        }

        public string NguoiKy
        {
            get
            {
                return _nguoiky;
            }
        }

        public decimal TongtnctNv
        {
            get
            {
                return _tongtnctNv;
            }
        }

        public decimal TongtnctNvkhautru
        {
            get
            {
                return _tongtnctNvkhautru;
            }
        }

        public decimal ThuetncnNv
        {
            get
            {
                return _thuetncnNv;
            }
        }

        public decimal TongtnctCtv
        {
            get
            {
                return _tongtnctCtv;
            }
        }

        public decimal TongtnctCtvkhautru
        {
            get
            {
                return _tongtnctCtvkhautru;
            }
        }

        public decimal ThuetncnCtv
        {
            get
            {
                return _thuetncnCtv;
            }
        }

        protected override object GetIdValue()
        {
            return _maCongTy;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ToKhaiThueTNCNChild GetToKhaiThueTNCNChild(SafeDataReader dr)
        {
            return new ToKhaiThueTNCNChild(dr);
        }

        private ToKhaiThueTNCNChild(SafeDataReader dr)
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
            _maCongTy = dr.GetInt32("MaCongTy");
            _tenCongTy = dr.GetString("TenCongTy");
            _maSoThue = dr.GetString("MaSoThue");
            _diaChi = dr.GetString("DiaChi");
            _dienThoai = dr.GetString("DienThoai");
            _fax = dr.GetString("Fax");
            _tongtnctNv = dr.GetDecimal("TongTNCT_NV");
            _tongtnctNvkhautru = dr.GetDecimal("TongTNCT_NVKhauTru");
            _thuetncnNv = dr.GetDecimal("ThueTNCN_NV");
            _tongtnctCtv = dr.GetDecimal("TongTNCT_CTV");
            _tongtnctCtvkhautru = dr.GetDecimal("TongTNCT_CTVKhauTru");
            _thuetncnCtv = dr.GetDecimal("ThueTNCN_CTV");
            _nguoiky = dr.GetString("NguoiKy");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
