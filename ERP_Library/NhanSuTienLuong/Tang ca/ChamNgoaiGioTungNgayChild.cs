
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ChamNgoaiGioTungNgayChild : Csla.ReadOnlyBase<ChamNgoaiGioTungNgayChild>
    {
        #region Business Properties and Methods

        //declare members
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
        private decimal _cong = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public decimal Ngay1
        {
            get
            {
                return _ngay1;
            }
        }

        public decimal Ngay2
        {
            get
            {
                return _ngay2;
            }
        }

        public decimal Ngay3
        {
            get
            {
                return _ngay3;
            }
        }

        public decimal Ngay4
        {
            get
            {
                return _ngay4;
            }
        }

        public decimal Ngay5
        {
            get
            {
                return _ngay5;
            }
        }

        public decimal Ngay6
        {
            get
            {
                return _ngay6;
            }
        }

        public decimal Ngay7
        {
            get
            {
                return _ngay7;
            }
        }

        public decimal Ngay8
        {
            get
            {
                return _ngay8;
            }
        }

        public decimal Ngay9
        {
            get
            {
                return _ngay9;
            }
        }

        public decimal Ngay10
        {
            get
            {
                return _ngay10;
            }
        }

        public decimal Ngay11
        {
            get
            {
                return _ngay11;
            }
        }

        public decimal Ngay12
        {
            get
            {
                return _ngay12;
            }
        }

        public decimal Ngay13
        {
            get
            {
                return _ngay13;
            }
        }

        public decimal Ngay14
        {
            get
            {
                return _ngay14;
            }
        }

        public decimal Ngay15
        {
            get
            {
                return _ngay15;
            }
        }

        public decimal Ngay16
        {
            get
            {
                return _ngay16;
            }
        }

        public decimal Ngay17
        {
            get
            {
                return _ngay17;
            }
        }

        public decimal Ngay18
        {
            get
            {
                return _ngay18;
            }
        }

        public decimal Ngay19
        {
            get
            {
                return _ngay19;
            }
        }

        public decimal Ngay20
        {
            get
            {
                return _ngay20;
            }
        }

        public decimal Ngay21
        {
            get
            {
                return _ngay21;
            }
        }

        public decimal Ngay22
        {
            get
            {
                return _ngay22;
            }
        }

        public decimal Ngay23
        {
            get
            {
                return _ngay23;
            }
        }

        public decimal Ngay24
        {
            get
            {
                return _ngay24;
            }
        }

        public decimal Ngay25
        {
            get
            {
                return _ngay25;
            }
        }

        public decimal Ngay26
        {
            get
            {
                return _ngay26;
            }
        }

        public decimal Ngay27
        {
            get
            {
                return _ngay27;
            }
        }

        public decimal Ngay28
        {
            get
            {
                return _ngay28;
            }
        }

        public decimal Ngay29
        {
            get
            {
                return _ngay29;
            }
        }

        public decimal Ngay30
        {
            get
            {
                return _ngay30;
            }
        }

        public decimal Ngay31
        {
            get
            {
                return _ngay31;
            }
        }

        public decimal Cong
        {
            get
            {
                return _cong;
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ChamNgoaiGioTungNgayChild GetChamNgoaiGioTungNgayChild(SafeDataReader dr)
        {
            return new ChamNgoaiGioTungNgayChild(dr);
        }

        private ChamNgoaiGioTungNgayChild(SafeDataReader dr)
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
            _cong = _ngay1 + _ngay2 + _ngay3 + _ngay4 + _ngay5 + _ngay6 + _ngay7 + _ngay8 + _ngay9 + _ngay10 +
                _ngay11 + _ngay12 + _ngay13 + _ngay14 + _ngay15 + _ngay16 + _ngay17 + _ngay18 + _ngay19 + _ngay20 +
                _ngay21 + _ngay22 + _ngay23 + _ngay24 + _ngay25 + _ngay26 + _ngay27 + _ngay28 + _ngay29 + _ngay30 + _ngay31;
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
