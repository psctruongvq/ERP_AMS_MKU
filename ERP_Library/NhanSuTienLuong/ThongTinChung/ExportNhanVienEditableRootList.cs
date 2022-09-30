using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ExportNhanVienList : Csla.BusinessListBase<ExportNhanVienList, ExportNhanVien>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ExportNhanVien item = ExportNhanVien.NewNhanVien();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ExportNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ExportNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ExportNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ExportNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ExportNhanVienList()
		{ /* require use of factory method */ }

		public static ExportNhanVienList NewNhanVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ExportNhanVienList");
			return new ExportNhanVienList();
		}

		public static ExportNhanVienList GetNhanVienList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");
			return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteria());
		}
        public static ExportNhanVienList GetNhanVienListByChild(bool isChild)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");
            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaByChild(isChild));
        }

        public static ExportNhanVienList GetNhanVienList(string maNV)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");
            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaByMaNV(maNV));
        }

        public static ExportNhanVienList GetNhanVienList(int MaPhongBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");
            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaByMaPB(MaPhongBan));
        }

        public static ExportNhanVienList GetNhanVienListByMaChucVu(int MaChucVu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");
            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaByMaChucVu(MaChucVu));
        }

      

        public static ExportNhanVienList GetNhanVienListBoPhan(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaByBoPhan(maBoPhan));
        }
        public static ExportNhanVienList GetNhanVienListBoPhanChucVu(int maBoPhan,int maChucVu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaByBoPhanChuVu(maBoPhan, maChucVu));
        }
        public static ExportNhanVienList GetNhanVienListBoPhanNgay(int maBoPhan, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaByBoPhanNgay(maBoPhan, ngay));
        }

        public static ExportNhanVienList GetNhanVienListNghiViecBoPhanNgay(int maBoPhan, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaNghiViecByBoPhanNgay(maBoPhan, ngay));
        }

        public static ExportNhanVienList GetNhanVienListLichLamViecBoPhanNgay(int maBoPhan, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaLichLamViecByBoPhanNgay(maBoPhan, ngay));
        }
        public static ExportNhanVienList GetNhanVienListByDanhSachDenHanNangLuong(int loaiNV,DateTime ngayDenHan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaByDanhSachDenHanNangLuong(loaiNV,ngayDenHan));
        }
        public static ExportNhanVienList GetNhanVienListByDanhSachChuaCoSoBHXH(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaDanhSachChuaCoSoBHXH(maBoPhan));
        }
        public static ExportNhanVienList GetNhanVienListByDanhSachChuaCoTheBHYT(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaDanhSachChuaCoTheBHYT(maBoPhan));
        }
        public static ExportNhanVienList GetNhanVienListByDanhSachChuaDongBHTN(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ExportNhanVienList");

            return DataPortal.Fetch<ExportNhanVienList>(new FilterCriteriaDanhSachChuaDongBHTN(maBoPhan));
        }

		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        private class FilterCriteriaNghiViecByBoPhanNgay
        {
            public int MaBoPhan;
            public DateTime ngay;

            public FilterCriteriaNghiViecByBoPhanNgay(int maBoPhan, DateTime ngay)
            {
                this.MaBoPhan = maBoPhan;
                this.ngay = ngay;
            }
        }
        private class FilterCriteriaDanhSachChuaCoSoBHXH
        {
            public int MaBoPhan;
            public FilterCriteriaDanhSachChuaCoSoBHXH(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;                
            }
        }
        private class FilterCriteriaDanhSachChuaCoTheBHYT
        {
            public int MaBoPhan;
            public FilterCriteriaDanhSachChuaCoTheBHYT(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
            }
        }
        private class FilterCriteriaDanhSachChuaDongBHTN
        {
            public int MaBoPhan;
            public FilterCriteriaDanhSachChuaDongBHTN(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
            }
        }
		private class FilterCriteria
		{
			
			public FilterCriteria()
			{				
			}
		}
        private class FilterCriteriaByChild
        {
            public bool IsChild;
          
            public FilterCriteriaByChild(bool isChild)
            {
                this.IsChild = isChild;
              
            }
        }
        private class FilterCriteriaByBoPhanNgay
        {
            public int MaBoPhan;
            public DateTime ngay;

            public FilterCriteriaByBoPhanNgay(int maBoPhan, DateTime ngay)
            {
                this.MaBoPhan = maBoPhan;
                this.ngay = ngay;
            }
        }
        private class FilterCriteriaByMaNV
        {
            public string maNV;
            public FilterCriteriaByMaNV(string maNV)
            {
                this.maNV = maNV;
            }
        }
        private class FilterCriteriaByDanhSachDenHanNangLuong
        {
            public int loaiNV;
            public DateTime ngayDenHan;
            public FilterCriteriaByDanhSachDenHanNangLuong(int loaiNV,DateTime _ngayDenHan)
            {
                this.loaiNV = loaiNV;
                this.ngayDenHan = _ngayDenHan;
            }
        }
        private class FilterCriteriaLichLamViecByBoPhanNgay
        {
            public int MaBoPhan;
            public DateTime ngay;

            public FilterCriteriaLichLamViecByBoPhanNgay(int maBoPhan, DateTime ngay)
            {
                this.MaBoPhan = maBoPhan;
                this.ngay = ngay;
            }
        }
        [Serializable()]
        private class FilterCriteriaByBoPhan
        {
            public int MaBoPhan;
            public FilterCriteriaByBoPhan(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
            }
        }
        private class FilterCriteriaByBoPhanChuVu
        {
            public int MaBoPhan;
            public int MaChucVu;
            public FilterCriteriaByBoPhanChuVu(int maBoPhan,int maChucVu)
            {
                this.MaBoPhan = maBoPhan;
                this.MaChucVu = maChucVu;
            }
        }
         private class FilterCriteriaByMaPB
        {
            public int _maPB;
             public FilterCriteriaByMaPB(int maPB)
            {
                this._maPB = maPB;
            }
        }
        private class FilterCriteriaByMaChucVu
        {
            public int MaChucVu;
            public FilterCriteriaByMaChucVu(int MaChucVu)
            {
                this.MaChucVu = MaChucVu;
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
				catch(Exception ex)
				{
					tr.Rollback();
                    throw ex;
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
                    cm.CommandText = "spd_SelecttblnsNhanViensAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ExportNhanVien.GetNhanVien(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByChild)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanViensAll";
                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (((FilterCriteriaByChild)criteria).IsChild == true)
                        {
                            while (dr.Read())
                            {
                                this.Add(ExportNhanVien.GetNhanVien(dr));
                            }
                        }
                        else
                        {
                            while (dr.Read())
                            {
                                this.Add(ExportNhanVien.GetNhanVienNotChild(dr));
                            }
                        }
                    }
                }//using
            }
           
            else if (criteria is FilterCriteriaByMaChucVu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienByChucVu";
                    cm.Parameters.AddWithValue("@MaChucVu", ((FilterCriteriaByMaChucVu)criteria).MaChucVu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ExportNhanVien.GetNhanVien(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByBoPhan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByBoPhan)criteria).MaBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ExportNhanVien.GetNhanVien(dr));
                    }
                }
            
            }
            else if (criteria is FilterCriteriaByBoPhanChuVu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienByBoPhanChucVu";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByBoPhanChuVu)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaChucVu", ((FilterCriteriaByBoPhanChuVu)criteria).MaChucVu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ExportNhanVien.GetNhanVien(dr));
                    }
                }

            }
            else if (criteria is FilterCriteriaNghiViecByBoPhanNgay)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsNhanVienByNgayBoPhanNghiViec";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaNghiViecByBoPhanNgay)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@Ngay", ((FilterCriteriaNghiViecByBoPhanNgay)criteria).ngay.ToShortDateString());
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ExportNhanVien.GetNhanVien(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaLichLamViecByBoPhanNgay)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_Select_NhanVienByMaBoPhanNgay";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaLichLamViecByBoPhanNgay)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@NgayTao", ((FilterCriteriaLichLamViecByBoPhanNgay)criteria).ngay.ToShortDateString());
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ExportNhanVien.GetNhanVien(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByBoPhanNgay)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsQuaTrinhNghiBoPhanNgay";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByBoPhanNgay)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@Ngay", ((FilterCriteriaByBoPhanNgay)criteria).ngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ExportNhanVien.GetNhanVien(dr));
                    }
                }
            }
		}
		#endregion //Data Access - Fetch


		
		#endregion //Data Access
	}
}
