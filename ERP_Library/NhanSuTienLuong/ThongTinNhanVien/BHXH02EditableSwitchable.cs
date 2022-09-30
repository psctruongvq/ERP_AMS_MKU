
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BHXH02 : Csla.BusinessBase<BHXH02>
    {
        #region Business Properties and Methods

        //declare members
        private long _maso = 0;
        private int _thang = 0;
        private int _nam=0;
        private long _manhanvien=0;
        private string _TenNhanVien = string.Empty;
        private string _NoiDKTinh=string.Empty;

        private decimal _LuongCB = 0;
        private string _NoiDKBenhvien=string.Empty;
        private decimal _PCChucvu = 0;
        private decimal _PCthamnienVK=0;
        private decimal _PCthamniennghe = 0;
        private decimal _PCKhuVuc = 0;
        private string _ThamGiaTu=string.Empty;
        private string _ThamGiaDen=string.Empty;
        private string _GhiChu=string.Empty;
        private int _Sothang = 0;

        private decimal _BSBHXH = 0;
        private decimal _BSBHYT = 0;
        [System.ComponentModel.DataObjectField(true, true)]
        public long Maso
        {
            get
            {
                CanReadProperty("MaSo", true);
                return _maso;
            }
        }
    
        public int Thang
        {
            get
            {
                CanReadProperty("Thang", true);
                return _thang;
            }
            set
            {
                CanWriteProperty("Thang", true);
                if (!_thang.Equals(value))
                {
                    _thang = value;
                    PropertyHasChanged("Thang");
                }
            }
        }

        public int Nam
        {
            get
            {
                CanReadProperty("nam", true);
                return _nam;
            }
            set
            {
                CanWriteProperty("Nam", true);
                if (!_nam.Equals(value))
                {
                    _nam = value;
                    PropertyHasChanged("nam");
                }
            }
        }

        public long Manhanvien
        {
            get
            {
                CanReadProperty("Manhanvien", true);
                return _manhanvien;
            }
            set
            {
                CanWriteProperty("manhanvien", true);
                if (!_manhanvien.Equals(value))
                {
                    _manhanvien = value;
                    PropertyHasChanged("manhanvien");
                }
            }
        }

        public string NoiDKTinh
        {
            get
            {
                CanReadProperty("NoiDKTinh", true);
                return _NoiDKTinh;
            }
            set
            {
                CanWriteProperty("NoiDKTinh", true);
                if (!_NoiDKTinh.Equals(value))
                {
                    _NoiDKTinh = value;
                    PropertyHasChanged("NoiDKTinh");
                }
            }
        }

        public string Tennhanvien
        {
            get
            {
                CanReadProperty("Tennhanvien", true);
                return _TenNhanVien;
            }
            set
            {
                CanWriteProperty("Tennhanvien", true);
                if (!_TenNhanVien.Equals(value))
                {
                    _TenNhanVien = value;
                    PropertyHasChanged("Tennhanvien");
                }
            }
        }

        public decimal LuongCB
        {
            get
            {
                CanReadProperty("LuongCB", true);
                return _LuongCB;
            }
            set
            {
                CanWriteProperty("LuongCB", true);
                if (!_LuongCB.Equals(value))
                {
                    _LuongCB = value;
                    PropertyHasChanged("LuongCB");
                }
            }
        }

        public string NoiDKBenhvien
        {
            get
            {
                CanReadProperty("NoiDKBenhvien", true);
                return _NoiDKBenhvien;
            }
            set
            {
                CanWriteProperty("NoiDKBenhvien", true);
                if (!_NoiDKBenhvien.Equals(value))
                {
                    _NoiDKBenhvien = value;
                    PropertyHasChanged("NoiDKBenhvien");
                }
            }
        }

        public decimal PCChucvu
        {
            get
            {
                CanReadProperty("PCChucvu", true);
                return _PCChucvu;
            }
            set
            {
                CanWriteProperty("PCChucvu", true);
                if (!_PCChucvu.Equals(value))
                {
                    _PCChucvu = value;
                    PropertyHasChanged("PCChucvu");
                }
            }
        }

        public decimal PCthamnienVK
        {
            get
            {
                CanReadProperty("PCthamnienVK", true);
                return _PCthamnienVK;
            }
            set
            {
                CanWriteProperty("PCthamnienVK", true);
                if (!_PCthamnienVK.Equals(value))
                {
                    _PCthamnienVK = value;
                    PropertyHasChanged("PCthamnienVK");
                }
            }
        }

        public decimal PCthamniennghe
        {
            get
            {
                CanReadProperty("PCthamniennghe", true);
                return _PCthamniennghe;
            }
            set
            {
                CanWriteProperty("PCthamniennghe", true);
                if (!_PCthamniennghe.Equals(value))
                {
                    _PCthamniennghe = value;
                    PropertyHasChanged("PCthamniennghe");
                }
            }
        }

        public decimal PCKhuVuc
        {
            get
            {
                CanReadProperty("PCKhuVuc", true);
                return _PCKhuVuc;
            }
            set
            {
                CanWriteProperty("PCKhuVuc", true);
                if (!_PCKhuVuc.Equals(value))
                {
                    _PCKhuVuc = value;
                    PropertyHasChanged("PCKhuVuc");
                }
            }
        }

        public string ThamGiaTu
        {
            get
            {
                CanReadProperty("ThamGiaTu", true);
                return _ThamGiaTu;
            }
            set
            {
                CanWriteProperty("ThamGiaTu", true);
                if (!_ThamGiaTu.Equals(value))
                {
                    _ThamGiaTu = value;
                    PropertyHasChanged("ThamGiaTu");
                }
            }
        }

        public string ThamGiaDen
        {
            get
            {
                CanReadProperty("ThamGiaDen", true);
                return _ThamGiaDen;
            }
            set
            {
                CanWriteProperty("ThamGiaDen", true);
                if (!_ThamGiaDen.Equals(value))
                {
                    _ThamGiaDen = value;
                    PropertyHasChanged("ThamGiaDen");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _GhiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (!_GhiChu.Equals(value))
                {
                    _GhiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public int Sothang
        {
            get
            {
                CanReadProperty("Sothang", true);
                return _Sothang;
            }
            set
            {
                CanWriteProperty("Sothang", true);
                if (!_Sothang.Equals(value))
                {
                    _Sothang = value;
                    PropertyHasChanged("Sothang");
                }
            }
        }

        public decimal BSBHXH
        {
            get
            {
                CanReadProperty("BSBHXH", true);
                return _BSBHXH;
            }
            set
            {
                CanWriteProperty("BSBHXH", true);
                if (!_BSBHXH.Equals(value))
                {
                    _BSBHXH = value;
                    PropertyHasChanged("BSBHXH");
                }
            }
        }

        public decimal BSBHYT
        {
            get
            {
                CanReadProperty("BSBHYT", true);
                return _BSBHYT;
            }
            set
            {
                CanWriteProperty("BSBHYT", true);
                if (!_BSBHYT.Equals(value))
                {
                    _BSBHYT = value;
                    PropertyHasChanged("BSBHYT");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maso;
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
            // MaBiaHoSoQuanLy
            //
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
            //TODO: Define authorization rules in BiaHoSo
            //AuthorizationRules.AllowRead("MaBiaHoSo", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("MaBiaHoSoQuanLy", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("TenBiaHoSo", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("SoLuongChua", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("SoLuongToiDa", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("NgayTao", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("NgayTaoString", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("NguoiTao", "BiaHoSoReadGroup");

            //AuthorizationRules.AllowWrite("MaBiaHoSoQuanLy", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("TenBiaHoSo", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongChua", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongToiDa", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("NgayTaoString", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiTao", "BiaHoSoWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BHXH02()
        { /* require use of factory method */ }

        public static BHXH02 NewBHXH02()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BiaHoSo");
            return DataPortal.Create<BHXH02>();
        }

        public static BHXH02 GetBHXH02(long maso)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BiaHoSo");
            return DataPortal.Fetch<BHXH02>(new Criteria(maso));
        }

        public static void DeleteBHXH02(long maso)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BiaHoSo");
            DataPortal.Delete(new Criteria(maso));
        }

        public override BHXH02 Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BiaHoSo");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BiaHoSo");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BiaHoSo");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static BHXH02 NewBHXH02Child()
        {
            BHXH02 child = new BHXH02();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BHXH02 GetBHXH02(SafeDataReader dr)
        {
            BHXH02 child = new BHXH02();
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
            public long maso;

            public Criteria(long maso)
            {
                this.maso = maso;
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
                cm.CommandText = "spd_SelecttblnsBHXH02";

                cm.Parameters.AddWithValue("@Maso", criteria.maso);

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
            DataPortal_Delete(new Criteria(_maso));
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
                cm.CommandText = "spd_DeletetblnsBHXH02";

                cm.Parameters.AddWithValue("@Maso", criteria.maso);

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
            _maso = dr.GetInt64("Maso");
                _thang = dr.GetInt32("Thang");
                _nam = dr.GetInt32("nam");
                _TenNhanVien = dr.GetString("Tennhanvien");
                _NoiDKTinh = dr.GetString("NoiDKTinh");
                _NoiDKBenhvien = dr.GetString("NoiDKBenhvien");
                _LuongCB = dr.GetDecimal("LuongCB");
                _PCChucvu = dr.GetDecimal("PCChucvu");
                _PCthamnienVK = dr.GetDecimal("PCthamnienVK");
                _PCthamniennghe = dr.GetDecimal("PCthamniennghe");
                _PCKhuVuc = dr.GetDecimal("PCKhuVuc");
                _ThamGiaTu = dr.GetString("ThamGiaTu");
                _ThamGiaDen = dr.GetString("ThamGiaDen");
                _GhiChu = dr.GetString("GhiChu");
                _Sothang = dr.GetInt32("Sothang");
                _BSBHXH = dr.GetDecimal("BSBHXH");
                _BSBHYT = dr.GetDecimal("BSBHYT");
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
                cm.CommandText = "spd_inserttblnsbiahoso";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maso = (int)cm.Parameters["@Maso"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //if (_maBiaHoSoQuanLy.Length > 0)
            //    cm.Parameters.AddWithValue("@MaBiaHoSoQuanLy", _maBiaHoSoQuanLy);
            //else
            //    cm.Parameters.AddWithValue("@MaBiaHoSoQuanLy", DBNull.Value);
            //if (_tenBiaHoSo.Length > 0)
            //    cm.Parameters.AddWithValue("@TenBiaHoSo", _tenBiaHoSo);
            //else
            //    cm.Parameters.AddWithValue("@TenBiaHoSo", DBNull.Value);
            //if (_soLuongChua != 0)
            //    cm.Parameters.AddWithValue("@SoLuongChua", _soLuongChua);
            //else
            //    cm.Parameters.AddWithValue("@SoLuongChua", DBNull.Value);
            //if (_soLuongToiDa != 0)
            //    cm.Parameters.AddWithValue("@SoLuongToiDa", _soLuongToiDa);
            //else
            //    cm.Parameters.AddWithValue("@SoLuongToiDa", DBNull.Value);
            //cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
            //if (_nguoiTao != 0)
            //    cm.Parameters.AddWithValue("@NguoiTao", _nguoiTao);
            //else
            //    cm.Parameters.AddWithValue("@NguoiTao", DBNull.Value);
            //cm.Parameters.AddWithValue("@MaBiaHoSo", _maBiaHoSo);
            //cm.Parameters["@MaBiaHoSo"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_updatetblnsBHXH02";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Maso", _maso);
            if (_NoiDKTinh.Length > 0)
                cm.Parameters.AddWithValue("@NoiDKTInh", _NoiDKTinh);
            else
                cm.Parameters.AddWithValue("@NoiDKTInh", DBNull.Value);
            if (_NoiDKBenhvien.Length > 0)
                cm.Parameters.AddWithValue("@NoiDKBenhvien", _NoiDKBenhvien);
            else
                cm.Parameters.AddWithValue("@NoiDKBenhvien", DBNull.Value);
                cm.Parameters.AddWithValue("@PCthamnienVK", _PCthamnienVK);
                cm.Parameters.AddWithValue("@PCChucvu", _PCChucvu);
                cm.Parameters.AddWithValue("@PCthamniennghe", _PCthamniennghe);
                cm.Parameters.AddWithValue("@PCKhuVuc", _PCKhuVuc);
                cm.Parameters.AddWithValue("@ThamGiaTu", _ThamGiaTu);
                cm.Parameters.AddWithValue("@ThamGiaDen", _ThamGiaDen);
                cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
                cm.Parameters.AddWithValue("@Sothang", _Sothang);
                cm.Parameters.AddWithValue("@BSBHXH", +_BSBHXH);
                cm.Parameters.AddWithValue("@BSBHYT", _BSBHYT);          
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

            ExecuteDelete(tr, new Criteria(_maso));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public static void Taodulieu(int thang, int nam)
        {
            using (SqlConnection cn =new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm=cn.CreateCommand())
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TaodanhsachBHXH02";
                        cm.Parameters.AddWithValue("@thang", thang);
                        cm.Parameters.AddWithValue("@nam", nam);
                        cm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public static void Tinhlai(int thang, int nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TinhLaiBHXH02";
                        cm.Parameters.AddWithValue("@thang", thang);
                        cm.Parameters.AddWithValue("@nam", nam);
                        cm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public static decimal QuyluongBH(int thang, int nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        decimal Quyluong = 0;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsBHXH02QuyluongBH";
                        cm.Parameters.AddWithValue("@thang", thang);
                        cm.Parameters.AddWithValue("@Nam", nam);
                        Quyluong = Convert.ToDecimal(cm.ExecuteScalar());
                        return Quyluong;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public static decimal QuyluongYTE(int thang, int nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        decimal Quyluong = 0;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsBHXH02QuyluongYT";
                        cm.Parameters.AddWithValue("@thang", thang);
                        cm.Parameters.AddWithValue("@Nam", nam);
                        Quyluong = Convert.ToDecimal(cm.ExecuteScalar());
                        return Quyluong;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public static decimal BHBS(int thang, int nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        decimal Quyluong = 0;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsBHXH02BSBH";
                        cm.Parameters.AddWithValue("@thang", thang);
                        cm.Parameters.AddWithValue("@Nam", nam);
                        Quyluong = Convert.ToDecimal(cm.ExecuteScalar());
                        return Quyluong;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public static decimal YTEBS(int thang, int nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        decimal Quyluong = 0;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsBHXH02BSYT";
                        cm.Parameters.AddWithValue("@thang", thang);
                        cm.Parameters.AddWithValue("@Nam", nam);
                        Quyluong = Convert.ToDecimal(cm.ExecuteScalar());
                        return Quyluong;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }

    }
}
