
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhoaSo_UserList : Csla.BusinessListBase<KhoaSo_UserList, KhoaSo_User>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KhoaSo_User item = KhoaSo_User.NewKhoaSo_User();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private KhoaSo_UserList()
		{ /* require use of factory method */ }

		public static KhoaSo_UserList NewKhoaSo_UserList()
		{
			return new KhoaSo_UserList();
		}
        public static KhoaSo_UserList GetKhoaSo_UserList()
        {
            return DataPortal.Fetch<KhoaSo_UserList>(new FilterCriteriaAll());
        }
		public static KhoaSo_UserList GetKhoaSo_UserList(int maKy)
		{
			return DataPortal.Fetch<KhoaSo_UserList>(new FilterCriteria(maKy));
		}
        public static KhoaSo_UserList GetKhoaSo_UserListByNgayLap(DateTime ngayLap)
        {
            return DataPortal.Fetch<KhoaSo_UserList>(new FilterCriteriaByNgayLap(ngayLap));
        }

        #region Bosung
        public static bool KiemTraTonTaiKhoaSoUserListtheoKy(int MaKy)
        {
            bool giaTriTraVe = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraTonTaiKhoaSoUserListtheoKy";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }
        #endregion
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
         private class FilterCriteriaByNgayLap
        {
             public DateTime NgayLap;
             public FilterCriteriaByNgayLap(DateTime ngayLap)
            {
                this.NgayLap = ngayLap;
            }
         }
        
		private class FilterCriteria
		{
			public int MaKy;

			public FilterCriteria(int maKy)
			{
				this.MaKy = maKy;
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
                if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "SelecttblKhoaSo_UsersAll";
                    
                }
                else if(criteria is FilterCriteria)
                {
                    cm.CommandText = "SelecttblKhoaSoByKy";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteria)criteria).MaKy);
                }
                else if (criteria is FilterCriteriaByNgayLap)
                {
                    cm.CommandText = "SelecttblKhoaSoByNgayLap";
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaByNgayLap)criteria).NgayLap);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(KhoaSo_User.GetKhoaSo_User(dr));
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
					// loop through each deleted child object
                    //foreach (KhoaSo_User deletedChild in DeletedList)
                    //    deletedChild.DeleteSelf(tr);
                    //DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KhoaSo_User child in this)
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
		#endregion //Data Access
	}
}
