
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTy_NganHangList : Csla.BusinessListBase<CongTy_NganHangList, CongTy_NganHang>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CongTy_NganHang item = CongTy_NganHang.NewCongTy_NganHang();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CongTy_NganHangList NewCongTy_NganHangList()
		{
			return new CongTy_NganHangList();
		}

		public static CongTy_NganHangList GetCongTy_NganHangList()
		{
            return DataPortal.Fetch<CongTy_NganHangList>(new FilterCriteriaAll());
		}

        public static CongTy_NganHangList GetCongTy_NganHangList(int maCongTy)
        {
            return DataPortal.Fetch<CongTy_NganHangList>(new FilterCriteria(maCongTy));
        }

		private CongTy_NganHangList()
		{
			MarkAsChild();
		}

		private CongTy_NganHangList(SafeDataReader dr)
		{
			MarkAsChild();			
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
                cm.CommandText = "spd_Selecttblns_CongTy_NganHangsAll";
                cm.Parameters.AddWithValue("@MaCongTy", criteria.maCongTy);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongTy_NganHang.GetCongTy_NganHang(dr));
                }
            }//using
        }


		internal void Update(SqlTransaction tr, CongTy parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CongTy_NganHang deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CongTy_NganHang child in this)
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
