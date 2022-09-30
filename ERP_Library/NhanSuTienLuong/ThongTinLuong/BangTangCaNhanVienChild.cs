
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BangTangCaNhanVienChild : Csla.ReadOnlyBase<BangTangCaNhanVienChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private decimal _ngay1 = 0;
        private decimal _ngay2 = 0;
        private decimal _ngay3 = 0;
        private decimal _ngay4 = 0;
        private decimal _ngay5 = 0;
        private decimal _ngay6 = 0;
        private decimal _ngay7 = 0;
        private decimal _ngay8 = 0;
        private decimal _ngay9 = 0;
        private decimal _ngay10 = 0;
        private decimal _ngay11 = 0;
        private decimal _ngay12 = 0;
        private decimal _ngay13 = 0;
        private decimal _ngay14 = 0;
        private decimal _ngay15 = 0;
        private decimal _ngay16 = 0;
        private decimal _ngay17 = 0;
        private decimal _ngay18 = 0;
        private decimal _ngay19 = 0;
        private decimal _ngay20 = 0;
        private decimal _ngay21 = 0;
        private decimal _ngay22 = 0;
        private decimal _ngay23 = 0;
        private decimal _ngay24 = 0;
        private decimal _ngay25 = 0;
        private decimal _ngay26 = 0;
        private decimal _ngay27 = 0;
        private decimal _ngay28 = 0;
        private decimal _ngay29 = 0;
        private decimal _ngay30 = 0;
        private decimal _ngay31 = 0;
        private string _tenChucVu = string.Empty;
        private decimal _SoGioTangCaNgayThuong = 0;
        private decimal _SoGioTangCaT7CN = 0;
        private decimal _SoGioTangCaNgayLe = 0;
        private decimal _TongSoGioTangCa = 0;

        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
        }

        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
        }

        public decimal Ngay1
        {
            get
            {
                CanReadProperty("Ngay1", true);
                return _ngay1;
            }
        }

        public decimal Ngay2
        {
            get
            {
                CanReadProperty("Ngay2", true);
                return _ngay2;
            }
        }

        public decimal Ngay3
        {
            get
            {
                CanReadProperty("Ngay3", true);
                return _ngay3;
            }
        }

        public decimal Ngay4
        {
            get
            {
                CanReadProperty("Ngay4", true);
                return _ngay4;
            }
        }

        public decimal Ngay5
        {
            get
            {
                CanReadProperty("Ngay5", true);
                return _ngay5;
            }
        }

        public decimal Ngay6
        {
            get
            {
                CanReadProperty("Ngay6", true);
                return _ngay6;
            }
        }

        public decimal Ngay7
        {
            get
            {
                CanReadProperty("Ngay7", true);
                return _ngay7;
            }
        }

        public decimal Ngay8
        {
            get
            {
                CanReadProperty("Ngay8", true);
                return _ngay8;
            }
        }

        public decimal Ngay9
        {
            get
            {
                CanReadProperty("Ngay9", true);
                return _ngay9;
            }
        }

        public decimal Ngay10
        {
            get
            {
                CanReadProperty("Ngay10", true);
                return _ngay10;
            }
        }

        public decimal Ngay11
        {
            get
            {
                CanReadProperty("Ngay11", true);
                return _ngay11;
            }
        }

        public decimal Ngay12
        {
            get
            {
                CanReadProperty("Ngay12", true);
                return _ngay12;
            }
        }

        public decimal Ngay13
        {
            get
            {
                CanReadProperty("Ngay13", true);
                return _ngay13;
            }
        }

        public decimal Ngay14
        {
            get
            {
                CanReadProperty("Ngay14", true);
                return _ngay14;
            }
        }

        public decimal Ngay15
        {
            get
            {
                CanReadProperty("Ngay15", true);
                return _ngay15;
            }
        }

        public decimal Ngay16
        {
            get
            {
                CanReadProperty("Ngay16", true);
                return _ngay16;
            }
        }

        public decimal Ngay17
        {
            get
            {
                CanReadProperty("Ngay17", true);
                return _ngay17;
            }
        }

        public decimal Ngay18
        {
            get
            {
                CanReadProperty("Ngay18", true);
                return _ngay18;
            }
        }

        public decimal Ngay19
        {
            get
            {
                CanReadProperty("Ngay19", true);
                return _ngay19;
            }
        }

        public decimal Ngay20
        {
            get
            {
                CanReadProperty("Ngay20", true);
                return _ngay20;
            }
        }

        public decimal Ngay21
        {
            get
            {
                CanReadProperty("Ngay21", true);
                return _ngay21;
            }
        }

        public decimal Ngay22
        {
            get
            {
                CanReadProperty("Ngay22", true);
                return _ngay22;
            }
        }

        public decimal Ngay23
        {
            get
            {
                CanReadProperty("Ngay23", true);
                return _ngay23;
            }
        }

        public decimal Ngay24
        {
            get
            {
                CanReadProperty("Ngay24", true);
                return _ngay24;
            }
        }

        public decimal Ngay25
        {
            get
            {
                CanReadProperty("Ngay25", true);
                return _ngay25;
            }
        }

        public decimal Ngay26
        {
            get
            {
                CanReadProperty("Ngay26", true);
                return _ngay26;
            }
        }

        public decimal Ngay27
        {
            get
            {
                CanReadProperty("Ngay27", true);
                return _ngay27;
            }
        }

        public decimal Ngay28
        {
            get
            {
                CanReadProperty("Ngay28", true);
                return _ngay28;
            }
        }

        public decimal Ngay29
        {
            get
            {
                CanReadProperty("Ngay29", true);
                return _ngay29;
            }
        }

        public decimal Ngay30
        {
            get
            {
                CanReadProperty("Ngay30", true);
                return _ngay30;
            }
        }

        public decimal Ngay31
        {
            get
            {
                CanReadProperty("Ngay31", true);
                return _ngay31;
            }
        }

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                return _tenChucVu;
            }
        }

        public decimal SoGioTangCaNgayThuong
        {
            get
            {
                CanReadProperty("SoGioTangCaNgayThuong", true);
                return _SoGioTangCaNgayThuong;
            }
        }

        public decimal SoGioTangCaT7CN
        {
            get
            {
                CanReadProperty("SoGioTangCaT7CN", true);
                return _SoGioTangCaT7CN;
            }
        }

        public decimal SoGioTangCaNgayLe
        {
            get
            {
                CanReadProperty("SoGioTangCaNgayLe", true);
                return _SoGioTangCaNgayLe;
            }
        }

        public decimal TongSoGioTangCa
        {
            get
            {
                CanReadProperty("TongSoGioTangCa", true);
                return _TongSoGioTangCa;
            }
        }

        protected override object GetIdValue()
		{
            return string.Format("{0}{1}", _maBoPhan, _maNhanVien);
		}

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in BangTangCaNhanVienChild
            //AuthorizationRules.AllowRead("MaBoPhan", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay1", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay2", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay3", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay4", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay5", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay6", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay7", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay8", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay9", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay10", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay11", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay12", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay13", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay14", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay15", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay16", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay17", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay18", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay19", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay20", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay21", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay22", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay23", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay24", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay25", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay26", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay27", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay28", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay29", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay30", "BangTangCaNhanVienChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay31", "BangTangCaNhanVienChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static BangTangCaNhanVienChild GetBangTangCaNhanVienChild(SafeDataReader dr)
        {
            return new BangTangCaNhanVienChild(dr);
        }

        private BangTangCaNhanVienChild(SafeDataReader dr)
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
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _ngay1 = dr.GetDecimal("Ngay1");
            _ngay2 = dr.GetDecimal("Ngay2");
            _ngay3 = dr.GetDecimal("Ngay3");
            _ngay4 = dr.GetDecimal("Ngay4");
            _ngay5 = dr.GetDecimal("Ngay5");
            _ngay6 = dr.GetDecimal("Ngay6");
            _ngay7 = dr.GetDecimal("Ngay7");
            _ngay8 = dr.GetDecimal("Ngay8");
            _ngay9 = dr.GetDecimal("Ngay9");
            _ngay10 = dr.GetDecimal("Ngay10");
            _ngay11 = dr.GetDecimal("Ngay11");
            _ngay12 = dr.GetDecimal("Ngay12");
            _ngay13 = dr.GetDecimal("Ngay13");
            _ngay14 = dr.GetDecimal("Ngay14");
            _ngay15 = dr.GetDecimal("Ngay15");
            _ngay16 = dr.GetDecimal("Ngay16");
            _ngay17 = dr.GetDecimal("Ngay17");
            _ngay18 = dr.GetDecimal("Ngay18");
            _ngay19 = dr.GetDecimal("Ngay19");
            _ngay20 = dr.GetDecimal("Ngay20");
            _ngay21 = dr.GetDecimal("Ngay21");
            _ngay22 = dr.GetDecimal("Ngay22");
            _ngay23 = dr.GetDecimal("Ngay23");
            _ngay24 = dr.GetDecimal("Ngay24");
            _ngay25 = dr.GetDecimal("Ngay25");
            _ngay26 = dr.GetDecimal("Ngay26");
            _ngay27 = dr.GetDecimal("Ngay27");
            _ngay28 = dr.GetDecimal("Ngay28");
            _ngay29 = dr.GetDecimal("Ngay29");
            _ngay30 = dr.GetDecimal("Ngay30");
            _ngay31 = dr.GetDecimal("Ngay31");
            _tenChucVu = dr.GetString("TenChucVu");
            _SoGioTangCaNgayThuong = dr.GetDecimal("SoGioTangCaNgayThuong");
            _SoGioTangCaT7CN = dr.GetDecimal("SoGioTangCaT7CN");
            _SoGioTangCaNgayLe = dr.GetDecimal("SoGioTangCaNgayLe");
            _TongSoGioTangCa = dr.GetDecimal("TongSoGioTangCa");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
