
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoSoPhuCap : Csla.BusinessBase<HoSoPhuCap>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHoSoPhuCap = 0;
		private long _maNhanVien = 0;
		private int _maLoaiPhuCap = 0;
		private decimal _heSoPhuCap = 0;
		private decimal _phanTramHuong = 100;
		private decimal _tongTien = 0;
        private DateTime _ngayBatDau = DateTime.Today;
        private DateTime _ngatKetThuc = DateTime.Today;
        private DateTime _ngayQuyetDinh = DateTime.Today;
        private string _tenLoaiPhuCap = string.Empty;
        private string _soQuyetDinh = string.Empty;
        private Int64 _nguoiKy = 0;
        private int _chucVuNguoiKy = 0;
		private string _dienGiai = string.Empty;
		private int _nguoiLap = 0;
        private string _tenNguoiLap = string.Empty;
		private DateTime _ngayLap = DateTime.Today;
        private string _tenChucVu = string.Empty;
        private string _tenNguoiKy = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHoSoPhuCap
		{
			get
			{
				CanReadProperty("MaHoSoPhuCap", true);
				return _maHoSoPhuCap;
			}
		}

		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaLoaiPhuCap
		{
			get
			{
				CanReadProperty("MaLoaiPhuCap", true);
				return _maLoaiPhuCap;
			}
			set
			{
				CanWriteProperty("MaLoaiPhuCap", true);
				if (!_maLoaiPhuCap.Equals(value))
				{
					_maLoaiPhuCap = value;
					PropertyHasChanged("MaLoaiPhuCap");
				}
			}
		}

        public string TenLoaiPhuCap
        {
            get
            {
                CanReadProperty("TenLoaiPhuCap", true);
                //_tenLoaiPhuCap = LoaiPhuCap.GetLoaiPhuCap(_maLoaiPhuCap).TenPhuCap.ToString();
                return _tenLoaiPhuCap;
            }
        }

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                _tenChucVu = ChucVu.GetChucVu(_chucVuNguoiKy).TenChucVu.ToString();
                return _tenChucVu;
            }
        }

        public string TenNguoiKy
        {
            get
            {
                CanReadProperty("TenNguoiKy", true);
                _tenNguoiKy = TenNV.GetTenNhanVien(_nguoiKy).TenNhanVien.ToString();
                return _tenNguoiKy;
            }
        }

		public decimal HeSoPhuCap
		{
			get
			{
				CanReadProperty("HeSoPhuCap", true);
				return _heSoPhuCap;
			}
			set
			{
				CanWriteProperty("HeSoPhuCap", true);
				if (!_heSoPhuCap.Equals(value))
				{
					_heSoPhuCap = value;
                    //_tongTien = (ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien)).LuongCB * _heSoPhuCap;
					PropertyHasChanged("HeSoPhuCap");
				}
			}
		}

		public decimal PhanTramHuong
		{
			get
			{
				CanReadProperty("PhanTramHuong", true);
				return _phanTramHuong;
			}
			set
			{
				CanWriteProperty("PhanTramHuong", true);
				if (!_phanTramHuong.Equals(value))
				{
					_phanTramHuong = value;
					PropertyHasChanged("PhanTramHuong");
				}
			}
		}

		public decimal TongTien
		{
			get
			{
				CanReadProperty("TongTien", true);
				return _tongTien;
			}
			set
			{
				CanWriteProperty("TongTien", true);
				if (!_tongTien.Equals(value))
				{
                    _tongTien = value;
					PropertyHasChanged("TongTien");
				}
			}
		}

		public DateTime NgayBatDau
		{
			get
			{
				CanReadProperty(true);
				return _ngayBatDau;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayBatDau.Equals(value))
                {
                    _ngayBatDau= value;
                    PropertyHasChanged();
                }
            }
		}

		public DateTime NgatKetThuc
		{
			get
			{
				CanReadProperty("NgatKetThuc", true);
				return _ngatKetThuc;
			}
            set
            {
                CanWriteProperty("NgatKetThuc", true);
                if (!_ngatKetThuc.Equals(value))
                {
                    _ngatKetThuc = value;
                    PropertyHasChanged("NgatKetThuc");
                }
            }
		}

		public DateTime NgayQuyetDinh
		{
			get
			{
				CanReadProperty("NgayQuyetDinh", true);
				return _ngayQuyetDinh.Date;
			}
            set
            {
                CanWriteProperty("NgayQuyetDinh", true);
                if (!_ngayQuyetDinh.Equals(value))
                {
                    _ngayQuyetDinh = value;
                    PropertyHasChanged("NgayQuyetDinh");
                }
            }
		}

		public string SoQuyetDinh
		{
			get
			{
				CanReadProperty("SoQuyetDinh", true);
				return _soQuyetDinh;
			}
			set
			{
				CanWriteProperty("SoQuyetDinh", true);
				if (value == null) value = string.Empty;
				if (!_soQuyetDinh.Equals(value))
				{
					_soQuyetDinh = value;
					PropertyHasChanged("SoQuyetDinh");
				}
			}
		}

		public Int64 NguoiKy
		{
			get
			{
				CanReadProperty("NguoiKy", true);
				return _nguoiKy;
			}
			set
			{
				CanWriteProperty("NguoiKy", true);
				if (!_nguoiKy.Equals(value))
				{
					_nguoiKy = value;
					PropertyHasChanged("NguoiKy");
				}
			}
		}

		public int ChucVuNguoiKy
		{
			get
			{
				CanReadProperty("ChucVuNguoiKy", true);
				return _chucVuNguoiKy;
			}
			set
			{
				CanWriteProperty("ChucVuNguoiKy", true);
				if (!_chucVuNguoiKy.Equals(value))
				{
					_chucVuNguoiKy = value;
					PropertyHasChanged("ChucVuNguoiKy");
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

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
                //_tenNguoiLap = NguoiSuDung.GetNguoiSuDung(_nguoiLap).TenDangNhap;
                return _tenNguoiLap;
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

		protected override object GetIdValue()
		{
			return _maHoSoPhuCap;
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
			// SoQuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoQuyetDinh");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 50));
			//
			// NguoiKy
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NguoiKy");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiKy", 50));
			//
			// ChucVuNguoiKy
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "ChucVuNguoiKy");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ChucVuNguoiKy", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
			//
			// NgayLap
			//
			//ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
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
			//TODO: Define authorization rules in HoSoPhuCap
			//AuthorizationRules.AllowRead("MaHoSoPhuCap", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiPhuCap", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("HeSoPhuCap", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("PhanTramHuong", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("TongTien", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NgayBatDau", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NgayBatDauString", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NgatKetThuc", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NgatKetThucString", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NgayQuyetDinh", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NgayQuyetDinhString", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("SoQuyetDinh", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NguoiKy", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("ChucVuNguoiKy", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "HoSoPhuCapReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "HoSoPhuCapReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiPhuCap", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoPhuCap", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramHuong", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("TongTien", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("NgayBatDauString", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("NgatKetThucString", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("NgayQuyetDinhString", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("SoQuyetDinh", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiKy", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("ChucVuNguoiKy", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "HoSoPhuCapWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "HoSoPhuCapWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HoSoPhuCap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoPhuCapViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HoSoPhuCap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoPhuCapAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HoSoPhuCap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoPhuCapEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HoSoPhuCap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoPhuCapDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HoSoPhuCap()
		{ /* require use of factory method */ }

		public static HoSoPhuCap NewHoSoPhuCap()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HoSoPhuCap");
			return DataPortal.Create<HoSoPhuCap>();
		}

        public static HoSoPhuCap NewHoSoPhuCap(long MaNhanVien)
        {
            HoSoPhuCap hoSoPhuCap = new HoSoPhuCap();
            hoSoPhuCap.MaNhanVien = MaNhanVien;
            return hoSoPhuCap;
        }

        public static HoSoPhuCap GetHoSoPhuCap(int maHoSoPhuCap)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HoSoPhuCap");
			return DataPortal.Fetch<HoSoPhuCap>(new Criteria(maHoSoPhuCap));
		}

		public static void DeleteHoSoPhuCap(int maHoSoPhuCap)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HoSoPhuCap");
			DataPortal.Delete(new Criteria(maHoSoPhuCap));
		}

		public override HoSoPhuCap Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HoSoPhuCap");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HoSoPhuCap");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HoSoPhuCap");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HoSoPhuCap NewHoSoPhuCapChild()
		{
			HoSoPhuCap child = new HoSoPhuCap();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HoSoPhuCap GetHoSoPhuCap(SafeDataReader dr)
		{
			HoSoPhuCap child =  new HoSoPhuCap();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        public static int KiemTra_SoQuyetDinh(string SoQuyetDinh)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraSoQuyetDinh_HoSoPhuCap";
                        cm.Parameters.AddWithValue("@SoQuyetDinh", SoQuyetDinh);
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
            public int MaHoSoPhuCap;

            public Criteria(int MaHoSoPhuCap)
			{
                this.MaHoSoPhuCap = MaHoSoPhuCap;
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
                cm.CommandText = "spd_SelecttblnsHoSoPhuCap";

				cm.Parameters.AddWithValue("@MaHoSoPhuCap", criteria.MaHoSoPhuCap);

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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn, null);

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
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maHoSoPhuCap));
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
                cm.CommandText = "spd_DeletetblnsHoSoPhuCap";

				cm.Parameters.AddWithValue("@MaHoSoPhuCap", criteria.MaHoSoPhuCap);

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
			_maHoSoPhuCap = dr.GetInt32("MaHoSoPhuCap");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
			_heSoPhuCap = dr.GetDecimal("HeSoPhuCap");
			_phanTramHuong = dr.GetDecimal("PhanTramHuong");
			_tongTien = dr.GetDecimal("TongTien");
			_ngayBatDau = dr.GetDateTime("NgayBatDau");
            _ngatKetThuc = dr.GetDateTime("NgatKetThuc");
            _ngayQuyetDinh = dr.GetDateTime("NgayQuyetDinh");
			_soQuyetDinh = dr.GetString("SoQuyetDinh");
			_nguoiKy = dr.GetInt64("NguoiKy");
			_chucVuNguoiKy = dr.GetInt32("ChucVuNguoiKy");
			_dienGiai = dr.GetString("DienGiai");
			_nguoiLap = dr.GetInt32("NguoiLap");
            _ngayLap = dr.GetDateTime("NgayLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, HoSoPhuCapList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, HoSoPhuCapList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsHoSoPhuCap";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maHoSoPhuCap = (int)cm.Parameters["@MaHoSoPhuCap"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, HoSoPhuCapList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
			cm.Parameters.AddWithValue("@HeSoPhuCap", _heSoPhuCap);
			cm.Parameters.AddWithValue("@PhanTramHuong", _phanTramHuong);
			cm.Parameters.AddWithValue("@TongTien", _tongTien);
			cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.ToShortDateString());
			cm.Parameters.AddWithValue("@NgatKetThuc", _ngatKetThuc.ToShortDateString());
			cm.Parameters.AddWithValue("@NgayQuyetDinh", _ngayQuyetDinh.ToShortDateString());
			cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			cm.Parameters.AddWithValue("@ChucVuNguoiKy", _chucVuNguoiKy);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.ToShortDateString());
			cm.Parameters.AddWithValue("@MaHoSoPhuCap", _maHoSoPhuCap);
			cm.Parameters["@MaHoSoPhuCap"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, HoSoPhuCapList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, HoSoPhuCapList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsHoSoPhuCap";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HoSoPhuCapList parent)
		{
			cm.Parameters.AddWithValue("@MaHoSoPhuCap", _maHoSoPhuCap);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);

			if (_maLoaiPhuCap != 0)
				cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
			else
				cm.Parameters.AddWithValue("@MaLoaiPhuCap", DBNull.Value);
			cm.Parameters.AddWithValue("@HeSoPhuCap", _heSoPhuCap);
			cm.Parameters.AddWithValue("@PhanTramHuong", _phanTramHuong);
			cm.Parameters.AddWithValue("@TongTien", _tongTien);
			cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.ToShortDateString());
			cm.Parameters.AddWithValue("@NgatKetThuc", _ngatKetThuc.ToShortDateString());
			cm.Parameters.AddWithValue("@NgayQuyetDinh", _ngayQuyetDinh.ToShortDateString());
			cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			cm.Parameters.AddWithValue("@ChucVuNguoiKy", _chucVuNguoiKy);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.ToShortDateString());
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

			ExecuteDelete(cn, new Criteria(_maHoSoPhuCap));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
