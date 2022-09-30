
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class TongHopDoiTruCongNo : Csla.BusinessBase<TongHopDoiTruCongNo>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private bool _check;
        private string _soPhieu = string.Empty;
        private DateTime _ngayLap = DateTime.Now;
        private string _dienGiai = string.Empty;
        private decimal _tongTien = 0;
        private int _loai = 0;
        private ChungTu_HoaDonThanhToanChildList _ChungTu_HoaDonThanhToanChildList = ChungTu_HoaDonThanhToanChildList.NewChungTu_HoaDonThanhToanChildList();
        private ChungTu_ChungTuChildList _chungTu_ChungTuChildList = ChungTu_ChungTuChildList.NewChungTu_ChungTuChildList();
        private string _tenDoiTac = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
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

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
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

        public int Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                CanWriteProperty("Loai", true);
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
                }
            }
        }

        public decimal TongTien
        {
            get
            {
                CanReadProperty("TongTien", true);
                return _tongTien;
            }
            set
            {
                CanWriteProperty("TongTien", true);
                if (!_tongTien.Equals(value))
                {
                    _tongTien = value;
                    PropertyHasChanged("TongTien");
                }
            }
        }

        public bool Check
        {
            get
            {
                CanReadProperty("Check", true);
                return _check;
            }
            set
            {
                CanWriteProperty("Check", true);
                if (!_check.Equals(value))
                {
                    _check = value;
                    PropertyHasChanged("Check");
                }
            }
        }

        public string TenDoiTac
        {
            get
            {
                CanReadProperty("TenDoiTac", true);
                return _tenDoiTac;
            }
            set
            {
                CanWriteProperty("TenDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTac.Equals(value))
                {
                    _tenDoiTac = value;
                    PropertyHasChanged("TenDoiTac");
                }
            }

        }
        public ChungTu_HoaDonThanhToanChildList ChungTu_HoaDonThanhToanChildList
        {
            get
            {
                CanReadProperty("ChungTu_HoaDonThanhToanChildList", true);
                return _ChungTu_HoaDonThanhToanChildList;
            }
        }

        public ChungTu_ChungTuChildList ChungTu_ChungTuChildList
        {
            get
            {
                CanReadProperty("ChungTu_ChungTuChildList", true);
                return _chungTu_ChungTuChildList;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _ChungTu_HoaDonThanhToanChildList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _ChungTu_HoaDonThanhToanChildList.IsDirty; }
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
            // SoPhieu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoPhieu", 100));
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
            //TODO: Define authorization rules in TongHopDoiTruCongNo
            //AuthorizationRules.AllowRead("Id", "TongHopDoiTruCongNoReadGroup");
            //AuthorizationRules.AllowRead("SoPhieu", "TongHopDoiTruCongNoReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "TongHopDoiTruCongNoReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "TongHopDoiTruCongNoReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "TongHopDoiTruCongNoReadGroup");

            //AuthorizationRules.AllowWrite("SoPhieu", "TongHopDoiTruCongNoWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "TongHopDoiTruCongNoWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "TongHopDoiTruCongNoWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TongHopDoiTruCongNo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TongHopDoiTruCongNoViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TongHopDoiTruCongNo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TongHopDoiTruCongNoAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TongHopDoiTruCongNo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TongHopDoiTruCongNoEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TongHopDoiTruCongNo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TongHopDoiTruCongNoDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TongHopDoiTruCongNo()
        { /* require use of factory method */ }

        public static TongHopDoiTruCongNo NewTongHopDoiTruCongNo()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TongHopDoiTruCongNo");
            return DataPortal.Create<TongHopDoiTruCongNo>();
        }

        public static TongHopDoiTruCongNo GetTongHopDoiTruCongNo(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TongHopDoiTruCongNo");
            return DataPortal.Fetch<TongHopDoiTruCongNo>(new Criteria(id));
        }

        public static void DeleteTongHopDoiTruCongNo(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TongHopDoiTruCongNo");
            DataPortal.Delete(new Criteria(id));
        }

        public override TongHopDoiTruCongNo Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TongHopDoiTruCongNo");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TongHopDoiTruCongNo");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a TongHopDoiTruCongNo");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static TongHopDoiTruCongNo NewTongHopDoiTruCongNoChild()
        {
            TongHopDoiTruCongNo child = new TongHopDoiTruCongNo();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static TongHopDoiTruCongNo GetTongHopDoiTruCongNo(SafeDataReader dr)
        {
            TongHopDoiTruCongNo child = new TongHopDoiTruCongNo();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        //internal static TongHopDoiTruCongNo GetTongHopDoiTruCongNoDeXoa(SafeDataReader dr)
        //{
        //    TongHopDoiTruCongNo child = new TongHopDoiTruCongNo();
        //    child.MarkAsChild();
        //    child.FetchDeXoa(dr);
        //    return child;
        //}
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
                cm.CommandText = "abc";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

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
            DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "spd_DeleteTongHopDoiTruCongNo";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

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
        //private void FetchDeXoa(SafeDataReader dr)
        //{
        //    FetchObjectDeXoa(dr);
        //    MarkOld();
        //    ValidationRules.CheckRules();

        //    //load child object(s)
        //    FetchChildren(dr);
        //}

        //private void FetchObjectDeXoa(SafeDataReader dr)
        //{
        //    _id = dr.GetInt32("Id");
        //    _soPhieu = dr.GetString("SoPhieu");
        //    _ngayLap = dr.GetDateTime("NgayLap");
        //    _dienGiai = dr.GetString("DienGiai");
        //    _tongTien = dr.GetDecimal("TongTien");
        //}

        private void FetchObject(SafeDataReader dr)
        {
            _id = dr.GetInt32("Id");
            _soPhieu = dr.GetString("SoPhieu");
            _ngayLap = dr.GetDateTime("NgayLap");
            _dienGiai = dr.GetString("DienGiai");
            _tongTien = dr.GetDecimal("TongTien");
            _tenDoiTac = dr.GetString("TenDoiTac");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _ChungTu_HoaDonThanhToanChildList = ChungTu_HoaDonThanhToanChildList.GetChungTu_HoaDonThanhToanChildListByIdDTCN(this._id);
            _chungTu_ChungTuChildList = ChungTu_ChungTuChildList.GetChungTu_ChungTuChildListByIdDTCN(this._id);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            MarkAsChild();
            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InsertTongHopDoiTruCongNo";

                AddInsertParameters(cm);
                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@NewId"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_soPhieu.Length > 0)
                cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
            else
                cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_loai > 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@NewId", _id);
            cm.Parameters["@NewId"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdateTongHopDoiTruCongNo";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Id", _id);
            if (_soPhieu.Length > 0)
                cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
            else
                cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Date);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _ChungTu_HoaDonThanhToanChildList.Update(tr, this);
            _chungTu_ChungTuChildList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _ChungTu_HoaDonThanhToanChildList.Clear();
            _chungTu_ChungTuChildList.Clear();
            UpdateChildren(tr);

            ExecuteDelete(tr, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete

        public static string NewSoChungTu(DateTime ngayLap,string TienTo,int loai)
        {
            string ret = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetNewSoChungTu_DoiTruCongNo";
                    cm.Parameters.AddWithValue("@ngayLap", ngayLap);
                    cm.Parameters.AddWithValue("@Loai", loai);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ret = TienTo + ds.Tables[0].Rows[0][0].ToString() + "-" + ngayLap.Year.ToString().Substring(2) + (ngayLap.Month > 9 ? ngayLap.Month.ToString() : "0" + ngayLap.Month.ToString());
                    return ret;
                }
            }//us
            return "";
        }
        #endregion //Data Access
    }
}
