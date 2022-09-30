
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ToList : Csla.BusinessListBase<ToList, To>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			To item = To.NewTo();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ToList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ToList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ToList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ToList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ToList()
		{ /* require use of factory method */ }

		public static ToList NewToList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ToList");
			return new ToList();
		}

		public static ToList GetToList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ToList");
			return DataPortal.Fetch<ToList>(new FilterCriteria());
		}

        public static ToList GetToList(int maPhanXuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ToList");
            return DataPortal.Fetch<ToList>(new FilterCriteriaByMaPhanXuong(maPhanXuong));
        }

        public static ToList GetToList_TheoPhongBan(int maPhongBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ToList");
            return DataPortal.Fetch<ToList>(new FilterCriteriaByMaPhongBan(maPhongBan));
        }

        public static ToList GetToListChung(int maPhanXuong,int maPhongBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ToList");
            return DataPortal.Fetch<ToList>(new FilterCriteriaByChung(maPhanXuong,maPhongBan));
        }     

        public static ToList GetToList_MaTo(int maTo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ToList");
            return DataPortal.Fetch<ToList>(new FilterCriteriaByMaTo(maTo));
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
        private class FilterCriteriaByMaPhanXuong
        {
            public int maPhanXuong;           
            public FilterCriteriaByMaPhanXuong(int maPhanXuong)
            {
                this.maPhanXuong = maPhanXuong;                
            }
        }
        private class FilterCriteriaByMaPhongBan
        {
            public int MaPhongBan;
            public FilterCriteriaByMaPhongBan(int maPhongBan)
            {
                this.MaPhongBan = maPhongBan;
            }
        }
        private class FilterCriteriaByChung
        {
            public int maPhanXuong;
            public int maPhongBan;
            public FilterCriteriaByChung(int maPhanXuong,int maPhongBan)
            {
                this.maPhanXuong = maPhanXuong;
                this.maPhongBan = maPhongBan;
            }
        }
        private class FilterCriteriaByMaTo
        {
            public int maTo;
            public FilterCriteriaByMaTo(int maTo)
            {
                this.maTo = maTo;
            }
        }

		#endregion //Filter Criteria

		#region Data Access - Fetch
		protected override void DataPortal_Fetch(object criteria)
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
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTosAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(To.GetTo(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByMaPhanXuong)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsToByMaPhanXuong";
                    cm.Parameters.AddWithValue("@MaPhanXuong", ((FilterCriteriaByMaPhanXuong)criteria).maPhanXuong);                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(To.GetTo(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByMaPhongBan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTo_TheoMaPhongBan";
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaByMaPhongBan)criteria).MaPhongBan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(To.GetTo(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByMaTo)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsToByMaTo";
                    cm.Parameters.AddWithValue("@MaTo", ((FilterCriteriaByMaTo)criteria).maTo);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(To.GetTo(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByChung)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsToByChung";
                    cm.Parameters.AddWithValue("@MaPhanXuong", ((FilterCriteriaByChung)criteria).maPhanXuong);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaByChung)criteria).maPhongBan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(To.GetTo(dr));
                    }
                }//using
            }
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
					foreach (To deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (To child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch (Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
