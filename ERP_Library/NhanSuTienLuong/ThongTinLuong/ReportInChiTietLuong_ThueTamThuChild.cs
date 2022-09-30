
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_ThueTamThuChild : Csla.ReadOnlyBase<InChiTietLuong_ThueTamThuChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _ma = 0;
        private int _loai = 0;
        private SmartDate _ngay = new SmartDate(false);
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private string _dienGiai = string.Empty;
        private decimal _soTien = 0;
        private string _tenloai = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public long Ma
        {
            get
            {
                return _ma;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int Loai
        {
            get
            {
                return _loai;
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _ngay.Date;
            }
        }

        public string NgayString
        {
            get
            {
                if (_loai == 1)
                    _tenloai = "Chi tiết tạm thu thuế TNCN";
                else
                    _tenloai = "Chi tiết điều chỉnh";

                return _tenloai;

            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public string DienGiai
        {
            get
            {
                return _dienGiai;
            }
        }

        public string TenLoai 
        {
            get
            {
                if (_loai == 1)
                    _tenloai = "Chi tiết tạm thu thuế TNCN";
                else
                    _tenloai = "Chi tiết điều chỉnh";
                return _tenloai;
            }
        }
        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _ma, _loai);
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static InChiTietLuong_ThueTamThuChild GetInChiTietLuong_ThueTamThuChild(SafeDataReader dr)
        {
            return new InChiTietLuong_ThueTamThuChild(dr);
        }

        private InChiTietLuong_ThueTamThuChild(SafeDataReader dr)
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
            _ma = dr.GetInt64("Ma");
            _loai = dr.GetInt32("Loai");
            _ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _dienGiai = dr.GetString("DienGiai");
            _soTien = dr.GetDecimal("SoTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
