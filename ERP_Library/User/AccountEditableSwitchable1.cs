
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Account : Csla.BusinessBase<Account>
	{
		#region Business Properties and Methods

		//declare members
		private int _accountID = 0;
		private long _maNhanVien = 0;
		private string _username = string.Empty;
		private string _password = string.Empty;
		private string _info = string.Empty;
        private AccountRolesList _AccountRolesList = AccountRolesList.NewAccountRolesList();


        public AccountRolesList AccountRolesList
        {
            get
            {
                CanReadProperty("AccountRolesList", true);
                return _AccountRolesList;
            }
            set
            {
                CanWriteProperty("AccountRolesList", true);
                if (!_AccountRolesList.Equals(value))
                {
                    _AccountRolesList = value;
                    PropertyHasChanged("AccountRolesList");
                }
            }
        }


		[System.ComponentModel.DataObjectField(true, true)]
		public int AccountID
		{
			get
			{
				CanReadProperty("AccountID", true);
				return _accountID;
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

		public string Username
		{
			get
			{
				CanReadProperty("Username", true);
				return _username;
			}
			set
			{
				CanWriteProperty("Username", true);
				if (value == null) value = string.Empty;
				if (!_username.Equals(value))
				{
					_username = value;
					PropertyHasChanged("Username");
				}
			}
		}

		public string Password
		{
			get
			{
				CanReadProperty("Password", true);
				return _password;
			}
			set
			{
				CanWriteProperty("Password", true);
				if (value == null) value = string.Empty;
				if (!_password.Equals(value))
				{
					_password = value;
					PropertyHasChanged("Password");
				}
			}
		}

		public string Info
		{
			get
			{
				CanReadProperty("Info", true);
				return _info;
			}
			set
			{
				CanWriteProperty("Info", true);
				if (value == null) value = string.Empty;
				if (!_info.Equals(value))
				{
					_info = value;
					PropertyHasChanged("Info");
				}
			}
		}
        
        public override bool IsValid
        {
            get
            {
                return base.IsValid && _AccountRolesList.IsValid;
            }
        }

        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _AccountRolesList.IsDirty;
            }
        }
        
		protected override object GetIdValue()
		{
			return _accountID;
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
			// Username
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "Username");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Username", 50));
			//
			// Password
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "Password");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Password", 50));
			//
			// Info
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Info", 500));
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
			//TODO: Define authorization rules in Account
			//AuthorizationRules.AllowRead("AccountID", "AccountReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "AccountReadGroup");
			//AuthorizationRules.AllowRead("Username", "AccountReadGroup");
			//AuthorizationRules.AllowRead("Password", "AccountReadGroup");
			//AuthorizationRules.AllowRead("Info", "AccountReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "AccountWriteGroup");
			//AuthorizationRules.AllowWrite("Username", "AccountWriteGroup");
			//AuthorizationRules.AllowWrite("Password", "AccountWriteGroup");
			//AuthorizationRules.AllowWrite("Info", "AccountWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in Account
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("AccountViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in Account
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("AccountAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in Account
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("AccountEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in Account
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("AccountDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private Account()
		{ /* require use of factory method */ }

		public static Account NewAccount()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Account");
			return DataPortal.Create<Account>();
		}

		public static Account GetAccount()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Account");
			return DataPortal.Fetch<Account>(new Criteria());
		}

        //public static void DeleteAccount(int accountID)
        //{
        //    if (!CanDeleteObject())
        //        throw new System.Security.SecurityException("User not authorized to remove a Account");
        //    DataPortal.Delete(new Criteria(accountID));
        //}

		public override Account Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Account");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Account");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a Account");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static Account NewAccountChild()
		{
			Account child = new Account();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static Account GetAccount(SafeDataReader dr)
		{
			Account child =  new Account();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

        public int GetAccountID(string UserName,SqlConnection cnn)
        {
            // SELECT AccountID 
            //   FROM Account 
            //  WHERE UserName=@UserName

            int retval = -1;
            cnn.Open();
            SqlCommand Command = new SqlCommand("HL_Account_GetAccountID", cnn);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@UserName", SqlDbType.Char, 32));
            Command.Parameters["@UserName"].Value = UserName;

           
                SqlDataReader dr = Command.ExecuteReader();

                if (dr.Read())
                {
                    retval = Convert.ToInt32(dr["AccountID"]);
                }
                        
              return retval;
        }

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public Criteria()
			{
				
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
                cm.CommandText = "HL_SelectAccount";

                cm.Parameters.AddWithValue("@MaNhanVien", DangNhap._MaNguoiSuDung);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					if(dr.Read())
					FetchObject(dr);
                    //ValidationRules.CheckRules();

					//load child object(s)
					//FetchChildren(dr);
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

				ExecuteInsert(cn,null);

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

        public void DataPortal_UpdateLong()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                ExecuteUpdate(cn, null);

            }//using

        }
		#endregion //Data Access - Update

		#region Data Access - Delete
        //protected override void DataPortal_DeleteSelf()
        //{
        //    DataPortal_Delete(new Criteria(_accountID));
        //}

        //private void DataPortal_Delete(Criteria criteria)
        //{
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();

        //        ExecuteDelete(cn, criteria);

        //    }//using

        //}

        //private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        //{
        //    using (SqlCommand cm = cn.CreateCommand())
        //    {
        //        cm.CommandType = CommandType.StoredProcedure;
        //        cm.CommandText = "HL_DeleteAccount";

        //        cm.Parameters.AddWithValue("@AccountID", criteria.AccountID);

        //        cm.ExecuteNonQuery();
        //    }//using
        //}
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
			_accountID = dr.GetInt32("AccountID");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_username = dr.GetString("Username");
			_password = dr.GetString("Password");
			_info = dr.GetString("Info");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, AccountList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, AccountList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "HL_InsertAccount";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_accountID = (int)cm.Parameters["@AccountID"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, AccountList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@Username", _username);
			cm.Parameters.AddWithValue("@Password", _password);
			if (_info.Length > 0)
				cm.Parameters.AddWithValue("@Info", _info);
			else
				cm.Parameters.AddWithValue("@Info", DBNull.Value);
			cm.Parameters.AddWithValue("@AccountID", _accountID);
			cm.Parameters["@AccountID"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, AccountList parent)
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

		private void ExecuteUpdate(SqlConnection cn, AccountList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "HL_UpdateAccount";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, AccountList parent)
		{			
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);		
			cm.Parameters.AddWithValue("@Password", _password);
			
		}

		private void UpdateChildren(SqlConnection cn)
		{
            _AccountRolesList.Update(cn, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
        //internal void DeleteSelf(SqlConnection cn)
        //{
        //    if (!IsDirty) return;
        //    if (IsNew) return;

        //    ExecuteDelete(cn, new Criteria(_accountID));
        //    MarkNew();
        //}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
