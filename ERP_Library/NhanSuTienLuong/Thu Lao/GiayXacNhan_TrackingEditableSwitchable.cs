
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class GiayXacNhan_Tracking : Csla.BusinessBase<GiayXacNhan_Tracking>
	{
		#region Business Properties and Methods

		//declare members
		private int _trackingID = 0;
		private int _maGiayXacNhan = 0;
		private string _tenGiayXacNhan = string.Empty;
		private int _maChiTietGiayXacNhan = 0;
		private decimal _soTien = 0;
		private decimal _soTienDaNhapNV = 0;
		private decimal _soTienDaNhapNVNgoaiDai = 0;
		private decimal _soTienConLai = 0;
	//	private int _databasenumberGxn = 0;
		private int _maBoPhanGui = 0;
		private string _tenBoPhanGui = string.Empty;
		private int _maBoPhanNhan = 0;
		private string _tenBoPhanNhan = string.Empty;
		private int _maChuongTrinh = 0;
		private string _tenChuongTrinh = string.Empty;
		private SmartDate _ngayLapGXN = new SmartDate(false);
		private SmartDate _ngayLap = new SmartDate(false);
		private int _nguoiLap = 0;
		private bool _tinhTrang = false;
		private string _ghiChu = string.Empty;
        private bool _isDelete = false;
        private decimal _soTienDaNhapNVTienMat = 0;
        private bool _duocNhapHo = false;
        private decimal _soTienDaNhapTrongDinhMuc = 0;
        private decimal _soTienChuaDeNghiCK = 0;

        private decimal _soTienDaDeNghiCK = 0;
        private decimal _tienThue = 0;

        private string _cMND = string.Empty;
        private string _mST = string.Empty;
        private string _tenNhanVien = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]

        public string CMND
        {
            get
            {
                CanReadProperty("CMND", true);
                return _cMND;
            }
        }
        public string MST
        {
            get
            {
                CanReadProperty("MST", true);
                return _mST;
            }
        }
        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
        }
		public int TrackingID
		{
			get
			{
				CanReadProperty("TrackingID", true);
				return _trackingID;
			}
		}

		public int MaGiayXacNhan
		{
			get
			{
				CanReadProperty("MaGiayXacNhan", true);
				return _maGiayXacNhan;
			}
			set
			{
				CanWriteProperty("MaGiayXacNhan", true);
				if (!_maGiayXacNhan.Equals(value))
				{
					_maGiayXacNhan = value;
					PropertyHasChanged("MaGiayXacNhan");
				}
			}
		}

		public string TenGiayXacNhan
		{
			get
			{
				CanReadProperty("TenGiayXacNhan", true);
				return _tenGiayXacNhan;
			}
			set
			{
				CanWriteProperty("TenGiayXacNhan", true);
				if (value == null) value = string.Empty;
				if (!_tenGiayXacNhan.Equals(value))
				{
					_tenGiayXacNhan = value;
					PropertyHasChanged("TenGiayXacNhan");
				}
			}
		}

		public int MaChiTietGiayXacNhan
		{
			get
			{
				CanReadProperty("MaChiTietGiayXacNhan", true);
				return _maChiTietGiayXacNhan;
			}
			set
			{
				CanWriteProperty("MaChiTietGiayXacNhan", true);
				if (!_maChiTietGiayXacNhan.Equals(value))
				{
					_maChiTietGiayXacNhan = value;
					PropertyHasChanged("MaChiTietGiayXacNhan");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

		public decimal SoTienDaNhapNV
		{
			get
			{
				CanReadProperty("SoTienDaNhapNV", true);
				return _soTienDaNhapNV;
			}
			set
			{
				CanWriteProperty("SoTienDaNhapNV", true);
				if (!_soTienDaNhapNV.Equals(value))
				{
					_soTienDaNhapNV = value;
					PropertyHasChanged("SoTienDaNhapNV");
				}
			}
		}

		public decimal SoTienDaNhapNVNgoaiDai
		{
			get
			{
				CanReadProperty("SoTienDaNhapNVNgoaiDai", true);
				return _soTienDaNhapNVNgoaiDai;
			}
			set
			{
				CanWriteProperty("SoTienDaNhapNVNgoaiDai", true);
				if (!_soTienDaNhapNVNgoaiDai.Equals(value))
				{
					_soTienDaNhapNVNgoaiDai = value;
					PropertyHasChanged("SoTienDaNhapNVNgoaiDai");
				}
			}
		}

		public decimal SoTienConLai
		{
			get
			{
				CanReadProperty("SoTienConLai", true);
				return _soTienConLai;
			}
			set
			{
				CanWriteProperty("SoTienConLai", true);
				if (!_soTienConLai.Equals(value))
				{
					_soTienConLai = value;
					PropertyHasChanged("SoTienConLai");
				}
			}
		}
        public decimal SoTienDaNhapNVTienMat
		{
			get
			{
                CanReadProperty("SoTienDaNhapNVTienMat", true);
                return _soTienDaNhapNVTienMat;
			}
			set
			{
                CanWriteProperty("SoTienDaNhapNVTienMat", true);
                if (!_soTienDaNhapNVTienMat.Equals(value))
				{
                    _soTienDaNhapNVTienMat = value;
                    PropertyHasChanged("SoTienDaNhapNVTienMat");
				}
			}
		}
        public decimal SoTienDaNhapTrongDinhMuc
        {
            get
            {
                CanReadProperty("SoTienDaNhapTrongDinhMuc", true);
                return _soTienDaNhapTrongDinhMuc;
            }
            set
            {
                CanWriteProperty("SoTienDaNhapTrongDinhMuc", true);
                if (!_soTienDaNhapTrongDinhMuc.Equals(value))
                {
                    _soTienDaNhapTrongDinhMuc = value;
                    PropertyHasChanged("SoTienDaNhapTrongDinhMuc");
                }
            }
        }

        public decimal SoTienChuaDeNghiCK
        {
            get { return _soTienChuaDeNghiCK; }
            set { _soTienChuaDeNghiCK = value; }
        }
        public decimal SoTienDaDeNghiCK
        {
            get { return _soTienDaDeNghiCK; }
            set { _soTienDaDeNghiCK = value; }
        }
		public int MaBoPhanGui
		{
			get
			{
				CanReadProperty("MaBoPhanGui", true);
				return _maBoPhanGui;
			}
			set
			{
				CanWriteProperty("MaBoPhanGui", true);
				if (!_maBoPhanGui.Equals(value))
				{
					_maBoPhanGui = value;
					PropertyHasChanged("MaBoPhanGui");
				}
			}
		}

		public string TenBoPhanGui
		{
			get
			{
				CanReadProperty("TenBoPhanGui", true);
				return _tenBoPhanGui;
			}
			set
			{
				CanWriteProperty("TenBoPhanGui", true);
				if (value == null) value = string.Empty;
				if (!_tenBoPhanGui.Equals(value))
				{
					_tenBoPhanGui = value;
					PropertyHasChanged("TenBoPhanGui");
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

		public string TenBoPhanNhan
		{
			get
			{
				CanReadProperty("TenBoPhanNhan", true);
				return _tenBoPhanNhan;
			}
			set
			{
				CanWriteProperty("TenBoPhanNhan", true);
				if (value == null) value = string.Empty;
				if (!_tenBoPhanNhan.Equals(value))
				{
					_tenBoPhanNhan = value;
					PropertyHasChanged("TenBoPhanNhan");
				}
			}
		}

		public int MaChuongTrinh
		{
			get
			{
				CanReadProperty("MaChuongTrinh", true);
				return _maChuongTrinh;
			}
			set
			{
				CanWriteProperty("MaChuongTrinh", true);
				if (!_maChuongTrinh.Equals(value))
				{
					_maChuongTrinh = value;
					PropertyHasChanged("MaChuongTrinh");
				}
			}
		}

		public string TenChuongTrinh
		{
			get
			{
				CanReadProperty("TenChuongTrinh", true);
				return _tenChuongTrinh;
			}
			set
			{
				CanWriteProperty("TenChuongTrinh", true);
				if (value == null) value = string.Empty;
				if (!_tenChuongTrinh.Equals(value))
				{
					_tenChuongTrinh = value;
					PropertyHasChanged("TenChuongTrinh");
				}
			}
		}

		public DateTime NgayLapGXN
		{
			get
			{
				CanReadProperty("NgayLapGXN", true);
				return _ngayLapGXN.Date;
			}
            set
            {
                CanWriteProperty("NgayLapGXN", true);
                if (!_ngayLapGXN.Equals(value))
                {
                    _ngayLapGXN = new SmartDate(value);
                    PropertyHasChanged("NgayLapGXN");
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
                    _ngayLap = new SmartDate(value);
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

		public bool TinhTrang
		{
			get
			{
				CanReadProperty("TinhTrang", true);
				return _tinhTrang;
			}
			set
			{
				CanWriteProperty("TinhTrang", true);
				if (!_tinhTrang.Equals(value))
				{
					_tinhTrang = value;
					PropertyHasChanged("TinhTrang");
				}
			}
		}
        public bool IsDelete
        {
            get
            {
                CanReadProperty("IsDelete", true);
                return _isDelete;
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
        public bool DuocNhapHo
        {
            get
            {
                CanReadProperty("DuocNhapHo", true);
                return _duocNhapHo;
            }
            set
            {
                CanWriteProperty("DuocNhapHo", true);
                if (!_duocNhapHo.Equals(value))
                {
                    _duocNhapHo = value;
                    PropertyHasChanged("DuocNhapHo");
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
		protected override object GetIdValue()
		{
			return _trackingID;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
            ////
            //// TenGiayXacNhan
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenGiayXacNhan", 50));
            ////
            //// TenBoPhanGui
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhanGui", 50));
            ////
            //// TenBoPhanNhan
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhanNhan", 50));
            ////
            //// TenChuongTrinh
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChuongTrinh", 50));
            ////
            //// GhiChu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
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
			//TODO: Define authorization rules in GiayXacNhan_Tracking
			//AuthorizationRules.AllowRead("TrackingID", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("MaGiayXacNhan", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("TenGiayXacNhan", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("MaChiTietGiayXacNhan", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("SoTienDaNhapNV", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("SoTienDaNhapNVNgoaiDai", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("SoTienConLai", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("DatabasenumberGxn", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhanGui", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhanGui", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhanNhan", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhanNhan", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("MaChuongTrinh", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("TenChuongTrinh", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("NgayLapGXN", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("NgayLapGXNString", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("TinhTrang", "GiayXacNhan_TrackingReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "GiayXacNhan_TrackingReadGroup");

			//AuthorizationRules.AllowWrite("MaGiayXacNhan", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("TenGiayXacNhan", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiTietGiayXacNhan", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienDaNhapNV", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienDaNhapNVNgoaiDai", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienConLai", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("DatabasenumberGxn", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhanGui", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhanGui", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhanNhan", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhanNhan", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuongTrinh", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("TenChuongTrinh", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapGXNString", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTrang", "GiayXacNhan_TrackingWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "GiayXacNhan_TrackingWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in GiayXacNhan_Tracking
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhan_TrackingViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in GiayXacNhan_Tracking
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhan_TrackingAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in GiayXacNhan_Tracking
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhan_TrackingEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in GiayXacNhan_Tracking
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhan_TrackingDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private GiayXacNhan_Tracking()
		{ /* require use of factory method */ }

		public static GiayXacNhan_Tracking NewGiayXacNhan_Tracking()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GiayXacNhan_Tracking");
			return DataPortal.Create<GiayXacNhan_Tracking>();
		}

		public static GiayXacNhan_Tracking GetGiayXacNhan_Tracking(int trackingID)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a GiayXacNhan_Tracking");
			return DataPortal.Fetch<GiayXacNhan_Tracking>(new Criteria(trackingID));
		}
        public static GiayXacNhan_Tracking GetGiayXacNhan_Tracking(int maChiTietGXN,int databaseNumberGXN)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayXacNhan_Tracking");
            return DataPortal.Fetch<GiayXacNhan_Tracking>(new CriteriaByDatabase(maChiTietGXN,databaseNumberGXN));
        }
		public static void DeleteGiayXacNhan_Tracking(int trackingID)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GiayXacNhan_Tracking");
			DataPortal.Delete(new Criteria(trackingID));
		}
        /// <summary>
        /// Hàm cập nhật số tiền cho giấy xác nhận.
        /// </summary>
        /// <param name="maChiTietGiayXacNhan">Mã Chi Tiết Giấy Xác Nhận</param>
        /// <param name="dataBaseNumberGXN">DatabaseNumber của GXN</param>
        
        public static void UpdateSoTienDaNhapChiTietGiayXacNhan(int trackingID,int maChiTietGiayXacNhan,int maBoPhanNhan)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 0;
                cm.CommandText = "UpdateSoTienDaNhapChiTietGiayXacNhan";
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
             
                cm.Parameters.AddWithValue("@TrackingID", trackingID);
                cm.Parameters.AddWithValue("@MaBoPhanNhan", maBoPhanNhan);
                
                cm.ExecuteNonQuery();

            }
        }
        public static decimal SoTienConLaiGXN(int maChiTietGiayXacNhan)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SoTienConLaiChiTietGiayXacNhan";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                    cm.Parameters.AddWithValue("@SoTienConLai", soTienConLai);
                    cm.Parameters["@SoTienConLai"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    soTienConLai = (decimal)cm.Parameters["@SoTienConLai"].Value;
                }
                catch (Exception ex) { soTienConLai = 0; }
               
                
            }
            return soTienConLai;
        }
		public override GiayXacNhan_Tracking Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GiayXacNhan_Tracking");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GiayXacNhan_Tracking");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a GiayXacNhan_Tracking");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static GiayXacNhan_Tracking NewGiayXacNhan_TrackingChild()
		{
			GiayXacNhan_Tracking child = new GiayXacNhan_Tracking();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static GiayXacNhan_Tracking GetGiayXacNhan_Tracking(SafeDataReader dr)
		{
			GiayXacNhan_Tracking child =  new GiayXacNhan_Tracking();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static GiayXacNhan_Tracking GetGiayXacNhan_TrackingDeNghiChuyenKhoan(SafeDataReader dr)
        {
            GiayXacNhan_Tracking child = new GiayXacNhan_Tracking();
            child.MarkAsChild();
            child.MarkOld();
            child._tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            child.TenBoPhanGui = dr.GetString("TenBoPhanGui");
            child.TenBoPhanNhan = dr.GetString("TenBoPhanNhan");
            child.TenChuongTrinh = dr.GetString("TenChuongTrinh");
            child.SoTien = dr.GetDecimal("SoTienTruocThue");
            child.DuocNhapHo = dr.GetBoolean("DuocNhapHo");
            child.TienThue = dr.GetDecimal("TienThue");
            child.SoTienConLai = dr.GetDecimal("SoTien");
            return child;
        }

        internal static GiayXacNhan_Tracking GetGiayXacNhan_TrackingDeNghiChuyenKhoanByNhanVien(SafeDataReader dr)
        {
            GiayXacNhan_Tracking child = new GiayXacNhan_Tracking();
            child.MarkAsChild();
            child.MarkOld();
            child._tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            child.TenBoPhanGui = dr.GetString("TenBoPhanGui");
            child.TenBoPhanNhan = dr.GetString("TenBoPhanNhan");
            child.TenChuongTrinh = dr.GetString("TenChuongTrinh");
            child.SoTien = dr.GetDecimal("SoTienTruocThue");
            child.DuocNhapHo = dr.GetBoolean("DuocNhapHo");
            child.TienThue = dr.GetDecimal("TienThue");
            child.SoTienConLai = dr.GetDecimal("SoTien");
            child._cMND = dr.GetString("CMND");
            child._mST = dr.GetString("MST");
            child._tenNhanVien = dr.GetString("TenNhanVien");

            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int TrackingID;

			public Criteria(int trackingID)
			{
				this.TrackingID = trackingID;
			}
		}
        private class CriteriaByDatabase
        {
            public int MaChiTietGXN;
            public int DBNumberGXN;
            public CriteriaByDatabase(int maChiTietGXN,int databaseNumberGXN)
            {
                this.MaChiTietGXN = maChiTietGXN;
                this.DBNumberGXN = databaseNumberGXN;
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
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_Tracking";

                    cm.Parameters.AddWithValue("@TrackingID",((Criteria) criteria).TrackingID);
                }
                else if (criteria is CriteriaByDatabase)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_TrackingMaChiTietGXN";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((CriteriaByDatabase)criteria).MaChiTietGXN);
                   // cm.Parameters.AddWithValue("@DatabaseNumber_GXN", ((CriteriaByDatabase)criteria).DBNumberGXN);
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
			DataPortal_Delete(new Criteria(_trackingID));
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
                cm.CommandText = "spd_DeletetblnsGiayXacNhan_Tracking";

				cm.Parameters.AddWithValue("@TrackingID", criteria.TrackingID);

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
			_trackingID = dr.GetInt32("TrackingID");
			_maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
			_tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
			_maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
			_soTien = dr.GetDecimal("SoTien");
			_soTienDaNhapNV = dr.GetDecimal("SoTienDaNhapNV");
			_soTienDaNhapNVNgoaiDai = dr.GetDecimal("SoTienDaNhapNVNgoaiDai");
			_soTienConLai = dr.GetDecimal("SoTienConLai");
		
			_maBoPhanGui = dr.GetInt32("MaBoPhanGui");
			_tenBoPhanGui = dr.GetString("TenBoPhanGui");
			_maBoPhanNhan = dr.GetInt32("MaBoPhanNhan");
			_tenBoPhanNhan = dr.GetString("TenBoPhanNhan");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_tenChuongTrinh = dr.GetString("TenChuongTrinh");
			_ngayLapGXN = dr.GetSmartDate("NgayLapGXN", _ngayLapGXN.EmptyIsMin);
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_nguoiLap = dr.GetInt32("NguoiLap");
			_tinhTrang = dr.GetBoolean("TinhTrang");
			_ghiChu = dr.GetString("GhiChu");
            _isDelete = dr.GetBoolean("IsDelete");
            _soTienDaNhapNVTienMat = dr.GetDecimal("SoTienDaNhapNVTienMat");
            _duocNhapHo = dr.GetBoolean("DuocNhapHo");
            _soTienDaNhapTrongDinhMuc = dr.GetDecimal("SoTienDaNhapTrongDinhMuc");
            _soTienDaDeNghiCK = dr.GetDecimal("SoTienDaDeNghiCK");
            _soTienChuaDeNghiCK = dr.GetDecimal("SoTienChuaDeNghiCK");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChiTietGiayXacNhan parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, ChiTietGiayXacNhan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsGiayXacNhan_Tracking";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_trackingID = (int)cm.Parameters["@TrackingID"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, ChiTietGiayXacNhan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaGiayXacNhan", parent.MaGiayXacNhan);
            if (parent.TenGiayXacNhan.Length > 0)
				cm.Parameters.AddWithValue("@TenGiayXacNhan", parent.TenGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", parent.MaChiTietGiayXacNhan);
            if (parent.SoTien != 0)
                cm.Parameters.AddWithValue("@SoTien", parent.SoTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_soTienDaNhapNV != 0)
				cm.Parameters.AddWithValue("@SoTienDaNhapNV", _soTienDaNhapNV);
			else
				cm.Parameters.AddWithValue("@SoTienDaNhapNV", DBNull.Value);
			if (_soTienDaNhapNVNgoaiDai != 0)
				cm.Parameters.AddWithValue("@SoTienDaNhapNVNgoaiDai", _soTienDaNhapNVNgoaiDai);
			else
				cm.Parameters.AddWithValue("@SoTienDaNhapNVNgoaiDai", DBNull.Value);
            if (_soTienDaNhapNVTienMat != 0)
                cm.Parameters.AddWithValue("@SoTienDaNhapNVTienMat", _soTienDaNhapNVTienMat);
            else
                cm.Parameters.AddWithValue("@SoTienDaNhapNVTienMat", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
            if (_soTienDaNhapTrongDinhMuc != 0)
                cm.Parameters.AddWithValue("@SoTienDaNhapTrongDinhMuc", _soTienDaNhapTrongDinhMuc);
            else
                cm.Parameters.AddWithValue("@SoTienDaNhapTrongDinhMuc", DBNull.Value);

		
            cm.Parameters.AddWithValue("@MaBoPhanGui", parent.MaBoPhanDi);
			if (_tenBoPhanGui.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhanGui", parent.TenBoPhanDi);
			else
				cm.Parameters.AddWithValue("@TenBoPhanGui", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhanNhan", parent.MaBoPhanDen);
			if (_tenBoPhanNhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhanNhan", _tenBoPhanNhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhanNhan", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLapGXN", _ngayLapGXN.DBValue);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			
				cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@TrackingID", _trackingID);
            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
            cm.Parameters.AddWithValue("@SoTienDaDeNghiCK", _soTienDaDeNghiCK);
			cm.Parameters["@TrackingID"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, ChiTietGiayXacNhan parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChiTietGiayXacNhan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsGiayXacNhan_Tracking";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ChiTietGiayXacNhan parent)
		{
			cm.Parameters.AddWithValue("@TrackingID", _trackingID);
			cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
			if (_tenGiayXacNhan.Length > 0)
				cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_soTienDaNhapNV != 0)
				cm.Parameters.AddWithValue("@SoTienDaNhapNV", _soTienDaNhapNV);
			else
				cm.Parameters.AddWithValue("@SoTienDaNhapNV", DBNull.Value);
            if (_soTienDaNhapNVTienMat != 0)
                cm.Parameters.AddWithValue("@SoTienDaNhapNVTienMat", _soTienDaNhapNVTienMat);
            else
                cm.Parameters.AddWithValue("@SoTienDaNhapNVTienMat", DBNull.Value);
			if (_soTienDaNhapNVNgoaiDai != 0)
				cm.Parameters.AddWithValue("@SoTienDaNhapNVNgoaiDai", _soTienDaNhapNVNgoaiDai);
			else
				cm.Parameters.AddWithValue("@SoTienDaNhapNVNgoaiDai", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
		
			cm.Parameters.AddWithValue("@MaBoPhanGui", _maBoPhanGui);
			if (_tenBoPhanGui.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhanGui", _tenBoPhanGui);
			else
				cm.Parameters.AddWithValue("@TenBoPhanGui", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanNhan);
			if (_tenBoPhanNhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhanNhan", _tenBoPhanNhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhanNhan", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLapGXN", _ngayLapGXN.DBValue);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
		
				cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
            if (_soTienDaNhapTrongDinhMuc != 0)
                cm.Parameters.AddWithValue("@SoTienDaNhapTrongDinhMuc", _soTienDaNhapTrongDinhMuc);
            else
                cm.Parameters.AddWithValue("@SoTienDaNhapTrongDinhMuc", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienDaDeNghiCK", _soTienDaDeNghiCK);
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

			ExecuteDelete(tr, new Criteria(_trackingID));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
