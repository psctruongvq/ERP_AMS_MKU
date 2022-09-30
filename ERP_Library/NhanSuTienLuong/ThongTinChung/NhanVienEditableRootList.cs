using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVienList : Csla.BusinessListBase<NhanVienList, NhanVien>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NhanVien item = NhanVien.NewNhanVien();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhanVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NhanVienList()
		{ /* require use of factory method */ }

		public static NhanVienList NewNhanVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhanVienList");
			return new NhanVienList();
		}

		public static NhanVienList GetNhanVienList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
			return DataPortal.Fetch<NhanVienList>(new FilterCriteria());
		}
        public static NhanVienList GetNhanVienListByChild(bool isChild)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaByChild(isChild));
        }

        public static NhanVienList GetNhanVienList(string maNV)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaByMaNV(maNV));
        }

        public static NhanVienList GetNhanVienList(int MaPhongBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaByMaPB(MaPhongBan));
        }

        public static NhanVienList GetNhanVienListByMaChucVu(int MaChucVu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaByMaChucVu(MaChucVu));
        }

      

        public static NhanVienList GetNhanVienListBoPhan(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");

            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaByBoPhan(maBoPhan));
        }

        public static NhanVienList GetNhanVienListBoPhanNgay(int maBoPhan, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");

            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaByBoPhanNgay(maBoPhan, ngay));
        }

        public static NhanVienList GetNhanVienListNghiViecBoPhanNgay(int maBoPhan, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");

            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaNghiViecByBoPhanNgay(maBoPhan, ngay));
        }

        public static NhanVienList GetNhanVienListLichLamViecBoPhanNgay(int maBoPhan, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");

            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaLichLamViecByBoPhanNgay(maBoPhan, ngay));
        }
        public static NhanVienList GetNhanVienListByDanhSachDenHanNangLuong(int loaiNV,DateTime ngayDenHan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");

            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaByDanhSachDenHanNangLuong(loaiNV,ngayDenHan));
        }
        public static NhanVienList GetNhanVienListByDanhSachChuaCoSoBHXH(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");

            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaDanhSachChuaCoSoBHXH(maBoPhan));
        }
        public static NhanVienList GetNhanVienListByDanhSachChuaCoTheBHYT(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");

            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaDanhSachChuaCoTheBHYT(maBoPhan));
        }
        public static NhanVienList GetNhanVienListByDanhSachChuaDongBHTN(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");

            return DataPortal.Fetch<NhanVienList>(new FilterCriteriaDanhSachChuaDongBHTN(maBoPhan));
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
                            this.Add(NhanVien.GetNhanVien(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByMaPB)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanViensAllByBoPan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByMaPB)criteria)._maPB);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVien.GetNhanVienNotChild(dr));
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
                                this.Add(NhanVien.GetNhanVien(dr));
                            }
                        }
                        else
                        {
                            while (dr.Read())
                            {
                                this.Add(NhanVien.GetNhanVienNotChild(dr));
                            }
                        }
                    }
                }//using
            }

            else if (criteria is FilterCriteriaByDanhSachDenHanNangLuong)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachDenHanNangLuong_1";
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriaByDanhSachDenHanNangLuong)criteria).loaiNV);
                    cm.Parameters.AddWithValue("@NgayDenHan", ((FilterCriteriaByDanhSachDenHanNangLuong)criteria).ngayDenHan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVien.GetNhanVienByDenHanNangLuong(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaDanhSachChuaCoSoBHXH)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachChuaCoSoBHXH";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaDanhSachChuaCoSoBHXH)criteria).MaBoPhan);                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVien.GetNhanVienByChuaCoSoBHXH(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaDanhSachChuaCoTheBHYT)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachChuaCoTheBHYT";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaDanhSachChuaCoTheBHYT)criteria).MaBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVien.GetNhanVienByChuaCoTheBHYT(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaDanhSachChuaDongBHTN)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachChuaDongBHTN";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaDanhSachChuaDongBHTN)criteria).MaBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVien.GetNhanVienByChuaCoTheBHYT(dr));
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
                            this.Add(NhanVien.GetNhanVien(dr));
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
                            this.Add(NhanVien.GetNhanVien(dr));
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
                            this.Add(NhanVien. GetNhanVienNotChild(dr));
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
                            this.Add(NhanVien.GetNhanVien(dr));
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
                            this.Add(NhanVien.GetNhanVien(dr));
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
					foreach (NhanVien deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (NhanVien child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch(Exception ex)
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
