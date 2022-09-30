
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TinhThanhList : Csla.BusinessListBase<TinhThanhList, TinhThanh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TinhThanh item = TinhThanh.NewTinhThanh();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TinhThanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhThanhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TinhThanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhThanhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TinhThanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhThanhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TinhThanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhThanhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TinhThanhList()
		{ /* require use of factory method */ }

		public static TinhThanhList NewTinhThanhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TinhThanhList");
			return new TinhThanhList();
		}

		public static TinhThanhList GetTinhThanhList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TinhThanhList");
			return DataPortal.Fetch<TinhThanhList>(new FilterCriteria());
		}
        public static TinhThanhList GetTinhThanhList(int MaKhuVuc)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TinhThanhList");
            return DataPortal.Fetch<TinhThanhList>(new FilterCriteriaByKhuVuc(MaKhuVuc));
        }
        public static TinhThanhList GetQuocGiaist(int MaQuocGia)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TinhThanhList");
            return DataPortal.Fetch<TinhThanhList>(new FilterCriteriaByQuocGia(MaQuocGia));
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

        private class FilterCriteriaByKhuVuc
        {
            public int MaKhuVuc;
            public FilterCriteriaByKhuVuc(int _MaKhuVuc)
            {
                MaKhuVuc = _MaKhuVuc;
            }
        }

        private class FilterCriteriaByQuocGia
        {
            public int MaQuocGia;
            public FilterCriteriaByQuocGia(int _MaQuocGia)
            {
                MaQuocGia = _MaQuocGia;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		protected override void DataPortal_Fetch(Object criteria)
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
				catch (SqlException ex)
				{
					tr.Rollback();
					HamDungChung.ThongBaoLoi(ex);
				}
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTinhThanhesAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TinhThanh.GetTinhThanh(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByKhuVuc)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTinhThanhByMaKhuVuc";
                    cm.Parameters.AddWithValue("@MaKhuVuc", ((FilterCriteriaByKhuVuc)criteria).MaKhuVuc);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TinhThanh.GetTinhThanh(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByQuocGia)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTinhThanhByMaQuocGia";
                    cm.Parameters.AddWithValue("@MaQuocGia", ((FilterCriteriaByQuocGia)criteria).MaQuocGia);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TinhThanh.GetTinhThanh(dr));
                    }
                }
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
					foreach (TinhThanh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TinhThanh child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch(SqlException ex)
				{
					tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
