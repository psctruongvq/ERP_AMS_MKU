
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTuongTheoDoiList : Csla.BusinessListBase<DoiTuongTheoDoiList, DoiTuongTheoDoi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			DoiTuongTheoDoi item = DoiTuongTheoDoi.NewDoiTuongTheoDoi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private DoiTuongTheoDoiList()
		{ /* require use of factory method */ }

		public static DoiTuongTheoDoiList NewDoiTuongTheoDoiList()
		{
			return new DoiTuongTheoDoiList();
		}
        public static DoiTuongTheoDoiList GetDoiTuongTheoDoiList()
        {
               return DataPortal.Fetch<DoiTuongTheoDoiList>(new FilterCriteria());
        }
        
		
        public static DoiTuongTheoDoiList GetDoiTuongTheoDoiListByTaiKhoan(int MaTaiKhoan)
        {
             return DataPortal.Fetch<DoiTuongTheoDoiList>(new FilterCriteriaByTaiKhoan(MaTaiKhoan));
        }

        public static DoiTuongTheoDoiList GetDoiTuongTheoDoiListByMaDoiTuong(long maDoiTuong)
        {
            return DataPortal.Fetch<DoiTuongTheoDoiList>(new FilterCriteriaByMaDoiTuong(maDoiTuong));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        private class FilterCriteriaByTaiKhoan
        {
            public int MaTaiKhoan;
            public FilterCriteriaByTaiKhoan(int mataikhoan)
            {
                MaTaiKhoan = mataikhoan;
            }
        }
		private class FilterCriteria
		{
			
			public FilterCriteria()
			{
			
			}
		}

        [Serializable()]
        private class FilterCriteriaByMaDoiTuong
        {
            public long MaDoiTuong;
            public FilterCriteriaByMaDoiTuong(long maDoiTuong)
            {
                MaDoiTuong = maDoiTuong;
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
                    cm.CommandText = "sp_SelecttblDoiTuongTheoDoisAll";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteriaByTaiKhoan)
                {
                    cm.CommandText = "sp_SelecttblDoiTuongTheoDoisAllByTaiKhoan";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteriaByTaiKhoan)criteria).MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                }

                else if (criteria is FilterCriteriaByMaDoiTuong)
                {
                    cm.CommandText = "sp_SelecttblDoiTuongTheoDoisAllByMaDoiTuong";
                    cm.Parameters.AddWithValue("@MaDoiTuong", ((FilterCriteriaByMaDoiTuong)criteria).MaDoiTuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DoiTuongTheoDoi.GetDoiTuongTheoDoi(dr));
                }
            }//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
        internal void Update(SqlTransaction tr, DoiTac parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (DoiTuongTheoDoi deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (DoiTuongTheoDoi child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
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
					foreach (DoiTuongTheoDoi deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (DoiTuongTheoDoi child in this)
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
					tr.Rollback();
					throw;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
