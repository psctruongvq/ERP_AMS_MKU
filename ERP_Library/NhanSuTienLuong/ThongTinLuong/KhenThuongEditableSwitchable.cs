
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhenThuong : Csla.BusinessBase<KhenThuong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKhenThuong = 0;
		private int _maChucVu = 0;
		private int _maCongViec = 0;
		private int _maMucDo = 0;
		private int _maKy = 0;
		private decimal _soTienThuong = 0;
		private string _ghiChu = string.Empty;

        //_maNguoiLap=Mã của nhân viên đăng nhập vào chương trình
		private long _maNguoiLap = 96;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);


        private string _tenChucVu = "";
        private string _tenCongViec = "";
        private string _tenMucDo = "";
        private string _tenKy = "";

		public int MaKhenThuong
		{
			get
			{
				CanReadProperty("MaKhenThuong", true);
				return _maKhenThuong;
			}

		}

		[System.ComponentModel.DataObjectField(true, false)]
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

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaCongViec
		{
			get
			{
				CanReadProperty("MaCongViec", true);
				return _maCongViec;
			}
            set
            {
                CanWriteProperty("MaCongViec", true);
                if (!_maCongViec.Equals(value))
                {
                    _maCongViec = value;
                    PropertyHasChanged("MaCongViec");
                }
            }
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaMucDo
		{
			get
			{
				CanReadProperty("MaMucDo", true);
				return _maMucDo;
			}
            set
            {
                CanWriteProperty("MaMucDo", true);
                if (!_maMucDo.Equals(value))
                {
                    _maMucDo = value;
                    PropertyHasChanged("MaMucDo");
                }
            }
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaKy
		{
			get
			{
				CanReadProperty("MaKy", true);
				return _maKy;
			}
            set
            {
                CanWriteProperty("MaKy", true);
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKy");
                }
            }
		}

		public decimal SoTienThuong
		{
			get
			{
				CanReadProperty("SoTienThuong", true);
				return _soTienThuong;
			}
			set
			{
				CanWriteProperty("SoTienThuong", true);
				if (!_soTienThuong.Equals(value))
				{
					_soTienThuong = value;
					PropertyHasChanged("SoTienThuong");
				}
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
                    _ngayLap.Date =new SmartDate(value).Date;
                    PropertyHasChanged("NgayLap");
                }
            }
		}		

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                _tenChucVu = ChucVu.GetChucVu(_maChucVu).TenChucVu;
                return _tenChucVu;
            }
        }
        public string TenCongViec
        {
            get
            {
                CanReadProperty("TenCongViec", true);
                _tenCongViec = CongViec.GetCongViec(_maCongViec).TenCongViec;
                return _tenCongViec;
            }
        }
        public string TenMucDo
        {
            get
            {
                CanReadProperty("TenMucDo", true);
                _tenMucDo = MucDoHTCongViec.GetMucDoHTCongViec(_maMucDo).TenMucDo;
                return _tenMucDo;
            }
        }
        public string TenKy
        {
            get
            {
                CanReadProperty("TenKy", true);
                _tenKy = KyTinhLuong.GetKyTinhLuong(_maKy).TenKy;
                return _tenKy;
            }
        }
		protected override object GetIdValue()
		{
			return string.Format("{0}:{1}:{2}:{3}", _maChucVu, _maCongViec, _maMucDo, _maKy);
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 2000));
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
			//TODO: Define authorization rules in KhenThuong
			//AuthorizationRules.AllowRead("MaKhenThuong", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("MaCongViec", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("MaMucDo", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("MaKy", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("SoTienThuong", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "KhenThuongReadGroup");
			//AuthorizationRules.AllowRead("KhoaSo", "KhenThuongReadGroup");

			//AuthorizationRules.AllowWrite("SoTienThuong", "KhenThuongWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "KhenThuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "KhenThuongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "KhenThuongWriteGroup");
			//AuthorizationRules.AllowWrite("KhoaSo", "KhenThuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KhenThuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KhenThuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KhenThuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KhenThuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KhenThuong()
		{ /* require use of factory method */ }

		public static KhenThuong NewKhenThuong(int maChucVu, int maCongViec, int maMucDo, int maKy)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhenThuong");
			return DataPortal.Create<KhenThuong>(new Criteria(maChucVu, maCongViec, maMucDo, maKy));
		}
        public static KhenThuong NewKhenThuong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhenThuong");
            return DataPortal.Create<KhenThuong>(new Criteria());
        }

		public static KhenThuong GetKhenThuong(int maChucVu, int maCongViec, int maMucDo, int maKy)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KhenThuong");
			return DataPortal.Fetch<KhenThuong>(new Criteria(maChucVu, maCongViec, maMucDo, maKy));
		}

		public static void DeleteKhenThuong(int maChucVu, int maCongViec, int maMucDo, int maKy)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KhenThuong");
			DataPortal.Delete(new Criteria(maChucVu, maCongViec, maMucDo, maKy));
		}

		public override KhenThuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KhenThuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhenThuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KhenThuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private KhenThuong(int maChucVu,int maCongViec,int maMucDo,int maKy)
		{
			this._maChucVu = maChucVu;
			this._maCongViec = maCongViec;
			this._maMucDo = maMucDo;
			this._maKy = maKy;
		}

		internal static KhenThuong NewKhenThuongChild(int maChucVu, int maCongViec, int maMucDo, int maKy)
		{
			KhenThuong child = new KhenThuong(maChucVu, maCongViec, maMucDo, maKy);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KhenThuong GetKhenThuong(SafeDataReader dr)
		{
			KhenThuong child =  new KhenThuong();
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
			public int MaChucVu;
			public int MaCongViec;
			public int MaMucDo;
			public int MaKy;

			public Criteria(int maChucVu, int maCongViec, int maMucDo, int maKy)
			{
				this.MaChucVu = maChucVu;
				this.MaCongViec = maCongViec;
				this.MaMucDo = maMucDo;
				this.MaKy = maKy;
			}
            public Criteria()
            {
                this.MaChucVu = 0;
                this.MaCongViec = 0;
                this.MaMucDo = 0;
                this.MaKy = 0;
            }
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChucVu = criteria.MaChucVu;
			_maCongViec = criteria.MaCongViec;
			_maMucDo = criteria.MaMucDo;
			_maKy = criteria.MaKy;
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
				cm.CommandText = "spd_SelecttblnsKhenThuong";

				cm.Parameters.AddWithValue("@MaChucVu", criteria.MaChucVu);
				cm.Parameters.AddWithValue("@MaCongViec", criteria.MaCongViec);
				cm.Parameters.AddWithValue("@MaMucDo", criteria.MaMucDo);
				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
			DataPortal_Delete(new Criteria(_maChucVu, _maCongViec, _maMucDo, _maKy));
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
				cm.CommandText = "spd_DeletetblnsKhenThuong";

				cm.Parameters.AddWithValue("@MaChucVu", criteria.MaChucVu);
				cm.Parameters.AddWithValue("@MaCongViec", criteria.MaCongViec);
				cm.Parameters.AddWithValue("@MaMucDo", criteria.MaMucDo);
				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
			_maKhenThuong = dr.GetInt32("MaKhenThuong");
			_maChucVu = dr.GetInt32("MaChucVu");
			_maCongViec = dr.GetInt32("MaCongViec");
			_maMucDo = dr.GetInt32("MaMucDo");
			_maKy = dr.GetInt32("MaKytinhluong");
			_soTienThuong = dr.GetDecimal("SoTienThuong");
			_ghiChu = dr.GetString("GhiChu");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _tenChucVu = dr.GetString("TenChucVu");
            _tenCongViec = dr.GetString("TenCongViec");
            _tenKy = dr.GetString("TenKy");
            _tenMucDo = dr.GetString("TenMucDo");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, KhenThuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, KhenThuongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblnsKhenThuong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maKhenThuong = (int)cm.Parameters["@MaKhenThuong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, KhenThuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			cm.Parameters.AddWithValue("@MaMucDo", _maMucDo);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_soTienThuong != 0)
				cm.Parameters.AddWithValue("@SoTienThuong", _soTienThuong);
			else
				cm.Parameters.AddWithValue("@SoTienThuong", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaKhenThuong", _maKhenThuong);
			cm.Parameters["@MaKhenThuong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, KhenThuongList parent)
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

		private void ExecuteUpdate(SqlConnection cn, KhenThuongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_UpdatetblnsKhenThuong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, KhenThuongList parent)
		{
			cm.Parameters.AddWithValue("@MaKhenThuong", _maKhenThuong);
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			cm.Parameters.AddWithValue("@MaMucDo", _maMucDo);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_soTienThuong != 0)
				cm.Parameters.AddWithValue("@SoTienThuong", _soTienThuong);
			else
				cm.Parameters.AddWithValue("@SoTienThuong", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			
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

			ExecuteDelete(cn, new Criteria(_maChucVu, _maCongViec, _maMucDo, _maKy));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
