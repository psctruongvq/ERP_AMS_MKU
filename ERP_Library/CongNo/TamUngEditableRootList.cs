
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUngList : Csla.BusinessListBase<TamUngList, TamUng>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TamUng item = TamUng.NewTamUng();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private TamUngList()
		{ /* require use of factory method */ }

		public static TamUngList NewTamUngList()
		{
			return new TamUngList();
		}
        public static TamUngList GetTamUngList()
        {
            return DataPortal.Fetch<TamUngList>(new FilterCriteriaAll());
        }
        public static TamUngList GetTamUngList(long maChungTu)
        {
            return DataPortal.Fetch<TamUngList>(new FilterCriteriaByChungTu( maChungTu));
        }
		public static TamUngList GetTamUngList(long maDoiTuong, long maChungTu)
		{
			return DataPortal.Fetch<TamUngList>(new FilterCriteria(maDoiTuong, maChungTu));
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
                    cm.CommandText = "SelecttblTamUngsAll";
                }
                else if (criteria is FilterCriteriaByChungTu)
                {
                    cm.CommandText = "SelecttblTamUngByChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu",((FilterCriteriaByChungTu)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "SelecttblTamUngByChungTuDoiTuong";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria)criteria).MaChungTu);
                    cm.Parameters.AddWithValue("@MaDoiTuong", ((FilterCriteria)criteria).MaDoiTuong);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TamUng.GetTamUng(dr));
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
                foreach (TamUng deletedChild in DeletedList)
                    deletedChild.Dataportal_Delete(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (TamUng child in this)
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
                cm.CommandText = "spd_DeletetblTamUngByChungTu";

                cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);

                cm.ExecuteNonQuery();
            }//using
        }
        public void DataPortal_Delete(SqlTransaction tr)
        {

            // loop through each deleted child object
            foreach (TamUng child in this)
            {
                child.Dataportal_Delete(tr);
            }

        }
        #endregion //Data Access - Update
        /*
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
					// loop through each deleted child object
					foreach (TamUng deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TamUng child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr,this);
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
        */
		#endregion //Data Access
	}
}
