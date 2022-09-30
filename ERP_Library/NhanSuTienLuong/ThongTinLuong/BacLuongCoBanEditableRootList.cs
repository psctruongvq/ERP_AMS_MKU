//
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BacLuongCoBanList : Csla.BusinessListBase<BacLuongCoBanList, BacLuongCoBan>
	{
        
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BacLuongCoBan item = BacLuongCoBan.NewBacLuongCoBan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BacLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongCoBanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BacLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongCoBanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BacLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongCoBanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BacLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongCoBanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BacLuongCoBanList()
		{ /* require use of factory method */ }

		public static BacLuongCoBanList NewBacLuongCoBanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BacLuongCoBanList");
			return new BacLuongCoBanList();
		}

		public static BacLuongCoBanList GetBacLuongCoBanList(int maNgachLuongCB)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BacLuongCoBanList");
			return DataPortal.Fetch<BacLuongCoBanList>(new FilterCriteria(maNgachLuongCB));
		}

        public static BacLuongCoBanList GetBacLuongCoBanListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BacLuongCoBanList");
            return DataPortal.Fetch<BacLuongCoBanList>(new FilterCriteriaAll());
        }
        public static BacLuongCoBanList GetBacLuongCoBanListByNgachLuong(int mangachluong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BacLuongCoBanList");
            return DataPortal.Fetch<BacLuongCoBanList>(new FilterCriteriaByNgachLuong(mangachluong));
        }
        public static BacLuongCoBanList GetBacLuongCoBanListByNhomNgachLuong(int maNhomNgachluong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BacLuongCoBanList");
            return DataPortal.Fetch<BacLuongCoBanList>(new FilterCriteriaByNhomNgachLuong(maNhomNgachluong));
        }

		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaNgachLuongCB;

			public FilterCriteria(int maNgachLuongCB)
			{
				this.MaNgachLuongCB = maNgachLuongCB;
			}
		}
        private class FilterCriteriaByNhomNgachLuong
        {
            public int MaNhomNgachLuongCB;

            public FilterCriteriaByNhomNgachLuong(int maNhomNgachLuongCB)
            {
                this.MaNhomNgachLuongCB = maNhomNgachLuongCB;
            }
        }

        private class FilterCriteriaByNgachLuong
        {
            public int MaNgachLuongCB;

            public FilterCriteriaByNgachLuong(int maNgachLuongCB)
            {
                this.MaNgachLuongCB = maNgachLuongCB;
            }
        }
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
		{
			RaiseListChangedEvents = false;
            if (criteria is FilterCriteria)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    try
                    {
                        ExecuteFetch(cn, criteria);
                    }
                    catch (SqlException ex)
                    {
                        HamDungChung.ThongBaoLoi(ex);
                    }
                }//using
            }
            else if (criteria is FilterCriteriaAll)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    ExecuteFetchAll(cn, criteria);
                }//using
            
            }
            else if (criteria is FilterCriteriaByNgachLuong)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    ExecuteFetchByNgach(cn, criteria);
                }//using

            }
            else if (criteria is FilterCriteriaByNhomNgachLuong)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    ExecuteFetchByNgach(cn, criteria);
                }//using

            }
			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsBacLuongCoBanTheoNgachCB";
                    cm.Parameters.AddWithValue("@MaNgachLuongCB", ((FilterCriteria)criteria).MaNgachLuongCB);
                }
                else if (criteria is FilterCriteriaByNhomNgachLuong)
                {
 
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BacLuongCoBan.GetBacLuongCoBan(dr));
				}
			}//using
		}

        private void ExecuteFetchByNgach(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriaByNgachLuong)
                {
                    cm.CommandText = "spd_SelecttblnsBacLuongCoBanTheoNgachCB";
                    cm.Parameters.AddWithValue("@MaNgachLuongCB", ((FilterCriteriaByNgachLuong)criteria).MaNgachLuongCB);
                }
                else if (criteria is FilterCriteriaByNhomNgachLuong)
                {
                    cm.CommandText = "spd_SelecttblnsBacLuongCoBanTheoNhomNgachCB";
                    cm.Parameters.AddWithValue("@MaNhomNgachLuongCB", ((FilterCriteriaByNhomNgachLuong)criteria).MaNhomNgachLuongCB);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BacLuongCoBan.GetBacLuongCoBan(dr));
                }
            }//using
        }

        private void ExecuteFetchAll(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsBacLuongCoBansAll";
                //cm.Parameters.AddWithValue("@MaNgachLuongCB", criteria.MaNgachLuongCB);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BacLuongCoBan.GetBacLuongCoBan(dr));
                }
            }//using
        }
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();
                try
                {
                    // loop through each deleted child object
                    foreach (BacLuongCoBan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BacLuongCoBan child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn, this);
                        else
                            child.Update(cn, this);
                    }
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
