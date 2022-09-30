using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class KhauHao:BusinessBase<KhauHao>
    {

        protected override object GetIdValue()
        {
            return _MaKhauHaoHaoMon;
        }
        #region Khai báo properties

        #region KhauHao
        int _MaKhauHaoHaoMon;
        public int MaKhauHaoHaoMon
        {
            get
            {
                CanReadProperty(true);
                return _MaKhauHaoHaoMon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaKhauHaoHaoMon.Equals(value))
                {
                    _MaKhauHaoHaoMon = value;
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

        Decimal _LuyKe;
        public Decimal LuyKe
        {
            get
            {
                CanReadProperty(true);
                return _LuyKe;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LuyKe.Equals(value))
                {
                    _LuyKe = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgayThucHien;
        public DateTime NgayThucHien
        {
            get
            {
                CanReadProperty(true);
                return _NgayThucHien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayThucHien.Equals(value))
                {
                    _NgayThucHien = value;
                    PropertyHasChanged();
                }
            }
        }

        Boolean _Loai;
        public Boolean Loai
        {
            get
            {
                CanReadProperty(true);
                return _Loai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Loai.Equals(value))
                {
                    _Loai = value;
                    PropertyHasChanged();
                }
            }
        }

        Ky _Ky;
        public Ky Ky
        {
            get
            {
                CanReadProperty(true);
                return _Ky;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Ky.Equals(value))
                {
                    _Ky = value;
                    PropertyHasChanged();
                }
            }
        }
       
        #endregion 

        #region TSCD Ca Biet
        TSCDCaBiet _TaiSanCoDinhCaBiet;
        public TSCDCaBiet TaiSanCoDinhCaBiet
        {
            get
            {
                CanReadProperty(true);
                return _TaiSanCoDinhCaBiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TaiSanCoDinhCaBiet.Equals(value))
                {
                    _TaiSanCoDinhCaBiet = value;
                    PropertyHasChanged();
                }
            }
        }       

        public int MaTSCDCaBiet
        {
            get
            {
                return _TaiSanCoDinhCaBiet.MaTSCDCaBiet;
            }
        }
        
        public String SoHieuCB
        {
            get
            {
                return _TaiSanCoDinhCaBiet.SoHieuCB;         
            }
         
        }        
        
        public String Serial
        {
            get
            {
                return _TaiSanCoDinhCaBiet.Serial;         
            }
            
        }        
        
               
        public int NamSanXuat
        {
            get
            {
                return _TaiSanCoDinhCaBiet.NamSanXuat;
            }
         
        }        
        
        public Decimal NguyenGiaMua
        {
            get
            {
                return _TaiSanCoDinhCaBiet.NguyenGiaMua;
            }
         
        }        
        
        public Decimal NguyenGiaConLai
        {
            get
            {
                return _TaiSanCoDinhCaBiet.NguyenGiaConLai;
            }
         
        }               
     
        public int ThoiGianSuDung
        {
            get
            {
                return _TaiSanCoDinhCaBiet.ThoiGianSuDung;
            }

        }      
           
        public Decimal TyLeKhauHaoNam
        {
            get
            {
                return _TaiSanCoDinhCaBiet.TyLeKhauHaoNam;
            }
        
        
        }
        String _TenTaiSan;
        public String TenTaiSan
        {
            get
            {
                CanReadProperty(true);
                return _TenTaiSan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenTaiSan.Equals(value))
                {
                    _TenTaiSan = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenPhongBan;
        public String TenPhongBan
        {
            get
            {
                CanReadProperty(true);
                return _TenPhongBan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenPhongBan.Equals(value))
                {
                    _TenPhongBan = value;
                    PropertyHasChanged();
                }
            }
        }

        String _Model;
        public String Model
        {
            get
            {
                CanReadProperty(true);
                return _Model;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Model.Equals(value))
                {
                    _Model = value;
                    PropertyHasChanged();
                }
            }
        }        
        #endregion               


        #endregion

        #region Constructor

        public KhauHao()
        {
            _MaKhauHaoHaoMon = 0;
            _Loai = false;
            _LuyKe = 0;
            _NgayThucHien = DateTime.Today;
            _SoTien = 0;
            _TaiSanCoDinhCaBiet = TSCDCaBiet.NewTSCDCaBiet();                     
            MarkAsChild();
        }
       
        #endregion     

        #region Static Methods
         public override KhauHao Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaKhauHaoHaoMon));
        }
        public void Insert()
        {
            DataPortal_Insert();
        }
        public void Update()
        {
            DataPortal_Update();
        }


         private  KhauHao(SafeDataReader dr)
         {

            MarkAsChild();
            try
            {
                MarkAsChild();
                _TaiSanCoDinhCaBiet = TSCDCaBiet.NewTSCDCaBietChoKhauHao();
                _TaiSanCoDinhCaBiet.MaTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
                _TaiSanCoDinhCaBiet.SoHieuCB = dr.GetString("SoHieu");
                _TaiSanCoDinhCaBiet.Serial = dr.GetString("Serial");                
                _TaiSanCoDinhCaBiet.NamSanXuat = dr.GetInt32("NamSX");
                _TaiSanCoDinhCaBiet.NguyenGiaMua = dr.GetDecimal("NguyenGiaMua");
                _TaiSanCoDinhCaBiet.NguyenGiaConLai = dr.GetDecimal("NguyenGiaConLai");              
                //_TaiSanCoDinhCaBiet.NgayNhan = dr.GetSmartDate("NgayNhan");
                //_TaiSanCoDinhCaBiet.NgaySuDung = dr.GetSmartDate("NgaySuDung");                
                _TaiSanCoDinhCaBiet.NgayNhan = dr.GetDateTime("NgayNhan");
                _TaiSanCoDinhCaBiet.NgaySuDung = dr.GetDateTime("NgaySuDung");
                _TaiSanCoDinhCaBiet.ThoiGianSuDung = dr.GetInt32("ThoiGianSuDung");                
                _TaiSanCoDinhCaBiet.TyLeKhauHaoNam = dr.GetDecimal("KhauHaoNam");               
                _TaiSanCoDinhCaBiet.MucDichSuDung = dr.GetBoolean("MucDichSuDung");
                _TenTaiSan = dr.GetString("TenTSCD");
                _TenPhongBan = dr.GetString("TenBoPhan");
                _Model = dr.GetString("Model");
                _NgayThucHien = DateTime.Today;
                //if (_TaiSanCoDinhCaBiet.MucDichSuDung == true)
                //    _Loai = true;
                //else _Loai = false;
                _Loai = dr.GetBoolean("KhauHaoHaoMon");
               
                _SoTien = dr.GetDecimal("SoTienKhauHao");
                _LuyKe = dr.GetDecimal("LuyKe");
                _TaiSanCoDinhCaBiet.NguyenGiaConLai = dr.GetDecimal("NguyenGiaConLaiSau");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            MarkNew();
        }
        
        
         public static KhauHao  GetKhauHaoHaoMon(SafeDataReader dr)
        {
            KhauHao khauHao = new KhauHao();
            khauHao.MarkAsChild();            
            try
            {
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


        public static int KiemTraKyKhauHao(bool mucDichSuDung, int ky)
        {
            int count =0;
            int temp = 0;
            if (mucDichSuDung == true)
                temp = 1;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select count(*) from tblNghiepVuKhauHaoHaoMon where MaKy =" + ky  +" and Loai ="+temp;
                        count = (int)cm.ExecuteScalar();

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
             }
             return count;
        }

        public static int KiemTraKyDeleteKhauHao(bool mucDichSuDung, int ky)
        {
            int count = 0;
            int temp = 0;
            if (mucDichSuDung == true)
                temp = 1;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select Max(MaKy) from tblNghiepVuKhauHaoHaoMon where datepart(year,NgayThucHien)= datepart(year,getdate())and Loai =" + temp;
                        count = (int)cm.ExecuteScalar();

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return count;
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

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaKhauHao;

            public Criteria(int maKhauHao)
            {
                MaKhauHao = maKhauHao;
            }            

        }

        #endregion

        #region Data Access     
        
        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;

            // Load object data from database
            
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadMaCaBiet_NghiepVuKhauHaoHaoMon";
                    cm.Parameters.AddWithValue("@MaKhauHaoHaoMon", crit.MaKhauHao);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            _MaKhauHaoHaoMon = dr.GetInt32("MaKhauHaoHaoMon");
                            _Loai = dr.GetBoolean("Loai");
                            _LuyKe = dr.GetDecimal("LuyKe");
                            _SoTien = dr.GetDecimal("SoTien");
                            _NgayThucHien = dr.GetDateTime("NgayThucHien");
                            _TaiSanCoDinhCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCabiet"));
                            _Ky = Ky.GetKy(dr.GetInt32("MaKy"));
                            // load child objects
                            dr.NextResult();
                        }
                    }
                }           
                MarkOld();

            }

        }

        
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_NghiepVuKhauHaoHaoMon";
                        cm.Parameters.AddWithValue("@MaKhauHaoHaoMon", _MaKhauHaoHaoMon).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TaiSanCoDinhCaBiet.MaTSCDCaBiet);
                        cm.Parameters.AddWithValue("@SoTien", _SoTien);
                        cm.Parameters.AddWithValue("@LuyKe", _LuyKe);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                        cm.Parameters.AddWithValue("@Loai", _Loai);
                        cm.Parameters.AddWithValue("@NguyenGiaConLai",_TaiSanCoDinhCaBiet.NguyenGiaConLai);
                        cm.Parameters.AddWithValue("@MaKy",((KhauHaoList)this.Parent).MaKy);                        
                        cm.ExecuteNonQuery();
                        _MaKhauHaoHaoMon = (int)cm.Parameters["@MaKhauHaoHaoMon"].Value;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }                              
            }
        }

        protected override void DataPortal_Update()
        {
            // Insert or update object data into database
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Update_NghiepVuKhauHaoHaoMon";
                        cm.Parameters.AddWithValue("@MaKhauHaoHaoMon", _MaKhauHaoHaoMon);
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TaiSanCoDinhCaBiet.MaTSCDCaBiet);
                        cm.Parameters.AddWithValue("@SoTien", _SoTien);
                        cm.Parameters.AddWithValue("@LuyKe", _LuyKe);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                        cm.Parameters.AddWithValue("@Loai", _Loai);
                        cm.Parameters.AddWithValue("@NguyenGiaConLai", _TaiSanCoDinhCaBiet.NguyenGiaConLai);                                            
                        cm.ExecuteNonQuery();                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }

        
        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_NghiepVuKhauHaoHaoMon";
                    cm.Parameters.AddWithValue("@MaKhauHaoHaoMon", crit.MaKhauHao);
                    cm.ExecuteNonQuery();
                }
            }
        }
            
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaKhauHaoHaoMon));
        }     

        #endregion
    } 
}
