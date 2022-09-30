
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KetChuyenTonKhoBanQuyen : Csla.BusinessBase<KetChuyenTonKhoBanQuyen>
    {
        #region Business Properties and Methods

        //declare members
        private long _maKetChuyenBQ = 0;
        private int _maKho = 0;
        private int _maKy = 0;
        private string _dienGiai = string.Empty;
        private int _maNguoiLap = 0;
        private SmartDate _ngayKetChuyen = new SmartDate(false);
        private int _maBoPhan = 0;
        private decimal _luyKeNhap = 0;
        private decimal _luyKeXuat = 0;
        private decimal _tonDauNam = 0;
        //declare child member(s)
        private CT_KetChuyenTonKhoBanQuyenList _ct_KetChuyenTonKhoBanQuyenList = CT_KetChuyenTonKhoBanQuyenList.NewCT_KetChuyenTonKhoBanQuyenList();
        [System.ComponentModel.DataObjectField(true, true)]
        public long MaKetChuyenBQ
        {
            get
            {
                CanReadProperty("MaKetChuyenBQ", true);
                return _maKetChuyenBQ;
            }
        }

        public int MaKho
        {
            get
            {
                CanReadProperty("MaKho", true);
                return _maKho;
            }
            set
            {
                CanWriteProperty("MaKho", true);
                if (!_maKho.Equals(value))
                {
                    _maKho = value;
                    PropertyHasChanged("MaKho");
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

        public DateTime NgayKetChuyen
        {
            get
            {
                CanReadProperty("NgayKetChuyen", true);
                return _ngayKetChuyen.Date;
            }
        }

        public string NgayKetChuyenString
        {
            get
            {
                CanReadProperty("NgayKetChuyenString", true);
                return _ngayKetChuyen.Text;
            }
            set
            {
                CanWriteProperty("NgayKetChuyenString", true);
                if (value == null) value = string.Empty;
                if (!_ngayKetChuyen.Equals(value))
                {
                    _ngayKetChuyen.Text = value;
                    PropertyHasChanged("NgayKetChuyenString");
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
        public decimal LuyKeNhap
        {
            get
            {
                CanReadProperty("LuyKeNhap", true);
                return _luyKeNhap;
            }
            set
            {
                CanWriteProperty("LuyKeNhap", true);
                if (!_luyKeNhap.Equals(value))
                {
                    _luyKeNhap = value;
                    PropertyHasChanged("LuyKeNhap");
                }
            }
        }
        public decimal LuyKeXuat
        {
            get
            {
                CanReadProperty("LuyKeXuat", true);
                return _luyKeXuat;
            }
            set
            {
                CanWriteProperty("LuyKeXuat", true);
                if (!_luyKeXuat.Equals(value))
                {
                    _luyKeXuat = value;
                    PropertyHasChanged("LuyKeXuat");
                }
            }
        }

        public decimal TonDauNam
        {
            get
            {
                CanReadProperty("TonDauNam", true);
                return _tonDauNam;
            }
            set
            {
                CanWriteProperty("TonDauNam", true);
                if (!_tonDauNam.Equals(value))
                {
                    _tonDauNam = value;
                    PropertyHasChanged("TonDauNam");
                }
            }
        }

        public CT_KetChuyenTonKhoBanQuyenList CT_KetChuyenTonKhoBanQuyenList
        {
            get
            {
                CanReadProperty("CT_KetChuyenTonKhoBanQuyenList", true);
                return _ct_KetChuyenTonKhoBanQuyenList;
            }
        }
        public override bool IsValid
        {
            get{ return base.IsValid && _ct_KetChuyenTonKhoBanQuyenList.IsValid;}
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _ct_KetChuyenTonKhoBanQuyenList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maKetChuyenBQ;
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
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
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
            //TODO: Define authorization rules in KetChuyenTonKhoBanQuyen
            //AuthorizationRules.AllowRead("MaKetChuyenBQ", "KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("MaKho", "KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("NgayKetChuyen", "KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("NgayKetChuyenString", "KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "KetChuyenTonKhoBanQuyenReadGroup");

            //AuthorizationRules.AllowWrite("MaKho", "KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("MaKy", "KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKetChuyenString", "KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "KetChuyenTonKhoBanQuyenWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KetChuyenTonKhoBanQuyen
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenTonKhoBanQuyenViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KetChuyenTonKhoBanQuyen
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenTonKhoBanQuyenAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KetChuyenTonKhoBanQuyen
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenTonKhoBanQuyenEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KetChuyenTonKhoBanQuyen
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenTonKhoBanQuyenDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KetChuyenTonKhoBanQuyen()
        { /* require use of factory method */ }

        public static KetChuyenTonKhoBanQuyen NewKetChuyenTonKhoBanQuyen()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KetChuyenTonKhoBanQuyen");
            return DataPortal.Create<KetChuyenTonKhoBanQuyen>();
        }

        public static KetChuyenTonKhoBanQuyen GetKetChuyenTonKhoBanQuyen(long maKetChuyenBQ)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KetChuyenTonKhoBanQuyen");
            return DataPortal.Fetch<KetChuyenTonKhoBanQuyen>(new Criteria(maKetChuyenBQ));
        }
        public static KetChuyenTonKhoBanQuyen GetKetChuyenTonKhoBanQuyen(int maKy, int maKho,int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KetChuyenTonKhoBanQuyen");
            return DataPortal.Fetch<KetChuyenTonKhoBanQuyen>(new CriteriaByKyAndKhoAndBoPhan(maKy,maKho,maBoPhan));
        }

        public static void DeleteKetChuyenTonKhoBanQuyen(int maKetChuyenBQ)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KetChuyenTonKhoBanQuyen");
            DataPortal.Delete(new Criteria(maKetChuyenBQ));
        }

        public override KetChuyenTonKhoBanQuyen Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KetChuyenTonKhoBanQuyen");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KetChuyenTonKhoBanQuyen");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a KetChuyenTonKhoBanQuyen");

            return base.Save();
        }
        public static KetChuyenTonKhoBanQuyen NewKetChuyenTonKhoBanQuyen(int maKy, int maKho, int maBoPhan)
        {
            KetChuyenTonKhoBanQuyen _ketChuyenTonKhoBanQuyen = new KetChuyenTonKhoBanQuyen();
            _ketChuyenTonKhoBanQuyen.MaKy = maKy;
            _ketChuyenTonKhoBanQuyen.MaKho = maKho;
            _ketChuyenTonKhoBanQuyen.MaBoPhan = maBoPhan;
            //_ketChuyenTonKhoBanQuyen._ct_KetChuyenTonKhoBanQuyenList = CT_KetChuyenTonKhoBanQuyenList.GetCT_KetChuyenTonKhoBanQuyenList(maKho);
            _ketChuyenTonKhoBanQuyen._ct_KetChuyenTonKhoBanQuyenList = CT_KetChuyenTonKhoBanQuyenList.NewCT_KetChuyenTonKhoBanQuyenList();
            return _ketChuyenTonKhoBanQuyen;

        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KetChuyenTonKhoBanQuyen NewKetChuyenTonKhoBanQuyenChild()
        {
            KetChuyenTonKhoBanQuyen child = new KetChuyenTonKhoBanQuyen();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KetChuyenTonKhoBanQuyen GetKetChuyenTonKhoBanQuyen(SafeDataReader dr)
        {
            KetChuyenTonKhoBanQuyen child = new KetChuyenTonKhoBanQuyen();
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
            public long MaKetChuyenBQ;

            public Criteria(long maKetChuyenBQ)
            {
                this.MaKetChuyenBQ = maKetChuyenBQ;
            }
        }
        private class CriteriaByKyAndKhoAndBoPhan
        {
            public int MaKy;
            public int MaKho;
            public int MaBoPhan;

            public CriteriaByKyAndKhoAndBoPhan(int maKy, int maKho,int maBoPhan)
            {
                this.MaKy = maKy;
                this.MaKho = maKho;
                this.MaBoPhan = maBoPhan;
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
        private void DataPortal_Fetch(Object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if(criteria is Criteria)
                    {
                cm.CommandText = "spd_SelecttblKetChuyenTonKhoBanQuyen";
                cm.Parameters.AddWithValue("@MaKetChuyenBQ", ((Criteria)criteria).MaKetChuyenBQ);
                    }
                else if(criteria is CriteriaByKyAndKhoAndBoPhan)
                {
                    cm.CommandText = "spd_SelecttblKetChuyenTonKhoBanQuyenByMaKyAndMaKhoAndMaBoPhan";
                    cm.Parameters.AddWithValue("@MaKy",((CriteriaByKyAndKhoAndBoPhan)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaKho", ((CriteriaByKyAndKhoAndBoPhan)criteria).MaKho);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((CriteriaByKyAndKhoAndBoPhan)criteria).MaBoPhan);
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
            DataPortal_Delete(new Criteria(_maKetChuyenBQ));
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
                cm.CommandText = "spd_DeletetblKetChuyenTonKhoBanQuyen";

                cm.Parameters.AddWithValue("@MaKetChuyenBQ", criteria.MaKetChuyenBQ);

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
            _maKetChuyenBQ = dr.GetInt64("MaKetChuyenBQ");
            _maKho = dr.GetInt32("MaKho");
            _maKy = dr.GetInt32("MaKy");
            _dienGiai = dr.GetString("DienGiai");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _ngayKetChuyen = dr.GetSmartDate("NgayKetChuyen", _ngayKetChuyen.EmptyIsMin);
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _luyKeNhap=dr.GetDecimal("LuyKeNhap");
            _luyKeXuat = dr.GetDecimal("LuyKeXuat");
            _tonDauNam = dr.GetDecimal("TonDauNam");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _ct_KetChuyenTonKhoBanQuyenList = CT_KetChuyenTonKhoBanQuyenList.GetCT_KetChuyenTonKhoBanQuyenList(this.MaKetChuyenBQ);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, KetChuyenTonKhoBanQuyenList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, KetChuyenTonKhoBanQuyenList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblKetChuyenTonKhoBanQuyen";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maKetChuyenBQ = (long)cm.Parameters["@MaKetChuyenBQ"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, KetChuyenTonKhoBanQuyenList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maKho != 0)
                cm.Parameters.AddWithValue("@MaKho", _maKho);
            else
                cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKetChuyen", _ngayKetChuyen.DBValue);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);

            if (_luyKeNhap != 0)
                cm.Parameters.AddWithValue("@LuyKeNhap", _luyKeNhap);
            else
                cm.Parameters.AddWithValue("@LuyKeNhap", DBNull.Value);

            if (_luyKeXuat != 0)
                cm.Parameters.AddWithValue("@LuyKeXuat", _luyKeXuat);
            else
                cm.Parameters.AddWithValue("@LuyKeXuat", DBNull.Value);

            if (_tonDauNam != 0)
                cm.Parameters.AddWithValue("@TonDauNam", _tonDauNam);
            else
                cm.Parameters.AddWithValue("@TonDauNam", DBNull.Value);

            cm.Parameters.AddWithValue("@MaKetChuyenBQ", _maKetChuyenBQ);
            cm.Parameters["@MaKetChuyenBQ"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, KetChuyenTonKhoBanQuyenList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, KetChuyenTonKhoBanQuyenList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblKetChuyenTonKhoBanQuyen";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, KetChuyenTonKhoBanQuyenList parent)
        {
            cm.Parameters.AddWithValue("@MaKetChuyenBQ", _maKetChuyenBQ);
            if (_maKho != 0)
                cm.Parameters.AddWithValue("@MaKho", _maKho);
            else
                cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKetChuyen", _ngayKetChuyen.DBValue);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);

            if (_luyKeNhap != 0)
                cm.Parameters.AddWithValue("@LuyKeNhap", _luyKeNhap);
            else
                cm.Parameters.AddWithValue("@LuyKeNhap", DBNull.Value);

            if (_luyKeXuat != 0)
                cm.Parameters.AddWithValue("@LuyKeXuat", _luyKeXuat);
            else
                cm.Parameters.AddWithValue("@LuyKeXuat", DBNull.Value);

            if (_tonDauNam != 0)
                cm.Parameters.AddWithValue("@TonDauNam", _tonDauNam);
            else
                cm.Parameters.AddWithValue("@TonDauNam", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _ct_KetChuyenTonKhoBanQuyenList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maKetChuyenBQ));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
#region Kiem Tra Da Ton Tai Ket Chuyen Ton Kho
        public static bool KiemTraKetChuyenTonKhoBanQuyen(int maKho,int maKy,int maBoPhan)
        {
            bool giaTriTraVe = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraKetChuyenTonKhoBanQuyen";
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    cm.Parameters.AddWithValue("@MaKy", maKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }
#endregion//Kiem Tra Da Ton Tai Ket Chuyen Ton Kho
        #region lay ngay ket thuc cua ky
        public static DateTime GetNgayKetThucCuaKy(int maKy)
        {
            DateTime giaTriTraVe = DateTime.Today.Date;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetNgayKetThucCuaKy";
                    cm.Parameters.AddWithValue("@MaKy", maKy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.DateTime);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (DateTime)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }
        #endregion
    }
}
