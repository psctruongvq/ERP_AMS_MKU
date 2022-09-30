
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BangChamCongChild : Csla.ReadOnlyBase<BangChamCongChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maBangCong = 0;
        private long _maNhanVien = 0;
        private int _maBoPhan = 0;
        private int _maKyTinhLuong = 0;
        private string _ngay1 = string.Empty;
        private string _ngay2 = string.Empty;
        private string _ngay3 = string.Empty;
        private string _ngay4 = string.Empty;
        private string _ngay5 = string.Empty;
        private string _ngay6 = string.Empty;
        private string _ngay7 = string.Empty;
        private string _ngay8 = string.Empty;
        private string _ngay9 = string.Empty;
        private string _ngay10 = string.Empty;
        private string _ngay11 = string.Empty;
        private string _ngay12 = string.Empty;
        private string _ngay13 = string.Empty;
        private string _ngay14 = string.Empty;
        private string _ngay15 = string.Empty;
        private string _ngay16 = string.Empty;
        private string _ngay17 = string.Empty;
        private string _ngay18 = string.Empty;
        private string _ngay19 = string.Empty;
        private string _ngay20 = string.Empty;
        private string _ngay21 = string.Empty;
        private string _ngay22 = string.Empty;
        private string _ngay23 = string.Empty;
        private string _ngay24 = string.Empty;
        private string _ngay25 = string.Empty;
        private string _ngay26 = string.Empty;
        private string _ngay27 = string.Empty;
        private string _ngay28 = string.Empty;
        private string _ngay29 = string.Empty;
        private string _ngay30 = string.Empty;
        private string _ngay31 = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenChucVu = string.Empty;
        private string _tenBoPhan = string.Empty;

        public long MaBangCong
        {
            get
            {
                CanReadProperty("MaBangCong", true);
                return _maBangCong;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
        }

        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
        }

        public string Ngay1
        {
            get
            {
                CanReadProperty("Ngay1", true);
                return _ngay1;
            }
        }

        public string Ngay2
        {
            get
            {
                CanReadProperty("Ngay2", true);
                return _ngay2;
            }
        }

        public string Ngay3
        {
            get
            {
                CanReadProperty("Ngay3", true);
                return _ngay3;
            }
        }

        public string Ngay4
        {
            get
            {
                CanReadProperty("Ngay4", true);
                return _ngay4;
            }
        }

        public string Ngay5
        {
            get
            {
                CanReadProperty("Ngay5", true);
                return _ngay5;
            }
        }

        public string Ngay6
        {
            get
            {
                CanReadProperty("Ngay6", true);
                return _ngay6;
            }
        }

        public string Ngay7
        {
            get
            {
                CanReadProperty("Ngay7", true);
                return _ngay7;
            }
        }

        public string Ngay8
        {
            get
            {
                CanReadProperty("Ngay8", true);
                return _ngay8;
            }
        }

        public string Ngay9
        {
            get
            {
                CanReadProperty("Ngay9", true);
                return _ngay9;
            }
        }

        public string Ngay10
        {
            get
            {
                CanReadProperty("Ngay10", true);
                return _ngay10;
            }
        }

        public string Ngay11
        {
            get
            {
                CanReadProperty("Ngay11", true);
                return _ngay11;
            }
        }

        public string Ngay12
        {
            get
            {
                CanReadProperty("Ngay12", true);
                return _ngay12;
            }
        }

        public string Ngay13
        {
            get
            {
                CanReadProperty("Ngay13", true);
                return _ngay13;
            }
        }

        public string Ngay14
        {
            get
            {
                CanReadProperty("Ngay14", true);
                return _ngay14;
            }
        }

        public string Ngay15
        {
            get
            {
                CanReadProperty("Ngay15", true);
                return _ngay15;
            }
        }

        public string Ngay16
        {
            get
            {
                CanReadProperty("Ngay16", true);
                return _ngay16;
            }
        }

        public string Ngay17
        {
            get
            {
                CanReadProperty("Ngay17", true);
                return _ngay17;
            }
        }

        public string Ngay18
        {
            get
            {
                CanReadProperty("Ngay18", true);
                return _ngay18;
            }
        }

        public string Ngay19
        {
            get
            {
                CanReadProperty("Ngay19", true);
                return _ngay19;
            }
        }

        public string Ngay20
        {
            get
            {
                CanReadProperty("Ngay20", true);
                return _ngay20;
            }
        }

        public string Ngay21
        {
            get
            {
                CanReadProperty("Ngay21", true);
                return _ngay21;
            }
        }

        public string Ngay22
        {
            get
            {
                CanReadProperty("Ngay22", true);
                return _ngay22;
            }
        }

        public string Ngay23
        {
            get
            {
                CanReadProperty("Ngay23", true);
                return _ngay23;
            }
        }

        public string Ngay24
        {
            get
            {
                CanReadProperty("Ngay24", true);
                return _ngay24;
            }
        }

        public string Ngay25
        {
            get
            {
                CanReadProperty("Ngay25", true);
                return _ngay25;
            }
        }

        public string Ngay26
        {
            get
            {
                CanReadProperty("Ngay26", true);
                return _ngay26;
            }
        }

        public string Ngay27
        {
            get
            {
                CanReadProperty("Ngay27", true);
                return _ngay27;
            }
        }

        public string Ngay28
        {
            get
            {
                CanReadProperty("Ngay28", true);
                return _ngay28;
            }
        }

        public string Ngay29
        {
            get
            {
                CanReadProperty("Ngay29", true);
                return _ngay29;
            }
        }

        public string Ngay30
        {
            get
            {
                CanReadProperty("Ngay30", true);
                return _ngay30;
            }
        }

        public string Ngay31
        {
            get
            {
                CanReadProperty("Ngay31", true);
                return _ngay31;
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

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                return _tenChucVu;
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

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _maNhanVien, _maBoPhan);
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in BangChamCongChild
            //AuthorizationRules.AllowRead("MaBangCong", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay1", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay2", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay3", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay4", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay5", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay6", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay7", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay8", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay9", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay10", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay11", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay12", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay13", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay14", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay15", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay16", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay17", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay18", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay19", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay20", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay21", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay22", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay23", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay24", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay25", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay26", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay27", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay28", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay29", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay30", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("Ngay31", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("TenChucVu", "BangChamCongChildReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "BangChamCongChildReadGroup");

        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static BangChamCongChild GetBangChamCongChild(SafeDataReader dr)
        {
            return new BangChamCongChild(dr);
        }

        private BangChamCongChild(SafeDataReader dr)
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
            _maBangCong = dr.GetInt64("MaBangCong");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _ngay1 = dr.GetString("Ngay1");
            _ngay2 = dr.GetString("Ngay2");
            _ngay3 = dr.GetString("Ngay3");
            _ngay4 = dr.GetString("Ngay4");
            _ngay5 = dr.GetString("Ngay5");
            _ngay6 = dr.GetString("Ngay6");
            _ngay7 = dr.GetString("Ngay7");
            _ngay8 = dr.GetString("Ngay8");
            _ngay9 = dr.GetString("Ngay9");
            _ngay10 = dr.GetString("Ngay10");
            _ngay11 = dr.GetString("Ngay11");
            _ngay12 = dr.GetString("Ngay12");
            _ngay13 = dr.GetString("Ngay13");
            _ngay14 = dr.GetString("Ngay14");
            _ngay15 = dr.GetString("Ngay15");
            _ngay16 = dr.GetString("Ngay16");
            _ngay17 = dr.GetString("Ngay17");
            _ngay18 = dr.GetString("Ngay18");
            _ngay19 = dr.GetString("Ngay19");
            _ngay20 = dr.GetString("Ngay20");
            _ngay21 = dr.GetString("Ngay21");
            _ngay22 = dr.GetString("Ngay22");
            _ngay23 = dr.GetString("Ngay23");
            _ngay24 = dr.GetString("Ngay24");
            _ngay25 = dr.GetString("Ngay25");
            _ngay26 = dr.GetString("Ngay26");
            _ngay27 = dr.GetString("Ngay27");
            _ngay28 = dr.GetString("Ngay28");
            _ngay29 = dr.GetString("Ngay29");
            _ngay30 = dr.GetString("Ngay30");
            _ngay31 = dr.GetString("Ngay31");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenChucVu = dr.GetString("TenChucVu");
            _tenBoPhan = dr.GetString("TenBoPhan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
