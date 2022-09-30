using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KiemKeCCDC : Csla.BusinessBase<KiemKeCCDC>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private int _maPhongBan = 0;
        private string _maQuanLyCCDC = string.Empty;
        private string _maPhongBanQL = string.Empty;
        private SmartDate _ngayKiemKe = new SmartDate(false);
        private string _filePath = string.Empty;
        private int _userID = 0;
        private int _maCCDC = 0;
        private int _maChiTietCCDC = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public int MaPhongBan
        {
            get
            {
                CanReadProperty("MaPhongBan", true);
                return _maPhongBan;
            }
            set
            {
                CanWriteProperty("MaPhongBan", true);
                if (!_maPhongBan.Equals(value))
                {
                    _maPhongBan = value;
                    PropertyHasChanged("MaPhongBan");
                }
            }
        }

        public string MaQuanLyCCDC
        {
            get
            {
                CanReadProperty("MaQuanLyCCDC", true);
                return _maQuanLyCCDC;
            }
            set
            {
                CanWriteProperty("MaQuanLyCCDC", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLyCCDC.Equals(value))
                {
                    _maQuanLyCCDC = value;
                    PropertyHasChanged("MaQuanLyCCDC");
                }
            }
        }

        public string MaPhongBanQL
        {
            get
            {
                CanReadProperty("MaPhongBanQL", true);
                return _maPhongBanQL;
            }
            set
            {
                CanWriteProperty("MaPhongBanQL", true);
                if (value == null) value = string.Empty;
                if (!_maPhongBanQL.Equals(value))
                {
                    _maPhongBanQL = value;
                    PropertyHasChanged("MaPhongBanQL");
                }
            }
        }

        public DateTime NgayKiemKe
        {
            get
            {
                CanReadProperty("NgayKiemKe", true);
                return _ngayKiemKe.Date;
            }
        }

        public string NgayKiemKeString
        {
            get
            {
                CanReadProperty("NgayKiemKeString", true);
                return _ngayKiemKe.Text;
            }
            set
            {
                CanWriteProperty("NgayKiemKeString", true);
                if (value == null) value = string.Empty;
                if (!_ngayKiemKe.Equals(value))
                {
                    _ngayKiemKe.Text = value;
                    PropertyHasChanged("NgayKiemKeString");
                }
            }
        }

        public string FilePath
        {
            get
            {
                CanReadProperty("FilePath", true);
                return _filePath;
            }
            set
            {
                CanWriteProperty("FilePath", true);
                if (value == null) value = string.Empty;
                if (!_filePath.Equals(value))
                {
                    _filePath = value;
                    PropertyHasChanged("FilePath");
                }
            }
        }

        public int UserID
        {
            get
            {
                CanReadProperty("UserID", true);
                return _userID;
            }
            set
            {
                CanWriteProperty("UserID", true);
                if (!_userID.Equals(value))
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
                }
            }
        }

        public int MaCCDC
        {
            get
            {
                CanReadProperty("MaCCDC", true);
                return _maCCDC;
            }
            set
            {
                CanWriteProperty("MaCCDC", true);
                if (!_maCCDC.Equals(value))
                {
                    _maCCDC = value;
                    PropertyHasChanged("MaCCDC");
                }
            }
        }

        public int MaChiTietCCDC
        {
            get
            {
                CanReadProperty("MaChiTietCCDC", true);
                return _maChiTietCCDC;
            }
            set
            {
                CanWriteProperty("MaChiTietCCDC", true);
                if (!_maChiTietCCDC.Equals(value))
                {
                    _maChiTietCCDC = value;
                    PropertyHasChanged("MaChiTietCCDC");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _id;
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
            // MaQuanLyCCDC
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLyCCDC", 50));
            //
            // MaPhongBanQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhongBanQL", 50));
            //
            // FilePath
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("FilePath", 255));
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
            //TODO: Define authorization rules in KiemKeCCDC
            //AuthorizationRules.AllowRead("Id", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("MaPhongBan", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLyCCDC", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("MaPhongBanQL", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("NgayKiemKe", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("NgayKiemKeString", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("FilePath", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("UserID", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("MaCCDC", "KiemKeCCDCReadGroup");
            //AuthorizationRules.AllowRead("MaChiTietCCDC", "KiemKeCCDCReadGroup");

            //AuthorizationRules.AllowWrite("MaPhongBan", "KiemKeCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuanLyCCDC", "KiemKeCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhongBanQL", "KiemKeCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKiemKeString", "KiemKeCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("FilePath", "KiemKeCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "KiemKeCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("MaCCDC", "KiemKeCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("MaChiTietCCDC", "KiemKeCCDCWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KiemKeCCDC
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KiemKeCCDCViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KiemKeCCDC
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KiemKeCCDCAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KiemKeCCDC
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KiemKeCCDCEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KiemKeCCDC
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KiemKeCCDCDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KiemKeCCDC()
        { /* require use of factory method */ }

        public static KiemKeCCDC NewKiemKeCCDC()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KiemKeCCDC");
            return DataPortal.Create<KiemKeCCDC>();
        }

        public static KiemKeCCDC GetKiemKeCCDC(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KiemKeCCDC");
            return DataPortal.Fetch<KiemKeCCDC>(new Criteria(id));
        }

        public static void DeleteKiemKeCCDC(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KiemKeCCDC");
            DataPortal.Delete(new Criteria(id));
        }

        public override KiemKeCCDC Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KiemKeCCDC");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KiemKeCCDC");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a KiemKeCCDC");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KiemKeCCDC NewKiemKeCCDCChild()
        {
            KiemKeCCDC child = new KiemKeCCDC();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KiemKeCCDC GetKiemKeCCDC(SafeDataReader dr)
        {
            KiemKeCCDC child = new KiemKeCCDC();
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
            public int Id;

            public Criteria(int id)
            {
                this.Id = id;
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetKiemKeCCDC";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteInsert(cn);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_id));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeleteKiemKeCCDC";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            _id = dr.GetInt32("ID");
            _maPhongBan = dr.GetInt32("MaPhongBan");
            _maQuanLyCCDC = dr.GetString("MaQuanLyCCDC");
            _maPhongBanQL = dr.GetString("MaPhongBanQL");
            _ngayKiemKe = dr.GetSmartDate("NgayKiemKe", _ngayKiemKe.EmptyIsMin);
            _filePath = dr.GetString("FilePath");
            _userID = dr.GetInt32("UserID");
            _maCCDC = dr.GetInt32("MaCCDC");
            _maChiTietCCDC = dr.GetInt32("MaChiTietCCDC");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "AddKiemKeCCDC";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@NewID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maPhongBan != 0)
                cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
            else
                cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
            if (_maQuanLyCCDC.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLyCCDC", _maQuanLyCCDC);
            else
                cm.Parameters.AddWithValue("@MaQuanLyCCDC", DBNull.Value);
            if (_maPhongBanQL.Length > 0)
                cm.Parameters.AddWithValue("@MaPhongBanQL", _maPhongBanQL);
            else
                cm.Parameters.AddWithValue("@MaPhongBanQL", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKiemKe", _ngayKiemKe.DBValue);
            if (_filePath.Length > 0)
                cm.Parameters.AddWithValue("@FilePath", _filePath);
            else
                cm.Parameters.AddWithValue("@FilePath", DBNull.Value);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", DBNull.Value);
            if (_maCCDC != 0)
                cm.Parameters.AddWithValue("@MaCCDC", _maCCDC);
            else
                cm.Parameters.AddWithValue("@MaCCDC", DBNull.Value);
            if (_maChiTietCCDC != 0)
                cm.Parameters.AddWithValue("@MaChiTietCCDC", _maChiTietCCDC);
            else
                cm.Parameters.AddWithValue("@MaChiTietCCDC", DBNull.Value);
            cm.Parameters.AddWithValue("@NewID", _id);
            cm.Parameters["@NewID"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateKiemKeCCDC";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_maPhongBan != 0)
                cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
            else
                cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
            if (_maQuanLyCCDC.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLyCCDC", _maQuanLyCCDC);
            else
                cm.Parameters.AddWithValue("@MaQuanLyCCDC", DBNull.Value);
            if (_maPhongBanQL.Length > 0)
                cm.Parameters.AddWithValue("@MaPhongBanQL", _maPhongBanQL);
            else
                cm.Parameters.AddWithValue("@MaPhongBanQL", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKiemKe", _ngayKiemKe.DBValue);
            if (_filePath.Length > 0)
                cm.Parameters.AddWithValue("@FilePath", _filePath);
            else
                cm.Parameters.AddWithValue("@FilePath", DBNull.Value);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", DBNull.Value);
            if (_maCCDC != 0)
                cm.Parameters.AddWithValue("@MaCCDC", _maCCDC);
            else
                cm.Parameters.AddWithValue("@MaCCDC", DBNull.Value);
            if (_maChiTietCCDC != 0)
                cm.Parameters.AddWithValue("@MaChiTietCCDC", _maChiTietCCDC);
            else
                cm.Parameters.AddWithValue("@MaChiTietCCDC", DBNull.Value);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
