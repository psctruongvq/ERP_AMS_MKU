
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class ReportDeNghiChuyenKhoan_CacQuy : Csla.ReadOnlyBase<ReportDeNghiChuyenKhoan_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maPhieu = 0;
        private string _so = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _lyDo = string.Empty;
        private decimal _soTien = 0;
        private string _tenNganHang = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private string _tenNguoiNhan = string.Empty;
        private string _soTaiKhoanNhan = string.Empty;
        private string _nganHangNhan = string.Empty;
        private int _loaiTien = 0;
        private string _soTienBangChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaPhieu
        {
            get
            {
                return _maPhieu;
            }
        }

        public string So
        {
            get
            {
                return _so;
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _ngay;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public string LyDo
        {
            get
            {
                return _lyDo;
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }

        public string TenNganHang
        {
            get
            {
                return _tenNganHang;
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
        }

        public string TenNguoiNhan
        {
            get
            {
                return _tenNguoiNhan;
            }
        }

        public string SoTaiKhoanNhan
        {
            get
            {
                return _soTaiKhoanNhan;
            }
        }

        public string NganHangNhan
        {
            get
            {
                return _nganHangNhan;
            }
        }

        public string SoTienFormart
        {
            get
            {
                if (_loaiTien == 1)
                {
                    string Chuoi = String.Format("{0:0,0}", _soTien);
                    Chuoi = Chuoi.Replace(",", ".");
                    return Chuoi + " đồng";
                }
                else
                {
                    return String.Format("{0:0,0.##}", _soTien) + " " + LoaiTien.GetLoaiTien(_loaiTien).MaLoaiQuanLy;
                }
            }
        }

        public string SoTienBangChu
        {
             get
            {
                if (_loaiTien == 1)
                {
                    return HamDungChung.DocTien(_soTien);
                }
                else if (_loaiTien == 2)
                {
                    return HamDungChung.DocTienDo(_soTien);
                }
                return HamDungChung.DocTienNgoaiTe(_soTien, LoaiTien.GetLoaiTien(_loaiTien).TienChan, LoaiTien.GetLoaiTien(_loaiTien).TienLe);
            }
        }

        protected override object GetIdValue()
        {
            return _maPhieu;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static ReportDeNghiChuyenKhoan_CacQuy GetDeNghiChuyenKhoanChild(SafeDataReader dr)
        {
            return new ReportDeNghiChuyenKhoan_CacQuy(dr);
        }

        internal static ReportDeNghiChuyenKhoan_CacQuy GetDeNghiChuyenKhoanChild_New(SafeDataReader dr)
        {
            ReportDeNghiChuyenKhoan_CacQuy child = new ReportDeNghiChuyenKhoan_CacQuy();
            child.Fetch(dr);
            return child;
        }

        private ReportDeNghiChuyenKhoan_CacQuy(SafeDataReader dr)
        {
            Fetch(dr);
        }

        private ReportDeNghiChuyenKhoan_CacQuy()
        {
           
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
            _maPhieu = dr.GetInt64("MaPhieu");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
            _tenNganHang = dr.GetString("TenNganHang");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _tenNguoiNhan = dr.GetString("TenNguoiNhan");
            _soTaiKhoanNhan = dr.GetString("SoTaiKhoanNhan");
            _nganHangNhan = dr.GetString("NganHangNhan");
            _loaiTien = dr.GetInt32("LoaiTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
