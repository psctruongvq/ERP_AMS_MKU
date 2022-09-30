
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoPhan_LuongList : Csla.BusinessListBase<BoPhan_LuongList, BoPhan_Luong>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoPhan_LuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_LuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoPhan_LuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_LuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoPhan_LuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_LuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoPhan_LuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhan_LuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoPhan_LuongList()
		{ /* require use of factory method */ }

		public static BoPhan_LuongList NewBoPhan_LuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhan_LuongList");
			return new BoPhan_LuongList();
		}

		public static BoPhan_LuongList GetBoPhan_LuongList(int maLoaiLuong, int maBoPhan, int maQuyLuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhan_LuongList");
			return DataPortal.Fetch<BoPhan_LuongList>(new FilterCriteria(maLoaiLuong, maBoPhan, maQuyLuong));
		}
        public static BoPhan_LuongList GetBoPhan_LuongListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan_LuongList");
            return DataPortal.Fetch<BoPhan_LuongList>(new BoPhan_LuongListAll());
        }
        public static BoPhan_LuongList GetBoPhan_LuongListByMaBoPhan(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan_LuongList");
            return DataPortal.Fetch<BoPhan_LuongList>(new BoPhan_LuongListByMaBoPhan(maBoPhan));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaLoaiLuong;
			public int MaBoPhan;
			public int MaQuyLuong;

			public FilterCriteria(int maLoaiLuong, int maBoPhan, int maQuyLuong)
			{
				this.MaLoaiLuong = maLoaiLuong;
				this.MaBoPhan = maBoPhan;
				this.MaQuyLuong = maQuyLuong;
			}
		}
        private class BoPhan_LuongListAll
		{
			
            public BoPhan_LuongListAll()
			{
				
			}
		}
        private class BoPhan_LuongListByMaBoPhan
		{
            public int maBoPhan;
            public BoPhan_LuongListByMaBoPhan(int maBoPhan)
			{
                this.maBoPhan = maBoPhan;
			}
		}
        
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is BoPhan_LuongListAll)
                {
                    cm.CommandText = "sp_SelecttblnsBoPhan_LuongsAll";
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "sp_SelecttblnsBoPhan_Luong";
                    cm.Parameters.AddWithValue("@MaLoaiLuong",((FilterCriteria)criteria).MaLoaiLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                   // cm.Parameters.AddWithValue("@MaQuyLuong", ((FilterCriteria)criteria).MaQuyLuong);
                }
                else if (criteria is BoPhan_LuongListByMaBoPhan)
                {
                    cm.CommandText = "sp_SelecttblnsBoPhan_LuongByMaBoPhan";                    
                    cm.Parameters.AddWithValue("@MaBoPhan", ((BoPhan_LuongListByMaBoPhan)criteria).maBoPhan);                    
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BoPhan_Luong.GetBoPhan_Luong(dr));
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
					foreach (BoPhan_Luong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BoPhan_Luong child in this)
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
