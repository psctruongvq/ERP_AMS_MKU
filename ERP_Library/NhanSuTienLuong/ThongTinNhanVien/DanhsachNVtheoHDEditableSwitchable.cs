
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DanhsachNVTheoHD : Csla.BusinessBase<DanhsachNVTheoHD>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _maQLNhanVien = string.Empty;
        private string _cardID = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _tenChucVu = string.Empty;
        private string _HinhThucHDLD = string.Empty;
        private DateTime _Tungay = DateTime.Today;
        private DateTime _Denngay =DateTime.Today;
        private int _maChucVu = 0;
        private int _maChucDanh = 0;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private DateTime _ngayVaoLam = DateTime.Today;
        private bool _gioiTinh = false;
        private string _cmnd = string.Empty;


        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                return _maQLNhanVien;
            }
            set
            {
                CanWriteProperty("MaQLNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_maQLNhanVien.Equals(value))
                {
                    _maQLNhanVien = value;
                    PropertyHasChanged("MaQLNhanVien");
                }
            }
        }

        public string CardID
        {
            get
            {
                CanReadProperty("CardID", true);
                return _cardID;
            }
            set
            {
                CanWriteProperty("CardID", true);
                if (value == null) value = string.Empty;
                if (!_cardID.Equals(value))
                {
                    _cardID = value;
                    PropertyHasChanged("CardID");
                }
            }
        }

        public string HinhThucHDLD
        {
            get
            {
                CanReadProperty(true);
                return _HinhThucHDLD;
            }          
        }
        public DateTime TuNgay
        {
            get
            {
                CanReadProperty(true);
                return _Tungay;
            }
        }
        public DateTime Denngay
        {
            get
            {
                CanReadProperty(true);
                return _Denngay;
            }
        }
        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
            set
            {
                CanWriteProperty("TenNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                return _tenChucVu;
            }
            set
            {
                CanWriteProperty("TenChucVu", true);
                if (value == null) value = string.Empty;
                if (!_tenChucVu.Equals(value))
                {
                    _tenChucVu = value;
                    PropertyHasChanged("TenChucVu");
                }
            }
        }

        public int MaChucVu
        {
            get
            {
                CanReadProperty("MaChucVu", true);
                return _maChucVu;
            }
            set
            {
                CanWriteProperty("MaChucVu", true);
                if (!_maChucVu.Equals(value))
                {
                    _maChucVu = value;
                    PropertyHasChanged("MaChucVu");
                }
            }
        }

        public int MaChucDanh
        {
            get
            {
                CanReadProperty("MaChucDanh", true);
                return _maChucDanh;
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

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
            set
            {
                CanWriteProperty("TenBoPhan", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }

        public DateTime NgayVaoLam
        {
            get
            {
                CanReadProperty("NgayVaoLam", true);
                return _ngayVaoLam.Date;
            }
            set
            {
                CanWriteProperty("NgayVaoLam", true);
                if (!_ngayVaoLam.Equals(value))
                {
                    _ngayVaoLam = value;
                    PropertyHasChanged("NgayVaoLam");
                }
            }
        }

        public bool GioiTinh
        {
            get
            {
                CanReadProperty("GioiTinh", true);
                return _gioiTinh;
            }
            set
            {
                CanWriteProperty("GioiTinh", true);
                if (!_gioiTinh.Equals(value))
                {
                    _gioiTinh = value;
                    PropertyHasChanged("GioiTinh");
                }
            }
        }

        public string Cmnd
        {
            get
            {
                CanReadProperty("Cmnd", true);
                return _cmnd;
            }
            set
            {
                CanWriteProperty("Cmnd", true);
                if (value == null) value = string.Empty;
                if (!_cmnd.Equals(value))
                {
                    _cmnd = value;
                    PropertyHasChanged("Cmnd");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
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
            // MaQLNhanVien
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLNhanVien", 50));
            //
            // CardID
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CardID", 50));
            //
            // TenNhanVien
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
            //
            // TenChucVu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 500));
            //
            // Cmnd
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 20));
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
            //TODO: Define CanGetObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTinNhanVienTongHop
            return true;
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTinNhanVienTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DanhsachNVTheoHD()
        { /* require use of factory method */ }

        public static DanhsachNVTheoHD NewDanhsachNVTheoHD(long maNhanVien)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHop");
            return DataPortal.Create<DanhsachNVTheoHD>(new Criteria(maNhanVien));
        }

        public static DanhsachNVTheoHD GetDanhsachNVTheoHD(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHop");
            return DataPortal.Fetch<DanhsachNVTheoHD>(new Criteria(maNhanVien));
        }

        public static void DeleteThongTinNhanVienTongHop(long maNhanVien)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinNhanVienTongHop");
            DataPortal.Delete(new Criteria(maNhanVien));
        }

        public override DanhsachNVTheoHD Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTinNhanVienTongHop");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHop");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThongTinNhanVienTongHop");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private DanhsachNVTheoHD(long maNhanVien)
        {
            this._maNhanVien = maNhanVien;
        }

        internal static DanhsachNVTheoHD NewDanhsachNVTheoHDChild(long maNhanVien)
        {
            DanhsachNVTheoHD child = new DanhsachNVTheoHD(maNhanVien);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DanhsachNVTheoHD GetDanhsachNVTheoHD(SafeDataReader dr)
        {
            DanhsachNVTheoHD child = new DanhsachNVTheoHD();
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
            public long MaNhanVien;

            public Criteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _maNhanVien = criteria.MaNhanVien;
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
                cm.CommandText = "spd_ThongTinNhanVien";

                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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

        #region Bo
        /*
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
			DataPortal_Delete(new Criteria(_maNhanVien));
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
				cm.CommandText = "DeleteThongTinNhanVienTongHop";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

        */
        #endregion

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
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maQLNhanVien = dr.GetString("MaQLNhanVien");
                _cardID = dr.GetString("CardID");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _tenChucVu = dr.GetString("TenChucVu");
                _maChucVu = dr.GetInt32("MaChucVu");
                _maChucDanh = dr.GetInt32("MaChucDanh");
                _ngayVaoLam = dr.GetDateTime("NgayVaonganh");
                _gioiTinh = dr.GetBoolean("GioiTinh");
                _cmnd = dr.GetString("CMND");
                _tenBoPhan = dr.GetString("Tenbophan");
                _HinhThucHDLD = dr.GetString("TenHinhthuchopdong");
                _Tungay = dr.GetDateTime("Tungay");
                _Denngay = dr.GetDateTime("Denngay");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Bo
        /*
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
				cm.CommandText = "AddThongTinNhanVienTongHop";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_maQLNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
			else
				cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
			if (_cardID.Length > 0)
				cm.Parameters.AddWithValue("@CardID", _cardID);
			else
				cm.Parameters.AddWithValue("@CardID", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_phanTramBHXH != 0)
				cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
			else
				cm.Parameters.AddWithValue("@PhanTramBHXH", DBNull.Value);
			if (_tienBHXH != 0)
				cm.Parameters.AddWithValue("@TienBHXH", _tienBHXH);
			else
				cm.Parameters.AddWithValue("@TienBHXH", DBNull.Value);
			if (_phanTramBHYT != 0)
				cm.Parameters.AddWithValue("@PhanTramBHYT", _phanTramBHYT);
			else
				cm.Parameters.AddWithValue("@PhanTramBHYT", DBNull.Value);
			if (_tienBHYT != 0)
				cm.Parameters.AddWithValue("@TienBHYT", _tienBHYT);
			else
				cm.Parameters.AddWithValue("@TienBHYT", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTienCongDoan", _soTienCongDoan);
			else
				cm.Parameters.AddWithValue("@SoTienCongDoan", DBNull.Value);
			if (_tienNopThue != 0)
				cm.Parameters.AddWithValue("@TienNopThue", _tienNopThue);
			else
				cm.Parameters.AddWithValue("@TienNopThue", DBNull.Value);
			if (_soNgayCong != 0)
				cm.Parameters.AddWithValue("@SoNgayCong", _soNgayCong);
			else
				cm.Parameters.AddWithValue("@SoNgayCong", DBNull.Value);
			if (_soNgayLamViec != 0)
				cm.Parameters.AddWithValue("@SoNgayLamViec", _soNgayLamViec);
			else
				cm.Parameters.AddWithValue("@SoNgayLamViec", DBNull.Value);
			if (_tienThucLanh != 0)
				cm.Parameters.AddWithValue("@TienThucLanh", _tienThucLanh);
			else
				cm.Parameters.AddWithValue("@TienThucLanh", DBNull.Value);
			if (_tienThucLanhTron != 0)
				cm.Parameters.AddWithValue("@TienThucLanhTron", _tienThucLanhTron);
			else
				cm.Parameters.AddWithValue("@TienThucLanhTron", DBNull.Value);
			if (_phiDoan != 0)
				cm.Parameters.AddWithValue("@Phi_Doan", _phiDoan);
			else
				cm.Parameters.AddWithValue("@Phi_Doan", DBNull.Value);
			if (_phiDang != 0)
				cm.Parameters.AddWithValue("@Phi_Dang", _phiDang);
			else
				cm.Parameters.AddWithValue("@Phi_Dang", DBNull.Value);
			if (_phanTramLCB != 0)
				cm.Parameters.AddWithValue("@PhanTramLCB", _phanTramLCB);
			else
				cm.Parameters.AddWithValue("@PhanTramLCB", DBNull.Value);
			if (_phanTramLKD != 0)
				cm.Parameters.AddWithValue("@PhanTramLKD", _phanTramLKD);
			else
				cm.Parameters.AddWithValue("@PhanTramLKD", DBNull.Value);
			if (_luongCB != 0)
				cm.Parameters.AddWithValue("@LuongCB", _luongCB);
			else
				cm.Parameters.AddWithValue("@LuongCB", DBNull.Value);
			if (_heSoLuongCB != 0)
				cm.Parameters.AddWithValue("@HeSoLuongCB", _heSoLuongCB);
			else
				cm.Parameters.AddWithValue("@HeSoLuongCB", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayVaoLam", _ngayVaoLam);
			if (_soTienHSCB != 0)
				cm.Parameters.AddWithValue("@SoTienHSCB", _soTienHSCB);
			else
				cm.Parameters.AddWithValue("@SoTienHSCB", DBNull.Value);
			if (_luongKD != 0)
				cm.Parameters.AddWithValue("@LuongKD", _luongKD);
			else
				cm.Parameters.AddWithValue("@LuongKD", DBNull.Value);
			if (_heSoLuongKD != 0)
				cm.Parameters.AddWithValue("@HeSoLuongKD", _heSoLuongKD);
			else
				cm.Parameters.AddWithValue("@HeSoLuongKD", DBNull.Value);
			if (_soTienHSKD != 0)
				cm.Parameters.AddWithValue("@SoTienHSKD", _soTienHSKD);
			else
				cm.Parameters.AddWithValue("@SoTienHSKD", DBNull.Value);
			if (_tenChiNhanh.Length > 0)
				cm.Parameters.AddWithValue("@TenChiNhanh", _tenChiNhanh);
			else
				cm.Parameters.AddWithValue("@TenChiNhanh", DBNull.Value);
			if (_gioiTinh != false)
				cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
			else
				cm.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
			if (_cmnd.Length > 0)
				cm.Parameters.AddWithValue("@CMND", _cmnd);
			else
				cm.Parameters.AddWithValue("@CMND", DBNull.Value);
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
				cm.CommandText = "UpdateThongTinNhanVienTongHop";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_maQLNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
			else
				cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
			if (_cardID.Length > 0)
				cm.Parameters.AddWithValue("@CardID", _cardID);
			else
				cm.Parameters.AddWithValue("@CardID", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			if (_tenChucVu.Length > 0)
				cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			else
				cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_maPhongBan != 0)
				cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
			else
				cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
			if (_tenPhongBan.Length > 0)
				cm.Parameters.AddWithValue("@TenPhongBan", _tenPhongBan);
			else
				cm.Parameters.AddWithValue("@TenPhongBan", DBNull.Value);
			if (_ngachLuong.Length > 0)
				cm.Parameters.AddWithValue("@NgachLuong", _ngachLuong);
			else
				cm.Parameters.AddWithValue("@NgachLuong", DBNull.Value);
			if (_phanTramBHXH != 0)
				cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
			else
				cm.Parameters.AddWithValue("@PhanTramBHXH", DBNull.Value);
			if (_tienBHXH != 0)
				cm.Parameters.AddWithValue("@TienBHXH", _tienBHXH);
			else
				cm.Parameters.AddWithValue("@TienBHXH", DBNull.Value);
			if (_phanTramBHYT != 0)
				cm.Parameters.AddWithValue("@PhanTramBHYT", _phanTramBHYT);
			else
				cm.Parameters.AddWithValue("@PhanTramBHYT", DBNull.Value);
			if (_tienBHYT != 0)
				cm.Parameters.AddWithValue("@TienBHYT", _tienBHYT);
			else
				cm.Parameters.AddWithValue("@TienBHYT", DBNull.Value);
			if (_phanTramCongDoan != 0)
				cm.Parameters.AddWithValue("@PhanTramCongDoan", _phanTramCongDoan);
			else
				cm.Parameters.AddWithValue("@PhanTramCongDoan", DBNull.Value);
			if (_phanTramDanhGiaCB != 0)
				cm.Parameters.AddWithValue("@PhanTramDanhGiaCB", _phanTramDanhGiaCB);
			else
				cm.Parameters.AddWithValue("@PhanTramDanhGiaCB", DBNull.Value);
			if (_phanTramDanhGiaKD != 0)
				cm.Parameters.AddWithValue("@PhanTramDanhGiaKD", _phanTramDanhGiaKD);
			else
				cm.Parameters.AddWithValue("@PhanTramDanhGiaKD", DBNull.Value);
			if (_soTienCongDoan != 0)
				cm.Parameters.AddWithValue("@SoTienCongDoan", _soTienCongDoan);
			else
				cm.Parameters.AddWithValue("@SoTienCongDoan", DBNull.Value);
			if (_tienNopThue != 0)
				cm.Parameters.AddWithValue("@TienNopThue", _tienNopThue);
			else
				cm.Parameters.AddWithValue("@TienNopThue", DBNull.Value);
			if (_soNgayCong != 0)
				cm.Parameters.AddWithValue("@SoNgayCong", _soNgayCong);
			else
				cm.Parameters.AddWithValue("@SoNgayCong", DBNull.Value);
			if (_soNgayLamViec != 0)
				cm.Parameters.AddWithValue("@SoNgayLamViec", _soNgayLamViec);
			else
				cm.Parameters.AddWithValue("@SoNgayLamViec", DBNull.Value);
			if (_tienThucLanh != 0)
				cm.Parameters.AddWithValue("@TienThucLanh", _tienThucLanh);
			else
				cm.Parameters.AddWithValue("@TienThucLanh", DBNull.Value);
			if (_tienThucLanhTron != 0)
				cm.Parameters.AddWithValue("@TienThucLanhTron", _tienThucLanhTron);
			else
				cm.Parameters.AddWithValue("@TienThucLanhTron", DBNull.Value);
			if (_phiDoan != 0)
				cm.Parameters.AddWithValue("@Phi_Doan", _phiDoan);
			else
				cm.Parameters.AddWithValue("@Phi_Doan", DBNull.Value);
			if (_phiDang != 0)
				cm.Parameters.AddWithValue("@Phi_Dang", _phiDang);
			else
				cm.Parameters.AddWithValue("@Phi_Dang", DBNull.Value);
			if (_phanTramLCB != 0)
				cm.Parameters.AddWithValue("@PhanTramLCB", _phanTramLCB);
			else
				cm.Parameters.AddWithValue("@PhanTramLCB", DBNull.Value);
			if (_phanTramLKD != 0)
				cm.Parameters.AddWithValue("@PhanTramLKD", _phanTramLKD);
			else
				cm.Parameters.AddWithValue("@PhanTramLKD", DBNull.Value);
			if (_luongCB != 0)
				cm.Parameters.AddWithValue("@LuongCB", _luongCB);
			else
				cm.Parameters.AddWithValue("@LuongCB", DBNull.Value);
			if (_heSoLuongCB != 0)
				cm.Parameters.AddWithValue("@HeSoLuongCB", _heSoLuongCB);
			else
				cm.Parameters.AddWithValue("@HeSoLuongCB", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayVaoLam", _ngayVaoLam);
			if (_soTienHSCB != 0)
				cm.Parameters.AddWithValue("@SoTienHSCB", _soTienHSCB);
			else
				cm.Parameters.AddWithValue("@SoTienHSCB", DBNull.Value);
			if (_luongKD != 0)
				cm.Parameters.AddWithValue("@LuongKD", _luongKD);
			else
				cm.Parameters.AddWithValue("@LuongKD", DBNull.Value);
			if (_heSoLuongKD != 0)
				cm.Parameters.AddWithValue("@HeSoLuongKD", _heSoLuongKD);
			else
				cm.Parameters.AddWithValue("@HeSoLuongKD", DBNull.Value);
			if (_soTienHSKD != 0)
				cm.Parameters.AddWithValue("@SoTienHSKD", _soTienHSKD);
			else
				cm.Parameters.AddWithValue("@SoTienHSKD", DBNull.Value);
			if (_tenChiNhanh.Length > 0)
				cm.Parameters.AddWithValue("@TenChiNhanh", _tenChiNhanh);
			else
				cm.Parameters.AddWithValue("@TenChiNhanh", DBNull.Value);
			if (_gioiTinh != false)
				cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
			else
				cm.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
			if (_cmnd.Length > 0)
				cm.Parameters.AddWithValue("@CMND", _cmnd);
			else
				cm.Parameters.AddWithValue("@CMND", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete 
        */
        #endregion


        #endregion //Data Access
    }
}
