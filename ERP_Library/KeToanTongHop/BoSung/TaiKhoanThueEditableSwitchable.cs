using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class TaiKhoanThueH : Csla.BusinessBase<TaiKhoanThueH>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private int _maTaiKhoanThue = 0;
        private string _soHieuTKThue = string.Empty;
        private int _maTKTamUng = 0;
        private string _soHieuTKTamUng = string.Empty;
        private int _maCongTy = 1;
        private string _tenCongTy = string.Empty;
        private string _mauHoaDon = string.Empty;
        private string _kyHieuHoaDon = string.Empty;
        private int _maTaiKhoanThuePhaiNop = 0;
        private string _soHieuTKThuePhaiNop = string.Empty;
        private bool _dungChung = false;
        private int _tuNgayNamTC = 0;
        private int _denNgayNamTC = 0;
        private int _tuThangNamTC = 0;
        private int _denThangNamTC = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public int MaTaiKhoanThue
        {
            get
            {
                CanReadProperty("MaTaiKhoanThue", true);
                return _maTaiKhoanThue;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanThue", true);
                if (!_maTaiKhoanThue.Equals(value))
                {
                    _maTaiKhoanThue = value;
                    _soHieuTKThue = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKhoanThue).SoHieuTK;
                    PropertyHasChanged("MaTaiKhoanThue");
                }
            }
        }

        public string SoHieuTKThue
        {
            get
            {
                CanReadProperty("SoHieuTKThue", true);
                return _soHieuTKThue;
            }
            set
            {
                CanWriteProperty("SoHieuTKThue", true);
                if (value == null) value = string.Empty;
                if (!_soHieuTKThue.Equals(value))
                {
                    _soHieuTKThue = value;
                    //_maTaiKhoanThue = HeThongTaiKhoan1.GetHeThongTaiKhoan1(Convert.ToInt32(_soHieuTKThue)).MaTaiKhoan;
                    PropertyHasChanged("SoHieuTKThue");
                }
            }
        }

        public string TenCongTy
        {
            get
            {
                CanReadProperty("TenCongTy", true);
                return _tenCongTy;
            }
            set
            {
                CanWriteProperty("TenCongTy", true);
                if (value == null) value = string.Empty;
                if (!_tenCongTy.Equals(value))
                {
                    _tenCongTy = value;
                    PropertyHasChanged("TenCongTy");
                }
            }
        }

        public int MaTKTamUng
        {
            get
            {
                CanReadProperty("MaTKTamUng", true);
                return _maTKTamUng;
            }
            set
            {
                CanWriteProperty("MaTKTamUng", true);
                if (!_maTKTamUng.Equals(value))
                {
                    _maTKTamUng = value;
                    _soHieuTKTamUng = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTKTamUng).SoHieuTK;
                    PropertyHasChanged("MaTKTamUng");
                }
            }
        }

        public string SoHieuTKTamUng
        {
            get
            {
                CanReadProperty("SoHieuTKTamUng", true);
                return _soHieuTKTamUng;
            }
            set
            {
                CanWriteProperty("SoHieuTKTamUng", true);
                if (value == null) value = string.Empty;
                if (!_soHieuTKTamUng.Equals(value))
                {
                    _soHieuTKTamUng = value;
                    PropertyHasChanged("SoHieuTKTamUng");
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
                    _tenCongTy = CongTy.GetCongTy(_maCongTy).TenCongTy;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }

        public string MauHoaDon
        {
            get
            {
                CanReadProperty("MauHoaDon", true);
                return _mauHoaDon;
            }
            set
            {
                CanWriteProperty("MauHoaDon", true);
                if (value == null) value = string.Empty;
                if (!_mauHoaDon.Equals(value))
                {
                    _mauHoaDon = value;
                    PropertyHasChanged("MauHoaDon");
                }
            }
        }

        public string KyHieuHoaDon
        {
            get
            {
                CanReadProperty("KyHieuHoaDon", true);
                return _kyHieuHoaDon;
            }
            set
            {
                CanWriteProperty("KyHieuHoaDon", true);
                if (value == null) value = string.Empty;
                if (!_kyHieuHoaDon.Equals(value))
                {
                    _kyHieuHoaDon = value;
                    PropertyHasChanged("KyHieuHoaDon");
                }
            }
        }

        public int MaTaiKhoanThuePhaiNop
        {
            get
            {
                CanReadProperty("MaTaiKhoanThuePhaiNop", true);
                return _maTaiKhoanThuePhaiNop;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanThuePhaiNop", true);
                if (!_maTaiKhoanThuePhaiNop.Equals(value))
                {
                    _maTaiKhoanThuePhaiNop = value;
                    _soHieuTKThuePhaiNop = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKhoanThuePhaiNop).SoHieuTK;
                    PropertyHasChanged("MaTaiKhoanThuePhaiNop");
                }
            }
        }

        public string SoHieuTKThuePhaiNop
        {
            get
            {
                CanReadProperty("SoHieuTKThuePhaiNop", true);
                return _soHieuTKThuePhaiNop;
            }
            set
            {
                CanWriteProperty("SoHieuTKThuePhaiNop", true);
                if (value == null) value = string.Empty;
                if (!_soHieuTKThuePhaiNop.Equals(value))
                {
                    _soHieuTKThuePhaiNop = value;
                    PropertyHasChanged("SoHieuTKThuePhaiNop");
                }
            }
        }

        public bool DungChung
        {
            get
            {
                CanReadProperty("DungChung", true);
                return _dungChung;
            }
            set
            {
                CanWriteProperty("DungChung", true);
                if (!_dungChung.Equals(value))
                {
                    _dungChung = value;
                    PropertyHasChanged("DungChung");
                }
            }
        }

        public int TuNgayNamTC
        {
            get
            {
                CanReadProperty("TuNgayNamTC", true);
                return _tuNgayNamTC;
            }
            set
            {
                CanWriteProperty("TuNgayNamTC", true);
                if (!_tuNgayNamTC.Equals(value))
                {
                    _tuNgayNamTC = value;
                    PropertyHasChanged("TuNgayNamTC");
                }
            }
        }

        public int DenNgayNamTC
        {
            get
            {
                CanReadProperty("DenNgayNamTC", true);
                return _denNgayNamTC;
            }
            set
            {
                CanWriteProperty("DenNgayNamTC", true);
                if (!_denNgayNamTC.Equals(value))
                {
                    _denNgayNamTC = value;
                    PropertyHasChanged("DenNgayNamTC");
                }
            }
        }

        public int TuThangNamTC
        {
            get
            {
                CanReadProperty("TuThangNamTC", true);
                return _tuThangNamTC;
            }
            set
            {
                CanWriteProperty("TuThangNamTC", true);
                if (!_tuThangNamTC.Equals(value))
                {
                    _tuThangNamTC = value;
                    PropertyHasChanged("TuThangNamTC");
                }
            }
        }

        public int DenThangNamTC
        {
            get
            {
                CanReadProperty("DenThangNamTC", true);
                return _denThangNamTC;
            }
            set
            {
                CanWriteProperty("DenThangNamTC", true);
                if (!_denThangNamTC.Equals(value))
                {
                    _denThangNamTC = value;
                    PropertyHasChanged("DenThangNamTC");
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
            // SoHieuTKThue
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTKThue", 50));
            //
            // SoHieuTKTamUng
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTKTamUng", 50));
            //
            // MauHoaDon
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MauHoaDon", 100));
            //
            // KyHieuHoaDon
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("KyHieuHoaDon", 100));
            //
            // SoHieuTKThuePhaiNop
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTKThuePhaiNop", 50));
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
            //TODO: Define authorization rules in TaiKhoanThueH
            //AuthorizationRules.AllowRead("Id", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoanThue", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("SoHieuTKThue", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("MaTKTamUng", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("SoHieuTKTamUng", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("MauHoaDon", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("KyHieuHoaDon", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoanThuePhaiNop", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("SoHieuTKThuePhaiNop", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("DungChung", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("TuNgayNamTC", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("DenNgayNamTC", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("TuThangNamTC", "TaiKhoanThueHReadGroup");
            //AuthorizationRules.AllowRead("DenThangNamTC", "TaiKhoanThueHReadGroup");

            //AuthorizationRules.AllowWrite("MaTaiKhoanThue", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("SoHieuTKThue", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("MaTKTamUng", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("SoHieuTKTamUng", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("MauHoaDon", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("KyHieuHoaDon", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoanThuePhaiNop", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("SoHieuTKThuePhaiNop", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("DungChung", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgayNamTC", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgayNamTC", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("TuThangNamTC", "TaiKhoanThueHWriteGroup");
            //AuthorizationRules.AllowWrite("DenThangNamTC", "TaiKhoanThueHWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TaiKhoanThueH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiKhoanThueHViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TaiKhoanThueH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiKhoanThueHAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TaiKhoanThueH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiKhoanThueHEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TaiKhoanThueH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiKhoanThueHDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TaiKhoanThueH()
        { /* require use of factory method */ }

        public static TaiKhoanThueH NewTaiKhoanThueH()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TaiKhoanThueH");
            return DataPortal.Create<TaiKhoanThueH>();
        }

        public static TaiKhoanThueH GetTaiKhoanThueH(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TaiKhoanThueH");
            return DataPortal.Fetch<TaiKhoanThueH>(new Criteria(id));
        }

        public static void DeleteTaiKhoanThueH(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TaiKhoanThueH");
            DataPortal.Delete(new Criteria(id));
        }

        public override TaiKhoanThueH Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TaiKhoanThueH");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TaiKhoanThueH");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a TaiKhoanThueH");

            return base.Save();
        }



        #endregion //Factory Methods

        #region Child Factory Methods
        internal static TaiKhoanThueH NewTaiKhoanThueHChild()
        {
            TaiKhoanThueH child = new TaiKhoanThueH();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static TaiKhoanThueH GetTaiKhoanThueH(SafeDataReader dr)
        {
            TaiKhoanThueH child = new TaiKhoanThueH();
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
                cm.CommandText = "spd_GetTaiKhoanThueHById";

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
                cm.CommandText = "DeleteTaiKhoanThueH";

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
            _maTaiKhoanThue = dr.GetInt32("MaTaiKhoanThue");
            _soHieuTKThue = dr.GetString("SoHieuTKThue");
            _maTKTamUng = dr.GetInt32("MaTKTamUng");
            _tenCongTy = dr.GetString("TenCongTy");
            _soHieuTKTamUng = dr.GetString("SoHieuTKTamUng");
            _maCongTy = dr.GetInt32("MaCongTy");
            _mauHoaDon = dr.GetString("MauHoaDon");
            _kyHieuHoaDon = dr.GetString("KyHieuHoaDon");
            _maTaiKhoanThuePhaiNop = dr.GetInt32("MaTaiKhoanThuePhaiNop");
            _soHieuTKThuePhaiNop = dr.GetString("SoHieuTKThuePhaiNop");
            _dungChung = dr.GetBoolean("DungChung");
            _tuNgayNamTC = dr.GetInt32("TuNgayNamTC");
            _denNgayNamTC = dr.GetInt32("DenNgayNamTC");
            _tuThangNamTC = dr.GetInt32("TuThangNamTC");
            _denThangNamTC = dr.GetInt32("DenThangNamTC");
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
                cm.CommandText = "spd_AddTaiKhoanThueH";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                //_id = (int)cm.Parameters["@NewID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maTaiKhoanThue != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanThue", _maTaiKhoanThue);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanThue", DBNull.Value);

            if (_maTKTamUng != 0)
                cm.Parameters.AddWithValue("@MaTKTamUng", _maTKTamUng);
            else
                cm.Parameters.AddWithValue("@MaTKTamUng", DBNull.Value);

            if (_maTaiKhoanThuePhaiNop != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanThuePhaiNop", _maTaiKhoanThuePhaiNop);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanThuePhaiNop", DBNull.Value);

            if (_soHieuTKThue.Length > 0)
                cm.Parameters.AddWithValue("@SoHieuTKThue", _soHieuTKThue);
            else
                cm.Parameters.AddWithValue("@SoHieuTKThue", DBNull.Value);
            if (_soHieuTKTamUng.Length > 0)
                cm.Parameters.AddWithValue("@SoHieuTKTamUng", _soHieuTKTamUng);
            else
                cm.Parameters.AddWithValue("@SoHieuTKTamUng", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_mauHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@MauHoaDon", _mauHoaDon);
            else
                cm.Parameters.AddWithValue("@MauHoaDon", DBNull.Value);
            if (_kyHieuHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@KyHieuHoaDon", _kyHieuHoaDon);
            else
                cm.Parameters.AddWithValue("@KyHieuHoaDon", DBNull.Value);
            if (_soHieuTKThuePhaiNop.Length > 0)
                cm.Parameters.AddWithValue("@SoHieuTKThuePhaiNop", _soHieuTKThuePhaiNop);
            else
                cm.Parameters.AddWithValue("@SoHieuTKThuePhaiNop", DBNull.Value);
            if (_dungChung != false)
                cm.Parameters.AddWithValue("@DungChung", _dungChung);
            else
                cm.Parameters.AddWithValue("@DungChung", DBNull.Value);
            if (_tuNgayNamTC != 0)
                cm.Parameters.AddWithValue("@TuNgayNamTC", _tuNgayNamTC);
            else
                cm.Parameters.AddWithValue("@TuNgayNamTC", DBNull.Value);
            if (_denNgayNamTC != 0)
                cm.Parameters.AddWithValue("@DenNgayNamTC", _denNgayNamTC);
            else
                cm.Parameters.AddWithValue("@DenNgayNamTC", DBNull.Value);
            if (_tuThangNamTC != 0)
                cm.Parameters.AddWithValue("@TuThangNamTC", _tuThangNamTC);
            else
                cm.Parameters.AddWithValue("@TuThangNamTC", DBNull.Value);
            if (_denThangNamTC != 0)
                cm.Parameters.AddWithValue("@DenThangNamTC", _denThangNamTC);
            else
                cm.Parameters.AddWithValue("@DenThangNamTC", DBNull.Value);
            //cm.Parameters.AddWithValue("@NewID", _id);
            //cm.Parameters["@NewID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdateTaiKhoanThueH";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);

            if (_maTaiKhoanThue != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanThue", _maTaiKhoanThue);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanThue", DBNull.Value);

            if (_maTKTamUng != 0)
                cm.Parameters.AddWithValue("@MaTKTamUng", _maTKTamUng);
            else
                cm.Parameters.AddWithValue("@MaTKTamUng", DBNull.Value);

            if (_maTaiKhoanThuePhaiNop != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanThuePhaiNop", _maTaiKhoanThuePhaiNop);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanThuePhaiNop", DBNull.Value);

            if (_soHieuTKThue.Length > 0)
                cm.Parameters.AddWithValue("@SoHieuTKThue", _soHieuTKThue);
            else
                cm.Parameters.AddWithValue("@SoHieuTKThue", DBNull.Value);
            
            if (_soHieuTKTamUng.Length > 0)
                cm.Parameters.AddWithValue("@SoHieuTKTamUng", _soHieuTKTamUng);
            else
                cm.Parameters.AddWithValue("@SoHieuTKTamUng", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_mauHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@MauHoaDon", _mauHoaDon);
            else
                cm.Parameters.AddWithValue("@MauHoaDon", DBNull.Value);
            if (_kyHieuHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@KyHieuHoaDon", _kyHieuHoaDon);
            else
                cm.Parameters.AddWithValue("@KyHieuHoaDon", DBNull.Value);
            
            if (_soHieuTKThuePhaiNop.Length > 0)
                cm.Parameters.AddWithValue("@SoHieuTKThuePhaiNop", _soHieuTKThuePhaiNop);
            else
                cm.Parameters.AddWithValue("@SoHieuTKThuePhaiNop", DBNull.Value);
            if (_dungChung != false)
                cm.Parameters.AddWithValue("@DungChung", _dungChung);
            else
                cm.Parameters.AddWithValue("@DungChung", DBNull.Value);
            if (_tuNgayNamTC != 0)
                cm.Parameters.AddWithValue("@TuNgayNamTC", _tuNgayNamTC);
            else
                cm.Parameters.AddWithValue("@TuNgayNamTC", DBNull.Value);
            if (_denNgayNamTC != 0)
                cm.Parameters.AddWithValue("@DenNgayNamTC", _denNgayNamTC);
            else
                cm.Parameters.AddWithValue("@DenNgayNamTC", DBNull.Value);
            if (_tuThangNamTC != 0)
                cm.Parameters.AddWithValue("@TuThangNamTC", _tuThangNamTC);
            else
                cm.Parameters.AddWithValue("@TuThangNamTC", DBNull.Value);
            if (_denThangNamTC != 0)
                cm.Parameters.AddWithValue("@DenThangNamTC", _denThangNamTC);
            else
                cm.Parameters.AddWithValue("@DenThangNamTC", DBNull.Value);
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
