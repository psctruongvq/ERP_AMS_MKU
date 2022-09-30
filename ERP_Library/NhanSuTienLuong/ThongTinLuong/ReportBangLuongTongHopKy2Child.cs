
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class BangLuongTongHopKy2Child : Csla.ReadOnlyBase<BangLuongTongHopKy2Child>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private int _soNV = 0;
        private decimal _heSoCoBan = 0;
        private decimal _heSoPhuCap = 0;
        private decimal _heSoVuotKhung = 0;
        private decimal _luongKy1 = 0;
        private decimal _luongThamNien = 0;
        private decimal _luongHeSo = 0;
        private decimal _congKhac = 0;
        private decimal _tongThuNhap = 0;
        private decimal _thueTNCN = 0;
        private decimal _cacKhoanDaLinh = 0;
        private decimal _thueDaTamThu = 0;
        private decimal _thucLanh = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public int SoNV
        {
            get
            {
                return _soNV;
            }
        }

        public decimal HeSoCoBan
        {
            get
            {
                return _heSoCoBan;
            }
        }

        public decimal HeSoPhuCap
        {
            get
            {
                return _heSoPhuCap;
            }
        }

        public decimal HeSoVuotKhung
        {
            get
            {
                return _heSoVuotKhung;
            }
        }

        public decimal LuongKy1
        {
            get
            {
                return _luongKy1;
            }
        }

        public decimal LuongThamNien
        {
            get
            {
                return _luongThamNien;
            }
        }

        public decimal LuongHeSo
        {
            get
            {
                return _luongHeSo;
            }
        }

        public decimal CongKhac
        {
            get
            {
                return _congKhac;
            }
        }

        public decimal TongThuNhap
        {
            get
            {
                return _tongThuNhap;
            }
        }

        public decimal ThueTNCN
        {
            get
            {
                return _thueTNCN;
            }
        }

        public decimal CacKhoanDaLinh
        {
            get
            {
                return _cacKhoanDaLinh;
            }
        }

        public decimal ThueDaTamThu
        {
            get
            {
                return _thueDaTamThu;
            }
        }

        public decimal ThucLanh
        {
            get
            {
                return _thucLanh;
            }
        }

        protected override object GetIdValue()
        {
            return _maBoPhan;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static BangLuongTongHopKy2Child GetBangLuongTongHopKy2Child(SafeDataReader dr)
        {
            return new BangLuongTongHopKy2Child(dr);
        }

        private BangLuongTongHopKy2Child(SafeDataReader dr)
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
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _soNV = dr.GetInt32("SoNV");
            _heSoCoBan = dr.GetDecimal("HeSoCoBan");
            _heSoPhuCap = dr.GetDecimal("HeSoPhuCap");
            _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
            _luongKy1 = dr.GetDecimal("LuongKy1");
            _luongThamNien = dr.GetDecimal("LuongThamNien");
            _luongHeSo = dr.GetDecimal("LuongHeSo");
            _congKhac = dr.GetDecimal("CongKhac");
            _tongThuNhap = dr.GetDecimal("TongThuNhap");
            _thueTNCN = dr.GetDecimal("ThueTNCN");
            _cacKhoanDaLinh = dr.GetDecimal("CacKhoanDaLinh");
            _thueDaTamThu = dr.GetDecimal("ThueDaTamThu");
            _thucLanh = dr.GetDecimal("ThucLanh");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
