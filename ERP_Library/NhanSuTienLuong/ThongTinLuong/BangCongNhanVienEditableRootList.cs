
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangCongNhanVienList : Csla.BusinessListBase<BangCongNhanVienList, BangCongNhanVien>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangCongNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongNhanVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangCongNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongNhanVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangCongNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongNhanVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangCongNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongNhanVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangCongNhanVienList()
		{ /* require use of factory method */ }

		public static BangCongNhanVienList NewBangCongNhanVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangCongNhanVienList");
			return new BangCongNhanVienList();
		}

		public static BangCongNhanVienList GetBangCongNhanVienList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangCongNhanVienList");
			return DataPortal.Fetch<BangCongNhanVienList>(new FilterCriteria());
		}
        public static BangCongNhanVienList GetBangCongNhanVienList(int maCa, SmartDate ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCongNhanVienList");
            return DataPortal.Fetch<BangCongNhanVienList>(new FilterCriteriaByNgayChamCong_Ca(maCa,ngay));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
           
		}
        public class FilterCriteriaByNgayChamCong_Ca
        {
            public int maCa;
            public SmartDate ngayChamCong;
            public FilterCriteriaByNgayChamCong_Ca(int ca, SmartDate ngay)
            {
                this.maCa = ca;
                this.ngayChamCong = ngay;
            }
        }
        //public class FilterCriteriaByCty
        //{
        //    public int maCty;
        //    public string ngayCham;
        //    public FilterCriteriaByCty(int macty, string ngay)
        //    {
        //        this.maCty = macty;
        //        this.ngayCham = ngay;
        //    }
        //}
        //public class FilterCriteriaByPhongBan
        //{
        //    public int maCty,maPhongBan;
        //    public string ngayCham;
        //    public FilterCriteriaByPhongBan(int macty, int maphongban, string ngay)
        //    {
        //        this.maCty = macty;
        //        this.maPhongBan=maphongban;
        //        this.ngayCham = ngay;
        //    }
        //}
        //public class FilterCriteriaByTo
        //{
        //    public int maCty, maPhongBan,maTo;
        //    public string ngayCham;
        //    public FilterCriteriaByTo(int macty, int maphongban, int mato, string ngay)
        //    {
        //        this.maCty = macty;
        //        this.maPhongBan = maphongban;
        //        this.maTo = mato;
        //        this.ngayCham = ngay;
        //    }
        //}
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
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Select * from View_DSChamCongNV";
                    //cm.Parameters.AddWithValue("@NgayCham", ((FilterCriteria)criteria).ngayCham);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BangCongNhanVien.GetBangCongNhanVien(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByNgayChamCong_Ca)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Select * from View_DSChamCongNV v,tblnsCaLamViec ca where v.MaQuanLy=ca.MaQuanLy and ca.MaCa=" + ((FilterCriteriaByNgayChamCong_Ca)criteria).maCa +
                                     "and Ngay = '" + ((FilterCriteriaByNgayChamCong_Ca)criteria).ngayChamCong+"'";
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaByNgayChamCong_Ca)criteria).maCa);
                    cm.Parameters.AddWithValue("@NgayCham", ((FilterCriteriaByNgayChamCong_Ca)criteria).ngayChamCong);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BangCongNhanVien.GetBangCongNhanVien(dr));
                    }
                }
            }
            //else if (criteria is FilterCriteriaByPhongBan)
            //{
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "BangChamCong_Select_TheoMaPhongBan";
            //        cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaByPhongBan)criteria).maCty);
            //        cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaByPhongBan)criteria).maPhongBan);
            //        cm.Parameters.AddWithValue("@NgayCham", ((FilterCriteriaByPhongBan)criteria).ngayCham);

            //        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            //        {
            //            while (dr.Read())
            //                this.Add(BangCongNhanVien.GetBangCongNhanVien(dr));
            //        }
            //    }
            //}
            //else if (criteria is FilterCriteriaByTo)
            //{
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "BangChamCong_Select_TheoMaTo";
            //        cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaByTo)criteria).maCty);
            //        cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaByTo)criteria).maPhongBan);
            //        cm.Parameters.AddWithValue("@MaTo", ((FilterCriteriaByTo)criteria).maTo);
            //        cm.Parameters.AddWithValue("@NgayCham", ((FilterCriteriaByTo)criteria).ngayCham);
            //        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            //        {
            //            while (dr.Read())
            //                this.Add(BangCongNhanVien.GetBangCongNhanVien(dr));
            //        }
            //    }
            //}
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
				foreach (BangCongNhanVien deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (BangCongNhanVien child in this)
				{
					if (child.IsNew)
						child.Insert(cn);
					else
						child.Update(cn);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
