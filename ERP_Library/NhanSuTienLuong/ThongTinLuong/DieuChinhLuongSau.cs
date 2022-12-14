
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DieuChinhLuongSau : Csla.BusinessBase<DieuChinhLuongSau>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maChiTiet = 0;
        private int _maKyTinhLuong = 0;
        private int _maBoPhan = 0;
        private long _maNhanVien = 0;
        private DateTime _tuThang = DateTime.Today;
        private DateTime _denThang = DateTime.Today;
        private int _soThang = 0;
        private decimal _heSoLuongTruoc = 0;
        private decimal _heSoPCTruoc = 0;
        private decimal _heSoVKTruoc = 0;
        private decimal _tiLeTruoc = 0;
        private decimal _heSoLuongSau = 0;
        private decimal _heSoPCSau = 0;
        private decimal _heSoVKSau = 0;
        private decimal _tiLeSau = 0;
        private decimal _luongDot1Truoc = 0;
        private decimal _luongDot2Truoc = 0;
        private decimal _bHXHTruoc = 0;
        private decimal _soTienTruoc = 0;
        private decimal _luongDot1Sau = 0;
        private decimal _luongDot2Sau = 0;
        private decimal _bHXHSau = 0;
        private decimal _soTienSau = 0;
        private decimal _soTienDieuChinh = 0;
        private string _ghiChu = string.Empty;
        private bool _traLuongQuaTK = false;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        public int MaKyTinhLuong
        {
            get
            {
                return _maKyTinhLuong;
            }
            set
            {
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                    CapNhatTruocDieuChinh();
                }
            }
        }

        public DateTime TuThang
        {
            get
            {
                return _tuThang;
            }
            set
            {
                if (!_tuThang.Equals(value))
                {
                    _tuThang = value;
                    PropertyHasChanged("TuThang");
                    CapNhatSoThang();
                    CapNhatTruocDieuChinh();
                }
            }
        }

        public DateTime DenThang
        {
            get
            {
                return _denThang;
            }
            set
            {
                if (!_denThang.Equals(value))
                {
                    _denThang = value;
                    PropertyHasChanged("DenThang");
                    CapNhatSoThang();
                }
            }
        }

        public int SoThang
        {
            get
            {
                return _soThang;
            }
            set
            {
                if (!_soThang.Equals(value))
                {
                    _soThang = value;
                    PropertyHasChanged("SoThang");
                }
            }
        }

        public decimal HeSoLuongTruoc
        {
            get
            {
                return _heSoLuongTruoc;
            }
            set
            {
                if (!_heSoLuongTruoc.Equals(value))
                {
                    _heSoLuongTruoc = value;
                    PropertyHasChanged("HeSoLuongTruoc");
                }
            }
        }

        public decimal HeSoPCTruoc
        {
            get
            {
                return _heSoPCTruoc;
            }
            set
            {
                if (!_heSoPCTruoc.Equals(value))
                {
                    _heSoPCTruoc = value;
                    PropertyHasChanged("HeSoPCTruoc");
                }
            }
        }

        public decimal HeSoVKTruoc
        {
            get
            {
                return _heSoVKTruoc;
            }
            set
            {
                if (!_heSoVKTruoc.Equals(value))
                {
                    _heSoVKTruoc = value;
                    PropertyHasChanged("HeSoVKTruoc");
                }
            }
        }

        public decimal TiLeTruoc
        {
            get
            {
                return _tiLeTruoc;
            }
            set
            {
                if (!_tiLeTruoc.Equals(value))
                {
                    _tiLeTruoc = value;
                    PropertyHasChanged("TiLeTruoc");
                }
            }
        }

        public decimal HeSoLuongSau
        {
            get
            {
                return _heSoLuongSau;
            }
            set
            {
                if (!_heSoLuongSau.Equals(value))
                {
                    _heSoLuongSau = value;
                    PropertyHasChanged("HeSoLuongSau");
                }
            }
        }

        public decimal HeSoPCSau
        {
            get
            {
                return _heSoPCSau;
            }
            set
            {
                if (!_heSoPCSau.Equals(value))
                {
                    _heSoPCSau = value;
                    PropertyHasChanged("HeSoPCSau");
                }
            }
        }

        public decimal HeSoVKSau
        {
            get
            {
                return _heSoVKSau;
            }
            set
            {
                if (!_heSoVKSau.Equals(value))
                {
                    _heSoVKSau = value;
                    PropertyHasChanged("HeSoVKSau");
                }
            }
        }

        public decimal TiLeSau
        {
            get
            {
                return _tiLeSau;
            }
            set
            {
                if (!_tiLeSau.Equals(value))
                {
                    _tiLeSau = value;
                    PropertyHasChanged("TiLeSau");
                }
            }
        }

        public decimal LuongDot1Truoc
        {
            get
            {
                return _luongDot1Truoc;
            }
            set
            {
                if (!_luongDot1Truoc.Equals(value))
                {
                    _luongDot1Truoc = value;
                    PropertyHasChanged("LuongDot1Truoc");
                    SoTienTruoc = LuongDot1Truoc - BHXHTruoc + LuongDot2Truoc;
                    SoTienDieuChinh = SoTienSau - SoTienTruoc;
                }
            }
        }

        public decimal LuongDot2Truoc
        {
            get
            {
                return _luongDot2Truoc;
            }
            set
            {
                if (!_luongDot2Truoc.Equals(value))
                {
                    _luongDot2Truoc = value;
                    PropertyHasChanged("LuongDot2Truoc");
                    SoTienTruoc = LuongDot1Truoc - BHXHTruoc + LuongDot2Truoc;
                    SoTienDieuChinh = SoTienSau - SoTienTruoc;
                }
            }
        }

        public decimal BHXHTruoc
        {
            get
            {
                return _bHXHTruoc;
            }
            set
            {
                if (!_bHXHTruoc.Equals(value))
                {
                    _bHXHTruoc = value;
                    PropertyHasChanged("BHXHTruoc");
                    SoTienTruoc = LuongDot1Truoc - BHXHTruoc + LuongDot2Truoc;
                    SoTienDieuChinh = SoTienSau - SoTienTruoc;
                }
            }
        }

        public decimal SoTienTruoc
        {
            get
            {
                return _soTienTruoc;
            }
            set
            {
                if (!_soTienTruoc.Equals(value))
                {
                    _soTienTruoc = value;
                    PropertyHasChanged("SoTienTruoc");
                    SoTienDieuChinh = SoTienSau - SoTienTruoc;
                }
            }
        }

        public decimal LuongDot1Sau
        {
            get
            {
                return _luongDot1Sau;
            }
            set
            {
                if (!_luongDot1Sau.Equals(value))
                {
                    _luongDot1Sau = value;
                    PropertyHasChanged("LuongDot1Sau");
                    SoTienSau = LuongDot1Sau - BHXHSau + LuongDot2Sau;
                    SoTienDieuChinh = SoTienSau - SoTienTruoc;
                }
            }
        }

        public decimal LuongDot2Sau
        {
            get
            {
                return _luongDot2Sau;
            }
            set
            {
                if (!_luongDot2Sau.Equals(value))
                {
                    _luongDot2Sau = value;
                    PropertyHasChanged("LuongDot2Sau");
                    SoTienSau = LuongDot1Sau - BHXHSau + LuongDot2Sau;
                    SoTienDieuChinh = SoTienSau - SoTienTruoc;
                }
            }
        }

        public decimal BHXHSau
        {
            get
            {
                return _bHXHSau;
            }
            set
            {
                if (!_bHXHSau.Equals(value))
                {
                    _bHXHSau = value;
                    PropertyHasChanged("BHXHSau");
                    SoTienSau = LuongDot1Sau - BHXHSau + LuongDot2Sau;
                    SoTienDieuChinh = SoTienSau - SoTienTruoc;
                }
            }
        }

        public decimal SoTienSau
        {
            get
            {
                return _soTienSau;
            }
            set
            {
                if (!_soTienSau.Equals(value))
                {
                    _soTienSau = value;
                    PropertyHasChanged("SoTienSau");
                    SoTienDieuChinh = SoTienSau - SoTienTruoc;
                }
            }
        }

        public decimal SoTienDieuChinh
        {
            get
            {
                return _soTienDieuChinh;
            }
            set
            {
                if (!_soTienDieuChinh.Equals(value))
                {
                    _soTienDieuChinh = value;
                    PropertyHasChanged("SoTienDieuChinh");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public bool TraLuongQuaTK
        {
            get
            {
                return _traLuongQuaTK;
            }
            set
            {
                if (!_traLuongQuaTK.Equals(value))
                {
                    _traLuongQuaTK = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaBoPhan", "Chưa nhập bộ phận"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaNhanVien", "Chưa nhập nhân viên"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("TuThang", "Chưa nhập tháng bắt đầu điều chỉnh"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("DenThang", "Chưa nhập tháng kết thúc điều chỉnh"));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        public DieuChinhLuongSau()
        { /* require use of factory method */
            _tuThang = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            _denThang = _tuThang;
            _soThang = 1;
        }

        public static DieuChinhLuongSau NewDieuChinhLuongSau()
        {
            return DataPortal.Create<DieuChinhLuongSau>();
        }

        public static DieuChinhLuongSau GetDieuChinhLuongSau(int maChiTiet)
        {
            return DataPortal.Fetch<DieuChinhLuongSau>(new Criteria(maChiTiet));
        }

        public static void DeleteDieuChinhLuongSau(int maChiTiet)
        {
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DieuChinhLuongSau NewDieuChinhLuongSauChild()
        {
            DieuChinhLuongSau child = new DieuChinhLuongSau();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DieuChinhLuongSau GetDieuChinhLuongSau(SafeDataReader dr)
        {
            DieuChinhLuongSau child = new DieuChinhLuongSau();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaChiTiet;

            public Criteria(int maChiTiet)
            {
                this.MaChiTiet = maChiTiet;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
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
                cm.CommandText = "spd_Select_DieuChinhLuongSau";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
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
            DataPortal_Delete(new Criteria(_maChiTiet));
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
                cm.CommandText = "spd_Delete_DieuChinhLuongSau";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tuThang = dr.GetDateTime("TuThang");
            _denThang = dr.GetDateTime("DenThang");
            _soThang = dr.GetInt32("SoThang");
            _heSoLuongTruoc = dr.GetDecimal("HeSoLuongTruoc");
            _heSoPCTruoc = dr.GetDecimal("HeSoPCTruoc");
            _heSoVKTruoc = dr.GetDecimal("HeSoVKTruoc");
            _tiLeTruoc = dr.GetDecimal("TiLeTruoc");
            _heSoLuongSau = dr.GetDecimal("HeSoLuongSau");
            _heSoPCSau = dr.GetDecimal("HeSoPCSau");
            _heSoVKSau = dr.GetDecimal("HeSoVKSau");
            _tiLeSau = dr.GetDecimal("TiLeSau");
            _luongDot1Truoc = dr.GetDecimal("LuongDot1Truoc");
            _luongDot2Truoc = dr.GetDecimal("LuongDot2Truoc");
            _bHXHTruoc = dr.GetDecimal("BHXHTruoc");
            _soTienTruoc = dr.GetDecimal("SoTienTruoc");
            _luongDot1Sau = dr.GetDecimal("LuongDot1Sau");
            _luongDot2Sau = dr.GetDecimal("LuongDot2Sau");
            _bHXHSau = dr.GetDecimal("BHXHSau");
            _soTienSau = dr.GetDecimal("SoTienSau");
            _soTienDieuChinh = dr.GetDecimal("SoTienDieuChinh");
            _ghiChu = dr.GetString("GhiChu");
            _traLuongQuaTK = dr.GetBoolean("TraLuongQuaTK");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

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
                cm.CommandText = "spd_Insert_DieuChinhLuongSau";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@TuThang", _tuThang);
            cm.Parameters.AddWithValue("@DenThang", _denThang);
            cm.Parameters.AddWithValue("@SoThang", _soThang);
            cm.Parameters.AddWithValue("@HeSoLuongTruoc", _heSoLuongTruoc);
            cm.Parameters.AddWithValue("@HeSoPCTruoc", _heSoPCTruoc);
            cm.Parameters.AddWithValue("@HeSoVKTruoc", _heSoVKTruoc);
            cm.Parameters.AddWithValue("@TiLeTruoc", _tiLeTruoc);
            cm.Parameters.AddWithValue("@HeSoLuongSau", _heSoLuongSau);
            cm.Parameters.AddWithValue("@HeSoPCSau", _heSoPCSau);
            cm.Parameters.AddWithValue("@HeSoVKSau", _heSoVKSau);
            cm.Parameters.AddWithValue("@TiLeSau", _tiLeSau);
            cm.Parameters.AddWithValue("@LuongDot1Truoc", _luongDot1Truoc);
            cm.Parameters.AddWithValue("@LuongDot2Truoc", _luongDot2Truoc);
            cm.Parameters.AddWithValue("@BHXHTruoc", _bHXHTruoc);
            cm.Parameters.AddWithValue("@SoTienTruoc", _soTienTruoc);
            cm.Parameters.AddWithValue("@LuongDot1Sau", _luongDot1Sau);
            cm.Parameters.AddWithValue("@LuongDot2Sau", _luongDot2Sau);
            cm.Parameters.AddWithValue("@BHXHSau", _bHXHSau);
            cm.Parameters.AddWithValue("@SoTienSau", _soTienSau);
            cm.Parameters.AddWithValue("@SoTienDieuChinh", _soTienDieuChinh);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@TraLuongQuaTK", _traLuongQuaTK);
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
                cm.CommandText = "spd_Update_DieuChinhLuongSau";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@TuThang", _tuThang);
            cm.Parameters.AddWithValue("@DenThang", _denThang);
            cm.Parameters.AddWithValue("@SoThang", _soThang);
            cm.Parameters.AddWithValue("@HeSoLuongTruoc", _heSoLuongTruoc);
            cm.Parameters.AddWithValue("@HeSoPCTruoc", _heSoPCTruoc);
            cm.Parameters.AddWithValue("@HeSoVKTruoc", _heSoVKTruoc);
            cm.Parameters.AddWithValue("@TiLeTruoc", _tiLeTruoc);
            cm.Parameters.AddWithValue("@HeSoLuongSau", _heSoLuongSau);
            cm.Parameters.AddWithValue("@HeSoPCSau", _heSoPCSau);
            cm.Parameters.AddWithValue("@HeSoVKSau", _heSoVKSau);
            cm.Parameters.AddWithValue("@TiLeSau", _tiLeSau);
            cm.Parameters.AddWithValue("@LuongDot1Truoc", _luongDot1Truoc);
            cm.Parameters.AddWithValue("@LuongDot2Truoc", _luongDot2Truoc);
            cm.Parameters.AddWithValue("@BHXHTruoc", _bHXHTruoc);
            cm.Parameters.AddWithValue("@SoTienTruoc", _soTienTruoc);
            cm.Parameters.AddWithValue("@LuongDot1Sau", _luongDot1Sau);
            cm.Parameters.AddWithValue("@LuongDot2Sau", _luongDot2Sau);
            cm.Parameters.AddWithValue("@BHXHSau", _bHXHSau);
            cm.Parameters.AddWithValue("@SoTienSau", _soTienSau);
            cm.Parameters.AddWithValue("@SoTienDieuChinh", _soTienDieuChinh);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@TraLuongQuaTK", _traLuongQuaTK);
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

            ExecuteDelete(tr, new Criteria(_maChiTiet));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        private void CapNhatSoThang()
        {
            //cập nhật lại số tháng
            int count = 0;
            for (DateTime thang = _tuThang; thang <= _denThang; thang = thang.AddMonths(1))
                count++;
            SoThang = count;
        }

        private void CapNhatTruocDieuChinh()
        {
            //cập nhật lại lương, bhxh trước điều chỉnh , dữ liệu lấy từ bảng lương
            //tìm kỳ lương
            int kyluong = 0;
            bool hl = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandText = "Select MaKy From tblnsKyTinhLuong Where NgayBatDau <= @Thang AND NgayKetThuc >= @Thang AND MaKyChinh IS NULL";
                cm.CommandType = CommandType.Text;
                cm.Parameters.AddWithValue("@Thang", _tuThang.AddMonths(-1));
                try
                {
                    kyluong = (int)cm.ExecuteScalar();
                    hl = true;
                }
                catch
                {
                    hl = false;//không có dữ liệu trên bảng lương
                }
                cn.Close();
            }
            //cập nhật 
            if (hl)
            {
                LuongTruocDieuChinh item = LuongTruocDieuChinh.GetLuongTruocDieuChinh(kyluong, _maNhanVien);
                HeSoLuongTruoc = item.HSPhu;
                HeSoPCTruoc = item.HSChucVu;
                HeSoVKTruoc = item.HSVuotKhung;
                TiLeTruoc = item.PTLuongV1;
                LuongDot1Truoc = item.LuongV1;
                BHXHTruoc = item.Bhxh;
                LuongDot2Truoc = item.LuongV2;
                SoTienTruoc = item.SoTien;
                SoTienDieuChinh = SoTienSau - SoTienTruoc;
            }
        }
    }
}
