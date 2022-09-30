
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanHeGiaDinh : Csla.BusinessBase<QuanHeGiaDinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _mactQuanhegiadinh = 0;
		private long _maNhanVien = 0;
		private string _hoTenNguoiThan = string.Empty;
		private bool _gioiTinh = false;
        private Nullable<DateTime> _ngaySinh = null;
		private int _maQuanHe = 0;
		private string _cmnd = string.Empty;
        private Nullable<DateTime> _ngayCap = null;
		private int _maNoiCap = 0;
		private bool _tinhTrang = false;
		private string _diaChi = string.Empty;
		private int _maThanhPhanGD = 0;
		private string _ngheNghiepHienTai = string.Empty;
		private string _noilamViec = string.Empty;
		private bool _dangVien = false;
		private bool _cuTruNgoaiNuoc = false;
		private int _maNuoc = 0;
		private string _quaTrinhCongTac = string.Empty;
		private long _maNguoiLap = 1;
        private string _tenNguoiLap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private string _HoChieu = string.Empty;
        private string _SoGiayKhaiSinh = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public int MactQuanhegiadinh
		{
			get
			{
				CanReadProperty("MactQuanhegiadinh", true);
				return _mactQuanhegiadinh;
			}
		}
        public string SoGiayKhaiSinh
        {
            get
            {
                CanReadProperty("SoGiayKhaiSinh", true);
                return _SoGiayKhaiSinh;
            }
            set
            {
                CanWriteProperty("SoGiayKhaiSinh", true);
                if (value == null) value = string.Empty;
                if (!_SoGiayKhaiSinh.Equals(value))
                {
                    _SoGiayKhaiSinh = value;
                    PropertyHasChanged("SoGiayKhaiSinh");
                }
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
        public string HoChieu
        {
            get
            {
                CanReadProperty("HoChieu", true);
                return _HoChieu;
            }
            set
            {
                CanWriteProperty("HoChieu", true);
                if (value == null) value = string.Empty;
                if (!_HoChieu.Equals(value))
                {
                    _HoChieu = value;
                    PropertyHasChanged("HoChieu");
                }
            }
        }
		public string HoTenNguoiThan
		{
			get
			{
				CanReadProperty("HoTenNguoiThan", true);
				return _hoTenNguoiThan;
			}
			set
			{
				CanWriteProperty("HoTenNguoiThan", true);
				if (value == null) value = string.Empty;
				if (!_hoTenNguoiThan.Equals(value))
				{
					_hoTenNguoiThan = value;
					PropertyHasChanged("HoTenNguoiThan");
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

        public Nullable<DateTime> NgaySinh
        {
			get
			{
				CanReadProperty("NgaySinh", true);
				return _ngaySinh;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngaySinh.Equals(value))
                {
                    _ngaySinh = value;
                    PropertyHasChanged("NgaySinh");
                }
            }
		}		

		public int MaQuanHe
		{
			get
			{
				CanReadProperty("MaQuanHe", true);
				return _maQuanHe;
			}
			set
			{
				CanWriteProperty("MaQuanHe", true);
				if (!_maQuanHe.Equals(value))
				{
					_maQuanHe = value;
					PropertyHasChanged("MaQuanHe");
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

        public Nullable<DateTime> NgayCap
        {
			get
			{
				CanReadProperty("NgayCap", true);
				return _ngayCap;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayCap.Equals(value))
                {
                    _ngayCap = value;
                    PropertyHasChanged("NgayCap");
                }
            }
		}

		public int MaNoiCap
		{
			get
			{
				CanReadProperty("MaNoiCap", true);
				return _maNoiCap;
			}
			set
			{
				CanWriteProperty("MaNoiCap", true);
				if (!_maNoiCap.Equals(value))
				{
					_maNoiCap = value;
					PropertyHasChanged("MaNoiCap");
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

		public string DiaChi
		{
			get
			{
				CanReadProperty("DiaChi", true);
				return _diaChi;
			}
			set
			{
				CanWriteProperty("DiaChi", true);
				if (value == null) value = string.Empty;
				if (!_diaChi.Equals(value))
				{
					_diaChi = value;
					PropertyHasChanged("DiaChi");
				}
			}
		}

		public int MaThanhPhanGD
		{
			get
			{
				CanReadProperty("MaThanhPhanGD", true);
				return _maThanhPhanGD;
			}
			set
			{
				CanWriteProperty("MaThanhPhanGD", true);
				if (!_maThanhPhanGD.Equals(value))
				{
					_maThanhPhanGD = value;
					PropertyHasChanged("MaThanhPhanGD");
				}
			}
		}

		public string NgheNghiepHienTai
		{
			get
			{
				CanReadProperty("NgheNghiepHienTai", true);
				return _ngheNghiepHienTai;
			}
			set
			{
				CanWriteProperty("NgheNghiepHienTai", true);
				if (value == null) value = string.Empty;
				if (!_ngheNghiepHienTai.Equals(value))
				{
					_ngheNghiepHienTai = value;
					PropertyHasChanged("NgheNghiepHienTai");
				}
			}
		}

		public string NoilamViec
		{
			get
			{
				CanReadProperty("NoilamViec", true);
				return _noilamViec;
			}
			set
			{
				CanWriteProperty("NoilamViec", true);
				if (value == null) value = string.Empty;
				if (!_noilamViec.Equals(value))
				{
					_noilamViec = value;
					PropertyHasChanged("NoilamViec");
				}
			}
		}

		public bool DangVien
		{
			get
			{
				CanReadProperty("DangVien", true);
				return _dangVien;
			}
			set
			{
				CanWriteProperty("DangVien", true);
				if (!_dangVien.Equals(value))
				{
					_dangVien = value;
					PropertyHasChanged("DangVien");
				}
			}
		}

		public bool CuTruNgoaiNuoc
		{
			get
			{
				CanReadProperty("CuTruNgoaiNuoc", true);
				return _cuTruNgoaiNuoc;
			}
			set
			{
				CanWriteProperty("CuTruNgoaiNuoc", true);
				if (!_cuTruNgoaiNuoc.Equals(value))
				{
					_cuTruNgoaiNuoc = value;
					PropertyHasChanged("CuTruNgoaiNuoc");
				}
			}
		}

		public int MaNuoc
		{
			get
			{
				CanReadProperty("MaNuoc", true);
				return _maNuoc;
			}
			set
			{
				CanWriteProperty("MaNuoc", true);
				if (!_maNuoc.Equals(value))
				{
					_maNuoc = value;
					PropertyHasChanged("MaNuoc");
				}
			}
		}

		public string QuaTrinhCongTac
		{
			get
			{
				CanReadProperty("QuaTrinhCongTac", true);
				return _quaTrinhCongTac;
			}
			set
			{
				CanWriteProperty("QuaTrinhCongTac", true);
				if (value == null) value = string.Empty;
				if (!_quaTrinhCongTac.Equals(value))
				{
					_quaTrinhCongTac = value;
					PropertyHasChanged("QuaTrinhCongTac");
				}
			}
		}

		public long MaNguoiLap
		{
			get
			{
				CanReadProperty("MaNguoiLap", true);
				return _maNguoiLap;
			}
			set
			{
				CanWriteProperty("MaNguoiLap", true);
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
                //_tenNguoiLap =DangNhap.GetNguoiSuDung(_maNguoiLap).TenDangNhap;
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
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
		}		
 
		protected override object GetIdValue()
		{
			return _mactQuanhegiadinh;
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
			// HoTenNguoiThan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("HoTenNguoiThan", 1000));
			//
			// Cmnd
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 20));
			//
			// DiaChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 500));
			//
			// NgheNghiepHienTai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NgheNghiepHienTai", 200));
			//
			// NoilamViec
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoilamViec", 500));
			//
			// QuaTrinhCongTac
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuaTrinhCongTac", 4000));
			//
			// NgayLap
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
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
			//TODO: Define authorization rules in QuanHeGiaDinh
			//AuthorizationRules.AllowRead("MactQuanhegiadinh", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("HoTenNguoiThan", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("GioiTinh", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("NgaySinh", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("NgaySinhString", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("MaQuanHe", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("Cmnd", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("NgayCap", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("NgayCapString", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("MaNoiCap", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("TinhTrang", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("DiaChi", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("MaThanhPhanGD", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("NgheNghiepHienTai", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("NoilamViec", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("DangVien", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("CuTruNgoaiNuoc", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("MaNuoc", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("QuaTrinhCongTac", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuanHeGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuanHeGiaDinhReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("HoTenNguoiThan", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("GioiTinh", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("NgaySinhString", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanHe", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("Cmnd", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("NgayCapString", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaNoiCap", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTrang", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChi", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaThanhPhanGD", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("NgheNghiepHienTai", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("NoilamViec", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("DangVien", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("CuTruNgoaiNuoc", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaNuoc", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("QuaTrinhCongTac", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuanHeGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuanHeGiaDinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuanHeGiaDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeGiaDinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuanHeGiaDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeGiaDinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuanHeGiaDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeGiaDinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuanHeGiaDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeGiaDinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuanHeGiaDinh()
		{ /* require use of factory method */ }

		public static QuanHeGiaDinh NewQuanHeGiaDinh()
		{
            QuanHeGiaDinh item = new QuanHeGiaDinh();
            item.MarkAsChild();
            return item;
		}

        public static QuanHeGiaDinh NewQuanHeGiaDinh(long maNhanVien)
        {
            QuanHeGiaDinh _QuanHeGiaDinh = new QuanHeGiaDinh();
            _QuanHeGiaDinh.MaNhanVien = maNhanVien;
            return _QuanHeGiaDinh;
        }

		public static QuanHeGiaDinh GetQuanHeGiaDinh(int mactQuanhegiadinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuanHeGiaDinh");
			return DataPortal.Fetch<QuanHeGiaDinh>(new Criteria(mactQuanhegiadinh));
		}

		public static void DeleteQuanHeGiaDinh(int mactQuanhegiadinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuanHeGiaDinh");
			DataPortal.Delete(new Criteria(mactQuanhegiadinh));
		}

		public override QuanHeGiaDinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuanHeGiaDinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuanHeGiaDinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuanHeGiaDinh");

			return base.Save();
		}
        public static int KiemTraCMNDBiTrung(string CMND,long MaNhanVien)
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
                        cm.CommandText = "spd_KiemTraCMND_NhanVien_NguoiThan_DuyNhat";
                        if (CMND.Length > 0)
                            cm.Parameters.AddWithValue("@CMND", CMND);
                        else
                            cm.Parameters.AddWithValue("@CMND", DBNull.Value);
                        if(MaNhanVien!=0)
                            cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        else
                            cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
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
        public static int KiemTraHoChieuBiTrung(string HoChieu, long MaNhanVien)
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
                        cm.CommandText = "spd_KiemTraHoChieu_NhanVien_NguoiThan_DuyNhat";
                        if (HoChieu.Length > 0)
                            cm.Parameters.AddWithValue("@HoChieu", HoChieu);
                        else
                            cm.Parameters.AddWithValue("@HoChieu", DBNull.Value);
                        if (MaNhanVien != 0)
                            cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        else
                            cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
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
        public static int KiemTraSoGiayKhaiSinhBiTrung(string SoGiayKhaiSinh, long MaNhanVien)
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
                        cm.CommandText = "spd_KiemTraSoGiayKhaiSinh_NhanVien_NguoiThan_DuyNhat";
                        if (SoGiayKhaiSinh.Length > 0)
                            cm.Parameters.AddWithValue("@SoGiayKhaiSinh", SoGiayKhaiSinh);
                        else
                            cm.Parameters.AddWithValue("@SoGiayKhaiSinh", DBNull.Value);
                        if (MaNhanVien != 0)
                            cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        else
                            cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
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
	
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuanHeGiaDinh NewQuanHeGiaDinhChild()
		{
			QuanHeGiaDinh child = new QuanHeGiaDinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuanHeGiaDinh GetQuanHeGiaDinh(SafeDataReader dr)
		{
			QuanHeGiaDinh child =  new QuanHeGiaDinh();
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
			public int MactQuanhegiadinh;

			public Criteria(int mactQuanhegiadinh)
			{
				this.MactQuanhegiadinh = mactQuanhegiadinh;
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
                cm.CommandText = "spd_SelecttblnsQuanHeGiaDinh";

				cm.Parameters.AddWithValue("@MaCT_QuanHeGiaDinh", criteria.MactQuanhegiadinh);

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
			DataPortal_Delete(new Criteria(_mactQuanhegiadinh));
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
                cm.CommandText = "spd_DeletetblnsQuanHeGiaDinh";

				cm.Parameters.AddWithValue("@MaCT_QuanHeGiaDinh", criteria.MactQuanhegiadinh);

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
			_mactQuanhegiadinh = dr.GetInt32("MaCT_QuanHeGiaDinh");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_hoTenNguoiThan = dr.GetString("HoTenNguoiThan");
			_gioiTinh = dr.GetBoolean("GioiTinh");
            object ngaySinh = dr.GetValue("NgaySinh");
            if (ngaySinh != null)
                _ngaySinh = (DateTime)ngaySinh;
            else
                _ngaySinh = null;
			
			_maQuanHe = dr.GetInt32("MaQuanHe");
			_cmnd = dr.GetString("CMND");
            object ngayCap = dr.GetValue("NgayCap");
            if (ngayCap != null)
                _ngayCap = (DateTime)ngayCap;
            else
                _ngayCap = null;			
			_maNoiCap = dr.GetInt32("MaNoiCap");
			_tinhTrang = dr.GetBoolean("TinhTrang");
			_diaChi = dr.GetString("DiaChi");
			_maThanhPhanGD = dr.GetInt32("MaThanhPhanGD");
			_ngheNghiepHienTai = dr.GetString("NgheNghiepHienTai");
			_noilamViec = dr.GetString("NoilamViec");
			_dangVien = dr.GetBoolean("DangVien");
			_cuTruNgoaiNuoc = dr.GetBoolean("CuTruNgoaiNuoc");
			_maNuoc = dr.GetInt32("MaNuoc");
			_quaTrinhCongTac = dr.GetString("QuaTrinhCongTac");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _HoChieu = dr.GetString("HoChieu");
            _SoGiayKhaiSinh = dr.GetString("SoGiayKhaiSinh");
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
                cm.CommandText = "spd_InserttblnsQuanHeGiaDinh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_mactQuanhegiadinh = (int)cm.Parameters["@MaCT_QuanHeGiaDinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_hoTenNguoiThan.Length > 0)
				cm.Parameters.AddWithValue("@HoTenNguoiThan", _hoTenNguoiThan);
			else
				cm.Parameters.AddWithValue("@HoTenNguoiThan", DBNull.Value);
            if (_HoChieu.Length > 0)
                cm.Parameters.AddWithValue("@HoChieu", _HoChieu);
            else
                cm.Parameters.AddWithValue("@HoChieu", DBNull.Value);
            if (_SoGiayKhaiSinh.Length > 0)
                cm.Parameters.AddWithValue("@SoGiayKhaiSinh", _SoGiayKhaiSinh);
            else
                cm.Parameters.AddWithValue("@SoGiayKhaiSinh", DBNull.Value);
			if (_gioiTinh != false)
				cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
			else
				cm.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
            if (_ngaySinh == null)
                cm.Parameters.AddWithValue("@NgaySinh", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh);
			
			if (_maQuanHe != 0)
				cm.Parameters.AddWithValue("@MaQuanHe", _maQuanHe);
			else
				cm.Parameters.AddWithValue("@MaQuanHe", DBNull.Value);
			if (_cmnd.Length > 0)
				cm.Parameters.AddWithValue("@CMND", _cmnd);
			else
				cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_ngayCap == null)
                cm.Parameters.AddWithValue("@NgayCap", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
			if (_maNoiCap != 0)
				cm.Parameters.AddWithValue("@MaNoiCap", _maNoiCap);
			else
				cm.Parameters.AddWithValue("@MaNoiCap", DBNull.Value);
			if (_tinhTrang != false)
				cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			else
				cm.Parameters.AddWithValue("@TinhTrang", false);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_maThanhPhanGD != 0)
				cm.Parameters.AddWithValue("@MaThanhPhanGD", _maThanhPhanGD);
			else
				cm.Parameters.AddWithValue("@MaThanhPhanGD", DBNull.Value);
			if (_ngheNghiepHienTai.Length > 0)
				cm.Parameters.AddWithValue("@NgheNghiepHienTai", _ngheNghiepHienTai);
			else
				cm.Parameters.AddWithValue("@NgheNghiepHienTai", DBNull.Value);
			if (_noilamViec.Length > 0)
				cm.Parameters.AddWithValue("@NoilamViec", _noilamViec);
			else
				cm.Parameters.AddWithValue("@NoilamViec", DBNull.Value);
			if (_dangVien != false)
				cm.Parameters.AddWithValue("@DangVien", _dangVien);
			else
				cm.Parameters.AddWithValue("@DangVien", DBNull.Value);
			if (_cuTruNgoaiNuoc != false)
				cm.Parameters.AddWithValue("@CuTruNgoaiNuoc", _cuTruNgoaiNuoc);
			else
				cm.Parameters.AddWithValue("@CuTruNgoaiNuoc", DBNull.Value);
			if (_maNuoc != 0)
				cm.Parameters.AddWithValue("@MaNuoc", _maNuoc);
			else
				cm.Parameters.AddWithValue("@MaNuoc", DBNull.Value);
			if (_quaTrinhCongTac.Length > 0)
				cm.Parameters.AddWithValue("@QuaTrinhCongTac", _quaTrinhCongTac);
			else
				cm.Parameters.AddWithValue("@QuaTrinhCongTac", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaCT_QuanHeGiaDinh", _mactQuanhegiadinh);
			cm.Parameters["@MaCT_QuanHeGiaDinh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuanHeGiaDinh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaCT_QuanHeGiaDinh", _mactQuanhegiadinh);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_hoTenNguoiThan.Length > 0)
				cm.Parameters.AddWithValue("@HoTenNguoiThan", _hoTenNguoiThan);
			else
				cm.Parameters.AddWithValue("@HoTenNguoiThan", DBNull.Value);
			if (_gioiTinh != false)
				cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
			else
				cm.Parameters.AddWithValue("@GioiTinh", DBNull.Value);
            if (_ngaySinh == null)
                cm.Parameters.AddWithValue("@NgaySinh", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh);
			
			if (_maQuanHe != 0)
				cm.Parameters.AddWithValue("@MaQuanHe", _maQuanHe);
			else
				cm.Parameters.AddWithValue("@MaQuanHe", DBNull.Value);
			if (_cmnd.Length > 0)
				cm.Parameters.AddWithValue("@CMND", _cmnd);
			else
				cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_ngayCap == null)
                cm.Parameters.AddWithValue("@NgayCap", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
			if (_maNoiCap != 0)
				cm.Parameters.AddWithValue("@MaNoiCap", _maNoiCap);
			else
				cm.Parameters.AddWithValue("@MaNoiCap", DBNull.Value);
			if (_tinhTrang != false)
				cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			else
				cm.Parameters.AddWithValue("@TinhTrang", false);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_maThanhPhanGD != 0)
				cm.Parameters.AddWithValue("@MaThanhPhanGD", _maThanhPhanGD);
			else
				cm.Parameters.AddWithValue("@MaThanhPhanGD", DBNull.Value);
			if (_ngheNghiepHienTai.Length > 0)
				cm.Parameters.AddWithValue("@NgheNghiepHienTai", _ngheNghiepHienTai);
			else
				cm.Parameters.AddWithValue("@NgheNghiepHienTai", DBNull.Value);
			if (_noilamViec.Length > 0)
				cm.Parameters.AddWithValue("@NoilamViec", _noilamViec);
			else
				cm.Parameters.AddWithValue("@NoilamViec", DBNull.Value);
			if (_dangVien != false)
				cm.Parameters.AddWithValue("@DangVien", _dangVien);
			else
				cm.Parameters.AddWithValue("@DangVien", DBNull.Value);
			if (_cuTruNgoaiNuoc != false)
				cm.Parameters.AddWithValue("@CuTruNgoaiNuoc", _cuTruNgoaiNuoc);
			else
				cm.Parameters.AddWithValue("@CuTruNgoaiNuoc", DBNull.Value);
			if (_maNuoc != 0)
				cm.Parameters.AddWithValue("@MaNuoc", _maNuoc);
			else
				cm.Parameters.AddWithValue("@MaNuoc", DBNull.Value);
			if (_quaTrinhCongTac.Length > 0)
				cm.Parameters.AddWithValue("@QuaTrinhCongTac", _quaTrinhCongTac);
			else
				cm.Parameters.AddWithValue("@QuaTrinhCongTac", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_HoChieu.Length > 0)
                cm.Parameters.AddWithValue("@HoChieu", _HoChieu);
            else
                cm.Parameters.AddWithValue("@HoChieu", DBNull.Value);
            if (_SoGiayKhaiSinh.Length > 0)
                cm.Parameters.AddWithValue("@SoGiayKhaiSinh", _SoGiayKhaiSinh);
            else
                cm.Parameters.AddWithValue("@SoGiayKhaiSinh", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_mactQuanhegiadinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
