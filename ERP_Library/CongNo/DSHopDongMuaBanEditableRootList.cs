
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DSHopDongMuaBanList : Csla.BusinessListBase<DSHopDongMuaBanList, DSHopDongMuaBan>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DSHopDongMuaBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSHopDongMuaBanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DSHopDongMuaBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSHopDongMuaBanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DSHopDongMuaBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSHopDongMuaBanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DSHopDongMuaBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSHopDongMuaBanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DSHopDongMuaBanList()
		{ /* require use of factory method */ }

		public static DSHopDongMuaBanList NewDSHopDongMuaBanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DSHopDongMuaBanList");
			return new DSHopDongMuaBanList();
		}

		public static DSHopDongMuaBanList GetDSHopDongMuaBanList(long maKhachHang, bool thuChi)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DSHopDongMuaBanList");
			return DataPortal.Fetch<DSHopDongMuaBanList>(new FilterCriteria(maKhachHang, thuChi));
		}
        public static DSHopDongMuaBanList GetDSHopDongMuaBanList_NgayThu(DateTime NgayThu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DSHopDongMuaBanList");
            return DataPortal.Fetch<DSHopDongMuaBanList>(new FilterCriteria_NgayThu(NgayThu));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaKhachHang;
			public bool ThuChi;

			public FilterCriteria(long maKhachHang, bool thuchi)
			{
				this.MaKhachHang = maKhachHang;
				this.ThuChi = thuchi;
			}
		}
        [Serializable()]
        private class FilterCriteria_NgayThu
        {
            public DateTime NgayThu;

            public FilterCriteria_NgayThu(DateTime ngayThu)
            {
                this.NgayThu = ngayThu;
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
			using (SqlCommand cm = cn.CreateCommand())
			{
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHopDongMuaBansAll_Trang";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteria)criteria).MaKhachHang);
                    cm.Parameters.AddWithValue("@ThuChi", ((FilterCriteria)criteria).ThuChi);
                }
                else if (criteria is FilterCriteria_NgayThu)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblHopDongMuaBansAll_NgayThuLai_Trang";
                    cm.Parameters.AddWithValue("@NgayThu", ((FilterCriteria_NgayThu)criteria).NgayThu.ToShortDateString());
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(DSHopDongMuaBan.GetDSHopDongMuaBan(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch

		#region Data Access - Update
        public void DataPortal_Update(SqlTransaction tr)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each non-deleted child object
                foreach (DSHopDongMuaBan child in this)
                {
                    if (!child.IsNew)
                        child.Update(tr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access
        #endregion
    }
}
