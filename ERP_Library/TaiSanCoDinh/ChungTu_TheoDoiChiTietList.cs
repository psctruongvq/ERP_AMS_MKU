
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_TheoDoiChiTietList : Csla.BusinessListBase<ChungTu_TheoDoiChiTietList, ChungTu_TheoDoiChiTiet>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChungTu_TheoDoiChiTiet item = ChungTu_TheoDoiChiTiet.NewChungTu_TheoDoiChiTiet();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ChungTu_TheoDoiChiTietList()
		{ /* require use of factory method */ }

		public static ChungTu_TheoDoiChiTietList NewChungTu_TheoDoiChiTietList()
		{
			return new ChungTu_TheoDoiChiTietList();
		}

		public static ChungTu_TheoDoiChiTietList GetChungTu_TheoDoiChiTietList(int maTheoDoi)
		{
			return DataPortal.Fetch<ChungTu_TheoDoiChiTietList>(new FilterCriteria(maTheoDoi));
		}
        public static ChungTu_TheoDoiChiTietList GetChungTu_TheoDoiChiTietList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_TheoDoiChiTietList>(new FilterCriteriaByChungTu(maChungTu));
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
			public int MaTheoDoi;

			public FilterCriteria(int maTheoDoi)
			{
				this.MaTheoDoi = maTheoDoi;
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

				
				try
				{
					ExecuteFetch(cn, criteria);

					
				}
				catch
				{
				//	tr.Rollback();
					throw;
				}
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
			
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "SelecttblChungTu_TheoDoiChiTietByMaTheoDoi";
                    cm.Parameters.AddWithValue("@MaTheoDoi", ((FilterCriteria)criteria).MaTheoDoi);
                }
                else if (criteria is FilterCriteriaByChungTu)
                {
                    cm.CommandText = "SelecttblChungTu_TheoDoiChiTietByChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTu)criteria).MaChungTu);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChungTu_TheoDoiChiTiet.GetChungTu_TheoDoiChiTiet(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		internal  void DataPortal_Update(SqlTransaction tr,ChungTu_TheoDoi parent)
		{
			RaiseListChangedEvents = false;	
				
				try
				{
					// loop through each deleted child object
					foreach (ChungTu_TheoDoiChiTiet deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ChungTu_TheoDoiChiTiet child in this)
					{
						if (child.IsNew)
                            child.Insert(tr);
						else
                            child.Update(tr);
					}

				//	tr.Commit();
				}
				catch
				{
					//tr.Rollback();
					throw;
				}
		

			RaiseListChangedEvents = true;
		}
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
                    foreach (ChungTu_TheoDoiChiTiet deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTu_TheoDoiChiTiet child in this)
                    {
                       
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                  //  tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
