
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NguoiLienLacList : Csla.BusinessListBase<NguoiLienLacList, NguoiLienLac>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NguoiLienLac item = NguoiLienLac.NewNguoiLienLac();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static NguoiLienLacList NewNguoiLienLacList()
		{
			return new NguoiLienLacList();
		}

		public static NguoiLienLacList GetNguoiLienLacList(long maDoiTac)
		{
            return DataPortal.Fetch<NguoiLienLacList>(new FilterCriteria(maDoiTac));
		}

		public  NguoiLienLacList()
		{           
			MarkAsChild();
		}

		private NguoiLienLacList(SafeDataReader dr)
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
                cm.CommandText = "spd_SelecttblNguoiLienLacsAll";
                cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NguoiLienLac.GetNguoiLienLac(dr));
                }
            }//using
        }

		internal void Update(SqlTransaction tr, DoiTac parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (NguoiLienLac deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (NguoiLienLac child in this)
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
