
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class XacNhanThuNhapChild : Csla.ReadOnlyBase<XacNhanThuNhapChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maXacNhan = 0;
        private DateTime _ngayLap = DateTime.Today;
        private string _veViec = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _chucDanh = string.Empty;
        private string _loaiNV = string.Empty;
        private string _nguoiLap = string.Empty;
        private string _pTTaiChinh = string.Empty;
        private string _pTDonVi = string.Empty;
        private string _SoCMND = "";

        //declare child member(s)
        private XacNhanThuNhapChiTietList _chiTiet;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaXacNhan
        {
            get
            {
                return _maXacNhan;
            }
        }

        public DateTime NgayLap
        {
            get
            {
                return _ngayLap;
            }
        }

        public string VeViec
        {
            get
            {
                return _veViec;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public string SoCMND
        {
            get
            {
                return _SoCMND;
            }
        }

        public string ChucDanh
        {
            get
            {
                return _chucDanh;
            }
        }

        public string LoaiNV
        {
            get
            {
                return _loaiNV;
            }
        }

        public string NguoiLap
        {
            get
            {
                return _nguoiLap;
            }
        }

        public string PTTaiChinh
        {
            get
            {
                return _pTTaiChinh;
            }
        }

        public string PTDonVi
        {
            get
            {
                return _pTDonVi;
            }
        }

        public XacNhanThuNhapChiTietList ChiTiet
        {
            get
            {
                return _chiTiet;
            }
        }

        protected override object GetIdValue()
        {
            return _maXacNhan;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static XacNhanThuNhapChild GetXacNhanThuNhapChild(SafeDataReader dr)
        {
            return new XacNhanThuNhapChild(dr);
        }

        private XacNhanThuNhapChild(SafeDataReader dr)
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
            _maXacNhan = dr.GetInt32("MaXacNhan");
            _ngayLap = dr.GetDateTime("NgayLap");
            _veViec = dr.GetString("VeViec");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _chucDanh = dr.GetString("ChucDanh");
            _loaiNV = dr.GetString("LoaiNV");
            _nguoiLap = dr.GetString("NguoiLap");
            _pTTaiChinh = dr.GetString("PTTaiChinh");
            _pTDonVi = dr.GetString("PTDonVi");
            _SoCMND = dr.GetString("CMND");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            _chiTiet = XacNhanThuNhapChiTietList.GetXacNhanThuNhapChiTietList(dr);
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
