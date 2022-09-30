using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class QuyHoach : Csla.BusinessBase<QuyHoach>
    {
        #region Business Properties and Methods

        //declare members
        private int _maQuyHoach = 0;
        private SmartDate _ngayQuyHoach = new SmartDate(DateTime.Today);
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private int _maNguoiLap = 0;
        private string _dienGiai = string.Empty;
        //
        private ChiTietQuyHoachList _chitietQuyHoachList = ChiTietQuyHoachList.NewChiTietQuyHoachList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaQuyHoach
        {
            get
            {
                CanReadProperty("MaQuyHoach", true);
                return _maQuyHoach;
            }
        }

        
        public DateTime? NgayQuyHoach
        {
            get
            {
                CanReadProperty("NgayQuyHoach", true);
                if (_ngayQuyHoach.Date == DateTime.MinValue)
                    return null;
                return _ngayQuyHoach.Date;
            }
            set
            {
                CanWriteProperty("NgayQuyHoach", true);
                if (!_ngayQuyHoach.Equals(value))
                {
                    if (value == null)
                        _ngayQuyHoach = new SmartDate(DateTime.MinValue);
                    else
                        _ngayQuyHoach = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
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
                    PropertyHasChanged();
                }
            }
        }

        public int MaNguoiLap
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

        #region Bo Sung
        public int SoNguoiQuyHoach
        {
            get
            {
                return _chitietQuyHoachList.Count;
            }
        }
        #endregion

        public ChiTietQuyHoachList chitietQuyHoachList
        {
            get
            {
                CanReadProperty("chitietQuyHoachList", true);
                return _chitietQuyHoachList;
            }
        }

        protected override object GetIdValue()
        {
            return _maQuyHoach;
        }

        public override bool IsValid
        {
            get { return base.IsValid && _chitietQuyHoachList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _chitietQuyHoachList.IsDirty; }
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
            //TODO: Define authorization rules in QuyHoach
            //AuthorizationRules.AllowRead("MaQuyHoach", "QuyHoachReadGroup");
            //AuthorizationRules.AllowRead("NgayQuyHoach", "QuyHoachReadGroup");
            //AuthorizationRules.AllowRead("NgayQuyHoachString", "QuyHoachReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "QuyHoachReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "QuyHoachReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "QuyHoachReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "QuyHoachReadGroup");

            //AuthorizationRules.AllowWrite("NgayQuyHoachString", "QuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "QuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "QuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "QuyHoachWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuyHoach
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyHoachViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuyHoach
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyHoachAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuyHoach
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyHoachEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuyHoach
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyHoachDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuyHoach()
        { /* require use of factory method */ }

        public static QuyHoach NewQuyHoach()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuyHoach");
            return DataPortal.Create<QuyHoach>();
        }

        public static QuyHoach NewQuyHoach(QuyHoach quyHoach)
        {
            QuyHoach newQuyHoach = new QuyHoach();
            newQuyHoach.DienGiai = quyHoach.DienGiai;
            foreach (ChiTietQuyHoach ctQuyHoach in quyHoach.chitietQuyHoachList)
            {
                newQuyHoach.chitietQuyHoachList.Add(ChiTietQuyHoach.NewChiTietQuyHoach(ctQuyHoach));
            }
            return newQuyHoach;
            
        }

        public static QuyHoach GetQuyHoach(int maQuyHoach)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyHoach");
            return DataPortal.Fetch<QuyHoach>(new Criteria(maQuyHoach));
        }

        public static QuyHoach GetQuyHoachWithoutChild(int maQuyHoach)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyHoach");
            return DataPortal.Fetch<QuyHoach>(new CriteriaWithoutChild(maQuyHoach));
        }

        public static void DeleteQuyHoach(int maQuyHoach)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuyHoach");
            DataPortal.Delete(new Criteria(maQuyHoach));
        }

        #region Bosung
        public static void DeleteQuyHoach(QuyHoach quyHoach)
        {//B
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    quyHoach.chitietQuyHoachList.Clear();
                    quyHoach.chitietQuyHoachList.Update(tr, quyHoach);

                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblnsQuyHoach";

                        cm.Parameters.AddWithValue("@MaQuyHoach", quyHoach.MaQuyHoach);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }//E

        public static bool KiemTraTrungQuyHoachTrongNam(long maNhanVien, int maQuyHoach, int namQuyHoach)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckTrungQuyHoachTrongNam";
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.Parameters.AddWithValue("@MaQuyHoach", maQuyHoach);
                    cm.Parameters.AddWithValue("@NamQuyHoach", namQuyHoach);
                    SqlParameter outPara = new SqlParameter("@TrungQHtrongNam", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function
        #endregion

        public override QuyHoach Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuyHoach");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuyHoach");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a QuyHoach");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static QuyHoach NewQuyHoachChild()
        {
            QuyHoach child = new QuyHoach();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static QuyHoach GetQuyHoach(SafeDataReader dr)
        {
            QuyHoach child = new QuyHoach();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static QuyHoach GetQuyHoachWithoutChild(SafeDataReader dr)
        {
            QuyHoach child = new QuyHoach();
            child.MarkAsChild();
            child.FetchWithoutChild(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaQuyHoach;

            public Criteria(int maQuyHoach)
            {
                this.MaQuyHoach = maQuyHoach;
            }
        }

        private class CriteriaWithoutChild
        {
            public int MaQuyHoach;

            public CriteriaWithoutChild(int maQuyHoach)
            {
                this.MaQuyHoach = maQuyHoach;
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
        private void DataPortal_Fetch(object criteria)
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
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw;
                }

            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            if (criteria is Criteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsQuyHoach";

                    cm.Parameters.AddWithValue("@MaQuyHoach", ((Criteria)criteria).MaQuyHoach);

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
            else if(criteria is CriteriaWithoutChild)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsQuyHoach";

                    cm.Parameters.AddWithValue("@MaQuyHoach", ((CriteriaWithoutChild)criteria).MaQuyHoach);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                        ValidationRules.CheckRules();
                    }
                }//using  
            }
            
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
                catch (Exception ex)
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

                catch (Exception ex)
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
            DataPortal_Delete(new Criteria(_maQuyHoach));
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
                    _chitietQuyHoachList.Clear();
                    _chitietQuyHoachList.Update(tr,this);
                    UpdateChildren(tr);
                    ExecuteDelete(tr, criteria);
                    tr.Commit();
                }
                catch (Exception ex)
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
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsQuyHoach";

                cm.Parameters.AddWithValue("@MaQuyHoach", criteria.MaQuyHoach);

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

        private void FetchWithoutChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maQuyHoach = dr.GetInt32("MaQuyHoach");
            _ngayQuyHoach = dr.GetSmartDate("NgayQuyHoach", _ngayQuyHoach.EmptyIsMin);
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _dienGiai = dr.GetString("DienGiai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _chitietQuyHoachList = ChiTietQuyHoachList.GetChiTietQuyHoachList(this.MaQuyHoach);
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
                cm.CommandText = "spd_InserttblnsQuyHoach";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maQuyHoach = (int)cm.Parameters["@MaQuyHoach"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@NgayQuyHoach", _ngayQuyHoach.DBValue);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaQuyHoach", _maQuyHoach);
            cm.Parameters["@MaQuyHoach"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuyHoach";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaQuyHoach", _maQuyHoach);
            cm.Parameters.AddWithValue("@NgayQuyHoach", _ngayQuyHoach.DBValue);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _chitietQuyHoachList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maQuyHoach));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
