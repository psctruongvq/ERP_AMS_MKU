using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_HoaDonThanhToan : Csla.BusinessBase<ChungTu_HoaDonThanhToan>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private long _maChungTu = 0;
        private int _maButToan = 0;
        private long _maHoaDon = 0;
        private long _maPhieuNhapXuat = 0;
        private DateTime _ngayLap = DateTime.Today.Date;
        private int _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private decimal _tienThue = 0;
        private decimal _soTienThanhToan = 0;
        private int _idDTCN = 0;

        private string _dienGiai = "";

        private string _soChungTu = "";
        private string _soHoaDon = "";
        private long _maDoiTac = 0;
        private DateTime _ngayChungTu = DateTime.Today.Date;
        private DateTime _ngayHoaDon = DateTime.Today.Date;
        private bool _isCanTruSoDauKy = false;

        #region Properties BS
        HoaDon _HoaDon = HoaDon.NewHoaDon();
        public HoaDon HoaDon
        {
            get
            {
                CanReadProperty(true);
                return _HoaDon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_HoaDon.Equals(value))
                {
                    _HoaDon = value;
                    PropertyHasChanged();
                }
            }
        }

        #region Properties HoaDon
        //private string _GhiChu;
        //private string _SoHoaDon;
        //private string _SoSerial;
        //private string _MauHoaDon;
        //private string _KyHieuMauHoaDon;
        //private decimal _ThueVAT;
        //private DateTime _NgayLapHoaDon;

        //public string GhiChu
        //{
        //    get { return _GhiChu; }
        //}

        //public string SoHoaDon
        //{
        //    get { return _SoHoaDon; }
        //}
        //public string SoSerial
        //{
        //    get { return _SoSerial; }
        //}
        //public string MauHoaDon
        //{
        //    get { return _MauHoaDon; }
        //}

        //public string KyHieuMauHoaDon
        //{
        //    get { return _KyHieuMauHoaDon; }
        //}
        //public decimal ThueVAT
        //{
        //    get { return _ThueVAT; }
        //}

        //public DateTime NgayLapHoaDon
        //{
        //    get { return _NgayLapHoaDon; }
        //} 
        #endregion//Properties HoaDon

        #endregion //Properties BS

        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public long MaDoiTac
        {
            get
            {
                CanReadProperty("MaDoiTac", true);
                return _maDoiTac;
            }
            set
            {
                CanWriteProperty("MaDoiTac", true);
                if (!_maDoiTac.Equals(value))
                {
                    _maDoiTac = value;
                    PropertyHasChanged("MaDoiTac");
                }
            }
        }

        public int MaButToan
        {
            get
            {
                CanReadProperty("MaButToan", true);
                return _maButToan;
            }
            set
            {
                CanWriteProperty("MaButToan", true);
                if (!_maButToan.Equals(value))
                {
                    _maButToan = value;
                    PropertyHasChanged("MaButToan");
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

        public string SoHoaDon
        {
            get
            {
                CanReadProperty("SoHoaDon", true);
                return _soHoaDon;
            }
            set
            {
                CanWriteProperty("SoHoaDon", true);
                if (value == null) value = string.Empty;
                if (!_soHoaDon.Equals(value))
                {
                    _soHoaDon = value;
                    PropertyHasChanged("SoHoaDon");
                }
            }
        }

        public int IdDTCN
        {
            get
            {
                CanReadProperty("IdDTCN", true);
                return _idDTCN;
            }
            set
            {
                CanWriteProperty("IdDTCN", true);
                if (!_idDTCN.Equals(value))
                {
                    _idDTCN = value;
                    PropertyHasChanged("IdDTCN");
                }
            }
        }

        public long MaHoaDon
        {
            get
            {
                CanReadProperty("MaHoaDon", true);
                return _maHoaDon;
            }
            set
            {
                CanWriteProperty("MaHoaDon", true);
                if (!_maHoaDon.Equals(value))
                {
                    _maHoaDon = value;
                    PropertyHasChanged("MaHoaDon");
                }
            }
        }

        public long MaPhieuNhapXuat
        {
            get
            {
                CanReadProperty("MaPhieuNhapXuat", true);
                return _maPhieuNhapXuat;
            }
            set
            {
                CanWriteProperty("MaPhieuNhapXuat", true);
                if (!_maPhieuNhapXuat.Equals(value))
                {
                    _maPhieuNhapXuat = value;
                    PropertyHasChanged("MaPhieuNhapXuat");
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

        public int NguoiLap
        {
            get
            {
                CanReadProperty("NguoiLap", true);
                return _nguoiLap;
            }
            set
            {
                CanWriteProperty("NguoiLap", true);
                if (!_nguoiLap.Equals(value))
                {
                    _nguoiLap = value;
                    PropertyHasChanged("NguoiLap");
                }
            }
        }

        public decimal TienThue
        {
            get
            {
                CanReadProperty("TienThue", true);
                return _tienThue;
            }
            set
            {
                CanWriteProperty("TienThue", true);
                if (!_tienThue.Equals(value))
                {
                    _tienThue = value;
                    PropertyHasChanged("TienThue");
                }
            }
        }

        public decimal SoTienThanhToan
        {
            get
            {
                CanReadProperty("SoTienThanhToan", true);
                return _soTienThanhToan;
            }
            set
            {
                CanWriteProperty("SoTienThanhToan", true);
                if (!_soTienThanhToan.Equals(value))
                {
                    _soTienThanhToan = value;
                    PropertyHasChanged("SoTienThanhToan");
                }
            }
        }

        public DateTime NgayChungTu
        {
            get
            {
                CanReadProperty("NgayChungTu", true);
                return _ngayChungTu.Date;
            }
            set
            {
                CanWriteProperty("NgayChungTu", true);
                if (!_ngayChungTu.Equals(value))
                {
                    _ngayChungTu = value;
                    PropertyHasChanged("NgayChungTu");
                }
            }
        }

        public DateTime NgayHoaDon
        {
            get
            {
                CanReadProperty("NgayHoaDon", true);
                return _ngayHoaDon.Date;
            }
            set
            {
                CanWriteProperty("NgayHoaDon", true);
                if (!_ngayHoaDon.Equals(value))
                {
                    _ngayHoaDon = value;
                    PropertyHasChanged("NgayHoaDon");
                }
            }
        }

        public bool IsCanTruSoDauKy
        {
            get
            {
                CanReadProperty("IsCanTruSoDauKy", true);
                return _isCanTruSoDauKy;
            }
            set
            {
                CanWriteProperty("IsCanTruSoDauKy", true);
                if (!_isCanTruSoDauKy.Equals(value))
                {
                    _isCanTruSoDauKy = value;
                    PropertyHasChanged("IsCanTruSoDauKy");
                }
            }
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
            //TODO: Define authorization rules in ChungTu_HoaDonThanhToan
            //AuthorizationRules.AllowRead("Id", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("MaButToan", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("MaHoaDon", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuNhapXuat", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("NguoiLap", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("TienTruocThue", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("TienThue", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("TienSauThue", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("SoTienDaThanhToan", "ChungTu_HoaDonThanhToanReadGroup");
            //AuthorizationRules.AllowRead("SoTienConLai", "ChungTu_HoaDonThanhToanReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaButToan", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaHoaDon", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieuNhapXuat", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLap", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("TienTruocThue", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("TienThue", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("TienSauThue", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienDaThanhToan", "ChungTu_HoaDonThanhToanWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienConLai", "ChungTu_HoaDonThanhToanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTu_HoaDonThanhToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoaDonThanhToanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTu_HoaDonThanhToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoaDonThanhToanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTu_HoaDonThanhToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoaDonThanhToanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTu_HoaDonThanhToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoaDonThanhToanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTu_HoaDonThanhToan()
        { /* require use of factory method */ }

        public static ChungTu_HoaDonThanhToan NewChungTu_HoaDonThanhToan()
        {
            //if (!CanAddObject())
            //    throw new System.Security.SecurityException("User not authorized to add a ChungTu_HoaDonThanhToan");           
            //return DataPortal.Create<ChungTu_HoaDonThanhToan>();

            ChungTu_HoaDonThanhToan item = new ChungTu_HoaDonThanhToan();        
            item.MarkAsChild();
            return item;
        }

        public static ChungTu_HoaDonThanhToan NewChungTu_HoaDonThanhToan(HoaDon _hoaDon)
        {
            ChungTu_HoaDonThanhToan item = new ChungTu_HoaDonThanhToan();
            item._HoaDon = HoaDon.GetHoaDon(_hoaDon.MaHoaDon);
            item._maHoaDon = item._HoaDon.MaHoaDon;
            item.SoTienThanhToan =HoaDon.GetSoTienConLaiHoaDon( item._HoaDon.MaHoaDon,0);
            item._tienThue = item._HoaDon.TienThue;
            item.MaDoiTac = _hoaDon.MaDoiTac;
            item.MarkAsChild();
            return item;
        }

        public static ChungTu_HoaDonThanhToan GetChungTu_HoaDonThanhToan(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_HoaDonThanhToan");
            return DataPortal.Fetch<ChungTu_HoaDonThanhToan>(new Criteria(id));
        }

        public static void DeleteChungTu_HoaDonThanhToan(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTu_HoaDonThanhToan");
            DataPortal.Delete(new Criteria(id));
        }

        public override ChungTu_HoaDonThanhToan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTu_HoaDonThanhToan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_HoaDonThanhToan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChungTu_HoaDonThanhToan");

            return base.Save();
        }

        //public void KiemTraChungTu_HoaDonThanhToan(long MaChungTu)
        //{
        //    bool _kq = false;
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();
        //        using (SqlCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;
        //            cm.CommandText = "Spd_KiemTraChungTuTrongHDTT";
        //            cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
        //            SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
        //            prmGiaTriTraVe.Direction = ParameterDirection.Output;
        //            cm.Parameters.Add(prmGiaTriTraVe);
        //            cm.ExecuteNonQuery();
        //            _kq = (bool)prmGiaTriTraVe.Value;
        //        }
        //    }//us
        //    if (_kq != false)
        //        DataPortal_Insert();
        //}

        #endregion //Factory Methods

        #region Child Factory Methods
        public static ChungTu_HoaDonThanhToan NewChungTu_HoaDonThanhToanChild()
        {
            ChungTu_HoaDonThanhToan child = new ChungTu_HoaDonThanhToan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        public static ChungTu_HoaDonThanhToan GetChungTu_HoaDonThanhToan(SafeDataReader dr)
        {
            ChungTu_HoaDonThanhToan child = new ChungTu_HoaDonThanhToan();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        public static ChungTu_HoaDonThanhToan GetChungTu_HoaDonThanhToan_deXoa(SafeDataReader dr)
        {
            ChungTu_HoaDonThanhToan child = new ChungTu_HoaDonThanhToan();
            child.MarkAsChild();
            child.FetchDeXoa(dr);
            return child;
        }

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _HoaDon.IsDirty;

            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid && _HoaDon.IsValid
                    ;
            }
        }
        #endregion
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long Id;

            public Criteria(long id)
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
                cm.CommandText = "spd_SelecttblChungTu_HoaDonThanhToan";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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

                ExecuteInsert(tr,null as ChungTu);

                //update child object(s)
                UpdateChildren(tr);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                tr = cn.BeginTransaction();
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(tr, null as ChungTu);
                }

                //update child object(s)
                UpdateChildren(tr);
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

                ExecuteDelete(tr, criteria);

            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblChungTu_HoaDonThanhToan";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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

        private void FetchDeXoa(SafeDataReader dr)
        {
            FetchObjectDeXoa(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObjectDeXoa(SafeDataReader dr)
        {
            _id = dr.GetInt64("ID");
            _maChungTu = dr.GetInt64("MaChungTu");
            _soChungTu = dr.GetString("SoChungTu");
            _maHoaDon = dr.GetInt64("MaHoaDon");
            _soHoaDon = dr.GetString("SoHoaDon");
            _ngayLap = dr.GetDateTime("NgayLap");
            _soTienThanhToan = dr.GetDecimal("SoTienThanhToan");
            _ngayChungTu = dr.GetDateTime("NgayChungTu");
            _ngayHoaDon = dr.GetDateTime("NgayHoaDon");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _isCanTruSoDauKy = dr.GetBoolean("isCanTruSoDauKy");
        }

        private void FetchObject(SafeDataReader dr)
        {
            _HoaDon = HoaDon.GetHoaDon(dr.GetInt64("MaHoaDon"));
            _id = dr.GetInt64("ID");
            _maChungTu = dr.GetInt64("MaChungTu");
            _maButToan = dr.GetInt32("MaButToan");
            _maHoaDon = dr.GetInt64("MaHoaDon");
            _maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
            _ngayLap = dr.GetDateTime("NgayLap");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _tienThue = dr.GetDecimal("TienThue");
            _soTienThanhToan = dr.GetDecimal("SoTienThanhToan");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _ngayChungTu = dr.GetDateTime("NgayChungTu");
            _ngayHoaDon = dr.GetDateTime("NgayHoaDon");
            _isCanTruSoDauKy = dr.GetBoolean("isCanTruSoDauKy");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        #region Parent ChungTu
        internal void Insert(SqlTransaction tr, ChungTu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();
            MarkAsChild();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;

                if (_HoaDon.LoaiHoaDon != 5)    //
                _HoaDon.Save(tr);

                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTu_HoaDonThanhToan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            _maChungTu = parent.MaChungTu;
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            cm.Parameters.AddWithValue("@MaHoaDon", _HoaDon.MaHoaDon);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@TienThue", _HoaDon.TienThue);
            cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);

            if (_maDoiTac == 0)
            {
                _maDoiTac = _HoaDon.MaDoiTac;
            }
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);

            cm.Parameters.AddWithValue("@IsCanTruSoDauKy", _isCanTruSoDauKy);

            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
        } 
        #endregion//Parent ChungTu


        #region Parent: HoaDon
        internal void Insert(SqlTransaction tr, HoaDon parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HoaDon parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                //_HoaDon.Save(tr);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTu_HoaDonThanhToan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HoaDon parent)
        {
            _maHoaDon = parent.MaHoaDon;
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@TienThue", parent.TienThue);
            cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);

            if (_maDoiTac == 0)
            {
                _maDoiTac = _HoaDon.MaDoiTac;
            }
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@IsCanTruSoDauKy", _isCanTruSoDauKy);

            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
        }
        #endregion//Parent: HoaDon

        #region Parent DoiTruCongNo
        internal void Insert(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                //_HoaDon.Save(tr);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTu_HoaDonThanhToan_DTCN";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, TongHopDoiTruCongNo parent)
        {
            _idDTCN = parent.Id;
            _maHoaDon = _HoaDon.MaHoaDon;
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@TienThue", _HoaDon.TienThue);
            cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);
            cm.Parameters.AddWithValue("@IdDTCN", _idDTCN);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@IsCanTruSoDauKy", _isCanTruSoDauKy);

            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
        }
        #endregion//Parent ChungTu

        #endregion //Data Access - Insert

        #region Data Access - Update
        #region Parent ChungTu
        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            if (!IsDirty) return;

            //if (base.IsDirty)
            if (IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;

                if (_HoaDon.LoaiHoaDon != 5)    //
                    _HoaDon.Save(tr);

                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_HoaDonThanhToan";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            _maChungTu = parent.MaChungTu;
            cm.Parameters.AddWithValue("@ID", _id);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@TienThue", _HoaDon.TienThue);
            cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);

            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
        }
        #endregion//Parent ChungTu

        #region HoaDon
        internal void Update(SqlTransaction tr, HoaDon parent)
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

        private void ExecuteUpdate(SqlTransaction tr, HoaDon parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                _HoaDon.Save(tr);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_HoaDonThanhToan";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HoaDon parent)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            cm.Parameters.AddWithValue("@MaHoaDon", parent.MaHoaDon);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@TienThue", parent.TienThue);
            cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);

            if (_maDoiTac == 0)
                _maDoiTac = _HoaDon.MaDoiTac;

            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);

            cm.Parameters.AddWithValue("@IsCanTruSoDauKy", _isCanTruSoDauKy);
        }
        #endregion //HoaDon

        #region Parent DoiTruCongNo
        internal void Update(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            if (!IsDirty) return;

            //if (base.IsDirty)
            if (IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                //_HoaDon.Save(tr);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_HoaDonThanhToan_DTCN";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, TongHopDoiTruCongNo parent)
        {
            _idDTCN = parent.Id;


            cm.Parameters.AddWithValue("@ID", _id);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@TienThue", _HoaDon.TienThue);
            cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);
            cm.Parameters.AddWithValue("@IdDTCN", _idDTCN);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);

            cm.Parameters.AddWithValue("@IsCanTruSoDauKy", _isCanTruSoDauKy);
        }
        #endregion//Parent ChungTu

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
