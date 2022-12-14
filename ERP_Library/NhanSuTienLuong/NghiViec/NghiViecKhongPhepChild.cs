
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NghiViecKhongPhepChild : Csla.BusinessBase<NghiViecKhongPhepChild>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maNghiViec = 0;
        private int _maBoPhan = 0;
        private long _maNhanVien = 0;
        private Nullable<int> _maHinhThucNghi = null;
        private DateTime _tuNgay = DateTime.Today;
        private DateTime _denNgay = DateTime.Today;
        private string _lyDo = string.Empty;
        private int _SoNgay = 1;
        private int _maKyTinhLuong = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
            set
            {
                CanWriteProperty("MaKyTinhLuong", true);
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }


        public int MaNghiViec
        {
            get
            {
                CanReadProperty("MaNghiViec", true);
                return _maNghiViec;
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

        public long MaNhanVien
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

        public Nullable<int> MaHinhThucNghi
        {
            get
            {
                CanReadProperty("MaHinhThucNghi", true);
                return _maHinhThucNghi;
            }
            set
            {
                CanWriteProperty("MaHinhThucNghi", true);
                if (!_maHinhThucNghi.Equals(value))
                {
                    _maHinhThucNghi = value;
                    PropertyHasChanged("MaHinhThucNghi");
                }
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay;
            }
            set
            {
                CanWriteProperty("TuNgay", true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = value;
                    PropertyHasChanged("TuNgay");
                    CapNhatSoNgay();
                }
            }
        }

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay;
            }
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = value;
                    PropertyHasChanged("DenNgay");
                    CapNhatSoNgay();
                }
            }
        }

        public string LyDo
        {
            get
            {
                CanReadProperty("LyDo", true);
                return _lyDo;
            }
            set
            {
                CanWriteProperty("LyDo", true);
                if (value == null) value = string.Empty;
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
                }
            }
        }

        public int SoNgay
        {
            get
            {
                CanReadProperty("SoNgay", true);
                return _SoNgay;
            }
        }

        private void CapNhatSoNgay()
        {
            //kiểm tra ngày holiday
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandText = "Select Ngay From tblnsNgayHoliday";
            cm.CommandType = CommandType.Text;
            System.Collections.Generic.List<DateTime> d = new System.Collections.Generic.List<DateTime>();
            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            {
                while (dr.Read())
                {
                    d.Add(dr.GetDateTime("Ngay"));
                }
            }
            cn.Close();
            //không tính thứ 7 và chủ nhật
            int i = 0;
            if (_tuNgay <= _denNgay)
            {
                for (DateTime ngay = _tuNgay.Date; ngay <= _denNgay.Date; ngay = ngay.AddDays(1))
                {
                    if (ngay.DayOfWeek != DayOfWeek.Saturday && ngay.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (!d.Contains(ngay))
                            i++;
                    }
                }
            }

            _SoNgay = i;
            PropertyHasChanged("SoNgay");
        }


        protected override object GetIdValue()
        {
            return _maNghiViec;
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
            // LyDo
            //
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaBoPhan", "Chưa nhập bộ phận"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaNhanVien", "Chưa nhập nhân viên"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaHinhThucNghi", "Chưa nhập hình thức nghỉ"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("LyDo","Chưa nhập lý do nghỉ"));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 200));
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
            //TODO: Define authorization rules in NghiViecKhongPhepChild
            //AuthorizationRules.AllowRead("MaNghiViec", "NghiViecKhongPhepChildReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "NghiViecKhongPhepChildReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "NghiViecKhongPhepChildReadGroup");
            //AuthorizationRules.AllowRead("MaHinhThucNghi", "NghiViecKhongPhepChildReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "NghiViecKhongPhepChildReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "NghiViecKhongPhepChildReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "NghiViecKhongPhepChildReadGroup");

            //AuthorizationRules.AllowWrite("MaBoPhan", "NghiViecKhongPhepChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "NghiViecKhongPhepChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaHinhThucNghi", "NghiViecKhongPhepChildWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgay", "NghiViecKhongPhepChildWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgay", "NghiViecKhongPhepChildWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "NghiViecKhongPhepChildWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NghiViecKhongPhepChild
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiViecKhongPhepChildViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NghiViecKhongPhepChild
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiViecKhongPhepChildAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NghiViecKhongPhepChild
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiViecKhongPhepChildEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NghiViecKhongPhepChild
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiViecKhongPhepChildDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public NghiViecKhongPhepChild()
        { /* require use of factory method */ }

        public static NghiViecKhongPhepChild NewNghiViecKhongPhepChild()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NghiViecKhongPhepChild");
            return DataPortal.Create<NghiViecKhongPhepChild>();
        }

        public static NghiViecKhongPhepChild NewNghiViecKhongPhepChildAsChild()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NghiViecKhongPhepChild");

            NghiViecKhongPhepChild t = DataPortal.Create<NghiViecKhongPhepChild>();
            t.MarkAsChild();
            return t;
        }

        public static NghiViecKhongPhepChild GetNghiViecKhongPhepChild(int maNghiViec)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NghiViecKhongPhepChild");
            return DataPortal.Fetch<NghiViecKhongPhepChild>(new Criteria(maNghiViec));
        }

        public static void DeleteNghiViecKhongPhepChild(int maNghiViec)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NghiViecKhongPhepChild");
            DataPortal.Delete(new Criteria(maNghiViec));
        }

        public override NghiViecKhongPhepChild Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NghiViecKhongPhepChild");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NghiViecKhongPhepChild");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NghiViecKhongPhepChild");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NghiViecKhongPhepChild NewNghiViecKhongPhepChildChild()
        {
            NghiViecKhongPhepChild child = new NghiViecKhongPhepChild();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NghiViecKhongPhepChild GetNghiViecKhongPhepChild(SafeDataReader dr)
        {
            NghiViecKhongPhepChild child = new NghiViecKhongPhepChild();
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
            public int MaNghiViec;

            public Criteria(int maNghiViec)
            {
                this.MaNghiViec = maNghiViec;
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
                cm.CommandText = "spd_Select_NghiViecKhongPhepChild";

                cm.Parameters.AddWithValue("@MaNghiViec", criteria.MaNghiViec);

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
            DataPortal_Delete(new Criteria(_maNghiViec));
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
                cm.CommandText = "spd_Delete_NghiViecKhongPhepChild";

                cm.Parameters.AddWithValue("@MaNghiViec", criteria.MaNghiViec);

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
            _maNghiViec = dr.GetInt32("MaNghiViec");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maHinhThucNghi = dr.GetInt32("MaHinhThucNghi");
            _tuNgay = dr.GetDateTime("TuNgay");
            _denNgay = dr.GetDateTime("DenNgay");
            _lyDo = dr.GetString("LyDo");
            _SoNgay = dr.GetInt32("SoNgay");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
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
                cm.CommandText = "spd_Insert_NghiViecKhongPhepChild";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maNghiViec = (int)cm.Parameters["@MaNghiViec"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@SoNgay", _SoNgay);
            cm.Parameters.AddWithValue("@MaNghiViec", _maNghiViec);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters["@MaNghiViec"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_NghiViecKhongPhepChild";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNghiViec", _maNghiViec);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@SoNgay", _SoNgay);
            cm.Parameters.AddWithValue("@MaKyTinhLong", _maKyTinhLuong);
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

            ExecuteDelete(tr, new Criteria(_maNghiViec));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
