
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class AccountRolesList : Csla.BusinessListBase<AccountRolesList, AccountRoles>
	{

		#region Factory Methods
		public static AccountRolesList NewAccountRolesList()
		{
			return new AccountRolesList();
		}
        public static AccountRolesList GetAccountRolesListForID(int accountID)
        {            
            return DataPortal.Fetch<AccountRolesList>(new FilterCriteria(accountID));
        }
		internal static AccountRolesList GetAccountRolesList(SafeDataReader dr)
		{
			return new AccountRolesList(dr);
		}

		private AccountRolesList()
		{
			MarkAsChild();
		}

		private AccountRolesList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int AccountID;            

            public FilterCriteria(int accountID)
            {
                this.AccountID = accountID;
            }
        }
        #endregion //Filter Criteria

		#region Data Access
		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(AccountRoles.GetAccountRoles(dr));

			RaiseListChangedEvents = true;
		}

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "HL_AccountRoles_GetRolesForID";
                cm.Parameters.AddWithValue("@AccountID", criteria.AccountID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(AccountRoles.GetAccountRoles(dr));
                }
            }//using
        }

		internal void Update(SqlConnection cn, Account parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (AccountRoles deletedChild in DeletedList)
				deletedChild.DeleteSelf(cn);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (AccountRoles child in this)
			{
				if(child.IsNew)
					child.Insert(cn, parent);
				else
					child.Update(cn, parent);
			}

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
