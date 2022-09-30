using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiVanBanList : Csla.BusinessListBase<LoaiVanBanList, LoaiVanBan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			LoaiVanBan item = LoaiVanBan.NewLoaiVanBan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiVanBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiVanBanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiVanBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiVanBanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiVanBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiVanBanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiVanBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiVanBanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiVanBanList()
        { /* require use of factory method */   }

		public static LoaiVanBanList NewLoaiVanBanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiVanBanList");
			return new LoaiVanBanList();
		}

		public static LoaiVanBanList GetLoaiVanBanList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiVanBanList");
			return DataPortal.Fetch<LoaiVanBanList>(new FilterCriteria());
		}
        public static LoaiVanBanList GetLoaiVanBanList(string duLieuTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiVanBanList");
            return DataPortal.Fetch<LoaiVanBanList>(new FilterCriteriaByDuLieuTim(duLieuTim));
        }
        public static LoaiVanBanList GetLoaiVanBanList(long maLoaiVanBanCha)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiVanBanList");
            return DataPortal.Fetch<LoaiVanBanList>(new FilterCriteriaByMaLoaiVanBanCha(maLoaiVanBanCha));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{

		}
        private class FilterCriteriaByMaLoaiVanBanCha
        {
            public long MaLoaiVanBanCha;

            public FilterCriteriaByMaLoaiVanBanCha(long maLoaiVanBanCha)
            {
                this.MaLoaiVanBanCha = maLoaiVanBanCha;
            }
        }
        private class FilterCriteriaByDuLieuTim
        {
            public string DuLieuTim;

            public FilterCriteriaByDuLieuTim(string duLieuTim)
            {
                this.DuLieuTim = duLieuTim;
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
                    cm.CommandText = "spd_SelecttblLoaiVanBansAll";
                }
                if (criteria is FilterCriteriaByDuLieuTim)
                {
                    cm.CommandText = "spd_SelecttblLoaiVanBansAllByDuLieuTim";
                    cm.Parameters.AddWithValue("@DuLieuTim", ((FilterCriteriaByDuLieuTim)criteria).DuLieuTim);
                }
                if (criteria is FilterCriteriaByMaLoaiVanBanCha)
                {
                    cm.CommandText = "spd_SelecttblLoaiVanBansAllByMaLoaiVanBanCha";
                    cm.Parameters.Add("@MaLoaiVanBanCha", ((FilterCriteriaByMaLoaiVanBanCha)criteria).MaLoaiVanBanCha);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(LoaiVanBan.GetLoaiVanBan(dr));
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
					foreach (LoaiVanBan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (LoaiVanBan child in this)
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
