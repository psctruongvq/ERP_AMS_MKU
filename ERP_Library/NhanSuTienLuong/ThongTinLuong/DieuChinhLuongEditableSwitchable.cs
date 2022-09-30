
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DieuChinhLuong : Csla.BusinessBase<DieuChinhLuong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maDieuChinh = 0;
		private long _maNhanVien = 0;
		private decimal _soTienDieuChinh = 0;
		private bool _congTruLuong = false;
		private int _maKy = 0;
		private int _maLoaiDieuChinh = 0;
        private string _TenLoaidieuchinh = string.Empty;
		private string _maQLNhanVien = string.Empty;
		private string _tenNhanVien = string.Empty;
        private string _ghiChu = string.Empty;
        private string _strCongtru = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaDieuChinh
		{
			get
			{
				CanReadProperty("MaDieuChinh", true);
				return _maDieuChinh;
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

		public decimal SoTienDieuChinh
		{
			get
			{
				CanReadProperty("SoTienDieuChinh", true);
				return _soTienDieuChinh;
			}
			set
			{
				CanWriteProperty("SoTienDieuChinh", true);
				if (!_soTienDieuChinh.Equals(value))
				{
					_soTienDieuChinh = value;
					PropertyHasChanged("SoTienDieuChinh");
				}
			}
		}

		public bool CongTruLuong
		{
			get
			{
				CanReadProperty("CongTruLuong", true);
				return _congTruLuong;
			}
			set
			{
				CanWriteProperty("CongTruLuong", true);
				if (!_congTruLuong.Equals(value))
				{
					_congTruLuong = value;
					PropertyHasChanged("CongTruLuong");
				}
			}
		}

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

		public int MaLoaiDieuChinh
		{
			get
			{
				CanReadProperty("MaLoaiDieuChinh", true);
				return _maLoaiDieuChinh;
			}
			set
			{
				CanWriteProperty("MaLoaiDieuChinh", true);
				if (!_maLoaiDieuChinh.Equals(value))
				{
					_maLoaiDieuChinh = value;
					PropertyHasChanged("MaLoaiDieuChinh");
				}
			}
		}

		public string MaQLNhanVien
		{
			get
			{
				CanReadProperty(true);
				return _maQLNhanVien;
			}			
		}

		public string TenNhanVien
		{
			get
			{
				CanReadProperty(true);
                return _tenNhanVien;
			}			
		}

        public string CongTru
        {
            get
            {
                CanReadProperty(true);
                return _strCongtru;
            }
        }

        public string Tenloaidieuchinh
        {
            get
            {
                CanReadProperty(true);
                return _TenLoaidieuchinh;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_TenLoaidieuchinh.Equals(value))
                {
                    _TenLoaidieuchinh = value;
                    PropertyHasChanged();
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
		protected override object GetIdValue()
		{
			return _maDieuChinh;
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
			// MaQLNhanVien
			//
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
			//TODO: Define authorization rules in DieuChinhLuong
			//AuthorizationRules.AllowRead("MaDieuChinh", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("Thang", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("Nam", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("SoTienDieuChinh", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("CongTruLuong", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("MaKy", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiDieuChinh", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("MaQLNhanVien", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "DieuChinhLuongReadGroup");
			//AuthorizationRules.AllowRead("TenKy", "DieuChinhLuongReadGroup");

			//AuthorizationRules.AllowWrite("Thang", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("Nam", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienDieuChinh", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("CongTruLuong", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaKy", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiDieuChinh", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLNhanVien", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "DieuChinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("TenKy", "DieuChinhLuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DieuChinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChinhLuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DieuChinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChinhLuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DieuChinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChinhLuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DieuChinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChinhLuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DieuChinhLuong()
		{ /* require use of factory method */ }

		public static DieuChinhLuong NewDieuChinhLuong(int maDieuChinh)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DieuChinhLuong");
			return DataPortal.Create<DieuChinhLuong>(new Criteria(maDieuChinh));
		}

		public static DieuChinhLuong GetDieuChinhLuong(int maDieuChinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DieuChinhLuong");
			return DataPortal.Fetch<DieuChinhLuong>(new Criteria(maDieuChinh));
		}

		public static void DeleteDieuChinhLuong(int maDieuChinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DieuChinhLuong");
			DataPortal.Delete(new Criteria(maDieuChinh));
		}

		public override DieuChinhLuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DieuChinhLuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DieuChinhLuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DieuChinhLuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private DieuChinhLuong(int maDieuChinh)
		{
			this._maDieuChinh = maDieuChinh;
		}

		internal static DieuChinhLuong NewDieuChinhLuongChild(int maDieuChinh)
		{
			DieuChinhLuong child = new DieuChinhLuong(maDieuChinh);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DieuChinhLuong GetDieuChinhLuong(SafeDataReader dr)
		{
			DieuChinhLuong child =  new DieuChinhLuong();
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
			public int MaDieuChinh;

			public Criteria(int maDieuChinh)
			{
				this.MaDieuChinh = maDieuChinh;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maDieuChinh = criteria.MaDieuChinh;
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
                cm.CommandText = "spd_SelecttblnsDieuChinhLuong";

				cm.Parameters.AddWithValue("@MaDieuChinh", criteria.MaDieuChinh);

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
			DataPortal_Delete(new Criteria(_maDieuChinh));
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
                cm.CommandText = "spd_DeletetblnsDieuChinhLuong";

				cm.Parameters.AddWithValue("@MaDieuChinh", criteria.MaDieuChinh);

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
			_maDieuChinh = dr.GetInt32("MaDieuChinh");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_soTienDieuChinh = dr.GetDecimal("SoTienDieuChinh");
			_congTruLuong = dr.GetBoolean("CongTruLuong");
            if (_congTruLuong)
            {
                _strCongtru = "Trừ";
            }
            else
            {
                _strCongtru = "Cộng";
            }
			_maKy = dr.GetInt32("MaKy");
			_maLoaiDieuChinh = dr.GetInt32("MaLoaiDieuChinh");
            _TenLoaidieuchinh = dr.GetString("Tenloaidieuchinh");
			_maQLNhanVien = dr.GetString("MaQLNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
            _ghiChu= dr.GetString("GhiChu");
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
                cm.CommandText = "spd_InserttblnsDieuChinhLuong";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();
                _maDieuChinh = (int)cm.Parameters["@MaDieuChinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{			
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_soTienDieuChinh != 0)
				cm.Parameters.AddWithValue("@SoTienDieuChinh", _soTienDieuChinh);
			else
				cm.Parameters.AddWithValue("@SoTienDieuChinh", DBNull.Value);
			if (_congTruLuong != false)
				cm.Parameters.AddWithValue("@CongTruLuong", _congTruLuong);
			else
				cm.Parameters.AddWithValue("@CongTruLuong", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_maLoaiDieuChinh != 0)
				cm.Parameters.AddWithValue("@MaLoaiDieuChinh", _maLoaiDieuChinh);
			else
				cm.Parameters.AddWithValue("@MaLoaiDieuChinh", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            cm.Parameters.AddWithValue("@MaDieuChinh", _maLoaiDieuChinh);
            cm.Parameters["@MaDieuChinh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsDieuChinhLuong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaDieuChinh", _maDieuChinh);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_soTienDieuChinh != 0)
				cm.Parameters.AddWithValue("@SoTienDieuChinh", _soTienDieuChinh);
			else
				cm.Parameters.AddWithValue("@SoTienDieuChinh", DBNull.Value);
			cm.Parameters.AddWithValue("@CongTruLuong", _congTruLuong);			
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_maLoaiDieuChinh != 0)
				cm.Parameters.AddWithValue("@MaLoaiDieuChinh", _maLoaiDieuChinh);
			else
				cm.Parameters.AddWithValue("@MaLoaiDieuChinh", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			
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

			ExecuteDelete(tr, new Criteria(_maDieuChinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
        public static void ThemDieuChinh(int maky, long manhanvien, decimal Sotien, bool CongTru, int maloaiDC, string Ghichu)
        {
            using (SqlConnection cn=new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using(SqlCommand cm=cn.CreateCommand())
                {
                    cm.CommandType=CommandType.StoredProcedure;
                    cm.CommandText="spd_tblnsDieuChinhLuong_ThemMoi";
                    cm.Parameters.AddWithValue("@Maky",maky);
                    cm.Parameters.AddWithValue("@manhanvien",manhanvien);
                    cm.Parameters.AddWithValue("@sotien",Sotien);
                    if (CongTru)                    
                    cm.Parameters.AddWithValue("@congtru",1);
                    else
                    cm.Parameters.AddWithValue("@congtru", 0);
                    cm.Parameters.AddWithValue("@maloaiDC",maloaiDC);
                    cm.Parameters.AddWithValue("@ghichu",Ghichu);
                    cm.ExecuteNonQuery();
                }
            }
        }

		#endregion //Data Access
	}
}
