
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class MauKinhPhiHoatDong : Csla.BusinessBase<MauKinhPhiHoatDong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBaoCao = 0;
        private string _tenChiTieu = string.Empty;
        private decimal _cPKyTruocChuyenSang = 0;
        private decimal _soThucNhanKyNay = 0;
        private decimal _luyKeTuDauNam = 0;
        private decimal _soKPDaSuDungKyNay = 0;
        private decimal _soKPLuyKeTuDauNam = 0;
        private int _maKy = 0;
        private int _maMucCha = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaBaoCao
        {
            get
            {
                CanReadProperty("MaBaoCao", true);
                return _maBaoCao;
            }
        }

        public string TenChiTieu
        {
            get
            {
                CanReadProperty("TenChiTieu", true);
                return _tenChiTieu;
            }
            set
            {
                CanWriteProperty("TenChiTieu", true);
                if (value == null) value = string.Empty;
                if (!_tenChiTieu.Equals(value))
                {
                    _tenChiTieu = value;
                    PropertyHasChanged("TenChiTieu");
                }
            }
        }

        public decimal CPKyTruocChuyenSang
        {
            get
            {
                CanReadProperty("CPKyTruocChuyenSang", true);
                return _cPKyTruocChuyenSang;
            }
            set
            {
                CanWriteProperty("CPKyTruocChuyenSang", true);
                if (!_cPKyTruocChuyenSang.Equals(value))
                {
                    _cPKyTruocChuyenSang = value;
                    PropertyHasChanged("CPKyTruocChuyenSang");
                }
            }
        }

        public decimal SoThucNhanKyNay
        {
            get
            {
                CanReadProperty("SoThucNhanKyNay", true);
                return _soThucNhanKyNay;
            }
            set
            {
                CanWriteProperty("SoThucNhanKyNay", true);
                if (!_soThucNhanKyNay.Equals(value))
                {
                    _soThucNhanKyNay = value;
                    PropertyHasChanged("SoThucNhanKyNay");
                }
            }
        }

        public decimal LuyKeTuDauNam
        {
            get
            {
                CanReadProperty("LuyKeTuDauNam", true);
                return _luyKeTuDauNam;
            }
            set
            {
                CanWriteProperty("LuyKeTuDauNam", true);
                if (!_luyKeTuDauNam.Equals(value))
                {
                    _luyKeTuDauNam = value;
                    PropertyHasChanged("LuyKeTuDauNam");
                }
            }
        }

        public decimal SoKPDaSuDungKyNay
        {
            get
            {
                CanReadProperty("SoKPDaSuDungKyNay", true);
                return _soKPDaSuDungKyNay;
            }
            set
            {
                CanWriteProperty("SoKPDaSuDungKyNay", true);
                if (!_soKPDaSuDungKyNay.Equals(value))
                {
                    _soKPDaSuDungKyNay = value;
                    PropertyHasChanged("SoKPDaSuDungKyNay");
                }
            }
        }

        public decimal SoKPLuyKeTuDauNam
        {
            get
            {
                CanReadProperty("SoKPLuyKeTuDauNam", true);
                return _soKPLuyKeTuDauNam;
            }
            set
            {
                CanWriteProperty("SoKPLuyKeTuDauNam", true);
                if (!_soKPLuyKeTuDauNam.Equals(value))
                {
                    _soKPLuyKeTuDauNam = value;
                    PropertyHasChanged("SoKPLuyKeTuDauNam");
                }
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

        public int MaMucCha
        {
            get
            {
                CanReadProperty("MaMucCha", true);
                return _maMucCha;
            }
            set
            {
                CanWriteProperty("MaMucCha", true);
                if (!_maMucCha.Equals(value))
                {
                    _maMucCha = value;
                    PropertyHasChanged("MaMucCha");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maBaoCao;
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
            // TenChiTieu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChiTieu", 1000));
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
            //TODO: Define authorization rules in MauKinhPhiHoatDong
            //AuthorizationRules.AllowRead("MaBaoCao", "MauKinhPhiHoatDongReadGroup");
            //AuthorizationRules.AllowRead("TenChiTieu", "MauKinhPhiHoatDongReadGroup");
            //AuthorizationRules.AllowRead("CPKyTruocChuyenSang", "MauKinhPhiHoatDongReadGroup");
            //AuthorizationRules.AllowRead("SoThucNhanKyNay", "MauKinhPhiHoatDongReadGroup");
            //AuthorizationRules.AllowRead("LuyKeTuDauNam", "MauKinhPhiHoatDongReadGroup");
            //AuthorizationRules.AllowRead("SoKPDaSuDungKyNay", "MauKinhPhiHoatDongReadGroup");
            //AuthorizationRules.AllowRead("SoKPLuyKeTuDauNam", "MauKinhPhiHoatDongReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "MauKinhPhiHoatDongReadGroup");

            //AuthorizationRules.AllowWrite("TenChiTieu", "MauKinhPhiHoatDongWriteGroup");
            //AuthorizationRules.AllowWrite("CPKyTruocChuyenSang", "MauKinhPhiHoatDongWriteGroup");
            //AuthorizationRules.AllowWrite("SoThucNhanKyNay", "MauKinhPhiHoatDongWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeTuDauNam", "MauKinhPhiHoatDongWriteGroup");
            //AuthorizationRules.AllowWrite("SoKPDaSuDungKyNay", "MauKinhPhiHoatDongWriteGroup");
            //AuthorizationRules.AllowWrite("SoKPLuyKeTuDauNam", "MauKinhPhiHoatDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaKy", "MauKinhPhiHoatDongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in MauKinhPhiHoatDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MauKinhPhiHoatDongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in MauKinhPhiHoatDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MauKinhPhiHoatDongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in MauKinhPhiHoatDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MauKinhPhiHoatDongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in MauKinhPhiHoatDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MauKinhPhiHoatDongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private MauKinhPhiHoatDong()
        { /* require use of factory method */ }

        public static MauKinhPhiHoatDong NewMauKinhPhiHoatDong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a MauKinhPhiHoatDong");
            return DataPortal.Create<MauKinhPhiHoatDong>();
        }

        public static MauKinhPhiHoatDong GetMauKinhPhiHoatDong(int maBaoCao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a MauKinhPhiHoatDong");
            return DataPortal.Fetch<MauKinhPhiHoatDong>(new Criteria(maBaoCao));
        }

        public static void DeleteMauKinhPhiHoatDong(int maBaoCao)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a MauKinhPhiHoatDong");
            DataPortal.Delete(new Criteria(maBaoCao));
        }

        public override MauKinhPhiHoatDong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a MauKinhPhiHoatDong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a MauKinhPhiHoatDong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a MauKinhPhiHoatDong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static MauKinhPhiHoatDong NewMauKinhPhiHoatDongChild()
        {
            MauKinhPhiHoatDong child = new MauKinhPhiHoatDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static MauKinhPhiHoatDong GetMauKinhPhiHoatDong(SafeDataReader dr, bool kiemTra)
        {
            MauKinhPhiHoatDong child = new MauKinhPhiHoatDong();
            child.MarkAsChild();
            child.Fetch(dr, kiemTra);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaBaoCao;

            public Criteria(int maBaoCao)
            {
                this.MaBaoCao = maBaoCao;
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
                cm.CommandText = "spd_SelecttblMauKinhPhiHoatDong";

                cm.Parameters.AddWithValue("@MaBaoCao", criteria.MaBaoCao);

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
            DataPortal_Delete(new Criteria(_maBaoCao));
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
                cm.CommandText = "spd_DeletetblMauKinhPhiHoatDong";

                cm.Parameters.AddWithValue("@MaBaoCao", criteria.MaBaoCao);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr, bool kiemTra)
        {
            FetchObject(dr);
            if (kiemTra == true)
                MarkOld();
            else MarkNew();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maBaoCao = dr.GetInt32("MaBaoCao");
            _tenChiTieu = dr.GetString("TenChiTieu");
            _cPKyTruocChuyenSang = dr.GetDecimal("CPKyTruocChuyenSang");
            _soThucNhanKyNay = dr.GetDecimal("SoThucNhanKyNay");
            _luyKeTuDauNam = dr.GetDecimal("LuyKeTuDauNam");
            _soKPDaSuDungKyNay = dr.GetDecimal("SoKPDaSuDungKyNay");
            _soKPLuyKeTuDauNam = dr.GetDecimal("SoKPLuyKeTuDauNam");
            _maKy = dr.GetInt32("MaKy");
            _maMucCha = dr.GetInt32("MaMucCha");
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
                cm.CommandText = "spd_InserttblMauKinhPhiHoatDong";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maBaoCao = (int)cm.Parameters["@MaBaoCao"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenChiTieu.Length > 0)
                cm.Parameters.AddWithValue("@TenChiTieu", _tenChiTieu);
            else
                cm.Parameters.AddWithValue("@TenChiTieu", DBNull.Value);           
            cm.Parameters.AddWithValue("@CPKyTruocChuyenSang", _cPKyTruocChuyenSang);
            cm.Parameters.AddWithValue("@SoThucNhanKyNay", _soThucNhanKyNay);
            cm.Parameters.AddWithValue("@LuyKeTuDauNam", _luyKeTuDauNam);
            cm.Parameters.AddWithValue("@SoKPDaSuDungKyNay", _soKPDaSuDungKyNay);
            cm.Parameters.AddWithValue("@SoKPLuyKeTuDauNam", _soKPLuyKeTuDauNam);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maMucCha != 0)
                cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
            else
                cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBaoCao", _maBaoCao);
            cm.Parameters["@MaBaoCao"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblMauKinhPhiHoatDong";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBaoCao", _maBaoCao);
            if (_tenChiTieu.Length > 0)
                cm.Parameters.AddWithValue("@TenChiTieu", _tenChiTieu);
            else
                cm.Parameters.AddWithValue("@TenChiTieu", DBNull.Value);
           
            cm.Parameters.AddWithValue("@CPKyTruocChuyenSang", _cPKyTruocChuyenSang);
            cm.Parameters.AddWithValue("@SoThucNhanKyNay", _soThucNhanKyNay);
            cm.Parameters.AddWithValue("@LuyKeTuDauNam", _luyKeTuDauNam);
            cm.Parameters.AddWithValue("@SoKPDaSuDungKyNay", _soKPDaSuDungKyNay);
            cm.Parameters.AddWithValue("@SoKPLuyKeTuDauNam", _soKPLuyKeTuDauNam);
           
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maMucCha != 0)
                cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
            else
                cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maBaoCao));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        #region KiemTraKy
        public static int KiemTraKyBaoCao(int MaKy)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraKyBaoCaoKinhPhiHoatDong";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }
        #endregion 
    }
}

