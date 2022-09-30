
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTuRutGon : Csla.BusinessBase<ChungTuRutGon>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChungTu = 0;
        private bool _check = false;//Hau
        private string _tenDangNhap = string.Empty;
		private int _soTT = 0;
		private string _soChungTu = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private bool _ghiMucNganSach = false;
		private DateTime _ngayThucHien = DateTime.Today.Date;
		private bool _ghiSoCai = false;
		private int _maNguoiLap = 0;
		private long _maDoiTuong = 0;
		private long _maHopDong = 0;
		private int _maDinhKhoan = 0;
		private int _maLoaiChungTu = 0;
		private int _maKy = 0;
		private byte _khoaSo = 0;
		private bool _hoanTat = false;
		private string _maChungTuQL = string.Empty;
		private string _dienGiai = string.Empty;
		private int _maDoiTuongThuChi = 0;
		private int _maPhuongThucThanhToan = 0;
		private string _soChungTuCu = string.Empty;
		private int _soChungTuKemTheo = 0;
        private decimal _soTien = 0;
        private int _mabuttoan = 0;
        private decimal _STButToan = 0;
        private string _soTaiKhoan = string.Empty;

        private string _TenDoiTuong = string.Empty;

        private SmartDate _ngayXacNhanUNC = new SmartDate(DateTime.MinValue);      
        private bool _chon = false;
        private string _soHoaDon = string.Empty;
        private decimal _soTienHoaDon = 0;
        private DateTime _ngayHoaDon = DateTime.Today.Date;
        private decimal _soTienNgoaiTe = 0;
        private string _TenNganHangDoiTac = string.Empty;
        private string _SoTaiKhoanNHDoiTac = string.Empty;
        private string _TenNguoiNhan = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]

        public DateTime? NgayXacNhanUNC
        {
            get
            {
                CanReadProperty("NgayXacNhanUNC", true);
                if (_ngayXacNhanUNC.Date == DateTime.MinValue)
                    return null;
                return _ngayXacNhanUNC.Date;
            }
            set
            {
                CanWriteProperty("NgayXacNhanUNC", true);
                if (!_ngayXacNhanUNC.Equals(value))
                {
                    if (value == null)
                        _ngayXacNhanUNC = new SmartDate(DateTime.MinValue);
                    else
                        _ngayXacNhanUNC = new SmartDate(value.Value.Date);

                    PropertyHasChanged();
                }
            }

        }
        
        public bool Chon
        {
            get { return _chon; }
            set { _chon = value;
            PropertyHasChanged("Chon");
            }
        }
		public long MaChungTu
		{
			get
			{
				return _maChungTu;
			}
		}

		public int SoTT
		{
			get
			{
				return _soTT;
			}
			set
			{
				if (!_soTT.Equals(value))
				{
					_soTT = value;
					PropertyHasChanged("SoTT");
				}
			}
		}

		public string SoChungTu
		{
			get
			{
				return _soChungTu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soChungTu.Equals(value))
				{
					_soChungTu = value;
					PropertyHasChanged("SoChungTu");
				}
			}
		}

        public string TenDangNhap
        {
            get
            {
                return _tenDangNhap;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenDangNhap.Equals(value))
                {
                    _tenDangNhap = value;
                    PropertyHasChanged("TenDangNhap");
                }
            }
        }

		public DateTime NgayLap
		{
			get
			{
				return _ngayLap;
			}
			set
			{
				if (!_ngayLap.Equals(value))
				{
					_ngayLap = value;
					PropertyHasChanged("NgayLap");
				}
			}
		}

		public bool GhiMucNganSach
		{
			get
			{
				return _ghiMucNganSach;
			}
			set
			{
				if (!_ghiMucNganSach.Equals(value))
				{
					_ghiMucNganSach = value;
					PropertyHasChanged("GhiMucNganSach");
				}
			}
		}

        public bool Check
        {
            get
            {
                return _check;
            }
            set
            {
                if (!_check.Equals(value))
                {
                    _check = value;
                    PropertyHasChanged("Check");
                }
            }
        }

		public DateTime NgayThucHien
		{
			get
			{
				return _ngayThucHien;
			}
			set
			{
				if (!_ngayThucHien.Equals(value))
				{
					_ngayThucHien = value;
					PropertyHasChanged("NgayThucHien");
				}
			}
		}

		public bool GhiSoCai
		{
			get
			{
				return _ghiSoCai;
			}
			set
			{
				if (!_ghiSoCai.Equals(value))
				{
					_ghiSoCai = value;
					PropertyHasChanged("GhiSoCai");
				}
			}
		}

		public int MaNguoiLap
		{
			get
			{
				return _maNguoiLap;
			}
			set
			{
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

		public long MaDoiTuong
		{
			get
			{
				return _maDoiTuong;
			}
			set
			{
				if (!_maDoiTuong.Equals(value))
				{
					_maDoiTuong = value;
					PropertyHasChanged("MaDoiTuong");
				}
			}
		}

		public long MaHopDong
		{
			get
			{
				return _maHopDong;
			}
			set
			{
				if (!_maHopDong.Equals(value))
				{
					_maHopDong = value;
					PropertyHasChanged("MaHopDong");
				}
			}
		}

		public int MaDinhKhoan
		{
			get
			{
				return _maDinhKhoan;
			}
			set
			{
				if (!_maDinhKhoan.Equals(value))
				{
					_maDinhKhoan = value;
					PropertyHasChanged("MaDinhKhoan");
				}
			}
		}

		public int MaLoaiChungTu
		{
			get
			{
				return _maLoaiChungTu;
			}
			set
			{
				if (!_maLoaiChungTu.Equals(value))
				{
					_maLoaiChungTu = value;
					PropertyHasChanged("MaLoaiChungTu");
				}
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

		public byte KhoaSo
		{
			get
			{
				return _khoaSo;
			}
			set
			{
				if (!_khoaSo.Equals(value))
				{
					_khoaSo = value;
					PropertyHasChanged("KhoaSo");
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
					PropertyHasChanged("HoanTat");
				}
			}
		}

		public string MaChungTuQL
		{
			get
			{
				return _maChungTuQL;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maChungTuQL.Equals(value))
				{
					_maChungTuQL = value;
					PropertyHasChanged("MaChungTuQL");
				}
			}
		}
        
        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
                }
            }
        }

		public string DienGiai
		{
			get
			{
				return _dienGiai;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}

		public int MaDoiTuongThuChi
		{
			get
			{
				return _maDoiTuongThuChi;
			}
			set
			{
				if (!_maDoiTuongThuChi.Equals(value))
				{
					_maDoiTuongThuChi = value;
					PropertyHasChanged("MaDoiTuongThuChi");
				}
			}
		}

		public int MaPhuongThucThanhToan
		{
			get
			{
				return _maPhuongThucThanhToan;
			}
			set
			{
				if (!_maPhuongThucThanhToan.Equals(value))
				{
					_maPhuongThucThanhToan = value;
					PropertyHasChanged("MaPhuongThucThanhToan");
				}
			}
		}

		public string SoChungTuCu
		{
			get
			{
				return _soChungTuCu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soChungTuCu.Equals(value))
				{
					_soChungTuCu = value;
					PropertyHasChanged("SoChungTuCu");
				}
			}
		}

		public int SoChungTuKemTheo
		{
			get
			{
				return _soChungTuKemTheo;
			}
			set
			{
				if (!_soChungTuKemTheo.Equals(value))
				{
					_soChungTuKemTheo = value;
					PropertyHasChanged("SoChungTuKemTheo");
				}
			}
		}
        public decimal SoTien
        {
            get { return _soTien; }
            set { _soTien = value; }
        }
        public int MaButToan
        {
            get { return _mabuttoan; }
            set { _mabuttoan = value; }
        }
        public decimal STButToan
        {
            get { return _STButToan; }
            set { _STButToan = value; }
        }

        public string TenDoiTuong
        {
            get { return _TenDoiTuong; }
        }    
		protected override object GetIdValue()
		{
			return _maChungTu;
		}
        public decimal SoTienHoaDon
        {
            get { return _soTienHoaDon; }
            set { _soTienHoaDon = value; }
        }
        public decimal SoTienNgoaiTe
        {
            get { return _soTienNgoaiTe; }
            set { _soTienNgoaiTe = value; }
        }
        public string SoHoaDon
        {
            get { return _soHoaDon; }
            set { _soHoaDon = value; }
        }
        public DateTime NgayHoaDon
        {
            get { return _ngayHoaDon; }
            set { _ngayHoaDon = value; }
        }

        public string TenNganHangDoiTac
        {
            get { return _TenNganHangDoiTac; }
            set { _TenNganHangDoiTac = value; }
        }

        public string SoTaiKhoanNHDoiTac
        {
            get { return _SoTaiKhoanNHDoiTac; }
            set { _SoTaiKhoanNHDoiTac = value; }
        }

        public string TenNguoiNhan
        {
            get { return _TenNguoiNhan; }
            set { _TenNguoiNhan = value; }
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
			// SoChungTu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoChungTu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
			//
			// MaChungTuQL
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaChungTuQL", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 2000));
			//
			// SoChungTuCu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTuCu", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ChungTuRutGon()
		{ /* require use of factory method */ }

		public static ChungTuRutGon NewChungTuRutGon()
		{
			return DataPortal.Create<ChungTuRutGon>();
		}

		public static ChungTuRutGon GetChungTuRutGon(long maChungTu)
		{
			return DataPortal.Fetch<ChungTuRutGon>(new Criteria(maChungTu));
		}

        public static ChungTuRutGon GetChungTuRutGonForUNC(long maChungTu)
        {
            return DataPortal.Fetch<ChungTuRutGon>(new Criteria(maChungTu));
        }

		public static void DeleteChungTuRutGon(long maChungTu)
		{
			DataPortal.Delete(new Criteria(maChungTu));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChungTuRutGon NewChungTuRutGonChild()
		{
			ChungTuRutGon child = new ChungTuRutGon();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChungTuRutGon GetChungTuRutGon(SafeDataReader dr)
		{
			ChungTuRutGon child =  new ChungTuRutGon();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static ChungTuRutGon GetChungTuRutGonForUNC(SafeDataReader dr)
        {
            ChungTuRutGon child = new ChungTuRutGon();
            child.MarkAsChild();
            child.FetchForUNC(dr);
            return child;
        }
        internal static ChungTuRutGon GetChungTuRutGon_ByLoc(SafeDataReader dr)
        {
            ChungTuRutGon child = new ChungTuRutGon();
            child.MarkAsChild();
            child.Fetch_ByLoc(dr);
            return child;
        }
        internal static ChungTuRutGon GetChungTuRutGon_UserId(SafeDataReader dr)
        {
            ChungTuRutGon child = new ChungTuRutGon();
            child.MarkAsChild();
            child.FetchObjectByUserId(dr);
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long MaChungTu;

			public Criteria(long maChungTu)
			{
				this.MaChungTu = maChungTu;
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
				cm.CommandText = "SelecttblChungTu";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					//ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_maChungTu));
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
				cm.CommandText = "DeletetblChungTu";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
        private void FetchForUNC(SafeDataReader dr)
        {
            FetchObjectForUNC(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }
        private void Fetch_ByLoc(SafeDataReader dr)
        {
            FetchObject_ByLoc(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren_ByLoc(dr);
        }
        private void Fetch_UserId(SafeDataReader dr)
        {
            FetchObjectByUserId(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
        }

		private void FetchObject(SafeDataReader dr)
		{
			_maChungTu = dr.GetInt64("MaChungTu");
			_soTT = dr.GetInt32("SoTT");
			_soChungTu = dr.GetString("SoChungTu");
			_ngayLap = dr.GetDateTime("NgayLap");
			_ghiMucNganSach = dr.GetBoolean("GhiMucNganSach");
			_ngayThucHien = dr.GetDateTime("NgayThucHien");
			_ghiSoCai = dr.GetBoolean("GhiSoCai");
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
			_maDoiTuong = dr.GetInt64("MaDoiTuong");
			_maHopDong = dr.GetInt64("MaHopDong");
			_maDinhKhoan = dr.GetInt32("MaDinhKhoan");
			_maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
			_maKy = dr.GetInt32("MaKy");
			_khoaSo = dr.GetByte("KhoaSo");
			_hoanTat = dr.GetBoolean("HoanTat");
			_maChungTuQL = dr.GetString("MaChungTuQL");
			_dienGiai = dr.GetString("DienGiai");
			_maDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
			_maPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
			_soChungTuCu = dr.GetString("SoChungTuCu");
			_soChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
            _soTien = dr.GetDecimal("SoTien");
            _TenDoiTuong = dr.GetString("TenDoiTuong");
            //_soTaiKhoan = dr.GetString("SoTaiKhoan");
            try
            {
                _ngayXacNhanUNC = dr.GetSmartDate("NgayXacNhanUNC", _ngayXacNhanUNC.EmptyIsMin);
            }
            catch
            {

            }
		}

        private void FetchObjectForUNC(SafeDataReader dr)
        {
            _maChungTu = dr.GetInt64("MaChungTu");
            _soTT = dr.GetInt32("SoTT");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayLap = dr.GetDateTime("NgayLap");
            _ghiMucNganSach = dr.GetBoolean("GhiMucNganSach");
            _ngayThucHien = dr.GetDateTime("NgayThucHien");
            _ghiSoCai = dr.GetBoolean("GhiSoCai");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _maDoiTuong = dr.GetInt64("MaDoiTuong");
            _maHopDong = dr.GetInt64("MaHopDong");
            _maDinhKhoan = dr.GetInt32("MaDinhKhoan");
            _maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
            _maKy = dr.GetInt32("MaKy");
            _khoaSo = dr.GetByte("KhoaSo");
            _hoanTat = dr.GetBoolean("HoanTat");
            _maChungTuQL = dr.GetString("MaChungTuQL");
            _dienGiai = dr.GetString("DienGiai");
            _maDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
            _maPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
            _soChungTuCu = dr.GetString("SoChungTuCu");
            _soChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
            _soTien = dr.GetDecimal("SoTien");
            _TenDoiTuong = dr.GetString("TenDoiTuong");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _tenDangNhap = dr.GetString("TenDangNhap");
            try
            {
                _ngayXacNhanUNC = dr.GetSmartDate("NgayXacNhanUNC", _ngayXacNhanUNC.EmptyIsMin);
            }
            catch
            {

            }
            _soHoaDon = dr.GetString("SoHoaDon");
            _ngayHoaDon = dr.GetDateTime("NgayHoaDon");
            _soTienHoaDon = dr.GetDecimal("SoTienHoaDon");
            _soTienNgoaiTe = dr.GetDecimal("SoTienNgoaiTe");
            _TenNganHangDoiTac = dr.GetString("TenNganHangDoiTac");
            _SoTaiKhoanNHDoiTac = dr.GetString("SoTaiKhoanNHDoiTac");
            _TenNguoiNhan = dr.GetString("TenNguoiNhan");
        }

        private void FetchObjectByUserId(SafeDataReader dr)
        {
            _maChungTu = dr.GetInt64("MaChungTu");
            _soTT = dr.GetInt32("SoTT");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayLap = dr.GetDateTime("NgayLap");
            _ghiMucNganSach = dr.GetBoolean("GhiMucNganSach");
            _ngayThucHien = dr.GetDateTime("NgayThucHien");
            _ghiSoCai = dr.GetBoolean("GhiSoCai");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _maDoiTuong = dr.GetInt64("MaDoiTuong");
            _maHopDong = dr.GetInt64("MaHopDong");
            _maDinhKhoan = dr.GetInt32("MaDinhKhoan");
            _maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
            _maKy = dr.GetInt32("MaKy");
            _khoaSo = dr.GetByte("KhoaSo");
            _hoanTat = dr.GetBoolean("HoanTat");
            _maChungTuQL = dr.GetString("MaChungTuQL");
            _dienGiai = dr.GetString("DienGiai");
            _maDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
            _maPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
            _soChungTuCu = dr.GetString("SoChungTuCu");
            _soChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
            _soTien = dr.GetDecimal("SoTien");
            _TenDoiTuong = dr.GetString("TenDoiTuong");
            _tenDangNhap = dr.GetString("TenDangNhap");           
            try
            {
                _ngayXacNhanUNC = dr.GetSmartDate("NgayXacNhanUNC", _ngayXacNhanUNC.EmptyIsMin);
            }
            catch
            {

            }
        }
        private void FetchObject_ByLoc(SafeDataReader dr)
        {
            _maChungTu = dr.GetInt64("MaChungTu");
            _soTT = dr.GetInt32("SoTT");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayLap = dr.GetDateTime("NgayLap");
            _ghiMucNganSach = dr.GetBoolean("GhiMucNganSach");
            _ngayThucHien = dr.GetDateTime("NgayThucHien");
            _ghiSoCai = dr.GetBoolean("GhiSoCai");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _maDoiTuong = dr.GetInt64("MaDoiTuong");
            _maHopDong = dr.GetInt64("MaHopDong");
            _maDinhKhoan = dr.GetInt32("MaDinhKhoan");
            _maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
            _maKy = dr.GetInt32("MaKy");
            _khoaSo = dr.GetByte("KhoaSo");
            _hoanTat = dr.GetBoolean("HoanTat");
            _maChungTuQL = dr.GetString("MaChungTuQL");
            _dienGiai = dr.GetString("DienGiai");
            _maDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
            _maPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
            _soChungTuCu = dr.GetString("SoChungTuCu");
            _soChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
            _soTien = dr.GetDecimal("SoTien");
            _mabuttoan = dr.GetInt32("MaButToan");
            _STButToan = dr.GetDecimal("STButToan");
            try
            {
                _ngayXacNhanUNC = dr.GetSmartDate("NgayXacNhanUNC", _ngayXacNhanUNC.EmptyIsMin);
            }
            catch
            {

            }
        }

		private void FetchChildren(SafeDataReader dr)
		{
		}
        private void FetchChildren_ByLoc(SafeDataReader dr)
        {
        }
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChungTuRutGonList parent)
		{
			if (!IsDirty) return;
            /*
			ExecuteInsert(tr, parent);
			MarkOld();
            */
			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChungTuRutGonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblChungTu";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChungTu = (long)cm.Parameters["@MaChungTu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChungTuRutGonList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_soTT != 0)
				cm.Parameters.AddWithValue("@SoTT", _soTT);
			else
				cm.Parameters.AddWithValue("@SoTT", DBNull.Value);
			cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_ghiMucNganSach != false)
					cm.Parameters.AddWithValue("@GhiMucNganSach", _ghiMucNganSach);
				else
					cm.Parameters.AddWithValue("@GhiMucNganSach", DBNull.Value);
					cm.Parameters.AddWithValue("@NgayThucHien", _ngayThucHien);
					if (_ghiSoCai != false)
						cm.Parameters.AddWithValue("@GhiSoCai", _ghiSoCai);
					else
						cm.Parameters.AddWithValue("@GhiSoCai", DBNull.Value);
					if (_maNguoiLap != 0)
						cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
					else
						cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
					if (_maDoiTuong != 0)
						cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
					else
						cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
					if (_maHopDong != 0)
						cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
					else
						cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
					if (_maDinhKhoan != 0)
						cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
					else
						cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);
					if (_maLoaiChungTu != 0)
						cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
					else
						cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
					if (_maKy != 0)
						cm.Parameters.AddWithValue("@MaKy", _maKy);
					else
						cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
					if (_khoaSo != 0)
						cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
					else
						cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
					if (_hoanTat != false)
						cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
					else
						cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
					if (_maChungTuQL.Length > 0)
						cm.Parameters.AddWithValue("@MaChungTuQL", _maChungTuQL);
					else
						cm.Parameters.AddWithValue("@MaChungTuQL", DBNull.Value);
					if (_dienGiai.Length > 0)
						cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
					else
						cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
					if (_maDoiTuongThuChi != 0)
						cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _maDoiTuongThuChi);
					else
						cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
					if (_maPhuongThucThanhToan != 0)
						cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _maPhuongThucThanhToan);
					else
						cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
					if (_soChungTuCu.Length > 0)
						cm.Parameters.AddWithValue("@SoChungTuCu", _soChungTuCu);
					else
						cm.Parameters.AddWithValue("@SoChungTuCu", DBNull.Value);
					if (_soChungTuKemTheo != 0)
						cm.Parameters.AddWithValue("@SoChungTuKemTheo", _soChungTuKemTheo);
					else
						cm.Parameters.AddWithValue("@SoChungTuKemTheo", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdateChungTuRutGonCustomize";
                    cm.Parameters.AddWithValue("@NgayXacNhanUNC", _ngayXacNhanUNC.DBValue);
                    cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);

                    cm.ExecuteNonQuery();

                }//using

                /*
				ExecuteUpdate(tr, parent);
				MarkOld();
                 * */
            }

            //update child object(s)
            UpdateChildren(tr);
        }


		internal void Update(SqlTransaction tr, ChungTuRutGonList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
                /*
				ExecuteUpdate(tr, parent);
				MarkOld();
                 * */
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, ChungTuRutGonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblChungTu";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChungTuRutGonList parent)
		{
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			if (_soTT != 0)
				cm.Parameters.AddWithValue("@SoTT", _soTT);
			else
				cm.Parameters.AddWithValue("@SoTT", DBNull.Value);
			cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_ghiMucNganSach != false)
				cm.Parameters.AddWithValue("@GhiMucNganSach", _ghiMucNganSach);
			else
				cm.Parameters.AddWithValue("@GhiMucNganSach", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayThucHien", _ngayThucHien);
			if (_ghiSoCai != false)
				cm.Parameters.AddWithValue("@GhiSoCai", _ghiSoCai);
			else
				cm.Parameters.AddWithValue("@GhiSoCai", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			if (_maDoiTuong != 0)
				cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
			if (_maHopDong != 0)
				cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			else
				cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
			if (_maDinhKhoan != 0)
				cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
			else
				cm.Parameters.AddWithValue("@MaDinhKhoan", DBNull.Value);
			if (_maLoaiChungTu != 0)
				cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
			else
				cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
			if (_maKy != 0)
				cm.Parameters.AddWithValue("@MaKy", _maKy);
			else
				cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
			if (_khoaSo != 0)
				cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
			else
				cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
			if (_hoanTat != false)
				cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
			else
				cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
			if (_maChungTuQL.Length > 0)
				cm.Parameters.AddWithValue("@MaChungTuQL", _maChungTuQL);
			else
				cm.Parameters.AddWithValue("@MaChungTuQL", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maDoiTuongThuChi != 0)
				cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _maDoiTuongThuChi);
			else
				cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
			if (_maPhuongThucThanhToan != 0)
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _maPhuongThucThanhToan);
			else
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
			if (_soChungTuCu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTuCu", _soChungTuCu);
			else
				cm.Parameters.AddWithValue("@SoChungTuCu", DBNull.Value);
			if (_soChungTuKemTheo != 0)
				cm.Parameters.AddWithValue("@SoChungTuKemTheo", _soChungTuKemTheo);
			else
				cm.Parameters.AddWithValue("@SoChungTuKemTheo", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        public static ChungTuRutGon NewChungTuRutGon(string p)
        {
            ChungTuRutGon item = new ChungTuRutGon();
            item.SoChungTu = p;
            return item;
        }
        
    }
}
