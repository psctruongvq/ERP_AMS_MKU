
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiLuong : Csla.BusinessBase<LoaiLuong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiLuong = 0;
		private string _maLoaiLuongQL = string.Empty;
		private string _tenLoaiLuong = string.Empty;
		private SmartDate _ngayTao = new SmartDate(false);

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaLoaiLuong
		{
			get
			{
				CanReadProperty("MaLoaiLuong", true);
				return _maLoaiLuong;
			}
		}

		public string MaLoaiLuongQL
		{
			get
			{
				CanReadProperty("MaLoaiLuongQL", true);
				return _maLoaiLuongQL;
			}
			set
			{
				CanWriteProperty("MaLoaiLuongQL", true);
				if (value == null) value = string.Empty;
				if (!_maLoaiLuongQL.Equals(value))
				{
					_maLoaiLuongQL = value;
					PropertyHasChanged("MaLoaiLuongQL");
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

		public DateTime NgayTao
		{
			get
			{
				CanReadProperty("NgayTao", true);
				return _ngayTao.Date;
			}
		}

		
		protected override object GetIdValue()
		{
			return _maLoaiLuong;
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
			// MaLoaiLuongQL
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaLoaiLuongQL", 50));
			//
			// TenLoaiLuong
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiLuong", 50));
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
			//TODO: Define authorization rules in LoaiLuong
			//AuthorizationRules.AllowRead("MaLoaiLuong", "LoaiLuongReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiLuongQL", "LoaiLuongReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiLuong", "LoaiLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayTao", "LoaiLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayTaoString", "LoaiLuongReadGroup");

			//AuthorizationRules.AllowWrite("MaLoaiLuongQL", "LoaiLuongWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiLuong", "LoaiLuongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayTaoString", "LoaiLuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiLuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiLuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiLuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiLuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiLuong()
		{ /* require use of factory method */ }

		public static LoaiLuong NewLoaiLuong(int maLoaiLuong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiLuong");
			return DataPortal.Create<LoaiLuong>(new Criteria(maLoaiLuong));
		}

		public static LoaiLuong GetLoaiLuong(int maLoaiLuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiLuong");
			return DataPortal.Fetch<LoaiLuong>(new Criteria(maLoaiLuong));
		}

		public static void DeleteLoaiLuong(int maLoaiLuong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiLuong");
			DataPortal.Delete(new Criteria(maLoaiLuong));
		}

		public override LoaiLuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiLuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiLuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiLuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private LoaiLuong(int maLoaiLuong)
		{
			this._maLoaiLuong = maLoaiLuong;
		}

		internal static LoaiLuong NewLoaiLuongChild(int maLoaiLuong)
		{
			LoaiLuong child = new LoaiLuong(maLoaiLuong);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiLuong GetLoaiLuong(SafeDataReader dr)
		{
			LoaiLuong child =  new LoaiLuong();
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

			public Criteria(int maLoaiLuong)
			{
				this.MaLoaiLuong = maLoaiLuong;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maLoaiLuong = criteria.MaLoaiLuong;
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
                cm.CommandText = "sp_SelecttblnsLoaiLuong";

				cm.Parameters.AddWithValue("@MaLoaiLuong", criteria.MaLoaiLuong);

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
			DataPortal_Delete(new Criteria(_maLoaiLuong));
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
                cm.CommandText = "sp_DeletetblnsLoaiLuong";

				cm.Parameters.AddWithValue("@MaLoaiLuong", criteria.MaLoaiLuong);

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
			_maLoaiLuong = dr.GetInt32("MaLoaiLuong");
			_maLoaiLuongQL = dr.GetString("MaLoaiLuongQL");
			_tenLoaiLuong = dr.GetString("TenLoaiLuong");
			_ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, LoaiLuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, LoaiLuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsLoaiLuong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, LoaiLuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaLoaiLuong", _maLoaiLuong);
			if (_maLoaiLuongQL.Length > 0)
				cm.Parameters.AddWithValue("@MaLoaiLuongQL", _maLoaiLuongQL);
			else
				cm.Parameters.AddWithValue("@MaLoaiLuongQL", DBNull.Value);
			if (_tenLoaiLuong.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiLuong", _tenLoaiLuong);
			else
				cm.Parameters.AddWithValue("@TenLoaiLuong", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, LoaiLuongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, LoaiLuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsLoaiLuong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, LoaiLuongList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiLuong", _maLoaiLuong);
			if (_maLoaiLuongQL.Length > 0)
				cm.Parameters.AddWithValue("@MaLoaiLuongQL", _maLoaiLuongQL);
			else
				cm.Parameters.AddWithValue("@MaLoaiLuongQL", DBNull.Value);
			if (_tenLoaiLuong.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiLuong", _tenLoaiLuong);
			else
				cm.Parameters.AddWithValue("@TenLoaiLuong", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
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

			ExecuteDelete(tr, new Criteria(_maLoaiLuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
