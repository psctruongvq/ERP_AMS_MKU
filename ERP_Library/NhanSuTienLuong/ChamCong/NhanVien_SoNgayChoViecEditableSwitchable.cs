
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using ERP_Library;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVien_SoNgayChoViec : Csla.BusinessBase<NhanVien_SoNgayChoViec>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNhanVienSoNgayCV = 0;
        private long _maNhanVien = 0;
        private int _maKyTinhLuong = 0;
        private decimal _soNgayChoViec = 0;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenKy = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaNhanVienSoNgayCV
        {
            get
            {
                CanReadProperty("MaNhanVienSoNgayCV", true);
                return _maNhanVienSoNgayCV;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
        }

        public decimal SoNgayChoViec
        {
            get
            {
                CanReadProperty("SoNgayChoViec", true);
                return _soNgayChoViec;
            }
            set
            {
                CanWriteProperty("SoNgayChoViec", true);
                if (!_soNgayChoViec.Equals(value))
                {
                    _soNgayChoViec = value;
                    PropertyHasChanged("SoNgayChoViec");
                }
            }
        }
        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                return _maQLNhanVien;
            }
            set
            {

                CanWriteProperty("MaQLNhanVien", true);
                if (!_maQLNhanVien.Equals(value))
                {
                    _maQLNhanVien = value;
                    PropertyHasChanged("MaQLNhanVien");
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
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
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
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }
        public string TenKy
        {
            get
            {
                CanReadProperty("TenKy", true);
                return _tenKy;
            }
            set
            {

                CanWriteProperty("TenKy", true);
                if (!_tenKy.Equals(value))
                {
                    _tenKy = value;
                    PropertyHasChanged("TenKy");
                }
            }
        }
        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}:{2}", _maNhanVienSoNgayCV, _maNhanVien, _maKyTinhLuong);
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

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
            //TODO: Define authorization rules in NhanVien_SoNgayChoViec
            //AuthorizationRules.AllowRead("MaNhanVienSoNgayCV", "NhanVien_SoNgayChoViecReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "NhanVien_SoNgayChoViecReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "NhanVien_SoNgayChoViecReadGroup");
            //AuthorizationRules.AllowRead("SoNgayChoViec", "NhanVien_SoNgayChoViecReadGroup");

            //AuthorizationRules.AllowWrite("SoNgayChoViec", "NhanVien_SoNgayChoViecWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhanVien_SoNgayChoViec
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_SoNgayChoViecViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhanVien_SoNgayChoViec
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_SoNgayChoViecAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhanVien_SoNgayChoViec
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_SoNgayChoViecEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhanVien_SoNgayChoViec
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_SoNgayChoViecDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhanVien_SoNgayChoViec()
        { /* require use of factory method */ }

        public static NhanVien_SoNgayChoViec NewNhanVien_SoNgayChoViec()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVien_SoNgayChoViec");
            return DataPortal.Create<NhanVien_SoNgayChoViec>();
        }

        public static NhanVien_SoNgayChoViec GetNhanVien_SoNgayChoViec(int maNhanVienSoNgayCV, long maNhanVien, int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_SoNgayChoViec");
            return DataPortal.Fetch<NhanVien_SoNgayChoViec>(new Criteria(maNhanVienSoNgayCV, maNhanVien, maKyTinhLuong));
        }

        public static void DeleteNhanVien_SoNgayChoViec(int maNhanVienSoNgayCV, long maNhanVien, int maKyTinhLuong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhanVien_SoNgayChoViec");
            DataPortal.Delete(new Criteria(maNhanVienSoNgayCV, maNhanVien, maKyTinhLuong));
        }

        public override NhanVien_SoNgayChoViec Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhanVien_SoNgayChoViec");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVien_SoNgayChoViec");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhanVien_SoNgayChoViec");

            return base.Save();
        }
        public static void TinhSoNgayChoViec(int maKy, int maBoPhan)
        {
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_TinhSoNgayChoViecNV]";

                //AddUpdateParameters(cm, parent);

                cm.Parameters.AddWithValue("@MaKyTinhLuong", maKy);
                cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                //cm.Parameters.AddWithValue("@NhaMay", "");//Properties.Settings.Default.NhaMay);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }//using
        }

        public static void TinhSoNgayChoViecTungNV(int maKy, long MaNhanVien, double SoNgayChoViec)
        {
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_tinhSoNgayChoViecTungNV]";

                //AddUpdateParameters(cm, parent);

                cm.Parameters.AddWithValue("@MaKyTinhLuong", maKy);
                cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                cm.Parameters.AddWithValue("@SoNgayChoViec", SoNgayChoViec);
                //cm.Parameters.AddWithValue("@NhaMay", "");//Properties.Settings.Default.NhaMay);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }//using
        }
        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NhanVien_SoNgayChoViec NewNhanVien_SoNgayChoViecChild()
        {
            NhanVien_SoNgayChoViec child = new NhanVien_SoNgayChoViec();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhanVien_SoNgayChoViec GetNhanVien_SoNgayChoViec(SafeDataReader dr)
        {
            NhanVien_SoNgayChoViec child = new NhanVien_SoNgayChoViec();
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
            public int MaNhanVienSoNgayCV;
            public long MaNhanVien;
            public int MaKyTinhLuong;

            public Criteria(int maNhanVienSoNgayCV, long maNhanVien, int maKyTinhLuong)
            {
                this.MaNhanVienSoNgayCV = maNhanVienSoNgayCV;
                this.MaNhanVien = maNhanVien;
                this.MaKyTinhLuong = maKyTinhLuong;
            }
            public Criteria(int maNhanVienSoNgayCV)
            {
                this.MaNhanVienSoNgayCV = maNhanVienSoNgayCV;
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
                cm.CommandText = "[spd_SelecttblnsNhanVien_SoNgayChoViec]";

                cm.Parameters.AddWithValue("@MaNhanVienSoNgayCV", criteria.MaNhanVienSoNgayCV);
                ////cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                ////cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

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
            DataPortal_Delete(new Criteria(_maNhanVienSoNgayCV));
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
                cm.CommandText = "[spd_DeletetblnsNhanVien_SoNgayChoViec]";

                //cm.Parameters.AddWithValue("@MaNhanVienSoNgayCV", criteria.MaNhanVienSoNgayCV);
                //cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                //cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

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
            _maNhanVienSoNgayCV = dr.GetInt32("MaNhanVienSoNgayCV");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _soNgayChoViec = dr.GetDecimal("SoNgayChoViec");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenKy = dr.GetString("TenKy");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn, NhanVien_SoNgayChoViecList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn, NhanVien_SoNgayChoViecList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_InserttblnsNhanVien_SoNgayChoViec]";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maNhanVienSoNgayCV = (int)cm.Parameters["@NewMaNhanVienSoNgayCV"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, NhanVien_SoNgayChoViecList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            if (_soNgayChoViec != 0)
                cm.Parameters.AddWithValue("@SoNgayChoViec", _soNgayChoViec);
            else
                cm.Parameters.AddWithValue("@SoNgayChoViec", DBNull.Value);
            //cm.Parameters.AddWithValue("@NewMaNhanVienSoNgayCV", _maNhanVienSoNgayCV);
            cm.Parameters["@NewMaNhanVienSoNgayCV"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn, NhanVien_SoNgayChoViecList parent)
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

        private void ExecuteUpdate(SqlConnection cn, NhanVien_SoNgayChoViecList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_UpdatetblnsNhanVien_SoNgayChoViec]";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, NhanVien_SoNgayChoViecList parent)
        {
            cm.Parameters.AddWithValue("@MaNhanVienSoNgayCV", _maNhanVienSoNgayCV);
            //cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            //cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            if (_soNgayChoViec != 0)
                cm.Parameters.AddWithValue("@SoNgayChoViec", _soNgayChoViec);
            else
                cm.Parameters.AddWithValue("@SoNgayChoViec", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_maNhanVienSoNgayCV));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }

}