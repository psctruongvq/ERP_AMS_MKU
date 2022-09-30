
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class UserChildList : Csla.BusinessListBase<UserChildList, UserChild>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			UserChild item = UserChild.NewUserChild();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private UserChildList()
		{ /* require use of factory method */ }

		public static UserChildList NewUserChildList()
		{
			return new UserChildList();
		}

		public static UserChildList GetUserChildList(int userID)
		{
			return DataPortal.Fetch<UserChildList>(new FilterCriteria(userID));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int UserID;
			public FilterCriteria(int userID)
			{
                this.UserID = userID;
			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
		{
			RaiseListChangedEvents = false;

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

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Selectapp_UserChildsAll";
                cm.Parameters.AddWithValue("@UserID", ((FilterCriteria)criteria).UserID);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(UserChild.GetUserChild(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
        internal void Update(SqlTransaction tr, Security.UserItem parent)
        {
            RaiseListChangedEvents = false;




            //tr = cn.BeginTransaction();
            try
            {
                // loop through each deleted child object
                foreach (UserChild deletedChild in DeletedList)
                {



                    deletedChild.DeleteSelf(tr);
                }
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (UserChild child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }

                //tr.Commit();
            }
            catch
            {
                // tr.Rollback();
                throw;
            }

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
