
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoatDong_ChiPhiHoatDongList : Csla.BusinessListBase<HoatDong_ChiPhiHoatDongList, HoatDong_ChiPhiHoatDong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HoatDong_ChiPhiHoatDong item = HoatDong_ChiPhiHoatDong.NewHoatDong_ChiPhiHoatDong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private HoatDong_ChiPhiHoatDongList()
		{ /* require use of factory method */ }

		public static HoatDong_ChiPhiHoatDongList NewHoatDong_ChiPhiHoatDongList()
		{
			return new HoatDong_ChiPhiHoatDongList();
		}

		public static HoatDong_ChiPhiHoatDongList GetHoatDong_ChiPhiHoatDongList(int maChiHoatDong, int maChiTietHoatDong)
		{
			return DataPortal.Fetch<HoatDong_ChiPhiHoatDongList>(new FilterCriteria(maChiHoatDong, maChiTietHoatDong));
		}
        public static HoatDong_ChiPhiHoatDongList GetHoatDong_ChiPhiHoatDongList()
        {
            return DataPortal.Fetch<HoatDong_ChiPhiHoatDongList>(new FilterCriteriaByAll());
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        
        private class FilterCriteriaByAll
		{
		
            public FilterCriteriaByAll()
			{
				
			}
		}
		private class FilterCriteria
		{
			public int MaChiHoatDong;
			public int MaChiTietHoatDong;

			public FilterCriteria(int maChiHoatDong, int maChiTietHoatDong)
			{
				this.MaChiHoatDong = maChiHoatDong;
				this.MaChiTietHoatDong = maChiTietHoatDong;
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
                if (criteria is FilterCriteriaByAll)
                {
                    cm.CommandText = "SelecttblHoatDong_ChiPhiHoatDongsAll";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);            
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(HoatDong_ChiPhiHoatDong.GetHoatDong_ChiPhiHoatDong(dr));
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
					foreach (HoatDong_ChiPhiHoatDong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (HoatDong_ChiPhiHoatDong child in this)
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
