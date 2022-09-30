using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DSHoaDonDichVu_BaoCao : Csla.BusinessBase<DSHoaDonDichVu_BaoCao>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKy = 0;
        private int _thang = 0;
        private int _nam = 0;
        private long _mahoadon = 0;
        private string _soserial = "";
        private DateTime _ngaylap = DateTime.Now.Date;
        private string _tendoitac = "";
        private string _masothue = "";
        private string _mathang = "";
        private decimal _sotien = 0;
        private decimal _thuesuat = 0;
        private decimal _tienthue = 0;
        private decimal _tiensauthue = 0;
        private string _ghichu = "";
        private DateTime _ngaylaphd = DateTime.Now.Date;
        private string _loaidv = "";
        private string _mauHoaDon = string.Empty;
        private string _kyHieuMauHoaDon = string.Empty;
        private int _maNhanVien = Convert.ToInt32(ERP_Library.Security.CurrentUser.Info.UserID);
        private int _loai = 0;
        private bool _check = false;
        private string _soHoaDon = string.Empty;
        private DateTime _ngayGhiSo = DateTime.Now.Date;
        private int _maLoaiChungTu = 0;
        private long _maChungTu = 0;
        private int _maBoPhan = 0;
        private int _loaiNhapXuat = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public bool check
        {
            get
            {
                CanReadProperty("check", true);
                return _check;
            }
            set
            {
                _check = value;
            }
        }

        public int MaKy
        {
            get
            {
                CanReadProperty("MaKy", true);
                return _maKy;
            }
            set
            {
                _maKy = value;
            }
        }

        public int Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                _loai = value;
            }

        }
        public int MaLoaiChungTu
        {
            get
            {
                CanReadProperty("MaLoaiChungTu", true);
                return _maLoaiChungTu;
            }           
        }
        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
        }
        public int thang
        {
            get
            {
                CanReadProperty(true);
                return _thang;
            }
        }
        public int nam
        {
            get
            {
                CanReadProperty(true);
                return _nam;
            }
        }
        public long mahoadon
        {
            get
            {
                CanReadProperty(true);
                return _mahoadon;
            }
        }
        public string soserial
        {
            get
            {
                CanReadProperty(true);
                return _soserial;
            }
        }
        public DateTime NgayLap
        {
            get
            {
                CanReadProperty(true);
                return _ngaylap;
            }
        }
        public DateTime NgayLapHD
        {
            get
            {
                CanReadProperty(true);
                return _ngaylaphd;
            }
        }
        public DateTime NgayGhiSo
        {
            get
            {
                CanReadProperty(true);
                return _ngayGhiSo;
            }
        }
        public string tendoitac
        {
            get
            {
                CanReadProperty(true);
                return _tendoitac;
            }
        }
        public string masothue
        {
            get
            {
                CanReadProperty(true);
                return _masothue;
            }
        }
        public string mathang
        {
            get
            {
                CanReadProperty(true);
                return _mathang;
            }
        }

        public decimal sotien
        {
            get
            {
                CanReadProperty(true);
                return _sotien;
            }
        }
        public decimal thuesuat
        {
            get
            {
                CanReadProperty(true);
                return _thuesuat;
            }
        }
        public decimal tienthue
        {
            get
            {
                CanReadProperty(true);
                return _tienthue;
            }
        }
        public decimal tiensauthue
        {
            get
            {
                CanReadProperty(true);
                return _tiensauthue;
            }
        }
        public string Ghichu
        {
            get
            {
                CanReadProperty(true);
                return _ghichu;
            }
        }
        public string loaidv
        {
            get
            {
                CanReadProperty(true);
                return _loaidv;
            }
        }

        public string MauHoaDon
        {
            get
            {
                CanReadProperty("MauHoaDon", true);
                return _mauHoaDon;
            }
        }

        public string KyHieuMauHoaDon
        {
            get
            {
                CanReadProperty("KyHieuMauHoaDon", true);
                return _kyHieuMauHoaDon;
            }
        }

        public string SoHoDon
        {
            get
            {
                CanReadProperty("SoHoDon", true);
                return _soHoaDon;
            }
        }

        public int MaBoPhan
        {
            get
            {
                CanReadProperty(true);
                return _maBoPhan;
            }
        }

        public int LoaiNhapXuat
        {
            get
            {
                CanReadProperty(true);
                return _loaiNhapXuat;
            }
        }

        protected override object GetIdValue()
        {
            return _maKy;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DSHoaDonDichVu_BaoCao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DSHoaDonDichVu_BaoCaoViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DSHoaDonDichVu_BaoCao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DSHoaDonDichVu_BaoCaoAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DSHoaDonDichVu_BaoCao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DSHoaDonDichVu_BaoCaoEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DSHoaDonDichVu_BaoCao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DSHoaDonDichVu_BaoCaoDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DSHoaDonDichVu_BaoCao()
        { /* require use of factory method */ }

        public static DSHoaDonDichVu_BaoCao NewDSHoaDonDichVu_BaoCao(int maKy)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DSHoaDonDichVu_BaoCao");
            return DataPortal.Create<DSHoaDonDichVu_BaoCao>(new Criteria(maKy));
        }

        public static DSHoaDonDichVu_BaoCao GetDSHoaDonDichVu_BaoCao(int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DSHoaDonDichVu_BaoCao");
            return DataPortal.Fetch<DSHoaDonDichVu_BaoCao>(new Criteria(maKy));
        }

        public static void DeleteDSHoaDonDichVu_BaoCao(int maKy)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DSHoaDonDichVu_BaoCao");
            DataPortal.Delete(new Criteria(maKy));
        }

        public override DSHoaDonDichVu_BaoCao Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DSHoaDonDichVu_BaoCao");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DSHoaDonDichVu_BaoCao");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DSHoaDonDichVu_BaoCao");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private DSHoaDonDichVu_BaoCao(int maKy)
        {
            this._maKy = maKy;
        }

        internal static DSHoaDonDichVu_BaoCao NewDSHoaDonDichVu_BaoCaoChild(int maKy)
        {
            DSHoaDonDichVu_BaoCao child = new DSHoaDonDichVu_BaoCao(maKy);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DSHoaDonDichVu_BaoCao GetDSHoaDonDichVu_BaoCao(SafeDataReader dr)
        {
            DSHoaDonDichVu_BaoCao child = new DSHoaDonDichVu_BaoCao();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static DSHoaDonDichVu_BaoCao GetObject_ChonBaoCao_HoaDonMuaVao(SafeDataReader dr)
        {
            DSHoaDonDichVu_BaoCao child = new DSHoaDonDichVu_BaoCao();
            child.MarkAsChild();
            child.FetchObject_ChonBaoCao(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaKy;

            public Criteria(int maKy)
            {
                this.MaKy = maKy;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _maKy = criteria.MaKy;
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DSHoaDonDichVu_BaoCao";
                cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maKy));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteDelete(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeleteDSHoaDonDichVu_BaoCao";

                cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            // _maKy = dr.GetInt32("MaKy");
            _thang = dr.GetInt32("thang");
            _nam = dr.GetInt32("nam");
            _soHoaDon = dr.GetString("Sohoadon");
            _soserial = dr.GetString("soserial");
            _ngaylap = dr.GetDateTime("ngaylap");
            _tendoitac = dr.GetString("tendoitac");
            _masothue = dr.GetString("masothue");
            _mathang = dr.GetString("mathang");
            _sotien = dr.GetDecimal("sotien");
            _thuesuat = dr.GetInt32("thuesuat");
            _tienthue = dr.GetDecimal("tienthue");
            _tiensauthue = dr.GetDecimal("tiensauthue");
            _ghichu = dr.GetString("GhiChu");
            _ngaylaphd = dr.GetDateTime("ngaylaphd");
            _loaidv = dr.GetString("loaidv");
            _mauHoaDon = dr.GetString("MauHoaDon");
            _kyHieuMauHoaDon = dr.GetString("KyHieuMauHoaDon");
        }

        private void FetchObject_ChonBaoCao(SafeDataReader dr)
        {
            // _maKy = dr.GetInt32("MaKy");
            //_thang = dr.GetInt32("thang");
            //_nam = dr.GetInt32("nam");
            _mahoadon = dr.GetInt64("mahoadon");
            _soserial = dr.GetString("soserial");
            _ngaylap = dr.GetDateTime("ngaylap");
            _tendoitac = dr.GetString("tendoitac");
            _masothue = dr.GetString("masothue");
            _mathang = dr.GetString("mathang");
            _sotien = dr.GetDecimal("sotien");
            _thuesuat = dr.GetInt32("thuesuat");
            _tienthue = dr.GetDecimal("tienthue");
            _tiensauthue = dr.GetDecimal("tiensauthue");
            _ghichu = dr.GetString("GhiChu");
            _ngaylaphd = dr.GetDateTime("ngaylaphd");
            //_loaidv = dr.GetString("loaidv");
            _mauHoaDon = dr.GetString("MauHoaDon");
            _kyHieuMauHoaDon = dr.GetString("KyHieuMauHoaDon");
            _check = dr.GetBoolean("Check");
            _soHoaDon = dr.GetString("SoHoaDon");
            _ngayGhiSo = dr.GetDateTime("NgayGhiSo");
            _maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _loaiNhapXuat = dr.GetInt32("LoaiNhapXuat");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            //if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spInsert_tblDSHoaDonDichVu";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKy", _maKy);
            cm.Parameters.AddWithValue("@MaHoaDon", _mahoadon);
            cm.Parameters.AddWithValue("@SoSerial", _soserial);
            cm.Parameters.AddWithValue("@SoHoaDon", _soHoaDon);
            cm.Parameters.AddWithValue("@NgayLap", DateTime.Now.Date);
            cm.Parameters.AddWithValue("@TenDoiTac", _tendoitac);
            cm.Parameters.AddWithValue("@MaSoThue", _masothue);
            cm.Parameters.AddWithValue("@MatHang", _mathang);
            if (_sotien != 0)
                cm.Parameters.AddWithValue("@SoTien", _sotien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_thuesuat != 0)
                cm.Parameters.AddWithValue("@ThueSuat", _thuesuat);
            else
                cm.Parameters.AddWithValue("@ThueSuat", DBNull.Value);
            if (_tienthue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienthue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);
            if (_tiensauthue != 0)
                cm.Parameters.AddWithValue("@TienSauThue", _tiensauthue);
            else
                cm.Parameters.AddWithValue("@TienSauThue", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghichu);
            cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@NgayLapHD", _ngaylaphd);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTT", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiDV", _loaidv);
            cm.Parameters.AddWithValue("@MauHoaDon", _mauHoaDon);
            cm.Parameters.AddWithValue("@KyHieuMauHoaDon", _kyHieuMauHoaDon);
            cm.Parameters.AddWithValue("@NhomHHDVMuaVao", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);

        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[dbo].[spd_UpdatetblToKhaiThueGTGTGianTiep]";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {

        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maKy));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }

}
