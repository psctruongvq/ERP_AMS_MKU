
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_Luong : Csla.BusinessBase<NhanVien_Luong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiLuong = 0;
		private long _maNhanVien = 0;
		private SmartDate _ngayTao = new SmartDate(DateTime.Today);
		private int _maQuyLuong = 0;
        private string _tenNhanVien = string.Empty;
        private string _tenLoaiLuong = string.Empty;
		[System.ComponentModel.DataObjectField(true, false)]
		public int MaLoaiLuong
		{
			get
			{
				CanReadProperty("MaLoaiLuong", true);
				return _maLoaiLuong;
			}
            set
            {
                CanWriteProperty("MaLoaiLuong", true);
                if (!_maLoaiLuong.Equals(value))
                {                  
                    _maLoaiLuong = value;
                    _tenLoaiLuong = NhanVien_Luong.GetNhanVien_Luong(_maLoaiLuong, _maNhanVien).TenLoaiLuong;
                    PropertyHasChanged("MaLoaiLuong");
                }
            }
		}

		[System.ComponentModel.DataObjectField(true, false)]
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

		public DateTime NgayTao
		{
			get
			{
				CanReadProperty("NgayTao", true);
				return _ngayTao.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayTao.Equals(value))
                {
                    _ngayTao = new SmartDate(value);
                    PropertyHasChanged("NgayTao");
                }
            }
		}

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
            set
            {
                CanWriteProperty("TenNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }
        public string TenLoaiLuong
        {
            get
            {
                CanReadProperty("TenLoaiLuong", true);
                return _tenLoaiLuong;
            }
            set
            {
                CanWriteProperty("TenLoaiLuong", true);
                if (value == null) value = string.Empty;
                if (!_tenLoaiLuong.Equals(value))
                {
                    _tenLoaiLuong = value;
                    PropertyHasChanged("TenLoaiLuong");
                }
            }
        }
		public int MaQuyLuong
		{
			get
			{
				CanReadProperty("MaQuyLuong", true);
				return _maQuyLuong;
			}
			set
			{
				CanWriteProperty("MaQuyLuong", true);
				if (!_maQuyLuong.Equals(value))
				{
					_maQuyLuong = value;
					PropertyHasChanged("MaQuyLuong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return string.Format("{0}:{1}", _maLoaiLuong, _maNhanVien);
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
			// NgayTao
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayTaoString");
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
			//TODO: Define authorization rules in NhanVien_Luong
			//AuthorizationRules.AllowRead("MaLoaiLuong", "NhanVien_LuongReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "NhanVien_LuongReadGroup");
			//AuthorizationRules.AllowRead("NgayTao", "NhanVien_LuongReadGroup");
			//AuthorizationRules.AllowRead("NgayTaoString", "NhanVien_LuongReadGroup");
			//AuthorizationRules.AllowRead("MaQuyLuong", "NhanVien_LuongReadGroup");

			//AuthorizationRules.AllowWrite("NgayTaoString", "NhanVien_LuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuyLuong", "NhanVien_LuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhanVien_Luong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVien_LuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhanVien_Luong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVien_LuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhanVien_Luong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVien_LuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhanVien_Luong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVien_LuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NhanVien_Luong()
		{ /* require use of factory method */ }

		public static NhanVien_Luong NewNhanVien_Luong(int maLoaiLuong, long maNhanVien)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhanVien_Luong");
			return DataPortal.Create<NhanVien_Luong>(new Criteria(maLoaiLuong, maNhanVien));
		}

		public static NhanVien_Luong GetNhanVien_Luong(int maLoaiLuong, long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhanVien_Luong");
			return DataPortal.Fetch<NhanVien_Luong>(new Criteria(maLoaiLuong, maNhanVien));
		}

		public static void DeleteNhanVien_Luong(int maLoaiLuong, long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhanVien_Luong");
			DataPortal.Delete(new Criteria(maLoaiLuong, maNhanVien));
		}

		public override NhanVien_Luong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhanVien_Luong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhanVien_Luong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NhanVien_Luong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private NhanVien_Luong(int maLoaiLuong,long maNhanVien)
		{
			this._maLoaiLuong = maLoaiLuong;
			this._maNhanVien = maNhanVien;
		}

		internal static NhanVien_Luong NewNhanVien_LuongChild(int maLoaiLuong, long maNhanVien)
		{
			NhanVien_Luong child = new NhanVien_Luong(maLoaiLuong, maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhanVien_Luong GetNhanVien_Luong(SafeDataReader dr)
		{
			NhanVien_Luong child =  new NhanVien_Luong();
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
			public int MaLoaiLuong;
			public long MaNhanVien;

			public Criteria(int maLoaiLuong, long maNhanVien)
			{
				this.MaLoaiLuong = maLoaiLuong;
				this.MaNhanVien = maNhanVien;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Object criteria)
		{
			_maLoaiLuong = ((Criteria)criteria).MaLoaiLuong;
			_maNhanVien = ((Criteria)criteria).MaNhanVien;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "sp_SelecttblnsNhanVien_Luong";

                    cm.Parameters.AddWithValue("@MaLoaiLuong", ((Criteria)criteria).MaLoaiLuong);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((Criteria)criteria).MaNhanVien);
                }
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
			DataPortal_Delete(new Criteria(_maLoaiLuong, _maNhanVien));
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
                cm.CommandText = "sp_DeletetblnsNhanVien_Luong";

				cm.Parameters.AddWithValue("@MaLoaiLuong", criteria.MaLoaiLuong);
				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
            try
            {
                _maLoaiLuong = dr.GetInt32("MaLoaiLuong");
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
                _maQuyLuong = dr.GetInt32("MaQuyLuong");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _tenLoaiLuong = dr.GetString("TenLoaiLuong");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhanVien_LuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhanVien_LuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsNhanVien_Luong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien_LuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaLoaiLuong", _maLoaiLuong);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
			cm.Parameters.AddWithValue("@MaQuyLuong", _maQuyLuong);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhanVien_LuongList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, NhanVien_LuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsNhanVien_Luong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien_LuongList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiLuong", _maLoaiLuong);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
			cm.Parameters.AddWithValue("@MaQuyLuong", _maQuyLuong);
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

			ExecuteDelete(tr, new Criteria(_maLoaiLuong, _maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
