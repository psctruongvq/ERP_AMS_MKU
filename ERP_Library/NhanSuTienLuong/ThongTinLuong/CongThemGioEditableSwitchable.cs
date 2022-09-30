
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongThemGio : Csla.BusinessBase<CongThemGio>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCongThemGio = 0;
		private long _maNhanVien = 0;
		private SmartDate _ngayChamCong = new SmartDate(false);
		private double _soGio = 0;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private string _ghiChu = string.Empty;
		private int _maCacLoaiCong = 0;
        private string _tenCacLoaiCong = string.Empty;
        private long _maNguoiLap = 96;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaCongThemGio
		{
			get
			{
				CanReadProperty("MaCongThemGio", true);
				return _maCongThemGio;
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

		public DateTime NgayChamCong
		{
			get
			{
				CanReadProperty("NgayChamCong", true);
				return _ngayChamCong.Date;
			}
            set
            {
                CanWriteProperty("NgayChamCong", true);
                if (!_ngayChamCong.Equals(value))
                {
                    _ngayChamCong = new SmartDate(value);
                    PropertyHasChanged("NgayChamCong");
                }
            }
		}

		public double SoGio
		{
			get
			{
				CanReadProperty("SoGio", true);
				return _soGio;
			}
			set
			{
				CanWriteProperty("SoGio", true);
				if (!_soGio.Equals(value))
				{
					_soGio = value;
					PropertyHasChanged("SoGio");
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

		public int MaCacLoaiCong
		{
			get
			{
				CanReadProperty("MaCacLoaiCong", true);
				return _maCacLoaiCong;
			}
			set
			{
				CanWriteProperty("MaCacLoaiCong", true);
				if (!_maCacLoaiCong.Equals(value))
				{
					_maCacLoaiCong = value;
					PropertyHasChanged("MaCacLoaiCong");
				}
			}
		}

        public string TenCacLoaiCong
        {
            get
            {
                CanReadProperty("TenCacLoaiCong", true);
                _tenCacLoaiCong = CacLoaiCong.GetCacLoaiCong(_maCacLoaiCong).TenCacLoaiCong;
                return _tenCacLoaiCong;
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
 
		protected override object GetIdValue()
		{
			return _maCongThemGio;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 200));
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
			//TODO: Define authorization rules in CongThemGio
			//AuthorizationRules.AllowRead("MaCongThemGio", "CongThemGioReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "CongThemGioReadGroup");
			//AuthorizationRules.AllowRead("NgayChamCong", "CongThemGioReadGroup");
			//AuthorizationRules.AllowRead("NgayChamCongString", "CongThemGioReadGroup");
			//AuthorizationRules.AllowRead("SoGio", "CongThemGioReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "CongThemGioReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "CongThemGioReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "CongThemGioReadGroup");
			//AuthorizationRules.AllowRead("MaCacLoaiCong", "CongThemGioReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "CongThemGioWriteGroup");
			//AuthorizationRules.AllowWrite("NgayChamCongString", "CongThemGioWriteGroup");
			//AuthorizationRules.AllowWrite("SoGio", "CongThemGioWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "CongThemGioWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "CongThemGioWriteGroup");
			//AuthorizationRules.AllowWrite("MaCacLoaiCong", "CongThemGioWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CongThemGio
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThemGioViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CongThemGio
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThemGioAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CongThemGio
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThemGioEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CongThemGio
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThemGioDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CongThemGio()
		{ /* require use of factory method */ }

		public static CongThemGio NewCongThemGio(int maCongThemGio)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongThemGio");
			return DataPortal.Create<CongThemGio>(new Criteria(maCongThemGio));
		}

        public static CongThemGio NewCongThemGio(long maNhanVien)
        {
            CongThemGio _CongThemGio = new CongThemGio();
            _CongThemGio.MaNhanVien = maNhanVien;
            return _CongThemGio;
        }

		public static CongThemGio GetCongThemGio(int maCongThemGio)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CongThemGio");
			return DataPortal.Fetch<CongThemGio>(new Criteria(maCongThemGio));
		}

		public static void DeleteCongThemGio(int maCongThemGio)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CongThemGio");
			DataPortal.Delete(new Criteria(maCongThemGio));
		}

		public override CongThemGio Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CongThemGio");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongThemGio");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a CongThemGio");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private CongThemGio(int maCongThemGio)
		{
			this._maCongThemGio = maCongThemGio;
		}

		internal static CongThemGio NewCongThemGioChild(int maCongThemGio)
		{
			CongThemGio child = new CongThemGio(maCongThemGio);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CongThemGio GetCongThemGio(SafeDataReader dr)
		{
			CongThemGio child =  new CongThemGio();
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
			public int MaCongThemGio;

			public Criteria(int maCongThemGio)
			{
				this.MaCongThemGio = maCongThemGio;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maCongThemGio = criteria.MaCongThemGio;
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
                cm.CommandText = "spd_SelecttblnsCongThemGio";

				cm.Parameters.AddWithValue("@MaCongThemGio", criteria.MaCongThemGio);

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
			DataPortal_Delete(new Criteria(_maCongThemGio));
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
                cm.CommandText = "spd_DeletetblnsCongThemGio";

				cm.Parameters.AddWithValue("@MaCongThemGio", criteria.MaCongThemGio);

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
			_maCongThemGio = dr.GetInt32("MaCongThemGio");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_ngayChamCong = dr.GetSmartDate("NgayChamCong", _ngayChamCong.EmptyIsMin);
			_soGio = dr.GetDouble("SoGio");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_ghiChu = dr.GetString("GhiChu");
			_maCacLoaiCong = dr.GetInt32("MaCacLoaiCong");
            _maNguoiLap = dr.GetInt64("MaNguoiLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, CongThemGioList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, CongThemGioList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsCongThemGio";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CongThemGioList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaCongThemGio", _maCongThemGio);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayChamCong", _ngayChamCong.DBValue);
			if (_soGio != 0)
				cm.Parameters.AddWithValue("@SoGio", _soGio);
			else
				cm.Parameters.AddWithValue("@SoGio", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_maCacLoaiCong != 0)
				cm.Parameters.AddWithValue("@MaCacLoaiCong", _maCacLoaiCong);
			else
				cm.Parameters.AddWithValue("@MaCacLoaiCong", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, CongThemGioList parent)
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

		private void ExecuteUpdate(SqlConnection cn, CongThemGioList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsCongThemGio";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongThemGioList parent)
		{
			cm.Parameters.AddWithValue("@MaCongThemGio", _maCongThemGio);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayChamCong", _ngayChamCong.DBValue);
			if (_soGio != 0)
				cm.Parameters.AddWithValue("@SoGio", _soGio);
			else
				cm.Parameters.AddWithValue("@SoGio", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_maCacLoaiCong != 0)
				cm.Parameters.AddWithValue("@MaCacLoaiCong", _maCacLoaiCong);
			else
				cm.Parameters.AddWithValue("@MaCacLoaiCong", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maCongThemGio));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
