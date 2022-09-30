
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThueTamThu : Csla.BusinessBase<ThueTamThu>
	{
		#region Business Properties and Methods

		//declare members
		private long _maThueTamThu = 0;
		private int _maBoPhan = 0;
		private int _maKyTinhLuong = 0;
		private long _maNhanVien = 0;
		private decimal _TongThuNhap = 0;
		private decimal _giamTru = 0;
		private decimal _thueTNCN = 0;
		private decimal _thueDaThu = 0;
		private decimal _thuePhaiThu = 0;
		private long _maChungTuDeNghi = 0;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private int _nguoiLap = 0;
        private string _tenNhanVien = "";
        private string _tenBoPhan = "";
        private decimal _TamThuKhac = 0;
        private decimal _TongThu = 0;
        private string _DienGiai = "";
        private bool _DaThu = false;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaThueTamThu
		{
			get
			{
				CanReadProperty("MaThueTamThu", true);
				return _maThueTamThu;
			}
		}
        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }
        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
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

		public int MaKyTinhLuong
		{
			get
			{
				CanReadProperty("MaKyTinhLuong", true);
				return _maKyTinhLuong;
			}
			set
			{
				CanWriteProperty("MaKyTinhLuong", true);
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
					PropertyHasChanged("MaKyTinhLuong");
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

		public decimal TongThuNhap
		{
			get
			{
				CanReadProperty("TongThuNhap", true);
				return _TongThuNhap;
			}
			set
			{
				CanWriteProperty("TongThuNhap", true);
				if (!_TongThuNhap.Equals(value))
				{
					_TongThuNhap = value;
					PropertyHasChanged("TongThuNhap");
				}
			}
		}

		public decimal GiamTru
		{
			get
			{
				CanReadProperty("GiamTru", true);
				return _giamTru;
			}
			set
			{
				CanWriteProperty("GiamTru", true);
				if (!_giamTru.Equals(value))
				{
					_giamTru = value;
					PropertyHasChanged("GiamTru");
				}
			}
		}

		public decimal ThueTNCN
		{
			get
			{
				CanReadProperty("ThueTNCN", true);
				return _thueTNCN;
			}
			set
			{
				CanWriteProperty("ThueTNCN", true);
				if (!_thueTNCN.Equals(value))
				{
					_thueTNCN = value;
					PropertyHasChanged("ThueTNCN");
				}
			}
		}

		public decimal thueDaThu
		{
			get
			{
				CanReadProperty("ThueDaThu", true);
				return _thueDaThu;
			}
			set
			{
				CanWriteProperty("ThueDaThu", true);
				if (!_thueDaThu.Equals(value))
				{
					_thueDaThu = value;
					PropertyHasChanged("ThueDaThu");
				}
			}
		}

		public decimal ThuePhaiThu
		{
			get
			{
				CanReadProperty("ThuePhaiThu", true);
				return _thuePhaiThu;
			}
			set
			{
				CanWriteProperty("ThuePhaiThu", true);
				if (!_thuePhaiThu.Equals(value))
				{
					_thuePhaiThu = value;
					PropertyHasChanged("ThuePhaiThu");
                    TongThu = ThuePhaiThu + TamThuKhac;
				}
			}
		}

		public long MaChungTuDeNghi
		{
			get
			{
				CanReadProperty("MaChungTuDeNghi", true);
				return _maChungTuDeNghi;
			}
			set
			{
				CanWriteProperty("MaChungTuDeNghi", true);
				if (!_maChungTuDeNghi.Equals(value))
				{
					_maChungTuDeNghi = value;
					PropertyHasChanged("MaChungTuDeNghi");
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
		}

		public string NgayLapString
		{
			get
			{
				CanReadProperty("NgayLapString", true);
				return _ngayLap.Text;
			}
			set
			{
				CanWriteProperty("NgayLapString", true);
				if (value == null) value = string.Empty;
				if (!_ngayLap.Equals(value))
				{
					_ngayLap.Text = value;
					PropertyHasChanged("NgayLapString");
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

        public decimal TamThuKhac
        {
            get
            {
                return _TamThuKhac;
            }
            set
            {
                _TamThuKhac = value;
                PropertyHasChanged();
                TongThu = ThuePhaiThu + TamThuKhac;
            }
        }

        public decimal TongThu
        {
            get
            {
                return _TongThu;
            }
            set
            {
                _TongThu = value;
                PropertyHasChanged();
            }
        }

        public string DienGiai
        {
            get
            {
                return _DienGiai;
            }
            set
            {
                _DienGiai = value;
                PropertyHasChanged();
            }
        }

        public bool DaThu
        {
            get
            {
                return _DaThu;
            }
            set
            {
                _DaThu = value;
                PropertyHasChanged();
            }
        }
 
		protected override object GetIdValue()
		{
			return _maThueTamThu;
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
			//TODO: Define authorization rules in ThueTamThu
			//AuthorizationRules.AllowRead("MaThueTamThu", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("TongThuNhap", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("GiamTru", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("ThueTNCN", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("ThueTamThu", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("ThuePhaiThu", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("MaChungTuDeNghi", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "ThueTamThuReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "ThueTamThuReadGroup");

			//AuthorizationRules.AllowWrite("MaBoPhan", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("TongThuNhap", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("GiamTru", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("ThueTNCN", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("ThueTamThu", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("ThuePhaiThu", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("MaChungTuDeNghi", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "ThueTamThuWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "ThueTamThuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThueTamThu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTamThuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThueTamThu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTamThuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThueTamThu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTamThuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThueTamThu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTamThuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThueTamThu()
		{ /* require use of factory method */ }

		public static ThueTamThu NewThueTamThu()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThueTamThu");
			return DataPortal.Create<ThueTamThu>();
		}

		public static ThueTamThu GetThueTamThu(long maThueTamThu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThueTamThu");
			return DataPortal.Fetch<ThueTamThu>(new Criteria(maThueTamThu));
		}

		public static void DeleteThueTamThu(long maThueTamThu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThueTamThu");
			DataPortal.Delete(new Criteria(maThueTamThu));
		}

		public override ThueTamThu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThueTamThu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThueTamThu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThueTamThu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ThueTamThu NewThueTamThuChild()
		{
			ThueTamThu child = new ThueTamThu();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThueTamThu GetThueTamThu(SafeDataReader dr)
		{
			ThueTamThu child =  new ThueTamThu();
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
			public long MaThueTamThu;

			public Criteria(long maThueTamThu)
			{
				this.MaThueTamThu = maThueTamThu;
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
				cm.CommandText = "GetThueTamThu";

				cm.Parameters.AddWithValue("@MaThueTamThu", criteria.MaThueTamThu);

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
			DataPortal_Delete(new Criteria(_maThueTamThu));
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
				cm.CommandText = "spd_Delete_ThueTamThu";

				cm.Parameters.AddWithValue("@MaThueTamThu", criteria.MaThueTamThu);

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
			_maThueTamThu = dr.GetInt64("MaThueTamThu");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_TongThuNhap = dr.GetDecimal("TongThuNhap");
			_giamTru = dr.GetDecimal("GiamTru");
			_thueTNCN = dr.GetDecimal("ThueTNCN");
			_thueDaThu = dr.GetDecimal("ThueTamThu");
			_thuePhaiThu = dr.GetDecimal("ThuePhaiThu");
			_maChungTuDeNghi = dr.GetInt64("MaChungTuDeNghi");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_nguoiLap = dr.GetInt32("NguoiLap");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _TamThuKhac = dr.GetDecimal("TamThuKhac");
            _TongThu = dr.GetDecimal("TongThu");
            _DienGiai = dr.GetString("DienGiai");
            _DaThu = dr.GetBoolean("DaThu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, ThueTamThuList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, ThueTamThuList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddThueTamThu";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maThueTamThu = (long)cm.Parameters["@NewMaThueTamThu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ThueTamThuList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_TongThuNhap != 0)
				cm.Parameters.AddWithValue("@TongThuNhap", _TongThuNhap);
			else
				cm.Parameters.AddWithValue("@TongThuNhap", DBNull.Value);
			if (_giamTru != 0)
				cm.Parameters.AddWithValue("@GiamTru", _giamTru);
			else
				cm.Parameters.AddWithValue("@GiamTru", DBNull.Value);
			if (_thueTNCN != 0)
				cm.Parameters.AddWithValue("@ThueTNCN", _thueTNCN);
			else
				cm.Parameters.AddWithValue("@ThueTNCN", DBNull.Value);
			if (_thueDaThu != 0)
				cm.Parameters.AddWithValue("@ThueTamThu", _thueDaThu);
			else
				cm.Parameters.AddWithValue("@ThueTamThu", DBNull.Value);
			if (_thuePhaiThu != 0)
				cm.Parameters.AddWithValue("@ThuePhaiThu", _thuePhaiThu);
			else
				cm.Parameters.AddWithValue("@ThuePhaiThu", DBNull.Value);
			if (_maChungTuDeNghi != 0)
				cm.Parameters.AddWithValue("@MaChungTuDeNghi", _maChungTuDeNghi);
			else
				cm.Parameters.AddWithValue("@MaChungTuDeNghi", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			cm.Parameters.AddWithValue("@NewMaThueTamThu", _maThueTamThu);
			cm.Parameters["@NewMaThueTamThu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, ThueTamThuList parent)
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

		private void ExecuteUpdate(SqlConnection cn, ThueTamThuList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_Update_ThueTamThu";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ThueTamThuList parent)
		{
			cm.Parameters.AddWithValue("@MaThueTamThu", _maThueTamThu);
            cm.Parameters.AddWithValue("@ThuePhaiThu", _thuePhaiThu);
            cm.Parameters.AddWithValue("@TamThuKhac", _TamThuKhac);
            cm.Parameters.AddWithValue("@TongThu", _TongThu);
            cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
            cm.Parameters.AddWithValue("@DaThu", _DaThu);
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

			ExecuteDelete(cn, new Criteria(_maThueTamThu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
