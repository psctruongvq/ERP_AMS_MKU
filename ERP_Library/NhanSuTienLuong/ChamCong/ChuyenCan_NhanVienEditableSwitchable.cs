
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
    public class ChuyenCan_NhanVien : Csla.BusinessBase<ChuyenCan_NhanVien>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChuyenCanNhanVien = 0;
        private long _maNhanVien = 0;
        private int _maKyTinhLuong = 0;
        private byte _loaiChuyenCan = 0;
        private string _chuyenCan = string.Empty;

        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenKy = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChuyenCanNhanVien
        {
            get
            {
                CanReadProperty("MaChuyenCanNhanVien", true);
                return _maChuyenCanNhanVien;
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

        public byte LoaiChuyenCan
        {
            get
            {
                CanReadProperty("LoaiChuyenCan", true);
                return _loaiChuyenCan;
            }
            set
            {
                CanWriteProperty("LoaiChuyenCan", true);
                if (!_loaiChuyenCan.Equals(value))
                {
                    _loaiChuyenCan = value;
                    PropertyHasChanged("LoaiChuyenCan");
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
        public string ChuyenCan
        {
            get
            {
                CanReadProperty("ChuyenCan", true);
                return _chuyenCan;
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
            return string.Format("{0}:{1}:{2}", _maChuyenCanNhanVien, _maNhanVien, _maKyTinhLuong);
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
            //TODO: Define authorization rules in ChuyenCan_NhanVien
            //AuthorizationRules.AllowRead("MaChuyenCanNhanVien", "ChuyenCan_NhanVienReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "ChuyenCan_NhanVienReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "ChuyenCan_NhanVienReadGroup");
            //AuthorizationRules.AllowRead("LoaiChuyenCan", "ChuyenCan_NhanVienReadGroup");

            //AuthorizationRules.AllowWrite("LoaiChuyenCan", "ChuyenCan_NhanVienWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuyenCan_NhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenCan_NhanVienViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuyenCan_NhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenCan_NhanVienAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuyenCan_NhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenCan_NhanVienEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuyenCan_NhanVien
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenCan_NhanVienDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuyenCan_NhanVien()
        { /* require use of factory method */ }

        public static ChuyenCan_NhanVien NewChuyenCan_NhanVien()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuyenCan_NhanVien");
            return DataPortal.Create<ChuyenCan_NhanVien>();
        }

        public static ChuyenCan_NhanVien GetChuyenCan_NhanVien(int maChuyenCanNhanVien, long maNhanVien, int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuyenCan_NhanVien");
            return DataPortal.Fetch<ChuyenCan_NhanVien>(new Criteria(maChuyenCanNhanVien, maNhanVien, maKyTinhLuong));
        }

        public static void DeleteChuyenCan_NhanVien(int maChuyenCanNhanVien, long maNhanVien, int maKyTinhLuong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChuyenCan_NhanVien");
            DataPortal.Delete(new Criteria(maChuyenCanNhanVien, maNhanVien, maKyTinhLuong));
        }
        public static void TinhChuyenCan(int maKy,int maBoPhan)
        {
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhChuyenCanNV";

                //AddUpdateParameters(cm, parent);

                cm.Parameters.AddWithValue("@MaKyTinhLuong", maKy);
                cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                //cm.Parameters.AddWithValue("@NhaMay", "");//Properties.Settings.Default.NhaMay);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }//using
        }
        public static void TinhChuyenCanTungNhanVien(int maKy,long maNhanVien,byte loaiChuyenCan)
        {
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhChuyenCanTungNV";

                //AddUpdateParameters(cm, parent);

                cm.Parameters.AddWithValue("@MaKyTinhLuong", maKy);
                cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);//Properties.Settings.Default.NhaMay);
                cm.Parameters.AddWithValue("@LoaiChuyenCan", loaiChuyenCan);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }//using
        }
        public override ChuyenCan_NhanVien Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChuyenCan_NhanVien");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuyenCan_NhanVien");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChuyenCan_NhanVien");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChuyenCan_NhanVien NewChuyenCan_NhanVienChild()
        {
            ChuyenCan_NhanVien child = new ChuyenCan_NhanVien();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChuyenCan_NhanVien GetChuyenCan_NhanVien(SafeDataReader dr)
        {
            ChuyenCan_NhanVien child = new ChuyenCan_NhanVien();
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
            public int MaChuyenCanNhanVien;
            public long MaNhanVien;
            public int MaKyTinhLuong;
            public int MaBoPhan;

            public Criteria(int maChuyenCanNhanVien, long maNhanVien, int maKyTinhLuong)
            {
                this.MaChuyenCanNhanVien = maChuyenCanNhanVien;
                this.MaNhanVien = maNhanVien;
                this.MaKyTinhLuong = maKyTinhLuong;
            }
            public Criteria(int maChuyenCanNhanVien, int maBoPhan)
            {
                this.MaChuyenCanNhanVien = maChuyenCanNhanVien;
                this.MaBoPhan = maBoPhan;
            }
            public Criteria(int maChuyenCanNhanVien)
            {
                this.MaChuyenCanNhanVien = maChuyenCanNhanVien;

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
                cm.CommandText = "spd_SelecttblnsChuyenCan_NhanVien";

                cm.Parameters.AddWithValue("@MaChuyenCanNhanVien", criteria.MaChuyenCanNhanVien);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                //cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                //cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

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
            DataPortal_Delete(new Criteria(_maChuyenCanNhanVien));
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
                cm.CommandText = "spd_DeletetblnsChuyenCan_NhanVien";

                cm.Parameters.AddWithValue("@MaChuyenCanNhanVien", criteria.MaChuyenCanNhanVien);

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
            _maChuyenCanNhanVien = dr.GetInt32("MaChuyenCanNhanVien");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _loaiChuyenCan = dr.GetByte("LoaiChuyenCan");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenKy = dr.GetString("TenKy");
            _chuyenCan = dr.GetString("ChuyenCan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn, ChuyenCan_NhanVienList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn, ChuyenCan_NhanVienList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsChuyenCan_NhanVien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChuyenCanNhanVien = (int)cm.Parameters["@MaChuyenCanNhanVien"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChuyenCan_NhanVienList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            if (_loaiChuyenCan != 0)
                cm.Parameters.AddWithValue("@LoaiChuyenCan", _loaiChuyenCan);
            else
                cm.Parameters.AddWithValue("@LoaiChuyenCan", DBNull.Value);
            //cm.Parameters.AddWithValue("@NewMaChuyenCanNhanVien", _maChuyenCanNhanVien);
            cm.Parameters["@MaChuyenCanNhanVien"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn, ChuyenCan_NhanVienList parent)
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

        private void ExecuteUpdate(SqlConnection cn, ChuyenCan_NhanVienList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsChuyenCan_NhanVien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChuyenCan_NhanVienList parent)
        {
            cm.Parameters.AddWithValue("@MaChuyenCanNhanVien", _maChuyenCanNhanVien);
            //cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            //cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            if (_loaiChuyenCan != 0)
                cm.Parameters.AddWithValue("@LoaiChuyenCan", _loaiChuyenCan);
            else
                cm.Parameters.AddWithValue("@LoaiChuyenCan", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_maChuyenCanNhanVien));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }

}