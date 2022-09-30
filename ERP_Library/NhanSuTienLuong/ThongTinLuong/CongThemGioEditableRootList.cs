
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongThemGioList : Csla.BusinessListBase<CongThemGioList, CongThemGio>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CongThemGioList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThemGioListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CongThemGioList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThemGioListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CongThemGioList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThemGioListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CongThemGioList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThemGioListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CongThemGioList()
		{ /* require use of factory method */ }

		public static CongThemGioList NewCongThemGioList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongThemGioList");
			return new CongThemGioList();
		}

		public static CongThemGioList GetCongThemGioList(int maCacLoaiCong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CongThemGioList");
			return DataPortal.Fetch<CongThemGioList>(new FilterCriteria(maCacLoaiCong));
		}

        public static CongThemGioList GetCongThemGioList(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThemGioList");
            return DataPortal.Fetch<CongThemGioList>(new FilterCriteria_MaNhanVien(maNhanVien));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaCacLoaiCong;

			public FilterCriteria(int maCacLoaiCong)
			{
				this.MaCacLoaiCong = maCacLoaiCong;
			}
		}

        private class FilterCriteria_MaNhanVien
        {
            public long MaNhanVien;

            public FilterCriteria_MaNhanVien(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, Object criteria)
		{
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsCongThemGiosAll";
                    cm.Parameters.AddWithValue("@MaCacLoaiCong", ((FilterCriteria)criteria).MaCacLoaiCong);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CongThemGio.GetCongThemGio(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_MaNhanVien)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsCongThemGiosAll_MaNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria_MaNhanVien)criteria).MaNhanVien);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CongThemGio.GetCongThemGio(dr));
                    }
                }//using
            }
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				// loop through each deleted child object
				foreach (CongThemGio deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (CongThemGio child in this)
				{
					if (child.IsNew)
						child.Insert(cn, this);
					else
						child.Update(cn, this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
