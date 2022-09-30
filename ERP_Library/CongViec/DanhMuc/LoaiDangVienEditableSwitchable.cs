
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiDangVien : Csla.BusinessBase<LoaiDangVien>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiDangVien = 0;
		private string _tenLoaiDangVien = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiDangVien
		{
			get
			{
				CanReadProperty("MaLoaiDangVien", true);
				return _maLoaiDangVien;
			}
		}

		public string TenLoaiDangVien
		{
			get
			{
				CanReadProperty("TenLoaiDangVien", true);
				return _tenLoaiDangVien;
			}
			set
			{
				CanWriteProperty("TenLoaiDangVien", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiDangVien.Equals(value))
				{
					_tenLoaiDangVien = value;
					PropertyHasChanged("TenLoaiDangVien");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiDangVien;
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
			// TenLoaiDangVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiDangVien", 50));
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
			//TODO: Define authorization rules in LoaiDangVien
			//AuthorizationRules.AllowRead("MaLoaiDangVien", "LoaiDangVienReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiDangVien", "LoaiDangVienReadGroup");

			//AuthorizationRules.AllowWrite("TenLoaiDangVien", "LoaiDangVienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiDangVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiDangVienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiDangVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiDangVienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiDangVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiDangVienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiDangVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiDangVienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiDangVien()
		{ /* require use of factory method */ }

		public static LoaiDangVien NewLoaiDangVien()
		{
            LoaiDangVien item = new LoaiDangVien();
            item.MarkAsChild();
            return item;
		}

		public static LoaiDangVien GetLoaiDangVien(int maLoaiDangVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiDangVien");
			return DataPortal.Fetch<LoaiDangVien>(new Criteria(maLoaiDangVien));
		}

		public static void DeleteLoaiDangVien(int maLoaiDangVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiDangVien");
			DataPortal.Delete(new Criteria(maLoaiDangVien));
		}

		public override LoaiDangVien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiDangVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiDangVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiDangVien");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiDangVien NewLoaiDangVienChild()
		{
			LoaiDangVien child = new LoaiDangVien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiDangVien GetLoaiDangVien(SafeDataReader dr)
		{
			LoaiDangVien child =  new LoaiDangVien();
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
			public int MaLoaiDangVien;

			public Criteria(int maLoaiDangVien)
			{
				this.MaLoaiDangVien = maLoaiDangVien;
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
                cm.CommandText = "spd_SelecttblnsLoaiDangVien";

				cm.Parameters.AddWithValue("@MaLoaiDangVien", criteria.MaLoaiDangVien);

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
			DataPortal_Delete(new Criteria(_maLoaiDangVien));
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
                cm.CommandText = "spd_DeletetblnsLoaiDangVien";

				cm.Parameters.AddWithValue("@MaLoaiDangVien", criteria.MaLoaiDangVien);

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
			_maLoaiDangVien = dr.GetInt32("MaLoaiDangVien");
			_tenLoaiDangVien = dr.GetString("TenLoaiDangVien");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, LoaiDangVienList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, LoaiDangVienList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsLoaiDangVien";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, LoaiDangVienList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_tenLoaiDangVien.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiDangVien", _tenLoaiDangVien);
			else
				cm.Parameters.AddWithValue("@TenLoaiDangVien", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, LoaiDangVienList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, LoaiDangVienList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsLoaiDangVien";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, LoaiDangVienList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiDangVien", _maLoaiDangVien);
			if (_tenLoaiDangVien.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiDangVien", _tenLoaiDangVien);
			else
				cm.Parameters.AddWithValue("@TenLoaiDangVien", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maLoaiDangVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
