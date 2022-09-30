
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTy_Website_EmailList : Csla.BusinessListBase<CongTy_Website_EmailList, CongTy_Website_Email>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongTy_Website_Email item = CongTy_Website_Email.NewCongTy_Website_Email();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		public static CongTy_Website_EmailList NewCongTy_Website_EmailList()
		{
			return new CongTy_Website_EmailList();
		}

		public static CongTy_Website_EmailList GetCongTy_Website_EmailList()
		{
			//return new CongTy_Website_EmailList(dr);
            return DataPortal.Fetch<CongTy_Website_EmailList>(new FilterCriteriaAll());
		}

        public static CongTy_Website_EmailList GetCongTy_Website_EmailList(int maCongTy)
        {
            //return new CongTy_Website_EmailList(dr);
            return DataPortal.Fetch<CongTy_Website_EmailList>(new FilterCriteria(maCongTy));
        }


		public CongTy_Website_EmailList()
		{
			MarkAsChild();
		}

		public CongTy_Website_EmailList(SafeDataReader dr)
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
            public int maCongTy;

            public FilterCriteria(int maCongTy)
            {
                this.maCongTy = maCongTy;
            }
        }

        [Serializable()]
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
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
                cm.CommandText = "spd_SelecttblCongTy_Website_EmailsAll";
                cm.Parameters.AddWithValue("@MaCongTy", criteria.maCongTy);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongTy_Website_Email.GetCongTy_Website_Email(dr));
                }
            }//using
        }



		internal void Update(SqlTransaction tr, CongTy parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CongTy_Website_Email deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CongTy_Website_Email child in this)
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
