
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DanhsachNVTheoBiaHoSo : Csla.BusinessBase<DanhsachNVTheoBiaHoSo>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenChucVu = string.Empty;
        private int _maChucVu = 0;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private DateTime _ngayVaoLam = DateTime.Today;
        private int _MaBiaHoSo = 0;
        private string _TenBiaHoSo = string.Empty;
        private bool _lyLich = false;
        private bool _donXinViec = false;
        private bool _khamSucKhoe = false;
        private bool _hoKhau = false;
        private bool _cmnd = false;
        private bool _vanBang = false;
        private bool _Giaytamtru = false;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("Maquanly", true);
                return _maQLNhanVien;
            }
            set
            {
                CanWriteProperty("Maquanly", true);
                if (value == null) value = string.Empty;
                if (!_maQLNhanVien.Equals(value))
                {
                    _maQLNhanVien = value;
                    PropertyHasChanged("Maquanly");
                }
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
            set
            {
                CanWriteProperty("TenNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                return _tenChucVu;
            }
            set
            {
                CanWriteProperty("TenChucVu", true);
                if (value == null) value = string.Empty;
                if (!_tenChucVu.Equals(value))
                {
                    _tenChucVu = value;
                    PropertyHasChanged("TenChucVu");
                }
            }
        }

        public string TenBiaHoSo
        {
            get
            {
                CanReadProperty( true);
                return _TenBiaHoSo;
            }           
        }

        public int MaChucVu
        {
            get
            {
                CanReadProperty("MaChucVu", true);
                return _maChucVu;
            }
            set
            {
                CanWriteProperty("MaChucVu", true);
                if (!_maChucVu.Equals(value))
                {
                    _maChucVu = value;
                    PropertyHasChanged("MaChucVu");
                }
            }
        }

        public int MaBiaHoSo
        {
            get
            {
                CanReadProperty("MaBiaHoSo", true);
                return _MaBiaHoSo;
            }
            set
            {
                CanWriteProperty("MaBiaHoSo", true);
                if (!_MaBiaHoSo.Equals(value))
                {
                    _MaBiaHoSo = value;
                    PropertyHasChanged("MaBiaHoSo");
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

        public DateTime NgayVaoLam
        {
            get
            {
                CanReadProperty("NgayVaoLam", true);
                return _ngayVaoLam.Date;
            }
            set
            {
                CanWriteProperty("NgayVaoLam", true);
                if (!_ngayVaoLam.Equals(value))
                {
                    _ngayVaoLam = value;
                    PropertyHasChanged("NgayVaoLam");
                }
            }
        }

        public bool LyLich
        {
            get
            {
                CanReadProperty( true);
                return _lyLich;
            }          
        }

        public bool DonXinViec
        {
            get
            {
                CanReadProperty( true);
                return _donXinViec;
            }          
        }

        public bool KhamSucKhoe
        {
            get
            {
                CanReadProperty( true);
                return _khamSucKhoe;
            }         
        }

        public bool HoKhau
        {
            get
            {
                CanReadProperty( true);
                return _hoKhau;
            }          
        }

        public bool Cmnd
        {
            get
            {
                CanReadProperty( true);
                return _cmnd;
            }           
        }

        public bool VanBang
        {
            get
            {
                CanReadProperty( true);
                return _vanBang;
            }          
        }
        public bool GiayTamTru
        {
            get
            {
                CanReadProperty( true);
                return _Giaytamtru;
            }
        }



        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
            //
            // TenChucVu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 500));
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

        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinNhanVienTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DanhsachNVTheoBiaHoSo()
        { /* require use of factory method */ }

        public static DanhsachNVTheoBiaHoSo NewDanhsachNVTheoBiaHoSo(long maNhanVien)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHop");
            return DataPortal.Create<DanhsachNVTheoBiaHoSo>(new Criteria(maNhanVien));
        }

        public static DanhsachNVTheoBiaHoSo GetDanhsachNVTheoBiaHoSo(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHop");
            return DataPortal.Fetch<DanhsachNVTheoBiaHoSo>(new Criteria(maNhanVien));
        }
        public override DanhsachNVTheoBiaHoSo Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinNhanVienTongHop");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHop");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThongTinNhanVienTongHop");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private DanhsachNVTheoBiaHoSo(long maNhanVien)
        {
            this._maNhanVien = maNhanVien;
        }

        internal static DanhsachNVTheoBiaHoSo NewDanhsachNVTheoBiaHoSoChild(long maNhanVien)
        {
            DanhsachNVTheoBiaHoSo child = new DanhsachNVTheoBiaHoSo(maNhanVien);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DanhsachNVTheoBiaHoSo GetDanhsachNVTheoBiaHoSo(SafeDataReader dr)
        {
            DanhsachNVTheoBiaHoSo child = new DanhsachNVTheoBiaHoSo();
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
            public long MaNhanVien;

            public Criteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _maNhanVien = criteria.MaNhanVien;
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
                cm.CommandText = "spd_ThongTinNhanVien";

                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maQLNhanVien = dr.GetString("Maquanly");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _tenChucVu = dr.GetString("TenChucVu");
                _maChucVu = dr.GetInt32("MaChucVu");
                _ngayVaoLam = dr.GetDateTime("NgayVaoLam");
                _MaBiaHoSo = dr.GetInt32("MaBiaHoSo");
               // _TenBiaHoSo = BiaHoSo.GetBiaHoSo(_MaBiaHoSo).TenBiaHoSo;
                _lyLich = dr.GetBoolean("LyLich");
                _hoKhau=dr.GetBoolean("HoKhau");
                _cmnd=dr.GetBoolean("CMND");
                _donXinViec = dr.GetBoolean("DonXinViec");
                _khamSucKhoe = dr.GetBoolean("KhamSucKhoe");
                _vanBang = dr.GetBoolean("VanBang");
                _Giaytamtru = dr.GetBoolean("GiayTamTru");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {

        }
        #endregion //Data Access - Fetch

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
                cm.CommandText = "spd_UpdatetblnsThongTinCongTyByMaBiaHS";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBiaHoSo", _MaBiaHoSo);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
           
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #endregion //Data Access
    }
}
