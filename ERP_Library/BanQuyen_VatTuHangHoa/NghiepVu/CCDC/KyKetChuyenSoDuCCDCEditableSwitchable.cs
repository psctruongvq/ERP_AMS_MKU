
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KyKetChuyenSoDuCCDC : Csla.BusinessBase<KyKetChuyenSoDuCCDC>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKetChuyen = 0;
        private int _maKy = 0;
        private SmartDate _ngayKetChuyen = new SmartDate(DateTime.Today);
        private int _MaBoPhan =0;
        private decimal _LuyKeNhap=0;
        private decimal _LuyKeXuat=0;
        private decimal _TonDauNam = 0;
        private int _maKho = 0;
        //declare child member(s)
        private CT_KetChuyenSoDuCCDCList _CT_KetChuyenSoDuCCDCList = CT_KetChuyenSoDuCCDCList.NewCT_KetChuyenSoDuCCDCList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKetChuyen
        {
            get
            {
                return _maKetChuyen;
            }
        }

        public int MaKy
        {
            get
            {
                return _maKy;
            }
            set
            {
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKy");
                }
            }
        }

        public DateTime NgayKetChuyen
        {
            get
            {
                return _ngayKetChuyen.Date;
            }
        }

        public string NgayKetChuyenString
        {
            get
            {
                return _ngayKetChuyen.Text;
            }
            set
            {
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
                return _MaBoPhan;
            }
            set
            {
                if (!_MaBoPhan.Equals(value))
                {
                    _MaBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public decimal LuyKeNhap
        {
            get
            {
                return _LuyKeNhap;
            }
            set
            {
                if (!_LuyKeNhap.Equals(value))
                {
                    _LuyKeNhap = value;
                    PropertyHasChanged("LuyKeNhap");
                }
            }
        }

        public decimal LuyKeXuat
        {
            get
            {
                return _LuyKeXuat;
            }
            set
            {
                if (!_LuyKeXuat.Equals(value))
                {
                    _LuyKeXuat = value;
                    PropertyHasChanged("LuyKeXuat");
                }
            }
        }

        public decimal TonDauNam
        {
            get
            {
                return _TonDauNam;
            }
            set
            {
                if (!_TonDauNam.Equals(value))
                {
                    _TonDauNam = value;
                    PropertyHasChanged("TonDauNam");
                }
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
        public CT_KetChuyenSoDuCCDCList CT_KetChuyenSoDuCCDCList
        {
            get
            {
                return _CT_KetChuyenSoDuCCDCList;
            }
            set
            {
                CanWriteProperty("CT_KetChuyenSoDuCCDCList", true);

                _CT_KetChuyenSoDuCCDCList = value;
                PropertyHasChanged("CT_KetChuyenSoDuCCDCList");
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _CT_KetChuyenSoDuCCDCList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _CT_KetChuyenSoDuCCDCList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maKetChuyen;
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

        #region Factory Methods
        private KyKetChuyenSoDuCCDC()
        { /* require use of factory method */ }

        public static KyKetChuyenSoDuCCDC NewKyKetChuyenSoDuCCDC()
        {
            return DataPortal.Create<KyKetChuyenSoDuCCDC>();
        }

        public static KyKetChuyenSoDuCCDC GetKyKetChuyenSoDuCCDC(int maKetChuyen)
        {
            return DataPortal.Fetch<KyKetChuyenSoDuCCDC>(new Criteria(maKetChuyen));
        }

        public static KyKetChuyenSoDuCCDC GetKyKetChuyenSoDuCCDCbyNamvaMaBoPhan(int nam,int maBoPhan)
        {
            return DataPortal.Fetch<KyKetChuyenSoDuCCDC>(new CriteriaNam_MaBoPhan(nam,maBoPhan));
        }

        public static KyKetChuyenSoDuCCDC GetKyKetChuyenSoDuCCDCbyMaKyvaMaBoPhanvaMaKho(int maKy, int maBoPhan, int maKho)
        {
            return DataPortal.Fetch<KyKetChuyenSoDuCCDC>(new CriteriaKy_MaBoPhan_MaKho(maKy, maBoPhan,maKho));
        }

        public static void DeleteKyKetChuyenSoDuCCDC(int maKetChuyen)
        {
            DataPortal.Delete(new Criteria(maKetChuyen));
        }

        public static bool KiemTraKyKetChuyenSoDuCCDCChuaKetChuyenSangKySau(int nam,int maBoPhan)
        {
            bool duocPhepKetChuyen = false;//Ky Nay da Ket chuyen
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraKetChuyenSoDuCCDCTheoNam";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    duocPhepKetChuyen = (bool)prmGiaTriTraVe.Value;
                }

            }
            return duocPhepKetChuyen;
        }

        public static bool KiemTraTonTaiKyKetChuyenSoDuCCDC(int nam, int maBoPhan)
        {
            bool duocPhepKetChuyen = false;//Ky Nay da Ket chuyen
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTonTaiKyKetChuyenSoDuCCDCTheoNam";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    duocPhepKetChuyen = (bool)prmGiaTriTraVe.Value;
                }
            }
            return duocPhepKetChuyen;
        }

        public static bool KiemTraTonTaiKyKetChuyenSoDuCCDC_ByMaKy(int maky, int maBoPhan, int maKho)
        {
            bool duocPhepKetChuyen = false;//Ky Nay da Ket chuyen
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTonTaiKyKetChuyenSoDuCCDCTheoKy_BoPhan_Kho";
                    cm.Parameters.AddWithValue("@MaKy", maky);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 2);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    duocPhepKetChuyen = (bool)prmGiaTriTraVe.Value;
                }
            }
            return duocPhepKetChuyen;
        }

        public static KyKetChuyenSoDuCCDC NewKyKetChuyenSoDuCCDC(int maKy, int maBoPhan, int maKho)
        {
            KyKetChuyenSoDuCCDC _kyKetChuyenSoDuCCDC = new KyKetChuyenSoDuCCDC();
            _kyKetChuyenSoDuCCDC.MaKy = maKy;
            _kyKetChuyenSoDuCCDC.MaBoPhan = maBoPhan;
            _kyKetChuyenSoDuCCDC.MaKho = maKho;
            _kyKetChuyenSoDuCCDC._CT_KetChuyenSoDuCCDCList = CT_KetChuyenSoDuCCDCList.GetCT_KetChuyenTonKhoListByMaKyandBoPhan(maKy,maBoPhan,maKho);
            return _kyKetChuyenSoDuCCDC;
        }
        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KyKetChuyenSoDuCCDC NewKyKetChuyenSoDuCCDCChild()
        {
            KyKetChuyenSoDuCCDC child = new KyKetChuyenSoDuCCDC();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KyKetChuyenSoDuCCDC GetKyKetChuyenSoDuCCDC(SafeDataReader dr)
        {
            KyKetChuyenSoDuCCDC child = new KyKetChuyenSoDuCCDC();
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
            public int MaKetChuyen;

            public Criteria(int maKetChuyen)
            {
                this.MaKetChuyen = maKetChuyen;
            }
        }

        [Serializable()]
        private class CriteriaNam_MaBoPhan
        {
            public int Nam;
            public int MaBoPhan;

            public CriteriaNam_MaBoPhan(int nam, int maBoPhan)
            {
                this.Nam = nam;
                this.MaBoPhan=maBoPhan;
            }
        }

        [Serializable()]
        private class CriteriaKy_MaBoPhan_MaKho
        {
            public int MaKy;
            public int MaBoPhan;
            public int MaKho;

            public CriteriaKy_MaBoPhan_MaKho(int maKy, int maBoPhan, int maKho)
            {
                this.MaKy = maKy;
                this.MaBoPhan = maBoPhan;
                this.MaKho = maKho;
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
                    cm.CommandText = "spd_SelecttblKyKetChuyenSoDuCCDC";//\\
                    cm.Parameters.AddWithValue("@MaKetChuyen", ((Criteria)criteria).MaKetChuyen);
                }
                else if(criteria is CriteriaNam_MaBoPhan)
                {
                    cm.CommandText = "spd_SelecttblKyKetChuyenSoDuCCDCByNamandMaBoPhan";//\\
                    cm.Parameters.AddWithValue("@Nam", ((CriteriaNam_MaBoPhan)criteria).Nam);
                    cm.Parameters.AddWithValue("@MaBoPhan",((CriteriaNam_MaBoPhan)criteria).MaBoPhan);
                }
                else if (criteria is CriteriaKy_MaBoPhan_MaKho)
                {
                    cm.CommandText = "spd_SelecttblKyKetChuyenSoDuCCDCByMaKyandMaBoPhanandKho";//\\
                    cm.Parameters.AddWithValue("@MaKy", ((CriteriaKy_MaBoPhan_MaKho)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((CriteriaKy_MaBoPhan_MaKho)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaKho", ((CriteriaKy_MaBoPhan_MaKho)criteria).MaKho);
                }
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
            DataPortal_Delete(new Criteria(_maKetChuyen));
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
                cm.CommandText = "spd_DeletetblKyKetChuyenSoDuCCDC";//\\

                cm.Parameters.AddWithValue("@MaKetChuyen", criteria.MaKetChuyen);

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
            _maKetChuyen = dr.GetInt32("MaKetChuyen");
            _maKy = dr.GetInt32("MaKy");
            _ngayKetChuyen = dr.GetSmartDate("NgayKetChuyen", _ngayKetChuyen.EmptyIsMin);
            _MaBoPhan=dr.GetInt32("MaBoPhan");
            _LuyKeNhap=dr.GetDecimal("LuyKeNhap");
            _LuyKeXuat=dr.GetDecimal("LuyKeXuat");
            _TonDauNam = dr.GetDecimal("TonDauNam");
            _maKho = dr.GetInt32("MaKho");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            //dr.NextResult();
            _CT_KetChuyenSoDuCCDCList = CT_KetChuyenSoDuCCDCList.GetCT_KetChuyenSoDuCCDCList(this.MaKetChuyen);
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
                cm.CommandText = "spd_InserttblKyKetChuyenSoDuCCDC";//\\

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKetChuyen = (int)cm.Parameters["@MaKetChuyen"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            
            cm.Parameters.AddWithValue("@NgayKetChuyen", _ngayKetChuyen.DBValue);

            if (_MaBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maKho != 0)
                cm.Parameters.AddWithValue("@MaKho", _maKho);
            else
                cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
            if (_LuyKeNhap != 0)
                cm.Parameters.AddWithValue("@LuyKeNhap", _LuyKeNhap);
            else
                cm.Parameters.AddWithValue("@LuyKeNhap", DBNull.Value);
            if (_LuyKeXuat != 0)
                cm.Parameters.AddWithValue("@LuyKeXuat", _LuyKeXuat);
            else
                cm.Parameters.AddWithValue("@LuyKeXuat", DBNull.Value);
            if (_TonDauNam != 0)
                cm.Parameters.AddWithValue("@TonDauNam", _TonDauNam);
            else
                cm.Parameters.AddWithValue("@TonDauNam", DBNull.Value);

            cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            cm.Parameters["@MaKetChuyen"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblKyKetChuyenSoDuCCDC";//\\

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            
            cm.Parameters.AddWithValue("@NgayKetChuyen", _ngayKetChuyen.DBValue);

            if (_MaBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_LuyKeNhap != 0)
                cm.Parameters.AddWithValue("@LuyKeNhap", _LuyKeNhap);
            else
                cm.Parameters.AddWithValue("@LuyKeNhap", DBNull.Value);
            if (_LuyKeXuat != 0)
                cm.Parameters.AddWithValue("@LuyKeXuat", _LuyKeXuat);
            else
                cm.Parameters.AddWithValue("@LuyKeXuat", DBNull.Value);
            if (_TonDauNam != 0)
                cm.Parameters.AddWithValue("@TonDauNam", _TonDauNam);
            else
                cm.Parameters.AddWithValue("@TonDauNam", DBNull.Value);
            if (_maKho != 0)
                cm.Parameters.AddWithValue("@MaKho", _maKho);
            else
                cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _CT_KetChuyenSoDuCCDCList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maKetChuyen));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
