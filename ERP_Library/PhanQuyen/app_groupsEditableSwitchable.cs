using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class app_groups : Csla.BusinessBase<app_groups>
	{
		#region Business Properties and Methods

		//declare members
		private int _groupID = 0;
		private string _tenChucNang = string.Empty;

        // child 
        private AppMenuGroupList _appMenuGroupList = AppMenuGroupList.NewAppMenuGroupList();

        [System.ComponentModel.DataObjectField(true, true)]
		public int GroupID
		{
			get
			{
				CanReadProperty("GroupID", true);
				return _groupID;
			}
		}

		public string TenChucNang
		{
			get
			{
				CanReadProperty("TenChucNang", true);
				return _tenChucNang;
			}
			set
			{
				CanWriteProperty("TenChucNang", true);
				if (value == null) value = string.Empty;
				if (!_tenChucNang.Equals(value))
				{
					_tenChucNang = value;
					PropertyHasChanged("TenChucNang");
				}
			}
		}

        public AppMenuGroupList AppMenuGroupList
        {
            get
            {
                CanReadProperty("AppMenuGroupList", true);
                return _appMenuGroupList;
            }
            set
            {
                CanWriteProperty("AppMenuGroupList", true);
               
                if (!_appMenuGroupList.Equals(value))
                {
                    _appMenuGroupList = value;
                    PropertyHasChanged("AppMenuGroupList");
                }
            }

        }
        public override bool IsValid
        {
            get { return base.IsValid && _appMenuGroupList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _appMenuGroupList.IsDirty; }
        }

        protected override object GetIdValue()
		{
			return _groupID;
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
			// TenChucNang
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenChucNang");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucNang", 100));
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
			//TODO: Define authorization rules in app_groups
			//AuthorizationRules.AllowRead("GroupID", "app_groupsReadGroup");
			//AuthorizationRules.AllowRead("TenChucNang", "app_groupsReadGroup");

			//AuthorizationRules.AllowWrite("TenChucNang", "app_groupsWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in app_groups
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("app_groupsViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in app_groups
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("app_groupsAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in app_groups
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("app_groupsEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in app_groups
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("app_groupsDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private app_groups()
		{ /* require use of factory method */ }

		public static app_groups Newapp_groups()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a app_groups");
			return DataPortal.Create<app_groups>();
		}

		public static app_groups Getapp_groups(int groupID)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a app_groups");
			return DataPortal.Fetch<app_groups>(new Criteria(groupID));
		}

		public static void Deleteapp_groups(int groupID)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a app_groups");
			DataPortal.Delete(new Criteria(groupID));
		}

		public override app_groups Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a app_groups");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a app_groups");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a app_groups");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static app_groups Newapp_groupsChild()
		{
			app_groups child = new app_groups();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static app_groups Getapp_groups(SafeDataReader dr)
		{
			app_groups child =  new app_groups();
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
			public int GroupID;

			public Criteria(int groupID)
			{
				this.GroupID = groupID;
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
				cm.CommandText = "";

				cm.Parameters.AddWithValue("@GroupID", criteria.GroupID);

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

				ExecuteInsert(cn);

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
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_groupID));
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
				cm.CommandText = "";

				cm.Parameters.AddWithValue("@GroupID", criteria.GroupID);

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
			_groupID = dr.GetInt32("GroupID");
			_tenChucNang = dr.GetString("TenChucNang");
		}

		private void FetchChildren(SafeDataReader dr)
		{
            _appMenuGroupList = AppMenuGroupList.GetAppMenuGroupList_byGroupID(dr.GetInt32("GroupID"));
        }
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			//ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_groupID = (int)cm.Parameters["@NewGroupID"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@TenChucNang", _tenChucNang);
			cm.Parameters.AddWithValue("@NewGroupID", _groupID);
			cm.Parameters["@NewGroupID"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@GroupID", _groupID);
			cm.Parameters.AddWithValue("@TenChucNang", _tenChucNang);
		}

		private void UpdateChildren(SqlConnection cn)
		{
            _appMenuGroupList.Update(cn, this); 
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_groupID));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
