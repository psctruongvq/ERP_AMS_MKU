
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class QuyetDinhBoNhiem : Csla.BusinessBase<QuyetDinhBoNhiem>
    {
        #region Business Properties and Methods

        //declare members
        private int _maQuyetDinh = 0;
        private string _soQuyetDinh = string.Empty;
        private int _maLoaiQuyetDinh = 0;
        private string _TenLoaiQD = string.Empty;
        private long _maNguoiCapQuyetdinh = 0;
        private string _Tennguoicap = string.Empty;
        private SmartDate _ngayKy = new SmartDate(DateTime.Today);
        private SmartDate _ngayHieuLuc = new SmartDate(DateTime.Today);
        private string _ghiChu = string.Empty;
        private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private CT_QuyetDinhBoNhiemList _CT_QuyetDinhBoNhiemList = CT_QuyetDinhBoNhiemList.NewCT_QuyetDinhBoNhiemList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaQuyetDinh
        {
            get
            {
                CanReadProperty("MaQuyetDinh", true);
                return _maQuyetDinh;
            }
        }

        public string SoQuyetDinh
        {
            get
            {
                CanReadProperty("SoQuyetDinh", true);
                return _soQuyetDinh;
            }
            set
            {
                CanWriteProperty("SoQuyetDinh", true);
                if (value == null) value = string.Empty;
                if (!_soQuyetDinh.Equals(value))
                {
                    _soQuyetDinh = value;
                    PropertyHasChanged("SoQuyetDinh");
                }
            }
        }

        public int MaLoaiQuyetDinh
        {
            get
            {
                CanReadProperty("MaLoaiQuyetDinh", true);
                return _maLoaiQuyetDinh;
            }
            set
            {
                CanWriteProperty("MaLoaiQuyetDinh", true);
                if (!_maLoaiQuyetDinh.Equals(value))
                {
                    _maLoaiQuyetDinh = value;
                    PropertyHasChanged("MaLoaiQuyetDinh");
                }
            }
        }

        public string TenLoaiQD
        {
            get
            {
                CanReadProperty(true);
                return _TenLoaiQD;
            }
        }

        public long MaNguoiCapQuyetdinh
        {
            get
            {
                CanReadProperty("MaNguoiCapQuyetdinh", true);
                return _maNguoiCapQuyetdinh;
            }
            set
            {
                CanWriteProperty("MaNguoiCapQuyetdinh", true);
                if (!_maNguoiCapQuyetdinh.Equals(value))
                {
                    _maNguoiCapQuyetdinh = value;
                    PropertyHasChanged("MaNguoiCapQuyetdinh");
                }
            }
        }

        public string TenNguoiCap
        {
            get
            {
                CanReadProperty( true);
                return _Tennguoicap;
            }          
        }

        public DateTime NgayKy
        {
            get
            {
                CanReadProperty("NgayKy", true);
                return _ngayKy.Date;
            }
            set
            {
                CanWriteProperty("NgayKy", true);
                if (!_ngayKy.Equals(value))
                {
                    _ngayKy = new SmartDate(value);
                    PropertyHasChanged("NgayKy");
                }
            }
        }

        public DateTime NgayHieuLuc
        {
            get
            {
                CanReadProperty("NgayHieuLuc", true);
                return _ngayHieuLuc.Date;
            }
            set
            {
                CanWriteProperty("NgayHieuLuc", true);
                if (!_ngayHieuLuc.Equals(value))
                {
                    _ngayHieuLuc = new SmartDate(value);
                    PropertyHasChanged("NgayHieuLuc");
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

        public CT_QuyetDinhBoNhiemList QuyetDinhBoNhiem_CTList
        {
            get
            {
                CanReadProperty(true);
                return _CT_QuyetDinhBoNhiemList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_CT_QuyetDinhBoNhiemList.Equals(value))
                {
                    _CT_QuyetDinhBoNhiemList = value;
                    PropertyHasChanged();
                }
            }

        }

        protected override object GetIdValue()
        {
            return _maQuyetDinh;
        }

        public override bool IsValid
        {
            get
            {
                return base.IsValid || _CT_QuyetDinhBoNhiemList.IsValid;
            }
        }

        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _CT_QuyetDinhBoNhiemList.IsDirty;
            }
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
            // SoQuyetDinh
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "SoQuyetDinh");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 50));
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
            //TODO: Define authorization rules in QuyetDinhBoNhiem
            //AuthorizationRules.AllowRead("MaQuyetDinh", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("SoQuyetDinh", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiQuyetDinh", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiCapQuyetdinh", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("NgayKy", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("NgayKyString", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("NgayHieuLuc", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("NgayHieuLucString", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "QuyetDinhBoNhiemReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "QuyetDinhBoNhiemReadGroup");

            //AuthorizationRules.AllowWrite("SoQuyetDinh", "QuyetDinhBoNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiQuyetDinh", "QuyetDinhBoNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiCapQuyetdinh", "QuyetDinhBoNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKyString", "QuyetDinhBoNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHieuLucString", "QuyetDinhBoNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "QuyetDinhBoNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "QuyetDinhBoNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "QuyetDinhBoNhiemWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuyetDinhBoNhiem
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhBoNhiemViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuyetDinhBoNhiem
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhBoNhiemAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuyetDinhBoNhiem
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhBoNhiemEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuyetDinhBoNhiem
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhBoNhiemDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuyetDinhBoNhiem()
        { /* require use of factory method */ }

        public static QuyetDinhBoNhiem NewQuyetDinhBoNhiem()
        {
            QuyetDinhBoNhiem item = new QuyetDinhBoNhiem();
            item.MarkAsChild();
            return item;
        }

        public static QuyetDinhBoNhiem GetQuyetDinhBoNhiem(int maQuyetDinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhBoNhiem");
            return DataPortal.Fetch<QuyetDinhBoNhiem>(new Criteria(maQuyetDinh));
        }

        public static void DeleteQuyetDinhBoNhiem(int maQuyetDinh)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuyetDinhBoNhiem");
            DataPortal.Delete(new Criteria(maQuyetDinh));
        }

        public override QuyetDinhBoNhiem Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuyetDinhBoNhiem");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuyetDinhBoNhiem");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a QuyetDinhBoNhiem");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static QuyetDinhBoNhiem NewQuyetDinhBoNhiemChild()
        {
            QuyetDinhBoNhiem child = new QuyetDinhBoNhiem();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static QuyetDinhBoNhiem GetQuyetDinhBoNhiem(SafeDataReader dr)
        {
            QuyetDinhBoNhiem child = new QuyetDinhBoNhiem();
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
            public int MaQuyetDinh;

            public Criteria(int maQuyetDinh)
            {
                this.MaQuyetDinh = maQuyetDinh;
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
                cm.CommandText = "spd_selecttblnsQuyetDinhBoNhiem";

                cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(this.MaQuyetDinh);
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
            DataPortal_Delete(new Criteria(_maQuyetDinh));
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
                cm.CommandText = "spd_DeletetblnsQuyetDinhBoNhiem";

                cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

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
            FetchChildren(this.MaQuyetDinh);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maQuyetDinh = dr.GetInt32("MaQuyetDinh");
            _soQuyetDinh = dr.GetString("SoQuyetDinh");
            _maLoaiQuyetDinh = dr.GetInt32("MaLoaiQuyetDinh");
            _TenLoaiQD = dr.GetString("TenLoaiQD");
            _maNguoiCapQuyetdinh = dr.GetInt64("MaNguoiCapQuyetdinh");
            _Tennguoicap = dr.GetString("TenNguoiCapQuyetDinh");
            _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
            _ngayHieuLuc = dr.GetSmartDate("NgayHieuLuc", _ngayHieuLuc.EmptyIsMin);
            _ghiChu = dr.GetString("GhiChu");
            _maNguoiLap = dr.GetInt64("MaNguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
        }

        private void FetchChildren(int maquyetdinh)
        {
            _CT_QuyetDinhBoNhiemList = CT_QuyetDinhBoNhiemList.GetCT_QuyetDinhBoNhiemList(maquyetdinh);
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
                cm.CommandText = "spd_InserttblnsQuyetDinhBoNhiem";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maQuyetDinh = (int)cm.Parameters["@MaQuyetDinh"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            if (_maLoaiQuyetDinh != 0)
                cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", _maLoaiQuyetDinh);
            else
                cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", DBNull.Value);
            if (_maNguoiCapQuyetdinh != 0)
                cm.Parameters.AddWithValue("@MaNguoiCapQuyetdinh", _maNguoiCapQuyetdinh);
            else
                cm.Parameters.AddWithValue("@MaNguoiCapQuyetdinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            cm.Parameters["@MaQuyetDinh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuyetDinhBoNhiem";

                AddUpdateParameters(cm);
                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            if (_maLoaiQuyetDinh != 0)
                cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", _maLoaiQuyetDinh);
            else
                cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", DBNull.Value);
            if (_maNguoiCapQuyetdinh != 0)
                cm.Parameters.AddWithValue("@MaNguoiCapQuyetdinh", _maNguoiCapQuyetdinh);
            else
                cm.Parameters.AddWithValue("@MaNguoiCapQuyetdinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _CT_QuyetDinhBoNhiemList.UpdateData(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
            _CT_QuyetDinhBoNhiemList.Clear();
            UpdateChildren(tr);
            ExecuteDelete(tr, new Criteria(_maQuyetDinh));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
