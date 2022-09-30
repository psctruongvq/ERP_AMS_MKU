
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTac_Website_EmailList : Csla.BusinessListBase<DoiTac_Website_EmailList, DoiTac_Website_Email>
	{

		#region Factory Methods
		public static DoiTac_Website_EmailList NewDoiTac_Website_EmailList()
		{
			return new DoiTac_Website_EmailList();
		}

		public static DoiTac_Website_EmailList GetDoiTac_Website_EmailList(long maDoiTac)
		{
			//return new DoiTac_Website_EmailList(dr);
            return DataPortal.Fetch<DoiTac_Website_EmailList>(new FilterCriteria(maDoiTac));
		}

		public DoiTac_Website_EmailList()
		{
			MarkAsChild();
		}

		public DoiTac_Website_EmailList(SafeDataReader dr)
		{
			MarkAsChild();
			//Fetch(dr);
		}
		#endregion //Factory Methods


		#region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaDoiTac;

            public FilterCriteria(long MaDoiTac)
            {
                this.MaDoiTac = MaDoiTac;
            }
        }
        #endregion //Filter Criteria

        protected override void DataPortal_Fetch(object criteria)
        {
            if (criteria is FilterCriteria)
            {
                DataPortal_Fetch(criteria);
            }
            else
            {
                //tu bo sung khi can
            }
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
                cm.CommandText = "spd_SelecttblDoiTac_Website_EmailsAll";
                cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DoiTac_Website_Email.GetDoiTac_Website_Email(dr));
                }
            }//using
        }
       
		internal void Update(SqlTransaction tr, DoiTac parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (DoiTac_Website_Email deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (DoiTac_Website_Email child in this)
			{
				if(child.IsNew)
					child.Insert(tr, parent);
				else
					child.Update(tr, parent);
			}

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
