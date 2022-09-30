
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThueTNCNKy3 : Csla.BusinessBase<ThueTNCNKy3>
    {
        #region Business Properties and Methods

        //declare members
        private long _thueID = 0;
        private int _maKyTinhLuong = 0;
        private int _maBoPhan = 0;
        private long _maNhanVien = 0;
        private decimal _tongThuNhap = 0;
        private decimal _thueTNCNKy3 = 0;
        private decimal _thueTNCNKy2 = 0;
        private decimal _thueDaNop = 0;
        private decimal _conLai = 0;
        private string _tenNhanVien = "";
        private decimal _giamTru = 0;
        private decimal _chiuThue = 0;
        private string _tenBoPhan = "";
        private decimal _tongThuNhapTinhThue = 0;
        private decimal _tnKy2 = 0;
        private decimal _tnTinhThueKy2 = 0;
        private decimal _thuLao = 0;
        private decimal _phuCap = 0;
        private decimal _khenThuong = 0;
        private decimal _khenThuongTinhThue = 0;
        private decimal _thueTamThu = 0;
        private decimal _tongThueTNCN = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long ThueID
        {
            get
            {
                return _thueID;
            }
        }

        public int MaKyTinhLuong
        {
            get
            {
                return _maKyTinhLuong;
            }
            set
            {
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
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
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public decimal TongThuNhap
        {
            get
            {
                return _tongThuNhap;
            }
            set
            {
                if (!_tongThuNhap.Equals(value))
                {
                    _tongThuNhap = value;
                    PropertyHasChanged("TongThuNhap");
                }
            }
        }

        public decimal TongThuNhapTinhThue
        {
            get
            {
                return _tongThuNhapTinhThue;
            }
            set
            {
                if (!_tongThuNhapTinhThue.Equals(value))
                {
                    _tongThuNhapTinhThue = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal TNKy2
        {
            get
            {
                return _tnKy2;
            }
            set
            {
                if (!_tnKy2.Equals(value))
                {
                    _tnKy2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal TNTinhThueKy2
        {
            get
            {
                return _tnTinhThueKy2;
            }
            set
            {
                if (!_tnTinhThueKy2.Equals(value))
                {
                    _tnTinhThueKy2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal ThuLao
        {
            get
            {
                return _thuLao;
            }
            set
            {
                if (!_thuLao.Equals(value))
                {
                    _thuLao = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal PhuCap
        {
            get
            {
                return _phuCap;
            }
            set
            {
                if (!_phuCap.Equals(value))
                {
                    _phuCap = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal KhenThuong
        {
            get
            {
                return _khenThuong;
            }
            set
            {
                if (!_khenThuong.Equals(value))
                {
                    _khenThuong = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal KhenThuongTinhThue
        {
            get
            {
                return _khenThuongTinhThue;
            }
            set
            {
                if (!_khenThuongTinhThue.Equals(value))
                {
                    _khenThuongTinhThue = value;
                    PropertyHasChanged();
                }
            }
        }
        
        public decimal TienThueTNCNKy3
        {
            get
            {
                return _thueTNCNKy3;
            }
            set
            {
                if (!_thueTNCNKy3.Equals(value))
                {
                    _thueTNCNKy3 = value;
                    PropertyHasChanged("TienThueTNCNKy3");
                }
            }
        }

        public decimal ThueTNCNKy2
        {
            get
            {
                return _thueTNCNKy2;
            }
            set
            {
                if (!_thueTNCNKy2.Equals(value))
                {
                    _thueTNCNKy2 = value;
                    PropertyHasChanged("ThueTNCNKy2");
                }
            }
        }

        public decimal ThueDaNop
        {
            get
            {
                return _thueDaNop;
            }
            set
            {
                if (!_thueDaNop.Equals(value))
                {
                    _thueDaNop = value;
                    PropertyHasChanged("ThueDaNop");
                }
            }
        }

        public decimal ConLai
        {
            get
            {
                return _conLai;
            }
            set
            {
                if (!_conLai.Equals(value))
                {
                    _conLai = value;
                    PropertyHasChanged("ConLai");
                }
            }
        }

        public decimal GiamTru
        {
            get
            {
                return _giamTru;
            }
            set
            {
                if (!_giamTru.Equals(value))
                {
                    _giamTru = value;
                    PropertyHasChanged("GiamTru");
                }
            }
        }

        public decimal ChiuThue
        {
            get
            {
                return _chiuThue;
            }
            set
            {
                if (!_chiuThue.Equals(value))
                {
                    _chiuThue = value;
                    PropertyHasChanged("ChiuThue");
                }
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        protected override object GetIdValue()
        {
            return _thueID;
        }


        public decimal ThueTamThu
        {
            get
            {
                return _thueTamThu;
            }
            set
            {
                if (!_thueTamThu.Equals(value))
                {
                    _thueTamThu = value;
                    PropertyHasChanged("ThueTamThu");
                }
            }
        }

        public decimal TongThueTNCN
        {
            get
            {
                return _tongThueTNCN;
            }
            set
            {
                if (!_tongThueTNCN.Equals(value))
                {
                    _tongThueTNCN = value;
                    PropertyHasChanged("TongThueTNCN");
                }
            }
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

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThueTNCNKy3
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNKy3ViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThueTNCNKy3
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNKy3AddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThueTNCNKy3
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNKy3EditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThueTNCNKy3
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNKy3DeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public ThueTNCNKy3()
        { /* require use of factory method */ }

        public static ThueTNCNKy3 NewThueTNCNKy3()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThueTNCNKy3");
            return DataPortal.Create<ThueTNCNKy3>();
        }

        public static ThueTNCNKy3 GetThueTNCNKy3(long thueID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThueTNCNKy3");
            return DataPortal.Fetch<ThueTNCNKy3>(new Criteria(thueID));
        }

        public static void DeleteThueTNCNKy3(long thueID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThueTNCNKy3");
            DataPortal.Delete(new Criteria(thueID));
        }

        public override ThueTNCNKy3 Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThueTNCNKy3");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThueTNCNKy3");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThueTNCNKy3");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ThueTNCNKy3 NewThueTNCNKy3Child()
        {
            ThueTNCNKy3 child = new ThueTNCNKy3();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ThueTNCNKy3 GetThueTNCNKy3(SafeDataReader dr)
        {
            ThueTNCNKy3 child = new ThueTNCNKy3();
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
            public long ThueID;

            public Criteria(long thueID)
            {
                this.ThueID = thueID;
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
                cm.CommandText = "spd_Select_ThueTNCNKy3";

                cm.Parameters.AddWithValue("@ThueID", criteria.ThueID);

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
            DataPortal_Delete(new Criteria(_thueID));
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
                cm.CommandText = "spd_Delete_ThueTNCNKy3";

                cm.Parameters.AddWithValue("@ThueID", criteria.ThueID);

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
            _thueID = dr.GetInt64("ThueID");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tongThuNhap = dr.GetDecimal("TongThuNhap");
            _tongThuNhapTinhThue = dr.GetDecimal("TongThuNhapTinhThue");
            _tnKy2 = dr.GetDecimal("TNKy2");
            _tnTinhThueKy2 = dr.GetDecimal("TNTinhThueKy2");
            _thuLao = dr.GetDecimal("ThuLao");
            _phuCap = dr.GetDecimal("PhuCap");
            _khenThuong = dr.GetDecimal("KhenThuong");
            _khenThuongTinhThue = dr.GetDecimal("KhenThuongTinhThue");
            _thueTNCNKy3 = dr.GetDecimal("ThueTNCNKy3");
            _thueTNCNKy2 = dr.GetDecimal("ThueTNCNKy2");
            _thueDaNop = dr.GetDecimal("ThueDaNop");
            _conLai = dr.GetDecimal("ConLai");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _giamTru = dr.GetDecimal("GiamTru");
            _chiuThue = dr.GetDecimal("ChiuThue");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _thueTamThu = dr.GetDecimal("ThueTamThu");
            _tongThueTNCN = dr.GetDecimal("TongThueTNCN");
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
                cm.CommandText = "spd_Insert_ThueTNCNKy3";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _thueID = (long)cm.Parameters["@ThueID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@TongThuNhap", _tongThuNhap);
            cm.Parameters.AddWithValue("@ThueTNCNKy3", _thueTNCNKy3);
            cm.Parameters.AddWithValue("@ThueTNCNKy2", _thueTNCNKy2);
            cm.Parameters.AddWithValue("@ThueDaNop", _thueDaNop);
            cm.Parameters.AddWithValue("@ConLai", _conLai);
            cm.Parameters.AddWithValue("@ThueID", _thueID);
            cm.Parameters.AddWithValue("@GiamTru", _giamTru);
            cm.Parameters.AddWithValue("@ChiuThue", _chiuThue);
            cm.Parameters.AddWithValue("@TNKy2", _tnKy2);
            cm.Parameters.AddWithValue("@TNTinhThueKy2", _tnTinhThueKy2);
            cm.Parameters.AddWithValue("@ThuLao", _thuLao);
            cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            cm.Parameters.AddWithValue("@KhenThuongTinhThue", _khenThuongTinhThue);
            cm.Parameters.AddWithValue("@TongThuNhapTinhThue", _tongThuNhapTinhThue);
            cm.Parameters.AddWithValue("@ThueTamThu", _thueTamThu);
            cm.Parameters["@ThueID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_ThueTNCNKy3";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ThueID", _thueID);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@TongThuNhap", _tongThuNhap);
            cm.Parameters.AddWithValue("@ThueTNCNKy3", _thueTNCNKy3);
            cm.Parameters.AddWithValue("@ThueTNCNKy2", _thueTNCNKy2);
            cm.Parameters.AddWithValue("@ThueDaNop", _thueDaNop);
            cm.Parameters.AddWithValue("@ConLai", _conLai);
            cm.Parameters.AddWithValue("@GiamTru", _giamTru);
            cm.Parameters.AddWithValue("@ChiuThue", _chiuThue);
            cm.Parameters.AddWithValue("@TNKy2", _tnKy2);
            cm.Parameters.AddWithValue("@TNTinhThueKy2", _tnTinhThueKy2);
            cm.Parameters.AddWithValue("@ThuLao", _thuLao);
            cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            cm.Parameters.AddWithValue("@KhenThuongTinhThue", _khenThuongTinhThue);
            cm.Parameters.AddWithValue("@TongThuNhapTinhThue", _tongThuNhapTinhThue);
            cm.Parameters.AddWithValue("@ThueTamThu", _thueTamThu);
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

            ExecuteDelete(tr, new Criteria(_thueID));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
