
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{

    [Serializable()]
    public class AccountList : Csla.BusinessListBase<AccountList, Account>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            Account item = Account.NewAccount();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in AccountList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AccountListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in AccountList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AccountListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in AccountList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AccountListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in AccountList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("AccountListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private AccountList()
        { /* require use of factory method */ }

        public static AccountList NewAccountList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a AccountList");
            return new AccountList();
        }

        public static AccountList GetAccountList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a AccountList");
            return DataPortal.Fetch<AccountList>(new FilterCriteria());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int AccountID;


            public FilterCriteria()
            {
             
            }

            public FilterCriteria(int accountID)
            {
                this.AccountID = accountID;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
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
                cm.CommandText = "HL_SelectAccountsAll";
                //cm.Parameters.AddWithValue("@AccountID", criteria.AccountID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(Account.GetAccount(dr));
                }
            }//using
        }

        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                //foreach (Account deletedChild in DeletedList)
                //    deletedChild.DeleteSelf(cn);
                //DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (Account child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn,this);
                    else
                        child.Update(cn,this);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}

