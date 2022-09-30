
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinTaiNan : Csla.BusinessBase<ThongTinTaiNan>
    {
        #region Business Properties and Methods

        //declare members
        private int _maTaiNan = 0;
        private string _tenTaiNan = string.Empty;
        private SmartDate _ngayTaiNan = new SmartDate(DateTime.Today);
        private bool _trongHayNgoai = false;
        private int _maLoaiTaiNan = 0;
        private string _TenLoaiTaiNan = string.Empty;
        private int _maNguyenNhanTaiNan = 0;
        private string _TenNguyenNhanTaiNan = string.Empty;
        private string _noiTaiNan = string.Empty;
        private decimal _thietHai = 0;
        private SmartDate _ngayLapBaoCao = new SmartDate(DateTime.Today);
        private string _moTaTaiNan = string.Empty;
        private string _ghiChu = string.Empty;
        private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private ThongTinNguoiBiTaiNanList _ThongtinNguoiBiTaiNanList = ThongTinNguoiBiTaiNanList.NewThongTinNguoiBiTaiNanList();


        [System.ComponentModel.DataObjectField(true, true)]
        public int MaTaiNan
        {
            get
            {
                CanReadProperty("MaTaiNan", true);
                return _maTaiNan;
            }
        }

        public string TenTaiNan
        {
            get
            {
                CanReadProperty("TenTaiNan", true);
                return _tenTaiNan;
            }
            set
            {
                CanWriteProperty("TenTaiNan", true);
                if (value == null) value = string.Empty;
                if (!_tenTaiNan.Equals(value))
                {
                    _tenTaiNan = value;
                    PropertyHasChanged("TenTaiNan");
                }
            }
        }

        public DateTime NgayTaiNan
        {
            get
            {
                CanReadProperty("NgayTaiNan", true);
                return _ngayTaiNan.Date;
            }
            set
            {
                CanWriteProperty("NgayTaiNan", true);
                if (!_ngayTaiNan.Equals(value))
                {
                    _ngayTaiNan = new SmartDate(value);
                    PropertyHasChanged("NgayTaiNan");
                }
            }
        }

        public bool TrongHayNgoai
        {
            get
            {
                CanReadProperty("TrongHayNgoai", true);
                return _trongHayNgoai;
            }
            set
            {
                CanWriteProperty("TrongHayNgoai", true);
                if (!_trongHayNgoai.Equals(value))
                {
                    _trongHayNgoai = value;
                    PropertyHasChanged("TrongHayNgoai");
                }
            }
        }

        public int MaLoaiTaiNan
        {
            get
            {
                CanReadProperty("MaLoaiTaiNan", true);
                return _maLoaiTaiNan;
            }
            set
            {
                CanWriteProperty("MaLoaiTaiNan", true);
                if (!_maLoaiTaiNan.Equals(value))
                {
                    _maLoaiTaiNan = value;
                    PropertyHasChanged("MaLoaiTaiNan");
                }
            }
        }

        public int MaNguyenNhanTaiNan
        {
            get
            {
                CanReadProperty("MaNguyenNhanTaiNan", true);
                return _maNguyenNhanTaiNan;
            }
            set
            {
                CanWriteProperty("MaNguyenNhanTaiNan", true);
                if (!_maNguyenNhanTaiNan.Equals(value))
                {
                    _maNguyenNhanTaiNan = value;
                    PropertyHasChanged("MaNguyenNhanTaiNan");
                }
            }
        }

        public string NoiTaiNan
        {
            get
            {
                CanReadProperty("NoiTaiNan", true);
                return _noiTaiNan;
            }
            set
            {
                CanWriteProperty("NoiTaiNan", true);
                if (value == null) value = string.Empty;
                if (!_noiTaiNan.Equals(value))
                {
                    _noiTaiNan = value;
                    PropertyHasChanged("NoiTaiNan");
                }
            }
        }

        public decimal ThietHai
        {
            get
            {
                CanReadProperty("ThietHai", true);
                return _thietHai;
            }
            set
            {
                CanWriteProperty("ThietHai", true);
                if (!_thietHai.Equals(value))
                {
                    _thietHai = value;
                    PropertyHasChanged("ThietHai");
                }
            }
        }

        public DateTime NgayLapBaoCao
        {
            get
            {
                CanReadProperty("NgayLapBaoCao", true);
                return _ngayLapBaoCao.Date;
            }
            set
            {
                CanWriteProperty("NgayLapBaoCao", true);
                if (!_ngayLapBaoCao.Equals(value))
                {
                    _ngayLapBaoCao = new SmartDate(value);
                    PropertyHasChanged("NgayLapBaoCao");
                }
            }
        }

        public string MoTaTaiNan
        {
            get
            {
                CanReadProperty("MoTaTaiNan", true);
                return _moTaTaiNan;
            }
            set
            {
                CanWriteProperty("MoTaTaiNan", true);
                if (value == null) value = string.Empty;
                if (!_moTaTaiNan.Equals(value))
                {
                    _moTaTaiNan = value;
                    PropertyHasChanged("MoTaTaiNan");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public long MaNguoiLap
        {
            get
            {
                CanReadProperty("MaNguoiLap", true);
                return _maNguoiLap;
            }
            set
            {
                CanWriteProperty("MaNguoiLap", true);
                if (!_maNguoiLap.Equals(value))
                {
                    _maNguoiLap = value;
                    PropertyHasChanged("MaNguoiLap");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public string TenLoaiTaiNan
        {
            get
            {
                CanReadProperty(true);
                return _TenLoaiTaiNan;
            }
        }

        public string TenNguyenNhanTaiNan
        {
            get
            {
                CanReadProperty(true);
                return _TenNguyenNhanTaiNan;
            }
        }

        public ThongTinNguoiBiTaiNanList ThongTinNguoiBiTainanList
        {
            get
            {
                CanReadProperty(true);
                return _ThongtinNguoiBiTaiNanList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ThongtinNguoiBiTaiNanList.Equals(value))
                {   
                    _ThongtinNguoiBiTaiNanList = value;
                    PropertyHasChanged();
                }

            }

        }

        protected override object GetIdValue()
        {
            return _maTaiNan;
        }

        /*public override bool IsValid
        {
            get
            {
                return base.IsValid || _ThongtinNguoiBiTaiNanList.IsValid;
            }
        }*/
        /*public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _ThongtinNguoiBiTaiNanList.IsDirty;
            }
        }*/
        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //
            // TenTaiNan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTaiNan", 4000));


            //
            // NoiTaiNan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiTaiNan", 4000));
            //
            // MoTaTaiNan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MoTaTaiNan", 4000));
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
            //TODO: Define authorization rules in ThongTinTaiNan
            //AuthorizationRules.AllowRead("MaTaiNan", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("TenTaiNan", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NgayTaiNan", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NgayTaiNanString", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("TrongHayNgoai", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiTaiNan", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MaNguyenNhanTaiNan", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NoiTaiNan", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("ThietHai", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NgayLapBaoCao", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NgayLapBaoCaoString", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MoTaTaiNan", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MaChiNhanh", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ThongTinTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ThongTinTaiNanReadGroup");

            //AuthorizationRules.AllowWrite("TenTaiNan", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("NgayTaiNanString", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("TrongHayNgoai", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiTaiNan", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguyenNhanTaiNan", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("NoiTaiNan", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("ThietHai", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapBaoCaoString", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("MoTaTaiNan", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("MaChiNhanh", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "ThongTinTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ThongTinTaiNanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinTaiNan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinTaiNanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinTaiNan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinTaiNanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinTaiNan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinTaiNanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinTaiNan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinTaiNanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinTaiNan()
        { /* require use of factory method */ }

        public static ThongTinTaiNan NewThongTinTaiNan()
        {
            ThongTinTaiNan item = new ThongTinTaiNan();
            item.MarkAsChild();
            return item;
        }

        public static ThongTinTaiNan GetThongTinTaiNan(int maTaiNan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinTaiNan");
            return DataPortal.Fetch<ThongTinTaiNan>(new Criteria(maTaiNan));
        }

        public static void DeleteThongTinTaiNan(int maTaiNan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinTaiNan");
            DataPortal.Delete(new Criteria(maTaiNan));
        }

        public override ThongTinTaiNan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinTaiNan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinTaiNan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThongTinTaiNan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ThongTinTaiNan NewThongTinTaiNanChild()
        {
            ThongTinTaiNan child = new ThongTinTaiNan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ThongTinTaiNan GetThongTinTaiNan(SafeDataReader dr)
        {
            ThongTinTaiNan child = new ThongTinTaiNan();
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
            public int MaTaiNan;

            public Criteria(int maTaiNan)
            {
                this.MaTaiNan = maTaiNan;
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
                cm.CommandText = "spd_SelecttblnsThongTinTaiNan";

                cm.Parameters.AddWithValue("@MaTaiNan", criteria.MaTaiNan);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(this.MaTaiNan);
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
            DataPortal_Delete(new Criteria(_maTaiNan));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    ExecuteDelete(tr, criteria);
                    tr.Commit();

            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsThongTinTaiNan";
                cm.Parameters.AddWithValue("@MaTaiNan", criteria.MaTaiNan);
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
            FetchChildren(this.MaTaiNan);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maTaiNan = dr.GetInt32("MaTaiNan");
            _tenTaiNan = dr.GetString("TenTaiNan");
            _ngayTaiNan = dr.GetSmartDate("NgayTaiNan", _ngayTaiNan.EmptyIsMin);
            _trongHayNgoai = dr.GetBoolean("TrongHayNgoai");
            _maLoaiTaiNan = dr.GetInt32("MaLoaiTaiNan");
            _TenLoaiTaiNan = dr.GetString("TenLoaiTaiNan");
            _maNguyenNhanTaiNan = dr.GetInt32("MaNguyenNhanTaiNan");
            _TenNguyenNhanTaiNan = dr.GetString("TenNguyennhantainan");
            _noiTaiNan = dr.GetString("NoiTaiNan");
            _thietHai = dr.GetDecimal("ThietHai");
            _ngayLapBaoCao = dr.GetSmartDate("NgayLapBaoCao", _ngayLapBaoCao.EmptyIsMin);
            _moTaTaiNan = dr.GetString("MoTaTaiNan");
            _ghiChu = dr.GetString("GhiChu");
            _maNguoiLap = dr.GetInt64("MaNguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
        }

        private void FetchChildren(int Matainan)
        {
            _ThongtinNguoiBiTaiNanList = ThongTinNguoiBiTaiNanList.GetThongTinNguoiBiTaiNanList(Matainan);
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
                cm.CommandText = "spd_InserttblnsThongTinTaiNan";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maTaiNan = (int)cm.Parameters["@MaTaiNan"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenTaiNan.Length > 0)
                cm.Parameters.AddWithValue("@TenTaiNan", _tenTaiNan);
            else
                cm.Parameters.AddWithValue("@TenTaiNan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayTaiNan", _ngayTaiNan.DBValue);
            cm.Parameters.AddWithValue("@TrongHayNgoai", _trongHayNgoai);
            cm.Parameters.AddWithValue("@MaLoaiTaiNan", _maLoaiTaiNan);
            cm.Parameters.AddWithValue("@MaNguyenNhanTaiNan", _maNguyenNhanTaiNan);
            if (_noiTaiNan.Length > 0)
                cm.Parameters.AddWithValue("@NoiTaiNan", _noiTaiNan);
            else
                cm.Parameters.AddWithValue("@NoiTaiNan", DBNull.Value);
            if (_thietHai != 0)
                cm.Parameters.AddWithValue("@ThietHai", _thietHai);
            else
                cm.Parameters.AddWithValue("@ThietHai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLapBaoCao", _ngayLapBaoCao.DBValue);
            if (_moTaTaiNan.Length > 0)
                cm.Parameters.AddWithValue("@MoTaTaiNan", _moTaTaiNan);
            else
                cm.Parameters.AddWithValue("@MoTaTaiNan", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaTaiNan", _maTaiNan);
            cm.Parameters["@MaTaiNan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsThongTinTaiNan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaTaiNan", _maTaiNan);
            if (_tenTaiNan.Length > 0)
                cm.Parameters.AddWithValue("@TenTaiNan", _tenTaiNan);
            else
                cm.Parameters.AddWithValue("@TenTaiNan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayTaiNan", _ngayTaiNan.DBValue);
            cm.Parameters.AddWithValue("@TrongHayNgoai", _trongHayNgoai);
            cm.Parameters.AddWithValue("@MaLoaiTaiNan", _maLoaiTaiNan);
            cm.Parameters.AddWithValue("@MaNguyenNhanTaiNan", _maNguyenNhanTaiNan);
            if (_noiTaiNan.Length > 0)
                cm.Parameters.AddWithValue("@NoiTaiNan", _noiTaiNan);
            else
                cm.Parameters.AddWithValue("@NoiTaiNan", DBNull.Value);
            if (_thietHai != 0)
                cm.Parameters.AddWithValue("@ThietHai", _thietHai);
            else
                cm.Parameters.AddWithValue("@ThietHai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLapBaoCao", _ngayLapBaoCao.DBValue);
            if (_moTaTaiNan.Length > 0)
                cm.Parameters.AddWithValue("@MoTaTaiNan", _moTaTaiNan);
            else
                cm.Parameters.AddWithValue("@MoTaTaiNan", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _ThongtinNguoiBiTaiNanList.UpdateData(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maTaiNan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
