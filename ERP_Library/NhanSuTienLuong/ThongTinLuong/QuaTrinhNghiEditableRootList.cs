
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhNghiList : Csla.BusinessListBase<QuaTrinhNghiList, QuaTrinhNghi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuaTrinhNghi item = QuaTrinhNghi.NewQuaTrinhNghi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhNghiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhNghiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhNghiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhNghiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhNghiList()
		{ /* require use of factory method */ }

		public static QuaTrinhNghiList NewQuaTrinhNghiList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhNghiList");
			return new QuaTrinhNghiList();
		}

		public static QuaTrinhNghiList GetQuaTrinhNghiList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
			return DataPortal.Fetch<QuaTrinhNghiList>(new FilterCriteria(maNhanVien));
		}

        public static QuaTrinhNghiList GetQuaTrinhNghiListBoPhan_Ngay(int maBoPhan, DateTime ngayNghi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
            return DataPortal.Fetch<QuaTrinhNghiList>(new FilterCriterialBoPhanNgay(maBoPhan,ngayNghi));
        }

        public static QuaTrinhNghiList GetQuaTrinhNghiListNgay(DateTime Tungay, DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
            return DataPortal.Fetch<QuaTrinhNghiList>(new FilterCriterialByNgay(Tungay,Denngay));
        }

        public static QuaTrinhNghiList GetQuaTrinhNghiListBoPhan(int maBoPhan, DateTime Tungay,DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
            return DataPortal.Fetch<QuaTrinhNghiList>(new FilterCriterialByBoPhan(maBoPhan, Tungay,Denngay));
        }
        public static QuaTrinhNghiList GetHetHanNghiAll(int Mahinhthuc,DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
            return DataPortal.Fetch<QuaTrinhNghiList>(new FilterCriterialHetHanAll(Mahinhthuc, Denngay));
        }
        public static QuaTrinhNghiList GetHetHanNghiByBoPhan(int Mahinhthuc, DateTime Denngay,int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
            return DataPortal.Fetch<QuaTrinhNghiList>(new FilterCriterialHetHanByBoPhan(Mahinhthuc, Denngay,mabophan));
        }
        public static QuaTrinhNghiList GetHetHanNghiByNhanVien(int Mahinhthuc, DateTime Denngay, long manhanvien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
            return DataPortal.Fetch<QuaTrinhNghiList>(new FilterCriterialHetHanByNhanVien(Mahinhthuc, Denngay, manhanvien));
        }
		#endregion //Factory Methods
        

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaNhanVien;

			public FilterCriteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
			}
		}
        private class FilterCriterialBoPhanNgay
        {
            public int maBoPhan;
            public DateTime ngayNghi;
            public FilterCriterialBoPhanNgay(int maBoPhan, DateTime ngayNghi)
            {
                this.maBoPhan = maBoPhan;
                this.ngayNghi = ngayNghi;
            }
        }

        private class FilterCriterialByBoPhan
        {
            public int maBoPhan;
            public DateTime Tungay;
            public DateTime Denngay;
            public FilterCriterialByBoPhan(int maBoPhan, DateTime Tungay, DateTime denngay)
            {
                this.maBoPhan = maBoPhan;
                this.Tungay = Tungay;
                this.Denngay = denngay;
            }
        }
        private class FilterCriterialByNgay
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public FilterCriterialByNgay(DateTime Tungay, DateTime denngay)
            {
                this.Tungay = Tungay;
                this.Denngay = denngay;
            }
        }

        private class FilterCriterialHetHanAll
        {
            public int mahinhthuc;
            public DateTime Denngay;
            public FilterCriterialHetHanAll(int mahinhthuc, DateTime Denngay)
            {
                this.mahinhthuc = mahinhthuc;
                this.Denngay = Denngay;
            }
        }
        private class FilterCriterialHetHanByBoPhan
        {
            public int mahinhthuc;
            public DateTime Denngay;
            public int mabophan;
            public FilterCriterialHetHanByBoPhan(int mahinhthuc, DateTime Denngay,int mabophan)
            {
                this.mahinhthuc = mahinhthuc;
                this.Denngay = Denngay;
                this.mabophan = mabophan;
            }
        }
        private class FilterCriterialHetHanByNhanVien
        {
            public int mahinhthuc;
            public DateTime Denngay;
            public long manhanvien;
            public FilterCriterialHetHanByNhanVien(int mahinhthuc, DateTime Denngay, long manhanvien)
            {
                this.mahinhthuc = mahinhthuc;
                this.Denngay = Denngay;
                this.manhanvien = manhanvien;
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
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, Object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhNghisAll";
                    cm.Parameters.AddWithValue("@MaNhanVien",((FilterCriteria)criteria).MaNhanVien);
                }
                else if (criteria is FilterCriterialBoPhanNgay)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhNghisBoPhanNgay";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriterialBoPhanNgay)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@NgayNghi", ((FilterCriterialBoPhanNgay)criteria).ngayNghi);
                }

                else if (criteria is FilterCriterialByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhNghisByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriterialByBoPhan)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriterialByBoPhan)criteria).Tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriterialByBoPhan)criteria).Denngay);
                }

                else if (criteria is FilterCriterialByNgay)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhNghisByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriterialByNgay)criteria).Tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriterialByNgay)criteria).Denngay);
                }
                else if (criteria is FilterCriterialHetHanAll)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhNghiHetHanAll";
                    cm.Parameters.AddWithValue("@mahinhthuc", ((FilterCriterialHetHanAll)criteria).mahinhthuc);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriterialHetHanAll)criteria).Denngay);
                }
                else if (criteria is FilterCriterialHetHanByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhNghiHetByBoPhan";
                    cm.Parameters.AddWithValue("@mahinhthuc", ((FilterCriterialHetHanByBoPhan)criteria).mahinhthuc);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriterialHetHanByBoPhan)criteria).Denngay);
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriterialHetHanByBoPhan)criteria).mabophan);
                }
                else if (criteria is FilterCriterialHetHanByNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhNghiHetByNhanVien";
                    cm.Parameters.AddWithValue("@mahinhthuc", ((FilterCriterialHetHanByNhanVien)criteria).mahinhthuc);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriterialHetHanByNhanVien)criteria).Denngay);
                    cm.Parameters.AddWithValue("@Manhanvien", ((FilterCriterialHetHanByNhanVien)criteria).manhanvien);
                }
				//cm.Parameters.AddWithValue("@MaHinhThucNghi", criteria.MaHinhThucNghi);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuaTrinhNghi.GetQuaTrinhNghi(dr));
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
                    foreach (QuaTrinhNghi deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (QuaTrinhNghi child in this)
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
