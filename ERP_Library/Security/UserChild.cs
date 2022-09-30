
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class UserChild : Csla.BusinessBase<UserChild>
	{
		#region Business Properties and Methods

		//declare members
		private int _id = 0;
		private int _userID = 0;
		private int _userChild = 0;
        
		[System.ComponentModel.DataObjectField(true, true)]
		public int Id
		{
			get
			{
				return _id;
			}
		}

		public int UserID_Parent
		{
			get
			{
				return _userID;
			}
			set
			{
				if (!_userID.Equals(value))
				{
					_userID = value;
                    PropertyHasChanged("UserID_Parent");
				}
			}
		}

		public int User_Child
		{
			get
			{
				return _userChild;
			}
			set
			{
				if (!_userChild.Equals(value))
				{
					_userChild = value;
                    PropertyHasChanged("User_Child");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _id;
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

		#region Factory Methods
		private UserChild()
		{ /* require use of factory method */ }

		public static UserChild NewUserChild()
		{
			return DataPortal.Create<UserChild>();
		}

		public static UserChild GetUserChild(int id)
		{
			return DataPortal.Fetch<UserChild>(new Criteria(id));
		}

		public static void DeleteUserChild(int id)
		{
			DataPortal.Delete(new Criteria(id));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static UserChild NewUserChildChild()
		{
			UserChild child = new UserChild();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static UserChild GetUserChild(SafeDataReader dr)
		{
			UserChild child =  new UserChild();
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
			public int Id;

			public Criteria(int id)
			{
				this.Id = id;
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
				cm.CommandText = "Selectapp_UserChild";

				cm.Parameters.AddWithValue("@ID", criteria.Id);

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
			DataPortal_Delete(new Criteria(_id));
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
				cm.CommandText = "Deleteapp_UserChild";

				cm.Parameters.AddWithValue("@ID", criteria.Id);

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
			_id = dr.GetInt32("ID");
			_userID = dr.GetInt32("UserID");
			_userChild = dr.GetInt32("UserChild");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, Security.UserItem parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, Security.UserItem parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Insertapp_UserChild";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_id = (int)cm.Parameters["@ID"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, Security.UserItem parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@UserID", parent.UserID);
			cm.Parameters.AddWithValue("@UserChild", _userChild);
			cm.Parameters.AddWithValue("@ID", _id);
			cm.Parameters["@ID"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, Security.UserItem parent)
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

        private void ExecuteUpdate(SqlTransaction tr, Security.UserItem parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Updateapp_UserChild";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, Security.UserItem parent)
		{
			cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters.AddWithValue("@UserID", parent.UserID);
			cm.Parameters.AddWithValue("@UserChild", _userChild);
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

			ExecuteDelete(tr, new Criteria(_id));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
