using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DinhKhoanTuDong : Csla.BusinessBase<DinhKhoanTuDong>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private string _tenDinhKhoan = string.Empty;
        private int _loaiChungTu = 0;
        private int _tKNo = 0;
        private int _tKCo = 0;
        private int _IDHoatDong = 0;
        private int _IDKhoanMuc = 0;
        //--
        private string _MaDonViTruong = string.Empty;
        private int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        private string _loaiChungTustring =string.Empty;
        private string _tKNostring = string.Empty;
        private string _tKCostring = string.Empty;
        //KhoanMucString,HoatDongString
        private string _KhoanMucString = string.Empty;
        private string _HoatDongString = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string TenDinhKhoan
        {
            get
            {
                CanReadProperty("TenDinhKhoan", true);
                return _tenDinhKhoan;
            }
            set
            {
                CanWriteProperty("TenDinhKhoan", true);
                if (value == null) value = string.Empty;
                if (!_tenDinhKhoan.Equals(value))
                {
                    _tenDinhKhoan = value;
                    PropertyHasChanged("TenDinhKhoan");
                }
            }
        }

        public int LoaiChungTu
        {
            get
            {
                CanReadProperty("LoaiChungTu", true);
                return _loaiChungTu;
            }
            set
            {
                CanWriteProperty("LoaiChungTu", true);
                if (!_loaiChungTu.Equals(value))
                {
                    _loaiChungTu = value;
                    PropertyHasChanged("LoaiChungTu");
                }
            }
        }

        public string LoaiChungTuString
        {
            get
            {
                CanReadProperty("LoaiChungTuString", true);
                return _loaiChungTustring;
            }
        }
        public string TKNoString
        {
            get
            {
                CanReadProperty("TKNoString", true);
                return _tKNostring;
            }
        }


        public string TKCoString
        {
            get
            {
                CanReadProperty("TKCoString", true);
                return _tKCostring;
            }
        }

        public int TKNo
        {
            get
            {
                CanReadProperty("TKNo", true);
                return _tKNo;
            }
            set
            {
                CanWriteProperty("TKNo", true);
                if (!_tKNo.Equals(value))
                {
                    _tKNo = value;
                    PropertyHasChanged("TKNo");
                }
            }
        }

        public int TKCo
        {
            get
            {
                CanReadProperty("TKCo", true);
                return _tKCo;
            }
            set
            {
                CanWriteProperty("TKCo", true);
                if (!_tKCo.Equals(value))
                {
                    _tKCo = value;
                    PropertyHasChanged("TKCo");
                }
            }
        }

        public int IDHoatDong
        {
            get
            {
                CanReadProperty("IDHoatDong", true);
                return _IDHoatDong;
            }
            set
            {
                CanWriteProperty("IDHoatDong", true);
                if (!_IDHoatDong.Equals(value))
                {
                    _IDHoatDong = value;
                    PropertyHasChanged("IDHoatDong");
                }
            }
        }

        public int IDKhoanMuc
        {
            get
            {
                CanReadProperty("IDKhoanMuc", true);
                return _IDKhoanMuc;
            }
            set
            {
                CanWriteProperty("IDKhoanMuc", true);
                if (!_IDKhoanMuc.Equals(value))
                {
                    _IDKhoanMuc = value;
                    PropertyHasChanged("IDKhoanMuc");
                }
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
        public string KhoanMucString
        {
            get
            {
                CanReadProperty("KhoanMucString", true);
                return _KhoanMucString;
            }
        }

        public string MaDonViTruong
        {
            get
            {
                CanReadProperty("MaDonViTruong", true);
                return _MaDonViTruong;
            }
            set
            {
                CanWriteProperty("MaDonViTruong", true);
                if (value == null) value = string.Empty;
                if (!_MaDonViTruong.Equals(value))
                {
                    _MaDonViTruong = value;
                    PropertyHasChanged("MaDonViTruong");
                }
            }
        }

        public int MaCongTy
        {
            get
            {
                CanReadProperty("MaCongTy", true);
                return _MaCongTy;
            }
            set
            {
                CanWriteProperty("MaCongTy", true);
                if (!_MaCongTy.Equals(value))
                {
                    _MaCongTy = value;
                    PropertyHasChanged("MaCongTy");
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
            //TODO: Define authorization rules in DinhKhoanTuDong
            //AuthorizationRules.AllowRead("Id", "DinhKhoanTuDongReadGroup");
            //AuthorizationRules.AllowRead("TenDinhKhoan", "DinhKhoanTuDongReadGroup");
            //AuthorizationRules.AllowRead("LoaiChungTu", "DinhKhoanTuDongReadGroup");
            //AuthorizationRules.AllowRead("TKNo", "DinhKhoanTuDongReadGroup");
            //AuthorizationRules.AllowRead("TKCo", "DinhKhoanTuDongReadGroup");

            //AuthorizationRules.AllowWrite("TenDinhKhoan", "DinhKhoanTuDongWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiChungTu", "DinhKhoanTuDongWriteGroup");
            //AuthorizationRules.AllowWrite("TKNo", "DinhKhoanTuDongWriteGroup");
            //AuthorizationRules.AllowWrite("TKCo", "DinhKhoanTuDongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DinhKhoanTuDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DinhKhoanTuDongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DinhKhoanTuDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DinhKhoanTuDongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DinhKhoanTuDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DinhKhoanTuDongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DinhKhoanTuDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DinhKhoanTuDongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DinhKhoanTuDong()
        { /* require use of factory method */ }

        public static DinhKhoanTuDong NewDinhKhoanTuDong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DinhKhoanTuDong");
            return DataPortal.Create<DinhKhoanTuDong>();
        }

        public static DinhKhoanTuDong GetDinhKhoanTuDong(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DinhKhoanTuDong");
            return DataPortal.Fetch<DinhKhoanTuDong>(new Criteria(id));
        }

        public static DinhKhoanTuDong GetDinhKhoanTuDong(string tendinhKhoan,int loaichungtu, string madonvitruong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DinhKhoanTuDong");
            return DataPortal.Fetch<DinhKhoanTuDong>(new CriteriaCustomize(tendinhKhoan,loaichungtu,madonvitruong));
        }

        public static void DeleteDinhKhoanTuDong(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DinhKhoanTuDong");
            DataPortal.Delete(new Criteria(id));
        }

        public override DinhKhoanTuDong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DinhKhoanTuDong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DinhKhoanTuDong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DinhKhoanTuDong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DinhKhoanTuDong NewDinhKhoanTuDongChild()
        {
            DinhKhoanTuDong child = new DinhKhoanTuDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DinhKhoanTuDong GetDinhKhoanTuDong(SafeDataReader dr)
        {
            DinhKhoanTuDong child = new DinhKhoanTuDong();
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

        [Serializable()]
        private class CriteriaCustomize
        {
            public string TenDinhKhoan;
            public int LoaiChungTu;
            public string MaDonViTruong;

            public CriteriaCustomize(string tendinhKhoan, int loaichungTu, string maDonViTruong)
            {
                this.TenDinhKhoan = tendinhKhoan;
                this.LoaiChungTu = loaichungTu;
                this.MaDonViTruong = maDonViTruong;
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblDinhKhoanTuDong";

                    cm.Parameters.AddWithValue("@Id", ((Criteria)criteria).Id);
                }
                else if (criteria is CriteriaCustomize)
                {
                    cm.CommandText = "spd_SelecttblDinhKhoanTuDongByModify";
                    //@TenDinhKhoan NVARCHAR(max),@LoaiChungTu INT,@MaDonViTruong NVARCHAR(max)
                    cm.Parameters.AddWithValue("@TenDinhKhoan", ((CriteriaCustomize)criteria).TenDinhKhoan);
                    cm.Parameters.AddWithValue("@LoaiChungTu", ((CriteriaCustomize)criteria).LoaiChungTu);
                    cm.Parameters.AddWithValue("@MaDonViTruong", ((CriteriaCustomize)criteria).MaDonViTruong);
                    cm.Parameters.AddWithValue("@MaCongTy",ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }

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
                cm.CommandText = "spd_DeletetblDinhKhoanTuDong";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

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
            _id = dr.GetInt32("Id");
            _tenDinhKhoan = dr.GetString("TenDinhKhoan");
            _loaiChungTu = dr.GetInt32("LoaiChungTu");
            _tKNo = dr.GetInt32("TKNo");
            _tKCo = dr.GetInt32("TKCo");
            _IDHoatDong = dr.GetInt32("IDHoatDong");
            _IDKhoanMuc = dr.GetInt32("IDKhoanMuc");
            //--
            _MaDonViTruong = dr.GetString("MaDonViTruong");
            _MaCongTy = dr.GetInt32("MaCongTy");

            _loaiChungTustring = dr.GetString("LoaiChungTuString");
            _tKNostring = dr.GetString("TKNoString");
            _tKCostring = dr.GetString("TKCoString");
            _HoatDongString = dr.GetString("HoatDongString");
            _KhoanMucString = dr.GetString("KhoanMucString");
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
                cm.CommandText = "spd_InserttblDinhKhoanTuDong";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@Id"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenDinhKhoan.Length > 0)
                cm.Parameters.AddWithValue("@TenDinhKhoan", _tenDinhKhoan);
            else
                cm.Parameters.AddWithValue("@TenDinhKhoan", DBNull.Value);
            if (_loaiChungTu != 0)
                cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
            else
                cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
            if (_tKNo != 0)
                cm.Parameters.AddWithValue("@TKNo", _tKNo);
            else
                cm.Parameters.AddWithValue("@TKNo", DBNull.Value);
            if (_tKCo != 0)
                cm.Parameters.AddWithValue("@TKCo", _tKCo);
            else
                cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
            if (_IDHoatDong != 0)
                cm.Parameters.AddWithValue("@IDHoatDong", _IDHoatDong);
            else
                cm.Parameters.AddWithValue("@IDHoatDong", DBNull.Value);
            if (_IDKhoanMuc != 0)
                cm.Parameters.AddWithValue("@IDKhoanMuc", _IDKhoanMuc);
            else
                cm.Parameters.AddWithValue("@IDKhoanMuc", DBNull.Value);
            //--
            if (_MaDonViTruong.Length > 0)
                cm.Parameters.AddWithValue("@MaDonViTruong", _MaDonViTruong);
            else
                cm.Parameters.AddWithValue("@MaDonViTruong", DBNull.Value);
            if (_MaCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);

            cm.Parameters.AddWithValue("@Id", _id);
            cm.Parameters["@Id"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblDinhKhoanTuDong";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Id", _id);
            if (_tenDinhKhoan.Length > 0)
                cm.Parameters.AddWithValue("@TenDinhKhoan", _tenDinhKhoan);
            else
                cm.Parameters.AddWithValue("@TenDinhKhoan", DBNull.Value);
            if (_loaiChungTu != 0)
                cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
            else
                cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
            if (_tKNo != 0)
                cm.Parameters.AddWithValue("@TKNo", _tKNo);
            else
                cm.Parameters.AddWithValue("@TKNo", DBNull.Value);
            if (_tKCo != 0)
                cm.Parameters.AddWithValue("@TKCo", _tKCo);
            else
                cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
            if (_IDHoatDong != 0)
                cm.Parameters.AddWithValue("@IDHoatDong", _IDHoatDong);
            else
                cm.Parameters.AddWithValue("@IDHoatDong", DBNull.Value);
            if (_IDKhoanMuc != 0)
                cm.Parameters.AddWithValue("@IDKhoanMuc", _IDKhoanMuc);
            else
                cm.Parameters.AddWithValue("@IDKhoanMuc", DBNull.Value);
            //--
            if (_MaDonViTruong.Length > 0)
                cm.Parameters.AddWithValue("@MaDonViTruong", _MaDonViTruong);
            else
                cm.Parameters.AddWithValue("@MaDonViTruong", DBNull.Value);
            if (_MaCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
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
