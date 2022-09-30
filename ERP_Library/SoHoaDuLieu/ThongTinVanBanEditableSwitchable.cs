
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{
    [Serializable()]
    public class ThongTinVanBan : Csla.BusinessBase<ThongTinVanBan>
    {
        #region Business Properties and Methods

        //declare members
        private long _maThongTinVanBan = 0;
        private long _maThongTinNhanVien = 0;
        private long _maBoPhan = 0;
        private long _maNhomVanBan = 0;
        private string _SoHoSo = string.Empty;
        private SmartDate _ngayLap = new SmartDate(DateTime.Now.Date);
        private string _tenFile;
        private string _dienGiai = string.Empty;
        private long _userId = 0;

        private double _viTri = 0.0d;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaThongTinVanBan
        {
            get
            {
                CanReadProperty("MaThongTinVanBan", true);
                return _maThongTinVanBan;
            }
        }

        public long MaThongTinNhanVien
        {
            get
            {
                CanReadProperty("MaThongTinNhanVien", true);
                return _maThongTinNhanVien;
            }
            set
            {
                CanWriteProperty("MaThongTinNhanVien", true);
                if (!_maThongTinNhanVien.Equals(value))
                {
                    _maThongTinNhanVien = value;
                    PropertyHasChanged("MaThongTinNhanVien");
                }
            }
        }

        public long MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public long MaNhomVanBan
        {
            get
            {
                CanReadProperty("MaNhomVanBan", true);
                return _maNhomVanBan;
            }
            set
            {
                CanWriteProperty("MaNhomVanBan", true);
                if (!_maNhomVanBan.Equals(value))
                {
                    _maNhomVanBan = value;
                    PropertyHasChanged("MaNhomVanBan");
                }
            }
        }

        public string SoHoSo
        {
            get
            {
                CanReadProperty("SoHoSo", true);
                return _SoHoSo;
            }
            set
            {
                CanWriteProperty("SoHoSo", true);
                if (value == null) value = string.Empty;
                if (!_SoHoSo.Equals(value))
                {
                    _SoHoSo = value;
                    PropertyHasChanged("SoHoSo");
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
                if (value == null) value = DateTime.Now.Date;
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public string NgayLapString
        {
            get
            {
                CanReadProperty("NgayLapString", true);
                return _ngayLap.Text;
            }
            set
            {
                CanWriteProperty("NgayLapString", true);
                if (value == null) value = string.Empty;
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap.Text = value;
                    PropertyHasChanged("NgayLapString");
                }
            }
        }

        public string TenFile
        {
            get
            {
                CanReadProperty("TenFile", true);
                return _tenFile;
            }
            set
            {
                CanWriteProperty("TenFile", true);
                _tenFile = value;
                PropertyHasChanged("TenFile");
            }
        }

        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }

        public long UserId
        {
            get
            {
                CanReadProperty("UserId", true);
                return _userId;
            }
            set
            {
                CanWriteProperty("UserId", true);
                if (!_userId.Equals(value))
                {
                    _userId = value;
                    PropertyHasChanged("UserId");
                }
            }
        }

        public double ViTri
        {
            get
            {
                CanReadProperty("ViTri", true);
                return _viTri;
            }
            set
            {
                CanWriteProperty("ViTri", true);
                if (!_viTri.Equals(value))
                {
                    _viTri = value;
                    PropertyHasChanged("ViTri");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maThongTinVanBan;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        //private void AddCustomRules()
        //{
        //    //add custom/non-generated rules here...
        //}

        //private void AddCommonRules()
        //{
        //    //
        //    // SoHoSo
        //    //
        //    ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHoSo", 50));
        //}

        //protected override void AddBusinessRules()
        //{
        //    AddCommonRules();
        //    AddCustomRules();
        //}
        #endregion //Validation Rules

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in ThongTinVanBan
            //AuthorizationRules.AllowRead("MaThongTinVanBan", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("MaThongTinNhanVien", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("MaNhomVanBan", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("SoHoSo", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("HinhAnh", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "ThongTinVanBanReadGroup");
            //AuthorizationRules.AllowRead("UserId", "ThongTinVanBanReadGroup");

            //AuthorizationRules.AllowWrite("MaThongTinNhanVien", "ThongTinVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "ThongTinVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhomVanBan", "ThongTinVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("SoHoSo", "ThongTinVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ThongTinVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("HinhAnh", "ThongTinVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "ThongTinVanBanWriteGroup");
            //AuthorizationRules.AllowWrite("UserId", "ThongTinVanBanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinVanBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinVanBanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinVanBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinVanBanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinVanBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinVanBanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinVanBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinVanBanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinVanBan()
        { /* require use of factory method */ }

        public static ThongTinVanBan NewThongTinVanBan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinVanBan");
            return DataPortal.Create<ThongTinVanBan>();
        }

        public static ThongTinVanBan GetThongTinVanBan(long maThongTinVanBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinVanBan");
            return DataPortal.Fetch<ThongTinVanBan>(new Criteria(maThongTinVanBan));
        }

        public static void DeleteThongTinVanBan(long maThongTinVanBan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinVanBan");
            DataPortal.Delete(new Criteria(maThongTinVanBan));
        }

        public override ThongTinVanBan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinVanBan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinVanBan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThongTinVanBan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ThongTinVanBan NewThongTinVanBanChild()
        {
            ThongTinVanBan child = new ThongTinVanBan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ThongTinVanBan GetThongTinVanBan(SafeDataReader dr)
        {
            ThongTinVanBan child = new ThongTinVanBan();
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
            public long MaThongTinVanBan;

            public Criteria(long maThongTinVanBan)
            {
                this.MaThongTinVanBan = maThongTinVanBan;
            }
        }
        //-------------------------01/03/2016 -
        #region Get Max Vị trí theo mã nhân viên và mã loại văn bản
        public static double GetMaxMViTri_By_NhanVienAndLoaiVanBan(long maNhanVien, long maNhomVanBan)
        {
            double  _maxViTri = 0.0d;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SoHoaNhanSu_GetMaxViTri";
                    cm.Parameters.AddWithValue("@MaNhomVanBan", maNhomVanBan);
                    cm.Parameters.AddWithValue("@MaThongTinNhanVien", maNhanVien);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@ViTriMax", SqlDbType.Float);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _maxViTri = (double)prmGiaTriTraVe.Value;
                }
            }//us
            return _maxViTri;
        }
        #endregion
        //--------------------------
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

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
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
                cm.CommandText = "spd_SelecttblThongTinVanBan";

                cm.Parameters.AddWithValue("@MaThongTinVanBan", criteria.MaThongTinVanBan);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);

                        MarkAsChild();
                    }
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr, null);

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

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr, null);
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
            DataPortal_Delete(new Criteria(_maThongTinVanBan));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection_Digital))
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
                cm.CommandText = "spd_DeletetblThongTinVanBan";

                cm.Parameters.AddWithValue("@MaThongTinVanBan", criteria.MaThongTinVanBan);

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
            _maThongTinVanBan = dr.GetInt64("MaThongTinVanBan");
            _maThongTinNhanVien = dr.GetInt64("MaThongTinNhanVien");
            _maBoPhan = dr.GetInt64("MaBoPhan");
            _maNhomVanBan = dr.GetInt64("MaNhomVanBan");
            _SoHoSo = dr.GetString("SoHoSo");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            //if (dr.GetInt32("Loai") == 1)  
            //    _hinhAnh = (byte[])dr["HinhAnh"];
            _tenFile = dr.GetString("TenFile");
            _dienGiai = dr.GetString("DienGiai");
            _userId = dr.GetInt64("UserId");
            if (dr.GetInt32("Loai") == 1)
                _viTri = double.Parse(dr.GetDouble("ViTri").ToString());
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ThongTinVanBanList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ThongTinVanBanList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblThongTinVanBan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maThongTinVanBan = (long)cm.Parameters["@MaThongTinVanBan"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ThongTinVanBanList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maThongTinNhanVien != 0)
                cm.Parameters.AddWithValue("@MaThongTinNhanVien", _maThongTinNhanVien);
            else
                cm.Parameters.AddWithValue("@MaThongTinNhanVien", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maNhomVanBan != 0)
                cm.Parameters.AddWithValue("@MaNhomVanBan", _maNhomVanBan);
            else
                cm.Parameters.AddWithValue("@MaNhomVanBan", DBNull.Value);
            if (_SoHoSo.Length > 0)
                cm.Parameters.AddWithValue("@SoHoSo", _SoHoSo);
            else
                cm.Parameters.AddWithValue("@SoHoSo", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@TenFile", _tenFile);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);

            if (_viTri != 0.0d)
                cm.Parameters.AddWithValue("@ViTri", _viTri);
            else
                cm.Parameters.AddWithValue("@ViTri", DBNull.Value);

            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@MaThongTinVanBan", _maThongTinVanBan);
            cm.Parameters["@MaThongTinVanBan"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ThongTinVanBanList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, ThongTinVanBanList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblThongTinVanBan";
                AddUpdateParameters(cm, parent);
                cm.ExecuteNonQuery();
            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ThongTinVanBanList parent)
        {
            cm.Parameters.AddWithValue("@MaThongTinVanBan", _maThongTinVanBan);
            if (_maThongTinNhanVien != 0)
                cm.Parameters.AddWithValue("@MaThongTinNhanVien", _maThongTinNhanVien);
            else
                cm.Parameters.AddWithValue("@MaThongTinNhanVien", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maNhomVanBan != 0)
                cm.Parameters.AddWithValue("@MaNhomVanBan", _maNhomVanBan);
            else
                cm.Parameters.AddWithValue("@MaNhomVanBan", DBNull.Value);
            if (_SoHoSo.Length > 0)
                cm.Parameters.AddWithValue("@SoHoSo", _SoHoSo);
            else
                cm.Parameters.AddWithValue("@SoHoSo", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            //if (_hinhAnh != null)
            //    cm.Parameters.AddWithValue("@HinhAnh", _hinhAnh);
            //else
            //    cm.Parameters.AddWithValue("@HinhAnh", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);

            if (_viTri !=0.0d)
                cm.Parameters.AddWithValue("@ViTri", _viTri);
            else
                cm.Parameters.AddWithValue("@ViTri", DBNull.Value);

            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
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

            ExecuteDelete(tr, new Criteria(_maThongTinVanBan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
