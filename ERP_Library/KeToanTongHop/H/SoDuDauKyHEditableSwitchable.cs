using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKyH : Csla.BusinessBase<SoDuDauKyH>
    {
        #region Business Properties and Methods

        //declare members
        private int _maSoDuDauKy = 0;
        private int _maKy = 0;
        private int _maTaiKhoan = 0;
        private decimal _soDuDauKyCo = 0;
        private decimal _soDuDauKyNo = 0;
        private decimal _phatSinhTrongKyNo = 0;
        private decimal _phatSinhTrongKyCo = 0;
        private decimal _luyKeNo = 0;
        private decimal _luyKeCo = 0;
        private int _maBoPhan = 0;
        private int _nam = 0;
        private int _maTaiKhoanCha = 0;
        private string _soHieuTK = string.Empty;
        private bool _coTheoDoiDoiTuong = false;
        private int _maTK_KeToan_NganHang = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaSoDuDauKy
        {
            get
            {
                CanReadProperty("MaSoDuDauKy", true);
                return _maSoDuDauKy;
            }
        }

        public bool CoTheoDoiDoiTuong
        {
            get
            {
                CanReadProperty("CoTheoDoiDoiTuong", true);
                return _coTheoDoiDoiTuong;
            }
        }
        public int MaTK_KeToan_NganHang
        {
            get
            {
                CanReadProperty("MaTK_KeToan_NganHang", true);
                return _maTK_KeToan_NganHang;
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

        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoan", true);
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    _TenTaiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKhoan).TenTaiKhoan;
                    PropertyHasChanged("MaTaiKhoan");
                }
            }
        }

        public int MaTaiKhoanCha
        {
            get
            {
                CanReadProperty("MaTaiKhoanCha", true);
                return _maTaiKhoanCha;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanCha", true);
                if (!_maTaiKhoanCha.Equals(value))
                {
                    _maTaiKhoanCha = value;
                    PropertyHasChanged("MaTaiKhoanCha");
                }
            }
        }


        public decimal SoDuDauKyCo
        {
            get
            {
                CanReadProperty("SoDuDauKyCo", true);
                return _soDuDauKyCo;
            }
            set
            {
                CanWriteProperty("SoDuDauKyCo", true);
                if (!_soDuDauKyCo.Equals(value))
                {
                    _soDuDauKyCo = value;
                    PropertyHasChanged("SoDuDauKyCo");
                }
            }
        }

        public decimal SoDuDauKyNo
        {
            get
            {
                CanReadProperty("SoDuDauKyNo", true);
                return _soDuDauKyNo;
            }
            set
            {
                CanWriteProperty("SoDuDauKyNo", true);
                if (!_soDuDauKyNo.Equals(value))
                {
                    _soDuDauKyNo = value;
                    PropertyHasChanged("SoDuDauKyNo");
                }
            }
        }

        public decimal PhatSinhTrongKyNo
        {
            get
            {
                CanReadProperty("PhatSinhTrongKyNo", true);
                return _phatSinhTrongKyNo;
            }
            set
            {
                CanWriteProperty("PhatSinhTrongKyNo", true);
                if (!_phatSinhTrongKyNo.Equals(value))
                {
                    _phatSinhTrongKyNo = value;
                    PropertyHasChanged("PhatSinhTrongKyNo");
                }
            }
        }

        public decimal PhatSinhTrongKyCo
        {
            get
            {
                CanReadProperty("PhatSinhTrongKyCo", true);
                return _phatSinhTrongKyCo;
            }
            set
            {
                CanWriteProperty("PhatSinhTrongKyCo", true);
                if (!_phatSinhTrongKyCo.Equals(value))
                {
                    _phatSinhTrongKyCo = value;
                    PropertyHasChanged("PhatSinhTrongKyCo");
                }
            }
        }

        public decimal LuyKeNo
        {
            get
            {
                CanReadProperty("LuyKeNo", true);
                return _luyKeNo;
            }
            set
            {
                CanWriteProperty("LuyKeNo", true);
                if (!_luyKeNo.Equals(value))
                {
                    _luyKeNo = value;
                    PropertyHasChanged("LuyKeNo");
                }
            }
        }

        public decimal LuyKeCo
        {
            get
            {
                CanReadProperty("LuyKeCo", true);
                return _luyKeCo;
            }
            set
            {
                CanWriteProperty("LuyKeCo", true);
                if (!_luyKeCo.Equals(value))
                {
                    _luyKeCo = value;
                    PropertyHasChanged("LuyKeCo");
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

        public int Nam
        {
            get
            {
                CanReadProperty("Nam", true);
                return _nam;
            }
            set
            {
                CanWriteProperty("Nam", true);
                if (!_nam.Equals(value))
                {
                    _nam = value;
                    PropertyHasChanged("Nam");
                }
            }
        }

        string _TenTaiKhoan;
        public string TenTaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _TenTaiKhoan;
            }
        }
              
        public string SoHieuTK
        {
            get
            {
                CanReadProperty(true);
                return _soHieuTK;
            }
        }


        protected override object GetIdValue()
        {
            return _maSoDuDauKy;
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
            //TODO: Define authorization rules in SoDuDauKyH
            //AuthorizationRules.AllowRead("MaSoDuDauKy", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKyCo", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKyNo", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("PhatSinhTrongKyNo", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("PhatSinhTrongKyCo", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("LuyKeNo", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("LuyKeCo", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "SoDuDauKyHReadGroup");
            //AuthorizationRules.AllowRead("Nam", "SoDuDauKyHReadGroup");

            //AuthorizationRules.AllowWrite("MaKy", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoan", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("SoDuDauKyCo", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("SoDuDauKyNo", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("PhatSinhTrongKyNo", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("PhatSinhTrongKyCo", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeNo", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeCo", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "SoDuDauKyHWriteGroup");
            //AuthorizationRules.AllowWrite("Nam", "SoDuDauKyHWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKyH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKyH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKyH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKyH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKyH()
        { /* require use of factory method */ }

        public static SoDuDauKyH NewSoDuDauKyH()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyH");
            return DataPortal.Create<SoDuDauKyH>();
        }

        public static SoDuDauKyH GetSoDuDauKyH(int maSoDuDauKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyH");
            return DataPortal.Fetch<SoDuDauKyH>(new Criteria(maSoDuDauKy));
        }

        public static void DeleteSoDuDauKyH(int maSoDuDauKy)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKyH");
            DataPortal.Delete(new Criteria(maSoDuDauKy));
        }

        public override SoDuDauKyH Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKyH");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyH");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a SoDuDauKyH");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static SoDuDauKyH NewSoDuDauKyHChild()
        {
            SoDuDauKyH child = new SoDuDauKyH();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static SoDuDauKyH GetSoDuDauKyH(SafeDataReader dr)
        {
            SoDuDauKyH child = new SoDuDauKyH();
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
            public int MaSoDuDauKy;

            public Criteria(int maSoDuDauKy)
            {
                this.MaSoDuDauKy = maSoDuDauKy;
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
                cm.CommandText = "spd_LoadMaCaBiet_SoDuDauKy";//"sdp_GetSoDuDauKyH";

                cm.Parameters.AddWithValue("@MaSoDuDauKy", criteria.MaSoDuDauKy);

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
            DataPortal_Delete(new Criteria(_maSoDuDauKy));
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
                cm.CommandText = "spd_DeletetblSoDuDauKy";

                cm.Parameters.AddWithValue("@MaSoDuDauKy", criteria.MaSoDuDauKy);

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
            _maSoDuDauKy = dr.GetInt32("MaSoDuDauKy");
            _maKy = dr.GetInt32("MaKy");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _soDuDauKyCo = dr.GetDecimal("SoDuDauKyCo");
            _soDuDauKyNo = dr.GetDecimal("SoDuDauKyNo");
            _phatSinhTrongKyNo = dr.GetDecimal("PhatSinhTrongKyNo");
            _phatSinhTrongKyCo = dr.GetDecimal("PhatSinhTrongKyCo");
            _luyKeNo = dr.GetDecimal("LuyKeNo");
            _luyKeCo = dr.GetDecimal("LuyKeCo");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _nam = dr.GetInt32("Nam");
            _maTaiKhoanCha = dr.GetInt32("MaTaiKhoanCha");
            _TenTaiKhoan = dr.GetString("TenTaiKhoan");
            _soHieuTK = dr.GetString("SoHieuTK");
            _coTheoDoiDoiTuong = dr.GetBoolean("coTheoDoiDoiTuong");
            _maTK_KeToan_NganHang = dr.GetInt32("maTK_KeToan_NganHang");
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
            MarkAsChild();
            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblSoDuDauKyH";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maSoDuDauKy = (int)cm.Parameters["@MaSoDuDauKy"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKy", _maKy);
            cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            if (_soDuDauKyCo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyCo", DBNull.Value);
            if (_soDuDauKyNo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyNo", DBNull.Value);
            if (_phatSinhTrongKyNo != 0)
                cm.Parameters.AddWithValue("@PhatSinhTrongKyNo", _phatSinhTrongKyNo);
            else
                cm.Parameters.AddWithValue("@PhatSinhTrongKyNo", DBNull.Value);
            if (_phatSinhTrongKyCo != 0)
                cm.Parameters.AddWithValue("@PhatSinhTrongKyCo", _phatSinhTrongKyCo);
            else
                cm.Parameters.AddWithValue("@PhatSinhTrongKyCo", DBNull.Value);
            if (_luyKeNo != 0)
                cm.Parameters.AddWithValue("@LuyKeNo", _luyKeNo);
            else
                cm.Parameters.AddWithValue("@LuyKeNo", DBNull.Value);
            if (_luyKeCo != 0)
                cm.Parameters.AddWithValue("@LuyKeCo", _luyKeCo);
            else
                cm.Parameters.AddWithValue("@LuyKeCo", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_nam != 0)
                cm.Parameters.AddWithValue("@Nam", _nam);
            else
                cm.Parameters.AddWithValue("@Nam", DBNull.Value);
            cm.Parameters.AddWithValue("@MaSoDuDauKy", _maSoDuDauKy);
            cm.Parameters["@MaSoDuDauKy"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn)
        {
            if (!IsDirty) return;

            if (this.MaSoDuDauKy == 0)
            {
                Insert(cn);
                return;
            }

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
                cm.CommandText = "spd_UpdatetblSoDuDauKyH";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaSoDuDauKy", _maSoDuDauKy);
            cm.Parameters.AddWithValue("@MaKy", _maKy);
            cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            if (_soDuDauKyCo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyCo", DBNull.Value);
            if (_soDuDauKyNo != 0)
                cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            else
                cm.Parameters.AddWithValue("@SoDuDauKyNo", DBNull.Value);
            if (_phatSinhTrongKyNo != 0)
                cm.Parameters.AddWithValue("@PhatSinhTrongKyNo", _phatSinhTrongKyNo);
            else
                cm.Parameters.AddWithValue("@PhatSinhTrongKyNo", DBNull.Value);
            if (_phatSinhTrongKyCo != 0)
                cm.Parameters.AddWithValue("@PhatSinhTrongKyCo", _phatSinhTrongKyCo);
            else
                cm.Parameters.AddWithValue("@PhatSinhTrongKyCo", DBNull.Value);
            if (_luyKeNo != 0)
                cm.Parameters.AddWithValue("@LuyKeNo", _luyKeNo);
            else
                cm.Parameters.AddWithValue("@LuyKeNo", DBNull.Value);
            if (_luyKeCo != 0)
                cm.Parameters.AddWithValue("@LuyKeCo", _luyKeCo);
            else
                cm.Parameters.AddWithValue("@LuyKeCo", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_nam != 0)
                cm.Parameters.AddWithValue("@Nam", _nam);
            else
                cm.Parameters.AddWithValue("@Nam", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_maSoDuDauKy));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
