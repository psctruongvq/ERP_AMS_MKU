
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DanhSachDenHanNangLuongList : Csla.BusinessListBase<DanhSachDenHanNangLuongList, DanhSachDenHanNangLuong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			DanhSachDenHanNangLuong item = DanhSachDenHanNangLuong.NewDanhSachDenHanNangLuong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private DanhSachDenHanNangLuongList()
		{ /* require use of factory method */ }

		public static DanhSachDenHanNangLuongList NewDanhSachDenHanNangLuongList()
		{
			return new DanhSachDenHanNangLuongList();
		}

		public static DanhSachDenHanNangLuongList GetDanhSachDenHanNangLuongList()
		{
			return DataPortal.Fetch<DanhSachDenHanNangLuongList>(new FilterCriteria());
		}
        public static DanhSachDenHanNangLuongList GetDanhSachDenHanNangLuongListByThang()
        {
            return DataPortal.Fetch<DanhSachDenHanNangLuongList>(new FilterCriteriaByThang());
        }
        public static DanhSachDenHanNangLuongList NewDanhSachDenHanNangLuongList(DateTime ngayDenHan)
        {
            return DataPortal.Fetch<DanhSachDenHanNangLuongList>(new FilterCriteriabyDate(ngayDenHan));
        }
        public static DanhSachDenHanNangLuongList NewDanhSachDenHanNangLuongBaoHiemList(DateTime ngayDenHan,int kieuNangLuong)
        {
            return DataPortal.Fetch<DanhSachDenHanNangLuongList>(new FilterCriteriaBaoHiemByDate(ngayDenHan,kieuNangLuong));
        }
        public static DanhSachDenHanNangLuongList GetDanhSachDenHanNangLuongList(DateTime tuNgay, DateTime denNgay,int loaiNangLuong,int kieuNhanVien)
        {
            return DataPortal.Fetch<DanhSachDenHanNangLuongList>(new FilterCriteriabyTuNgayDenNgay(tuNgay, denNgay,loaiNangLuong,kieuNhanVien));
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
        	private class FilterCriteriaByThang
		{

                public FilterCriteriaByThang()
			{

			}
		}
        
        private class FilterCriteriabyDate
        {
            public DateTime NgayDenHan;
            public FilterCriteriabyDate(DateTime ngaydenhan)
            {
                this.NgayDenHan = ngaydenhan;
            }
        }
        private class FilterCriteriaBaoHiemByDate
        {
            public DateTime NgayDenHan;
            public int KieuNangLuong;
           public FilterCriteriaBaoHiemByDate(DateTime ngaydenhan,int kieuNangLuong)
            {
                this.NgayDenHan = ngaydenhan;
                this.KieuNangLuong = kieuNangLuong;
            }
        }
        private class FilterCriteriabyTuNgayDenNgay
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int LoaiNangLuong;
            public int KieuNhanVien;
            public FilterCriteriabyTuNgayDenNgay(DateTime tuNgay,DateTime denNgay,int loaiNangLuong,int kieuNhanVien)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.LoaiNangLuong = loaiNangLuong;
                this.KieuNhanVien = kieuNhanVien;
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
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsDanhSachDenHanNangLuongsAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhSachDenHanNangLuong.GetDanhSachDenHanNangLuong(dr));
                    }
                }
               else if (criteria is FilterCriteriaByThang)
                {
                    cm.CommandText = "spd_SelecttblnsDanhSachDenHanNangLuongByThang";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhSachDenHanNangLuong.GetDanhSachDenHanNangLuongByThang(dr));
                    }
                }
                else if (criteria is FilterCriteriabyDate)
                {
                    cm.CommandText = "spd_DanhSachDenHanNangLuong";
                    cm.Parameters.AddWithValue("@NgayDenHan",((FilterCriteriabyDate)criteria).NgayDenHan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhSachDenHanNangLuong.GetDanhSachDenHanNangLuongByDenNgay(dr));
                    }
                }
                else if (criteria is FilterCriteriaBaoHiemByDate)
                {
                    cm.CommandText = "spd_DanhSachDenHanNangLuongBaoHiem";
                    cm.Parameters.AddWithValue("@NgayDenHan", ((FilterCriteriaBaoHiemByDate)criteria).NgayDenHan);
                    cm.Parameters.AddWithValue("@KieuNangLuong", ((FilterCriteriaBaoHiemByDate)criteria).KieuNangLuong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhSachDenHanNangLuong.GetDanhSachDenHanNangLuongBaoHiemByDenNgay(dr));
                    }
                }
                else if (criteria is FilterCriteriabyTuNgayDenNgay)
                {
                    cm.CommandText = "spd_SelecttblnsDanhSachDenHanNangLuongsByTuNgayDenNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriabyTuNgayDenNgay)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriabyTuNgayDenNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriabyTuNgayDenNgay)criteria).KieuNhanVien);
                    cm.Parameters.AddWithValue("@KieuNangLuong", ((FilterCriteriabyTuNgayDenNgay)criteria).LoaiNangLuong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhSachDenHanNangLuong.GetDanhSachDenHanNangLuong(dr));
                    }
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

				// loop through each deleted child object
				foreach (DanhSachDenHanNangLuong deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (DanhSachDenHanNangLuong child in this)
				{
					if (child.IsNew)
						child.Insert(cn,this);
					else
						child.Update(cn,this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
