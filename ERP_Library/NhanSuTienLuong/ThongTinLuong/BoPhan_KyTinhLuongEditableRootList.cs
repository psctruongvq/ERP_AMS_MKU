
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoPhan_KyTinhLuongList : Csla.BusinessListBase<BoPhan_KyTinhLuongList, BoPhan_KyTinhLuong>
	{
        protected override object AddNewCore()
        {

            BoPhan_KyTinhLuong item = BoPhan_KyTinhLuong.NewBoPhan_KyTinhLuong();
            this.Add(item);
            return item;
        }
		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoPhan_KyTinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_KyTinhLuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoPhan_KyTinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_KyTinhLuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoPhan_KyTinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_KyTinhLuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoPhan_KyTinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_KyTinhLuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoPhan_KyTinhLuongList()
		{ /* require use of factory method */ }

		public static BoPhan_KyTinhLuongList NewBoPhan_KyTinhLuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhan_KyTinhLuongList");
			return new BoPhan_KyTinhLuongList();
		}

		public static BoPhan_KyTinhLuongList GetBoPhan_KyTinhLuongListAll()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhan_KyTinhLuongList");
			return DataPortal.Fetch<BoPhan_KyTinhLuongList>(new FilterCriteria());
		}
        public static BoPhan_KyTinhLuongList GetBoPhan_KyTinhLuongListByKyTinhLuong(int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan_KyTinhLuongList");
            return DataPortal.Fetch<BoPhan_KyTinhLuongList>(new FilterCriteriaKyTinhLuong(maKyTinhLuong));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			
			public FilterCriteria()
			{
				
			}
		}
         private class FilterCriteriaKyTinhLuong
		{
			
			public int MaKyTinhLuong;

			public FilterCriteriaKyTinhLuong(int maKyTinhLuong)
			{				
				this.MaKyTinhLuong = maKyTinhLuong;
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
                    cm.CommandText = "sp_SelecttblnsBoPhan_KyTinhLuongsAll";
                }
                else if (criteria is FilterCriteriaKyTinhLuong)
                {
                    cm.CommandText = "sp_SelecttblnsBoPhan_KyTinhLuong_ByKyTinhLuong";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong",((FilterCriteriaKyTinhLuong) criteria).MaKyTinhLuong);
                }
				//cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
				//cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BoPhan_KyTinhLuong.GetBoPhan_KyTinhLuong(dr));
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
					foreach (BoPhan_KyTinhLuong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BoPhan_KyTinhLuong child in this)
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
