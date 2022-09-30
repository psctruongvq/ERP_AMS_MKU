
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChuongTrinh_New : Csla.BusinessBase<ChuongTrinh_New>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChuongTrinh = 0;
        private string _maQL = string.Empty;
        private string _tenChuongTrinh = string.Empty;
        private SmartDate _ngaySanXuat = new SmartDate(false);
        private SmartDate _ngayKetThuc = new SmartDate(false);
        private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private SmartDate _ngayLap = new SmartDate(false);
        private int _maChuongTrinhCha = 0;
        private bool _hoanTat = false;
        private int _maNguon = 0;
        private string _tenNguon = string.Empty;
        //private int _maLoaiChuongTrinh = 0;
        //private string _ghiChu = string.Empty;
        private int _maCongTy =ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private bool _dungChung = false;
        private decimal _phanTramThueTNCN = 0;
        private int _maPhanCap = 1;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;

        //MaQuocGia, MaDonViTinh, ThoiLuong
        private int _maQuocGia = 0;
        private int _maDonViTinh = 0;
        private decimal _thoiLuong = 0; 
        //
        private Boolean _chon = false;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChuongTrinh
        {
            get
            {
                CanReadProperty("MaChuongTrinh", true);
                return _maChuongTrinh;
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

        public string TenChuongTrinh
        {
            get
            {
                CanReadProperty("TenChuongTrinh", true);
                return _tenChuongTrinh;
            }
            set
            {
                CanWriteProperty("TenChuongTrinh", true);
                if (value == null) value = string.Empty;
                if (!_tenChuongTrinh.Equals(value))
                {
                    _tenChuongTrinh = value;
                    PropertyHasChanged("TenChuongTrinh");
                }
            }
        }

        public DateTime NgaySanXuat
        {
            get
            {
                CanReadProperty("NgaySanXuat", true);
                return _ngaySanXuat.Date;
            }
        }

        public string NgaySanXuatString
        {
            get
            {
                CanReadProperty("NgaySanXuatString", true);
                return _ngaySanXuat.Text;
            }
            set
            {
                CanWriteProperty("NgaySanXuatString", true);
                if (value == null) value = string.Empty;
                if (!_ngaySanXuat.Equals(value))
                {
                    _ngaySanXuat.Text = value;
                    PropertyHasChanged("NgaySanXuatString");
                }
            }
        }

        public DateTime NgayKetThuc
        {
            get
            {
                CanReadProperty("NgayKetThuc", true);
                return _ngayKetThuc.Date;
            }
        }

        public string NgayKetThucString
        {
            get
            {
                CanReadProperty("NgayKetThucString", true);
                return _ngayKetThuc.Text;
            }
            set
            {
                CanWriteProperty("NgayKetThucString", true);
                if (value == null) value = string.Empty;
                if (!_ngayKetThuc.Equals(value))
                {
                    _ngayKetThuc.Text = value;
                    PropertyHasChanged("NgayKetThucString");
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

        public int MaChuongTrinhCha
        {
            get
            {
                CanReadProperty("MaChuongTrinhCha", true);
                return _maChuongTrinhCha;
            }
            set
            {
                CanWriteProperty("MaChuongTrinhCha", true);
                if (!_maChuongTrinhCha.Equals(value))
                {
                    _maChuongTrinhCha = value;
                    PropertyHasChanged("MaChuongTrinhCha");
                }
            }
        }

        public bool HoanTat
        {
            get
            {
                CanReadProperty("HoanTat", true);
                return _hoanTat;
            }
            set
            {
                CanWriteProperty("HoanTat", true);
                if (!_hoanTat.Equals(value))
                {
                    _hoanTat = value;
                    PropertyHasChanged("HoanTat");
                }
            }
        }

        public int MaNguon
        {
            get
            {
                CanReadProperty("MaNguon", true);
                return _maNguon;
            }
            set
            {
                CanWriteProperty("MaNguon", true);
                if (!_maNguon.Equals(value))
                {
                    _maNguon = value;
                    PropertyHasChanged("MaNguon");
                    _tenNguon = Nguon.GetNguon(_maNguon).TenNguon;
                }
            }
        }

        public string TenNguon
        {
            get
            {
                CanReadProperty("TenNguon", true);
                return _tenNguon;
            }
            set
            {
                CanWriteProperty("TenNguon", true);
                if (value == null) value = string.Empty;
                if (!_tenNguon.Equals(value))
                {
                    _tenNguon = value;
                    PropertyHasChanged("TenNguon");
                }
            }
        }

        //public int MaLoaiChuongTrinh
        //{
        //    get
        //    {
        //        CanReadProperty("MaLoaiChuongTrinh", true);
        //        return _maLoaiChuongTrinh;
        //    }
        //    set
        //    {
        //        CanWriteProperty("MaLoaiChuongTrinh", true);
        //        if (!_maLoaiChuongTrinh.Equals(value))
        //        {
        //            _maLoaiChuongTrinh = value;
        //            PropertyHasChanged("MaLoaiChuongTrinh");
        //        }
        //    }
        //}

        //public string GhiChu
        //{
        //    get
        //    {
        //        CanReadProperty("GhiChu", true);
        //        return _ghiChu;
        //    }
        //    set
        //    {
        //        CanWriteProperty("GhiChu", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ghiChu.Equals(value))
        //        {
        //            _ghiChu = value;
        //            PropertyHasChanged("GhiChu");
        //        }
        //    }
        //}

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
        public bool Chon
        {
            get
            {
                CanReadProperty("Chon", true);
                return _chon;
            }
            set
            {
                CanWriteProperty("Chon", true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
            }
        }
        public decimal PhanTramThueTNCN
        {
            get
            {
                CanReadProperty("PhanTramThueTNCN", true);
                return _phanTramThueTNCN;
            }
            set
            {
                CanWriteProperty("PhanTramThueTNCN", true);
                if (!_phanTramThueTNCN.Equals(value))
                {
                    _phanTramThueTNCN = value;
                    PropertyHasChanged("PhanTramThueTNCN");
                }
            }
        }

        public int MaPhanCap
        {
            get
            {
                CanReadProperty("MaPhanCap", true);
                return _maPhanCap;
            }
            set
            {
                CanWriteProperty("MaPhanCap", true);
                if (!_maPhanCap.Equals(value))
                {
                    _maPhanCap = value;
                    PropertyHasChanged("MaPhanCap");
                }
            }
        }


        public int MaBoPhan
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

        //
        public int MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                return _maQuocGia;
            }
            set
            {
                CanWriteProperty("MaQuocGia", true);
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    PropertyHasChanged("MaQuocGia");
                }
            }
        }

        public int MaDonViTinh
        {
            get
            {
                CanReadProperty("MaDonViTinh", true);
                return _maDonViTinh;
            }
            set
            {
                CanWriteProperty("MaDonViTinh", true);
                if (!_maDonViTinh.Equals(value))
                {
                    _maDonViTinh = value;
                    PropertyHasChanged("MaDonViTinh");
                }
            }
        }

        public decimal ThoiLuong
        {
            get
            {
                CanReadProperty("ThoiLuong", true);
                return _thoiLuong;
            }
            set
            {
                CanWriteProperty("ThoiLuong", true);
                if (!_thoiLuong.Equals(value))
                {
                    _thoiLuong = value;
                    PropertyHasChanged("ThoiLuong");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChuongTrinh;
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
            // MaQL
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQL", 100));
            ////
            //// TenChuongTrinh
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChuongTrinh", 500));
            ////
            //// TenNguon
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNguon", 500));
            //
            // GhiChu
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
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
            //TODO: Define authorization rules in ChuongTrinh_New
            //AuthorizationRules.AllowRead("MaChuongTrinh", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("MaQL", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("TenChuongTrinh", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("NgaySanXuat", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("NgaySanXuatString", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("NgayKetThuc", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("NgayKetThucString", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("MaChuongTrinhCha", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("HoanTat", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("MaNguon", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("TenNguon", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiChuongTrinh", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("DungChung", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("PhanTramThueTNCN", "ChuongTrinh_NewReadGroup");
            //AuthorizationRules.AllowRead("MaPhanCap", "ChuongTrinh_NewReadGroup");

            //AuthorizationRules.AllowWrite("MaQL", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("TenChuongTrinh", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("NgaySanXuatString", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKetThucString", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("MaChuongTrinhCha", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("HoanTat", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguon", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("TenNguon", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiChuongTrinh", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("DungChung", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramThueTNCN", "ChuongTrinh_NewWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhanCap", "ChuongTrinh_NewWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuongTrinh_New
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuongTrinh_New
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuongTrinh_New
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuongTrinh_New
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuongTrinh_New()
        { /* require use of factory method */ }

        public static ChuongTrinh_New NewChuongTrinh_New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuongTrinh_New");
            return DataPortal.Create<ChuongTrinh_New>();
        }
        public static ChuongTrinh_New NewChuongTrinh_New(string tenChuongTrinh)
        {
            ChuongTrinh_New ct = ChuongTrinh_New.NewChuongTrinh_New();
            ct.TenChuongTrinh = tenChuongTrinh;
            return ct;
        }

        public static ChuongTrinh_New GetChuongTrinh_New(int maChuongTrinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_New");
            return DataPortal.Fetch<ChuongTrinh_New>(new Criteria(maChuongTrinh));
        }

        public static void DeleteChuongTrinh_New(int maChuongTrinh)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChuongTrinh_New");
            DataPortal.Delete(new Criteria(maChuongTrinh));
        }

        public override ChuongTrinh_New Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChuongTrinh_New");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuongTrinh_New");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChuongTrinh_New");

            return base.Save();
        }

        public static bool ExistsChuongTrinh(int maChuongTrinh)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "ExistsChuongTrinh";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
            
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChuongTrinh_New NewChuongTrinh_NewChild()
        {
            ChuongTrinh_New child = new ChuongTrinh_New();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }
        
        internal static ChuongTrinh_New GetChuongTrinh_New(SafeDataReader dr)
        {
            ChuongTrinh_New child = new ChuongTrinh_New();
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
            public int MaChuongTrinh;

            public Criteria(int maChuongTrinh)
            {
                this.MaChuongTrinh = maChuongTrinh;
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
                cm.CommandText = "spd_SelecttblnsChuongTrinh_New";
                cm.Parameters.AddWithValue("@MaChuongTrinh", ((Criteria)criteria).MaChuongTrinh);
                //cm.CommandText = "GetChuongTrinh_New";
                //cm.Parameters.AddWithValue("@MaChuongTrinh", criteria.MaChuongTrinh);

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

                ExecuteInsert(cn, null);

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
                    ExecuteUpdate(cn, null);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maChuongTrinh));
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
                cm.CommandText = "spd_DeletetblnsChuongTrinh";

                cm.Parameters.AddWithValue("@MaChuongTrinh", criteria.MaChuongTrinh);

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
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _maQL = dr.GetString("MaQL");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
            _ngaySanXuat = dr.GetSmartDate("NgaySanXuat", _ngaySanXuat.EmptyIsMin);
            _ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
            _maNguoiLap = dr.GetInt64("MaNguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _maChuongTrinhCha = dr.GetInt32("MaChuongTrinhCha");
            _hoanTat = dr.GetBoolean("HoanTat");
            _maNguon = dr.GetInt32("MaNguon");
            _tenNguon = dr.GetString("TenNguon");
            //_maLoaiChuongTrinh = dr.GetInt32("MaLoaiChuongTrinh");
            //_ghiChu = dr.GetString("GhiChu");
            _maCongTy = dr.GetInt32("MaCongTy");
            _dungChung = dr.GetBoolean("DungChung");
            _phanTramThueTNCN = dr.GetDecimal("PhanTramThueTNCN");
            _maPhanCap = dr.GetInt32("MaPhanCap");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            //
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _thoiLuong = dr.GetDecimal("ThoiLuong");

        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn, ChuongTrinh_NewList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn, ChuongTrinh_NewList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsChuongTrinh_New";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChuongTrinh = (int)cm.Parameters["@MaChuongTrinh"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChuongTrinh_NewList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgaySanXuat", _ngaySanXuat.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maChuongTrinhCha != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinhCha", _maChuongTrinhCha);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhCha", DBNull.Value);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", false);//DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("@MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
            if (_tenNguon.Length > 0)
                cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
            else
                cm.Parameters.AddWithValue("@TenNguon", DBNull.Value);
            //if (_maLoaiChuongTrinh != 0)
            //    cm.Parameters.AddWithValue("@MaLoaiChuongTrinh", _maLoaiChuongTrinh);
            //else
            //    cm.Parameters.AddWithValue("@MaLoaiChuongTrinh", DBNull.Value);
            //if (_ghiChu.Length > 0)
            //    cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            //else
            //    cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_dungChung != false)
                cm.Parameters.AddWithValue("@DungChung", _dungChung);
            else
                cm.Parameters.AddWithValue("@DungChung",false);//, DBNull.Value);
            if (_phanTramThueTNCN != 0)
                cm.Parameters.AddWithValue("@PhanTramThueTNCN", _phanTramThueTNCN);
            else
                cm.Parameters.AddWithValue("@PhanTramThueTNCN", DBNull.Value);
            if (_maPhanCap != 0)
                cm.Parameters.AddWithValue("@MaPhanCap", _maPhanCap);
            else
                cm.Parameters.AddWithValue("@MaPhanCap", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            //
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);

            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);

            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong",DBNull.Value);

            cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            cm.Parameters["@MaChuongTrinh"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn, ChuongTrinh_NewList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn, ChuongTrinh_NewList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsChuongTrinh_New";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChuongTrinh_NewList parent)
        {
            cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgaySanXuat", _ngaySanXuat.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maChuongTrinhCha != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinhCha", _maChuongTrinhCha);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhCha", DBNull.Value);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", false);//DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("@MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
            if (_tenNguon.Length > 0)
                cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
            else
                cm.Parameters.AddWithValue("@TenNguon", DBNull.Value);
            //if (_maLoaiChuongTrinh != 0)
            //    cm.Parameters.AddWithValue("@MaLoaiChuongTrinh", _maLoaiChuongTrinh);
            //else
            //    cm.Parameters.AddWithValue("@MaLoaiChuongTrinh", DBNull.Value);
            //if (_ghiChu.Length > 0)
            //    cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            //else
            //    cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_dungChung != false)
                cm.Parameters.AddWithValue("@DungChung", _dungChung);
            else
                cm.Parameters.AddWithValue("@DungChung", false);//DBNull.Value);
            if (_phanTramThueTNCN != 0)
                cm.Parameters.AddWithValue("@PhanTramThueTNCN", _phanTramThueTNCN);
            else
                cm.Parameters.AddWithValue("@PhanTramThueTNCN", DBNull.Value);
            if (_maPhanCap != 0)
                cm.Parameters.AddWithValue("@MaPhanCap", _maPhanCap);
            else
                cm.Parameters.AddWithValue("@MaPhanCap", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            //
            //
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);

            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);

            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_maChuongTrinh));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
