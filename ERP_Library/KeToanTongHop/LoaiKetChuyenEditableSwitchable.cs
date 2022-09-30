using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiKetChuyen : Csla.BusinessBase<LoaiKetChuyen>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiKetChuyen = 0;
		private string _tenLoaiKetChuyen = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiKetChuyen
		{
			get
			{
				CanReadProperty("MaLoaiKetChuyen", true);
				return _maLoaiKetChuyen;
			}
		}

		public string TenLoaiKetChuyen
		{
			get
			{
				CanReadProperty("TenLoaiKetChuyen", true);
				return _tenLoaiKetChuyen;
			}
			set
			{
				CanWriteProperty("TenLoaiKetChuyen", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiKetChuyen.Equals(value))
				{
					_tenLoaiKetChuyen = value;
					PropertyHasChanged("TenLoaiKetChuyen");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiKetChuyen;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

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
			//TODO: Define authorization rules in LoaiKetChuyen
			//AuthorizationRules.AllowRead("MaLoaiKetChuyen", "LoaiKetChuyenReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiKetChuyen", "LoaiKetChuyenReadGroup");

			//AuthorizationRules.AllowWrite("TenLoaiKetChuyen", "LoaiKetChuyenWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiKetChuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKetChuyenViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiKetChuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKetChuyenAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiKetChuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKetChuyenEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiKetChuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKetChuyenDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiKetChuyen()
		{ /* require use of factory method */ }

		public static LoaiKetChuyen NewLoaiKetChuyen()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiKetChuyen");
			return DataPortal.Create<LoaiKetChuyen>();
		}

		public static LoaiKetChuyen GetLoaiKetChuyen(int maLoaiKetChuyen)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiKetChuyen");
			return DataPortal.Fetch<LoaiKetChuyen>(new Criteria(maLoaiKetChuyen));
		}

		public static void DeleteLoaiKetChuyen(int maLoaiKetChuyen)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiKetChuyen");
			DataPortal.Delete(new Criteria(maLoaiKetChuyen));
		}

		public override LoaiKetChuyen Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiKetChuyen");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiKetChuyen");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiKetChuyen");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiKetChuyen NewLoaiKetChuyenChild()
		{
			LoaiKetChuyen child = new LoaiKetChuyen();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiKetChuyen GetLoaiKetChuyen(SafeDataReader dr)
		{
			LoaiKetChuyen child =  new LoaiKetChuyen();
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
			public int MaLoaiKetChuyen;

			public Criteria(int maLoaiKetChuyen)
			{
				this.MaLoaiKetChuyen = maLoaiKetChuyen;
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
				cm.CommandText = "GetLoaiKetChuyen";

				cm.Parameters.AddWithValue("@MaLoaiKetChuyen", criteria.MaLoaiKetChuyen);

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
			DataPortal_Delete(new Criteria(_maLoaiKetChuyen));
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
                cm.CommandText = "spd_DeletetblLoaiKetChuyen";

				cm.Parameters.AddWithValue("@MaLoaiKetChuyen", criteria.MaLoaiKetChuyen);

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
			_maLoaiKetChuyen = dr.GetInt32("MaLoaiKetChuyen");
			_tenLoaiKetChuyen = dr.GetString("TenLoaiKetChuyen");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, LoaiKetChuyenList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, LoaiKetChuyenList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblLoaiKetChuyen";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maLoaiKetChuyen = (int)cm.Parameters["@MaLoaiKetChuyen"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, LoaiKetChuyenList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_tenLoaiKetChuyen.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiKetChuyen", _tenLoaiKetChuyen);
			else
				cm.Parameters.AddWithValue("@TenLoaiKetChuyen", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiKetChuyen", _maLoaiKetChuyen);
			cm.Parameters["@MaLoaiKetChuyen"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, LoaiKetChuyenList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, LoaiKetChuyenList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblLoaiKetChuyen";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, LoaiKetChuyenList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiKetChuyen", _maLoaiKetChuyen);
			if (_tenLoaiKetChuyen.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiKetChuyen", _tenLoaiKetChuyen);
			else
				cm.Parameters.AddWithValue("@TenLoaiKetChuyen", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maLoaiKetChuyen));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
