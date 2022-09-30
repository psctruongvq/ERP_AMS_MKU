
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{
    [Serializable()]
    public class BaoCaoUocTinhDoanhThu : Csla.BusinessBase<BaoCaoUocTinhDoanhThu>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBaoCao = 0;
        private int _maKy = 0;
        private int _maMuc = 0;
        private string _tenMuc = string.Empty;
        private int _maMucCha = 0;
        private int _soTT = 0;
        private byte _format = 0;
        private decimal _doanhThuThucTeKyTruoc = 0;
        private decimal _uocTinhDoanhThu = 0;
        private decimal _doanhThuLuyKeKyNay = 0;
        private decimal _keHoachNam = 0;
        private decimal _doanhThuLuyLeCungKyNamTruoc = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaBaoCao
        {
            get
            {
                CanReadProperty("MaBaoCao", true);
                return _maBaoCao;
            }
        }

        public int MaKy
        {
            get
            {
                CanReadProperty("MaKy", true);
                return _maKy;
            }
            set
            {
                CanWriteProperty("MaKy", true);
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKy");
                }
            }
        }

        public int MaMuc
        {
            get
            {
                CanReadProperty("MaMuc", true);
                return _maMuc;
            }
            set
            {
                CanWriteProperty("MaMuc", true);
                if (!_maMuc.Equals(value))
                {
                    _maMuc = value;
                    PropertyHasChanged("MaMuc");
                }
            }
        }

        public string TenMuc
        {
            get
            {
                CanReadProperty("TenMuc", true);
                return _tenMuc;
            }
            set
            {
                CanWriteProperty("TenMuc", true);
                if (value == null) value = string.Empty;
                if (!_tenMuc.Equals(value))
                {
                    _tenMuc = value;
                    PropertyHasChanged("TenMuc");
                }
            }
        }

        public int MaMucCha
        {
            get
            {
                CanReadProperty("MaMucCha", true);
                return _maMucCha;
            }
            set
            {
                CanWriteProperty("MaMucCha", true);
                if (!_maMucCha.Equals(value))
                {
                    _maMucCha = value;
                    PropertyHasChanged("MaMucCha");
                }
            }
        }

        public int SoTT
        {
            get
            {
                CanReadProperty("SoTT", true);
                return _soTT;
            }
            set
            {
                CanWriteProperty("SoTT", true);
                if (!_soTT.Equals(value))
                {
                    _soTT = value;
                    PropertyHasChanged("SoTT");
                }
            }
        }

        public byte Format
        {
            get
            {
                CanReadProperty("Format", true);
                return _format;
            }
            set
            {
                CanWriteProperty("Format", true);
                if (!_format.Equals(value))
                {
                    _format = value;
                    PropertyHasChanged("Format");
                }
            }
        }

        public decimal DoanhThuThucTeKyTruoc
        {
            get
            {
                CanReadProperty("DoanhThuThucTeKyTruoc", true);
                return _doanhThuThucTeKyTruoc;
            }
            set
            {
                CanWriteProperty("DoanhThuThucTeKyTruoc", true);
                if (!_doanhThuThucTeKyTruoc.Equals(value))
                {
                    _doanhThuThucTeKyTruoc = value;
                    PropertyHasChanged("DoanhThuThucTeKyTruoc");
                }
            }
        }

        public decimal UocTinhDoanhThu
        {
            get
            {
                CanReadProperty("UocTinhDoanhThu", true);
                return _uocTinhDoanhThu;
            }
            set
            {
                CanWriteProperty("UocTinhDoanhThu", true);
                if (!_uocTinhDoanhThu.Equals(value))
                {
                    _uocTinhDoanhThu = value;
                    PropertyHasChanged("UocTinhDoanhThu");
                }
            }
        }

        public decimal DoanhThuLuyKeKyNay
        {
            get
            {
                CanReadProperty("DoanhThuLuyKeKyNay", true);
                return _doanhThuLuyKeKyNay;
            }
            set
            {
                CanWriteProperty("DoanhThuLuyKeKyNay", true);
                if (!_doanhThuLuyKeKyNay.Equals(value))
                {
                    _doanhThuLuyKeKyNay = value;
                    PropertyHasChanged("DoanhThuLuyKeKyNay");
                }
            }
        }

        public decimal KeHoachNam
        {
            get
            {
                CanReadProperty("KeHoachNam", true);
                return _keHoachNam;
            }
            set
            {
                CanWriteProperty("KeHoachNam", true);
                if (!_keHoachNam.Equals(value))
                {
                    _keHoachNam = value;
                    PropertyHasChanged("KeHoachNam");
                }
            }
        }

        public decimal DoanhThuLuyLeCungKyNamTruoc
        {
            get
            {
                CanReadProperty("DoanhThuLuyLeCungKyNamTruoc", true);
                return _doanhThuLuyLeCungKyNamTruoc;
            }
            set
            {
                CanWriteProperty("DoanhThuLuyLeCungKyNamTruoc", true);
                if (!_doanhThuLuyLeCungKyNamTruoc.Equals(value))
                {
                    _doanhThuLuyLeCungKyNamTruoc = value;
                    PropertyHasChanged("DoanhThuLuyLeCungKyNamTruoc");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maBaoCao;
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
            // TenMuc
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMuc", 1000));
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
            //TODO: Define authorization rules in BaoCaoUocTinhDoanhThu
            //AuthorizationRules.AllowRead("MaBaoCao", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("MaMuc", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("TenMuc", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("MaMucCha", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("SoTT", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("Format", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("DoanhThuThucTeKyTruoc", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("UocTinhDoanhThu", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("DoanhThuLuyKeKyNay", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("KeHoachNam", "BaoCaoUocTinhDoanhThuReadGroup");
            //AuthorizationRules.AllowRead("DoanhThuLuyLeCungKyNamTruoc", "BaoCaoUocTinhDoanhThuReadGroup");

            //AuthorizationRules.AllowWrite("MaKy", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("MaMuc", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("TenMuc", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("MaMucCha", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("SoTT", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("Format", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("DoanhThuThucTeKyTruoc", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("UocTinhDoanhThu", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("DoanhThuLuyKeKyNay", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("KeHoachNam", "BaoCaoUocTinhDoanhThuWriteGroup");
            //AuthorizationRules.AllowWrite("DoanhThuLuyLeCungKyNamTruoc", "BaoCaoUocTinhDoanhThuWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BaoCaoUocTinhDoanhThu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BaoCaoUocTinhDoanhThuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BaoCaoUocTinhDoanhThu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BaoCaoUocTinhDoanhThuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BaoCaoUocTinhDoanhThu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BaoCaoUocTinhDoanhThuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BaoCaoUocTinhDoanhThu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BaoCaoUocTinhDoanhThuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BaoCaoUocTinhDoanhThu()
        { /* require use of factory method */ }

        public static BaoCaoUocTinhDoanhThu NewBaoCaoUocTinhDoanhThu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BaoCaoUocTinhDoanhThu");
            return DataPortal.Create<BaoCaoUocTinhDoanhThu>();
        }

        public static BaoCaoUocTinhDoanhThu GetBaoCaoUocTinhDoanhThu(int maBaoCao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BaoCaoUocTinhDoanhThu");
            return DataPortal.Fetch<BaoCaoUocTinhDoanhThu>(new Criteria(maBaoCao));
        }

        public static void DeleteBaoCaoUocTinhDoanhThu(int maBaoCao)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BaoCaoUocTinhDoanhThu");
            DataPortal.Delete(new Criteria(maBaoCao));
        }

        public override BaoCaoUocTinhDoanhThu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BaoCaoUocTinhDoanhThu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BaoCaoUocTinhDoanhThu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BaoCaoUocTinhDoanhThu");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static BaoCaoUocTinhDoanhThu NewBaoCaoUocTinhDoanhThuChild()
        {
            BaoCaoUocTinhDoanhThu child = new BaoCaoUocTinhDoanhThu();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BaoCaoUocTinhDoanhThu GetBaoCaoUocTinhDoanhThu(SafeDataReader dr, bool kiemtra)
        {
            BaoCaoUocTinhDoanhThu child = new BaoCaoUocTinhDoanhThu();
            child.MarkAsChild();
            child.Fetch(dr, kiemtra);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaBaoCao;

            public Criteria(int maBaoCao)
            {
                this.MaBaoCao = maBaoCao;
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
                cm.CommandText = "spd_SelecttblBaoCaoUocTinhDoanhThu";

                cm.Parameters.AddWithValue("@MaBaoCao", criteria.MaBaoCao);

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
            DataPortal_Delete(new Criteria(_maBaoCao));
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
                cm.CommandText = "spd_DeletetblBaoCaoUocTinhDoanhThu";

                cm.Parameters.AddWithValue("@MaBaoCao", criteria.MaBaoCao);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr, bool kiemtra)
        {
            FetchObject(dr);
            if (kiemtra == true)
                MarkOld();
            else MarkNew();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maBaoCao = dr.GetInt32("MaBaoCao");
            _maKy = dr.GetInt32("MaKy");
            _maMuc = dr.GetInt32("MaMuc");
            _tenMuc = dr.GetString("TenMuc");
            _maMucCha = dr.GetInt32("MaMucCha");
            _soTT = dr.GetInt32("SoTT");
            _format = dr.GetByte("Format");
            _doanhThuThucTeKyTruoc = dr.GetDecimal("DoanhThuThucTeKyTruoc");
            _uocTinhDoanhThu = dr.GetDecimal("UocTinhDoanhThu");
            _doanhThuLuyKeKyNay = dr.GetDecimal("DoanhThuLuyKeKyNay");
            _keHoachNam = dr.GetDecimal("KeHoachNam");
            _doanhThuLuyLeCungKyNamTruoc = dr.GetDecimal("DoanhThuLuyLeCungKyNamTruoc");
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
                cm.CommandText = "spd_InserttblBaoCaoUocTinhDoanhThu";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maBaoCao = (int)cm.Parameters["@MaBaoCao"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maMuc != 0)
                cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            else
                cm.Parameters.AddWithValue("@MaMuc", DBNull.Value);
            if (_tenMuc.Length > 0)
                cm.Parameters.AddWithValue("@TenMuc", _tenMuc);
            else
                cm.Parameters.AddWithValue("@TenMuc", DBNull.Value);
            if (_maMucCha != 0)
                cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
            else
                cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
            if (_soTT != 0)
                cm.Parameters.AddWithValue("@SoTT", _soTT);
            else
                cm.Parameters.AddWithValue("@SoTT", DBNull.Value);
            if (_format != 0)
                cm.Parameters.AddWithValue("@Format", _format);
            else
                cm.Parameters.AddWithValue("@Format", DBNull.Value);
           
            cm.Parameters.AddWithValue("@DoanhThuThucTeKyTruoc", _doanhThuThucTeKyTruoc);          
            cm.Parameters.AddWithValue("@UocTinhDoanhThu", _uocTinhDoanhThu);           
            cm.Parameters.AddWithValue("@DoanhThuLuyKeKyNay", _doanhThuLuyKeKyNay);           
            cm.Parameters.AddWithValue("@KeHoachNam", _keHoachNam);
            cm.Parameters.AddWithValue("@DoanhThuLuyLeCungKyNamTruoc", _doanhThuLuyLeCungKyNamTruoc);
         
            cm.Parameters.AddWithValue("@MaBaoCao", _maBaoCao);
            cm.Parameters["@MaBaoCao"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblBaoCaoUocTinhDoanhThu";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBaoCao", _maBaoCao);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maMuc != 0)
                cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            else
                cm.Parameters.AddWithValue("@MaMuc", DBNull.Value);
            if (_tenMuc.Length > 0)
                cm.Parameters.AddWithValue("@TenMuc", _tenMuc);
            else
                cm.Parameters.AddWithValue("@TenMuc", DBNull.Value);
            if (_maMucCha != 0)
                cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
            else
                cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
            if (_soTT != 0)
                cm.Parameters.AddWithValue("@SoTT", _soTT);
            else
                cm.Parameters.AddWithValue("@SoTT", DBNull.Value);
            if (_format != 0)
                cm.Parameters.AddWithValue("@Format", _format);
            else
                cm.Parameters.AddWithValue("@Format", DBNull.Value);
           
            cm.Parameters.AddWithValue("@DoanhThuThucTeKyTruoc", _doanhThuThucTeKyTruoc);          
            cm.Parameters.AddWithValue("@UocTinhDoanhThu", _uocTinhDoanhThu);          
            cm.Parameters.AddWithValue("@DoanhThuLuyKeKyNay", _doanhThuLuyKeKyNay);          
            cm.Parameters.AddWithValue("@KeHoachNam", _keHoachNam);          
            cm.Parameters.AddWithValue("@DoanhThuLuyLeCungKyNamTruoc", _doanhThuLuyLeCungKyNamTruoc);
           
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

            ExecuteDelete(tr, new Criteria(_maBaoCao));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        #region KiemTraKy
        public static int KiemTraKyBaoCao(int MaKy)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraKyBaoCaoUocTinhDTChiPhi";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }
        #endregion 

    }

}

