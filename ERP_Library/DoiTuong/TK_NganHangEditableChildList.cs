
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TK_NganHangList : Csla.BusinessListBase<TK_NganHangList, TK_NganHang>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TK_NganHang item = TK_NganHang.NewTK_NganHang();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static TK_NganHangList NewTK_NganHangList()
		{
			return new TK_NganHangList();
		}

        public static TK_NganHangList GetTK_NganHangList(long maDoiTac)
        {
            return DataPortal.Fetch<TK_NganHangList>(new FilterCriteria(maDoiTac));
        }


		public TK_NganHangList()
		{
			MarkAsChild();
		}

		public TK_NganHangList(SafeDataReader dr)
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
                cm.CommandText = "spd_SelecttblTK_NganHangsAll";
                cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TK_NganHang.GetTK_NganHang(dr));
                }
            }
        }

        
        internal void Update(SqlTransaction tr, DoiTac parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (TK_NganHang deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (TK_NganHang child in this)
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
