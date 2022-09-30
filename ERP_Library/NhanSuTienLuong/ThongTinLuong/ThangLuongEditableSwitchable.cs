using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThangLuong : Csla.BusinessBase<ThangLuong>
	{
		#region Business Properties and Methods

        
        //declare members
		private int _maThangLuong = 0;
		private int _maChucVu = 0;
        private string _tenchucvu = string.Empty;
		private int _maCongViec = 0;
        private string _tencongviec = string.Empty;
		private int _maKy = 0;
        private string _kyluong = string.Empty;
		private decimal _luong = 0;
		private string _ghiChu = string.Empty;
        private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private string _tennguoilap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private bool _khoaSo = false;
		public int MaThangLuong
		{
			get
			{
				CanReadProperty("MaThangLuong", true);
				return _maThangLuong;
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

		public decimal Luong
		{
			get
			{
				CanReadProperty("Luong", true);
				return _luong;
			}
			set
			{
				CanWriteProperty("Luong", true);
				if (!_luong.Equals(value))
				{
					_luong = value;
					PropertyHasChanged("Luong");
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

        public string Tennguoilap
        {
            get
            {
                CanReadProperty( true);
                return _tennguoilap;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_tennguoilap.Equals(value))
                {
                    _tennguoilap = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Tenchucvu
        {
            get
            {
                CanReadProperty(true);
                return _tenchucvu;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_tenchucvu.Equals(value))
                {
                    _tenchucvu = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Tencongviec
        {
            get
            {
                CanReadProperty(true);
                return _tencongviec;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_tencongviec.Equals(value))
                {
                    _tencongviec = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Kyluong
        {
            get
            {
                CanReadProperty(true);
                return _kyluong;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_kyluong.Equals(value))
                {
                    _kyluong = value;
                    PropertyHasChanged();
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
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
		}
        public Boolean KhoaSo
        {
            get
            {
                CanReadProperty("KhoaSo", true);
                return _khoaSo;
            }
            set
            {
                CanWriteProperty("KhoaSo", true);
                if (!_khoaSo.Equals(value))
                {
                    _khoaSo = value;
                    PropertyHasChanged("KhoaSo");
                }
            }
        }
    
        
		protected override object GetIdValue()
		{
			return string.Format("{0}:{1}:{2}", _maChucVu, _maCongViec, _maKy);
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
			//TODO: Define authorization rules in ThangLuong
			//AuthorizationRules.AllowRead("MaThangLuong", "ThangLuongReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "ThangLuongReadGroup");
			//AuthorizationRules.AllowRead("MaCongViec", "ThangLuongReadGroup");
			//AuthorizationRules.AllowRead("MaKy", "ThangLuongReadGroup");
			//AuthorizationRules.AllowRead("Luong", "ThangLuongReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "ThangLuongReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "ThangLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "ThangLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "ThangLuongReadGroup");

			//AuthorizationRules.AllowWrite("Luong", "ThangLuongWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "ThangLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "ThangLuongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "ThangLuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThangLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThangLuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThangLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThangLuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThangLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThangLuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThangLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThangLuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThangLuong()
		{ /* require use of factory method */ }

		public static ThangLuong NewThangLuong(int maChucVu, int maCongViec, int maKy)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThangLuong");
			return DataPortal.Create<ThangLuong>(new Criteria(maChucVu, maCongViec, maKy));
		}

        public static ThangLuong NewThangLuong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThangLuong");
            return DataPortal.Create<ThangLuong>(new Criteria());
        }

		public static ThangLuong GetThangLuong(int maChucVu, int maCongViec)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThangLuong");
			return DataPortal.Fetch<ThangLuong>(new Criteria_CuoiCung(maChucVu, maCongViec));
		}
        public static ThangLuong GetThangLuong(int maChucVu, int maCongViec,int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThangLuong");
            return DataPortal.Fetch<ThangLuong>(new Criteria(maChucVu, maCongViec,maKy));
        }
		public static void DeleteThangLuong(int maChucVu, int maCongViec, int maKy)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThangLuong");
			DataPortal.Delete(new Criteria(maChucVu, maCongViec, maKy));
		}

		public override ThangLuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThangLuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThangLuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThangLuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ThangLuong(int maChucVu, int maCongViec, int maKy)
		{
			this._maChucVu = maChucVu;
			this._maCongViec = maCongViec;
			this._maKy = maKy;
		}

		internal static ThangLuong NewThangLuongChild(int maChucVu, int maCongViec, int maKy)
		{
			ThangLuong child = new ThangLuong(maChucVu, maCongViec, maKy);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThangLuong GetThangLuong(SafeDataReader dr)
		{
			ThangLuong child =  new ThangLuong();
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
            public int MaKy;

			public Criteria(int maChucVu, int maCongViec, int MaKy)
			{
				this.MaChucVu = maChucVu;
				this.MaCongViec = maCongViec;
                this.MaKy = MaKy;
			}
            public Criteria()
            { 
            }
		}

        private class Criteria_CuoiCung
        {
            public int MaChucVu;
            public int MaCongViec;

            public Criteria_CuoiCung(int maChucVu, int maCongViec)
            {
                this.MaChucVu = maChucVu;
                this.MaCongViec = maCongViec;
            }
        }
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChucVu = criteria.MaChucVu;
			_maCongViec = criteria.MaCongViec;
			_maKy = criteria.MaKy;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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
                if (criteria is Criteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsThangLuong";

                    cm.Parameters.AddWithValue("@MaChucVu", ((Criteria)criteria).MaChucVu);
                    cm.Parameters.AddWithValue("@MaCongViec", ((Criteria)criteria).MaCongViec);
                    cm.Parameters.AddWithValue("@MaKy", ((Criteria)criteria).MaKy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren(dr);
                        }
                    }
                }
                else if (criteria is Criteria_CuoiCung)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsThangLuong_CuoiCung";

                    cm.Parameters.AddWithValue("@MaChucVu", ((Criteria_CuoiCung)criteria).MaChucVu);
                    cm.Parameters.AddWithValue("@MaCongViec", ((Criteria_CuoiCung)criteria).MaCongViec);

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
			DataPortal_Delete(new Criteria(_maChucVu, _maCongViec, _maKy));
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
				cm.CommandText = "spd_DeletetblnsThangLuong";

                cm.Parameters.AddWithValue("@MaChucVu", criteria.MaChucVu);
                cm.Parameters.AddWithValue("@MaCongViec", criteria.MaCongViec);
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
			_maThangLuong = dr.GetInt32("MaThangLuong");
			_maChucVu = dr.GetInt32("MaChucVu");
            _tenchucvu = ChucVu.GetChucVu(_maChucVu).TenChucVu;
			_maCongViec = dr.GetInt32("MaCongViec");
            _tencongviec = CongViec.GetCongViec(_maCongViec).TenCongViec;
			_maKy = dr.GetInt32("MaKy");
            _kyluong = KyTinhLuong.GetKyTinhLuong(_maKy).TenKy;
			_luong = dr.GetDecimal("Luong");
			_ghiChu = dr.GetString("GhiChu");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
            _tennguoilap = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNguoiLap).TenNhanVien;
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _khoaSo = dr.GetBoolean("KhoaSo");
         }

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, ThangLuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, ThangLuongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblnsThangLuong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maThangLuong = (int)cm.Parameters["@MaThangLuong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ThangLuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_luong != 0)
				cm.Parameters.AddWithValue("@Luong", _luong);
			else
				cm.Parameters.AddWithValue("@Luong", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaThangLuong", _maThangLuong);
            cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
			cm.Parameters["@MaThangLuong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, ThangLuongList parent)
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

		private void ExecuteUpdate(SqlConnection cn, ThangLuongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_UpdatetblnsThangLuong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ThangLuongList parent)
		{
			cm.Parameters.AddWithValue("@MaThangLuong", _maThangLuong);
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_luong != 0)
				cm.Parameters.AddWithValue("@Luong", _luong);
			else
				cm.Parameters.AddWithValue("@Luong", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
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

			ExecuteDelete(cn, new Criteria(_maChucVu, _maCongViec, _maKy));
			MarkNew();
		}
		#endregion //Data Access - Delete

        public static void CapNhatDS(int maky)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand command = cn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Spd_SelecttblnsThangluongintoNhanvien";
                    command.Parameters.AddWithValue("@maky", maky   );
                    command.ExecuteNonQuery();
                }
            }
        }

		#endregion //Data Access
	}
}
