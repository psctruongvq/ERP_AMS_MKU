using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhanLoaiHopDong : Csla.BusinessBase<PhanLoaiHopDong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maPhanLoaiHD = 0;
        private string _maPhanLoaiHDQL = string.Empty;
        private string _tenPhanLoaiHD = string.Empty;
        private int _maLoaiHopDong = 0;
        private int _maNguoiLap = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaPhanLoaiHD
        {
            get
            {
                CanReadProperty("MaPhanLoaiHD", true);
                return _maPhanLoaiHD;
            }
        }

        public string MaPhanLoaiHDQL
        {
            get
            {
                CanReadProperty("MaPhanLoaiHDQL", true);
                return _maPhanLoaiHDQL;
            }
            set
            {
                CanWriteProperty("MaPhanLoaiHDQL", true);
                if (value == null) value = string.Empty;
                if (!_maPhanLoaiHDQL.Equals(value))
                {
                    _maPhanLoaiHDQL = value;
                    PropertyHasChanged("MaPhanLoaiHDQL");
                }
            }
            
        }

        public string TenPhanLoaiHD
        {
            get
            {
                CanReadProperty("TenPhanLoaiHD", true);
                return _tenPhanLoaiHD;
            }
            set
            {
                CanWriteProperty("TenPhanLoaiHD", true);
                if (value == null) value = string.Empty;
                if (!_tenPhanLoaiHD.Equals(value))
                {
                    _tenPhanLoaiHD = value;
                    PropertyHasChanged("TenPhanLoaiHD");
                }
            }
        }

        public int MaLoaiHopDong
        {
            get
            {
                CanReadProperty("MaLoaiHopDong", true);
                return _maLoaiHopDong;
            }
            set
            {
                CanWriteProperty("MaLoaiHopDong", true);
                if (!_maLoaiHopDong.Equals(value))
                {
                    _maLoaiHopDong = value;
                    PropertyHasChanged("MaLoaiHopDong");
                }
            }
            
        }

        public int MaNguoiLap
        {
            get
            {
                CanReadProperty("MaNguoiLap", true);
                return _maNguoiLap;
            }
            set
            {
                CanWriteProperty("MaNguoiLap", true);
                if (!_maNguoiLap.Equals(value))
                {
                    _maNguoiLap = value;
                    PropertyHasChanged("MaNguoiLap");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maPhanLoaiHD;
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
            // MaPhanLoaiHDQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhanLoaiHDQL", 50));
            //
            // TenPhanLoaiHD
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenPhanLoaiHD", 1000));
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
            //TODO: Define authorization rules in PhanLoaiHopDong
            //AuthorizationRules.AllowRead("MaPhanLoaiHD", "PhanLoaiHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaPhanLoaiHDQL", "PhanLoaiHopDongReadGroup");
            //AuthorizationRules.AllowRead("TenPhanLoaiHD", "PhanLoaiHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiHopDong", "PhanLoaiHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "PhanLoaiHopDongReadGroup");

            //AuthorizationRules.AllowWrite("MaPhanLoaiHDQL", "PhanLoaiHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("TenPhanLoaiHD", "PhanLoaiHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiHopDong", "PhanLoaiHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "PhanLoaiHopDongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhanLoaiHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanLoaiHopDongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhanLoaiHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanLoaiHopDongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhanLoaiHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanLoaiHopDongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhanLoaiHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanLoaiHopDongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhanLoaiHopDong()
        { /* require use of factory method */ }
        private PhanLoaiHopDong(int ma, string ten)
        {
            _maLoaiHopDong = ma;
            _tenPhanLoaiHD = ten;
        }
        public static PhanLoaiHopDong NewPhanLoaiHopDong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhanLoaiHopDong");
            return DataPortal.Create<PhanLoaiHopDong>();
        }

        public static PhanLoaiHopDong NewPhanLoaiHopDong(int ma,string ten)
        {
            return new PhanLoaiHopDong(ma, ten);
        }

        public static PhanLoaiHopDong GetPhanLoaiHopDong(int maPhanLoaiHD)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanLoaiHopDong");
            return DataPortal.Fetch<PhanLoaiHopDong>(new Criteria(maPhanLoaiHD));
        }

        public static PhanLoaiHopDong GetPhanLoaiHopDongByMaQL(string maQL)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanLoaiHopDong");
            return DataPortal.Fetch<PhanLoaiHopDong>(new CriteriaByMaQL(maQL));
        }

        public static void DeletePhanLoaiHopDong(int maPhanLoaiHD)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhanLoaiHopDong");
            DataPortal.Delete(new Criteria(maPhanLoaiHD));
        }

        public override PhanLoaiHopDong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhanLoaiHopDong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhanLoaiHopDong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a PhanLoaiHopDong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static PhanLoaiHopDong NewPhanLoaiHopDongChild()
        {
            PhanLoaiHopDong child = new PhanLoaiHopDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static PhanLoaiHopDong GetPhanLoaiHopDong(SafeDataReader dr)
        {
            PhanLoaiHopDong child = new PhanLoaiHopDong();
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
            public int MaPhanLoaiHD;

            public Criteria(int maPhanLoaiHD)
            {
                this.MaPhanLoaiHD = maPhanLoaiHD;
            }
        }

        private class CriteriaByMaQL
        {
            public string MaQL;

            public CriteriaByMaQL(string maQL)
            {
                this.MaQL = maQL;
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is CriteriaByMaQL)
                {
                    cm.CommandText = "usp_SelecttblPhanLoaiHopDongByMaQL";

                    cm.Parameters.AddWithValue("@MaQL", ((CriteriaByMaQL)criteria).MaQL);
                }
                else
                {
                    cm.CommandText = "usp_SelecttblPhanLoaiHopDong";

                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", ((Criteria)criteria).MaPhanLoaiHD);
                }

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
            DataPortal_Delete(new Criteria(_maPhanLoaiHD));
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
                cm.CommandText = "usp_DeletetblPhanLoaiHopDong";

                cm.Parameters.AddWithValue("@MaPhanLoaiHD", criteria.MaPhanLoaiHD);

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
            _maPhanLoaiHD = dr.GetInt32("MaPhanLoaiHD");
            _maPhanLoaiHDQL = dr.GetString("MaPhanLoaiHDQL");
            _tenPhanLoaiHD = dr.GetString("TenPhanLoaiHD");
            _maLoaiHopDong = dr.GetInt32("MaLoaiHopDong");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
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
                cm.CommandText = "usp_InserttblPhanLoaiHopDong";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maPhanLoaiHD = (int)cm.Parameters["@MaPhanLoaiHD"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maPhanLoaiHDQL.Length > 0)
                cm.Parameters.AddWithValue("@MaPhanLoaiHDQL", _maPhanLoaiHDQL);
            else
                cm.Parameters.AddWithValue("@MaPhanLoaiHDQL", DBNull.Value);
            if (_tenPhanLoaiHD.Length > 0)
                cm.Parameters.AddWithValue("@TenPhanLoaiHD", _tenPhanLoaiHD);
            else
                cm.Parameters.AddWithValue("@TenPhanLoaiHD", DBNull.Value);
            if (_maLoaiHopDong != 0)
                cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);
            else
                cm.Parameters.AddWithValue("@MaLoaiHopDong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@MaPhanLoaiHD", _maPhanLoaiHD);
            cm.Parameters["@MaPhanLoaiHD"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "usp_UpdatetblPhanLoaiHopDong";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhanLoaiHD", _maPhanLoaiHD);
            if (_maPhanLoaiHDQL.Length > 0)
                cm.Parameters.AddWithValue("@MaPhanLoaiHDQL", _maPhanLoaiHDQL);
            else
                cm.Parameters.AddWithValue("@MaPhanLoaiHDQL", DBNull.Value);
            if (_tenPhanLoaiHD.Length > 0)
                cm.Parameters.AddWithValue("@TenPhanLoaiHD", _tenPhanLoaiHD);
            else
                cm.Parameters.AddWithValue("@TenPhanLoaiHD", DBNull.Value);
            if (_maLoaiHopDong != 0)
                cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);
            else
                cm.Parameters.AddWithValue("@MaLoaiHopDong", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
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

            ExecuteDelete(cn, new Criteria(_maPhanLoaiHD));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        #region Kiem Tra
        public static bool KiemTraTrungMaPhanloaiHopDong(int maPhanLoaiHD, string maQuanLy)
        {
            bool trungSoHopDong = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungMaPhanLoaiHD";
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", maPhanLoaiHD);
                    cm.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@TrungMaQuanLy", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    trungSoHopDong = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return trungSoHopDong;
        }
        #endregion
    }
}
