
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoPhan_Luong : Csla.BusinessBase<BoPhan_Luong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiLuong = 0;
		private int _maBoPhan = 0;
		private SmartDate _ngayTao = new SmartDate(DateTime.Today);
		private int _maQuyLuong = 0;
        private string _tenLoaiLuong = string.Empty;
        [System.ComponentModel.DataObjectField(true, false)]
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
                    PropertyHasChanged("MaLoaiLuong");
                }
            }
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaBoPhan
		{
			get
			{
				CanReadProperty("MaBoPhan", true);
				return _maBoPhan;
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
                CanWriteProperty("NgayTao", true);
                if (!_ngayTao.Equals(value))
                {
                    _ngayTao = new SmartDate(value);
                    PropertyHasChanged("NgayTao");
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
			return string.Format("{0}:{1}", _maLoaiLuong, _maBoPhan);
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
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayTaoString");
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
			//TODO: Define authorization rules in BoPhan_Luong
			//AuthorizationRules.AllowRead("MaLoaiLuong", "BoPhan_LuongReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "BoPhan_LuongReadGroup");
			//AuthorizationRules.AllowRead("NgayTao", "BoPhan_LuongReadGroup");
			//AuthorizationRules.AllowRead("NgayTaoString", "BoPhan_LuongReadGroup");
			//AuthorizationRules.AllowRead("MaQuyLuong", "BoPhan_LuongReadGroup");

			//AuthorizationRules.AllowWrite("NgayTaoString", "BoPhan_LuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuyLuong", "BoPhan_LuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoPhan_Luong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_LuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoPhan_Luong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_LuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoPhan_Luong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_LuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoPhan_Luong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_LuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoPhan_Luong()
		{ /* require use of factory method */ }

		public static BoPhan_Luong NewBoPhan_Luong(int maLoaiLuong, int maBoPhan)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhan_Luong");
			return DataPortal.Create<BoPhan_Luong>(new Criteria(maLoaiLuong, maBoPhan));
		}

		public static BoPhan_Luong GetBoPhan_Luong(int maLoaiLuong, int maBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhan_Luong");
			return DataPortal.Fetch<BoPhan_Luong>(new Criteria(maLoaiLuong, maBoPhan));
		}

		public static void DeleteBoPhan_Luong(int maLoaiLuong, int maBoPhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoPhan_Luong");
			DataPortal.Delete(new Criteria(maLoaiLuong, maBoPhan));
		}

		public override BoPhan_Luong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoPhan_Luong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhan_Luong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BoPhan_Luong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private BoPhan_Luong(int maLoaiLuong,int maBoPhan)
		{
			this._maLoaiLuong = maLoaiLuong;
			this._maBoPhan = maBoPhan;
		}

		internal static BoPhan_Luong NewBoPhan_LuongChild(int maLoaiLuong, int maBoPhan)
		{
			BoPhan_Luong child = new BoPhan_Luong(maLoaiLuong, maBoPhan);
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BoPhan_Luong GetBoPhan_Luong(SafeDataReader dr)
		{
			BoPhan_Luong child =  new BoPhan_Luong();
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
			public int MaBoPhan;

			public Criteria(int maLoaiLuong, int maBoPhan)
			{
				this.MaLoaiLuong = maLoaiLuong;
				this.MaBoPhan = maBoPhan;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maLoaiLuong = criteria.MaLoaiLuong;
			_maBoPhan = criteria.MaBoPhan;
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
				cm.CommandText = "GetBoPhan_Luong";

				cm.Parameters.AddWithValue("@MaLoaiLuong", criteria.MaLoaiLuong);
				cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

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
			DataPortal_Delete(new Criteria(_maLoaiLuong, _maBoPhan));
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
                cm.CommandText = "sp_DeletetblnsBoPhan_NhanVien_Luong";

				cm.Parameters.AddWithValue("@MaLoaiLuong", criteria.MaLoaiLuong);
				cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

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
            _tenLoaiLuong = dr.GetString("TenLoaiLuong");
			_maLoaiLuong = dr.GetInt32("MaLoaiLuong");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
			_maQuyLuong = dr.GetInt32("MaQuyLuong");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BoPhan_LuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BoPhan_LuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsBoPhan_Luong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BoPhan_LuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaLoaiLuong", _maLoaiLuong);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
			cm.Parameters.AddWithValue("@MaQuyLuong", _maQuyLuong);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BoPhan_LuongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BoPhan_LuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsBoPhan_Luong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BoPhan_LuongList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiLuong", _maLoaiLuong);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
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

			ExecuteDelete(tr, new Criteria(_maLoaiLuong, _maBoPhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
