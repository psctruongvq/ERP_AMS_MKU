using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoPhanMoRongList : Csla.BusinessListBase<BoPhanMoRongList, BoPhanMoRong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BoPhanMoRong item = BoPhanMoRong.NewBoPhanMoRong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoPhanMoRongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRongListViewGroup"))
			//	return true;m
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoPhanMoRongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoPhanMoRongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoPhanMoRongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoPhanMoRongList()
		{ /* require use of factory method */ }

		public static BoPhanMoRongList NewBoPhanMoRongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhanMoRongList");
			return new BoPhanMoRongList();
		}

		public static BoPhanMoRongList GetBoPhanMoRongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhanMoRongList");
			return DataPortal.Fetch<BoPhanMoRongList>(new FilterCriteria());
		}
        public static BoPhanMoRongList GetBoPhanMoRongList(int checkDay,DateTime tuNgayLap,DateTime denNgayLap,string maQuanLy,string tenBoPhanMoRong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanMoRongList");
            return DataPortal.Fetch<BoPhanMoRongList>(new FilterCriteria(checkDay,tuNgayLap,denNgayLap,maQuanLy,tenBoPhanMoRong));
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
            public int CheckDay=-1;
            public DateTime TuNgayLap;
            public DateTime DenNgayLap;
            public string MaQuanLy;
            public string TenBoPhanMoRong;
            public FilterCriteria(int checkDay, DateTime tuNgayLap, DateTime denNgayLap, string maQuanLy, string tenBoPhanMoRong)
            {
                this.CheckDay = checkDay;
                this.TuNgayLap = tuNgayLap;
                this.DenNgayLap = denNgayLap;
                this.MaQuanLy = maQuanLy;
                this.TenBoPhanMoRong = tenBoPhanMoRong;
            }
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
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

		private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
		{
            if(criteria.CheckDay==-1)
			    using (SqlCommand cm = tr.Connection.CreateCommand())
			    {
				    cm.Transaction = tr;
				    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectnsBoPhanMoRongListAll";


				    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				    {
					    while (dr.Read())
						    this.Add(BoPhanMoRong.GetBoPhanMoRong(dr));
				    }
			    }//using
            else
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectnsBoPhanMoRongListByAll";
                    cm.Parameters.AddWithValue("@CheckDay", criteria.CheckDay);
                    cm.Parameters.AddWithValue("@MaQuanLy", criteria.MaQuanLy);
                    cm.Parameters.AddWithValue("@TenBoPhanMoRong", criteria.TenBoPhanMoRong);
                    cm.Parameters.AddWithValue("@TuNgayLap", criteria.TuNgayLap);
                    cm.Parameters.AddWithValue("@DenNgayLap", criteria.DenNgayLap);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BoPhanMoRong.GetBoPhanMoRong(dr));
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
					foreach (BoPhanMoRong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BoPhanMoRong child in this)
					{
						if (child.IsNew)
							child.Insert(tr, this);
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
