using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//a long
namespace ERP_Library
{
    [Serializable()]

    public class HeThongTaiKhoan1 : Csla.BusinessBase<HeThongTaiKhoan1>
    {
        #region Business Properties and Methods

        //declare members
        private int _maTaiKhoan = 0;
        private string _soHieuTK = string.Empty;
        private string _tenTaiKhoan = string.Empty;
        private int _maTaiKhoanCha = 0;
        private bool _coDoiTuongTheoDoi = false;
        private bool _loaiSoDuCo = false;
        private bool _loaiSoDuNo = false;
        private decimal _soDuNoDauNam = 0;
        private decimal _soDuCoDauNam = 0;
        private int _maLoaiTaiKhoan = 0;
        private byte _capTaiKhoan = 0;
        private bool _chon = false;
        private int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private bool _dungChung = true;
        private bool _CoTheoDoiKhoanMucChiPhi=false;
        private bool _CoDonViTheoDoi = false;
        private bool _ngungSuDung = false;
        private SmartDate _NgayADKhongSuDung = new SmartDate(DateTime.MinValue);
       

        public bool Chon
        {
            get { return _chon; }
            set { _chon = value; }
        }


        [System.ComponentModel.DataObjectField(true, true)]
        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
        }
        public int MaCongTy
        {
            get { return _maCongTy; }
            set { _maCongTy = value;
            PropertyHasChanged("MaCongTy");
            }
        }


        public bool DungChung
        {
            get { return _dungChung; }
            set { _dungChung = value;
            PropertyHasChanged("DungChung");
            }
        }
        public string SoHieuTK
        {
            get
            {
                CanReadProperty("SoHieuTK", true);
                return _soHieuTK;
            }
            set
            {
                CanWriteProperty("SoHieuTK", true);
                if (value == null) value = string.Empty;
                if (!_soHieuTK.Equals(value))
                {
                    _soHieuTK = value;
                    PropertyHasChanged("SoHieuTK");
                }
            }
        }

        public DateTime? NgayADKhongSuDung
        {
            get
            {
                CanReadProperty("NgayADKhongSuDung", true);
                if (_NgayADKhongSuDung.Date == DateTime.MinValue)
                    return null;
                return _NgayADKhongSuDung.Date;
            }
            set
            {
                CanWriteProperty("NgayADKhongSuDung", true);
                if (!_NgayADKhongSuDung.Equals(value))
                {
                    if (value == null)
                        _NgayADKhongSuDung = new SmartDate(DateTime.MinValue);
                    else
                        _NgayADKhongSuDung = new SmartDate(value.Value.Date);

                    PropertyHasChanged();
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

        public string TenTaiKhoan
        {
            get
            {
                CanReadProperty("TenTaiKhoan", true);
                return _tenTaiKhoan;
            }
            set
            {
                CanWriteProperty("TenTaiKhoan", true);
                if (value == null) value = string.Empty;
                if (!_tenTaiKhoan.Equals(value))
                {
                    _tenTaiKhoan = value;
                    PropertyHasChanged("TenTaiKhoan");
                }
            }
        }

        public int MaTaiKhoanCha
        {
            get
            {
                CanReadProperty("MaTaiKhoanCha", true);
                return _maTaiKhoanCha;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanCha", true);
                if (!_maTaiKhoanCha.Equals(value))
                {
                    _maTaiKhoanCha = value;
                    PropertyHasChanged("MaTaiKhoanCha");
                }
            }
        }

        public bool CoDoiTuongTheoDoi
        {
            get
            {
                CanReadProperty("CoDoiTuongTheoDoi", true);
                return _coDoiTuongTheoDoi;
            }
            set
            {
                CanWriteProperty("CoDoiTuongTheoDoi", true);
                if (!_coDoiTuongTheoDoi.Equals(value))
                {
                    _coDoiTuongTheoDoi = value;
                    PropertyHasChanged("CoDoiTuongTheoDoi");
                }
            }
        }

        public bool CoTheoDoiKhoanMucChiPhi
        {
            get
            {
                CanReadProperty("CoTheoDoiKhoanMucChiPhi", true);
                return _CoTheoDoiKhoanMucChiPhi;
            }
            set
            {
                CanWriteProperty("CoTheoDoiKhoanMucChiPhi", true);
                if (!_CoTheoDoiKhoanMucChiPhi.Equals(value))
                {
                    _CoTheoDoiKhoanMucChiPhi = value;
                    PropertyHasChanged("CoTheoDoiKhoanMucChiPhi");
                }
            }
        }

        public bool CoDonViTheoDoi
        {
            get
            {
                CanReadProperty("CoDonViTheoDoi", true);
                return _CoDonViTheoDoi;
            }
            set
            {
                CanWriteProperty("CoDonViTheoDoi", true);
                if (!_CoDonViTheoDoi.Equals(value))
                {
                    _CoDonViTheoDoi = value;
                    PropertyHasChanged("CoDonViTheoDoi");
                }
            }
        }

        public bool LoaiSoDuCo
        {
            get
            {
                CanReadProperty("LoaiSoDuCo", true);
                return _loaiSoDuCo;
            }
            set
            {
                CanWriteProperty("LoaiSoDuCo", true);
                if (!_loaiSoDuCo.Equals(value))
                {
                    _loaiSoDuCo = value;
                    PropertyHasChanged("LoaiSoDuCo");
                }
            }
        }

        public bool LoaiSoDuNo
        {
            get
            {
                CanReadProperty("LoaiSoDuNo", true);
                return _loaiSoDuNo;
            }
            set
            {
                CanWriteProperty("LoaiSoDuNo", true);
                if (!_loaiSoDuNo.Equals(value))
                {
                    _loaiSoDuNo = value;
                    PropertyHasChanged("LoaiSoDuNo");
                }
            }
        }

        public decimal SoDuNoDauNam
        {
            get
            {
                CanReadProperty("SoDuNoDauNam", true);
                return _soDuNoDauNam;
            }
            set
            {
                CanWriteProperty("SoDuNoDauNam", true);
                if (!_soDuNoDauNam.Equals(value))
                {
                    _soDuNoDauNam = value;
                    PropertyHasChanged("SoDuNoDauNam");
                }
            }
        }

        public decimal SoDuCoDauNam
        {
            get
            {
                CanReadProperty("SoDuCoDauNam", true);
                return _soDuCoDauNam;
            }
            set
            {
                CanWriteProperty("SoDuCoDauNam", true);
                if (!_soDuCoDauNam.Equals(value))
                {
                    _soDuCoDauNam = value;
                    PropertyHasChanged("SoDuCoDauNam");
                }
            }
        }

        public int MaLoaiTaiKhoan
        {
            get
            {
                CanReadProperty("MaLoaiTaiKhoan", true);
                return _maLoaiTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaLoaiTaiKhoan", true);
                if (!_maLoaiTaiKhoan.Equals(value))
                {
                    _maLoaiTaiKhoan = value;
                    PropertyHasChanged("MaLoaiTaiKhoan");
                }
            }
        }

        public byte CapTaiKhoan
        {
            get
            {
                CanReadProperty("CapTaiKhoan", true);
                return _capTaiKhoan;
            }
            set
            {
                CanWriteProperty("CapTaiKhoan", true);
                if (!_capTaiKhoan.Equals(value))
                {
                    _capTaiKhoan = value;
                    PropertyHasChanged("CapTaiKhoan");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maTaiKhoan;
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
            // SoHieuTK
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "SoHieuTK");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTK", 50));
            //
            // TenTaiKhoan
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenTaiKhoan");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTaiKhoan", 4000));
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
            //TODO: Define authorization rules in HeThongTaiKhoan1
            //AuthorizationRules.AllowRead("MaTaiKhoan", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("SoHieuTK", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("TenTaiKhoan", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoanCha", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("CoDoiTuongTheoDoi", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("LoaiSoDuCo", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("LoaiSoDuNo", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("SoDuNoDauNam", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("SoDuCoDauNam", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiTaiKhoan", "HeThongTaiKhoan1ReadGroup");
            //AuthorizationRules.AllowRead("CapTaiKhoan", "HeThongTaiKhoan1ReadGroup");

            //AuthorizationRules.AllowWrite("SoHieuTK", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("TenTaiKhoan", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoanCha", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("CoDoiTuongTheoDoi", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("LoaiSoDuCo", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("LoaiSoDuNo", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("SoDuNoDauNam", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("SoDuCoDauNam", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiTaiKhoan", "HeThongTaiKhoan1WriteGroup");
            //AuthorizationRules.AllowWrite("CapTaiKhoan", "HeThongTaiKhoan1WriteGroup");
        }

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HeThongTaiKhoan1
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HeThongTaiKhoan1ViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HeThongTaiKhoan1
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HeThongTaiKhoan1AddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HeThongTaiKhoan1
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HeThongTaiKhoan1EditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HeThongTaiKhoan1
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HeThongTaiKhoan1DeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HeThongTaiKhoan1()
        { /* require use of factory method */ }

        private HeThongTaiKhoan1(string soHieuTK)
        { /* require use of factory method */
            this._soHieuTK = soHieuTK;
        }

        public static HeThongTaiKhoan1 NewHeThongTaiKhoan1()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HeThongTaiKhoan1");
            return DataPortal.Create<HeThongTaiKhoan1>();
        }

        public static HeThongTaiKhoan1 NewHeThongTaiKhoan1(string soHieuTK)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HeThongTaiKhoan1");
            return new HeThongTaiKhoan1(soHieuTK);
        }

        public static HeThongTaiKhoan1 NewHeThongTaiKhoan1(String soHieuTK, Boolean doiTuong, Boolean loaiSoDuco, Boolean loaiSoDuNo, int loaiTK, Decimal soDuDauNamNo, Decimal SoDuDauNamCo, String tenTaiKhoan, String taiKhoanCha, byte capTaiKhoan)
        {
            HeThongTaiKhoan1 taiKhoan = new HeThongTaiKhoan1();
            taiKhoan._soHieuTK = String.Empty;
            taiKhoan._coDoiTuongTheoDoi = false;
            taiKhoan._CoTheoDoiKhoanMucChiPhi = false;
            taiKhoan._CoDonViTheoDoi = false;
            taiKhoan._loaiSoDuCo = false;
            taiKhoan._loaiSoDuNo = false;
            taiKhoan._maLoaiTaiKhoan = 0;
            taiKhoan._soDuCoDauNam = 0;
            taiKhoan._soDuNoDauNam = 0;
            taiKhoan._maTaiKhoanCha = 0;
            taiKhoan._tenTaiKhoan = String.Empty;
            taiKhoan.CapTaiKhoan = 0;
            taiKhoan.MarkDirty();
            taiKhoan.ValidationRules.CheckRules();
            return taiKhoan;
        }

        public static HeThongTaiKhoan1 GetHeThongTaiKhoan1()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1");
            return DataPortal.Fetch<HeThongTaiKhoan1>(new CriteriaAll());
        }

        public static HeThongTaiKhoan1 GetHeThongTaiKhoan1(int maTaiKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1");
            return DataPortal.Fetch<HeThongTaiKhoan1>(new Criteria(maTaiKhoan));
        }

       
        public static void DeleteHeThongTaiKhoan1(int maTaiKhoan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HeThongTaiKhoan1");
            DataPortal.Delete(new Criteria(maTaiKhoan));
        }

        public static int LayMaTaiKhoan(string soHieuTK)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LayMaTaiKhoan";
                        cm.Parameters.AddWithValue("@SoHieuTK", soHieuTK);
                        cm.Parameters.AddWithValue("@MaTaiKhoan", gt);
                        cm.Parameters["@MaTaiKhoan"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@MaTaiKhoan"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }

        public override HeThongTaiKhoan1 Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HeThongTaiKhoan1");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HeThongTaiKhoan1");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HeThongTaiKhoan1");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HeThongTaiKhoan1 NewHeThongTaiKhoan1Child()
        {
            HeThongTaiKhoan1 child = new HeThongTaiKhoan1();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static HeThongTaiKhoan1 GetHeThongTaiKhoan1(SafeDataReader dr)
        {
            HeThongTaiKhoan1 child = new HeThongTaiKhoan1();
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
            public int MaTaiKhoan;

            public Criteria(int maTaiKhoan)
            {
                this.MaTaiKhoan = maTaiKhoan;
            }
        }
    
        private class CriteriaAll
        {


            public CriteriaAll()
            {
                
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
                if (criteria is Criteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTaiKhoan";
                    cm.Parameters.AddWithValue("@MaTaiKhoan",  ((Criteria)criteria).MaTaiKhoan );
                }
             
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        //ValidationRules.CheckRules();

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
            DataPortal_Delete(new Criteria(_maTaiKhoan));
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
                cm.CommandText = "spd_DeletetblTaiKhoan";

                cm.Parameters.AddWithValue("@MaTaiKhoan", criteria.MaTaiKhoan);

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
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _soHieuTK = dr.GetString("SoHieuTK");
            _tenTaiKhoan = dr.GetString("TenTaiKhoan");
            _maTaiKhoanCha = dr.GetInt32("MaTaiKhoanCha");
            _coDoiTuongTheoDoi = dr.GetBoolean("CoDoiTuongTheoDoi");
            _CoTheoDoiKhoanMucChiPhi = dr.GetBoolean("CoTheoDoiKhoanMucChiPhi");
            _CoDonViTheoDoi = dr.GetBoolean("CoDonViTheoDoi");
            _loaiSoDuCo = dr.GetBoolean("LoaiSoDuCo");
            _loaiSoDuNo = dr.GetBoolean("LoaiSoDuNo");
            _soDuNoDauNam = dr.GetDecimal("SoDuNoDauNam");
            _soDuCoDauNam = dr.GetDecimal("SoDuCoDauNam");
            _maLoaiTaiKhoan = dr.GetInt32("MaLoaiTaiKhoan");
            _capTaiKhoan = dr.GetByte("CapTaiKhoan");
            _maCongTy = dr.GetInt32("MaCongTy");
            _dungChung = dr.GetBoolean("DungChung");
            _ngungSuDung = dr.GetBoolean("NgungSuDung");
            _NgayADKhongSuDung = dr.GetSmartDate("NgayADKhongSuDung",_NgayADKhongSuDung.EmptyIsMin);
            _chon = false;
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
                //cm.CommandText = "spd_InserttblTaiKhoan";
                cm.CommandText = "spd_InserttblTaiKhoan_1";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maTaiKhoan = (int)cm.Parameters["@MaTaiKhoan"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
            cm.Parameters.AddWithValue("@TenTaiKhoan", _tenTaiKhoan);
            if (_maTaiKhoanCha != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanCha", _maTaiKhoanCha);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanCha", DBNull.Value);
            if (_coDoiTuongTheoDoi != false)
                cm.Parameters.AddWithValue("@CoDoiTuongTheoDoi", _coDoiTuongTheoDoi);
            else
                cm.Parameters.AddWithValue("@CoDoiTuongTheoDoi", DBNull.Value);
            if (_CoTheoDoiKhoanMucChiPhi != false)
                cm.Parameters.AddWithValue("@CoTheoDoiKhoanMucChiPhi", _CoTheoDoiKhoanMucChiPhi);
            else
                cm.Parameters.AddWithValue("@CoTheoDoiKhoanMucChiPhi", DBNull.Value);

            if (_CoDonViTheoDoi != false)
                cm.Parameters.AddWithValue("@CoDonViTheoDoi", _CoDonViTheoDoi);
            else
                cm.Parameters.AddWithValue("@CoDonViTheoDoi", DBNull.Value);

            if (_loaiSoDuCo != false)
                cm.Parameters.AddWithValue("@LoaiSoDuCo", _loaiSoDuCo);
            else
                cm.Parameters.AddWithValue("@LoaiSoDuCo", DBNull.Value);
            if (_loaiSoDuNo != false)
                cm.Parameters.AddWithValue("@LoaiSoDuNo", _loaiSoDuNo);
            else
                cm.Parameters.AddWithValue("@LoaiSoDuNo", DBNull.Value);
            if (_soDuNoDauNam != 0)
                cm.Parameters.AddWithValue("@SoDuNoDauNam", _soDuNoDauNam);
            else
                cm.Parameters.AddWithValue("@SoDuNoDauNam", DBNull.Value);
            if (_soDuCoDauNam != 0)
                cm.Parameters.AddWithValue("@SoDuCoDauNam", _soDuCoDauNam);
            else
                cm.Parameters.AddWithValue("@SoDuCoDauNam", DBNull.Value);
            if (_maLoaiTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaLoaiTaiKhoan", _maLoaiTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaLoaiTaiKhoan", DBNull.Value);
            if (_capTaiKhoan != 0)
                cm.Parameters.AddWithValue("@CapTaiKhoan", _capTaiKhoan);
            else
                cm.Parameters.AddWithValue("@CapTaiKhoan", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            cm.Parameters.AddWithValue("@DungChung", _dungChung);
            cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            cm.Parameters.AddWithValue("@NgayADKhongSuDung", _NgayADKhongSuDung.DBValue);
            cm.Parameters["@MaTaiKhoan"].Direction = ParameterDirection.Output;
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
                //cm.CommandText = "spd_UpdatetblTaiKhoan";
                cm.CommandText = "spd_UpdatetblTaiKhoan_1";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }
        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
            cm.Parameters.AddWithValue("@TenTaiKhoan", _tenTaiKhoan);
            if (_maTaiKhoanCha != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanCha", _maTaiKhoanCha);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanCha", DBNull.Value);
            if (_coDoiTuongTheoDoi != false)
                cm.Parameters.AddWithValue("@CoDoiTuongTheoDoi", _coDoiTuongTheoDoi);
            else
                cm.Parameters.AddWithValue("@CoDoiTuongTheoDoi", DBNull.Value);
            if (_CoTheoDoiKhoanMucChiPhi != false)
                cm.Parameters.AddWithValue("@CoTheoDoiKhoanMucChiPhi", _CoTheoDoiKhoanMucChiPhi);
            else
                cm.Parameters.AddWithValue("@CoTheoDoiKhoanMucChiPhi", DBNull.Value);
            if (_CoDonViTheoDoi != false)
                cm.Parameters.AddWithValue("@CoDonViTheoDoi", _CoDonViTheoDoi);
            else
                cm.Parameters.AddWithValue("@CoDonViTheoDoi", DBNull.Value);

            if (_loaiSoDuCo != false)
                cm.Parameters.AddWithValue("@LoaiSoDuCo", _loaiSoDuCo);
            else
                cm.Parameters.AddWithValue("@LoaiSoDuCo", DBNull.Value);
            if (_loaiSoDuNo != false)
                cm.Parameters.AddWithValue("@LoaiSoDuNo", _loaiSoDuNo);



            else
                cm.Parameters.AddWithValue("@LoaiSoDuNo", DBNull.Value);
            if (_soDuNoDauNam != 0)
                cm.Parameters.AddWithValue("@SoDuNoDauNam", _soDuNoDauNam);
            else
                cm.Parameters.AddWithValue("@SoDuNoDauNam", DBNull.Value);
            if (_soDuCoDauNam != 0)
                cm.Parameters.AddWithValue("@SoDuCoDauNam", _soDuCoDauNam);
            else
                cm.Parameters.AddWithValue("@SoDuCoDauNam", DBNull.Value);
            if (_maLoaiTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaLoaiTaiKhoan", _maLoaiTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaLoaiTaiKhoan", DBNull.Value);
            if (_capTaiKhoan != 0)
                cm.Parameters.AddWithValue("@CapTaiKhoan", _capTaiKhoan);
            else
                cm.Parameters.AddWithValue("@CapTaiKhoan", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            cm.Parameters.AddWithValue("@DungChung", _dungChung);
            cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            cm.Parameters.AddWithValue("@NgayADKhongSuDung", _NgayADKhongSuDung.DBValue);
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

            ExecuteDelete(cn, new Criteria(_maTaiKhoan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

       
    }
}
