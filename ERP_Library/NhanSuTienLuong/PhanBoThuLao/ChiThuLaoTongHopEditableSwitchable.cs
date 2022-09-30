
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ //4-9 moi
	[Serializable()] 
	public class ChiThuLaoTongHop : Csla.BusinessBase<ChiThuLaoTongHop>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiThuLao = 0;
		private long _maChungTu = 0;
		private int _maBoPhanNhan = 0;
		private decimal _soTien = 0;
		private string _ghiChu = string.Empty;
        private bool _chon = false;
        
        private decimal _soTienTamThoi = 0;
        private long _mactChiphisanxuat = 0;
        private bool _hoanTat = false;
        private string _soChungTu = string.Empty;
        private int _maBoPhanGui = 0;
        private int _maChuongTrinh = 0;
        private string _tenChuongTrinh = string.Empty;
        private string _tenBoPhanGui = string.Empty;
        private string _tenBoPhanNhan = string.Empty;
        private decimal _soTienDaNhap = 0;
        private decimal _soTienDaNhapNgoaiDai=0;
        private decimal _soTienConLai=0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
        private decimal _soTienSeNhap = 0;
        private decimal _soTienSeNhapNgoaiDai = 0;
        private int _nguoiLap = 0;
        private int _maLoaiKinhPhi = 0;
        private DateTime _ngayThucHienChi;
        private string _maGiayXacNhanQL;
        private DateTime _ngayXacNhan;
        private string _tenLoaiNhanVien;
        private int _maTaiKhoan;

       
		[System.ComponentModel.DataObjectField(true, true)]

        public string TenLoaiNhanVien
        {
            get
            {
                CanReadProperty("TenLoaiNhanVien", true);
                return _tenLoaiNhanVien;
            }
            set
            {
                CanWriteProperty("TenLoaiNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_tenLoaiNhanVien.Equals(value))
                {
                    _tenLoaiNhanVien = value;
                    PropertyHasChanged("TenLoaiNhanVien");
                }
            }
        }

        public string MaGiayXacNhanQL
        {
            get
            {
                CanReadProperty("MaGiayXacNhanQL", true);
                return _maGiayXacNhanQL;
            }
            set
            {
                CanWriteProperty("MaGiayXacNhanQL", true);
                if (value == null) value = string.Empty;
                if (!_maGiayXacNhanQL.Equals(value))
                {
                    _maGiayXacNhanQL = value;
                    PropertyHasChanged("MaGiayXacNhanQL");
                }
            }
        }
        public DateTime NgayThucHienChi
        {
            get
            {
                CanReadProperty("NgayThucHienChi", true);
                return _ngayThucHienChi.Date;
            }
            set
            {
                CanWriteProperty("NgayThucHienChi", true);
                if (!_ngayThucHienChi.Equals(value))
                {
                    _ngayThucHienChi = value;
                    PropertyHasChanged("NgayThucHienChi");
                }
            }
        }
        public DateTime NgayXacNhan
        {
            get
            {
                CanReadProperty("NgayXacNhan", true);
                return _ngayXacNhan.Date;
            }
            set
            {
                CanWriteProperty("NgayXacNhan", true);
                if (!_ngayXacNhan.Equals(value))
                {
                    _ngayXacNhan = value;
                    PropertyHasChanged("NgayXacNhan");
                }
            }
        }

      
		public long MaChiThuLao
		{
			get
			{
				CanReadProperty("MaChiThuLao", true);
				return _maChiThuLao;
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

        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoan", true);
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    PropertyHasChanged("MaTaiKhoan");
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
        public decimal SoTienSeNhap
        {
            get
            {
                CanReadProperty("SoTienSeNhap", true);
                return _soTienSeNhap;
            }
            set
            {
                CanWriteProperty("SoTienSeNhap", true);
                if (!_soTienSeNhap.Equals(value))
                {
                    _soTienSeNhap = value;

                    PropertyHasChanged("SoTienSeNhap");
                }
            }
        }
        public decimal SoTienSeNhapNgoaiDai
        {
            get
            {
                CanReadProperty("SoTienSeNhapNgoaiDai", true);
                return _soTienSeNhapNgoaiDai;
            }
            set
            {
                CanWriteProperty("SoTienSeNhapNgoaiDai", true);
                if (!_soTienSeNhapNgoaiDai.Equals(value))
                {
                    _soTienSeNhapNgoaiDai = value;

                    PropertyHasChanged("SoTienSeNhapNgoaiDai");
                }
            }
        }
        public decimal SoTienDaNhap
        {
            get
            {
                CanReadProperty("SoTienDaNhap", true);
                return _soTienDaNhap;
            }
            set
            {
                CanWriteProperty("SoTienDaNhap", true);
                if (!_soTienDaNhap.Equals(value))
                {
                    _soTienDaNhap = value;

                    PropertyHasChanged("SoTienDaNhap");
                }
            }
        }
        public decimal SoTienDaNhapNgoaiDai
        {
            get
            {
                CanReadProperty("SoTienDaNhapNgoaiDai", true);
                return _soTienDaNhapNgoaiDai;
            }
            set
            {
                CanWriteProperty("SoTienDaNhapNgoaiDai", true);
                if (!_soTienDaNhapNgoaiDai.Equals(value))
                {
                    _soTienDaNhapNgoaiDai = value;

                    PropertyHasChanged("SoTienDaNhapNgoaiDai");
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
        public decimal SoTienTamThoi
        {
            get { return _soTienTamThoi; }
            set { _soTienTamThoi = value; }
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
        public bool Chon
        {
            get
            {
                CanReadProperty("Chon", true);
                return _chon;
            }
            set
            {
                CanWriteProperty("Chon", true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
            }
        }
       
        public bool HoanTat
        {
            get
            {
                CanReadProperty("HoanTat", true);
                return _hoanTat;
            }
            set
            {
                CanWriteProperty("HoanTat", true);
                if (!_hoanTat.Equals(value))
                {
                    _hoanTat = value;
                    PropertyHasChanged("HoanTat");
                }
            }
        }

        public int MaLoaiKinhPhi
        {
            get
            {
                CanReadProperty("MaLoaiKinhPhi", true);
                return _maLoaiKinhPhi;
            }
            set
            {
                CanWriteProperty("MaLoaiKinhPhi", true);
                if (!_maLoaiKinhPhi.Equals(value))
                {
                    _maLoaiKinhPhi = value;
                    PropertyHasChanged("MaLoaiKinhPhi");
                }
            }
        }
        public long MactChiphisanxuat
        {
            get
            {
                return _mactChiphisanxuat;
            }
            set
            {
                if (!_mactChiphisanxuat.Equals(value))
                {
                    _mactChiphisanxuat = value;
                    PropertyHasChanged("MactChiphisanxuat");
                }
            }
        }
        public override bool IsValid
        {
            get { return base.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty ; }
        }
		protected override object GetIdValue()
		{
			return _maChiThuLao;
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
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
			//TODO: Define authorization rules in ChiThuLaoTongHop
			//AuthorizationRules.AllowRead("MaChiThuLaoTongHop", "ChiThuLaoTongHopReadGroup");
			//AuthorizationRules.AllowRead("MaChungTu", "ChiThuLaoTongHopReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "ChiThuLaoTongHopReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ChiThuLaoTongHopReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "ChiThuLaoTongHopReadGroup");

			//AuthorizationRules.AllowWrite("MaChungTu", "ChiThuLaoTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhan", "ChiThuLaoTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ChiThuLaoTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "ChiThuLaoTongHopWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChiThuLaoTongHop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoTongHopViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChiThuLaoTongHop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoTongHopAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChiThuLaoTongHop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoTongHopEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChiThuLaoTongHop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoTongHopDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChiThuLaoTongHop()
		{ /* require use of factory method */ }

        public static ChiThuLaoTongHop NewChiThuLaoTongHop(int maBoPhan, decimal soTien)
        {
            return new ChiThuLaoTongHop(maBoPhan, soTien);
        }
        public static ChiThuLaoTongHop NewChiThuLaoTongHop(string soChungTu)
        {
            ChiThuLaoTongHop item = new ChiThuLaoTongHop();
            item.SoChungTu = soChungTu;
            return item;
        }
        private ChiThuLaoTongHop(int maBoPhan, decimal soTien)
        {
            this._maBoPhanNhan = maBoPhan;
            this._soTien = soTien;
            MarkAsChild();
        }

		public static ChiThuLaoTongHop NewChiThuLaoTongHop()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChiThuLaoTongHop");
			return DataPortal.Create<ChiThuLaoTongHop>();
		}
       

		public static ChiThuLaoTongHop GetChiThuLaoTongHop(long maChiThuLaoTongHop)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHop");
			return DataPortal.Fetch<ChiThuLaoTongHop>(new Criteria(maChiThuLaoTongHop));
		}


		public static void DeleteChiThuLaoTongHop(long maChiThuLaoTongHop)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChiThuLaoTongHop");
			DataPortal.Delete(new Criteria(maChiThuLaoTongHop));
		}
        public static void UpdateSoTienDaNhapPhieuChi(long maChiThuLaoTongHop)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateSoTienDaNhapPhieuChi";
                cm.Parameters.AddWithValue("@MaChiThuLaoTongHop", maChiThuLaoTongHop);
                cm.CommandTimeout = 0;
                cm.ExecuteNonQuery();

            }
        }
        public static void UpdateSoTienSeNhapPhieuChi(long maChiThuLaoTongHop, decimal soTienSeNhap, decimal soTienSeNhapNgoaiDai,int maDBGui)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblcnChiThuLaoTongHop_SoTienSeNhap";
                cm.Parameters.AddWithValue("@SoTienSeNhapNgoaiDai", soTienSeNhapNgoaiDai);
                cm.Parameters.AddWithValue("@SoTienSeNhap", soTienSeNhap);
                cm.Parameters.AddWithValue("@MaChiThuLaoTongHop", maChiThuLaoTongHop);
                cm.Parameters.AddWithValue("@MaDBGui", maDBGui);

                cm.ExecuteNonQuery();

            }
        }
        public static decimal SoTienConLaiPhieuChi(long maChiThuLaoTongHop)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SoTienConLaiPhieuChi";
                    cm.Parameters.AddWithValue("@MaChiThuLaoTongHop", maChiThuLaoTongHop);
                    cm.Parameters.AddWithValue("@SoTienConLai", soTienConLai);
                    cm.Parameters["@SoTienConLai"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    soTienConLai = (decimal)cm.Parameters["@SoTienConLai"].Value;
                }
                catch (Exception ex)
                {
                    soTienConLai = 0;
                }

            }
            return soTienConLai;
        }
        public static void UpdateTrangThaiChiThuLaoTongHop(long MaChiThuLaoTongHop, bool trangThai)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateTrangThaiChiThuLaoTongHop";
                cm.Parameters.AddWithValue("@MaChiThuLaoTongHop", MaChiThuLaoTongHop);
                cm.Parameters.AddWithValue("@trangThai", trangThai);

                cm.ExecuteNonQuery();

            }
        }
		public override ChiThuLaoTongHop Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChiThuLaoTongHop");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChiThuLaoTongHop");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChiThuLaoTongHop");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChiThuLaoTongHop NewChiThuLaoTongHopChild()
		{
			ChiThuLaoTongHop child = new ChiThuLaoTongHop();
			//child.ValidationRules.CheckRules();            
			child.MarkAsChild();
			return child;
		}

		internal static ChiThuLaoTongHop GetChiThuLaoTongHop(SafeDataReader dr)
		{
			ChiThuLaoTongHop child =  new ChiThuLaoTongHop();
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
			public long MaChiThuLaoTongHop;

			public Criteria(long maChiThuLaoTongHop)
			{
				this.MaChiThuLaoTongHop = maChiThuLaoTongHop;
			}
		}
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblcnChiThuLaoTongHop";
                    cm.Parameters.AddWithValue("@MaChiThuLaoTongHop", ((Criteria)criteria).MaChiThuLaoTongHop);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        //ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
				}
			}//using
		}

		#endregion //Data Access - Fetch


		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maChiThuLao = dr.GetInt64("MaChiThuLao");
			_maChungTu = dr.GetInt64("MaChungTu");
			_maBoPhanNhan = dr.GetInt32("MaBoPhanNhan");
			_soTien = dr.GetDecimal("SoTien");           
			_ghiChu = dr.GetString("GhiChu");
            _mactChiphisanxuat = dr.GetInt64("MaCT_ChiPhiSanXuat");
            _hoanTat = dr.GetBoolean("HoanTat");
            _soChungTu = dr.GetString("SoChungTu");
            _maBoPhanGui = dr.GetInt32("MaBoPhanGui");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
            _tenBoPhanGui = dr.GetString("TenBoPhanGui");
            _tenBoPhanNhan = dr.GetString("TenBoPhanNhan");
            _soTienDaNhap = dr.GetDecimal("SoTienDaNhap");
            _soTienDaNhapNgoaiDai = dr.GetDecimal("SoTienDaNhapNgoaiDai");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _soTienSeNhap = dr.GetDecimal("SoTienSeNhap");
            _soTienSeNhapNgoaiDai = dr.GetDecimal("SoTienSeNhapNgoaiDai");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _maLoaiKinhPhi = dr.GetInt32("MaLoaiKinhPhi");
            _ngayThucHienChi = dr.GetDateTime("NgayThucHienChi");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");

		}

		private void FetchChildren(SafeDataReader dr)
		{
     	}
		#endregion //Data Access - Fetch


		#endregion //Data Access
	}
}
