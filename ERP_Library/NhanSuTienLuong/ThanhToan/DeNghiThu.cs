
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class DeNghiThu : Csla.BusinessBase<DeNghiThu>
    {
        #region Business Properties and Methods

        //declare members
        private long _maPhieu = 0;
        private string _soPhieu = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private decimal _soTien = 0;
        private string _dienGiai = string.Empty;
        private Guid _maDaiLy = Guid.Empty;
        private Guid _nguoiLap = Guid.Empty;
        private bool _hoanTat = false;
        // Tran them cho Thu Chi
        private bool _check = false;
        private decimal _soTienThanhToan = 0;
        private long _maChungTuDeNghiThu = 0;

       
        [System.ComponentModel.DataObjectField(true, true)]
        public long MaPhieu
        {
            get
            {
                CanReadProperty("MaPhieu", true);
                return _maPhieu;
            }
        }

        public string SoPhieu
        {
            get
            {
                CanReadProperty("SoPhieu", true);
                return _soPhieu;
            }
            set
            {
                CanWriteProperty("SoPhieu", true);
                if (value == null) value = string.Empty;
                if (!_soPhieu.Equals(value))
                {
                    _soPhieu = value;
                    PropertyHasChanged("SoPhieu");
                }
            }
        }

        public DateTime Ngay
        {
            get
            {
                CanReadProperty("Ngay", true);
                return _ngay.Date;
            }
        }

        //public string NgayString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayString", true);
        //        return _ngay.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngay.Equals(value))
        //        {
        //            _ngay.Text = value;
        //            PropertyHasChanged("NgayString");
        //        }
        //    }
        //}

        public decimal SoTien
        {
            get
            {
                CanReadProperty("SoTien", true);
                return _soTien;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
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

        public Guid MaDaiLy
        {
            get
            {
                CanReadProperty("MaDaiLy", true);
                return _maDaiLy;
            }
            set
            {
                CanWriteProperty("MaDaiLy", true);
                if (!_maDaiLy.Equals(value))
                {
                    _maDaiLy = value;
                    PropertyHasChanged("MaDaiLy");
                }
            }
        }

        public Guid NguoiLap
        {
            get
            {
                CanReadProperty("NguoiLap", true);
                return _nguoiLap;
            }
            set
            {
                CanWriteProperty("NguoiLap", true);
                if (!_nguoiLap.Equals(value))
                {
                    _nguoiLap = value;
                    PropertyHasChanged("NguoiLap");
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
        public bool Check
        {
            get { return _check; }
            set { _check = value; }
        }
        public decimal SoTienThanhToan
        {
            get { return _soTienThanhToan; }
            set { _soTienThanhToan = value; }
        }
        public long MaChungTuDeNghiThu
        {
            get { return _maChungTuDeNghiThu; }
            set { _maChungTuDeNghiThu = value; }
        }
        protected override object GetIdValue()
        {
            return _maPhieu;
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
            // SoPhieu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoPhieu", 50));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 250));
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
            //TODO: Define authorization rules in DeNghiThu
            //AuthorizationRules.AllowRead("MaPhieu", "DeNghiThuReadGroup");
            //AuthorizationRules.AllowRead("SoPhieu", "DeNghiThuReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "DeNghiThuReadGroup");
            //AuthorizationRules.AllowRead("NgayString", "DeNghiThuReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "DeNghiThuReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "DeNghiThuReadGroup");
            //AuthorizationRules.AllowRead("MaDaiLy", "DeNghiThuReadGroup");
            //AuthorizationRules.AllowRead("NguoiLap", "DeNghiThuReadGroup");
            //AuthorizationRules.AllowRead("HoanTat", "DeNghiThuReadGroup");

            //AuthorizationRules.AllowWrite("SoPhieu", "DeNghiThuWriteGroup");
            //AuthorizationRules.AllowWrite("NgayString", "DeNghiThuWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "DeNghiThuWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "DeNghiThuWriteGroup");
            //AuthorizationRules.AllowWrite("MaDaiLy", "DeNghiThuWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLap", "DeNghiThuWriteGroup");
            //AuthorizationRules.AllowWrite("HoanTat", "DeNghiThuWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeNghiThu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeNghiThu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeNghiThu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeNghiThu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DeNghiThu()
        { /* require use of factory method */ }

        public static DeNghiThu NewDeNghiThu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiThu");
            return DataPortal.Create<DeNghiThu>();
        }

        public static DeNghiThu GetDeNghiThu(long maPhieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiThu");
            return DataPortal.Fetch<DeNghiThu>(new Criteria(maPhieu));
        }

        public static void DeleteDeNghiThu(long maPhieu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiThu");
            DataPortal.Delete(new Criteria(maPhieu));
        }

        public override DeNghiThu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiThu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiThu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DeNghiThu");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DeNghiThu NewDeNghiThuChild()
        {
            DeNghiThu child = new DeNghiThu();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DeNghiThu GetDeNghiThu(SafeDataReader dr)
        {
            DeNghiThu child = new DeNghiThu();
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
            public long MaPhieu;

            public Criteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
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
                cm.CommandText = "GetDeNghiThu";

                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

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
            DataPortal_Delete(new Criteria(_maPhieu));
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
                cm.CommandText = "sp_DeletetblDeNghiThu";

                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

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
            _maPhieu = dr.GetInt64("MaPhieu");
            _soPhieu = dr.GetString("SoPhieu");
            _ngay = dr.GetDateTime("Ngay");
            _soTien = dr.GetDecimal("SoTien");
            _dienGiai = dr.GetString("DienGiai");
            _maDaiLy = dr.GetGuid("MaDaiLy");
            _nguoiLap = dr.GetGuid("NguoiLap");
            _hoanTat = dr.GetBoolean("HoanTat");
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
                cm.CommandText = "sp_InserttblDeNghiThu";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maPhieu = (long)cm.Parameters["@MaPhieu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
          
                cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
          
                cm.Parameters.AddWithValue("@Ngay",_ngay);
           
                cm.Parameters.AddWithValue("@SoTien", _soTien);
           
           
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);


                if (_maDaiLy != Guid.Empty)
                    cm.Parameters.AddWithValue("@MaDaiLy", _maDaiLy);
                else
                    cm.Parameters.AddWithValue("@MaDaiLy", DBNull.Value);
                if (_nguoiLap != Guid.Empty)
                    cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
                else
                    cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
          
          
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
         
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            cm.Parameters["@MaPhieu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "sp_UpdatetblDeNghiThu";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
           
                cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
          
            cm.Parameters.AddWithValue("@Ngay",_ngay);
          
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
           
            if (_maDaiLy != Guid.Empty)
                cm.Parameters.AddWithValue("@MaDaiLy", _maDaiLy);
            else
                cm.Parameters.AddWithValue("@MaDaiLy", DBNull.Value);
            if (_nguoiLap != Guid.Empty)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
           
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            
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

            ExecuteDelete(tr, new Criteria(_maPhieu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
