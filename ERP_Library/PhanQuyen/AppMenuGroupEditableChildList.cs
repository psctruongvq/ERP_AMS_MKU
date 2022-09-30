using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class AppMenuGroupList : Csla.BusinessListBase<AppMenuGroupList, AppMenuGroup>
	{

		#region Factory Methods
		internal static AppMenuGroupList NewAppMenuGroupList()
		{
			return new AppMenuGroupList();
		}

		internal static AppMenuGroupList GetAppMenuGroupList(SafeDataReader dr)
		{
			return new AppMenuGroupList(dr);
		}

        internal static AppMenuGroupList GetAppMenuGroupList_byGroupID(int GroupID)
        {
            return DataPortal.Fetch<AppMenuGroupList>(new FilterCriteria_byGroupID(GroupID));
        }

        private AppMenuGroupList()
		{
			MarkAsChild();
		}

		private AppMenuGroupList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
        private class FilterCriteria_byGroupID
        {
            public int GroupID;

            public FilterCriteria_byGroupID(int GroupID)
            {
                this.GroupID = GroupID;
            }
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(AppMenuGroup.GetAppMenuGroup(dr));

			RaiseListChangedEvents = true;
		}
        protected override void DataPortal_Fetch(object criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                if (criteria is FilterCriteria_byGroupID)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblAppMenu"; 
                        cm.Parameters.AddWithValue("@GroupID", ((FilterCriteria_byGroupID)criteria).GroupID);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(AppMenuGroup.GetAppMenuGroup(dr));
                        }
                    }
                }
            }
        }

        internal void Update(SqlConnection cn, app_groups parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (AppMenuGroup deletedChild in DeletedList)
				deletedChild.DeleteSelf(cn);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (AppMenuGroup child in this)
			{
                //if(child.IsNew)
                //	child.Insert(cn, parent);
                //else
                //	child.Update(cn, parent);
                child.Insert(cn, parent);
			}

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
