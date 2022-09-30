using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class DieuChuyenNoiBo:BusinessBase<DieuChuyenNoiBo>
    {
        protected override object GetIdValue()
        {
            return _MaNghiepVuDieuChuyen;
        }

        #region rule
        protected override void AddBusinessRules()
        {          

         //   ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("TSCDCaBiet", 1));            
        }

        
        
        #endregion

        #region Properties

        int _MaNghiepVuDieuChuyen;
        public int MaNghiepVuDieuChuyen
        {
            get
            {
                CanReadProperty(true);
                return _MaNghiepVuDieuChuyen;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNghiepVuDieuChuyen.Equals(value))
                {
                    _MaNghiepVuDieuChuyen = value;
                    PropertyHasChanged();
                }
            }
        }

        long _maNhanVienBenGiao;
        public long MaNhanVienBenGiao
        {
            get
            {
                CanReadProperty(true);
                return _maNhanVienBenGiao;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maNhanVienBenGiao.Equals(value))
                {
                    _maNhanVienBenGiao = value;
                    PropertyHasChanged();
                }
            }
        }

        long _maNhanVienBenNhan;
        public long MaNhanVienBenNhan
        {
            get
            {
                CanReadProperty(true);
                return _maNhanVienBenNhan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maNhanVienBenNhan.Equals(value))
                {
                    _maNhanVienBenNhan = value;
                    PropertyHasChanged();
                }
            }
        }
        
        DateTime _NgaythucHien;
        public DateTime NgaythucHien
        {
            get
            {
                CanReadProperty(true);
                return _NgaythucHien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgaythucHien.Equals(value))
                {
                    _NgaythucHien = value;
                    PropertyHasChanged();
                }
            }
        }

        CT_NghiepVuDieuChuyenList _CT_NghiepVuDieuChuyenList;
        public CT_NghiepVuDieuChuyenList CT_NghiepVuDieuChuyenList
        {
            get
            {
                CanReadProperty(true);
                return _CT_NghiepVuDieuChuyenList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_CT_NghiepVuDieuChuyenList.Equals(value))
                {
                    _CT_NghiepVuDieuChuyenList = value;
                    PropertyHasChanged();
                }
            }
        }        

        String _GhiChu;
        public String GhiChu
        {
            get
            {
                CanReadProperty(true);
                return _GhiChu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GhiChu.Equals(value))
                {
                    _GhiChu = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaCTNV;
        public int MaCTNV
        {
            get
            {
                CanReadProperty(true);
                return _MaCTNV;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaCTNV.Equals(value))
                {
                    _MaCTNV = value;
                    PropertyHasChanged();
                }
            }
        }

        String _SoCTNV;
        public String SoCTNV
        {
            get
            {
                CanReadProperty(true);
                return _SoCTNV;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoCTNV.Equals(value))
                {
                    _SoCTNV = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaCTNVQL;
        public String MaCTNVQL
        {
            get
            {
                CanReadProperty(true);
                return _MaCTNVQL;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaCTNVQL.Equals(value))
                {
                    _MaCTNVQL = value;
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

        long _maNguoiLap;
        public long MaNguoiLap
        {
            get
            {
                CanReadProperty(true);
                return _maNguoiLap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maNguoiLap.Equals(value))
                {
                    _maNguoiLap = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaPhongBanGiao;
        public int MaPhongBanGiao
        {
            get
            {
                CanReadProperty(true);
                return _MaPhongBanGiao;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaPhongBanGiao.Equals(value))
                {
                    _MaPhongBanGiao = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaPhongBanNhan;
        public int MaPhongBanNhan
        {
            get
            {
                CanReadProperty(true);
                return _MaPhongBanNhan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaPhongBanNhan.Equals(value))
                {
                    _MaPhongBanNhan = value;
                    PropertyHasChanged();
                }
            }
        }

        #endregion

        #region Contructors
        private DieuChuyenNoiBo()
        {

            _MaNghiepVuDieuChuyen = 0;            
            _NgaythucHien = DateTime.Today;
            //_NhanVienBenGiao = NhanVien.NewNhanVien();
            //_NhanVienBenNhan = NhanVien.NewNhanVien();
            _maNhanVienBenGiao = 0;
            _maNhanVienBenNhan = 0;
            _GhiChu = String.Empty;
            _CT_NghiepVuDieuChuyenList= CT_NghiepVuDieuChuyenList.NewCT_NghiepVuDieuChuyenList();
            _DienGiai = String.Empty;
            _MaCTNV = 0;
            _MaCTNVQL = String.Empty;
            //_NguoiLap = NguoiSuDung.NewNguoiSuDung();
            _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _SoCTNV = String.Empty;
            _MaPhongBanGiao = 0;
            _MaPhongBanNhan = 0;
            
            //MarkAsChild();
        }
        #endregion

        #region Static Methods

        private void UpdateChildren(SqlTransaction tr)
        {
            _CT_NghiepVuDieuChuyenList.Update(tr, this);            
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }  
  
        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNghiepVuDieuChuyen));
        }

        private DieuChuyenNoiBo(SafeDataReader dr)
        {
            MarkAsChild();
            _MaNghiepVuDieuChuyen = dr.GetInt32("MaNghiepVuDieuChuyenNoiBo");
            _maNhanVienBenGiao = dr.GetInt64("MaNhanVienBenGiao");
            _maNhanVienBenNhan = dr.GetInt64("MaNhanVienBenNhan");
            _GhiChu = dr.GetString("GhiChu");
            _NgaythucHien = dr.GetDateTime("NgayThucHien");
            _MaCTNV = dr.GetInt32("MaCTNV");
            _SoCTNV = dr.GetString("SoCTNV");
            _MaCTNVQL = dr.GetString("MaCTNVQL");
            _DienGiai = dr.GetString("DienGiai");            
            _maNguoiLap = dr.GetInt64("MaNguoiSuDung");
            _MaPhongBanGiao= dr.GetInt32("MaPhongBanGiao");
            _MaPhongBanNhan= dr.GetInt32("MaPhongBanNhan");
            _CT_NghiepVuDieuChuyenList = CT_NghiepVuDieuChuyenList.GetCT_NghiepVuDieuChuyenList(_MaNghiepVuDieuChuyen); 
            MarkOld();
        }

        public static DieuChuyenNoiBo NewDieuChuyenNoiBo()
        {
            //return (NhanVien)DataPortal.Create(new Criteria());
            return new DieuChuyenNoiBo();
        }

        public static DieuChuyenNoiBo NewDieuChuyenNoiBoParent()
        {
            DieuChuyenNoiBo dieuChuyenNoiBo = new DieuChuyenNoiBo();

           // dieuChuyenNoiBo.ValidationRules.CheckRules();

            return dieuChuyenNoiBo;
        }

        public static DieuChuyenNoiBo GetDieuChuyenNoiBo(int maDieuChuyenNoiBo)
        {
            return (DieuChuyenNoiBo)DataPortal.Fetch<DieuChuyenNoiBo>(new Criteria(maDieuChuyenNoiBo));
        }

        public static DieuChuyenNoiBo NewDieuChuyenNoiBo(int maDieuChuyen, DateTime ngayThucHien, long nvGiao, long nvNhan,
                              String soChungTu, int maTSCD, int maChungTu , int maPhongBanGiao, int maPhongBanNhan)
        {
            DieuChuyenNoiBo dc = new DieuChuyenNoiBo();
            dc._MaNghiepVuDieuChuyen = maDieuChuyen;
            dc._NgaythucHien = ngayThucHien;
            dc._maNhanVienBenGiao = nvGiao;
            dc._maNhanVienBenNhan = nvNhan;
            dc._MaPhongBanGiao = maPhongBanGiao;
            dc._MaPhongBanNhan = maPhongBanNhan;
            return dc;
        }

        internal static DieuChuyenNoiBo GetDieuChuyenNoiBo(SafeDataReader dr)
        {
            return new DieuChuyenNoiBo(dr);
        }

        public static void DeleteDieuChuyenNoiBo(int maDieuChuyenNoiBo)
        {
            DataPortal.Delete(new Criteria(maDieuChuyenNoiBo));
        }

        public static Boolean KiemTraSoChungTu(string soChungTu)
        {
            int count = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(*) from tblChungTuNghiepVu where SoCTNV='" + soChungTu + "'";
                    count = (int)cm.ExecuteScalar();
                }
            }
            if (count == 0) return true;
            else return false;
        }
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaNghiepVuDieuChuyen;

            public Criteria(int maNghiepVuDieuChuyen)
            {
                MaNghiepVuDieuChuyen = maNghiepVuDieuChuyen;
            }
        }

        #endregion

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || CT_NghiepVuDieuChuyenList.IsDirty;
            }
        }

        public override bool IsValid
        {
            get
            {
                return base.IsValid || CT_NghiepVuDieuChuyenList.IsValid ;
            }
        }
        #endregion

        #region Data Access

        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadMaCaBiet_NghiepVuDieuChuyenNoiBo";
                    cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyenNoiBo", crit.MaNghiepVuDieuChuyen);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            _MaNghiepVuDieuChuyen = dr.GetInt32("MaNghiepVuDieuChuyenNoiBo");
                            _maNhanVienBenGiao = dr.GetInt64("MaNhanVienBenGiao");
                            _maNhanVienBenNhan = dr.GetInt64("MaNhanVienBenNhan");
                            _GhiChu = dr.GetString("GhiChu");
                            _NgaythucHien = dr.GetDateTime("NgayThucHien");
                            _MaCTNV = dr.GetInt32("MaCTNV");
                            _SoCTNV = dr.GetString("SoCTNV");
                            _MaCTNVQL = dr.GetString("MaCTNVQL");
                            _DienGiai = dr.GetString("DienGiai");
                            _MaPhongBanGiao = dr.GetInt32("MaPhongBanGiao");
                            _MaPhongBanNhan = dr.GetInt32("MaPhongBanNhan");
                            _maNguoiLap = dr.GetInt64("MaNguoiSuDung");
                            // load child objects
                            dr.NextResult();
                        }
                    }
                    _CT_NghiepVuDieuChuyenList = CT_NghiepVuDieuChuyenList.GetCT_NghiepVuDieuChuyenList(_MaNghiepVuDieuChuyen);
                }
                MarkOld();
            }
        }

        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlTransaction tr;
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {                   
                    
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;                       
                        cm.CommandText = "spd_Insert_NghiepVuDieuChuyenNoiBo";
                        cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyenNoiBo", _MaNghiepVuDieuChuyen).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaNhanVienBenGiao", _maNhanVienBenGiao);
                        cm.Parameters.AddWithValue("@MaNhanVienBenNhan", _maNhanVienBenNhan);
                        cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgaythucHien);
                        cm.Parameters.AddWithValue("@MaCTNV", _MaCTNV).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@SoCTNV", _SoCTNV);
                        cm.Parameters.AddWithValue("@MaCTNVQL", _MaCTNVQL);
                        cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                        cm.Parameters.AddWithValue("@MaPhongBanGiao", _MaPhongBanGiao);
                        cm.Parameters.AddWithValue("@MaPhongBanNhan", _MaPhongBanNhan);
                        //NHỚ PHẢI SỬA NHA 

                        cm.Parameters.AddWithValue("@MaNguoiSuDung", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.ExecuteNonQuery();
                        _MaCTNV = (int)cm.Parameters["@MaCTNV"].Value;
                        _MaNghiepVuDieuChuyen = (int)cm.Parameters["@MaNghiepVuDieuChuyenNoiBo"].Value;
                        MarkOld();
                    }
                    UpdateChildren(tr);
                    tr.Commit();
                }
               catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;                   
                }
            }
        }

        protected override void DataPortal_Update()
        {
            // Insert or update object data into database
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlTransaction tr;
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {                                    

                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_NghiepVuDieuChuyenNoiBo";
                        cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyenNoiBo", _MaNghiepVuDieuChuyen);                        
                        cm.Parameters.AddWithValue("@MaNhanVienBenGiao", _maNhanVienBenGiao);
                        cm.Parameters.AddWithValue("@MaNhanVienBenNhan", _maNhanVienBenNhan);                        
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgaythucHien);
                        cm.Parameters.AddWithValue("@GhiChu", _GhiChu);                      
                        cm.Parameters.AddWithValue("@SoCTNV", _SoCTNV);
                        cm.Parameters.AddWithValue("@MaCTNVQL", _MaCTNVQL);
                        cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                        cm.Parameters.AddWithValue("@MaPhongBanGiao", _MaPhongBanGiao);
                        cm.Parameters.AddWithValue("@MaPhongBanNhan", _MaPhongBanNhan);
                        //NHỚ PHẢI SỬA NHA 

                        cm.Parameters.AddWithValue("@MaNguoiSuDung", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.ExecuteNonQuery();
                        // make sure we're marked as an old object
                        MarkOld();
                    }
                    UpdateChildren(tr);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }

        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            try
            {
                // Delete object data from database
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    SqlTransaction tr;
                    cn.Open();
                    tr = cn.BeginTransaction();
                    _CT_NghiepVuDieuChuyenList.Clear();
                    UpdateChildren(tr);
                    using (SqlCommand cm =tr.Connection.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_NghiepVuDieuChuyenNoiBo";
                        cm.Parameters.AddWithValue("@MaNghiepVuDieuChuyenNoiBo", crit.MaNghiepVuDieuChuyen);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string temp = ex.Message;
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
                        
            DataPortal_Delete(new Criteria(_MaNghiepVuDieuChuyen));

        }       



        #endregion
                
    }
}
