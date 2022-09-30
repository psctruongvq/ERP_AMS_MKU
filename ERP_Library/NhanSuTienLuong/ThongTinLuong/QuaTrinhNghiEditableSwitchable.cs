
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhNghi : Csla.BusinessBase<QuaTrinhNghi>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuaTrinhNghi = 0;
		private long _maNhanVien = 0;
        private string _MaQLNhanVien = string.Empty;
        private string _TenNhanVien = string.Empty;
		private int _maHinhThucNghi = 0;
        private string _tenHinhThucNghi = string.Empty;
        private DateTime _ngayNghi = DateTime.Today;
        private DateTime _tuNgay = DateTime.Today;
        private DateTime _denNgay = DateTime.Today;
        private decimal _soGioNghi = 8;
        private decimal _soTienHuong = 0;
		private string _lyDo = string.Empty;
		private bool _truChuyenCan = false;
        private byte _suDung = 0;
        private bool _luongTinh = false;
        private bool _tinhTrang = false;
        private long _maNguoiLap = 0;
        private string _tenNguoiLap = string.Empty;
        private DateTime _ngayLap = DateTime.Today;
        private bool _GiaHan = false;
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuaTrinhNghi
		{
			get
			{
				CanReadProperty("MaQuaTrinhNghi", true);
				return _maQuaTrinhNghi;
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

		public int MaHinhThucNghi
		{
			get
			{
				CanReadProperty("MaHinhThucNghi", true);
				return _maHinhThucNghi;
			}
			set
			{
				CanWriteProperty("MaHinhThucNghi", true);
				if (!_maHinhThucNghi.Equals(value))
				{
					_maHinhThucNghi = value;
					PropertyHasChanged("MaHinhThucNghi");
				}
			}
		}

        public string TenHinhThucNghi
        {
            get
            {
                CanReadProperty("TenHinhThucNghi", true);
                return HinhThucNghi.GetHinhThucNghi(_maHinhThucNghi).TenHinhThucNghi;
            }
        }   
    
        public decimal SoGioNghi
        {
            get
            {
                CanReadProperty("SoGioNghi", true);
                return _soGioNghi;
            }
            set
            {
                CanWriteProperty("SoGioNghi", true);
                if (!_soGioNghi.Equals(value))
                {
                    _soGioNghi = value;
                    PropertyHasChanged("SoGioNghi");
                }
            }
        }

        public decimal SoTienHuong
        {
            get
            {
                CanReadProperty("SoTienHuong", true);
                return _soTienHuong;
            }
            set
            {
                CanWriteProperty("SoTienHuong", true);
                if (!_soTienHuong.Equals(value))
                {
                    _soTienHuong = value;
                    PropertyHasChanged("SoTienHuong");
                }
            }
        }

        public DateTime NgayNghi
        {
            get
            {
                CanReadProperty("NgayNghi", true);
                return _ngayNghi.Date;
            }
            set
            {
                CanWriteProperty("NgayNghi", true);
                if (!_ngayNghi.Equals(value))
                {
                    _ngayNghi = value;
                    PropertyHasChanged("NgayNghi");
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
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = value;
                    PropertyHasChanged("TuNgay");
                }
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
                if (!_denNgay.Equals(value))
                {
                    _denNgay = value;
                    PropertyHasChanged("DenNgay");
                }
            }
		}

		public string LyDo
		{
			get
			{
				CanReadProperty("LyDo", true);
				return _lyDo;
			}
			set
			{
				CanWriteProperty("LyDo", true);
				if (value == null) value = string.Empty;
				if (!_lyDo.Equals(value))
				{
					_lyDo = value;
					PropertyHasChanged("LyDo");
				}
			}
		}
        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty( true);
                return _MaQLNhanVien;
            }          
        }
        public string TenNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _TenNhanVien;
            }
        }

		public bool TruChuyenCan
		{
			get
			{
				CanReadProperty("TruChuyenCan", true);
				return _truChuyenCan;
			}
			set
			{
				CanWriteProperty("TruChuyenCan", true);
				if (!_truChuyenCan.Equals(value))
				{
					_truChuyenCan = value;
					PropertyHasChanged("TruChuyenCan");
				}
			}
		}

        public byte SuDung
        {
            get
            {
                CanReadProperty("SuDung", true);
                return _suDung;
            }
            set
            {
                CanWriteProperty("SuDung", true);
                if (!_suDung.Equals(value))
                {
                    _suDung = value;
                    PropertyHasChanged("SuDung");
                }
            }
        }

        public bool LuongTinh
        {
            get
            {
                CanReadProperty("LuongTinh", true);
                return _luongTinh;
            }
            set
            {
                CanWriteProperty("LuongTinh", true);
                if (!_luongTinh.Equals(value))
                {
                    _luongTinh = value;
                    PropertyHasChanged("LuongTinh");
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
        public bool GiaHan
        {
            get
            {
                CanReadProperty("GiaHan", true);
                return _GiaHan;
            }
            set
            {
                CanWriteProperty("Giahan", true);
                if (!_GiaHan.Equals(value))
                {
                    _GiaHan = value;
                    PropertyHasChanged("Giahan");
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
               // _tenNguoiLap = NguoiSuDung.GetNguoiSuDung(_maNguoiLap).TenDangNhap;
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
			return _maQuaTrinhNghi;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 4000));
			//
			// MaNguoiLap
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaNguoiLap", 10));
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
			//TODO: Define authorization rules in QuaTrinhNghi
			//AuthorizationRules.AllowRead("MaQuaTrinhNghi", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("MaHinhThucNghi", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("LyDo", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("TruChuyenCan", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuaTrinhNghiReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhNghiReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhNghiWriteGroup");
			//AuthorizationRules.AllowWrite("MaHinhThucNghi", "QuaTrinhNghiWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "QuaTrinhNghiWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "QuaTrinhNghiWriteGroup");
			//AuthorizationRules.AllowWrite("LyDo", "QuaTrinhNghiWriteGroup");
			//AuthorizationRules.AllowWrite("TruChuyenCan", "QuaTrinhNghiWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhNghiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhNghiWriteGroup");
		}

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhNghi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhNghi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhNghi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhNghi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiDeleteGroup"))
			//	return true;
			//return false;
		}

        public static int KiemTraNVNghi(long maNV, DateTime ngayNghi)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                 using (SqlCommand cm = cn.CreateCommand())
                    {
                        
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraNhanVienNghi";
                        cm.Parameters.AddWithValue("@maNV", maNV);
                        cm.Parameters.AddWithValue("@NgayNghi",Convert.ToDateTime(ngayNghi.ToShortDateString())); 
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;
                    }
               
                return gt;
            }//using
        }
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhNghi()
		{ /* require use of factory method */ }

		public static QuaTrinhNghi NewQuaTrinhNghi()
		{
            QuaTrinhNghi item = new QuaTrinhNghi();
            item.MarkAsChild();
            return item;
		}

        public static QuaTrinhNghi NewQuaTrinhNghi(long maNhanVien)
        {
            QuaTrinhNghi _QuaTrinhNghi = new QuaTrinhNghi();
            _QuaTrinhNghi.MaNhanVien = maNhanVien;
            return _QuaTrinhNghi;
        }

		public static QuaTrinhNghi GetQuaTrinhNghi(int maQuaTrinhNghi)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghi");
			return DataPortal.Fetch<QuaTrinhNghi>(new Criteria(maQuaTrinhNghi));
		}

		public static void DeleteQuaTrinhNghi(long maNhanVien, DateTime ngayNghi)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhNghi");
			DataPortal.Delete(new Criteria_Delete(maNhanVien,ngayNghi));
		}

		public override QuaTrinhNghi Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhNghi");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhNghi");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuaTrinhNghi");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuaTrinhNghi NewQuaTrinhNghiChild()
		{
			QuaTrinhNghi child = new QuaTrinhNghi();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuaTrinhNghi GetQuaTrinhNghi(SafeDataReader dr)
		{
			QuaTrinhNghi child =  new QuaTrinhNghi();
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
			public int MaQuaTrinhNghi;

			public Criteria(int maQuaTrinhNghi)
			{
				this.MaQuaTrinhNghi = maQuaTrinhNghi;
			}
		}

        private class Criteria_Delete
        {
            public long MaNhanVien;
            public DateTime NgayNghi;
            //public DateTime DenNgay;

            public Criteria_Delete(long maNhanVien, DateTime NgayNghi)
            {
                this.MaNhanVien = maNhanVien;
                this.NgayNghi = NgayNghi;
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhNghi";

				cm.Parameters.AddWithValue("@MaQuaTrinhNghi", criteria.MaQuaTrinhNghi);

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
			DataPortal_Delete(new Criteria(_maQuaTrinhNghi));
		}

		private void DataPortal_Delete(Criteria_Delete criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria_Delete criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsQuaTrinhNghi";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                cm.Parameters.AddWithValue("@NgayNghi", criteria.NgayNghi);
                //cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);

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
			_maQuaTrinhNghi = dr.GetInt32("MaQuaTrinhNghi");
			_maNhanVien = dr.GetInt64("MaNhanVien");
            _TenNhanVien = dr.GetString("Tennhanvien");
            _MaQLNhanVien = dr.GetString("maQLNhanVien");
			_maHinhThucNghi = dr.GetInt32("MaHinhThucNghi");
            _soTienHuong = dr.GetDecimal("SoTienHuong");
            _soGioNghi = dr.GetDecimal("SoGioNghi");
            _ngayNghi = dr.GetDateTime("NgayNghi");
            _suDung = dr.GetByte("SuDung");
            _luongTinh = dr.GetBoolean("LuongTinh");
            //_tinhTrang = dr.GetBoolean("TinhTrang");
			_tuNgay = dr.GetDateTime("TuNgay");
            _denNgay = dr.GetDateTime("DenNgay");
			_lyDo = dr.GetString("LyDo");
			_truChuyenCan = dr.GetBoolean("TruChuyenCan");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
            _ngayLap = dr.GetDateTime("NgayLap");
            _GiaHan = dr.GetBoolean("Giahang");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, QuaTrinhNghiList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, QuaTrinhNghiList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsQuaTrinhNghi";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maQuaTrinhNghi = (int)cm.Parameters["@MaQuaTrinhNghi"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuaTrinhNghiList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
            cm.Parameters.AddWithValue("@SoGioNghi", _soGioNghi);
            cm.Parameters.AddWithValue("@SoTienHuong", _soTienHuong);
            cm.Parameters.AddWithValue("@NgayNghi", _ngayNghi);
            cm.Parameters.AddWithValue("@SuDung", _suDung);
            cm.Parameters.AddWithValue("@LuongTinh", _luongTinh);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay);
			if (_lyDo.Length > 0)
				cm.Parameters.AddWithValue("@LyDo", _lyDo);
			else
				cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
			if (_truChuyenCan != false)
				cm.Parameters.AddWithValue("@TruChuyenCan", _truChuyenCan);
			else
				cm.Parameters.AddWithValue("@TruChuyenCan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			cm.Parameters.AddWithValue("@MaQuaTrinhNghi", _maQuaTrinhNghi);
            cm.Parameters.AddWithValue("@Giahan", _GiaHan);
			cm.Parameters["@MaQuaTrinhNghi"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, QuaTrinhNghiList parent)
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
        public  static void UpdateLichLamViecNVBySuDung(long maNhanVien, DateTime ngay)
        {
            using (SqlConnection cnn = new SqlConnection(Database.ERP_Connection))
            {
                cnn.Open();
                using (SqlCommand cm = cnn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblnsQuaTrinhNghiBySuDung";
                    cm.Parameters.AddWithValue("@NgayNghi",Convert.ToDateTime(ngay.ToShortDateString()));
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.ExecuteNonQuery();

                }
            }
        }
		private void ExecuteUpdate(SqlConnection cn, QuaTrinhNghiList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsQuaTrinhNghi";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, QuaTrinhNghiList parent)
		{
			cm.Parameters.AddWithValue("@MaQuaTrinhNghi", _maQuaTrinhNghi);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
            cm.Parameters.AddWithValue("@SoGioNghi", _soGioNghi);
            cm.Parameters.AddWithValue("@SoTienHuong", _soTienHuong);
            cm.Parameters.AddWithValue("@NgayNghi", _ngayNghi);
            cm.Parameters.AddWithValue("@SuDung", _suDung);
            cm.Parameters.AddWithValue("@LuongTinh", _luongTinh);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay);
			if (_lyDo.Length > 0)
				cm.Parameters.AddWithValue("@LyDo", _lyDo);
			else
				cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
			if (_truChuyenCan != false)
				cm.Parameters.AddWithValue("@TruChuyenCan", _truChuyenCan);
			else
				cm.Parameters.AddWithValue("@TruChuyenCan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@GiaHan", _GiaHan);
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

			ExecuteDelete(cn, new Criteria_Delete(_maNhanVien, _ngayNghi));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        public static void ThemQTNghi(long manhanvien, int Hinhthucnghi, decimal sogionghi, short truchuyencan, string lydo,DateTime ngaylap, long manguoilap,DateTime Tungay, DateTime denngay)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_InserttblnsQuatrinhNghitheoDS";
                        cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                        cm.Parameters.AddWithValue("@MaHinhthucnghi", Hinhthucnghi);
                        cm.Parameters.AddWithValue("@sogionghi", sogionghi);
                        cm.Parameters.AddWithValue("@TruChuyenCan", truchuyencan);
                        cm.Parameters.AddWithValue("@Lydo", lydo);
                        cm.Parameters.AddWithValue("@NgayLap", ngaylap);
                        cm.Parameters.AddWithValue("@Manguoilap", manguoilap);
                        cm.Parameters.AddWithValue("@Tungay", Tungay);
                        cm.Parameters.AddWithValue("@Denngay", denngay);
                        cm.Parameters.AddWithValue("@TinhTrang", 0);
                        // Chua Su dung cac bien nay khong duoc dung insert theo default
                        cm.Parameters.AddWithValue("@SuDung", 0);
                        cm.Parameters.AddWithValue("@Giahan", false);
                        cm.Parameters.AddWithValue("@LuongTinh", false);
                        cm.Parameters.AddWithValue("@SoTienHuong", 0);
                        cm.ExecuteNonQuery();
                    }
            }
            
        }



	}
}
