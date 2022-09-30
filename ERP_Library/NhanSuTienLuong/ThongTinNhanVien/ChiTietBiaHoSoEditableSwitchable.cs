
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietBiaHoSo : Csla.BusinessBase<ChiTietBiaHoSo>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTietBia = 0;
        private bool _lyLich = false;
        private bool _donXinViec = false;
        private bool _khamSucKhoe = false;
        private bool _hoKhau = false;
        private bool _cmnd = false;
        private bool _vanBang = false;
        private bool _GiayTamTru = false;
        private string _ghiChu = string.Empty;
        private long _maNhanVien = 0;
        private string _Tennhanvien = string.Empty;
        private string _MaQlNhanvien = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTietBia
        {
            get
            {
                CanReadProperty("MaChiTietBia", true);
                return _maChiTietBia;
            }
        }

        public bool LyLich
        {
            get
            {
                CanReadProperty("LyLich", true);
                return _lyLich;
            }
            set
            {
                CanWriteProperty("LyLich", true);
                if (!_lyLich.Equals(value))
                {
                    _lyLich = value;
                    PropertyHasChanged("LyLich");
                }
            }
        }

        public bool DonXinViec
        {
            get
            {
                CanReadProperty("DonXinViec", true);
                return _donXinViec;
            }
            set
            {
                CanWriteProperty("DonXinViec", true);
                if (!_donXinViec.Equals(value))
                {
                    _donXinViec = value;
                    PropertyHasChanged("DonXinViec");
                }
            }
        }

        public bool KhamSucKhoe
        {
            get
            {
                CanReadProperty("KhamSucKhoe", true);
                return _khamSucKhoe;
            }
            set
            {
                CanWriteProperty("KhamSucKhoe", true);
                if (!_khamSucKhoe.Equals(value))
                {
                    _khamSucKhoe = value;
                    PropertyHasChanged("KhamSucKhoe");
                }
            }
        }

        public bool HoKhau
        {
            get
            {
                CanReadProperty("HoKhau", true);
                return _hoKhau;
            }
            set
            {
                CanWriteProperty("HoKhau", true);
                if (!_hoKhau.Equals(value))
                {
                    _hoKhau = value;
                    PropertyHasChanged("HoKhau");
                }
            }
        }

        public bool Cmnd
        {
            get
            {
                CanReadProperty("Cmnd", true);
                return _cmnd;
            }
            set
            {
                CanWriteProperty("Cmnd", true);
                if (!_cmnd.Equals(value))
                {
                    _cmnd = value;
                    PropertyHasChanged("Cmnd");
                }
            }
        }

        public bool GiayTamTru
        {
            get
            {
                CanReadProperty("GiayTamTru", true);
                return _GiayTamTru;
            }
            set
            {
                CanWriteProperty("GiayTamTru", true);
                if (!_GiayTamTru.Equals(value))
                {
                    _GiayTamTru = value;
                    PropertyHasChanged("GiayTamTru");
                }
            }
        }

        public bool VanBang
        {
            get
            {
                CanReadProperty("VanBang", true);
                return _vanBang;
            }
            set
            {
                CanWriteProperty("VanBang", true);
                if (!_vanBang.Equals(value))
                {
                    _vanBang = value;
                    PropertyHasChanged("VanBang");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _Tennhanvien;
            }       
        }

        public string MaQlNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _MaQlNhanvien;
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

        protected override object GetIdValue()
        {
            return _maChiTietBia;
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
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 50));
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
            //TODO: Define authorization rules in ChiTietBiaHoSo
            //AuthorizationRules.AllowRead("MaChiTietBia", "ChiTietBiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("LyLich", "ChiTietBiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("DonXinViec", "ChiTietBiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("KhamSucKhoe", "ChiTietBiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("HoKhau", "ChiTietBiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("Cmnd", "ChiTietBiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("VanBang", "ChiTietBiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ChiTietBiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "ChiTietBiaHoSoReadGroup");

            //AuthorizationRules.AllowWrite("LyLich", "ChiTietBiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("DonXinViec", "ChiTietBiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("KhamSucKhoe", "ChiTietBiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("HoKhau", "ChiTietBiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("Cmnd", "ChiTietBiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("VanBang", "ChiTietBiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ChiTietBiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "ChiTietBiaHoSoWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChiTietBiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietBiaHoSoViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChiTietBiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietBiaHoSoAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChiTietBiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietBiaHoSoEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChiTietBiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietBiaHoSoDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChiTietBiaHoSo()
        { /* require use of factory method */ }

        public static ChiTietBiaHoSo NewChiTietBiaHoSo()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChiTietBiaHoSo");
            return DataPortal.Create<ChiTietBiaHoSo>();
        }

        public static ChiTietBiaHoSo GetChiTietBiaHoSo(long maChiTietBia)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietBiaHoSo");
            return DataPortal.Fetch<ChiTietBiaHoSo>(new Criteria(maChiTietBia));
        }

        public static void DeleteChiTietBiaHoSo(long maChiTietBia)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChiTietBiaHoSo");
            DataPortal.Delete(new Criteria(maChiTietBia));
        }

        public override ChiTietBiaHoSo Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChiTietBiaHoSo");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChiTietBiaHoSo");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChiTietBiaHoSo");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChiTietBiaHoSo NewChiTietBiaHoSoChild()
        {
            ChiTietBiaHoSo child = new ChiTietBiaHoSo();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChiTietBiaHoSo GetChiTietBiaHoSo(SafeDataReader dr)
        {
            ChiTietBiaHoSo child = new ChiTietBiaHoSo();
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
            public long MaChiTietBia;

            public Criteria(long maChiTietBia)
            {
                this.MaChiTietBia = maChiTietBia;
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
                cm.CommandText = "spd_SelecttblnsChiTietBiaHoSo";

                cm.Parameters.AddWithValue("@MaChiTietBia", criteria.MaChiTietBia);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
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
            DataPortal_Delete(new Criteria(_maChiTietBia));
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
                cm.CommandText = "spd_tblnsDeleteChiTietBiaHoSo";

                cm.Parameters.AddWithValue("@MaChiTietBia", criteria.MaChiTietBia);

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
            _maChiTietBia = dr.GetInt64("MaChiTietBia");
            _lyLich = dr.GetBoolean("LyLich");
            _donXinViec = dr.GetBoolean("DonXinViec");
            _khamSucKhoe = dr.GetBoolean("KhamSucKhoe");
            _hoKhau = dr.GetBoolean("HoKhau");
            _cmnd = dr.GetBoolean("CMND");
            _vanBang = dr.GetBoolean("VanBang");
            _GiayTamTru = dr.GetBoolean("GiayTamTru");
            _ghiChu = dr.GetString("GhiChu");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _Tennhanvien = dr.GetString("Tennhanvien");
            _MaQlNhanvien = dr.GetString("MaQLNhanvien");
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
                cm.CommandText = "spd_InserttblnsChiTietBiaHoSo";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maChiTietBia = (long)cm.Parameters["@MaChiTietBia"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_lyLich != false)
                cm.Parameters.AddWithValue("@LyLich", _lyLich);
            else
                cm.Parameters.AddWithValue("@LyLich", DBNull.Value);
            if (_donXinViec != false)
                cm.Parameters.AddWithValue("@DonXinViec", _donXinViec);
            else
                cm.Parameters.AddWithValue("@DonXinViec", DBNull.Value);
            if (_khamSucKhoe != false)
                cm.Parameters.AddWithValue("@KhamSucKhoe", _khamSucKhoe);
            else
                cm.Parameters.AddWithValue("@KhamSucKhoe", DBNull.Value);
            if (_hoKhau != false)
                cm.Parameters.AddWithValue("@HoKhau", _hoKhau);
            else
                cm.Parameters.AddWithValue("@HoKhau", DBNull.Value);
            if (_cmnd != false)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_vanBang != false)
                cm.Parameters.AddWithValue("@VanBang", _vanBang);
            else
                cm.Parameters.AddWithValue("@VanBang", DBNull.Value);

            if (_GiayTamTru != false)
                cm.Parameters.AddWithValue("@GiayTamTru", _GiayTamTru);
            else
                cm.Parameters.AddWithValue("@GiayTamTru", DBNull.Value);

            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTietBia", _maChiTietBia);
            cm.Parameters["@MaChiTietBia"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsChiTietBiaHoSo";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaChiTietBia", _maChiTietBia);
            if (_lyLich != false)
                cm.Parameters.AddWithValue("@LyLich", _lyLich);
            else
                cm.Parameters.AddWithValue("@LyLich", DBNull.Value);
            if (_donXinViec != false)
                cm.Parameters.AddWithValue("@DonXinViec", _donXinViec);
            else
                cm.Parameters.AddWithValue("@DonXinViec", DBNull.Value);
            if (_khamSucKhoe != false)
                cm.Parameters.AddWithValue("@KhamSucKhoe", _khamSucKhoe);
            else
                cm.Parameters.AddWithValue("@KhamSucKhoe", DBNull.Value);
            if (_hoKhau != false)
                cm.Parameters.AddWithValue("@HoKhau", _hoKhau);
            else
                cm.Parameters.AddWithValue("@HoKhau", DBNull.Value);
            if (_cmnd != false)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_vanBang != false)
                cm.Parameters.AddWithValue("@VanBang", _vanBang);
            else
                cm.Parameters.AddWithValue("@VanBang", DBNull.Value);

            if (_GiayTamTru != false)
                cm.Parameters.AddWithValue("@GiayTamTru", _GiayTamTru);
            else
                cm.Parameters.AddWithValue("@GiayTamTru", DBNull.Value);

            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maChiTietBia));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
