
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTac_DienThoai_FaxList : Csla.BusinessListBase<DoiTac_DienThoai_FaxList, DoiTac_DienThoai_Fax>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			DoiTac_DienThoai_Fax item = DoiTac_DienThoai_Fax.NewDoiTac_DienThoai_Fax();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static DoiTac_DienThoai_FaxList NewDoiTac_DienThoai_FaxList()
		{
			return new DoiTac_DienThoai_FaxList();
		}

		public static DoiTac_DienThoai_FaxList GetDoiTac_DienThoai_FaxList(long maDoiTac)
		{
            return DataPortal.Fetch<DoiTac_DienThoai_FaxList>(new FilterCriteria(maDoiTac));
		}

        public static DoiTac_DienThoai_FaxList GetDoiTac_DienThoai_FaxList()
        {
            return DataPortal.Fetch<DoiTac_DienThoai_FaxList>(new FilterCriteriaAll());
        }
        public DoiTac_DienThoai_FaxList()
		{
            //DoiTac_DienThoai_Fax _DoiTac_DienThoai_Fax = DoiTac_DienThoai_Fax.NewDoiTac_DienThoai_Fax();
            //this.Add(_DoiTac_DienThoai_Fax);
			MarkAsChild();
		}

		private DoiTac_DienThoai_FaxList(SafeDataReader dr)
		{
			MarkAsChild();			
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
                cm.CommandText = "spd_SelecttblDoiTac_DienThoai_FaxesAll";
                cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DoiTac_DienThoai_Fax.GetDoiTac_DienThoai_Fax(dr));
                }
            }//using
        }

       
		internal void Update(SqlTransaction tr, DoiTac parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (DoiTac_DienThoai_Fax deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (DoiTac_DienThoai_Fax child in this)
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
