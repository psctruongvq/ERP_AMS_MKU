using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DieuChuyenNoiBoCongCuDungCu : Csla.BusinessBase<DieuChuyenNoiBoCongCuDungCu>
    {
        #region Business Properties and Methods
        //public static SqlTransaction AdvancedTransaction = null;
        //declare members
        private int _maDieuChuyen = 0;
        private int _maBoPhanGiao = 0;
        private long _maNhanVienGiao = 0;
        private int _maBoPhanNhan = 0;
        private long _maNhanVienNhan = 0;
        private SmartDate _ngayDieuChuyen = new SmartDate(false);
        private string _dienGiai = string.Empty;
        private string _soChungTu = string.Empty;
        private int _maNguoiLap = 0;
        private SmartDate _ngayLap = new SmartDate(false);

        //declare child member(s)
        //private DuyetCongCuDungCuList _DSDuyetCongCuDungCu = DuyetCongCuDungCuList.NewDuyetCongCuDungCuList();
        private CT_DieuChuyenNoiBoCongCuDungCuList _cT_DieuChuyenNoiBoCongCuDungCuList = CT_DieuChuyenNoiBoCongCuDungCuList.NewCT_DieuChuyenNoiBoCongCuDungCuList();

        //public DuyetCongCuDungCuList DSDuyetCongCuDungCu
        //{
        //    get { return _DSDuyetCongCuDungCu; }
        //    set { _DSDuyetCongCuDungCu = value; }
        //}
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDieuChuyen
        {
            get
            {
                CanReadProperty("MaDieuChuyen", true);
                return _maDieuChuyen;
            }
        }

        public int MaBoPhanGiao
        {
            get
            {
                CanReadProperty("MaBoPhanGiao", true);
                return _maBoPhanGiao;
            }
            set
            {
                CanWriteProperty("MaBoPhanGiao", true);
                if (!_maBoPhanGiao.Equals(value))
                {
                    _maBoPhanGiao = value;
                    PropertyHasChanged("MaBoPhanGiao");
                }
            }
        }

        public long MaNhanVienGiao
        {
            get
            {
                CanReadProperty("MaNhanVienGiao", true);
                return _maNhanVienGiao;
            }
            set
            {
                CanWriteProperty("MaNhanVienGiao", true);
                if (!_maNhanVienGiao.Equals(value))
                {
                    _maNhanVienGiao = value;
                    PropertyHasChanged("MaNhanVienGiao");
                }
            }
        }

        public int MaBoPhanNhan
        {
            get
            {
                CanReadProperty("MaBoPhanNhan", true);
                return _maBoPhanNhan;
            }
            set
            {
                CanWriteProperty("MaBoPhanNhan", true);
                if (!_maBoPhanNhan.Equals(value))
                {
                    _maBoPhanNhan = value;
                    PropertyHasChanged("MaBoPhanNhan");
                }
            }
        }

        public long MaNhanVienNhan
        {
            get
            {
                CanReadProperty("MaNhanVienNhan", true);
                return _maNhanVienNhan;
            }
            set
            {
                CanWriteProperty("MaNhanVienNhan", true);
                if (!_maNhanVienNhan.Equals(value))
                {
                    _maNhanVienNhan = value;
                    PropertyHasChanged("MaNhanVienNhan");
                }
            }
        }

        public DateTime NgayDieuChuyen
        {
            get
            {
                CanReadProperty("NgayDieuChuyen", true);
                return _ngayDieuChuyen.Date;
            }
            set
            {
                if (_ngayDieuChuyen.Date != (DateTime)value)
                {
                    CanWriteProperty("NgayDieuChuyen", true);
                    _ngayDieuChuyen = new SmartDate(value);
                    PropertyHasChanged("NgayDieuChuyen");
                }

            }
        }

        public string NgayDieuChuyenString
        {
            get
            {
                CanReadProperty("NgayDieuChuyenString", true);
                return _ngayDieuChuyen.Text;
            }
            set
            {
                CanWriteProperty("NgayDieuChuyenString", true);
                if (value == null) value = string.Empty;
                if (!_ngayDieuChuyen.Equals(value))
                {
                    _ngayDieuChuyen.Text = value;
                    PropertyHasChanged("NgayDieuChuyenString");
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

        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (value == null) value = string.Empty;
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
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

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                if (_ngayLap.Date != (DateTime)value)
                {
                    CanWriteProperty("NgayLap", true);
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }

            }
        }

        //public string NgayLapString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayLapString", true);
        //        return _ngayLap.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayLapString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayLap.Equals(value))
        //        {
        //            _ngayLap.Text = value;
        //            PropertyHasChanged("NgayLapString");
        //        }
        //    }
        //}

        public CT_DieuChuyenNoiBoCongCuDungCuList CT_DieuChuyenNoiBoCongCuDungCuList
        {
            get
            {
                CanReadProperty("CT_DieuChuyenNoiBoCongCuDungCu", true);
                return _cT_DieuChuyenNoiBoCongCuDungCuList;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _cT_DieuChuyenNoiBoCongCuDungCuList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cT_DieuChuyenNoiBoCongCuDungCuList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maDieuChuyen;
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
            //
            // SoChungTu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
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
            //TODO: Define authorization rules in DieuChuyenNoiBoCongCuDungCu
            //AuthorizationRules.AllowRead("CT_DieuChuyenNoiBoCongCuDungCu", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaDieuChuyen", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhanGiao", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVienGiao", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhanNhan", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVienNhan", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayDieuChuyen", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayDieuChuyenString", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "DieuChuyenNoiBoCongCuDungCuReadGroup");

            //AuthorizationRules.AllowWrite("MaBoPhanGiao", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVienGiao", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhanNhan", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVienNhan", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("NgayDieuChuyenString", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "DieuChuyenNoiBoCongCuDungCuWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DieuChuyenNoiBoCongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChuyenNoiBoCongCuDungCuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DieuChuyenNoiBoCongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChuyenNoiBoCongCuDungCuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DieuChuyenNoiBoCongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChuyenNoiBoCongCuDungCuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DieuChuyenNoiBoCongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChuyenNoiBoCongCuDungCuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DieuChuyenNoiBoCongCuDungCu()
        { /* require use of factory method */ }

        public static string Get_NextSoChungTuDieuChuyenNoiBo(int maBoPhan, int year, String maQLUser, int size = 4)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_MaxSoTTChungTuDieuChuyenNoiBoCCDC";
                    cm.Parameters.AddWithValue("@Size", size);
                    //SqlParameter para = new SqlParameter("@Nam", SqlDbType.VarChar, 4);
                    //para.Value = year.ToString();
                    //cm.Parameters.Add(para);
                    cm.Parameters.AddWithValue("@Nam", year.ToString());
                    SqlParameter outPara = new SqlParameter("@SoTTChungTu", SqlDbType.VarChar, 20);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();

                    BoPhan bp = BoPhan.GetBoPhan(maBoPhan);
                    String doanCuoi = String.Format(@"DCNBCC/{0}/{1}/", maQLUser, bp.MaBoPhanQL) + year.ToString();
                    string maMoi = String.Format("{0}1{1}", new String('0', size - 1), doanCuoi);
                    if (outPara.SqlValue.ToString() != "Null")
                    {
                        String maxSoTTString = outPara.SqlValue.ToString();
                        int max = int.Parse(maxSoTTString);
                        int soMoi = max + 1;
                        maMoi = new String('0', size - soMoi.ToString().Length) + soMoi.ToString() + doanCuoi;
                    }
                    return maMoi;
                }
            }
        }
        public static DieuChuyenNoiBoCongCuDungCu NewDieuChuyenNoiBoCongCuDungCu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DieuChuyenNoiBoCongCuDungCu");
            return DataPortal.Create<DieuChuyenNoiBoCongCuDungCu>(new CriteriaNew(DateTime.Now.Date));
        }
        public static DieuChuyenNoiBoCongCuDungCu NewDieuChuyenNoiBoCongCuDungCu(int maDieuChuyen)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DieuChuyenNoiBoCongCuDungCu");
            return DataPortal.Create<DieuChuyenNoiBoCongCuDungCu>(new Criteria(maDieuChuyen));
        }

        public static DieuChuyenNoiBoCongCuDungCu GetDieuChuyenNoiBoCongCuDungCu(int maDieuChuyen)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DieuChuyenNoiBoCongCuDungCu");
            return DataPortal.Fetch<DieuChuyenNoiBoCongCuDungCu>(new Criteria(maDieuChuyen));
        }

        public static void DeleteDieuChuyenNoiBoCongCuDungCu(int maDieuChuyen)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DieuChuyenNoiBoCongCuDungCu");
            DataPortal.Delete(new Criteria(maDieuChuyen));
        }

        public override DieuChuyenNoiBoCongCuDungCu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DieuChuyenNoiBoCongCuDungCu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DieuChuyenNoiBoCongCuDungCu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DieuChuyenNoiBoCongCuDungCu");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private DieuChuyenNoiBoCongCuDungCu(int maDieuChuyen)
        {
            this._maDieuChuyen = maDieuChuyen;
        }

        internal static DieuChuyenNoiBoCongCuDungCu NewDieuChuyenNoiBoCongCuDungCuChild(int maDieuChuyen)
        {
            DieuChuyenNoiBoCongCuDungCu child = new DieuChuyenNoiBoCongCuDungCu(maDieuChuyen);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DieuChuyenNoiBoCongCuDungCu GetDieuChuyenNoiBoCongCuDungCu(SafeDataReader dr)
        {
            DieuChuyenNoiBoCongCuDungCu child = new DieuChuyenNoiBoCongCuDungCu();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria
        [Serializable()]
        private class CriteriaNew
        {
            public DateTime DateTime;
            public CriteriaNew(DateTime dateTime)
            {
                DateTime = dateTime;
            }
        }

        [Serializable()]
        private class Criteria
        {
            public int MaDieuChuyen;

            public Criteria(int maDieuChuyen)
            {
                this.MaDieuChuyen = maDieuChuyen;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(object criteria)
        {
            if (criteria is Criteria)
            {
                _maDieuChuyen = (criteria as Criteria).MaDieuChuyen;
            }
            else if (criteria is CriteriaNew)
            {
                _ngayLap.Date = (criteria as CriteriaNew).DateTime;
                _ngayDieuChuyen.Date = (criteria as CriteriaNew).DateTime;
            }
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
                cm.CommandText = "spd_SelectDieuChuyenNoiBoCongCuDungCu";

                cm.Parameters.AddWithValue("@MaDieuChuyen", criteria.MaDieuChuyen);

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
                //


                //
                tr = cn.BeginTransaction();


                try
                {
                    ////su dung transaction khac
                    //if (AdvancedTransaction != null && AdvancedTransaction.Connection != null)
                    //{
                    //    ExecuteInsert(AdvancedTransaction, null);

                    //    //update child object(s)
                    //    UpdateChildren(AdvancedTransaction);
                    //}
                    //else
                    {
                        ExecuteInsert(tr, null);

                        //update child object(s)
                        UpdateChildren(tr);
                        tr.Commit();
                    }

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
                    ////su dung transaction khac
                    //if (AdvancedTransaction != null && AdvancedTransaction.Connection != null)
                    //{
                    //    if (base.IsDirty)
                    //    {
                    //        ExecuteUpdate(AdvancedTransaction, null);
                    //    }

                    //    //update child object(s)
                    //    UpdateChildren(AdvancedTransaction);
                    //}
                    //else
                    {
                        if (base.IsDirty)
                        {
                            ExecuteUpdate(tr, null);
                        }

                        //update child object(s)
                        UpdateChildren(tr);
                        tr.Commit();
                    }
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
            DataPortal_Delete(new Criteria(_maDieuChuyen));
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
                    DeleteChild(tr);

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
                cm.CommandText = "spd_DeleteDieuChuyenNoiBoCongCuDungCu";

                cm.Parameters.AddWithValue("@MaDieuChuyen", criteria.MaDieuChuyen);

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
            _maDieuChuyen = dr.GetInt32("MaDieuChuyen");
            _maBoPhanGiao = dr.GetInt32("MaBoPhanGiao");
            _maNhanVienGiao = dr.GetInt64("MaNhanVienGiao");
            _maBoPhanNhan = dr.GetInt32("MaBoPhanNhan");
            _maNhanVienNhan = dr.GetInt64("MaNhanVienNhan");
            _ngayDieuChuyen = dr.GetSmartDate("NgayDieuChuyen", _ngayDieuChuyen.EmptyIsMin);
            _dienGiai = dr.GetString("DienGiai");
            _soChungTu = dr.GetString("SoChungTu");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _cT_DieuChuyenNoiBoCongCuDungCuList = CT_DieuChuyenNoiBoCongCuDungCuList.GetCT_DieuChuyenNoiBoCongCuDungCuList(_maDieuChuyen);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCuList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCuList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InsertDieuChuyenNoiBoCongCuDungCu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();
                _maDieuChuyen = (int)cm.Parameters["@MaDieuChuyen"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DieuChuyenNoiBoCongCuDungCuList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaDieuChuyen", _maDieuChuyen);
            cm.Parameters["@MaDieuChuyen"].Direction = ParameterDirection.Output;

            if (_maBoPhanGiao != 0)
                cm.Parameters.AddWithValue("@MaBoPhanGiao", _maBoPhanGiao);
            else
                cm.Parameters.AddWithValue("@MaBoPhanGiao", DBNull.Value);
            if (_maNhanVienGiao != 0)
                cm.Parameters.AddWithValue("@MaNhanVienGiao", _maNhanVienGiao);
            else
                cm.Parameters.AddWithValue("@MaNhanVienGiao", DBNull.Value);
            if (_maBoPhanNhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanNhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhanNhan", DBNull.Value);
            if (_maNhanVienNhan != 0)
                cm.Parameters.AddWithValue("@MaNhanVienNhan", _maNhanVienNhan);
            else
                cm.Parameters.AddWithValue("@MaNhanVienNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayDieuChuyen", _ngayDieuChuyen.DBValue);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCuList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCuList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdateDieuChuyenNoiBoCongCuDungCu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DieuChuyenNoiBoCongCuDungCuList parent)
        {
            cm.Parameters.AddWithValue("@MaDieuChuyen", _maDieuChuyen);
            if (_maBoPhanGiao != 0)
                cm.Parameters.AddWithValue("@MaBoPhanGiao", _maBoPhanGiao);
            else
                cm.Parameters.AddWithValue("@MaBoPhanGiao", DBNull.Value);
            if (_maNhanVienGiao != 0)
                cm.Parameters.AddWithValue("@MaNhanVienGiao", _maNhanVienGiao);
            else
                cm.Parameters.AddWithValue("@MaNhanVienGiao", DBNull.Value);
            if (_maBoPhanNhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanNhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhanNhan", DBNull.Value);
            if (_maNhanVienNhan != 0)
                cm.Parameters.AddWithValue("@MaNhanVienNhan", _maNhanVienNhan);
            else
                cm.Parameters.AddWithValue("@MaNhanVienNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayDieuChuyen", _ngayDieuChuyen.DBValue);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            //gan ma dieu chuyen vao chi tiet truoc khi luu
            foreach (CT_DieuChuyenNoiBoCongCuDungCu item in _cT_DieuChuyenNoiBoCongCuDungCuList)
            {
                if (item.MaDieuChuyen != this._maDieuChuyen)
                    item.MaDieuChuyen = this._maDieuChuyen;
            }
            _cT_DieuChuyenNoiBoCongCuDungCuList.Update(tr, null);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            DeleteChild(tr);

            ExecuteDelete(tr, new Criteria(_maDieuChuyen));
            MarkNew();
        }

        private void DeleteChild(SqlTransaction tr)
        {
            _cT_DieuChuyenNoiBoCongCuDungCuList.Clear();
            //_cT_DieuChuyenNoiBoCongCuDungCuList.Update(tr, this);
            this.UpdateChildren(tr);
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
