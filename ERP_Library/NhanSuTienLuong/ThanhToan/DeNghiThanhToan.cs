using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class DeNghiThanhToan : Csla.BusinessBase<DeNghiThanhToan>
    {
        #region Business Properties and Methods

        //declare members
        internal long _maPhieu = 0;
        private string _so = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private long _maNhanVien = ERP_Library.Security.CurrentUser.Info.MaNhanVien;
        private string _lyDo = string.Empty;
        private decimal _soTien = 0;
        private string _maPhanHe = string.Empty;
        private string _tinhTrang = "";
        private DeNghiThanhToan_ChungTuList _chungtu;
        private bool _hoanTat = false;
        private int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        private int _phanLoai = 0;
        /// <summary>
        /// Tran Them vao xu ly thu chi
        /// 
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private decimal _soTienThanhToan = 0; // 
 
        private decimal _tongTien = 0; // la tong tien tam luu cho so tien Thanh Toan
        private decimal _soTienConLai = 0;
        private long _maCTDNTT = 0;

        public long MaCTDNTT
        {
            get { return _maCTDNTT; }
            set { _maCTDNTT = value; }
        }
        
       
        private Boolean _check = false;
        private ChungTu_DeNghiThanhToanChildList _chungTu_DeNghiThanhToan;

       
        /// </summary>
        public decimal SoTienConLai
        {
            get { return _soTienConLai; }
            set {

               
                if (!_soTienConLai.Equals(value))
                {
                    _soTienConLai = value;
                    PropertyHasChanged("SoTienConLai");
                }
            }
        }
        public ChungTu_DeNghiThanhToanChildList ChungTu_DeNghiThanhToan
        {
            get {
                CanReadProperty(true);
                return _chungTu_DeNghiThanhToan; }
            set {
                CanWriteProperty(true);
                _chungTu_DeNghiThanhToan = value; }
        }
        public Boolean Check
        {
            get { return _check; }
            set 
            {
                _check = value; 
                //if (_check == true)
                //{
                //    _tongTien = _soTien;
                //    _tongTien = _soTien;
                //    _soTien = 0;

                //}
               
               
            
            }
        }
        public decimal SoTienThanhToan
        {
            get { return _soTienThanhToan; }
            set { _soTienThanhToan = value; }
        }
        public decimal TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
        [System.ComponentModel.DataObjectField(true, true)]
        public long MaPhieu
        {
            get
            {
                return _maPhieu;
            }
        }

        public string So
        {
            get
            {
                return _so;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_so.Equals(value))
                {
                    _so = value;
                    PropertyHasChanged("So");
                }
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _ngay;
            }
            set
            {
                if (!_ngay.Equals(value))
                {
                    _ngay = value;
                    PropertyHasChanged("Ngay");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }
        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);

                return BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
            }

        }
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }
        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);

                return NhanVien.GetNhanVien(_maNhanVien).TenNhanVien;
            }
            
        }

        public string LyDo
        {
            get
            {
                return _lyDo;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
                }
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        public string MaPhanHe
        {
            get
            {
                return _maPhanHe;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maPhanHe.Equals(value))
                {
                    _maPhanHe = value;
                    PropertyHasChanged("MaPhanHe");
                }
            }
        }

        public string TinhTrang
        {
            get
            {
                return _tinhTrang;
            }
            set
            {
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool HoanTat
        {
            get
            {
                return _hoanTat;
            }
            set
            {
                if (!_hoanTat.Equals(value))
                {
                    _hoanTat = value;
                    PropertyHasChanged();
                }
            }
        }

        public int PhanLoai
        {
            get
            {
                return _phanLoai;
            }
            set
            {
                if (!_phanLoai.Equals(value))
                {
                    _phanLoai = value;
                    PropertyHasChanged();
                }
            }
        }

        public DeNghiThanhToan_ChungTuList ChungTu
        {
            get
            {
                return _chungtu;
            }
        }

        protected override object GetIdValue()
        {
            return _maPhieu;
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
            // So
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "So");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("So", 50));
            //
            // LyDo
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "LyDo");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 250));
            //
            // MaPhanHe
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaPhanHe");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhanHe", 50));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeNghiThanhToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThanhToanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeNghiThanhToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThanhToanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeNghiThanhToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThanhToanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeNghiThanhToan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThanhToanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DeNghiThanhToan()
        { /* require use of factory method */
            _chungtu = DeNghiThanhToan_ChungTuList.NewDeNghiThanhToan_ChungTuList();
        }

        public static DeNghiThanhToan NewDeNghiThanhToan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiThanhToan");
            return DataPortal.Create<DeNghiThanhToan>();
        }

        public static DeNghiThanhToan GetDeNghiThanhToan(long maPhieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiThanhToan");
            return DataPortal.Fetch<DeNghiThanhToan>(new Criteria(maPhieu));
        }

        public static void DeleteDeNghiThanhToan(long maPhieu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiThanhToan");
            DataPortal.Delete(new Criteria(maPhieu));
        }

        public override DeNghiThanhToan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiThanhToan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiThanhToan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DeNghiThanhToan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DeNghiThanhToan NewDeNghiThanhToanChild()
        {
            DeNghiThanhToan child = new DeNghiThanhToan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DeNghiThanhToan GetDeNghiThanhToan(SafeDataReader dr)
        {
            DeNghiThanhToan child = new DeNghiThanhToan();
            child.MarkAsChild();
            child.Fetch(dr);
            child._chungtu = DeNghiThanhToan_ChungTuList.GetDeNghiThanhToan_ChungTuList(child._maPhieu);
            child._chungTu_DeNghiThanhToan = ChungTu_DeNghiThanhToanChildList.GetChungTu_DeNghiThanhToanChildList(child.MaPhieu);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaPhieu;

            public Criteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
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
                cm.CommandText = "spd_Select_DeNghiThanhToan";

                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
            _chungtu = DeNghiThanhToan_ChungTuList.GetDeNghiThanhToan_ChungTuList(_maPhieu);
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
            DataPortal_Delete(new Criteria(_maPhieu));
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
                cm.CommandText = "spd_Delete_DeNghiThanhToan";

                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

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
            _maPhieu = dr.GetInt64("MaPhieu");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _lyDo = dr.GetString("LyDo");
            _soTien = dr.GetDecimal("SoTien");
            _maPhanHe = dr.GetString("MaPhanHe");
            _tinhTrang = dr.GetString("TinhTrang");
            _hoanTat = dr.GetBoolean("HoanTat");
            _userID = dr.GetInt32("UserID");
            _phanLoai = dr.GetInt32("PhanLoai");
            if (dr.GetDecimal("SoTienConLai") != null)
                _soTienConLai = dr.GetDecimal("SoTienConLai");
            else
                _soTienConLai = 0;
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
                cm.CommandText = "spd_Insert_DeNghiThanhToan";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maPhieu = (long)cm.Parameters["@MaPhieu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@So", _so);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@MaPhanHe", _maPhanHe);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            cm.Parameters.AddWithValue("@PhanLoai", _phanLoai);
            cm.Parameters["@MaPhieu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_DeNghiThanhToan";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            cm.Parameters.AddWithValue("@So", _so);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@MaPhanHe", _maPhanHe);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@PhanLoai", _phanLoai);
            cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
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

            ExecuteDelete(tr, new Criteria(_maPhieu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _chungtu.IsDirty;
            }
        }

        /// <summary>
        /// Tìm số phiếu mới = tổng số phiếu hiện có + 1
        /// </summary>
        /// <returns></returns>
        public string SoPhieuMoi()
        {
            int c = 1;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "Select Count(*) From tblDeNghiThanhToan Where UserID = @UserID";
                cm.Parameters.AddWithValue("@UserID", _userID);
                c = Convert.ToInt32(cm.ExecuteScalar()) + 1;
                cn.Close();
            }
            return c + "/" + BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).MaBoPhanQL;
        }
    }
}
