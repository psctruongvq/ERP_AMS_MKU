
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_TheoDoiList : Csla.BusinessListBase<ChungTu_TheoDoiList, ChungTu_TheoDoi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChungTu_TheoDoi item = ChungTu_TheoDoi.NewChungTu_TheoDoi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ChungTu_TheoDoiList()
		{ /* require use of factory method */ }

		public static ChungTu_TheoDoiList NewChungTu_TheoDoiList()
		{
			return new ChungTu_TheoDoiList();
		}

		public static ChungTu_TheoDoiList GetChungTu_TheoDoiList()
		{
			return DataPortal.Fetch<ChungTu_TheoDoiList>(new FilterCriteria());
		}
        public static ChungTu_TheoDoiList GetChungTu_TheoDoiList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_TheoDoiList>(new FilterCriteriaByChungTu(maChungTu));
        }
        public static ChungTu_TheoDoiList GetChungTu_TheoDoiList(DateTime tuNgay,DateTime denNgay)
        {
            return DataPortal.Fetch<ChungTu_TheoDoiList>(new FilterCriteriaByNgay(tuNgay,denNgay));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        
        private class FilterCriteriaByChungTu
		{
            public long MaChungTu;
            public FilterCriteriaByChungTu(long maChungTu)
			{
                this.MaChungTu = maChungTu;
			}
		}
		private class FilterCriteria
		{

			public FilterCriteria()
			{

			}
		}
        private class FilterCriteriaByNgay
		{
            public DateTime tuNgay;
            public DateTime denNgay;
            public FilterCriteriaByNgay(DateTime tuNgay,DateTime denNgay)
			{
                this.tuNgay = tuNgay;
                this.denNgay = denNgay;
			}
		}
        
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "SelecttblChungTu_TheoDoisAll";
                }
                else if (criteria is FilterCriteriaByNgay)
                {
        
                    cm.CommandText = "SelecttblChungTu_TheoDoiByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgay)criteria).tuNgay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgay)criteria).denNgay.Date);
                    cm.Parameters.AddWithValue("@UserID",ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteriaByChungTu)
                {

                    cm.CommandText = "SelecttblChungTu_TheoDoiByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTu)criteria).MaChungTu);                    
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChungTu_TheoDoi.GetChungTu_TheoDoi(dr));
				}
			}//using

		}
		#endregion //Data Access - Fetch

       
		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					
                    foreach (ChungTu_TheoDoi child in this)
                    {
                        if (!child.IsNew)                       
                            child.Update(tr);
                    }

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
    
        public void DataPortal_Update(SqlTransaction tr, ChungTu  ChungTu)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ChungTu_TheoDoi deletedChild in DeletedList)
                    deletedChild.Dataportal_Delete(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChungTu_TheoDoi child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, ChungTu);
                    else
                        child.Update(tr, ChungTu);
                }
            }

            catch (Exception ex)
            {
             //   tr.Rollback();
                throw ex;
            }


            RaiseListChangedEvents = true;
        }
       
        public void DataPortal_Delete(SqlTransaction tr)
        {

            // loop through each deleted child object
            foreach (ChungTu_TheoDoi child in this)
            {
                child.Dataportal_Delete(tr);
            }

        }
		#endregion //Data Access
	}
}
