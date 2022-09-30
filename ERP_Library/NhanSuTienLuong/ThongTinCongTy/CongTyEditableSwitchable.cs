
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CongTy : Csla.BusinessBase<CongTy>
    {
        #region Business Properties and Methods

        //declare members
        private int _maCongTy = 0;
        private string _maCongTyQuanLy = string.Empty;
        private string _tenCongTy = string.Empty;
        private string _tenVietTat = string.Empty;
        private string _tenTiengAnh = string.Empty;
        private string _maSoThue = string.Empty;
        private string _dienThoai = string.Empty;
        private string _dienThoai1 = string.Empty;
        private int _maNganHang = 0;
        private string _soTaiKhoan = string.Empty;
        private string _fax = string.Empty;
        private string _website = string.Empty;
        private string _email = string.Empty;
        private string _diaChi = string.Empty;
        private string _diaChi1 = string.Empty;
        private byte[] _logo = new byte[0];
        private string _ghiChu = string.Empty;
        private string _tenNganHang = string.Empty;
        private string _SoDVSDNS = string.Empty;
        private bool? _congThue = false;
        private DateTime _ngayChanSo = DateTime.Today.Date;

        //declare child member(s)
        //private DiaChi_CongTyList _diaChi_CongTyList = DiaChi_CongTyList.NewDiaChi_CongTyList();
        //private CongTy_DienThoai_FaxList _congTy_DienThoai_FaxList = CongTy_DienThoai_FaxList.NewCongTy_DienThoai_FaxList();
        //private CongTy_Website_EmailList _congTy_Website_EmailList = CongTy_Website_EmailList.NewCongTy_Website_EmailList();
        //private CongTy_NganHangList _congTy_NganHangList = CongTy_NganHangList.NewCongTy_NganHangList();
        private DiaChi_CongTyList _diaChi_CongTyList = null;
        private CongTy_DienThoai_FaxList _congTy_DienThoai_FaxList = null;
        private CongTy_Website_EmailList _congTy_Website_EmailList = null;
        private CongTy_NganHangList _congTy_NganHangList = null;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaCongTy
        {
            get
            {
                return _maCongTy;
            }
        }

        public string MaCongTyQuanLy
        {
            get
            {
                return _maCongTyQuanLy;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maCongTyQuanLy.Equals(value))
                {
                    _maCongTyQuanLy = value;
                    PropertyHasChanged("MaCongTyQuanLy");
                }
            }
        }
        public string TenNganHang
        {
            get
            {
                _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
                return _tenNganHang;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenNganHang.Equals(value))
                {
                    _tenNganHang = value;
                    PropertyHasChanged("TenNganHang");
                }
            }
        }

        public string TenCongTy
        {
            get
            {
                return _tenCongTy;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenCongTy.Equals(value))
                {
                    _tenCongTy = value;
                    PropertyHasChanged("TenCongTy");
                }
            }
        }

        public string TenVietTat
        {
            get
            {
                return _tenVietTat;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenVietTat.Equals(value))
                {
                    _tenVietTat = value;
                    PropertyHasChanged("TenVietTat");
                }
            }
        }

        public string TenTiengAnh
        {
            get
            {
                return _tenTiengAnh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenTiengAnh.Equals(value))
                {
                    _tenTiengAnh = value;
                    PropertyHasChanged("TenTiengAnh");
                }
            }
        }

        public string MaSoThue
        {
            get
            {
                return _maSoThue;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maSoThue.Equals(value))
                {
                    _maSoThue = value;
                    PropertyHasChanged("MaSoThue");
                }
            }
        }

        public string DienThoai
        {
            get
            {
                return _dienThoai;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_dienThoai.Equals(value))
                {
                    _dienThoai = value;
                    PropertyHasChanged("DienThoai");
                }
            }
        }

        public string DienThoai1
        {
            get
            {
                return _dienThoai1;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_dienThoai1.Equals(value))
                {
                    _dienThoai1 = value;
                    PropertyHasChanged("DienThoai1");
                }
            }
        }

        public int MaNganHang
        {
            get
            {
                return _maNganHang;
            }
            set
            {
                if (!_maNganHang.Equals(value))
                {
                    _maNganHang = value;
                    _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
                    PropertyHasChanged("MaNganHang");
                }
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
                }
            }
        }

        public string Fax
        {
            get
            {
                return _fax;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_fax.Equals(value))
                {
                    _fax = value;
                    PropertyHasChanged("Fax");
                }
            }
        }

        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_website.Equals(value))
                {
                    _website = value;
                    PropertyHasChanged("Website");
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_email.Equals(value))
                {
                    _email = value;
                    PropertyHasChanged("Email");
                }
            }
        }

        public string DiaChi
        {
            get
            {
                return _diaChi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_diaChi.Equals(value))
                {
                    _diaChi = value;
                    PropertyHasChanged("DiaChi");
                }
            }
        }

        public string DiaChi1
        {
            get
            {
                return _diaChi1;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_diaChi1.Equals(value))
                {
                    _diaChi1 = value;
                    PropertyHasChanged("DiaChi1");
                }
            }
        }

        public byte[] Logo
        {
            get
            {
                return _logo;
            }
            set
            {
                //if (!_logo.Equals(value))
                //{
                _logo = value;
                PropertyHasChanged("Logo");
                //}
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

        public string SoDVSDNS
        {
            get
            {
                return _SoDVSDNS;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_SoDVSDNS.Equals(value))
                {
                    _SoDVSDNS = value;
                    PropertyHasChanged("SoDVSDNS");
                }
            }
        }


        public DiaChi_CongTyList DiaChi_CongTyList
        {
            get
            {
                CanReadProperty("DiaChi_CongTyList", true);
                return _diaChi_CongTyList;
            }
        }

        public CongTy_DienThoai_FaxList CongTy_DienThoai_FaxList
        {
            get
            {
                CanReadProperty("CongTy_DienThoai_FaxList", true);
                return _congTy_DienThoai_FaxList;
            }
        }

        public CongTy_Website_EmailList CongTy_Website_EmailList
        {
            get
            {
                CanReadProperty("CongTy_Website_EmailList", true);
                return _congTy_Website_EmailList;
            }
        }

        public CongTy_NganHangList CongTy_NganHangList
        {
            get
            {
                CanReadProperty("CongTy_NganHangList", true);
                return _congTy_NganHangList;
            }
        }

        public DateTime NgayChanSoLieu
        {
            get
            {
                CanReadProperty("NgayChanSoLieu", true);
                return _ngayChanSo;
            }
            set
            {
                CanWriteProperty("NgayChanSoLieu", true); ;
                if (!_ngayChanSo.Equals(value))
                {
                    _ngayChanSo = value;
                    PropertyHasChanged("NgayChanSoLieu");
                }
            }
        }
        public Boolean? CongThue
        {
            get
            {
                return _congThue;
            }
            set
            {
                if (value == null) value = false;
                if (!_congThue.Equals(value))
                {
                    _congThue = value;
                    PropertyHasChanged("CongThue");
                }
            }
        }
        public override bool IsValid
        {
            get
            {
                bool _diaChiCongTyListIsValid = true, _congTyDienThoaiFaxListIsValid = true, _congTyWebsiteEmailListIsValid = true, _congTyNganHangListIsValid = true;
                if (_diaChi_CongTyList != null)
                    _diaChiCongTyListIsValid = _diaChi_CongTyList.IsValid;
                if (_congTy_DienThoai_FaxList != null)
                    _congTyDienThoaiFaxListIsValid = _congTy_DienThoai_FaxList.IsValid;
                if (_congTy_Website_EmailList != null)
                    _congTyWebsiteEmailListIsValid = _congTy_Website_EmailList.IsValid;
                if (_congTy_NganHangList != null)
                    _congTyNganHangListIsValid = _congTy_NganHangList.IsValid;

                    return base.IsValid && _diaChiCongTyListIsValid && _congTyDienThoaiFaxListIsValid && _congTyWebsiteEmailListIsValid && _congTyNganHangListIsValid;
            }
        }

        public override bool IsDirty
        {
            get
            {
                bool _diaChiCongTyListIsDirty = true, _congTyDienThoaiFaxListIsDirty = true, _congTyWebsiteEmailListIsDirty = true, _congTyNganHangListIsDirty = true;
                if (_diaChi_CongTyList != null)
                    _diaChiCongTyListIsDirty = _diaChi_CongTyList.IsDirty;
                if (_congTy_DienThoai_FaxList != null)
                    _congTyDienThoaiFaxListIsDirty = _congTy_DienThoai_FaxList.IsDirty;
                if (_congTy_Website_EmailList != null)
                    _congTyWebsiteEmailListIsDirty = _congTy_Website_EmailList.IsDirty;
                if (_congTy_NganHangList != null)
                    _congTyNganHangListIsDirty = _congTy_NganHangList.IsDirty;

                return base.IsDirty || _diaChiCongTyListIsDirty || _congTyDienThoaiFaxListIsDirty || _congTyWebsiteEmailListIsDirty || _congTyNganHangListIsDirty;
            }
        }

        protected override object GetIdValue()
        {
            return _maCongTy;
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
            // MaCongTyQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaCongTyQuanLy", 20));
            //
            // TenCongTy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCongTy", 500));
            //
            // TenVietTat
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenVietTat", 500));
            //
            // TenTiengAnh
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTiengAnh", 500));
            //
            // MaSoThue
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaSoThue", 20));
            //
            // SoTaiKhoan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 20));
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
            //TODO: Define authorization rules in CongTy
            //AuthorizationRules.AllowRead("DiaChi_CongTyList", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("CongTy_DienThoai_FaxList", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("CongTy_Website_EmailList", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("CongTy_NganHangList", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("MaCongTyQuanLy", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("TenCongTy", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("TenVietTat", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("TenTiengAnh", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("MaSoThue", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("MaTinhThanh", "CongTyReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "CongTyReadGroup");			
            //AuthorizationRules.AllowRead("Logo", "CongTyReadGroup");

            //AuthorizationRules.AllowWrite("MaCongTyQuanLy", "CongTyWriteGroup");
            //AuthorizationRules.AllowWrite("TenCongTy", "CongTyWriteGroup");
            //AuthorizationRules.AllowWrite("TenVietTat", "CongTyWriteGroup");
            //AuthorizationRules.AllowWrite("TenTiengAnh", "CongTyWriteGroup");
            //AuthorizationRules.AllowWrite("MaSoThue", "CongTyWriteGroup");
            //AuthorizationRules.AllowWrite("MaTinhThanh", "CongTyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTaiKhoan", "CongTyWriteGroup");			
            //AuthorizationRules.AllowWrite("Logo", "CongTyWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CongTy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongTyViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CongTy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongTyAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CongTy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongTyEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CongTy
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongTyDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CongTy()
        { /* require use of factory method */
          _diaChi_CongTyList = DiaChi_CongTyList.NewDiaChi_CongTyList();
          _congTy_DienThoai_FaxList = CongTy_DienThoai_FaxList.NewCongTy_DienThoai_FaxList();
          _congTy_Website_EmailList = CongTy_Website_EmailList.NewCongTy_Website_EmailList();
         _congTy_NganHangList = CongTy_NganHangList.NewCongTy_NganHangList();
        }
        private CongTy(bool chooseChild = true)
        { /* require use of factory method */
            
        }
        private CongTy(string _maCongTyQuanLy, int MaCty)
        {
            this._maCongTy = MaCty;
            this._tenCongTy = _maCongTyQuanLy;
            MarkAsChild();
        }

        public static CongTy NewCongTy(string _maCongTyQuanLy, int MaCty)
        {
            return new CongTy(_maCongTyQuanLy, MaCty);
        }

        public static CongTy NewCongTy()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongTy");
            return DataPortal.Create<CongTy>();
        }

        public static CongTy GetCongTy(int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongTy");
            return DataPortal.Fetch<CongTy>(new Criteria(maCongTy));
        }
        public static CongTy GetCongTy_ByMaCongTyQuanLy(string maCongTyQuanLy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongTy");
            return DataPortal.Fetch<CongTy>(new CriteriaMaCongTyQuanLy(maCongTyQuanLy));
        }
        
        public static void DeleteCongTy(int maCongTy)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CongTy");
            DataPortal.Delete(new Criteria(maCongTy));
        }

        public override CongTy Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CongTy");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongTy");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a CongTy");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static CongTy NewCongTyChild()
        {
            CongTy child = new CongTy();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static CongTy GetCongTy(SafeDataReader dr)
        {
            CongTy child = new CongTy();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        internal static CongTy GetCongTyChooseChild(SafeDataReader dr, bool diaChi_CongTyListChild,
            bool congTy_DienThoai_FaxListChild, bool congTy_Website_EmailListChild, bool congTy_NganHangListChild)
        {
            CongTy child = new CongTy(chooseChild: true);
            child.MarkAsChild();
            child.FetchChooseChild(dr, diaChi_CongTyListChild,
            congTy_DienThoai_FaxListChild, congTy_Website_EmailListChild, congTy_NganHangListChild);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaCongTy;

            public Criteria(int maCongTy)
            {
                this.MaCongTy = maCongTy;
            }
        }
        [Serializable()]
        private class CriteriaMaCongTyQuanLy
        {
            public string MaCongTyQuanLy;

            public CriteriaMaCongTyQuanLy(string MaCongTyQuanLy)
            {
                this.MaCongTyQuanLy = MaCongTyQuanLy;
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
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                if (criteria is Criteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCongTy";
                    cm.Parameters.AddWithValue("@MaCongTy", ((Criteria)criteria).MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            //ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren(_maCongTy);
                        }
                    }
                }
                if (criteria is CriteriaMaCongTyQuanLy)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCongTy_ByMaCongTyQuanLy";
                    cm.Parameters.AddWithValue("@MaCongTyQuanLy", ((CriteriaMaCongTyQuanLy)criteria).MaCongTyQuanLy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                        }
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
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
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
                    throw ex;
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maCongTy));
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
                cm.CommandText = "spd_DeletetblCongTy";

                cm.Parameters.AddWithValue("@MaCongTy", criteria.MaCongTy);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(_maCongTy);
        }
        private void FetchChooseChild(SafeDataReader dr, bool diaChi_CongTyListChild,
            bool congTy_DienThoai_FaxListChild, bool congTy_Website_EmailListChild, bool congTy_NganHangListChild)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();
            FetchChildrenChooseChild(_maCongTy, diaChi_CongTyListChild,
             congTy_DienThoai_FaxListChild, congTy_Website_EmailListChild, congTy_NganHangListChild);
        }
        private void FetchObject(SafeDataReader dr)
        {
            _maCongTy = dr.GetInt32("MaCongTy");
            _maCongTyQuanLy = dr.GetString("MaCongTyQuanLy");
            _tenCongTy = dr.GetString("TenCongTy");
            _tenVietTat = dr.GetString("TenVietTat");
            _tenTiengAnh = dr.GetString("TenTiengAnh");
            _maSoThue = dr.GetString("MaSoThue");
            _dienThoai = dr.GetString("DienThoai");
            _dienThoai1 = dr.GetString("DienThoai1");
            _maNganHang = dr.GetInt32("MaNganHang");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _fax = dr.GetString("Fax");
            _website = dr.GetString("Website");
            _email = dr.GetString("Email");
            _diaChi = dr.GetString("DiaChi");
            _diaChi1 = dr.GetString("DiaChi1");
            _logo = (byte[])dr["Logo"];
            _ghiChu = dr.GetString("GhiChu");
            _SoDVSDNS = dr.GetString("SoDVSDNS");
            _ngayChanSo = dr.GetDateTime("NgayChanSo");
            _congThue = dr.GetBoolean("CongThue");
        }

        private void FetchChildren(int maCongTy)
        {
            _diaChi_CongTyList = DiaChi_CongTyList.GetDiaChi_CongTyList(maCongTy);
            _congTy_DienThoai_FaxList = CongTy_DienThoai_FaxList.GetCongTy_DienThoai_FaxList(maCongTy);
            _congTy_Website_EmailList = CongTy_Website_EmailList.GetCongTy_Website_EmailList(maCongTy);
            _congTy_NganHangList = CongTy_NganHangList.GetCongTy_NganHangList(maCongTy);

        }
        private void FetchChildrenChooseChild(int maCongTy, bool diaChi_CongTyListChild, 
            bool congTy_DienThoai_FaxListChild, bool congTy_Website_EmailListChild, bool congTy_NganHangListChild)
        {
            if (diaChi_CongTyListChild)
                _diaChi_CongTyList = DiaChi_CongTyList.GetDiaChi_CongTyList(maCongTy);
            if (congTy_DienThoai_FaxListChild)
                _congTy_DienThoai_FaxList = CongTy_DienThoai_FaxList.GetCongTy_DienThoai_FaxList(maCongTy);
            if (congTy_Website_EmailListChild)
                _congTy_Website_EmailList = CongTy_Website_EmailList.GetCongTy_Website_EmailList(maCongTy);
            if (congTy_NganHangListChild)
                _congTy_NganHangList = CongTy_NganHangList.GetCongTy_NganHangList(maCongTy);

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
                cm.CommandText = "spd_InserttblCongTy";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maCongTy = (int)cm.Parameters["@MaCongTy"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maCongTyQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaCongTyQuanLy", _maCongTyQuanLy);
            else
                cm.Parameters.AddWithValue("@MaCongTyQuanLy", DBNull.Value);
            if (_tenCongTy.Length > 0)
                cm.Parameters.AddWithValue("@TenCongTy", _tenCongTy);
            else
                cm.Parameters.AddWithValue("@TenCongTy", DBNull.Value);
            if (_tenVietTat.Length > 0)
                cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
            else
                cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
            if (_tenTiengAnh.Length > 0)
                cm.Parameters.AddWithValue("@TenTiengAnh", _tenTiengAnh);
            else
                cm.Parameters.AddWithValue("@TenTiengAnh", DBNull.Value);
            if (_maSoThue.Length > 0)
                cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
            else
                cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_dienThoai1.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai1", _dienThoai1);
            else
                cm.Parameters.AddWithValue("@DienThoai1", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_fax.Length > 0)
                cm.Parameters.AddWithValue("@Fax", _fax);
            else
                cm.Parameters.AddWithValue("@Fax", DBNull.Value);
            if (_website.Length > 0)
                cm.Parameters.AddWithValue("@Website", _website);
            else
                cm.Parameters.AddWithValue("@Website", DBNull.Value);
            if (_email.Length > 0)
                cm.Parameters.AddWithValue("@Email", _email);
            else
                cm.Parameters.AddWithValue("@Email", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_diaChi1.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi1", _diaChi1);
            else
                cm.Parameters.AddWithValue("@DiaChi1", DBNull.Value);
            if (Logo != null)
                cm.Parameters.AddWithValue("@Logo", _logo);
            else
                cm.Parameters.AddWithValue("@Logo", new byte[0]);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_SoDVSDNS.Length > 0)
                cm.Parameters.AddWithValue("@SoDVSDNS", _SoDVSDNS);
            else
                cm.Parameters.AddWithValue("@SoDVSDNS", DBNull.Value);
            if (_congThue != null)
                cm.Parameters.AddWithValue("@CongThue", _congThue);
            else
                cm.Parameters.AddWithValue("@CongThue", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            cm.Parameters.AddWithValue("@NgayChanSo", _ngayChanSo);
            cm.Parameters["@MaCongTy"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblCongTy";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            if (_maCongTyQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaCongTyQuanLy", _maCongTyQuanLy);
            else
                cm.Parameters.AddWithValue("@MaCongTyQuanLy", DBNull.Value);
            if (_tenCongTy.Length > 0)
                cm.Parameters.AddWithValue("@TenCongTy", _tenCongTy);
            else
                cm.Parameters.AddWithValue("@TenCongTy", DBNull.Value);
            if (_tenVietTat.Length > 0)
                cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
            else
                cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
            if (_tenTiengAnh.Length > 0)
                cm.Parameters.AddWithValue("@TenTiengAnh", _tenTiengAnh);
            else
                cm.Parameters.AddWithValue("@TenTiengAnh", DBNull.Value);
            if (_maSoThue.Length > 0)
                cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
            else
                cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_dienThoai1.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai1", _dienThoai1);
            else
                cm.Parameters.AddWithValue("@DienThoai1", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_fax.Length > 0)
                cm.Parameters.AddWithValue("@Fax", _fax);
            else
                cm.Parameters.AddWithValue("@Fax", DBNull.Value);
            if (_website.Length > 0)
                cm.Parameters.AddWithValue("@Website", _website);
            else
                cm.Parameters.AddWithValue("@Website", DBNull.Value);
            if (_email.Length > 0)
                cm.Parameters.AddWithValue("@Email", _email);
            else
                cm.Parameters.AddWithValue("@Email", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_diaChi1.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi1", _diaChi1);
            else
                cm.Parameters.AddWithValue("@DiaChi1", DBNull.Value);
            if (_logo != null)
                cm.Parameters.AddWithValue("@Logo", _logo);
            else
                cm.Parameters.AddWithValue("@Logo", new byte[0]);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_SoDVSDNS.Length > 0)
                cm.Parameters.AddWithValue("@SoDVSDNS", _SoDVSDNS);
            else
                cm.Parameters.AddWithValue("@SoDVSDNS", DBNull.Value);
            if (_ngayChanSo == DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayChanSo", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayChanSo", _ngayChanSo);
            if (_congThue != null)
                cm.Parameters.AddWithValue("@CongThue", _congThue);
            else
                cm.Parameters.AddWithValue("@CongThue", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            if (_diaChi_CongTyList != null)
                _diaChi_CongTyList.Update(tr, this);
            if (_congTy_DienThoai_FaxList != null)
                _congTy_DienThoai_FaxList.Update(tr, this);
            if (_congTy_Website_EmailList != null)
                _congTy_Website_EmailList.Update(tr, this);
            if (_congTy_NganHangList != null)
                _congTy_NganHangList.Update(tr, this);

        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
            _diaChi_CongTyList.Clear();
            _congTy_DienThoai_FaxList.Clear();
            _congTy_Website_EmailList.Clear();
            _congTy_NganHangList.Clear();

            UpdateChildren(tr);
            ExecuteDelete(tr, new Criteria(_maCongTy));
            MarkNew();
        }
        #endregion //Data Access - Delete


        #region KiemTraMaCongTy

        public static int KiemTraMaCongTy(string maCongTy)
        {
            int giaTri = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraMaCongTy";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    cm.Parameters.AddWithValue("@GiaTri", giaTri);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    giaTri = (int)cm.Parameters["@GiaTri"].Value;
                }
            }//us

            return giaTri;
        }

        public static bool KiemTraCongTyCongThue(int maCongTy)
        {
            bool giaTri = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_tblCongTy_CheckCongThue";
                    cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                    cm.Parameters.AddWithValue("@CongThue", giaTri);
                    cm.Parameters["@CongThue"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    giaTri = (bool)cm.Parameters["@CongThue"].Value;
                }
            }//us

            return giaTri;
        }
        #endregion
        #endregion //Data Access
    }
}
