
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinNguoiBiTaiNan : Csla.BusinessBase<ThongTinNguoiBiTaiNan>
    {
        #region Business Properties and Methods

        //declare members
        private int _maThongTinNguoiBiTaiNan = 0;
        private long _maNhanVien = 0;
        private string _MaQLNhanVien = string.Empty;
        private string _Tennhanvien = string.Empty;
        private int _maTaiNan = 0;
        private string _mucDo = string.Empty;
        private short _soNgayNghi = 0;
        private decimal _chiPhi = 0;
        private string _tinhTrangThuongTat = string.Empty;
        private string _noiVaPPDieuTri = string.Empty;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaThongTinNguoiBiTaiNan
        {
            get
            {
                CanReadProperty("MaThongTinNguoiBiTaiNan", true);
                return _maThongTinNguoiBiTaiNan;
            }
        }

        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public int MaTaiNan
        {
            get
            {
                CanReadProperty("MaTaiNan", true);
                return _maTaiNan;
            }
            set
            {
                CanWriteProperty("MaTaiNan", true);
                if (!_maTaiNan.Equals(value))
                {
                    _maTaiNan = value;
                    PropertyHasChanged("MaTaiNan");
                }
            }
        }

        public string MucDo
        {
            get
            {
                CanReadProperty("MucDo", true);
                return _mucDo;
            }
            set
            {
                CanWriteProperty("MucDo", true);
                if (value == null) value = string.Empty;
                if (!_mucDo.Equals(value))
                {
                    _mucDo = value;
                    PropertyHasChanged("MucDo");
                }
            }
        }

        public string MaQlNhanVien
        {
            get
            {
                CanReadProperty( true);
                return _MaQLNhanVien;
            }
            set
            {
                CanWriteProperty( true);
                if (!_MaQLNhanVien.Equals(value))
                {
                    _MaQLNhanVien = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _Tennhanvien;
            }
            set
            {
                CanWriteProperty( true);
                if (!_Tennhanvien.Equals(value))
                {
                    _Tennhanvien = value;
                    PropertyHasChanged();
                }
            }
        }

        public short SoNgayNghi
        {
            get
            {
                CanReadProperty("SoNgayNghi", true);
                return _soNgayNghi;
            }
            set
            {
                CanWriteProperty("SoNgayNghi", true);
                if (!_soNgayNghi.Equals(value))
                {
                    _soNgayNghi = value;
                    PropertyHasChanged("SoNgayNghi");
                }
            }
        }

        public decimal ChiPhi
        {
            get
            {
                CanReadProperty("ChiPhi", true);
                return _chiPhi;
            }
            set
            {
                CanWriteProperty("ChiPhi", true);
                if (!_chiPhi.Equals(value))
                {
                    _chiPhi = value;
                    PropertyHasChanged("ChiPhi");
                }
            }
        }

        public string TinhTrangThuongTat
        {
            get
            {
                CanReadProperty("TinhTrangThuongTat", true);
                return _tinhTrangThuongTat;
            }
            set
            {
                CanWriteProperty("TinhTrangThuongTat", true);
                if (value == null) value = string.Empty;
                if (!_tinhTrangThuongTat.Equals(value))
                {
                    _tinhTrangThuongTat = value;
                    PropertyHasChanged("TinhTrangThuongTat");
                }
            }
        }

        public string NoiVaPPDieuTri
        {
            get
            {
                CanReadProperty("NoiVaPPDieuTri", true);
                return _noiVaPPDieuTri;
            }
            set
            {
                CanWriteProperty("NoiVaPPDieuTri", true);
                if (value == null) value = string.Empty;
                if (!_noiVaPPDieuTri.Equals(value))
                {
                    _noiVaPPDieuTri = value;
                    PropertyHasChanged("NoiVaPPDieuTri");
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

        protected override object GetIdValue()
        {
            return _maThongTinNguoiBiTaiNan;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //
            // MucDo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MucDo", 50));
            //
            // TinhTrangThuongTat
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TinhTrangThuongTat", 4000));
            //
            // NoiVaPPDieuTri
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiVaPPDieuTri", 4000));
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
            //TODO: Define authorization rules in ThongTinNguoiBiTaiNan
            //AuthorizationRules.AllowRead("MaThongTinNguoiBiTaiNan", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MaTaiNan", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MucDo", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("SoNgayNghi", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("ChiPhi", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("TinhTrangThuongTat", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NoiVaPPDieuTri", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ThongTinNguoiBiTaiNanReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ThongTinNguoiBiTaiNanReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiNan", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("MucDo", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("SoNgayNghi", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("ChiPhi", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrangThuongTat", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("NoiVaPPDieuTri", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "ThongTinNguoiBiTaiNanWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ThongTinNguoiBiTaiNanWriteGroup");
        }

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinNguoiBiTaiNan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNguoiBiTaiNanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinNguoiBiTaiNan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNguoiBiTaiNanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinNguoiBiTaiNan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNguoiBiTaiNanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinNguoiBiTaiNan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNguoiBiTaiNanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinNguoiBiTaiNan()
        { /* require use of factory method */
            MarkAsChild();
        }

        public static ThongTinNguoiBiTaiNan NewThongTinNguoiBiTaiNan()
        {
            ThongTinNguoiBiTaiNan item = new ThongTinNguoiBiTaiNan();
            item.MarkAsChild();
            return item;
        }

        public static ThongTinNguoiBiTaiNan GetThongTinNguoiBiTaiNan(int maThongTinNguoiBiTaiNan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNguoiBiTaiNan");
            return DataPortal.Fetch<ThongTinNguoiBiTaiNan>(new Criteria(maThongTinNguoiBiTaiNan));
        }

        public static void DeleteThongTinNguoiBiTaiNan(int maThongTinNguoiBiTaiNan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinNguoiBiTaiNan");
            DataPortal.Delete(new Criteria(maThongTinNguoiBiTaiNan));
        }

        public override ThongTinNguoiBiTaiNan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinNguoiBiTaiNan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinNguoiBiTaiNan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThongTinNguoiBiTaiNan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ThongTinNguoiBiTaiNan NewThongTinNguoiBiTaiNanChild()
        {
            ThongTinNguoiBiTaiNan child = new ThongTinNguoiBiTaiNan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ThongTinNguoiBiTaiNan GetThongTinNguoiBiTaiNan(SafeDataReader dr)
        {
            ThongTinNguoiBiTaiNan child = new ThongTinNguoiBiTaiNan();
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
            public int MaThongTinNguoiBiTaiNan;

            public Criteria(int maThongTinNguoiBiTaiNan)
            {
                this.MaThongTinNguoiBiTaiNan = maThongTinNguoiBiTaiNan;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
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
                cm.CommandText = "GetThongTinNguoiBiTaiNan";

                cm.Parameters.AddWithValue("@MaThongTinNguoiBiTaiNan", criteria.MaThongTinNguoiBiTaiNan);

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
            DataPortal_Delete(new Criteria(_maThongTinNguoiBiTaiNan));
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
                cm.CommandText = "DeleteThongTinNguoiBiTaiNan";

                cm.Parameters.AddWithValue("@MaThongTinNguoiBiTaiNan", criteria.MaThongTinNguoiBiTaiNan);

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
            _maThongTinNguoiBiTaiNan = dr.GetInt32("MaThongTinNguoiBiTaiNan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _Tennhanvien = dr.GetString("TennhanVien");
            _MaQLNhanVien = dr.GetString("MaQLNhanVien");
            _maTaiNan = dr.GetInt32("MaTaiNan");
            _mucDo = dr.GetString("MucDo");
            _soNgayNghi = dr.GetInt16("SoNgayNghi");
            _chiPhi = dr.GetDecimal("ChiPhi");
            _tinhTrangThuongTat = dr.GetString("TinhTrangThuongTat");
            _noiVaPPDieuTri = dr.GetString("NoiVaPPDieuTri");
            _ghiChu = dr.GetString("GhiChu");
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
        internal void Insert(SqlTransaction tr,ThongTinTaiNan Parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr,Parent);
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
                cm.CommandText = "AddThongTinNguoiBiTaiNan";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maThongTinNguoiBiTaiNan = (int)cm.Parameters["@NewMaThongTinNguoiBiTaiNan"].Value;
            }//using
        }
        private void ExecuteInsert(SqlTransaction tr,ThongTinTaiNan Parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsThongTinNguoiBiTaiNan";

                AddInsertParameters(cm,Parent);

                cm.ExecuteNonQuery();

                _maThongTinNguoiBiTaiNan = (int)cm.Parameters["@MaThongTinNguoiBiTaiNan"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaTaiNan", _maTaiNan);
            if (_mucDo.Length > 0)
                cm.Parameters.AddWithValue("@MucDo", _mucDo);
            else
                cm.Parameters.AddWithValue("@MucDo", DBNull.Value);
            if (_soNgayNghi != 0)
                cm.Parameters.AddWithValue("@SoNgayNghi", _soNgayNghi);
            else
                cm.Parameters.AddWithValue("@SoNgayNghi", DBNull.Value);
            if (_chiPhi != 0)
                cm.Parameters.AddWithValue("@ChiPhi", _chiPhi);
            else
                cm.Parameters.AddWithValue("@ChiPhi", DBNull.Value);
            if (_tinhTrangThuongTat.Length > 0)
                cm.Parameters.AddWithValue("@TinhTrangThuongTat", _tinhTrangThuongTat);
            else
                cm.Parameters.AddWithValue("@TinhTrangThuongTat", DBNull.Value);
            if (_noiVaPPDieuTri.Length > 0)
                cm.Parameters.AddWithValue("@NoiVaPPDieuTri", _noiVaPPDieuTri);
            else
                cm.Parameters.AddWithValue("@NoiVaPPDieuTri", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NewMaThongTinNguoiBiTaiNan", _maThongTinNguoiBiTaiNan);
            cm.Parameters["@NewMaThongTinNguoiBiTaiNan"].Direction = ParameterDirection.Output;
        }
        private void AddInsertParameters(SqlCommand cm,ThongTinTaiNan Parent)
        {
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaTaiNan", Parent.MaTaiNan);
            if (_mucDo.Length > 0)
                cm.Parameters.AddWithValue("@MucDo", _mucDo);
            else
                cm.Parameters.AddWithValue("@MucDo", DBNull.Value);
            if (_soNgayNghi != 0)
                cm.Parameters.AddWithValue("@SoNgayNghi", _soNgayNghi);
            else
                cm.Parameters.AddWithValue("@SoNgayNghi", DBNull.Value);
            if (_chiPhi != 0)
                cm.Parameters.AddWithValue("@ChiPhi", _chiPhi);
            else
                cm.Parameters.AddWithValue("@ChiPhi", DBNull.Value);
            if (_tinhTrangThuongTat.Length > 0)
                cm.Parameters.AddWithValue("@TinhTrangThuongTat", _tinhTrangThuongTat);
            else
                cm.Parameters.AddWithValue("@TinhTrangThuongTat", DBNull.Value);
            if (_noiVaPPDieuTri.Length > 0)
                cm.Parameters.AddWithValue("@NoiVaPPDieuTri", _noiVaPPDieuTri);
            else
                cm.Parameters.AddWithValue("@NoiVaPPDieuTri", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaThongTinNguoiBiTaiNan", _maThongTinNguoiBiTaiNan);
            cm.Parameters["@MaThongTinNguoiBiTaiNan"].Direction = ParameterDirection.Output;
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
        internal void Update(SqlTransaction tr,ThongTinTaiNan Parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr,Parent);
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
                cm.CommandText = "UpdateThongTinNguoiBiTaiNan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }
        private void ExecuteUpdate(SqlTransaction tr,ThongTinTaiNan Parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsThongTinNguoiBiTaiNan";

                AddUpdateParameters(cm,Parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaThongTinNguoiBiTaiNan", _maThongTinNguoiBiTaiNan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaTaiNan", _maTaiNan);
            if (_mucDo.Length > 0)
                cm.Parameters.AddWithValue("@MucDo", _mucDo);
            else
                cm.Parameters.AddWithValue("@MucDo", DBNull.Value);
            if (_soNgayNghi != 0)
                cm.Parameters.AddWithValue("@SoNgayNghi", _soNgayNghi);
            else
                cm.Parameters.AddWithValue("@SoNgayNghi", DBNull.Value);
            if (_chiPhi != 0)
                cm.Parameters.AddWithValue("@ChiPhi", _chiPhi);
            else
                cm.Parameters.AddWithValue("@ChiPhi", DBNull.Value);
            if (_tinhTrangThuongTat.Length > 0)
                cm.Parameters.AddWithValue("@TinhTrangThuongTat", _tinhTrangThuongTat);
            else
                cm.Parameters.AddWithValue("@TinhTrangThuongTat", DBNull.Value);
            if (_noiVaPPDieuTri.Length > 0)
                cm.Parameters.AddWithValue("@NoiVaPPDieuTri", _noiVaPPDieuTri);
            else
                cm.Parameters.AddWithValue("@NoiVaPPDieuTri", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
        }
        private void AddUpdateParameters(SqlCommand cm,ThongTinTaiNan Parent)
        {
            cm.Parameters.AddWithValue("@MaThongTinNguoiBiTaiNan", _maThongTinNguoiBiTaiNan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaTaiNan", Parent.MaTaiNan);
            if (_mucDo.Length > 0)
                cm.Parameters.AddWithValue("@MucDo", _mucDo);
            else
                cm.Parameters.AddWithValue("@MucDo", DBNull.Value);
            if (_soNgayNghi != 0)
                cm.Parameters.AddWithValue("@SoNgayNghi", _soNgayNghi);
            else
                cm.Parameters.AddWithValue("@SoNgayNghi", DBNull.Value);
            if (_chiPhi != 0)
                cm.Parameters.AddWithValue("@ChiPhi", _chiPhi);
            else
                cm.Parameters.AddWithValue("@ChiPhi", DBNull.Value);
            if (_tinhTrangThuongTat.Length > 0)
                cm.Parameters.AddWithValue("@TinhTrangThuongTat", _tinhTrangThuongTat);
            else
                cm.Parameters.AddWithValue("@TinhTrangThuongTat", DBNull.Value);
            if (_noiVaPPDieuTri.Length > 0)
                cm.Parameters.AddWithValue("@NoiVaPPDieuTri", _noiVaPPDieuTri);
            else
                cm.Parameters.AddWithValue("@NoiVaPPDieuTri", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maThongTinNguoiBiTaiNan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
