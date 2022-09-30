using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    class NguoiLap: BusinessBase<NguoiLap>
    {
        protected override object GetIdValue()
        {
            return _NhanVien.MaNhanVien;
        }

        #region Khai báo biến

        NhanVien _NhanVien;
        public NhanVien NhanVien
        {
            get
            {
                CanReadProperty(true);
                return _NhanVien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NhanVien.Equals(value))
                {
                    _NhanVien = value;
                    PropertyHasChanged();
                }
            }
        }

        //String _HoTenNV;
        //public String HoTenNV
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _HoTenNV;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_HoTenNV.Equals(value))
        //        {
        //            _HoTenNV = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        NguoiSuDung _NguoiSuDung;
        public NguoiSuDung NguoiSuDung
        {
            get
            {
                CanReadProperty(true);
                return _NguoiSuDung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguoiSuDung.Equals(value))
                {
                    _NguoiSuDung = value;
                    PropertyHasChanged();
                }
            }
        }       

        #endregion              

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaNV;

            public Criteria(int maNV)
            {
                MaNV= maNV;
            }
        }

        #endregion

        #region Static Methods

        public static NguoiLap NewNguoiLap(int maNV)
        {
            return (NguoiLap)DataPortal.Create(new Criteria(maNV));
        }

        public static NguoiLap NewNguoiLap(long maNV, string tenNV, String maNguoiSuDung)
        {
            NguoiLap nl = NguoiLap.NewNguoiLap(0);
            ////nl._NhanVien.MaNhanVien = maNV;
            //nl._NhanVien.TenNhanVien = tenNV;
            //nl._NguoiSuDung.MaNguoiSuDung = maNguoiSuDung;
            return nl;
        }
        public static NguoiLap GetNguoiLap(int maNV)
        {
            return (NguoiLap)DataPortal.Fetch(new Criteria(maNV));
        }

        public static void DeleteNguoiLap(int maNV)
        {
            DataPortal.Delete(new Criteria(maNV));
        }
        #endregion

        #region Constructors

        private NguoiLap()
        {
            // Prevent direct creation
            _NhanVien = NhanVien.NewNhanVien();
            _NguoiSuDung = NguoiSuDung.NewNguoiSuDung();
            MarkAsChild();
        }

        #endregion
    }
}
