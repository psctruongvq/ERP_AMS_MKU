using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data.SqlClient;
using System.Data;

namespace KeToanProject.Library
{
    class SoDuDauNam
    {
       
     /*   #region Khai báo properties

        int _MaSoDuDauNam;
        public int MaSoDuDauNam
        {
            get
            {
                CanReadProperty(true);
                return _MaSoDuDauNam;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaSoDuDauNam.Equals(value))
                {
                    _MaSoDuDauNam = value;
                    PropertyHasChanged();
                }
            }
        }

        HeThongTaiKhoan _TaiKhoan;
        public HeThongTaiKhoan TaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _TaiKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TaiKhoan.Equals(value))
                {
                    _TaiKhoan = value;
                    PropertyHasChanged();
                }
            }
        }

        String   _SoHieu;
        public String SoHieu
        {
            get
            {
                
                return _TaiKhoan.SoHieuTK;
            }
            
        }

        String _TenTaiKhoan;
        public String TenTaiKhoan
        {
            get
            {
                
                return _TaiKhoan.TenTaiKhoan;
            }
          
        }
        Decimal _SoDuDauNamNo;
        public Decimal SoDuDauNamNo
        {
            get
            {
                CanReadProperty(true);
                return _SoDuDauNamNo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoDuDauNamNo.Equals(value))
                {
                    _SoDuDauNamNo = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _SoDuDauNamCo;
        public Decimal SoDuDauNamCo
        {
            get
            {
                CanReadProperty(true);
                return _SoDuDauNamCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoDuDauNamCo.Equals(value))
                {
                    _SoDuDauNamCo = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion

        #region Constructor

        public SoDuDauNam()
        {
            _MaSoDuDauNam = 0;
            _SoDuDauNamCo = 0;
            _SoDuDauNamNo = 0;
            _TaiKhoan = HeThongTaiKhoan.NewHeThongTaiKhoan();
            MarkAsChild();
        }       
        #endregion     

        #region Static Methods
        public override SoDuDauNam Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaSoDuDauNam));
        }
        public void Insert()
        {
            DataPortal_Insert();
        }
        public void Update()
        {
            DataPortal_Update();
        }


         private  SoDuDauNam(SafeDataReader dr)
         {            
            MarkAsChild();
            try
            {
                MarkAsChild();
                _TaiKhoan = HeThongTaiKhoan.NewHeThongTaiKhoan();
                _TaiKhoan.SoHieuTK = dr.GetString("SoHieuTK");
                _TaiKhoan.TenTaiKhoan = dr.GetString("TenTaiKhoan");                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            MarkNew();
        }
        
        
         public static SoDuDauNam  GetSoDuDauNam(SafeDataReader dr)
        {
            SoDuDauNam soDuDauNam = new SoDuDauNam();
            soDuDauNam.MarkAsChild();            
            try
            {
                soDuDauNam._MaSoDuDauNam = dr.GetInt32("Ma");
                khauHao._MaKhauHaoHaoMon = dr.GetInt32("MaKhauHaoHaoMon");
                khauHao._Loai = dr.GetBoolean("Loai");
                khauHao._LuyKe = dr.GetDecimal("LuyKe");
                khauHao._SoTien = dr.GetDecimal("SoTien");
                khauHao._NgayThucHien = dr.GetDateTime("NgayThucHien");
                khauHao._TaiSanCoDinhCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCabiet"));
                khauHao._Ky = Ky.GetKy(dr.GetInt32("MaKy"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            khauHao.MarkOld();
            return khauHao;
        }

        
        public static KhauHao NewKhauHao()
        {
            return new KhauHao();
        }

        public static KhauHao NewKhauHao(int maKhauHao, Decimal luyKe, Decimal soTien, 
            DateTime ngayThucHien, Boolean loai, int maTSCDCaBiet )
        {
            KhauHao khauHao = new KhauHao();
            khauHao._MaKhauHaoHaoMon = maKhauHao;
            khauHao._LuyKe = luyKe;
            khauHao._NgayThucHien = ngayThucHien;
            khauHao._SoTien = soTien;
            khauHao.Loai = loai;
            khauHao.TaiSanCoDinhCaBiet = TSCDCaBiet.GetTSCDCaBiet(maTSCDCaBiet);
            return khauHao;
        }

        public static KhauHao GetKhauHao(int maKhauHao)
        {
            return (KhauHao)DataPortal.Fetch<KhauHao>(new Criteria(maKhauHao));
        }

        internal static KhauHao GetKhauHao(SafeDataReader dr)
        {
            return new KhauHao(dr);            
        }

        public static void DeleteKhauHao(int maKhauHao)
        {
            DataPortal.Delete(new Criteria(maKhauHao));
        }

        #endregion*/



    }
}
