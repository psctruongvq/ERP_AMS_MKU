
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ //4-9 moi
	[Serializable()] 
	public class ChiThuLao : Csla.BusinessBase<ChiThuLao>
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
        private string _soDNCK = string.Empty;
        private DateTime _ngayDNCK;
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
        private ChiThuLao_NhanVienList _chiThuLaoNhanVienList = ChiThuLao_NhanVienList.NewChiThuLao_NhanVien();
        private int _maLoaiKinhPhi = 0;

        private DateTime _ngayThucHienChi;
        private string _maGiayXacNhanQL;
        private DateTime _ngayXacNhan;
        private string _tenLoaiNhanVien;
        private int _maTaiKhoan;
        private bool _loaiNV = false;
       
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
        public DateTime NgayDNCK
        {
            get
            {
                CanReadProperty("NgayDNCK", true);
                return _ngayDNCK.Date;
            }
            set
            {
                CanWriteProperty("NgayDNCK", true);
                if (!_ngayDNCK.Equals(value))
                {
                    _ngayDNCK = value;
                    PropertyHasChanged("NgayDNCK");
                }
            }
        }
         public ChiThuLao_NhanVienList ChiThuLaoNhanVienList
        {
            get { return _chiThuLaoNhanVienList; }
            set { _chiThuLaoNhanVienList = value; }
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
        public string SoDNCK
        {
            get
            {
                CanReadProperty("SoDNCK", true);
                return _soDNCK;
            }
            set
            {
                CanWriteProperty("SoDNCK", true);
                if (value == null) value = string.Empty;
                if (!_soDNCK.Equals(value))
                {
                    _soDNCK = value;
                    PropertyHasChanged("SoDNCK");
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
        public bool LoaiNV
        {
            get
            {
                CanReadProperty("LoaiNV", true);
                return _loaiNV;
            }
            set
            {
                CanWriteProperty("LoaiNV", true);
                if (!_hoanTat.Equals(value))
                {
                    _loaiNV = value;
                    PropertyHasChanged("LoaiNV");
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
            get { return base.IsValid && _chiThuLaoNhanVienList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _chiThuLaoNhanVienList.IsDirty; }
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
			//TODO: Define authorization rules in ChiThuLao
			//AuthorizationRules.AllowRead("MaChiThuLao", "ChiThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaChungTu", "ChiThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "ChiThuLaoReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ChiThuLaoReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "ChiThuLaoReadGroup");

			//AuthorizationRules.AllowWrite("MaChungTu", "ChiThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhan", "ChiThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ChiThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "ChiThuLaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChiThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChiThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChiThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChiThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChiThuLao()
		{ /* require use of factory method */ }

        public static ChiThuLao NewChiThuLao(int maBoPhan, decimal soTien)
        {
            return new ChiThuLao(maBoPhan, soTien);
        }
        public static ChiThuLao NewChiThuLao(string soChungTu)
        {
            ChiThuLao item = new ChiThuLao();
            item.SoChungTu = soChungTu;
            return item;
        }
        private ChiThuLao(int maBoPhan, decimal soTien)
        {
            this._maBoPhanNhan = maBoPhan;
            this._soTien = soTien;
            MarkAsChild();
        }

		public static ChiThuLao NewChiThuLao()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChiThuLao");
			return DataPortal.Create<ChiThuLao>();
		}
       

		public static ChiThuLao GetChiThuLao(long maChiThuLao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChiThuLao");
			return DataPortal.Fetch<ChiThuLao>(new Criteria(maChiThuLao));
		}

        public static ChiThuLao GetChiThuLaoBySoChungTu(string soChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLao");
            return DataPortal.Fetch<ChiThuLao>(new CriteriaByChungTu(soChungTu));
        }

		public static void DeleteChiThuLao(long maChiThuLao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChiThuLao");
			DataPortal.Delete(new Criteria(maChiThuLao));
		}
        public static void UpdateSoTienDaNhapPhieuChi(long maChiThuLao)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateSoTienDaNhapPhieuChi";
                cm.Parameters.AddWithValue("@MaChiThuLao", maChiThuLao);
                cm.CommandTimeout = 0;
                cm.ExecuteNonQuery();

            }
        }
        public static void UpdateSoTienSeNhapPhieuChi(long maChiThuLao, decimal soTienSeNhap, decimal soTienSeNhapNgoaiDai,int maDBGui)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblcnChiThuLao_SoTienSeNhap";
                cm.Parameters.AddWithValue("@SoTienSeNhapNgoaiDai", soTienSeNhapNgoaiDai);
                cm.Parameters.AddWithValue("@SoTienSeNhap", soTienSeNhap);
                cm.Parameters.AddWithValue("@MaChiThuLao", maChiThuLao);
                cm.Parameters.AddWithValue("@MaDBGui", maDBGui);

                cm.ExecuteNonQuery();

            }
        }
        public static decimal SoTienConLaiPhieuChi(long maChiThuLao)
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
                    cm.Parameters.AddWithValue("@MaChiThuLao", maChiThuLao);
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
        public static void UpdateTrangThaiChiThuLao(long MaChiThuLao, bool trangThai)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateTrangThaiChiThuLao";
                cm.Parameters.AddWithValue("@MaChiThuLao", MaChiThuLao);
                cm.Parameters.AddWithValue("@trangThai", trangThai);

                cm.ExecuteNonQuery();

            }
        }
		public override ChiThuLao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChiThuLao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChiThuLao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChiThuLao");

			return base.Save();
		}

        #region BoSung MaLoaiChi

        public static bool CheckChiThuLaoDaSuDung(long maChiThuLao)
        {
            bool result=false;
            using(SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using(SqlCommand cm=cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckChiThuLaoDaSuDung";
                    cm.Parameters.AddWithValue("@MaChiThuLao", maChiThuLao);
                    SqlParameter outPara = new SqlParameter("@DaSuDung", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }
            return result;
        }
        #endregion BoSung MaLoaiChi

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChiThuLao NewChiThuLaoChild()
		{
			ChiThuLao child = new ChiThuLao();
			//child.ValidationRules.CheckRules();            
			child.MarkAsChild();
			return child;
		}

		internal static ChiThuLao GetChiThuLao(SafeDataReader dr)
		{
			ChiThuLao child =  new ChiThuLao();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static ChiThuLao GetChiThuLaoByChiPhiSanXuat(SafeDataReader dr)
        {
            ChiThuLao child = new ChiThuLao();
            child._maBoPhanGui = dr.GetInt32("MaBoPhan");
            child._tenBoPhanGui = dr.GetString("TenBoPhan");
            child._maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            child.SoChungTu = dr.GetString("MaChuongTrinhQL");
            child._tenChuongTrinh = dr.GetString("TenChuongTrinh");
            child._maGiayXacNhanQL = dr.GetString("MaGiayXacNhanQL");
            child._ngayXacNhan = dr.GetDateTime("NgayXacNhan");
            child._soTien = dr.GetDecimal("SoTien");
            child._soTienDaNhap = dr.GetDecimal("TienThue");
            child._soTienConLai = dr.GetDecimal("SoTienConLai");
            child._tenLoaiNhanVien = dr.GetString("TenLoaiNhanVien");
            child._soDNCK = dr.GetString("SoDNCK");
            child._ngayDNCK = dr.GetDateTime("NgayDeNghi");
            child._loaiNV = dr.GetBoolean("LoaiNV");
            return child;
        }

		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long MaChiThuLao;

			public Criteria(long maChiThuLao)
			{
				this.MaChiThuLao = maChiThuLao;
			}
		}

        [Serializable()]
        private class CriteriaByChungTu
        {
            public string  SoChungTu;

            public CriteriaByChungTu(String soChungTu)
            {
                this.SoChungTu = soChungTu;
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
                    cm.CommandText = "spd_SelecttblcnChiThuLao";
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((Criteria)criteria).MaChiThuLao);
                }
                else if (criteria is CriteriaByChungTu)
                {
                    cm.CommandText = "[spd_SelecttblcnChiThuLaoByChungTuNew]";
                    cm.Parameters.AddWithValue("@SoChungTu",  ((CriteriaByChungTu)criteria).SoChungTu);
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
                    ExecuteInsert(tr, 0);

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
                    if (_soTienDaNhap != 0)
                        return;
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr, 0);
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
			DataPortal_Delete(new Criteria(_maChiThuLao));
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
                    if (_soTienDaNhap != 0)
                        return;
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
                cm.CommandText = "spd_DeletetblcnChiThuLao";

                cm.Parameters.AddWithValue("@MaChiThuLao", criteria.MaChiThuLao);

                cm.ExecuteNonQuery();
            }//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
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
            _chiThuLaoNhanVienList = ChiThuLao_NhanVienList.GetChiThuLao_NhanVien(_maChiThuLao);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, long MaChungTu, string soChungTu, long maCT_ChiPhiSanXuat, int maChuongTrinh, string tenChuongTrinh)
		{
            _maChungTu = MaChungTu; _soChungTu = soChungTu; _mactChiphisanxuat=maCT_ChiPhiSanXuat; _maChuongTrinh = maChuongTrinh; _tenChuongTrinh = tenChuongTrinh;
			if (!IsDirty) return;

			ExecuteInsert(tr, MaChungTu);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, long MaChungTu)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblcnChiThuLao";

				AddInsertParameters(cm, MaChungTu);

				cm.ExecuteNonQuery();

				_maChiThuLao = (long)cm.Parameters["@MaChiThuLao"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, long MaChungTu)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            // coi lai

            //
            _maBoPhanGui = Security.CurrentUser.Info.MaBoPhan;
            _tenBoPhanGui = BoPhan.GetBoPhan(Security.CurrentUser.Info.MaBoPhan).TenBoPhan;
            _tenBoPhanNhan = BoPhan.GetBoPhan(_maBoPhanNhan).TenBoPhan;
            //
            cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
            cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanNhan);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
           
          
            cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            //
            cm.Parameters.AddWithValue("@MaBoPhanGui", _maBoPhanGui);
            cm.Parameters["@MaChiThuLao"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@NgayThucHienChi", _ngayLap.DBValue);
            if (_maChuongTrinh > 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_tenBoPhanGui.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanGui", _tenBoPhanGui);
            else
                cm.Parameters.AddWithValue("@TenBoPhanGui", DBNull.Value);
            if (_tenBoPhanNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanNhan", _tenBoPhanNhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhanNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienSeNhap", _soTienSeNhap);
            cm.Parameters.AddWithValue("@SoTienSeNhapNgoaiDai", _soTienSeNhapNgoaiDai);
            cm.Parameters.AddWithValue("@SoTienDaNhap", _soTienDaNhap);
            cm.Parameters.AddWithValue("@SoTienDaNhapNgoaiDai", _soTienDaNhapNgoaiDai);
            cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@MaLoaiKinhPhi", _maLoaiKinhPhi);
            if(_maTaiKhoan>0)
            cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_mactChiphisanxuat > 0)
                cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _mactChiphisanxuat);
            else
                cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", DBNull.Value);
        }
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, long MaChungTu, string soChungTu, long maCT_ChiPhiSanXuat, int maChuongTrinh, string tenChuongTrinh)
		{
            _maChungTu = MaChungTu; _soChungTu = soChungTu; _mactChiphisanxuat = maCT_ChiPhiSanXuat; _maChuongTrinh = maChuongTrinh; _tenChuongTrinh = tenChuongTrinh;
            //if (!IsDirty) return;

            //if (base.IsDirty)
            //{
				ExecuteUpdate(tr, MaChungTu);
            //    MarkOld();
            //}

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteUpdate(SqlTransaction tr, long MaChungTu)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblcnChiThuLao";

				AddUpdateParameters(cm, MaChungTu);
                try
                {

               
				cm.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, long MaChungTu)
		{
            //
            _maBoPhanGui = Security.CurrentUser.Info.MaBoPhan;
            _tenBoPhanGui = BoPhan.GetBoPhan(Security.CurrentUser.Info.MaBoPhan).TenBoPhan;

            //
			cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
			cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
			cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanNhan);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
          
            cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            //
            cm.Parameters.AddWithValue("@MaBoPhanGui", _maBoPhanGui);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@NgayThucHienChi", _ngayLap.DBValue);
            if (_maChuongTrinh > 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_tenBoPhanGui.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanGui", _tenBoPhanGui);
            else
                cm.Parameters.AddWithValue("@TenBoPhanGui", DBNull.Value);
            if (_tenBoPhanNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanNhan", _tenBoPhanNhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhanNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienSeNhap", _soTienSeNhap);
            cm.Parameters.AddWithValue("@SoTienSeNhapNgoaiDai", _soTienSeNhapNgoaiDai);
            cm.Parameters.AddWithValue("@SoTienDaNhap", _soTienDaNhap);
            cm.Parameters.AddWithValue("@SoTienDaNhapNgoaiDai", _soTienDaNhapNgoaiDai);
            cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@MaLoaiKinhPhi", _maLoaiKinhPhi);
            if (_maTaiKhoan > 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_mactChiphisanxuat > 0)
                cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _mactChiphisanxuat);
            else
                cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", DBNull.Value);
		}

        private void UpdateChildren(SqlTransaction tr)
		{
            _chiThuLaoNhanVienList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
		{
            if (!IsDirty) return;
            if (IsNew) return;
            _chiThuLaoNhanVienList.Clear();
            UpdateChildren(tr);
            ExecuteDelete(tr, new Criteria(_maChiThuLao));
            MarkNew();
		}
        public void DeleteByChungTu(SqlTransaction tr, long MaChungTu)
        {
            _chiThuLaoNhanVienList.Save();
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblcnChiThuLaoByChungTu";

                cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);

                cm.ExecuteNonQuery();
            }//using
        }
        public void Dataportal_Delete(SqlTransaction tr)
        {
            _chiThuLaoNhanVienList.DataPortal_Delete(tr, _maChiThuLao);
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblcnChiThuLao";

                cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);

                cm.ExecuteNonQuery();
            }//using
        }
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
