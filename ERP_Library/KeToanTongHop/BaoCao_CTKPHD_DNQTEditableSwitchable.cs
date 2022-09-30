
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoCao_CTKPHD_DNQT : Csla.BusinessBase<BaoCao_CTKPHD_DNQT>
	{
		#region Business Properties and Methods

		//declare members
        private int _sTT = 0;
		private int _maMucNganSach = 0;
		private string _muc = string.Empty;
		private string _tenMucNganSach = string.Empty;
		private string _tieuMuc = string.Empty;
		private string _tenTieuMuc = string.Empty;
		private decimal _sotienKyNay = 0;
		private decimal _soTienLuyKe = 0;
		private string _tenNguon = string.Empty;
		private int _maNguon = 0;
		private long _maNguoiLap = 0;
		private string _tenChiPhiHD = string.Empty;
        private string _tenhoatdong = string.Empty;

        private decimal _hoatDongSuNghiepCoThu = 0;
        private decimal _boSungKinhPhiSuNghiep = 0;
        private decimal _phatTrienSuNghiep = 0;
        private decimal _thuNhapTangThem = 0;
        private decimal _kinhPhiKhac = 0;


        private decimal _hoatDongSuNghiepCoThuNamTruoc = 0;
        private decimal _boSungKinhPhiSuNghiepNamTruoc = 0;
        private decimal _phatTrienSuNghiepNamTruoc = 0;
        private decimal _thuNhapTangThemNamTruoc = 0;
        private decimal _kinhPhiKhacNamTruoc = 0;

        private decimal _clChiPhiHDDV = 0;
        private decimal _tyLePhanTramHDDV = 0;
        private decimal _clThuNhapTangThem = 0;
        private decimal _tyLePhanTramTNTT = 0;

        public int STT
        {
            get
            {
                CanReadProperty("STT", true);
                return _sTT;
            }
            set
            {
                CanWriteProperty("STT", true);
                if (!_sTT.Equals(value))
                {
                    _sTT = value;
                    PropertyHasChanged("STT");
                }
            }
        }

		public int MaMucNganSach
		{
			get
			{
				CanReadProperty("MaMucNganSach", true);
				return _maMucNganSach;
			}
			set
			{
				CanWriteProperty("MaMucNganSach", true);
				if (!_maMucNganSach.Equals(value))
				{
					_maMucNganSach = value;
					PropertyHasChanged("MaMucNganSach");
				}
			}
		}

		public string Muc
		{
			get
			{
				CanReadProperty("Muc", true);
				return _muc;
			}
			set
			{
				CanWriteProperty("Muc", true);
				if (value == null) value = string.Empty;
				if (!_muc.Equals(value))
				{
					_muc = value;
					PropertyHasChanged("Muc");
				}
			}
		}

		public string TenMucNganSach
		{
			get
			{
				CanReadProperty("TenMucNganSach", true);
				return _tenMucNganSach;
			}
			set
			{
				CanWriteProperty("TenMucNganSach", true);
				if (value == null) value = string.Empty;
				if (!_tenMucNganSach.Equals(value))
				{
					_tenMucNganSach = value;
					PropertyHasChanged("TenMucNganSach");
				}
			}
		}

		public string TieuMuc
		{
			get
			{
				CanReadProperty("TieuMuc", true);
				return _tieuMuc;
			}
			set
			{
				CanWriteProperty("TieuMuc", true);
				if (value == null) value = string.Empty;
				if (!_tieuMuc.Equals(value))
				{
					_tieuMuc = value;
					PropertyHasChanged("TieuMuc");
				}
			}
		}

		public string TenTieuMuc
		{
			get
			{
				CanReadProperty("TenTieuMuc", true);
				return _tenTieuMuc;
			}
			set
			{
				CanWriteProperty("TenTieuMuc", true);
				if (value == null) value = string.Empty;
				if (!_tenTieuMuc.Equals(value))
				{
					_tenTieuMuc = value;
					PropertyHasChanged("TenTieuMuc");
				}
			}
		}

		public decimal SotienKyNay
		{
			get
			{
				CanReadProperty("SotienKyNay", true);
				return _sotienKyNay;
			}
			set
			{
				CanWriteProperty("SotienKyNay", true);
				if (!_sotienKyNay.Equals(value))
				{
					_sotienKyNay = value;
					PropertyHasChanged("SotienKyNay");
				}
			}
		}

		public decimal SoTienLuyKe
		{
			get
			{
				CanReadProperty("SoTienLuyKe", true);
				return _soTienLuyKe;
			}
			set
			{
				CanWriteProperty("SoTienLuyKe", true);
				if (!_soTienLuyKe.Equals(value))
				{
					_soTienLuyKe = value;
					PropertyHasChanged("SoTienLuyKe");
				}
			}
		}

		public string TenNguon
		{
			get
			{
				CanReadProperty("TenNguon", true);
				return _tenNguon;
			}
			set
			{
				CanWriteProperty("TenNguon", true);
				if (value == null) value = string.Empty;
				if (!_tenNguon.Equals(value))
				{
					_tenNguon = value;
					PropertyHasChanged("TenNguon");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaNguon
		{
			get
			{
				CanReadProperty("MaNguon", true);
				return _maNguon;
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaNguoiLap
		{
			get
			{
				CanReadProperty("MaNguoiLap", true);
				return _maNguoiLap;
			}
		}

		public string TenChiPhiHD
		{
			get
			{
				CanReadProperty("TenChiPhiHD", true);
				return _tenChiPhiHD;
			}
			set
			{
				CanWriteProperty("TenChiPhiHD", true);
				if (value == null) value = string.Empty;
				if (!_tenChiPhiHD.Equals(value))
				{
					_tenChiPhiHD = value;
					PropertyHasChanged("TenChiPhiHD");
				}
			}
		}
        public string TenHoatDong
        {
            get
            {
                CanReadProperty(true);
                return _tenhoatdong;
            }
           
        }

        public decimal HoatDongSuNghiepCoThu
        {
            get
            {
                CanReadProperty(true);
                return _hoatDongSuNghiepCoThu;
            }
        }

        public decimal BoSungKinhPhiSuNghiep
        {
            get
            {
                CanReadProperty(true);
                return _boSungKinhPhiSuNghiep;
            }
        }

        public decimal PhatTrienSuNghiep
        {
            get
            {
                CanReadProperty(true);
                return _phatTrienSuNghiep;
            }
        }
        public decimal ThuNhapTangThem
        {
            get
            {
                CanReadProperty(true);
                return _thuNhapTangThem;
            }
        }

        public decimal KinhPhiKhac
        {
            get
            {
                CanReadProperty(true);
                return _kinhPhiKhac;
            }
        }
 
 // nam truoc

        public decimal HoatDongSuNghiepCoThuNamTruoc
        {
            get
            {
                CanReadProperty(true);
                return _hoatDongSuNghiepCoThuNamTruoc;
            }
        }

        public decimal BoSungKinhPhiSuNghiepNamTruoc
        {
            get
            {
                CanReadProperty(true);
                return _boSungKinhPhiSuNghiepNamTruoc;
            }
        }

        public decimal PhatTrienSuNghiepNamTruoc
        {
            get
            {
                CanReadProperty(true);
                return _phatTrienSuNghiepNamTruoc;
            }
        }
        public decimal ThuNhapTangThemNamTruoc
        {
            get
            {
                CanReadProperty(true);
                return _thuNhapTangThemNamTruoc;
            }
        }

        public decimal KinhPhiKhacNamTruoc
        {
            get
            {
                CanReadProperty(true);
                return _kinhPhiKhacNamTruoc;
            }
        }




        public decimal CLChiPhiHDDV
        {
            get
            {
                CanReadProperty(true);
                return _clChiPhiHDDV;
            }
        }

        public decimal TyLePhanTramHDDV
        {
            get
            {
                CanReadProperty(true);
                return _tyLePhanTramHDDV;
            }
        }

        public decimal CLThuNhapTangThem
        {
            get
            {
                CanReadProperty(true);
                return _clThuNhapTangThem;
            }
        }
        public decimal TyLePhanTramTNTT
        {
            get
            {
                CanReadProperty(true);
                return _tyLePhanTramTNTT;
            }
        }

		protected override object GetIdValue()
		{
			return string.Format("{0}:{1}", _maNguon, _maNguoiLap);
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
			// Muc
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
			return true;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BaoCao_CTKPHD_DNQT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCao_CTKPHD_DNQTAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BaoCao_CTKPHD_DNQT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCao_CTKPHD_DNQTEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BaoCao_CTKPHD_DNQT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCao_CTKPHD_DNQTDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BaoCao_CTKPHD_DNQT()
		{ /* require use of factory method */ }

		public static BaoCao_CTKPHD_DNQT NewBaoCao_CTKPHD_DNQT(int maNguon, long maNguoiLap)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCao_CTKPHD_DNQT");
			return DataPortal.Create<BaoCao_CTKPHD_DNQT>(new Criteria(maNguon, maNguoiLap));
		}

		public static BaoCao_CTKPHD_DNQT GetBaoCao_CTKPHD_DNQT(int maNguon, long maNguoiLap)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BaoCao_CTKPHD_DNQT");
			return DataPortal.Fetch<BaoCao_CTKPHD_DNQT>(new Criteria(maNguon, maNguoiLap));
		}

		public static void DeleteBaoCao_CTKPHD_DNQT(int maNguon, long maNguoiLap)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BaoCao_CTKPHD_DNQT");
			DataPortal.Delete(new Criteria(maNguon, maNguoiLap));
		}

		public override BaoCao_CTKPHD_DNQT Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BaoCao_CTKPHD_DNQT");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCao_CTKPHD_DNQT");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BaoCao_CTKPHD_DNQT");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
       
		internal static BaoCao_CTKPHD_DNQT NewBaoCao_CTKPHD_DNQTChild()
		{
            BaoCao_CTKPHD_DNQT child = new BaoCao_CTKPHD_DNQT();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BaoCao_CTKPHD_DNQT GetBaoCao_CTKPHD_DNQT(SafeDataReader dr)
		{
			BaoCao_CTKPHD_DNQT child =  new BaoCao_CTKPHD_DNQT();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static BaoCao_CTKPHD_DNQT GetBaoCao_CTKPHD_DNQTSoSanh(SafeDataReader dr)
        {
            BaoCao_CTKPHD_DNQT child = new BaoCao_CTKPHD_DNQT();
            child._sTT = dr.GetInt32("Row");
            child._maMucNganSach = dr.GetInt32("MaMucNganSach");
            child._muc = dr.GetString("MaMucQL");
            child._tenMucNganSach = dr.GetString("TenMucNganSach");
            child._tieuMuc = dr.GetString("TieuMuc");
            child._tenTieuMuc = dr.GetString("TenTieuMuc");
            child._sotienKyNay = dr.GetDecimal("TienPS");
            child._tenhoatdong = dr.GetString("TenHoatDong");
            child._hoatDongSuNghiepCoThu = dr.GetDecimal("HoatDongSuNghiepCoThu");
            child._boSungKinhPhiSuNghiep = dr.GetDecimal("BoSungKinhPhiSuNghiep");
            child._phatTrienSuNghiep = dr.GetDecimal("PhatTrienSuNghiep");
            child._thuNhapTangThem = dr.GetDecimal("ThuNhapTangThem");
            child._kinhPhiKhac = dr.GetDecimal("KinhPhiKhac");     

            child._hoatDongSuNghiepCoThuNamTruoc = dr.GetDecimal("HoatDongSuNghiepCoThuNamTruoc");
            child._boSungKinhPhiSuNghiepNamTruoc = dr.GetDecimal("BoSungKinhPhiSuNghiepNamTruoc");
            child._phatTrienSuNghiepNamTruoc = dr.GetDecimal("PhatTrienSuNghiepNamTruoc");
            child._thuNhapTangThemNamTruoc = dr.GetDecimal("ThuNhapTangThemNamTruoc");
            child._kinhPhiKhacNamTruoc = dr.GetDecimal("KinhPhiKhacNamTruoc");

            child._clChiPhiHDDV = dr.GetDecimal("CLChiPhiHDDV");
            child._tyLePhanTramHDDV = dr.GetDecimal("TyLePhanTramHDDV");
            child._clThuNhapTangThem = dr.GetDecimal("CLThuNhapTangThem");
            child._tyLePhanTramTNTT = dr.GetDecimal("TyLePhanTramTNTT");

            return child;
        }


		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaNguon;
			public long MaNguoiLap;

			public Criteria(int maNguon, long maNguoiLap)
			{
				this.MaNguon = maNguon;
				this.MaNguoiLap = maNguoiLap;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maNguon = criteria.MaNguon;
			_maNguoiLap = criteria.MaNguoiLap;
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
				cm.CommandText = "spd_BaoCaoChiTietKinhPhiHD_DeNghiQT";

				cm.Parameters.AddWithValue("@MaNguon", criteria.MaNguon);
				cm.Parameters.AddWithValue("@MaNguoiLap", criteria.MaNguoiLap);

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
			DataPortal_Delete(new Criteria(_maNguon, _maNguoiLap));
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
				cm.CommandText = "DeleteBaoCao_CTKPHD_DNQT";

				cm.Parameters.AddWithValue("@MaNguon", criteria.MaNguon);
				cm.Parameters.AddWithValue("@MaNguoiLap", criteria.MaNguoiLap);

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
            _sTT = dr.GetInt32("Row");
            _maMucNganSach = dr.GetInt32("MaMucNganSach");
            _muc = dr.GetString("MaMucQL");
            _tenMucNganSach = dr.GetString("TenMucNganSach");
            _tieuMuc = dr.GetString("TieuMuc");
            _tenTieuMuc = dr.GetString("TenTieuMuc");
            _sotienKyNay = dr.GetDecimal("TienPS");
            _tenNguon = dr.GetString("TenNguon");
            _maNguon = dr.GetInt32("MaNguon");
            _tenhoatdong = dr.GetString("TenHoatDong");
            _hoatDongSuNghiepCoThu = dr.GetDecimal("HoatDongSuNghiepCoThu");
            _boSungKinhPhiSuNghiep = dr.GetDecimal("BoSungKinhPhiSuNghiep");
            _phatTrienSuNghiep = dr.GetDecimal("PhatTrienSuNghiep");
            _thuNhapTangThem = dr.GetDecimal("ThuNhapTangThem");
            _kinhPhiKhac = dr.GetDecimal("KinhPhiKhac");
            _tenChiPhiHD = dr.GetString("TenTaiKhoan");
            _soTienLuyKe = dr.GetDecimal("SoTienLuyKe");
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
				cm.CommandText = "AddBaoCao_CTKPHD_DNQT";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMucNganSach", _maMucNganSach);
			cm.Parameters.AddWithValue("@Muc", _muc);
			cm.Parameters.AddWithValue("@TenMucNganSach", _tenMucNganSach);
			if (_tieuMuc.Length > 0)
				cm.Parameters.AddWithValue("@TieuMuc", _tieuMuc);
			else
				cm.Parameters.AddWithValue("@TieuMuc", DBNull.Value);
			if (_tenTieuMuc.Length > 0)
				cm.Parameters.AddWithValue("@TenTieuMuc", _tenTieuMuc);
			else
				cm.Parameters.AddWithValue("@TenTieuMuc", DBNull.Value);
			if (_sotienKyNay != 0)
				cm.Parameters.AddWithValue("@SotienKyNay", _sotienKyNay);
			else
				cm.Parameters.AddWithValue("@SotienKyNay", DBNull.Value);
			if (_soTienLuyKe != 0)
				cm.Parameters.AddWithValue("@SoTienLuyKe", _soTienLuyKe);
			else
				cm.Parameters.AddWithValue("@SoTienLuyKe", DBNull.Value);
			cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
			cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@TenChiPhiHD", _tenChiPhiHD);
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
				cm.CommandText = "UpdateBaoCao_CTKPHD_DNQT";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMucNganSach", _maMucNganSach);
			cm.Parameters.AddWithValue("@Muc", _muc);
			cm.Parameters.AddWithValue("@TenMucNganSach", _tenMucNganSach);
			if (_tieuMuc.Length > 0)
				cm.Parameters.AddWithValue("@TieuMuc", _tieuMuc);
			else
				cm.Parameters.AddWithValue("@TieuMuc", DBNull.Value);
			if (_tenTieuMuc.Length > 0)
				cm.Parameters.AddWithValue("@TenTieuMuc", _tenTieuMuc);
			else
				cm.Parameters.AddWithValue("@TenTieuMuc", DBNull.Value);
			if (_sotienKyNay != 0)
				cm.Parameters.AddWithValue("@SotienKyNay", _sotienKyNay);
			else
				cm.Parameters.AddWithValue("@SotienKyNay", DBNull.Value);
			if (_soTienLuyKe != 0)
				cm.Parameters.AddWithValue("@SoTienLuyKe", _soTienLuyKe);
			else
				cm.Parameters.AddWithValue("@SoTienLuyKe", DBNull.Value);
			cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
			cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@TenChiPhiHD", _tenChiPhiHD);
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

			ExecuteDelete(tr, new Criteria(_maNguon, _maNguoiLap));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
