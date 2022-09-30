using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class TongHopNghiepVuGhiTang:BusinessBase<TongHopNghiepVuGhiTang>
    {
        protected override object GetIdValue()
        {
            return _SoChungTu;
        }

        #region Khai báo biến
        int _SoTT;
        public int SoTT
        {
            get
            {
                CanReadProperty(true);
                return _SoTT;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoTT.Equals(value))
                {
                    _SoTT = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaChungTu;
        public int MaChungTu
        {
            get
            {
                CanReadProperty(true);
                return _MaChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaChungTu.Equals(value))
                {
                    _MaChungTu = value;
                    PropertyHasChanged();
                }
            }
        }

        String _SoChungTu;
        public String SoChungTu
        {
            get
            {
                CanReadProperty(true);
                return _SoChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoChungTu.Equals(value))
                {
                    _SoChungTu = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenMucNganSach;
        public String TenMucNganSach
        {
            get
            {
                CanReadProperty(true);
                return _TenMucNganSach;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenMucNganSach.Equals(value))
                {
                    _TenMucNganSach = value;
                    PropertyHasChanged();
                }
            }
        }

        String _NoTaiKhoan;
        public String NoTaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _NoTaiKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NoTaiKhoan.Equals(value))
                {
                    _NoTaiKhoan = value;
                    PropertyHasChanged();
                }
            }
        }

        String  _CoTaiKhoan;
        public String  CoTaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _CoTaiKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_CoTaiKhoan.Equals(value))
                {
                    _CoTaiKhoan = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgayLap;
        public DateTime NgayLap
        {
            get
            {
                CanReadProperty(true);
                return _NgayLap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayLap.Equals(value))
                {
                    _NgayLap = value;
                    PropertyHasChanged();
                }
            }
        }

        String _DienGiai;
        public String DienGiai
        {
            get
            {
                CanReadProperty(true);
                return _DienGiai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DienGiai.Equals(value))
                {
                    _DienGiai = value;
                    PropertyHasChanged();
                }
            }
        }
        
        Decimal _SoTien;
        public Decimal SoTien
        {
            get
            {
                CanReadProperty(true);
                return _SoTien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoTien.Equals(value))
                {
                    _SoTien = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion

        #region Contructor
        private TongHopNghiepVuGhiTang()
        {
            _CoTaiKhoan = String.Empty;
            _NgayLap = DateTime.Today;
            _NoTaiKhoan = String.Empty;
            _SoChungTu = String.Empty;
            _SoTien = 0;
            _SoTT = 0;
            _TenMucNganSach = String.Empty;
        }
        #endregion

        #region Static Methods
        private TongHopNghiepVuGhiTang(SafeDataReader dr)
        {
            MarkAsChild();
            _SoTT = dr.GetInt32("SoTT");
            _SoChungTu = dr.GetString("SoChungTu");
            _NgayLap = dr.GetDateTime("NgayLap");
            _NoTaiKhoan = dr.GetString("NoTaiKhoan");
            _CoTaiKhoan = dr.GetString("CoTaiKhoan");           
            _DienGiai = dr.GetString("DienGiai");
            _TenMucNganSach = dr.GetString("TenMucNganSach");
            _SoTien= dr.GetDecimal("SoTienMucNS");
            _MaChungTu = dr.GetInt32("MaChungTu");
            
            MarkOld();
        }

        public static TongHopNghiepVuGhiTang NewTongHopNghiepVuGhiTang()
        {
            //return (NhanVien)DataPortal.Create(new Criteria());
            return new TongHopNghiepVuGhiTang();
        }
        internal static TongHopNghiepVuGhiTang GetTongHopNghiepVuGhiTang(SafeDataReader dr)
        {
            return new TongHopNghiepVuGhiTang(dr);
        }
        #endregion
    }
}
