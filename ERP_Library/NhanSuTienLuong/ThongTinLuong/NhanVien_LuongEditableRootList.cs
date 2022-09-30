
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_LuongList : Csla.BusinessListBase<NhanVien_LuongList, NhanVien_Luong>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhanVien_LuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVien_LuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhanVien_LuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVien_LuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhanVien_LuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVien_LuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhanVien_LuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVien_LuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NhanVien_LuongList()
		{ /* require use of factory method */ }

		public static NhanVien_LuongList NewNhanVien_LuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhanVien_LuongList");
			return new NhanVien_LuongList();
		}
        //
		public static NhanVien_LuongList GetNhanVien_LuongList(int maLoaiLuong, int maBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhanVien_LuongList");
			return DataPortal.Fetch<NhanVien_LuongList>(new FilterCriteria(maLoaiLuong, maBoPhan));
        }//
        public static NhanVien_LuongList GetNhanVien_LuongListByBoPhan(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_LuongList");
            return DataPortal.Fetch<NhanVien_LuongList>(new NhanVien_LuongListByBoPhan(maBoPhan));
        }//
        public static NhanVien_LuongList GetNhanVien_LuongListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_LuongList");
            return DataPortal.Fetch<NhanVien_LuongList>(new FilterCriteriaAll());
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaLoaiLuong;
			//public long MaNhanVien;
			public int MaBoPhan;

			public FilterCriteria(int maLoaiLuong, int MaBoPhan)
			{
				this.MaLoaiLuong = maLoaiLuong;
				//this.MaNhanVien = maNhanVien;
                this.MaBoPhan = MaBoPhan;
			}
		}
        [Serializable()]
        private class FilterCriteriaAll
		{

            public FilterCriteriaAll()
			{
				
			}
		}
         [Serializable()]
        private class NhanVien_LuongListByBoPhan
		{
            public int maBoPhan;
            public NhanVien_LuongListByBoPhan(int maBoPhan)
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
				catch (Exception ex)
				{
					tr.Rollback();
					throw ex;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "sp_SelecttblnsNhanVien_LuongByMaBoPhan_MaLoaiLuong";
                    cm.Parameters.AddWithValue("@MaLoaiLuong",((FilterCriteria) criteria).MaLoaiLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan",((FilterCriteria) criteria).MaBoPhan);
                   // cm.Parameters.AddWithValue("@MaQuyLuong", ((FilterCriteria)criteria).MaQuyLuong);
                }
                else if (criteria is NhanVien_LuongListByBoPhan)
                {
                    cm.CommandText = "sp_SelecttblnsNhanVien_LuongByMaBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((NhanVien_LuongListByBoPhan)criteria).maBoPhan);
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "sp_SelecttblnsNhanVien_LuongsAll";
                    
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NhanVien_Luong.GetNhanVien_Luong(dr));
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
					foreach (NhanVien_Luong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (NhanVien_Luong child in this)
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
