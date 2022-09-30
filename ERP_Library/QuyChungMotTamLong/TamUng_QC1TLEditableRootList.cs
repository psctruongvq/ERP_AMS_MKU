
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUng_QC1TLList : Csla.BusinessListBase<TamUng_QC1TLList, TamUng_QC1TL>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TamUng_QC1TL item = TamUng_QC1TL.NewTamUng_QC1TL();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
        private TamUng_QC1TLList()
		{ /* require use of factory method */ }

        public static TamUng_QC1TLList NewTamUng_QC1TLList()
		{
            return new TamUng_QC1TLList();
		}
        public static TamUng_QC1TLList GetTamUng_QC1TLList()
        {
            return DataPortal.Fetch<TamUng_QC1TLList>(new FilterCriteriaAll());
        }
        public static TamUng_QC1TLList GetTamUng_QC1TLList(long maChungTu)
        {
            return DataPortal.Fetch<TamUng_QC1TLList>(new FilterCriteriaByChungTu(maChungTu));
        }
        public static TamUng_QC1TLList GetTamUng_QC1TLList(long maDoiTuong, long maChungTu)
		{
            return DataPortal.Fetch<TamUng_QC1TLList>(new FilterCriteria(maDoiTuong, maChungTu));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        
          private class FilterCriteriaAll
		{		
			
            public FilterCriteriaAll()
			{			
				
			}
		}
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
			public long MaDoiTuong;
			public long MaChungTu;

			public FilterCriteria(long maDoiTuong, long maChungTu)
			{
				this.MaDoiTuong = maDoiTuong;
				this.MaChungTu = maChungTu;
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
                    cm.CommandText = "spd_SelecttblTamUng_QC1TLsAll";
                }
                else if (criteria is FilterCriteriaByChungTu)
                {
                    cm.CommandText = "spd_SelecttblTamUngByChungTu_QC1TL";
                    cm.Parameters.AddWithValue("@MaChungTu",((FilterCriteriaByChungTu)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblTamUng_QC1TLByChungTuDoiTuong";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria)criteria).MaChungTu);
                    cm.Parameters.AddWithValue("@MaDoiTuong", ((FilterCriteria)criteria).MaDoiTuong);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
                        this.Add(TamUng_QC1TL.GetTamUng_QC1TL(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch
        #region Data Access - Update
        public void DataPortal_Update(SqlTransaction tr, long MaChungTu,string soChungTu)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (TamUng_QC1TL deletedChild in DeletedList)
                    deletedChild.Dataportal_Delete(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (TamUng_QC1TL child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, MaChungTu, soChungTu);
                    else
                        child.Update(tr, MaChungTu, soChungTu);
                }
            }

            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }


            RaiseListChangedEvents = true;
        }
        public void DataPortal_Delete(SqlTransaction tr, long MaChungTu)
        {

            // loop through each deleted child object
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblTamUng_QC1TLByChungTu";

                cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);

                cm.ExecuteNonQuery();
            }//using
        }
        public void DataPortal_Delete(SqlTransaction tr)
        {

            // loop through each deleted child object
            foreach (TamUng_QC1TL child in this)
            {
                child.Dataportal_Delete(tr);
            }

        }
        #endregion //Data Access - Update
        
		#endregion //Data Access
	}
}
