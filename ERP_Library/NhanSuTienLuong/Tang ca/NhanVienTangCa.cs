
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVienTangCa : Csla.BusinessBase<NhanVienTangCa>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBangTangCa = 0;
        private Nullable<int> _maBoPhan = null;
        private Nullable<long> _maNhanVien = null;
        private Nullable<int> _maLoaiTangCa = null;
        private DateTime _ngayTangCa = DateTime.Today;
        private decimal _soGio = 0;
        private DateTime _thoiGianBD = DateTime.Today;
        private DateTime _thoiGianKT = DateTime.Today;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaBangTangCa
        {
            get
            {
                CanReadProperty("MaBangTangCa", true);
                return _maBangTangCa;
            }
        }

        public Nullable<int> MaBoPhan
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

        public Nullable<long> MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public Nullable<int> MaLoaiTangCa
        {
            get
            {
                CanReadProperty("MaLoaiTangCa", true);
                return _maLoaiTangCa;
            }
            set
            {
                CanWriteProperty("MaLoaiTangCa", true);
                if (!_maLoaiTangCa.Equals(value))
                {
                    _maLoaiTangCa = value;
                    PropertyHasChanged("MaLoaiTangCa");
                }
            }
        }

        public DateTime NgayTangCa
        {
            get
            {
                CanReadProperty("NgayTangCa", true);
                return _ngayTangCa;
            }
            set
            {
                CanWriteProperty("NgayTangCa", true);
                if (!_ngayTangCa.Equals(value))
                {
                    _ngayTangCa = value;
                    PropertyHasChanged("NgayTangCa");
                    
                    _thoiGianBD = new DateTime(value.Year, value.Month, value.Day, _thoiGianBD.Hour, ThoiGianBD.Minute, 0);
                    PropertyHasChanged("ThoiGianBD");

                    _thoiGianKT = new DateTime(value.Year, value.Month, value.Day, _thoiGianKT.Hour, ThoiGianKT.Minute, 0);
                    PropertyHasChanged("ThoiGianKT");
                }
            }
        }

        private void CapNhatSoGio()
        {
            TimeSpan t = _thoiGianKT.Subtract(_thoiGianBD);
            _soGio = t.Hours + (decimal)t.Minutes / 60;
            PropertyHasChanged("SoGio");
        }

        public decimal SoGio
        {
            get
            {
                CanReadProperty("SoGio", true);
                return _soGio;
            }
            set
            {
                CanWriteProperty("SoGio", true);
                if (!_soGio.Equals(value))
                {
                    _soGio = value;
                    PropertyHasChanged("SoGio");
                }
            }
        }

        public DateTime ThoiGianBD
        {
            get
            {
                CanReadProperty("ThoiGianBD", true);
                return _thoiGianBD;
            }
            set
            {
                CanWriteProperty("ThoiGianBD", true);
                if (!_thoiGianBD.Equals(value))
                {
                    _thoiGianBD = value;
                    PropertyHasChanged("ThoiGianBD");
                    CapNhatSoGio();
                }
            }
        }

        public DateTime ThoiGianKT
        {
            get
            {
                CanReadProperty("ThoiGianKT", true);
                return _thoiGianKT;
            }
            set
            {
                CanWriteProperty("ThoiGianKT", true);
                if (!_thoiGianKT.Equals(value))
                {
                    _thoiGianKT = value;
                    PropertyHasChanged("ThoiGianKT");
                    CapNhatSoGio();
                }
            }
        }

        public string GioBatDau
        {
            get
            {
                CanReadProperty("ThoiGianBD", true);
                return _thoiGianBD.ToString("HH:mm");
            }
            set
            {
                CanWriteProperty("ThoiGianBD", true);
                if (!_thoiGianBD.ToString("HH:mm").Equals(value))
                {
                    _thoiGianBD = new DateTime(_ngayTangCa.Year, _ngayTangCa.Month, _ngayTangCa.Day, Convert.ToInt32(value.Substring(0, 2)), Convert.ToInt32(value.Substring(3, 2)), 0);
                    PropertyHasChanged("ThoiGianBD");
                    CapNhatSoGio();
                }
            }
        }

        public string GioKetThuc
        {
            get
            {
                CanReadProperty("ThoiGianKT", true);
                return _thoiGianKT.ToString("HH:mm");
            }
            set
            {
                CanWriteProperty("ThoiGianKT", true);
                if (!_thoiGianKT.ToString("HH:mm").Equals(value))
                {
                    _thoiGianKT = new DateTime(_ngayTangCa.Year, _ngayTangCa.Month, _ngayTangCa.Day, Convert.ToInt32(value.Substring(0, 2)), Convert.ToInt32(value.Substring(3, 2)), 0);
                    PropertyHasChanged("ThoiGianKT");
                    CapNhatSoGio();
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
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maBangTangCa;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
            
        }

        private void AddCommonRules()
        {
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaBoPhan", "Chưa nhập bộ phận"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaNhanVien", "Chưa nhập nhân viên"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaLoaiTangCa", "Chưa nhập hình thức tăng ca"));
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
            //TODO: Define authorization rules in NhanVienTangCa
            //AuthorizationRules.AllowRead("MaBangTangCa", "NhanVienTangCaReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "NhanVienTangCaReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "NhanVienTangCaReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiTangCa", "NhanVienTangCaReadGroup");
            //AuthorizationRules.AllowRead("NgayTangCa", "NhanVienTangCaReadGroup");
            //AuthorizationRules.AllowRead("SoGio", "NhanVienTangCaReadGroup");
            //AuthorizationRules.AllowRead("ThoiGianBD", "NhanVienTangCaReadGroup");
            //AuthorizationRules.AllowRead("ThoiGianKT", "NhanVienTangCaReadGroup");

            //AuthorizationRules.AllowWrite("MaBoPhan", "NhanVienTangCaWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "NhanVienTangCaWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiTangCa", "NhanVienTangCaWriteGroup");
            //AuthorizationRules.AllowWrite("NgayTangCa", "NhanVienTangCaWriteGroup");
            //AuthorizationRules.AllowWrite("SoGio", "NhanVienTangCaWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiGianBD", "NhanVienTangCaWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiGianKT", "NhanVienTangCaWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhanVienTangCa
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVienTangCaViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhanVienTangCa
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVienTangCaAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhanVienTangCa
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVienTangCaEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhanVienTangCa
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVienTangCaDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhanVienTangCa()
        { /* require use of factory method */ }

        public static NhanVienTangCa NewNhanVienTangCa()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVienTangCa");
            return DataPortal.Create<NhanVienTangCa>();
        }

        public static NhanVienTangCa GetNhanVienTangCa(int maBangTangCa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienTangCa");
            return DataPortal.Fetch<NhanVienTangCa>(new Criteria(maBangTangCa));
        }

        public static void DeleteNhanVienTangCa(int maBangTangCa)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhanVienTangCa");
            DataPortal.Delete(new Criteria(maBangTangCa));
        }

        public override NhanVienTangCa Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhanVienTangCa");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVienTangCa");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhanVienTangCa");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaBangTangCa;

            public Criteria(int maBangTangCa)
            {
                this.MaBangTangCa = maBangTangCa;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
            //PropertyHasChanged("MaBoPhan");
            //PropertyHasChanged("MaNhanVien");
            //PropertyHasChanged("MaLoaiTangCa");
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
                    MarkOld();
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
                cm.CommandText = "spd_Select_NhanVienTangCa";

                cm.Parameters.AddWithValue("@MaBangTangCa", criteria.MaBangTangCa);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    FetchObject(dr);
                    //ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        private void FetchObject(SafeDataReader dr)
        {
            dr.Read();
            _maBangTangCa = dr.GetInt32("MaBangTangCa");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maLoaiTangCa = dr.GetInt32("MaLoaiTangCa");
            _ngayTangCa = dr.GetDateTime("NgayTangCa");
            _soGio = dr.GetDecimal("SoGio");
            _thoiGianBD = dr.GetDateTime("ThoiGianBD");
            _thoiGianKT = dr.GetDateTime("ThoiGianKT");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
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

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_NhanVienTangCa";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maBangTangCa = (int)cm.Parameters["@MaBangTangCa"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaLoaiTangCa", _maLoaiTangCa);
            cm.Parameters.AddWithValue("@NgayTangCa", _ngayTangCa);
            cm.Parameters.AddWithValue("@SoGio", _soGio);
            cm.Parameters.AddWithValue("@ThoiGianBD", _thoiGianBD);
            cm.Parameters.AddWithValue("@ThoiGianKT", _thoiGianKT);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            cm.Parameters.AddWithValue("@MaBangTangCa", _maBangTangCa);
            cm.Parameters["@MaBangTangCa"].Direction = ParameterDirection.Output;
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

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_NhanVienTangCa";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBangTangCa", _maBangTangCa);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaLoaiTangCa", _maLoaiTangCa);
            cm.Parameters.AddWithValue("@NgayTangCa", _ngayTangCa);
            cm.Parameters.AddWithValue("@SoGio", _soGio);
            cm.Parameters.AddWithValue("@ThoiGianBD", _thoiGianBD);
            cm.Parameters.AddWithValue("@ThoiGianKT", _thoiGianKT);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maBangTangCa));
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
                cm.CommandText = "spd_Delete_NhanVienTangCa";

                cm.Parameters.AddWithValue("@MaBangTangCa", criteria.MaBangTangCa);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
