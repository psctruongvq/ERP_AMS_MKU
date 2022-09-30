
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class MauKinhPhiHoatDongList : Csla.BusinessListBase<MauKinhPhiHoatDongList, MauKinhPhiHoatDong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			MauKinhPhiHoatDong item = MauKinhPhiHoatDong.NewMauKinhPhiHoatDong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in MauKinhPhiHoatDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MauKinhPhiHoatDongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in MauKinhPhiHoatDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MauKinhPhiHoatDongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in MauKinhPhiHoatDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MauKinhPhiHoatDongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in MauKinhPhiHoatDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MauKinhPhiHoatDongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private MauKinhPhiHoatDongList()
		{ /* require use of factory method */ }

		public static MauKinhPhiHoatDongList NewMauKinhPhiHoatDongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MauKinhPhiHoatDongList");
			return new MauKinhPhiHoatDongList();
		}

		public static MauKinhPhiHoatDongList GetMauKinhPhiHoatDongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a MauKinhPhiHoatDongList");
			return DataPortal.Fetch<MauKinhPhiHoatDongList>(new FilterCriteria());
		}

        public static MauKinhPhiHoatDongList GetMauKinhPhiHoatDongList(int MaKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a MauKinhPhiHoatDongList");
            return DataPortal.Fetch<MauKinhPhiHoatDongList>(new FilterCriteriaByMaKy(MaKy));
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

        [Serializable()]
        private class FilterCriteriaByMaKy
        {
            public int MaKy;
            public FilterCriteriaByMaKy(int maKy)
            {
                MaKy = maKy;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblMauKinhPhiHoatDongsAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(MauKinhPhiHoatDong.GetMauKinhPhiHoatDong(dr, true));
                    }
                }
                else if (criteria is FilterCriteriaByMaKy)
                {
                    int count;
                    count = MauKinhPhiHoatDong.KiemTraKyBaoCao(((FilterCriteriaByMaKy)criteria).MaKy);

                    cm.CommandText = "spd_SelecttblMauKinhPhiHoatDongsbyMaKy";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteriaByMaKy)criteria).MaKy);
                    if (count > 0)
                    {
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(MauKinhPhiHoatDong.GetMauKinhPhiHoatDong(dr, true));
                        }
                    }
                    else
                    {
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(MauKinhPhiHoatDong.GetMauKinhPhiHoatDong(dr, false));
                        }
                    }
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
					foreach (MauKinhPhiHoatDong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (MauKinhPhiHoatDong child in this)
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
