using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class VanBanList : Csla.BusinessListBase<VanBanList, VanBan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			VanBan item = VanBan.NewVanBan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in VanBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("VanBanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in VanBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("VanBanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in VanBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("VanBanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in VanBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("VanBanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private VanBanList()
		{ /* require use of factory method */ }

		public static VanBanList NewVanBanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a VanBanList");
			return new VanBanList();
		}

		public static VanBanList GetVanBanList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a VanBanList");
			return DataPortal.Fetch<VanBanList>(new FilterCriteria());
		}
        public static VanBanList GetVanBanListByMaChungTuCu(string maChungTuCu )
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a VanBanList");
            return DataPortal.Fetch<VanBanList>(new FilterCriteriaByMaChungTuCu(maChungTuCu));
        }
        public static VanBanList GetVanBanListByMaChungTu(long maChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a VanBanList");
            return DataPortal.Fetch<VanBanList>(new FilterCriteriaByMaChungTu(maChungTu));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
		}
        private class FilterCriteriaByMaChungTuCu
        {
            public string MaChungTuCu;
            public FilterCriteriaByMaChungTuCu(string maChungTuCu)
            {
                this.MaChungTuCu = maChungTuCu;
            }
        }
        private class FilterCriteriaByMaChungTu
        {
            public long MaChungTu;
            public FilterCriteriaByMaChungTu(long maChungTu)
            {
                this.MaChungTu= maChungTu;
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
                    cm.CommandText = "spd_SelecttblVanBansAll";
                }
                if (criteria is FilterCriteriaByMaChungTuCu)
                {
                    cm.CommandText = "spd_SelecttblVanBansAllByMaChungTuCu";
                    cm.Parameters.Add("@MaChungTuCu", ((FilterCriteriaByMaChungTuCu)criteria).MaChungTuCu);
                }
                if (criteria is FilterCriteriaByMaChungTu)
                {
                    cm.CommandText = "spd_SelecttblVanBansAllByMaChungTu";
                    cm.Parameters.Add("@MaChungTu", ((FilterCriteriaByMaChungTu)criteria).MaChungTu);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(VanBan.GetVanBan(dr));
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
					foreach (VanBan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (VanBan child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
                            child.Update(tr, this);
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
