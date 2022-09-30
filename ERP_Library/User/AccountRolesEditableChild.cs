
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class AccountRoles : Csla.BusinessBase<AccountRoles>
	{
		#region Business Properties and Methods

		//declare members
		private int _accountID = 0;
        private int _rolesID = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public int AccountID
		{
			get
			{
				CanReadProperty("AccountID", true);
				return _accountID;
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
        public int RolesID
		{
			get
			{
                CanReadProperty("RolesID", true);
				return _rolesID;
			}
		}
 
		protected override object GetIdValue()
		{
			return string.Format("{0}:{1}", _accountID, _rolesID);
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
			//TODO: Define authorization rules in AccountRoles
			//AuthorizationRules.AllowRead("AccountID", "AccountRolesReadGroup");
			//AuthorizationRules.AllowRead("RoleID", "AccountRolesReadGroup");

		}

		#endregion //Authorization Rules

		#region Factory Methods
        public static AccountRoles NewAccountRoles(int accountID, int rolesID)
		{
            return new AccountRoles(accountID, rolesID);
		}

		internal static AccountRoles GetAccountRoles(SafeDataReader dr)
		{
			return new AccountRoles(dr);
		}

		private AccountRoles(int accountID, int rolesID)
		{
			this._accountID = accountID;
            this._rolesID = rolesID;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private AccountRoles(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods


		#region Data Access

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
			_accountID = dr.GetInt32("AccountID");
			_rolesID = dr.GetInt32("RolesID");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, Account parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, Account parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "HL_InsertAccountRole";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, Account parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@AccountID", parent.AccountID);
			cm.Parameters.AddWithValue("@RolesID", _rolesID);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, Account parent)
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

		private void ExecuteUpdate(SqlConnection cn, Account parent)
		{
            ExecuteDelete(cn);
            ExecuteInsert(cn, parent);
            //using (SqlCommand cm = cn.CreateCommand())
            //{
            //    cm.CommandType = CommandType.StoredProcedure;
            //    cm.CommandText = "HL_UpdateAccountRole";

            //    AddUpdateParameters(cm, parent);

            //    cm.ExecuteNonQuery();

            //}//using
		}

		private void AddUpdateParameters(SqlCommand cm, Account parent)
		{
            cm.Parameters.AddWithValue("@AccountID", parent.AccountID);
			cm.Parameters.AddWithValue("@RolesID", _rolesID);
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

			ExecuteDelete(cn);
			MarkNew();
		}

		private void ExecuteDelete(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "HL_DeleteAccountRole";

				cm.Parameters.AddWithValue("@AccountID", this._accountID);
				

				cm.ExecuteNonQuery();
			}//using
		}
        public void ExecuteDelete1(SqlConnection cn)
        {
          
                cn.Open();
           
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "HL_DeleteAccountRole";

                    cm.Parameters.AddWithValue("@AccountID", this._accountID);


                    cm.ExecuteNonQuery();
                }//using
            
        }
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
