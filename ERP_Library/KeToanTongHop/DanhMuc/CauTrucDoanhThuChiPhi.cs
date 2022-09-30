using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CauTrucDoanhThuChiPhi : Csla.BusinessBase<CauTrucDoanhThuChiPhi>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private string _ten = string.Empty;
        private string _maQL = string.Empty;
        private string _englishName = string.Empty;
        private int _maCongTy = 0;
        private int _parentID = 0;
        private int _maHoatDong = 0;
        private byte _tinhChat = 0;
        private bool _ngungSuDung = false;
        //,"ParentIDString","HoatDongString","TinhChatSring"
        private string _ParentIDString = string.Empty;
        private string _HoatDongString = string.Empty;
        private string _TinhChatSring = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string Ten
        {
            get
            {
                CanReadProperty("Ten", true);
                return _ten;
            }
            set
            {
                CanWriteProperty("Ten", true);
                if (value == null) value = string.Empty;
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    PropertyHasChanged("Ten");
                }
            }
        }

        public string MaQL
        {
            get
            {
                CanReadProperty("MaQL", true);
                return _maQL;
            }
            set
            {
                CanWriteProperty("MaQL", true);
                if (value == null) value = string.Empty;
                if (!_maQL.Equals(value))
                {
                    _maQL = value;
                    PropertyHasChanged("MaQL");
                }
            }
        }

        public string EnglishName
        {
            get
            {
                CanReadProperty("EnglishName", true);
                return _englishName;
            }
            set
            {
                CanWriteProperty("EnglishName", true);
                if (value == null) value = string.Empty;
                if (!_englishName.Equals(value))
                {
                    _englishName = value;
                    PropertyHasChanged("EnglishName");
                }
            }
        }

        public int MaCongTy
        {
            get
            {
                CanReadProperty("MaCongTy", true);
                return _maCongTy;
            }
            set
            {
                CanWriteProperty("MaCongTy", true);
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }

        public int ParentID
        {
            get
            {
                CanReadProperty("ParentID", true);
                return _parentID;
            }
            set
            {
                CanWriteProperty("ParentID", true);
                if (!_parentID.Equals(value))
                {
                    _parentID = value;
                    PropertyHasChanged("ParentID");
                }
            }
        }

        public int MaHoatDong
        {
            get
            {
                CanReadProperty("MaHoatDong", true);
                return _maHoatDong;
            }
            set
            {
                CanWriteProperty("MaHoatDong", true);
                if (!_maHoatDong.Equals(value))
                {
                    _maHoatDong = value;
                    PropertyHasChanged("MaHoatDong");
                }
            }
        }

        public byte TinhChat
        {
            get
            {
                CanReadProperty("TinhChat", true);
                return _tinhChat;
            }
            set
            {
                CanWriteProperty("TinhChat", true);
                if (!_tinhChat.Equals(value))
                {
                    _tinhChat = value;
                    PropertyHasChanged("TinhChat");
                }
            }
        }

        public bool NgungSuDung
        {
            get
            {
                CanReadProperty("NgungSuDung", true);
                return _ngungSuDung;
            }
            set
            {
                CanWriteProperty("NgungSuDung", true);
                if (!_ngungSuDung.Equals(value))
                {
                    _ngungSuDung = value;
                    PropertyHasChanged("NgungSuDung");
                }
            }
        }

        public string ParentIDString
        {
            get
            {
                CanReadProperty("ParentIDString", true);
                return _ParentIDString;
            }
        }
        public string HoatDongString
        {
            get
            {
                CanReadProperty("HoatDongString", true);
                return _HoatDongString;
            }
        }

        public string TinhChatSring
        {
            get
            {
                CanReadProperty("TinhChatSring", true);
                return _TinhChatSring;
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
            // Ten
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten", 2000));
            //
            // MaQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQL", 500));
            //
            // EnglishName
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("EnglishName", 2000));
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
            //TODO: Define authorization rules in CauTrucDoanhThuChiPhi
            //AuthorizationRules.AllowRead("Id", "CauTrucDoanhThuChiPhiReadGroup");
            //AuthorizationRules.AllowRead("Ten", "CauTrucDoanhThuChiPhiReadGroup");
            //AuthorizationRules.AllowRead("MaQL", "CauTrucDoanhThuChiPhiReadGroup");
            //AuthorizationRules.AllowRead("EnglishName", "CauTrucDoanhThuChiPhiReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "CauTrucDoanhThuChiPhiReadGroup");
            //AuthorizationRules.AllowRead("ParentID", "CauTrucDoanhThuChiPhiReadGroup");
            //AuthorizationRules.AllowRead("MaHoatDong", "CauTrucDoanhThuChiPhiReadGroup");
            //AuthorizationRules.AllowRead("TinhChat", "CauTrucDoanhThuChiPhiReadGroup");
            //AuthorizationRules.AllowRead("NgungSuDung", "CauTrucDoanhThuChiPhiReadGroup");

            //AuthorizationRules.AllowWrite("Ten", "CauTrucDoanhThuChiPhiWriteGroup");
            //AuthorizationRules.AllowWrite("MaQL", "CauTrucDoanhThuChiPhiWriteGroup");
            //AuthorizationRules.AllowWrite("EnglishName", "CauTrucDoanhThuChiPhiWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "CauTrucDoanhThuChiPhiWriteGroup");
            //AuthorizationRules.AllowWrite("ParentID", "CauTrucDoanhThuChiPhiWriteGroup");
            //AuthorizationRules.AllowWrite("MaHoatDong", "CauTrucDoanhThuChiPhiWriteGroup");
            //AuthorizationRules.AllowWrite("TinhChat", "CauTrucDoanhThuChiPhiWriteGroup");
            //AuthorizationRules.AllowWrite("NgungSuDung", "CauTrucDoanhThuChiPhiWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CauTrucDoanhThuChiPhi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CauTrucDoanhThuChiPhiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CauTrucDoanhThuChiPhi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CauTrucDoanhThuChiPhiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CauTrucDoanhThuChiPhi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CauTrucDoanhThuChiPhiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CauTrucDoanhThuChiPhi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CauTrucDoanhThuChiPhiDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CauTrucDoanhThuChiPhi()
        { /* require use of factory method */ }

        public static CauTrucDoanhThuChiPhi NewCauTrucDoanhThuChiPhi()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CauTrucDoanhThuChiPhi");
            return DataPortal.Create<CauTrucDoanhThuChiPhi>();
        }

        public static CauTrucDoanhThuChiPhi GetCauTrucDoanhThuChiPhi(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CauTrucDoanhThuChiPhi");
            return DataPortal.Fetch<CauTrucDoanhThuChiPhi>(new Criteria(id));
        }

        public static void DeleteCauTrucDoanhThuChiPhi(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CauTrucDoanhThuChiPhi");
            DataPortal.Delete(new Criteria(id));
        }

        public override CauTrucDoanhThuChiPhi Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CauTrucDoanhThuChiPhi");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CauTrucDoanhThuChiPhi");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a CauTrucDoanhThuChiPhi");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static CauTrucDoanhThuChiPhi NewCauTrucDoanhThuChiPhiChild()
        {
            CauTrucDoanhThuChiPhi child = new CauTrucDoanhThuChiPhi();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static CauTrucDoanhThuChiPhi GetCauTrucDoanhThuChiPhi(SafeDataReader dr)
        {
            CauTrucDoanhThuChiPhi child = new CauTrucDoanhThuChiPhi();
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
                cm.CommandText = "spd_SelecttblCauTrucDoanhThuChiPhi";

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
                cm.CommandText = "spd_DeletetblCauTrucDoanhThuChiPhi";

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
            _ten = dr.GetString("Ten");
            _maQL = dr.GetString("MaQL");
            _englishName = dr.GetString("EnglishName");
            _maCongTy = dr.GetInt32("MaCongTy");
            _parentID = dr.GetInt32("ParentID");
            _maHoatDong = dr.GetInt32("MaHoatDong");
            _tinhChat = dr.GetByte("TinhChat");
            _ngungSuDung = dr.GetBoolean("NgungSuDung");

            _ParentIDString = dr.GetString("ParentIDString");
            _HoatDongString = dr.GetString("HoatDongString");
            _TinhChatSring = dr.GetString("TinhChatSring");
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
                cm.CommandText = "spd_InserttblCauTrucDoanhThuChiPhi";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_ten.Length > 0)
                cm.Parameters.AddWithValue("@Ten", _ten);
            else
                cm.Parameters.AddWithValue("@Ten", DBNull.Value);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_englishName.Length > 0)
                cm.Parameters.AddWithValue("@EnglishName", _englishName);
            else
                cm.Parameters.AddWithValue("@EnglishName", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_parentID != 0)
                cm.Parameters.AddWithValue("@ParentID", _parentID);
            else
                cm.Parameters.AddWithValue("@ParentID", DBNull.Value);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            if (_tinhChat != 0)
                cm.Parameters.AddWithValue("@TinhChat", _tinhChat);
            else
                cm.Parameters.AddWithValue("@TinhChat", DBNull.Value);
            if (_ngungSuDung != false)
                cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            else
                cm.Parameters.AddWithValue("@NgungSuDung", DBNull.Value);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblCauTrucDoanhThuChiPhi";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_ten.Length > 0)
                cm.Parameters.AddWithValue("@Ten", _ten);
            else
                cm.Parameters.AddWithValue("@Ten", DBNull.Value);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_englishName.Length > 0)
                cm.Parameters.AddWithValue("@EnglishName", _englishName);
            else
                cm.Parameters.AddWithValue("@EnglishName", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_parentID != 0)
                cm.Parameters.AddWithValue("@ParentID", _parentID);
            else
                cm.Parameters.AddWithValue("@ParentID", DBNull.Value);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            if (_tinhChat != 0)
                cm.Parameters.AddWithValue("@TinhChat", _tinhChat);
            else
                cm.Parameters.AddWithValue("@TinhChat", DBNull.Value);
            if (_ngungSuDung != false)
                cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            else
                cm.Parameters.AddWithValue("@NgungSuDung", DBNull.Value);
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
