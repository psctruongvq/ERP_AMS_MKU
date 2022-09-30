
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinTaiNanList : Csla.BusinessListBase<ThongTinTaiNanList, ThongTinTaiNan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ThongTinTaiNan item = ThongTinTaiNan.NewThongTinTaiNan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThongTinTaiNanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTaiNanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinTaiNanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTaiNanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinTaiNanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTaiNanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinTaiNanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTaiNanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinTaiNanList()
		{ /* require use of factory method */ }

		public static ThongTinTaiNanList NewThongTinTaiNanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinTaiNanList");
			return new ThongTinTaiNanList();
		}

		public static ThongTinTaiNanList GetThongTinTaiNanList()//int maLoaiTaiNan, int maNguyenNhanTaiNan, long maNguoiLap)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinTaiNanList");
			return DataPortal.Fetch<ThongTinTaiNanList>(new FilterCriteria());//maLoaiTaiNan, maNguyenNhanTaiNan, maNguoiLap));
		}
        public static ThongTinTaiNanList GetThongTinTaiNanList(int maloaitainan, DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinTaiNanList");
            return DataPortal.Fetch<ThongTinTaiNanList>(new FilterCriteria_ByLoaiTN(maloaitainan,tungay,denngay));
        }
        public static ThongTinTaiNanList GetThongTinTaiNanList( DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinTaiNanList");
            return DataPortal.Fetch<ThongTinTaiNanList>(new FilterCriteria_ByNgay(tungay, denngay));
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
        private class FilterCriteria_ByLoaiTN
        {
            public int maloaitainan;
            public DateTime tungay;
            public DateTime denngay;

            public FilterCriteria_ByLoaiTN(int maloaitainan, DateTime tungay, DateTime denngay)
            {
                this.maloaitainan = maloaitainan;
                this.tungay = tungay;
                this.denngay = denngay;
            }
        }
        private class FilterCriteria_ByNgay
        {
            public DateTime tungay;
            public DateTime denngay;

            public FilterCriteria_ByNgay(DateTime tungay, DateTime denngay)
            {
                this.tungay = tungay;
                this.denngay = denngay;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

        private void ExecuteFetch(SqlConnection cn, object criteria)
		{
            try
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (criteria is FilterCriteria_ByLoaiTN)
                    {
                        cm.CommandText = "spd_SelecttblnsThongTinTaiNansAll";
                        cm.Parameters.AddWithValue("@maloaitainan", ((FilterCriteria_ByLoaiTN)criteria).maloaitainan);
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByLoaiTN)criteria).tungay);
                        cm.Parameters.AddWithValue("@Denngay", ((FilterCriteria_ByLoaiTN)criteria).denngay);
                    }
                    else if (criteria is FilterCriteria_ByNgay)
                    {
                        cm.CommandText = "spd_SelecttblnsThongTinTaiNanByNgay";                        
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgay)criteria).tungay);
                        cm.Parameters.AddWithValue("@Denngay", ((FilterCriteria_ByNgay)criteria).denngay);
                    }
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinTaiNan.GetThongTinTaiNan(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    foreach (ThongTinTaiNan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThongTinTaiNan child in this)
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
