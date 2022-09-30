
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class HopDongLaoDong_DieuKhoan : Csla.BusinessBase<HopDongLaoDong_DieuKhoan>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private string _thoiGiamLamViec = string.Empty;
        private string _phuongTinDiLai = string.Empty;
        private string _hinhThucTraLuong = string.Empty;
        private string _mucLuongTienCong = string.Empty;
        private string _dungCulamViec = string.Empty;
        private string _cheDoDaoTao = string.Empty;
        private string _Dieukhoankhac = string.Empty;
        private string _NguoiKy = string.Empty;
        private string _ChucVu = string.Empty;
        private string _QuocTich = string.Empty;
        private string _DienThoai = string.Empty;
        private double _loai = 0;
        private string _phuCap = string.Empty;
        private SmartDate _ngayTraLuong = new SmartDate(false);
        private string _tienThuong = string.Empty;
        private string _cheDoNangLuong = string.Empty;
        private string _bhxhBhyt = string.Empty;
        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public string ThoiGiamLamViec
        {
            get
            {
                CanReadProperty("ThoiGiamLamViec", true);
                return _thoiGiamLamViec;
            }
            set
            {
                CanWriteProperty("ThoiGiamLamViec", true);
                if (value == null) value = string.Empty;
                if (!_thoiGiamLamViec.Equals(value))
                {
                    _thoiGiamLamViec = value;
                    PropertyHasChanged("ThoiGiamLamViec");
                }
            }
        }

        public string PhuongTinDiLai
        {
            get
            {
                CanReadProperty("PhuongTinDiLai", true);
                return _phuongTinDiLai;
            }
            set
            {
                CanWriteProperty("PhuongTinDiLai", true);
                if (value == null) value = string.Empty;
                if (!_phuongTinDiLai.Equals(value))
                {
                    _phuongTinDiLai = value;
                    PropertyHasChanged("PhuongTinDiLai");
                }
            }
        }

        public string DieuKhoanKhac
        {
            get
            {
                CanReadProperty("Dieukhoankhac", true);
                return _Dieukhoankhac;
            }
            set
            {
                CanWriteProperty("Dieukhoankhac", true);
                if (value == null) value = string.Empty;
                if (!_Dieukhoankhac.Equals(value))
                {
                    _Dieukhoankhac = value;
                    PropertyHasChanged("Dieukhoankhac");
                }
            }
        }

        public string HinhThucTraLuong
        {
            get
            {
                CanReadProperty("HinhThucTraLuong", true);
                return _hinhThucTraLuong;
            }
            set
            {
                CanWriteProperty("HinhThucTraLuong", true);
                if (value == null) value = string.Empty;
                if (!_hinhThucTraLuong.Equals(value))
                {
                    _hinhThucTraLuong = value;
                    PropertyHasChanged("HinhThucTraLuong");
                }
            }
        }

        public string MucLuongTienCong
        {
            get
            {
                CanReadProperty("MucLuongTienCong", true);
                return _mucLuongTienCong;
            }
            set
            {
                CanWriteProperty("MucLuongTienCong", true);
                if (value == null) value = string.Empty;
                if (!_mucLuongTienCong.Equals(value))
                {
                    _mucLuongTienCong = value;
                    PropertyHasChanged("MucLuongTienCong");
                }
            }
        }

        public string DungCulamViec
        {
            get
            {
                CanReadProperty("DungCulamViec", true);
                return _dungCulamViec;
            }
            set
            {
                CanWriteProperty("DungCulamViec", true);
                if (value == null) value = string.Empty;
                if (!_dungCulamViec.Equals(value))
                {
                    _dungCulamViec = value;
                    PropertyHasChanged("DungCulamViec");
                }
            }
        }
        public string DienThoai
        {
            get
            {
                CanReadProperty("DienThoai", true);
                return _DienThoai;
            }
            set
            {
                CanWriteProperty("DienThoai", true);
                if (value == null) value = string.Empty;
                if (!_DienThoai.Equals(value))
                {
                    _DienThoai = value;
                    PropertyHasChanged("DienThoai");
                }
            }
        }

        public string CheDoDaoTao
        {
            get
            {
                CanReadProperty("CheDoDaoTao", true);
                return _cheDoDaoTao;
            }
            set
            {
                CanWriteProperty("CheDoDaoTao", true);
                if (value == null) value = string.Empty;
                if (!_cheDoDaoTao.Equals(value))
                {
                    _cheDoDaoTao = value;
                    PropertyHasChanged("CheDoDaoTao");
                }
            }
        }

        public string NguoiKy
        {
            get
            {
                CanReadProperty("NguoiKy", true);
                return _NguoiKy;
            }
            set
            {
                CanWriteProperty("NguoiKy", true);
                if (value == null) value = string.Empty;
                if (!_NguoiKy.Equals(value))
                {
                    _NguoiKy = value;
                    PropertyHasChanged("NguoiKy");
                }
            }
        }

        public string ChucVu
        {
            get
            {
                CanReadProperty("ChucVu", true);
                return _ChucVu;
            }
            set
            {
                CanWriteProperty("ChucVu", true);
                if (value == null) value = string.Empty;
                if (!_ChucVu.Equals(value))
                {
                    _ChucVu = value;
                    PropertyHasChanged("ChucVu");
                }
            }
        }

        public string QuocTich
        {
            get
            {
                CanReadProperty("QuocTich", true);
                return _QuocTich;
            }
            set
            {
                CanWriteProperty("QuocTich", true);
                if (value == null) value = string.Empty;
                if (!_QuocTich.Equals(value))
                {
                    _QuocTich = value;
                    PropertyHasChanged("QuocTich");
                }
            }
        }
        public double Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                CanWriteProperty("Loai", true);
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
                }
            }
        }

        public string PhuCap
        {
            get
            {
                CanReadProperty("PhuCap", true);
                return _phuCap;
            }
            set
            {
                CanWriteProperty("PhuCap", true);
                if (value == null) value = string.Empty;
                if (!_phuCap.Equals(value))
                {
                    _phuCap = value;
                    PropertyHasChanged("PhuCap");
                }
            }
        }

        public DateTime NgayTraLuong
        {
            get
            {
                CanReadProperty("NgayTraLuong", true);
                return _ngayTraLuong.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayTraLuong.Equals(value))
                {
                    _ngayTraLuong = new SmartDate(value);
                    PropertyHasChanged("NgayTraLuong");
                }
            }
        }

   

        public string TienThuong
        {
            get
            {
                CanReadProperty("TienThuong", true);
                return _tienThuong;
            }
            set
            {
                CanWriteProperty("TienThuong", true);
                if (value == null) value = string.Empty;
                if (!_tienThuong.Equals(value))
                {
                    _tienThuong = value;
                    PropertyHasChanged("TienThuong");
                }
            }
        }

        public string CheDoNangLuong
        {
            get
            {
                CanReadProperty("CheDoNangLuong", true);
                return _cheDoNangLuong;
            }
            set
            {
                CanWriteProperty("CheDoNangLuong", true);
                if (value == null) value = string.Empty;
                if (!_cheDoNangLuong.Equals(value))
                {
                    _cheDoNangLuong = value;
                    PropertyHasChanged("CheDoNangLuong");
                }
            }
        }

        public string BhxhBhyt
        {
            get
            {
                CanReadProperty("BhxhBhyt", true);
                return _bhxhBhyt;
            }
            set
            {
                CanWriteProperty("BhxhBhyt", true);
                if (value == null) value = string.Empty;
                if (!_bhxhBhyt.Equals(value))
                {
                    _bhxhBhyt = value;
                    PropertyHasChanged("BhxhBhyt");
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
            // ThoiGiamLamViec
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThoiGiamLamViec", 4000));
            //
            // PhuongTinDiLai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("PhuongTinDiLai", 4000));
            //
            // HinhThucTraLuong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("HinhThucTraLuong", 4000));
            //
            // MucLuongTienCong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MucLuongTienCong", 4000));
            //
            // DungCulamViec
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DungCulamViec", 4000));
            //
            // CheDoDaoTao
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CheDoDaoTao", 4000));
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
            //TODO: Define authorization rules in HopDongLaoDong_DieuKhoan
            //AuthorizationRules.AllowRead("Id", "HopDongLaoDong_DieuKhoanReadGroup");
            //AuthorizationRules.AllowRead("ThoiGiamLamViec", "HopDongLaoDong_DieuKhoanReadGroup");
            //AuthorizationRules.AllowRead("PhuongTinDiLai", "HopDongLaoDong_DieuKhoanReadGroup");
            //AuthorizationRules.AllowRead("HinhThucTraLuong", "HopDongLaoDong_DieuKhoanReadGroup");
            //AuthorizationRules.AllowRead("MucLuongTienCong", "HopDongLaoDong_DieuKhoanReadGroup");
            //AuthorizationRules.AllowRead("DungCulamViec", "HopDongLaoDong_DieuKhoanReadGroup");
            //AuthorizationRules.AllowRead("CheDoDaoTao", "HopDongLaoDong_DieuKhoanReadGroup");

            //AuthorizationRules.AllowWrite("ThoiGiamLamViec", "HopDongLaoDong_DieuKhoanWriteGroup");
            //AuthorizationRules.AllowWrite("PhuongTinDiLai", "HopDongLaoDong_DieuKhoanWriteGroup");
            //AuthorizationRules.AllowWrite("HinhThucTraLuong", "HopDongLaoDong_DieuKhoanWriteGroup");
            //AuthorizationRules.AllowWrite("MucLuongTienCong", "HopDongLaoDong_DieuKhoanWriteGroup");
            //AuthorizationRules.AllowWrite("DungCulamViec", "HopDongLaoDong_DieuKhoanWriteGroup");
            //AuthorizationRules.AllowWrite("CheDoDaoTao", "HopDongLaoDong_DieuKhoanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HopDongLaoDong_DieuKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongLaoDong_DieuKhoanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HopDongLaoDong_DieuKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongLaoDong_DieuKhoanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HopDongLaoDong_DieuKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongLaoDong_DieuKhoanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HopDongLaoDong_DieuKhoan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongLaoDong_DieuKhoanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HopDongLaoDong_DieuKhoan()
        { /* require use of factory method */ }

        public static HopDongLaoDong_DieuKhoan NewHopDongLaoDong_DieuKhoan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HopDongLaoDong_DieuKhoan");
            return DataPortal.Create<HopDongLaoDong_DieuKhoan>();
        }

        public static HopDongLaoDong_DieuKhoan GetHopDongLaoDong_DieuKhoan(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongLaoDong_DieuKhoan");
            return DataPortal.Fetch<HopDongLaoDong_DieuKhoan>(new Criteria(id));
        }

        public static void DeleteHopDongLaoDong_DieuKhoan(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HopDongLaoDong_DieuKhoan");
            DataPortal.Delete(new Criteria(id));
        }

        public override HopDongLaoDong_DieuKhoan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HopDongLaoDong_DieuKhoan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HopDongLaoDong_DieuKhoan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HopDongLaoDong_DieuKhoan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HopDongLaoDong_DieuKhoan NewHopDongLaoDong_DieuKhoanChild()
        {
            HopDongLaoDong_DieuKhoan child = new HopDongLaoDong_DieuKhoan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static HopDongLaoDong_DieuKhoan GetHopDongLaoDong_DieuKhoan(SafeDataReader dr)
        {
            HopDongLaoDong_DieuKhoan child = new HopDongLaoDong_DieuKhoan();
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

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsHopDongLaoDong_DieuKhoan";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "spd_DeletetblsHopDongLaoDong_DieuKhoan";

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
            _thoiGiamLamViec = dr.GetString("ThoiGiamLamViec");
            _phuongTinDiLai = dr.GetString("PhuongTinDiLai");
            _hinhThucTraLuong = dr.GetString("HinhThucTraLuong");
            _mucLuongTienCong = dr.GetString("MucLuongTienCong");
            _Dieukhoankhac = dr.GetString("DieuKhoanKhac");
            _dungCulamViec = dr.GetString("DungCulamViec");
            _cheDoDaoTao = dr.GetString("CheDoDaoTao");

            _NguoiKy = dr.GetString("NguoiKy");
            _ChucVu = dr.GetString("Chucvu");
            _QuocTich = dr.GetString("QuocTich");
            _DienThoai = dr.GetString("DienThoai");
            _loai = dr.GetDouble("Loai");
            _phuCap = dr.GetString("PhuCap");
            _ngayTraLuong = dr.GetSmartDate("NgayTraLuong", _ngayTraLuong.EmptyIsMin);
            _tienThuong = dr.GetString("TienThuong");
            _cheDoNangLuong = dr.GetString("CheDoNangLuong");
            _bhxhBhyt = dr.GetString("BHXH_BHYT");
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
                cm.CommandText = "spd_InserttblnsHopDongLaoDong_DieuKhoan";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {

            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@ID", _id);
            if (_thoiGiamLamViec.Length > 0)
                cm.Parameters.AddWithValue("@ThoiGiamLamViec", _thoiGiamLamViec);
            else
                cm.Parameters.AddWithValue("@ThoiGiamLamViec", DBNull.Value);
            if (_phuongTinDiLai.Length > 0)
                cm.Parameters.AddWithValue("@PhuongTinDiLai", _phuongTinDiLai);
            else
                cm.Parameters.AddWithValue("@PhuongTinDiLai", DBNull.Value);
            if (_hinhThucTraLuong.Length > 0)
                cm.Parameters.AddWithValue("@HinhThucTraLuong", _hinhThucTraLuong);
            else
                cm.Parameters.AddWithValue("@HinhThucTraLuong", DBNull.Value);
            if (_mucLuongTienCong.Length > 0)
                cm.Parameters.AddWithValue("@MucLuongTienCong", _mucLuongTienCong);
            else
                cm.Parameters.AddWithValue("@MucLuongTienCong", DBNull.Value);
            if (_dungCulamViec.Length > 0)
                cm.Parameters.AddWithValue("@DungCulamViec", _dungCulamViec);
            else
                cm.Parameters.AddWithValue("@DungCulamViec", DBNull.Value);
            if (_cheDoDaoTao.Length > 0)
                cm.Parameters.AddWithValue("@CheDoDaoTao", _cheDoDaoTao);
            else
                cm.Parameters.AddWithValue("@CheDoDaoTao", DBNull.Value);
            if (_Dieukhoankhac.Length > 0)
                cm.Parameters.AddWithValue("@DieuKhoanKhac", _Dieukhoankhac);
            else
                cm.Parameters.AddWithValue("@DieuKhoanKhac", DBNull.Value);
            if (_NguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@NguoiKy", _NguoiKy);
            else
                cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
            if (_ChucVu.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu", _ChucVu);
            else
                cm.Parameters.AddWithValue("@ChucVu", DBNull.Value);
            if (_QuocTich.Length > 0)
                cm.Parameters.AddWithValue("@QuocTich", _QuocTich);
            else
                cm.Parameters.AddWithValue("@QuocTich", DBNull.Value);
            if (_DienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _DienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", _loai);
            if (_phuCap.Length > 0)
                cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            else
                cm.Parameters.AddWithValue("@PhuCap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayTraLuong", _ngayTraLuong.DBValue);
            if (_tienThuong.Length > 0)
                cm.Parameters.AddWithValue("@TienThuong", _tienThuong);
            else
                cm.Parameters.AddWithValue("@TienThuong", DBNull.Value);
            if (_cheDoNangLuong.Length > 0)
                cm.Parameters.AddWithValue("@CheDoNangLuong", _cheDoNangLuong);
            else
                cm.Parameters.AddWithValue("@CheDoNangLuong", DBNull.Value);
            if (_bhxhBhyt.Length > 0)
                cm.Parameters.AddWithValue("@BHXH_BHYT", _bhxhBhyt);
            else
                cm.Parameters.AddWithValue("@BHXH_BHYT", DBNull.Value);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHopDongLaoDong_DieuKhoan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_thoiGiamLamViec.Length > 0)
                cm.Parameters.AddWithValue("@ThoiGiamLamViec", _thoiGiamLamViec);
            else
                cm.Parameters.AddWithValue("@ThoiGiamLamViec", DBNull.Value);
            if (_phuongTinDiLai.Length > 0)
                cm.Parameters.AddWithValue("@PhuongTinDiLai", _phuongTinDiLai);
            else
                cm.Parameters.AddWithValue("@PhuongTinDiLai", DBNull.Value);
            if (_hinhThucTraLuong.Length > 0)
                cm.Parameters.AddWithValue("@HinhThucTraLuong", _hinhThucTraLuong);
            else
                cm.Parameters.AddWithValue("@HinhThucTraLuong", DBNull.Value);
            if (_mucLuongTienCong.Length > 0)
                cm.Parameters.AddWithValue("@MucLuongTienCong", _mucLuongTienCong);
            else
                cm.Parameters.AddWithValue("@MucLuongTienCong", DBNull.Value);
            if (_dungCulamViec.Length > 0)
                cm.Parameters.AddWithValue("@DungCulamViec", _dungCulamViec);
            else
                cm.Parameters.AddWithValue("@DungCulamViec", DBNull.Value);
            if (_cheDoDaoTao.Length > 0)
                cm.Parameters.AddWithValue("@CheDoDaoTao", _cheDoDaoTao);
            else
                cm.Parameters.AddWithValue("@CheDoDaoTao", DBNull.Value);
            if (_Dieukhoankhac.Length > 0)
                cm.Parameters.AddWithValue("@DieuKhoanKhac", _Dieukhoankhac);
            else
                cm.Parameters.AddWithValue("@DieuKhoanKhac", DBNull.Value);

            if (_NguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@NguoiKy", _NguoiKy);
            else
                cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);

            if (_ChucVu.Length > 0)
                cm.Parameters.AddWithValue("@ChucVu", _ChucVu);
            else
                cm.Parameters.AddWithValue("@Chucvu", DBNull.Value);

            if (_QuocTich.Length > 0)
                cm.Parameters.AddWithValue("@QuocTich", _QuocTich);
            else
                cm.Parameters.AddWithValue("@QuocTich", DBNull.Value);
            if (_DienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _DienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            
            if (_phuCap.Length > 0)
                cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            else
                cm.Parameters.AddWithValue("@PhuCap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayTraLuong", _ngayTraLuong.DBValue);
            if (_tienThuong.Length > 0)
                cm.Parameters.AddWithValue("@TienThuong", _tienThuong);
            else
                cm.Parameters.AddWithValue("@TienThuong", DBNull.Value);
            if (_cheDoNangLuong.Length > 0)
                cm.Parameters.AddWithValue("@CheDoNangLuong", _cheDoNangLuong);
            else
                cm.Parameters.AddWithValue("@CheDoNangLuong", DBNull.Value);
            if (_bhxhBhyt.Length > 0)
                cm.Parameters.AddWithValue("@BHXH_BHYT", _bhxhBhyt);
            else
                cm.Parameters.AddWithValue("@BHXH_BHYT", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
