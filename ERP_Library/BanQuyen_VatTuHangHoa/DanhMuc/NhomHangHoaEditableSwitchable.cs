
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhomHangHoaBQ_VT : Csla.BusinessBase<NhomHangHoaBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNhomHangHoa = 0;
        private string _maQuanLy = string.Empty;
        private string _tenNhomHangHoa = string.Empty;
        private string _dienGiai = string.Empty;
        private bool _tinhTrang = true;
        private int _maLoaiVatTuHH = 0;
        private int _maNhomHangHoaCha = 0;
        private int _thoiGianPhanBo = 0;//tính bằng tháng

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaNhomHangHoa
        {
            get
            {
                CanReadProperty("MaNhomHangHoa", true);
                return _maNhomHangHoa;
            }
        }

        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }

        public string TenNhomHangHoa
        {
            get
            {
                CanReadProperty("TenNhomHangHoa", true);
                return _tenNhomHangHoa;
            }
            set
            {
                CanWriteProperty("TenNhomHangHoa", true);
                if (value == null) value = string.Empty;
                if (!_tenNhomHangHoa.Equals(value))
                {
                    _tenNhomHangHoa = value;
                    PropertyHasChanged("TenNhomHangHoa");
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

        public bool TinhTrang
        {
            get
            {
                CanReadProperty("TinhTrang", true);
                return _tinhTrang;
            }
            set
            {
                CanWriteProperty("TinhTrang", true);
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    PropertyHasChanged("TinhTrang");
                }
            }
        }

        public int MaLoaiVatTuHH
        {
            get
            {
                CanReadProperty("MaLoaiVatTuHH", true);
                return _maLoaiVatTuHH;
            }
            set
            {
                CanWriteProperty("MaLoaiVatTuHH", true);
                if (!_maLoaiVatTuHH.Equals(value))
                {
                    _maLoaiVatTuHH = value;
                    PropertyHasChanged("MaLoaiVatTuHH");
                }
            }
        }

        public int MaNhomHangHoaCha
        {
            get
            {
                CanReadProperty("MaNhomHangHoaCha", true);
                return _maNhomHangHoaCha;
            }
            set
            {
                CanWriteProperty("MaNhomHangHoaCha", true);
                if (!_maNhomHangHoaCha.Equals(value))
                {
                    _maNhomHangHoaCha = value;
                    PropertyHasChanged("MaNhomHangHoaCha");
                }
            }
        }

        public int ThoiGianPhanBo
        {
            get
            {
                CanReadProperty("ThoiGianPhanBo", true);
                return _thoiGianPhanBo;
            }
            set
            {
                CanWriteProperty("ThoiGianPhanBo", true);
                if (!_thoiGianPhanBo.Equals(value))
                {
                    _thoiGianPhanBo = value;
                    PropertyHasChanged("ThoiGianPhanBo");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNhomHangHoa;
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
            // MaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
            //
            // TenNhomHangHoa
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenNhomHangHoa");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomHangHoa", 100));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
            //TODO: Define authorization rules in NhomHangHoaBQ_VT
            //AuthorizationRules.AllowRead("MaNhomHangHoa", "NhomHangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "NhomHangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenNhomHangHoa", "NhomHangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "NhomHangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "NhomHangHoaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiVatTuHH", "NhomHangHoaBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "NhomHangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenNhomHangHoa", "NhomHangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "NhomHangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "NhomHangHoaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiVatTuHH", "NhomHangHoaBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomHangHoaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHangHoaBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomHangHoaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHangHoaBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomHangHoaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHangHoaBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomHangHoaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHangHoaBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhomHangHoaBQ_VT()
        { /* require use of factory method */
            base.MarkAsChild();
        }

        public static NhomHangHoaBQ_VT NewNhomHangHoaBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomHangHoaBQ_VT");
            return DataPortal.Create<NhomHangHoaBQ_VT>();
        }

        public static NhomHangHoaBQ_VT GetNhomHangHoaBQ_VT(int maNhomHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHangHoaBQ_VT");
            return DataPortal.Fetch<NhomHangHoaBQ_VT>(new Criteria(maNhomHangHoa));
        }

        public static NhomHangHoaBQ_VT GetNhomHangHoaBQ_VT(string tenNhomHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHangHoaBQ_VT");
            return DataPortal.Fetch<NhomHangHoaBQ_VT>(new Criteria_TenNhomHangHoa(tenNhomHangHoa));
        }

        public static void DeleteNhomHangHoaBQ_VT(int maNhomHangHoa)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomHangHoaBQ_VT");
            DataPortal.Delete(new Criteria(maNhomHangHoa));
        }

        public override NhomHangHoaBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomHangHoaBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomHangHoaBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhomHangHoaBQ_VT");

            return base.Save();
        }
        public static bool KiemTraNhomHH_CoTonTaiNhomHHCon(int maNhom)
        {
            bool gt = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraNhomHH_CoTonTaiNhomHHCon";
                        cm.Parameters.AddWithValue("@MaNhom", maNhom);
                        object gtTraVe = cm.ExecuteScalar();
                        if (gtTraVe != null)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        public static int DemHangHoaCon(int maNhom)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DemHangHoaCon";
                        cm.Parameters.AddWithValue("@MaNhom", maNhom);
                        int gtTraVe = (int)cm.ExecuteScalar();

                        return gtTraVe;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }//using
        }
        public static bool KiemTraNhomHH_CoTonTaiHangHoaCon(int maNhom)
        {
            bool gt = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraNhomHH_CoTonTaiHangHoaCon";
                        cm.Parameters.AddWithValue("@MaNhom", maNhom);
                        object gtTraVe = cm.ExecuteScalar();
                        if (gtTraVe != null)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NhomHangHoaBQ_VT NewNhomHangHoaBQ_VTChild()
        {
            NhomHangHoaBQ_VT child = new NhomHangHoaBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhomHangHoaBQ_VT GetNhomHangHoaBQ_VT(SafeDataReader dr)
        {
            NhomHangHoaBQ_VT child = new NhomHangHoaBQ_VT();
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
            public int MaNhomHangHoa;

            public Criteria(int maNhomHangHoa)
            {
                this.MaNhomHangHoa = maNhomHangHoa;
            }
        }

        [Serializable()]
        private class Criteria_TenNhomHangHoa
        {
            public string TenNhomHangHoa;

            public Criteria_TenNhomHangHoa(string tenNhomHangHoa)
            {
                this.TenNhomHangHoa = tenNhomHangHoa;
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
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblNhomHangHoa";
                    cm.Parameters.AddWithValue("@MaNhomHangHoa", ((Criteria)criteria).MaNhomHangHoa);
                }
                if (criteria is Criteria_TenNhomHangHoa)
                {
                    cm.CommandText = "spd_SelecttblNhomHangHoa_TenNhomHangHoa";
                    cm.Parameters.AddWithValue("@TenNhomHangHoa", ((Criteria_TenNhomHangHoa)criteria).TenNhomHangHoa);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        //dr.Read();
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
                    ExecuteInsert(tr, null);

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
                        ExecuteUpdate(tr, null);
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
            DataPortal_Delete(new Criteria(_maNhomHangHoa));
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
                cm.CommandText = "spd_DeletetblNhomHangHoa";

                cm.Parameters.AddWithValue("@MaNhomHangHoa", criteria.MaNhomHangHoa);

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
            _maNhomHangHoa = dr.GetInt32("MaNhomHangHoa");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenNhomHangHoa = dr.GetString("TenNhomHangHoa");
            _dienGiai = dr.GetString("DienGiai");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _maLoaiVatTuHH = dr.GetInt32("MaLoaiVatTuHH");
            _maNhomHangHoaCha = dr.GetInt32("MaNhomHangHoaCha");
            _thoiGianPhanBo = dr.GetInt32("ThoiGianPhanBo");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, NhomHangHoaBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, NhomHangHoaBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblNhomHangHoa";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maNhomHangHoa = (int)cm.Parameters["@MaNhomHangHoa"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, NhomHangHoaBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenNhomHangHoa", _tenNhomHangHoa);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_maLoaiVatTuHH != 0)
                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", _maLoaiVatTuHH);
            else
                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", DBNull.Value);
            if (_maNhomHangHoaCha != 0)
                cm.Parameters.AddWithValue("@MaNhomHangHoaCha", _maNhomHangHoaCha);
            else
                cm.Parameters.AddWithValue("@MaNhomHangHoaCha", DBNull.Value);
            if (_thoiGianPhanBo != 0)
                cm.Parameters.AddWithValue("@ThoiGianPhanBo", _thoiGianPhanBo);
            else
                cm.Parameters.AddWithValue("@ThoiGianPhanBo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@MaNhomHangHoa", _maNhomHangHoa);
            cm.Parameters["@MaNhomHangHoa"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, NhomHangHoaBQ_VTList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, NhomHangHoaBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblNhomHangHoa";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, NhomHangHoaBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaNhomHangHoa", _maNhomHangHoa);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenNhomHangHoa", _tenNhomHangHoa);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            if (_maLoaiVatTuHH != 0)
                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", _maLoaiVatTuHH);
            else
                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", DBNull.Value);
            if (_maNhomHangHoaCha != 0)
                cm.Parameters.AddWithValue("@MaNhomHangHoaCha", _maNhomHangHoaCha);
            else
                cm.Parameters.AddWithValue("@MaNhomHangHoaCha", DBNull.Value);
            if (_thoiGianPhanBo != 0)
                cm.Parameters.AddWithValue("@ThoiGianPhanBo", _thoiGianPhanBo);
            else
                cm.Parameters.AddWithValue("@ThoiGianPhanBo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
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

            ExecuteDelete(tr, new Criteria(_maNhomHangHoa));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
