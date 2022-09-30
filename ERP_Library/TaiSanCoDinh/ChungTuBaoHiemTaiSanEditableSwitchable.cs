using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//12_04_2013
///
namespace ERP_Library
{
    [Serializable()]
    public class ChungTuBaoHiemTaiSan : BusinessBase<ChungTuBaoHiemTaiSan>
    {
        #region Business Properties and Methods
        //declare members
        private long _ID = 0;
        private string _soChungTu = string.Empty;        
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private SmartDate _tuNgay = new SmartDate(DateTime.Today);
        private SmartDate _denNgay = new SmartDate(DateTime.Today);
        private int _userID = 0;              
        private decimal _tongGiaTriBaoHiem = 0;
        private long _maDoiTac = 0;
        private string _dienGiai = string.Empty;
       
        //declare child member(s)
        private CT_ChungTuBaoHiemTaiSanList _cT_ChungTuBaoHiemTaiSanList = CT_ChungTuBaoHiemTaiSanList.NewCT_ChungTuBaoHiemTaiSanList();        

        [System.ComponentModel.DataObjectField(true, true)]      

        public long ID
        {
            get
            {
                CanReadProperty("MaPhieuNhapXuat", true);
                return _ID;
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
                _ngayLap = new SmartDate(value);
                PropertyHasChanged("NgayLap");
            }
        }
        public int UserID
        {
            get
            {
                CanReadProperty("UserID", true);
                return _userID;
            }
            set
            {
                CanWriteProperty("UserID", true);
                if (!_userID.Equals(value))
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
                }
            }
        }
        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay.Date;
            }
            set
            {

                CanWriteProperty("TuNgay", true);
                _tuNgay = new SmartDate(value);
                PropertyHasChanged("TuNgay");
            }
        }
        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay.Date;
            }
            set
            {
                CanWriteProperty("DenNgay", true);
                _denNgay = new SmartDate(value);
                PropertyHasChanged("DenNgay");
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

        public decimal TongGiaTriBaoHiem
        {
            get
            {
                CanReadProperty("TongGiaTriBaoHiem", true);
                return _tongGiaTriBaoHiem;
            }
            set
            {
                CanWriteProperty("TongGiaTriBaoHiem", true);
                if (!_tongGiaTriBaoHiem.Equals(value))
                {
                    _tongGiaTriBaoHiem = value;                   
                    PropertyHasChanged("TongGiaTriBaoHiem");
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
       
        public CT_ChungTuBaoHiemTaiSanList CT_ChungTuBaoHiemTaiSanList
        {
            get
            {
                CanReadProperty("CT_ChungTuBaoHiemTaiSanList", true);
                return _cT_ChungTuBaoHiemTaiSanList;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _cT_ChungTuBaoHiemTaiSanList.IsValid;  }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cT_ChungTuBaoHiemTaiSanList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _ID;
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
        }

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTuBaoHiemTaiSan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTuBaoHiemTaiSan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTuBaoHiemTaiSan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTuBaoHiemTaiSan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhieuNhapXuatDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTuBaoHiemTaiSan()
        { /* require use of factory method */ }

        public static ChungTuBaoHiemTaiSan NewChungTuBaoHiemTaiSan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuBaoHiemTaiSan");
            return DataPortal.Create<ChungTuBaoHiemTaiSan>();
        }      
       
        public static ChungTuBaoHiemTaiSan GetChungTuBaoHiemTaiSan(long ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuBaoHiemTaiSan");
            return DataPortal.Fetch<ChungTuBaoHiemTaiSan>(new Criteria(ID));
        }         

        public static void DeleteChungTuBaoHiemTaiSan(long ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTuBaoHiemTaiSan");
            DataPortal.Delete(new Criteria(ID));
        }

        public override ChungTuBaoHiemTaiSan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChungTuBaoHiemTaiSan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuBaoHiemTaiSan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChungTuBaoHiemTaiSan");

            return base.Save();
        }
        #region Get Max Ma Phieu Nhap Xuat
        public static long GetMaxMaChungTuBaoHiemTaiSan(int year, int month, int maCongTy)
        {
            long _maxMaPhieuNhapXuat = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetMaxMaPhieuNhapXuat";
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.BigInt, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _maxMaPhieuNhapXuat = (long)prmGiaTriTraVe.Value;
                }
            }//us
            return _maxMaPhieuNhapXuat;
        }

        public static long KiemTraPhieu(long maPhieuNhapXuat)
        {
            long _count = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhieuNhapXuatThang";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.BigInt, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _count = (long)prmGiaTriTraVe.Value;
                }
            }//us
            return _count;
        }       

        public static bool KiemTraNgayNhap(long maPhieuNhapXuat,DateTime ngayNhap)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraNgayNhap";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@ngayNhap", ngayNhap);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;   //true: ngay nhap > ngay xuat -> ko hop le
                }
            }//us
            return _kq;
        }

        public static bool KiemTraPhieuXuatThangTuPhieuNhap(long ID)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhieuXuatThangTuPhieuNhap";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", ID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }
        public static bool KiemTraPhieuXuatTuDSPhieuDeNghiLinh(long ID)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraPhieuXuatTuDSPhieuDeNghiLinh";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", ID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }
        #endregion//END Get Max Ma Phieu Nhap Xuat

        public static string Get_NextSoChungTuBaoHiemTaiSan(int nam, int thang, int userID, int size = 4)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_MaxSoChungTuBaoHiemTaiSan";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@Nam", nam);
                    cm.Parameters.AddWithValue("@Thang", thang);
                    cm.Parameters.AddWithValue("@UserID", userID);
                    cm.Parameters.AddWithValue("@Size", size);                  
                    SqlParameter outPara = new SqlParameter("@SoTTChungTu", SqlDbType.NVarChar, 50);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();                    
                   
                    return outPara.Value.ToString();
                }
            }
        }
        #endregion //Factory Methods
      
        internal static ChungTuBaoHiemTaiSan GetChungTuBaoHiemTaiSan(SafeDataReader dr)
        {
            ChungTuBaoHiemTaiSan child = new ChungTuBaoHiemTaiSan();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static ChungTuBaoHiemTaiSan GetPhieuNhapXuatKhongChild(SafeDataReader dr)
        {
            ChungTuBaoHiemTaiSan child = new ChungTuBaoHiemTaiSan();
            child.MarkAsChild();
            child.FetchKhongChild(dr);
            return child;
        }

        internal static ChungTuBaoHiemTaiSan NewPhieuNhapXuatChild()
        {
            ChungTuBaoHiemTaiSan child = new ChungTuBaoHiemTaiSan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }
       
        #region
        public static void DeleteChungTuBaoHiemTaiSan(ChungTuBaoHiemTaiSan chungTuBaoHiemTaiSan)
        {//B
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    chungTuBaoHiemTaiSan._cT_ChungTuBaoHiemTaiSanList.Clear();
                    chungTuBaoHiemTaiSan._cT_ChungTuBaoHiemTaiSanList.Update(tr, chungTuBaoHiemTaiSan);
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletettblNghiepVuBaoHiemTaiSan";

                        cm.Parameters.AddWithValue("@ID", chungTuBaoHiemTaiSan.ID);
                        cm.ExecuteNonQuery();
                    }//using            
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }//E
        #endregion

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long ID;

            public Criteria(long id)
            {
                this.ID = id;
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
                cm.CommandTimeout = 900;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblNghiepVuBaoHiemTaiSan";
                    cm.Parameters.AddWithValue("@ID", ((Criteria)criteria).ID);
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
            DataPortal_Delete(new Criteria(_ID));
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
                    _cT_ChungTuBaoHiemTaiSanList.Clear();
                    _cT_ChungTuBaoHiemTaiSanList.Update(tr, this);                   
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
                cm.CommandText = "spd_DeletetblPhieuNhapXuat";

                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", criteria.ID);
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
       
        private void FetchKhongChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();
        }

        private void FetchObject(SafeDataReader dr)
        {
            _ID = dr.GetInt64("ID");
            _soChungTu = dr.GetString("SoChungTu");          
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _userID = dr.GetInt32("UserID");         
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _tongGiaTriBaoHiem = dr.GetDecimal("TongGiaTriBaoHiem");
            _dienGiai = dr.GetString("DienGiai");         
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);          
        }

        private void FetchObject_SoHoaDon(SafeDataReader dr)
        {
            _ID = dr.GetInt64("ID");
            _soChungTu = dr.GetString("SoChungTu");            
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _userID = dr.GetInt32("MaNguoiLap");          
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _tongGiaTriBaoHiem = dr.GetDecimal("TongGiaTriBaoHiem");
            _dienGiai = dr.GetString("DienGiai");           
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);           
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _cT_ChungTuBaoHiemTaiSanList = CT_ChungTuBaoHiemTaiSanList.GetCT_ChungTuBaoHiemTaiSanList(this.ID);        
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
                cm.CommandText = "spd_InserttblNghiepVuBaoHiemTaiSan";

                AddInsertParameters(cm);
                cm.ExecuteNonQuery();

                _ID = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {       
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);           
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);          
            if (_tuNgay.Date != DateTime.MinValue)
            {
                cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            }
            else
                cm.Parameters.AddWithValue("@TuNgay", DBNull.Value);
            if (_denNgay.Date != DateTime.MinValue)
            {
                cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            }
            else
                cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);            
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_tongGiaTriBaoHiem != 0)
                cm.Parameters.AddWithValue("@TongGiaTriBaoHiem", _tongGiaTriBaoHiem);
            else
                cm.Parameters.AddWithValue("@TongGiaTriBaoHiem", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);                    
           
            cm.Parameters.AddWithValue("@ID", _ID);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatettblNghiepVuBaoHiemTaiSan";

                AddUpdateParameters(cm);
                cm.ExecuteNonQuery();
            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _ID);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);           
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            if (_userID != 0)
                cm.Parameters.AddWithValue("@UserID", _userID);
            else
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);           
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_tongGiaTriBaoHiem != 0)
                cm.Parameters.AddWithValue("@TongGiaTriBaoHiem", _tongGiaTriBaoHiem);
            else
                cm.Parameters.AddWithValue("@TongGiaTriBaoHiem", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);              
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _cT_ChungTuBaoHiemTaiSanList.Update(tr, this);              
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
            _cT_ChungTuBaoHiemTaiSanList.Clear();
            _cT_ChungTuBaoHiemTaiSanList.Update(tr,this);
            ExecuteDelete(tr);
            MarkNew();
        }
        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletettblNghiepVuBaoHiemTaiSan";

                cm.Parameters.AddWithValue("@ID", this._ID);
                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
