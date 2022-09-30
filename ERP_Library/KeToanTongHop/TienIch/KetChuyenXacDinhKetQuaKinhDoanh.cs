using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KetChuyenXacDinhKetQuaKinhDoanh : Csla.BusinessBase<KetChuyenXacDinhKetQuaKinhDoanh>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private int _thuTuKC = 0;
        private string _maKetChuyen = string.Empty;
        private int _taiKhoanKC = 0;
        private int _taiKhoanNhan = 0;
        private byte _loaiKetChuyen = 0;
        private string _dienGiai = string.Empty;
        private bool _ngungSuDung = false;
        private int _MaLoaiKetChuyen = 0;


        private string _LoaiKetChuyenString = string.Empty;
        private string _taiKhoanKCString = string.Empty;
        private string _taiKhoanNhanString = string.Empty;
        private string _TenMaLoaiKetChuyen = string.Empty;

        //DataKetChuyenXDKQKD
        private decimal _GiaTri = 0;
        public decimal GiaTri
        {
            get
            {
                CanReadProperty("GiaTri", true);
                return _GiaTri;
            }
        }

        public string LoaiKetChuyenString
        {
            get
            {
                CanReadProperty("LoaiKetChuyenString", true);
                return _LoaiKetChuyenString;
            }
        }
        public string TaiKhoanKCString
        {
            get
            {
                CanReadProperty("TaiKhoanKCString", true);
                return _taiKhoanKCString;
            }
        }


        public string TaiKhoanNhanString
        {
            get
            {
                CanReadProperty("TaiKhoanNhanString", true);
                return _taiKhoanNhanString;
            }
        }

        public string TenMaLoaiKetChuyen
        {
            get
            {
                CanReadProperty("TenMaLoaiKetChuyen", true);
                return _TenMaLoaiKetChuyen;
            }
        }

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public int ThuTuKC
        {
            get
            {
                CanReadProperty("ThuTuKC", true);
                return _thuTuKC;
            }
            set
            {
                CanWriteProperty("ThuTuKC", true);
                if (!_thuTuKC.Equals(value))
                {
                    _thuTuKC = value;
                    PropertyHasChanged("ThuTuKC");
                }
            }
        }

        public string MaKetChuyen
        {
            get
            {
                CanReadProperty("MaKetChuyen", true);
                return _maKetChuyen;
            }
            set
            {
                CanWriteProperty("MaKetChuyen", true);
                if (value == null) value = string.Empty;
                if (!_maKetChuyen.Equals(value))
                {
                    _maKetChuyen = value;
                    PropertyHasChanged("MaKetChuyen");
                }
            }
        }

        public int TaiKhoanKC
        {
            get
            {
                CanReadProperty("TaiKhoanKC", true);
                return _taiKhoanKC;
            }
            set
            {
                CanWriteProperty("TaiKhoanKC", true);
                if (!_taiKhoanKC.Equals(value))
                {
                    _taiKhoanKC = value;
                    PropertyHasChanged("TaiKhoanKC");
                }
            }
        }

        public int TaiKhoanNhan
        {
            get
            {
                CanReadProperty("TaiKhoanNhan", true);
                return _taiKhoanNhan;
            }
            set
            {
                CanWriteProperty("TaiKhoanNhan", true);
                if (!_taiKhoanNhan.Equals(value))
                {
                    _taiKhoanNhan = value;
                    PropertyHasChanged("TaiKhoanNhan");
                }
            }
        }

        public byte LoaiKetChuyen
        {
            get
            {
                CanReadProperty("LoaiKetChuyen", true);
                return _loaiKetChuyen;
            }
            set
            {
                CanWriteProperty("LoaiKetChuyen", true);
                if (!_loaiKetChuyen.Equals(value))
                {
                    _loaiKetChuyen = value;
                    PropertyHasChanged("LoaiKetChuyen");
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

        public int MaLoaiKetChuyen
        {
            get
            {
                CanReadProperty("MaLoaiKetChuyen", true);
                return _MaLoaiKetChuyen;
            }
            set
            {
                CanWriteProperty("MaLoaiKetChuyen", true);
                if (!_MaLoaiKetChuyen.Equals(value))
                {
                    _MaLoaiKetChuyen = value;
                    PropertyHasChanged("MaLoaiKetChuyen");
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
            // MaKetChuyen
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaKetChuyen", 100));
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
            //TODO: Define authorization rules in KetChuyenXacDinhKetQuaKinhDoanh
            //AuthorizationRules.AllowRead("Id", "KetChuyenXacDinhKetQuaKinhDoanhReadGroup");
            //AuthorizationRules.AllowRead("ThuTuKC", "KetChuyenXacDinhKetQuaKinhDoanhReadGroup");
            //AuthorizationRules.AllowRead("MaKetChuyen", "KetChuyenXacDinhKetQuaKinhDoanhReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanKC", "KetChuyenXacDinhKetQuaKinhDoanhReadGroup");
            //AuthorizationRules.AllowRead("TaiKhoanNhan", "KetChuyenXacDinhKetQuaKinhDoanhReadGroup");
            //AuthorizationRules.AllowRead("LoaiKetChuyen", "KetChuyenXacDinhKetQuaKinhDoanhReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "KetChuyenXacDinhKetQuaKinhDoanhReadGroup");
            //AuthorizationRules.AllowRead("NgungSuDung", "KetChuyenXacDinhKetQuaKinhDoanhReadGroup");

            //AuthorizationRules.AllowWrite("ThuTuKC", "KetChuyenXacDinhKetQuaKinhDoanhWriteGroup");
            //AuthorizationRules.AllowWrite("MaKetChuyen", "KetChuyenXacDinhKetQuaKinhDoanhWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanKC", "KetChuyenXacDinhKetQuaKinhDoanhWriteGroup");
            //AuthorizationRules.AllowWrite("TaiKhoanNhan", "KetChuyenXacDinhKetQuaKinhDoanhWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiKetChuyen", "KetChuyenXacDinhKetQuaKinhDoanhWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "KetChuyenXacDinhKetQuaKinhDoanhWriteGroup");
            //AuthorizationRules.AllowWrite("NgungSuDung", "KetChuyenXacDinhKetQuaKinhDoanhWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KetChuyenXacDinhKetQuaKinhDoanh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenXacDinhKetQuaKinhDoanhViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KetChuyenXacDinhKetQuaKinhDoanh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenXacDinhKetQuaKinhDoanhAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KetChuyenXacDinhKetQuaKinhDoanh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenXacDinhKetQuaKinhDoanhEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KetChuyenXacDinhKetQuaKinhDoanh
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenXacDinhKetQuaKinhDoanhDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KetChuyenXacDinhKetQuaKinhDoanh()
        { /* require use of factory method */ }

        public static KetChuyenXacDinhKetQuaKinhDoanh NewKetChuyenXacDinhKetQuaKinhDoanh()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KetChuyenXacDinhKetQuaKinhDoanh");
            return DataPortal.Create<KetChuyenXacDinhKetQuaKinhDoanh>();
        }

        public static KetChuyenXacDinhKetQuaKinhDoanh GetKetChuyenXacDinhKetQuaKinhDoanh(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KetChuyenXacDinhKetQuaKinhDoanh");
            return DataPortal.Fetch<KetChuyenXacDinhKetQuaKinhDoanh>(new Criteria(id));
        }

        public static void DeleteKetChuyenXacDinhKetQuaKinhDoanh(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KetChuyenXacDinhKetQuaKinhDoanh");
            DataPortal.Delete(new Criteria(id));
        }

        public override KetChuyenXacDinhKetQuaKinhDoanh Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KetChuyenXacDinhKetQuaKinhDoanh");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KetChuyenXacDinhKetQuaKinhDoanh");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a KetChuyenXacDinhKetQuaKinhDoanh");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KetChuyenXacDinhKetQuaKinhDoanh NewKetChuyenXacDinhKetQuaKinhDoanhChild()
        {
            KetChuyenXacDinhKetQuaKinhDoanh child = new KetChuyenXacDinhKetQuaKinhDoanh();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KetChuyenXacDinhKetQuaKinhDoanh GetKetChuyenXacDinhKetQuaKinhDoanh(SafeDataReader dr)
        {
            KetChuyenXacDinhKetQuaKinhDoanh child = new KetChuyenXacDinhKetQuaKinhDoanh();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static KetChuyenXacDinhKetQuaKinhDoanh GetKetChuyenXacDinhKetQuaKinhDoanhForLoadDataKetChuyenXDKQKD(SafeDataReader dr)
        {
            KetChuyenXacDinhKetQuaKinhDoanh child = new KetChuyenXacDinhKetQuaKinhDoanh();
            child.MarkAsChild();
            child.FetchForLoadDataKetChuyenXDKQKD(dr);
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
                cm.CommandText = "spd_SelecttblKetChuyenXacDinhKetQuaKinhDoanh";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "spd_DeletetblKetChuyenXacDinhKetQuaKinhDoanh";

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
            _thuTuKC = dr.GetInt32("ThuTuKC");
            _maKetChuyen = dr.GetString("MaKetChuyen");
            _taiKhoanKC = dr.GetInt32("TaiKhoanKC");
            _taiKhoanNhan = dr.GetInt32("TaiKhoanNhan");
            _loaiKetChuyen = dr.GetByte("LoaiKetChuyen");
            _dienGiai = dr.GetString("DienGiai");
            _ngungSuDung = dr.GetBoolean("NgungSuDung");
            _MaLoaiKetChuyen = dr.GetInt32("MaLoaiKetChuyen");

            _LoaiKetChuyenString = dr.GetString("LoaiKetChuyenString");
            _taiKhoanKCString = dr.GetString("TaiKhoanKCString");
            _taiKhoanNhanString = dr.GetString("TaiKhoanNhanString");
            _TenMaLoaiKetChuyen = dr.GetString("TenMaLoaiKetChuyen");
        }

        private void FetchForLoadDataKetChuyenXDKQKD(SafeDataReader dr)
        {
            FetchObjectForLoadDataKetChuyenXDKQKD(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObjectForLoadDataKetChuyenXDKQKD(SafeDataReader dr)
        {
            _id = dr.GetInt32("ID");//
            _thuTuKC = dr.GetInt32("ThuTuKC");//
            _taiKhoanKC = dr.GetInt32("TaiKhoanKC");//
            _taiKhoanNhan = dr.GetInt32("TaiKhoanNhan");//
            _loaiKetChuyen = dr.GetByte("LoaiKetChuyen");//
            _dienGiai = dr.GetString("DienGiai");//
            _TenMaLoaiKetChuyen = dr.GetString("TenMaLoaiKetChuyen");//
            _GiaTri = dr.GetDecimal("GiaTri");
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
                cm.CommandText = "spd_InserttblKetChuyenXacDinhKetQuaKinhDoanh";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_thuTuKC != 0)
                cm.Parameters.AddWithValue("@ThuTuKC", _thuTuKC);
            else
                cm.Parameters.AddWithValue("@ThuTuKC", DBNull.Value);
            if (_maKetChuyen.Length > 0)
                cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaKetChuyen", DBNull.Value);
            if (_taiKhoanKC != 0)
                cm.Parameters.AddWithValue("@TaiKhoanKC", _taiKhoanKC);
            else
                cm.Parameters.AddWithValue("@TaiKhoanKC", DBNull.Value);
            if (_taiKhoanNhan != 0)
                cm.Parameters.AddWithValue("@TaiKhoanNhan", _taiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNhan", DBNull.Value);
            if (_loaiKetChuyen != 0)
                cm.Parameters.AddWithValue("@LoaiKetChuyen", _loaiKetChuyen);
            else
                cm.Parameters.AddWithValue("@LoaiKetChuyen", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_ngungSuDung != false)
                cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            else
                cm.Parameters.AddWithValue("@NgungSuDung", DBNull.Value);

            if (_MaLoaiKetChuyen != 0)
                cm.Parameters.AddWithValue("@MaLoaiKetChuyen", _MaLoaiKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaLoaiKetChuyen", DBNull.Value);

            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblKetChuyenXacDinhKetQuaKinhDoanh";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_thuTuKC != 0)
                cm.Parameters.AddWithValue("@ThuTuKC", _thuTuKC);
            else
                cm.Parameters.AddWithValue("@ThuTuKC", DBNull.Value);
            if (_maKetChuyen.Length > 0)
                cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaKetChuyen", DBNull.Value);
            if (_taiKhoanKC != 0)
                cm.Parameters.AddWithValue("@TaiKhoanKC", _taiKhoanKC);
            else
                cm.Parameters.AddWithValue("@TaiKhoanKC", DBNull.Value);
            if (_taiKhoanNhan != 0)
                cm.Parameters.AddWithValue("@TaiKhoanNhan", _taiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNhan", DBNull.Value);
            if (_loaiKetChuyen != 0)
                cm.Parameters.AddWithValue("@LoaiKetChuyen", _loaiKetChuyen);
            else
                cm.Parameters.AddWithValue("@LoaiKetChuyen", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_ngungSuDung != false)
                cm.Parameters.AddWithValue("@NgungSuDung", _ngungSuDung);
            else
                cm.Parameters.AddWithValue("@NgungSuDung", DBNull.Value);

            if (_MaLoaiKetChuyen != 0)
                cm.Parameters.AddWithValue("@MaLoaiKetChuyen", _MaLoaiKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaLoaiKetChuyen", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
