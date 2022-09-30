
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Role : Csla.BusinessBase<Role>
	{
		#region Business Properties and Methods

		//declare members
		private int _roleID = 0;
		private string _roles = string.Empty;
        private bool _check = false;


        public bool Check
        {
            get
            {
                CanReadProperty("Check", true);
                return _check;
            }
            set
            {
                CanWriteProperty("Check", true);                
                if (!_check.Equals(value))
                {
                    _check = value;
                    PropertyHasChanged("Check");
                }
            }
        }

		[System.ComponentModel.DataObjectField(true, false)]
		public int RoleID
		{
			get
			{
				CanReadProperty("RoleID", true);
				return _roleID;
			}
		}

		public string Roles
		{
			get
			{
				CanReadProperty("Roles", true);
				return _roles;
			}
			set
			{
				CanWriteProperty("Roles", true);
				if (value == null) value = string.Empty;
				if (!_roles.Equals(value))
				{
					_roles = value;
					PropertyHasChanged("Roles");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _roleID;
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
			// Roles
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "Roles");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Roles", 50));
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
			//TODO: Define authorization rules in Role
			//AuthorizationRules.AllowRead("RoleID", "RoleReadGroup");
			//AuthorizationRules.AllowRead("Roles", "RoleReadGroup");

			//AuthorizationRules.AllowWrite("Roles", "RoleWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in Role
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("RoleViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in Role
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("RoleAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in Role
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("RoleEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in Role
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("RoleDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private Role()
		{ /* require use of factory method */ }

		public static Role NewRole(int roleID)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Role");
			return DataPortal.Create<Role>(new Criteria(roleID));
		}

		public static Role GetRole(int roleID)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Role");
			return DataPortal.Fetch<Role>(new Criteria(roleID));
		}

		public static void DeleteRole(int roleID)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Role");
			DataPortal.Delete(new Criteria(roleID));
		}

		public override Role Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Role");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Role");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a Role");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private Role(int roleID)
		{
			this._roleID = roleID;
		}

		internal static Role NewRoleChild(int roleID)
		{
			Role child = new Role(roleID);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static Role GetRole(SafeDataReader dr)
		{
			Role child =  new Role();
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
			public int RoleID;

			public Criteria(int roleID)
			{
				this.RoleID = roleID;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_roleID = criteria.RoleID;
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
				cm.CommandText = "GetRole";

				cm.Parameters.AddWithValue("@RoleID", criteria.RoleID);

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
			DataPortal_Delete(new Criteria(_roleID));
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
				cm.CommandText = "DeleteRole";

				cm.Parameters.AddWithValue("@RoleID", criteria.RoleID);

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
			_roleID = dr.GetInt32("RoleID");
			_roles = dr.GetString("Roles");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, RoleList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, RoleList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddRole";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, RoleList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@RoleID", _roleID);
			cm.Parameters.AddWithValue("@Roles", _roles);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, RoleList parent)
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

		private void ExecuteUpdate(SqlConnection cn, RoleList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateRole";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, RoleList parent)
		{
			cm.Parameters.AddWithValue("@RoleID", _roleID);
			cm.Parameters.AddWithValue("@Roles", _roles);
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

			ExecuteDelete(cn, new Criteria(_roleID));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
