
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserItem : Csla.BusinessBase<UserItem>
    {
        #region Business Properties and Methods

        //declare members
        internal int _userID = 0;
        private string _tenDangNhap = string.Empty;
        private string _matKhau = string.Empty;
        private int _groupID = 0;
        private long _maNhanVien = 0;
        private int _maBoPhan = 0;
        private int _maCongTy = 0;
        private string _maQLUser = "";
        private int _userIDCha = 0;
        private int _maPhanLoaiUser = 0;
        private string _tenNguoiLap = string.Empty;

        private string _emailDenTang = string.Empty;
        private string _emailGui = string.Empty;
        private string _emailHRM = string.Empty;

        private string _tenThuTruong = string.Empty;

        private bool _capNhatHoSo;
        private bool _capNhatChamCong;
        private bool _capNhatPhuCap;

        //Thành bổ sung
        private string _tenNhanVien = "Không chọn";
        private string _tenBoPhan;
        private string _matKhauEmailGui = string.Empty;
        private bool _isBlock;
        private bool _isKeToanTruong;
        private bool _isKeToanTapDoan;

        //declare child member(s)

        private UserBoPhanList _boPhan = null;
        private PhanQuyenPhuCapList _phuCap = null;
        private UserThuLaoList _thulao = null;
        private UserChildList _userChildList = null;
        [System.ComponentModel.DataObjectField(true, true)]
        public int UserID
        {
            get
            {
                return _userID;
            }
        }

        public bool CapNhatHoSo
        {
            get
            {
                return _capNhatHoSo;
            }
            set
            {
                CanWriteProperty("CapNhatHoSo", true);
                if (!_capNhatHoSo.Equals(value))
                {
                    _capNhatHoSo = value;
                    PropertyHasChanged("CapNhatHoSo");
                }
            }
        }

        public bool CapNhatPhuCap
        {
            get
            {
                return _capNhatPhuCap;
            }
            set
            {
                _capNhatPhuCap = value;

            }
        }

        public bool CapNhatChamCong
        {
            get
            {
                return _capNhatChamCong;
            }
            set
            {
                _capNhatChamCong = value;

            }
        }

        public string MaQLUser
        {
            get
            {
                return _maQLUser;
            }
            set
            {
                if (!_maQLUser.Equals(value))
                {
                    _maQLUser = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenDangNhap
        {
            get
            {
                return _tenDangNhap;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenDangNhap.Equals(value))
                {
                    _tenDangNhap = value;
                    PropertyHasChanged("TenDangNhap");
                }
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        public string MatKhau
        {
            get
            {          
                return _matKhau;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_matKhau.Equals(value))
                {
                    _matKhau = value;
                    PropertyHasChanged("MatKhau");
                }
            }
        }

        public int GroupID
        {
            get
            {
                return _groupID;
            }
            set
            {
                if (!_groupID.Equals(value))
                {
                    _groupID = value;
                    PropertyHasChanged("GroupID");
                }
            }
        }

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public int MaCongTy
        {
            get
            {
                return _maCongTy;
            }
            set
            {
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged();
                }
            }
        }
        public int UserIDCha
        {
            get
            {
                return _userIDCha;
            }
            set
            {
                if (!_userIDCha.Equals(value))
                {
                    _userIDCha = value;
                    PropertyHasChanged("UserIDCha");
                }
            }
        }

        public int MaPhanLoaiUser
        {
            get
            {
                return _maPhanLoaiUser;
            }
            set
            {
                if (!_maPhanLoaiUser.Equals(value))
                {
                    _maPhanLoaiUser = value;
                    PropertyHasChanged("MaPhanLoaiUser");
                }
            }
        }
        public string TenThuTruong
        {
            get { return _tenThuTruong; }
            set { _tenThuTruong = value; }
        }
        public string TenNguoiLap
        {
            get
            {
                return _tenNguoiLap;
            }
            set
            {
                if (!_tenNguoiLap.Equals(value))
                {
                    _tenNguoiLap = value;
                    PropertyHasChanged("TenNguoiLap");
                }
            }
        }

        //_emailDen
        public string EmailDenTang
        {
            get
            {
                return _emailDenTang;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_emailDenTang.Equals(value))
                {
                    _emailDenTang = value;
                    PropertyHasChanged("EmailDenTang");
                }
            }
        }
        public string EmailGui
        {
            get
            {
                return _emailGui;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_emailGui.Equals(value))
                {
                    _emailGui = value;
                    PropertyHasChanged("EmailGui");
                }
            }
        }
        public string MatKhauEmailGui
        {
            get
            {
                return _matKhauEmailGui;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_matKhauEmailGui.Equals(value))
                {
                    _matKhauEmailGui = value;
                    PropertyHasChanged("MatKhauEmailGui");
                }
            }
        }

        public string EmailHRM
        {
            get
            {
                return _emailHRM;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_emailHRM.Equals(value))
                {
                    _emailHRM = value;
                    PropertyHasChanged("EmailHRM");
                }
            }
        }
        public bool IsBlock
        {
            get
            {
                return _isBlock;
            }
            set
            {
                CanWriteProperty("isBlock", true);
                if (!_isBlock.Equals(value))
                {
                    _isBlock = value;
                    PropertyHasChanged("isBlock");
                }
            }
        }
        public bool IsKeToanTruong
        {
            get
            {
                return _isKeToanTruong;
            }
            set
            {
                CanWriteProperty("IsKeToanTruong", true);
                if (!_isKeToanTruong.Equals(value))
                {
                    _isKeToanTruong = value;
                    PropertyHasChanged("IsKeToanTruong");
                }
            }
        }
        public bool IsKeToanTapDoan
        {
            get
            {
                return _isKeToanTapDoan;
            }
            set
            {
                CanWriteProperty("IsKeToanTapDoan", true);
                if (!_isKeToanTapDoan.Equals(value))
                {
                    _isKeToanTapDoan = value;
                    PropertyHasChanged("IsKeToanTapDoan");
                }
            }
        }
        public UserBoPhanList BoPhan
        {
            get
            {
                return _boPhan;
            }
        }

        public PhanQuyenPhuCapList PhuCap
        {
            get
            {
                return _phuCap;
            }
        }

        public UserThuLaoList ThuLao
        {
            get
            {
                return _thulao;
            }
        }
         public UserChildList UserChild
        {
            get
            {
                return _userChildList;
            }
        }
        
        public override bool IsValid
        {
           
            get
            {
                bool _boPhanIsValid = true, _phuCapIsValid = true, _thulaoIsValid = true, _userChildListIsValid = true;
                if (_boPhan != null)
                    _boPhanIsValid = _boPhan.IsValid;
                if (_phuCap != null)
                    _phuCapIsValid = _phuCap.IsValid;
                if (_thulao != null)
                    _thulaoIsValid = _thulao.IsValid;
                if (_userChildList != null)
                    _userChildListIsValid = _userChildList.IsValid;

                return base.IsValid && _boPhanIsValid && _phuCapIsValid && _thulaoIsValid && _userChildListIsValid;
            }
        }

        public override bool IsDirty
        {
            get
            {
                bool _boPhanIsDirty = true, _phuCapIsDirty = true, _thulaoIsDirty = true, _userChildListIsDirty = true;
                if (_boPhan != null)
                    _boPhanIsDirty = _boPhan.IsDirty;
                if (_phuCap != null)
                    _phuCapIsDirty = _phuCap.IsDirty;
                if (_thulao != null)
                    _thulaoIsDirty = _thulao.IsDirty;
                if (_userChildList != null)
                    _userChildListIsDirty = _userChildList.IsDirty;
              return base.IsDirty || _boPhanIsDirty || _phuCapIsDirty || _thulaoIsDirty || _userChildListIsDirty;
            }
        }

        protected override object GetIdValue()
        {
            return _userID;
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
            // TenDangNhap
            //
           // ValidationRules.AddRule(CommonRules.StringRequired, "TenDangNhap");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDangNhap", 50));
            //
            // MatKhau
            //
            //ValidationRules.AddRule(CommonRules.StringRequired, "MatKhau");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MatKhau", 50));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        private UserItem()
        { /* require use of factory method */
           _boPhan = UserBoPhanList.NewUserBoPhanList();
           _phuCap = PhanQuyenPhuCapList.NewPhanQuyenPhuCapList();
           _thulao = UserThuLaoList.NewUserThuLaoList();
          _userChildList = UserChildList.NewUserChildList();

    }
        private UserItem(bool chooseChild = true )
        { /* require use of factory method */ }

        public static UserItem NewUserItem()
        {
            return DataPortal.Create<UserItem>();
        }
        public static UserItem NewUserItemChooseChild( )
        {
          return new UserItem(true);
        }
        public static UserItem NewUserItem(string TenDangNhap)
        {
            UserItem child = new UserItem();
            child.TenDangNhap = TenDangNhap;
            return child;
        }

        public static UserItem GetUserItem(int userID)
        {
            return DataPortal.Fetch<UserItem>(new Criteria(userID));
        }
        public static UserItem GetUserItemChooseChild(int userID, bool boPhanChild, bool phuCapChild, bool thulaoChild, bool userChildListChild)
        {
           return DataPortal.Fetch<UserItem>(new CriteriaChooseChild(userID, boPhanChild, phuCapChild, thulaoChild, userChildListChild));
           //return new UserItem(true).FetchGetUserItemChooseChild(userID, boPhanChild, phuCapChild, thulaoChild, userChildListChild);
        }
        public static void DeleteUserItem(int userID)
        {
            DataPortal.Delete(new Criteria(userID));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static UserItem NewUserItemChild()
        {
            UserItem child = new UserItem();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static UserItem NewUserItemChild(string TenDangNhap)
        {
            UserItem child = new UserItem();
            child.TenDangNhap = TenDangNhap;
            return child;
        }
        internal static UserItem GetUserItem(SafeDataReader dr, SqlTransaction tr)
        {
            UserItem child = new UserItem();
            child.MarkAsChild();
            child.Fetch(dr, tr);
            return child;
        }
        internal static UserItem GetUserItemChooseChild(SafeDataReader dr, SqlTransaction tr, bool boPhanChild, bool secondChild, bool thirdthChild, bool fourthChild)
        {
            UserItem child = new UserItem(chooseChild: true);
            child.MarkAsChild();
            child.FetchChooseChild(dr,tr, boPhanChild, secondChild, thirdthChild, fourthChild);
            return child;
        }
        internal static UserItem GetUserItem_GBC(SafeDataReader dr, SqlTransaction tr)
        {
            UserItem child = new UserItem();
            child.MarkAsChild();
            child.Fetch_GBC(dr, tr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int UserID;

            public Criteria(int userID)
            {
                this.UserID = userID;
            }
        }
        [Serializable()]
        private class CriteriaChooseChild
        {
            public int UserID;
            public bool BoPhanChild;
            public bool PhuCapChild;
            public bool ThulaoChild;
            public bool UserChildListChild;
            public CriteriaChooseChild(int userID, bool boPhanChild, bool phuCapChild, bool thulaoChild, bool userChildListChild)
            {
                this.UserID = userID;
                this.BoPhanChild = boPhanChild;
                this.PhuCapChild = phuCapChild;
                this.ThulaoChild = thulaoChild;
                this.UserChildListChild = userChildListChild;
             }
        }
        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            //ValidationRules.CheckRules();
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
                if (criteria is Criteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "app_Select_UserItem";

                    cm.Parameters.AddWithValue("@UserID", ((Criteria)criteria).UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren();
                        }
                    }
                }
                else if (criteria is CriteriaChooseChild)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "app_Select_UserItem";
                    cm.Parameters.AddWithValue("@UserID", ((CriteriaChooseChild)criteria).UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildrenChooseChild
                                (
                                        ((CriteriaChooseChild)criteria).BoPhanChild, 
                                        ((CriteriaChooseChild)criteria).PhuCapChild, 
                                        ((CriteriaChooseChild)criteria).ThulaoChild, 
                                        ((CriteriaChooseChild)criteria).UserChildListChild
                                );
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
            DataPortal_Delete(new Criteria(_userID));
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
                cm.CommandText = "app_Delete_UserItem";

                cm.Parameters.AddWithValue("@UserID", criteria.UserID);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr, SqlTransaction tr)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren();
        }

        private void FetchChooseChild(SafeDataReader dr, SqlTransaction tr, bool boPhanChild, bool phuCapChild, bool thulaoChild, bool userChildListChild)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();
            FetchChildrenChooseChild(boPhanChild, phuCapChild, thulaoChild, userChildListChild);
        }
        private void Fetch_GBC(SafeDataReader dr, SqlTransaction tr)
        {
            FetchObject_GBC(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            //FetchChildren();
        }

        private void FetchObject(SafeDataReader dr)
        {
            _userID = dr.GetInt32("UserID");
            _tenDangNhap = dr.GetString("TenDangNhap");         
            _matKhau = EncryptUtil.DecryptString(dr.GetString("MatKhau"), "System.Windows.Forms.MessageBox");
            _groupID = dr.GetInt32("GroupID");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maCongTy = dr.GetInt32("MaCongTy");
            _maQLUser = dr.GetString("MaQLUser");
            _userIDCha = dr.GetInt32("UserIDCha");
            _maPhanLoaiUser = dr.GetInt32("MaPhanLoaiUser");
            _tenThuTruong = dr.GetString("ThuTruong_Ten");
            _tenNguoiLap = dr.GetString("NguoiLap_Ten");
            _capNhatHoSo = dr.GetBoolean("CapNhatHoSo");
            _capNhatChamCong = dr.GetBoolean("ChamCong");
            _capNhatPhuCap = dr.GetBoolean("PhuCap");
            _emailDenTang = dr.GetString("EmailDenTang");
            _emailGui = dr.GetString("EmailGui");
            _emailHRM = dr.GetString("EmailHRM");
            _matKhauEmailGui = dr.GetString("MatKhauEmailGui");
            _isBlock = dr.GetBoolean("IsBlock");
            _isKeToanTruong = dr.GetBoolean("IsKeToanTruong");
            _isKeToanTapDoan = dr.GetBoolean("IsKeToanTapDoan");
        }

        private void FetchObject_GBC(SafeDataReader dr)
        {
            _userID = dr.GetInt32("UserID");
            _tenDangNhap = dr.GetString("TenDangNhap");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maCongTy = dr.GetInt32("MaCongTy");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
        }

        private void FetchChildren()
        {
            _boPhan = UserBoPhanList.GetUserBoPhanList(_userID);
            _phuCap = PhanQuyenPhuCapList.GetPhanQuyenPhuCapList(_userID);
            _thulao = UserThuLaoList.GetUserThuLaoList(_userID);
            _userChildList = UserChildList.GetUserChildList(_userID);
        }
        private void FetchChildrenChooseChild(bool boPhanChild, bool phuCapChild, bool thulaoChild, bool userChildListChild)
        {
            if(boPhanChild)
                 _boPhan = UserBoPhanList.GetUserBoPhanList(_userID);
            if (phuCapChild)
                _phuCap = PhanQuyenPhuCapList.GetPhanQuyenPhuCapList(_userID);
            if (thulaoChild)
                _thulao = UserThuLaoList.GetUserThuLaoList(_userID);
            if (userChildListChild)
                _userChildList = UserChildList.GetUserChildList(_userID);
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
                cm.CommandText = "app_Insert_UserItem";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _userID = (int)cm.Parameters["@UserID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@TenDangNhap", _tenDangNhap);
            cm.Parameters.AddWithValue("@MatKhau", EncryptUtil.EncryptString(_matKhau, "System.Windows.Forms.MessageBox"));
            cm.Parameters.AddWithValue("@GroupID", _groupID);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters["@UserID"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            cm.Parameters.AddWithValue("@MaQLUser", _maQLUser);
            if (_userIDCha != 0)
                cm.Parameters.AddWithValue("@UserIDCha", _userIDCha);
            else
                cm.Parameters.AddWithValue("@UserIDCha", DBNull.Value);
            if (_maPhanLoaiUser != 0)
                cm.Parameters.AddWithValue("@MaPhanLoaiUser", _maPhanLoaiUser);
            else
                cm.Parameters.AddWithValue("@MaPhanLoaiUser", DBNull.Value);
            if (_emailGui != string.Empty)
                cm.Parameters.AddWithValue("@EmailGui", _emailGui);
            else
                cm.Parameters.AddWithValue("@EmailGui", DBNull.Value);
            if (_emailDenTang != string.Empty)
                cm.Parameters.AddWithValue("@EmailDenTang", _emailDenTang);
            else
                cm.Parameters.AddWithValue("@EmailDenTang", DBNull.Value);
            if (_emailHRM != string.Empty)
                cm.Parameters.AddWithValue("@EmailHRM", _emailHRM);
            else
                cm.Parameters.AddWithValue("@EmailHRM", DBNull.Value);
            if (_matKhauEmailGui != string.Empty)
                cm.Parameters.AddWithValue("@MatKhauEmailGui", _matKhauEmailGui);
            else
                cm.Parameters.AddWithValue("@MatKhauEmailGui", DBNull.Value);

            cm.Parameters.AddWithValue("@CapNhatHoSo", _capNhatHoSo);
            cm.Parameters.AddWithValue("@IsBlock", _isBlock);
            cm.Parameters.AddWithValue("@CapNhatPhuCap", _capNhatPhuCap);
                cm.Parameters.AddWithValue("@CapNhatChamCong", _capNhatChamCong);
            if (_tenNguoiLap != string.Empty)
                cm.Parameters.AddWithValue("@TenNguoiLap", _tenNguoiLap);
            else
                cm.Parameters.AddWithValue("@TenNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@IsKeToanTruong", _isKeToanTruong);
            cm.Parameters.AddWithValue("@IsKeToanTapDoan", _isKeToanTapDoan);
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
                cm.CommandText = "app_Update_UserItem";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@TenDangNhap", _tenDangNhap); ;
            cm.Parameters.AddWithValue("@MatKhau", EncryptUtil.EncryptString(_matKhau, "System.Windows.Forms.MessageBox"));
            cm.Parameters.AddWithValue("@GroupID", _groupID);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            cm.Parameters.AddWithValue("@MaQLUser", _maQLUser);
            if (_userIDCha != 0)
                cm.Parameters.AddWithValue("@UserIDCha", _userIDCha);
            else
                cm.Parameters.AddWithValue("@UserIDCha", DBNull.Value);
            if (_maPhanLoaiUser != 0)
                cm.Parameters.AddWithValue("@MaPhanLoaiUser", _maPhanLoaiUser);
            else
                cm.Parameters.AddWithValue("@MaPhanLoaiUser", DBNull.Value);

            cm.Parameters.AddWithValue("@CapNhatHoSo", _capNhatHoSo);
            cm.Parameters.AddWithValue("@CapNhatPhuCap", _capNhatPhuCap);
            cm.Parameters.AddWithValue("@CapNhatChamCong", _capNhatChamCong);

            if (_emailGui != string.Empty)
                cm.Parameters.AddWithValue("@EmailGui", _emailGui);
            else
                cm.Parameters.AddWithValue("@EmailGui", DBNull.Value);
            if (_emailDenTang != string.Empty)
                cm.Parameters.AddWithValue("@EmailDenTang", _emailDenTang);
            else
                cm.Parameters.AddWithValue("@EmailDenTang", DBNull.Value);
            if (_emailHRM != string.Empty)
                cm.Parameters.AddWithValue("@EmailHRM", _emailHRM);
            else
                cm.Parameters.AddWithValue("@EmailHRM", DBNull.Value);
            if (_matKhauEmailGui != string.Empty)
                cm.Parameters.AddWithValue("@MatKhauEmailGui", _matKhauEmailGui);
            else
                cm.Parameters.AddWithValue("@MatKhauEmailGui", DBNull.Value);
            if (_tenNguoiLap != string.Empty)
                cm.Parameters.AddWithValue("@TenNguoiLap", _tenNguoiLap);
            else
                cm.Parameters.AddWithValue("@TenNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@IsBlock", _isBlock);
            cm.Parameters.AddWithValue("@IsKeToanTruong", _isKeToanTruong);
            cm.Parameters.AddWithValue("@IsKeToanTapDoan", _isKeToanTapDoan);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            if(_boPhan!=null)
               _boPhan.Update(tr, this);
            if (_phuCap != null)
                _phuCap.Update(tr, this);
            if (_thulao != null)
                _thulao.Update(tr, this);
            if (_userChildList != null)
                _userChildList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_userID));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
