using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BoPhanERPNew : Csla.BusinessBase<BoPhanERPNew>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBoPhan = 0;
        private int _maBoPhanCha = 0;
        private string _tenBoPhan = string.Empty;
        private string _maBoPhanQL = string.Empty;
        private string _maBoPhanQLCu = string.Empty;
        private string _viTri = string.Empty;
        private string _maKhoiNhaCu = string.Empty;
        private string _maKhoiNhaMoi = string.Empty;
        private string _maHoaPhongNhomHoaThat = string.Empty;
        private string _maPhongHKEdusoft = string.Empty;
        private string _dienGiai = string.Empty;
        private string _tenTiengAnh = string.Empty;
        private int _maTinhChatPhong = 0;
        private int _soChoNgoiTheoThucTe = 0;
        private int _soChoNgoiTheoThietKe = 0;
        private decimal _dienTich = 0;
        private string _donViSuDung = string.Empty;
        private string _ghiChu = string.Empty;
        private string _quyPhongXepTKB = string.Empty;
        private bool _khauHaoHaoMon = false;
        private bool _laBoPhanMoRong = false;
        private int _mappingID = 0;
        private string _soPhong = string.Empty;
        private bool _isNgungSuDung = false;
        private DateTime _ngayNgungSuDung = DateTime.MinValue;
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
        }

        public int MaBoPhanCha
        {
            get
            {
                CanReadProperty("MaBoPhanCha", true);
                return _maBoPhanCha;
            }
            set
            {
                CanWriteProperty("MaBoPhanCha", true);
                if (!_maBoPhanCha.Equals(value))
                {
                    _maBoPhanCha = value;
                    PropertyHasChanged("MaBoPhanCha");
                }
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
            set
            {
                CanWriteProperty("TenBoPhan", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                CanReadProperty("MaBoPhanQL", true);
                return _maBoPhanQL;
            }
            set
            {
                CanWriteProperty("MaBoPhanQL", true);
                if (value == null) value = string.Empty;
                if (!_maBoPhanQL.Equals(value))
                {
                    _maBoPhanQL = value;
                    PropertyHasChanged("MaBoPhanQL");
                }
            }
        }

        public string MaBoPhanQLCu
        {
            get
            {
                CanReadProperty("MaBoPhanQLCu", true);
                return _maBoPhanQLCu;
            }
            set
            {
                CanWriteProperty("MaBoPhanQLCu", true);
                if (value == null) value = string.Empty;
                if (!_maBoPhanQLCu.Equals(value))
                {
                    _maBoPhanQLCu = value;
                    PropertyHasChanged("MaBoPhanQLCu");
                }
            }
        }

        public string ViTri
        {
            get
            {
                CanReadProperty("ViTri", true);
                return _viTri;
            }
            set
            {
                CanWriteProperty("ViTri", true);
                if (value == null) value = string.Empty;
                if (!_viTri.Equals(value))
                {
                    _viTri = value;
                    PropertyHasChanged("ViTri");
                }
            }
        }

        public string MaKhoiNhaCu
        {
            get
            {
                CanReadProperty("MaKhoiNhaCu", true);
                return _maKhoiNhaCu;
            }
            set
            {
                CanWriteProperty("MaKhoiNhaCu", true);
                if (value == null) value = string.Empty;
                if (!_maKhoiNhaCu.Equals(value))
                {
                    _maKhoiNhaCu = value;
                    PropertyHasChanged("MaKhoiNhaCu");
                }
            }
        }

        public string MaKhoiNhaMoi
        {
            get
            {
                CanReadProperty("MaKhoiNhaMoi", true);
                return _maKhoiNhaMoi;
            }
            set
            {
                CanWriteProperty("MaKhoiNhaMoi", true);
                if (value == null) value = string.Empty;
                if (!_maKhoiNhaMoi.Equals(value))
                {
                    _maKhoiNhaMoi = value;
                    PropertyHasChanged("MaKhoiNhaMoi");
                }
            }
        }

        public string MaHoaPhongNhomHoaThat
        {
            get
            {
                CanReadProperty("MaHoaPhongNhomHoaThat", true);
                return _maHoaPhongNhomHoaThat;
            }
            set
            {
                CanWriteProperty("MaHoaPhongNhomHoaThat", true);
                if (value == null) value = string.Empty;
                if (!_maHoaPhongNhomHoaThat.Equals(value))
                {
                    _maHoaPhongNhomHoaThat = value;
                    PropertyHasChanged("MaHoaPhongNhomHoaThat");
                }
            }
        }

        public string MaPhongHKEdusoft
        {
            get
            {
                CanReadProperty("MaPhongHKEdusoft", true);
                return _maPhongHKEdusoft;
            }
            set
            {
                CanWriteProperty("MaPhongHKEdusoft", true);
                if (value == null) value = string.Empty;
                if (!_maPhongHKEdusoft.Equals(value))
                {
                    _maPhongHKEdusoft = value;
                    PropertyHasChanged("MaPhongHKEdusoft");
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

        public string TenTiengAnh
        {
            get
            {
                CanReadProperty("TenTiengAnh", true);
                return _tenTiengAnh;
            }
            set
            {
                CanWriteProperty("TenTiengAnh", true);
                if (value == null) value = string.Empty;
                if (!_tenTiengAnh.Equals(value))
                {
                    _tenTiengAnh = value;
                    PropertyHasChanged("TenTiengAnh");
                }
            }
        }

        public int MaTinhChatPhong
        {
            get
            {
                CanReadProperty("MaTinhChatPhong", true);
                return _maTinhChatPhong;
            }
            set
            {
                CanWriteProperty("MaTinhChatPhong", true);
                if (!_maTinhChatPhong.Equals(value))
                {
                    _maTinhChatPhong = value;
                    PropertyHasChanged("MaTinhChatPhong");
                }
            }
        }

        public int SoChoNgoiTheoThucTe
        {
            get
            {
                CanReadProperty("SoChoNgoiTheoThucTe", true);
                return _soChoNgoiTheoThucTe;
            }
            set
            {
                CanWriteProperty("SoChoNgoiTheoThucTe", true);
                if (!_soChoNgoiTheoThucTe.Equals(value))
                {
                    _soChoNgoiTheoThucTe = value;
                    PropertyHasChanged("SoChoNgoiTheoThucTe");
                }
            }
        }

        public int SoChoNgoiTheoThietKe
        {
            get
            {
                CanReadProperty("SoChoNgoiTheoThietKe", true);
                return _soChoNgoiTheoThietKe;
            }
            set
            {
                CanWriteProperty("SoChoNgoiTheoThietKe", true);
                if (!_soChoNgoiTheoThietKe.Equals(value))
                {
                    _soChoNgoiTheoThietKe = value;
                    PropertyHasChanged("SoChoNgoiTheoThietKe");
                }
            }
        }

        public decimal DienTich
        {
            get
            {
                CanReadProperty("DienTich", true);
                return _dienTich;
            }
            set
            {
                CanWriteProperty("DienTich", true);
                if (!_dienTich.Equals(value))
                {
                    _dienTich = value;
                    PropertyHasChanged("DienTich");
                }
            }
        }

        public string DonViSuDung
        {
            get
            {
                CanReadProperty("DonViSuDung", true);
                return _donViSuDung;
            }
            set
            {
                CanWriteProperty("DonViSuDung", true);
                if (value == null) value = string.Empty;
                if (!_donViSuDung.Equals(value))
                {
                    _donViSuDung = value;
                    PropertyHasChanged("DonViSuDung");
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

        public string QuyPhongXepTKB
        {
            get
            {
                CanReadProperty("QuyPhongXepTKB", true);
                return _quyPhongXepTKB;
            }
            set
            {
                CanWriteProperty("QuyPhongXepTKB", true);
                if (value == null) value = string.Empty;
                if (!_quyPhongXepTKB.Equals(value))
                {
                    _quyPhongXepTKB = value;
                    PropertyHasChanged("QuyPhongXepTKB");
                }
            }
        }
        public string SoPhong
        {
            get
            {
                CanReadProperty("SoPhong", true);
                return _soPhong;
            }
            set
            {
                CanWriteProperty("SoPhong", true);
                if (value == null) value = string.Empty;
                if (!_soPhong.Equals(value))
                {
                    _soPhong = value;
                    PropertyHasChanged("SoPhong");
                }
            }
        }
        public bool KhauHaoHaoMon
        {
            get
            {
                CanReadProperty("KhauHaoHaoMon", true);
                return _khauHaoHaoMon;
            }
            set
            {
                CanWriteProperty("KhauHaoHaoMon", true);
                if (!_khauHaoHaoMon.Equals(value))
                {
                    _khauHaoHaoMon = value;
                    PropertyHasChanged("KhauHaoHaoMon");
                }
            }
        }

        public bool LaBoPhanMoRong
        {
            get
            {
                CanReadProperty("LaBoPhanMoRong", true);
                return _laBoPhanMoRong;
            }
            set
            {
                CanWriteProperty("LaBoPhanMoRong", true);
                if (!_laBoPhanMoRong.Equals(value))
                {
                    _laBoPhanMoRong = value;
                    PropertyHasChanged("LaBoPhanMoRong");
                }
            }
        }

        public int MappingID
        {
            get
            {
                CanReadProperty("MappingID", true);
                return _mappingID;
            }
            set
            {
                CanWriteProperty("MappingID", true);
                if (!_mappingID.Equals(value))
                {
                    _mappingID = value;
                    PropertyHasChanged("MappingID");
                }
            }
        }
        public bool IsNgungSuDung
        {
            get
            {
                CanReadProperty("IsNgungSuDung", true);
                return _isNgungSuDung;
            }
            set
            {
                CanWriteProperty("IsNgungSuDung", true);
                if (!_isNgungSuDung.Equals(value))
                {
                    _isNgungSuDung = value;
                    PropertyHasChanged("IsNgungSuDung");
                }
            }
        }
        public DateTime NgayNgungSuDung
        {
            get
            {
                CanReadProperty("NgayNgungSuDung", true);
                return _ngayNgungSuDung;
            }
            set
            {
                CanWriteProperty("NgayNgungSuDung", true);
                if (!_ngayNgungSuDung.Equals(value))
                {
                    _ngayNgungSuDung = value;
                    PropertyHasChanged("NgayNgungSuDung");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _maBoPhan;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaBoPhanQL", 250));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaBoPhanQLCu", 250));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ViTri", 250));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaKhoiNhaCu", 50));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaKhoiNhaMoi", 50));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaHoaPhongNhomHoaThat", 50));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhongHKEdusoft", 50));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DonViSuDung", 50));
            ValidationRules.AddRule(CommonRules.StringRequired, "MaBoPhanQL");
            ValidationRules.AddRule(CommonRules.StringRequired, "TenBoPhan");
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
            //TODO: Define authorization rules in BoPhanERPNew
            //AuthorizationRules.AllowRead("MaBoPhan", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhanQL", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("KhauHaoHaoMon", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhanCha", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("LaBoPhanMoRong", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("MappingID", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("TenTiengAnh", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("DienTich", "BoPhanERPNewReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "BoPhanERPNewReadGroup");

            //AuthorizationRules.AllowWrite("TenBoPhan", "BoPhanERPNewWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhanQL", "BoPhanERPNewWriteGroup");
            //AuthorizationRules.AllowWrite("KhauHaoHaoMon", "BoPhanERPNewWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhanCha", "BoPhanERPNewWriteGroup");
            //AuthorizationRules.AllowWrite("LaBoPhanMoRong", "BoPhanERPNewWriteGroup");
            //AuthorizationRules.AllowWrite("MappingID", "BoPhanERPNewWriteGroup");
            //AuthorizationRules.AllowWrite("TenTiengAnh", "BoPhanERPNewWriteGroup");
            //AuthorizationRules.AllowWrite("DienTich", "BoPhanERPNewWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "BoPhanERPNewWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BoPhanERPNew
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BoPhanERPNew
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BoPhanERPNew
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BoPhanERPNew
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BoPhanERPNewDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BoPhanERPNew()
        { /* require use of factory method */ }
        private BoPhanERPNew(string Ten)
        {
            this.TenBoPhan = Ten;
        }

        public static BoPhanERPNew NewBoPhanERPNew(string TenBoPhan)
        {
            return new BoPhanERPNew(TenBoPhan);
        }
        public static BoPhanERPNew NewBoPhanERPNew()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhanERPNew");
            return DataPortal.Create<BoPhanERPNew>();
        }

        public static BoPhanERPNew GetBoPhanERPNew(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanERPNew");
            return DataPortal.Fetch<BoPhanERPNew>(new Criteria(maBoPhan));
        }
       
        public static void DeleteBoPhanERPNew(int maBoPhan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BoPhanERPNew");
            DataPortal.Delete(new Criteria(maBoPhan));
        }

        public override BoPhanERPNew Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BoPhanERPNew");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BoPhanERPNew");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BoPhanERPNew");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        public static BoPhanERPNew NewBoPhanERPNewChild()
        {
            BoPhanERPNew child = new BoPhanERPNew();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BoPhanERPNew GetBoPhanERPNew(SafeDataReader dr)
        {
            BoPhanERPNew child = new BoPhanERPNew();
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
            public int MaBoPhan;

            public Criteria(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
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
                    cm.CommandText = "sp_SelecttblnsBoPhanERPNew";

                    cm.Parameters.AddWithValue("@MaBoPhan", ((Criteria)criteria).MaBoPhan);
                }
               
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
            DataPortal_Delete(new Criteria(_maBoPhan));
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
                cm.CommandText = "sp_tblBoPhanERPNew_Delete";

                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

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
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanCha = dr.GetInt32("MaBoPhanCha");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _maBoPhanQLCu = dr.GetString("MaBoPhanQLCu");
            _viTri = dr.GetString("ViTri");
            _maKhoiNhaCu = dr.GetString("MaKhoiNhaCu");
            _maKhoiNhaMoi = dr.GetString("MaKhoiNhaMoi");
            _maHoaPhongNhomHoaThat = dr.GetString("MaHoaPhongNhomHoaThat");
            _maPhongHKEdusoft = dr.GetString("MaPhongHKEdusoft");
            _dienGiai = dr.GetString("DienGiai");
            _tenTiengAnh = dr.GetString("TenTiengAnh");
            _maTinhChatPhong = dr.GetInt32("MaTinhChatPhong");
            _soChoNgoiTheoThucTe = dr.GetInt32("SoChoNgoiTheoThucTe");
            _soChoNgoiTheoThietKe = dr.GetInt32("SoChoNgoiTheoThietKe");
            _dienTich = dr.GetDecimal("DienTich");
            _donViSuDung = dr.GetString("DonViSuDung");
            _ghiChu = dr.GetString("GhiChu");
            _quyPhongXepTKB = dr.GetString("QuyPhongXepTKB");
            _khauHaoHaoMon = dr.GetBoolean("KhauHaoHaoMon");
            _laBoPhanMoRong = dr.GetBoolean("LaBoPhanMoRong");
            _mappingID = dr.GetInt32("MappingID");
            _soPhong = dr.GetString("SoPhong");
            _isNgungSuDung = dr.GetBoolean("IsNgungSuDung");
            _ngayNgungSuDung = dr.GetDateTime("NgayNgungSuDung");
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

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_tblBoPhanERPNew_Insert";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maBoPhan = (int)cm.Parameters["@NewMaBoPhan"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maBoPhanCha != 0)
                cm.Parameters.AddWithValue("@MaBoPhanCha", _maBoPhanCha);
            else
                cm.Parameters.AddWithValue("@MaBoPhanCha", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_maBoPhanQL.Length > 0)
                cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
            else
                cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
            if (_maBoPhanQLCu.Length > 0)
                cm.Parameters.AddWithValue("@MaBoPhanQLCu", _maBoPhanQLCu);
            else
                cm.Parameters.AddWithValue("@MaBoPhanQLCu", DBNull.Value);
            if (_viTri.Length > 0)
                cm.Parameters.AddWithValue("@ViTri", _viTri);
            else
                cm.Parameters.AddWithValue("@ViTri", DBNull.Value);
            if (_maKhoiNhaCu.Length > 0)
                cm.Parameters.AddWithValue("@MaKhoiNhaCu", _maKhoiNhaCu);
            else
                cm.Parameters.AddWithValue("@MaKhoiNhaCu", DBNull.Value);
            if (_maKhoiNhaMoi.Length > 0)
                cm.Parameters.AddWithValue("@MaKhoiNhaMoi", _maKhoiNhaMoi);
            else
                cm.Parameters.AddWithValue("@MaKhoiNhaMoi", DBNull.Value);
            if (_maHoaPhongNhomHoaThat.Length > 0)
                cm.Parameters.AddWithValue("@MaHoaPhongNhomHoaThat", _maHoaPhongNhomHoaThat);
            else
                cm.Parameters.AddWithValue("@MaHoaPhongNhomHoaThat", DBNull.Value);
            if (_maPhongHKEdusoft.Length > 0)
                cm.Parameters.AddWithValue("@MaPhongHKEdusoft", _maPhongHKEdusoft);
            else
                cm.Parameters.AddWithValue("@MaPhongHKEdusoft", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_tenTiengAnh.Length > 0)
                cm.Parameters.AddWithValue("@TenTiengAnh", _tenTiengAnh);
            else
                cm.Parameters.AddWithValue("@TenTiengAnh", DBNull.Value);
            if (_maTinhChatPhong != 0)
                cm.Parameters.AddWithValue("@MaTinhChatPhong", _maTinhChatPhong);
            else
                cm.Parameters.AddWithValue("@MaTinhChatPhong", DBNull.Value);
            if (_soChoNgoiTheoThucTe != 0)
                cm.Parameters.AddWithValue("@SoChoNgoiTheoThucTe", _soChoNgoiTheoThucTe);
            else
                cm.Parameters.AddWithValue("@SoChoNgoiTheoThucTe", DBNull.Value);
            if (_soChoNgoiTheoThietKe != 0)
                cm.Parameters.AddWithValue("@SoChoNgoiTheoThietKe", _soChoNgoiTheoThietKe);
            else
                cm.Parameters.AddWithValue("@SoChoNgoiTheoThietKe", DBNull.Value);
            if (_dienTich != 0)
                cm.Parameters.AddWithValue("@DienTich", _dienTich);
            else
                cm.Parameters.AddWithValue("@DienTich", DBNull.Value);
            if (_donViSuDung.Length > 0)
                cm.Parameters.AddWithValue("@DonViSuDung", _donViSuDung);
            else
                cm.Parameters.AddWithValue("@DonViSuDung", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_quyPhongXepTKB.Length > 0)
                cm.Parameters.AddWithValue("@QuyPhongXepTKB", _quyPhongXepTKB);
            else
                cm.Parameters.AddWithValue("@QuyPhongXepTKB", DBNull.Value);
            if (_khauHaoHaoMon != false)
                cm.Parameters.AddWithValue("@KhauHaoHaoMon", _khauHaoHaoMon);
            else
                cm.Parameters.AddWithValue("@KhauHaoHaoMon", DBNull.Value);
            if (_laBoPhanMoRong != false)
                cm.Parameters.AddWithValue("@LaBoPhanMoRong", _laBoPhanMoRong);
            else
                cm.Parameters.AddWithValue("@LaBoPhanMoRong", DBNull.Value);
            if (_mappingID != 0)
                cm.Parameters.AddWithValue("@MappingID", _mappingID);
            else
                cm.Parameters.AddWithValue("@MappingID", DBNull.Value);
            if (_soPhong.Length > 0)
                cm.Parameters.AddWithValue("@SoPhong", _soPhong);
            else
                cm.Parameters.AddWithValue("@SoPhong", DBNull.Value);
            if (_isNgungSuDung != false)
                cm.Parameters.AddWithValue("@IsNgungSuDung", _isNgungSuDung);
            else
                cm.Parameters.AddWithValue("@IsNgungSuDung", DBNull.Value);
            if (_ngayNgungSuDung != DateTime.MinValue    )
                cm.Parameters.AddWithValue("@NgayNgungSuDung", _ngayNgungSuDung);
            else
                cm.Parameters.AddWithValue("@NgayNgungSuDung", DBNull.Value);
            cm.Parameters.AddWithValue("@NewMaBoPhan", _maBoPhan);
            cm.Parameters["@NewMaBoPhan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "sp_tblBoPhanERPNew_Update";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            if (_maBoPhanCha != 0)
                cm.Parameters.AddWithValue("@MaBoPhanCha", _maBoPhanCha);
            else
                cm.Parameters.AddWithValue("@MaBoPhanCha", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_maBoPhanQL.Length > 0)
                cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
            else
                cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
            if (_maBoPhanQLCu.Length > 0)
                cm.Parameters.AddWithValue("@MaBoPhanQLCu", _maBoPhanQLCu);
            else
                cm.Parameters.AddWithValue("@MaBoPhanQLCu", DBNull.Value);
            if (_viTri.Length > 0)
                cm.Parameters.AddWithValue("@ViTri", _viTri);
            else
                cm.Parameters.AddWithValue("@ViTri", DBNull.Value);
            if (_maKhoiNhaCu.Length > 0)
                cm.Parameters.AddWithValue("@MaKhoiNhaCu", _maKhoiNhaCu);
            else
                cm.Parameters.AddWithValue("@MaKhoiNhaCu", DBNull.Value);
            if (_maKhoiNhaMoi.Length > 0)
                cm.Parameters.AddWithValue("@MaKhoiNhaMoi", _maKhoiNhaMoi);
            else
                cm.Parameters.AddWithValue("@MaKhoiNhaMoi", DBNull.Value);
            if (_maHoaPhongNhomHoaThat.Length > 0)
                cm.Parameters.AddWithValue("@MaHoaPhongNhomHoaThat", _maHoaPhongNhomHoaThat);
            else
                cm.Parameters.AddWithValue("@MaHoaPhongNhomHoaThat", DBNull.Value);
            if (_maPhongHKEdusoft.Length > 0)
                cm.Parameters.AddWithValue("@MaPhongHKEdusoft", _maPhongHKEdusoft);
            else
                cm.Parameters.AddWithValue("@MaPhongHKEdusoft", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_tenTiengAnh.Length > 0)
                cm.Parameters.AddWithValue("@TenTiengAnh", _tenTiengAnh);
            else
                cm.Parameters.AddWithValue("@TenTiengAnh", DBNull.Value);
            if (_maTinhChatPhong != 0)
                cm.Parameters.AddWithValue("@MaTinhChatPhong", _maTinhChatPhong);
            else
                cm.Parameters.AddWithValue("@MaTinhChatPhong", DBNull.Value);
            if (_soChoNgoiTheoThucTe != 0)
                cm.Parameters.AddWithValue("@SoChoNgoiTheoThucTe", _soChoNgoiTheoThucTe);
            else
                cm.Parameters.AddWithValue("@SoChoNgoiTheoThucTe", DBNull.Value);
            if (_soChoNgoiTheoThietKe != 0)
                cm.Parameters.AddWithValue("@SoChoNgoiTheoThietKe", _soChoNgoiTheoThietKe);
            else
                cm.Parameters.AddWithValue("@SoChoNgoiTheoThietKe", DBNull.Value);
            if (_dienTich != 0)
                cm.Parameters.AddWithValue("@DienTich", _dienTich);
            else
                cm.Parameters.AddWithValue("@DienTich", DBNull.Value);
            if (_donViSuDung.Length > 0)
                cm.Parameters.AddWithValue("@DonViSuDung", _donViSuDung);
            else
                cm.Parameters.AddWithValue("@DonViSuDung", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_quyPhongXepTKB.Length > 0)
                cm.Parameters.AddWithValue("@QuyPhongXepTKB", _quyPhongXepTKB);
            else
                cm.Parameters.AddWithValue("@QuyPhongXepTKB", DBNull.Value);
            if (_khauHaoHaoMon != false)
                cm.Parameters.AddWithValue("@KhauHaoHaoMon", _khauHaoHaoMon);
            else
                cm.Parameters.AddWithValue("@KhauHaoHaoMon", DBNull.Value);
            if (_laBoPhanMoRong != false)
                cm.Parameters.AddWithValue("@LaBoPhanMoRong", _laBoPhanMoRong);
            else
                cm.Parameters.AddWithValue("@LaBoPhanMoRong", DBNull.Value);
            if (_mappingID != 0)
                cm.Parameters.AddWithValue("@MappingID", _mappingID);
            else
                cm.Parameters.AddWithValue("@MappingID", DBNull.Value);
            if (_soPhong.Length > 0)
                cm.Parameters.AddWithValue("@SoPhong", _soPhong);
            else
                cm.Parameters.AddWithValue("@SoPhong", DBNull.Value);
            if (_isNgungSuDung != false)
                cm.Parameters.AddWithValue("@IsNgungSuDung", _isNgungSuDung);
            else
                cm.Parameters.AddWithValue("@IsNgungSuDung", DBNull.Value);
            if (_ngayNgungSuDung != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayNgungSuDung", _ngayNgungSuDung);
            else
                cm.Parameters.AddWithValue("@NgayNgungSuDung", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maBoPhan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
