using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TenNhanVienList : Csla.BusinessListBase<TenNhanVienList, TenNV>
	{
		#region Authorization Rules



		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TenNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TenNhanVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TenNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TenNhanVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TenNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TenNhanVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TenNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TenNhanVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

        
		#region Factory Methods
		private TenNhanVienList()
		{ /* require use of factory method */ }

		public static TenNhanVienList NewTenNhanVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TenNhanVienList");
			return new TenNhanVienList();
		}

		public static TenNhanVienList GetTenNhanVienList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
			return DataPortal.Fetch<TenNhanVienList>(new FilterCriteria());
		}
        public static TenNhanVienList GetTenNhanVienList_NguoiDaiDienHopDong()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaNguoiDaiDienHopDong());
        }

        public static TenNhanVienList GetTenNhanVienList(long maNV)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaByMaNV(maNV));
        }

        public static TenNhanVienList GetTenNhanVienChucVuList(int maChucVu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaByChucVu(maChucVu));
        }

        public static TenNhanVienList GetTenNhanVienList_Nghi(DateTime Ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaByNghi(Ngay));
        }

        public static TenNhanVienList GetTenNhanVienList_BoPhan(int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaByBoPhan(MaBoPhan));
        }

        public static TenNhanVienList GetTenNhanVienList_NghiMaNV(string maNV)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaByNghiMaNV(maNV));
        }

        public static TenNhanVienList GetTenNhanVienListAllCty(int maCty, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaByAllCty(maCty, ngay));
        }



        public static TenNhanVienList GetNhanVienListLichLamViecBoPhanNgay(int MaBoPhan, DateTime ngayTao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaLichLamViecByBoPhanNgay(MaBoPhan, ngayTao));
        }

        public static TenNhanVienList GetNhanVienNghi(int maBoPhan, int tuNam, int denNam, byte loaiNV)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<TenNhanVienList>(new FilterCriteriaByNhanVienNghi(maBoPhan, tuNam, denNam, loaiNV));
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
        private class FilterCriteriaNguoiDaiDienHopDong
        {
            public FilterCriteriaNguoiDaiDienHopDong()
            {
            }
        }
        private class FilterCriteriaLichLamViecByBoPhanNgay
        {
            public int MaBoPhan;
            public DateTime ngay;

            public FilterCriteriaLichLamViecByBoPhanNgay(int maBoPhan, DateTime Ngay)
            {
                this.MaBoPhan = maBoPhan;
                this.ngay = Ngay;
            }
        }
        private class FilterCriteriaByChucVu
        {
            public int maChucVu;

            public FilterCriteriaByChucVu(int maChucVu)
            {
                this.maChucVu = maChucVu;
            }
        }

        private class FilterCriteriaByBoPhan
        {
            public int maBoPhan;
         
            public FilterCriteriaByBoPhan(int MaBoPhan)
            {
                this.maBoPhan = MaBoPhan;
               
            }
        }

        private class FilterCriteriaByAllCty
        {
            public int maCty;
            public DateTime ngay;
            public FilterCriteriaByAllCty(int maCty, DateTime ngay)
            {
                this.maCty = maCty;
                this.ngay = ngay;
            }
        }

        private class FilterCriteriaByNghi
        {
            public DateTime _Ngay;
            public FilterCriteriaByNghi(DateTime ngay)
            {
                this._Ngay = ngay;
            }
        }

        private class FilterCriteriaByNghiMaNV
        {
            public string maNV;
            public FilterCriteriaByNghiMaNV(string maNV)
            {
                this.maNV = maNV;
            }
        }

        private class FilterCriteriaByMaNV
        {
            public long maNV;
            public FilterCriteriaByMaNV(long maNV)
            {
                this.maNV = maNV;
            }
        }

        private class FilterCriteriaByNhanVienNghi
        {
            public int mabophan;
            public int tuNam;
            public int denNam;
            public int loaiNV;
            public FilterCriteriaByNhanVienNghi(int mabophan, int TuNam, int DenNam, int LoaiNV)
            {
                this.mabophan = mabophan;
                this.tuNam = TuNam;
                this.denNam = DenNam;
                this.loaiNV = LoaiNV;
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
                catch (Exception ex)
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
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByChucVu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienByChucVu";
                    cm.Parameters.AddWithValue("@MaChucVu", ((FilterCriteriaByChucVu)criteria).maChucVu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByMaNV)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienByMaNV";
                    cm.Parameters.AddWithValue("@MaNV", ((FilterCriteriaByMaNV)criteria).maNV);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByNghi)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienByNghi";
                    cm.Parameters.AddWithValue("@Ngay", ((FilterCriteriaByNghi)criteria)._Ngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByNghiMaNV)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienByNghiMaNV";
                    cm.Parameters.AddWithValue("@MaNV", ((FilterCriteriaByNghiMaNV)criteria).maNV);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByAllCty)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienAllCty";
                    cm.Parameters.AddWithValue("@MaCty", ((FilterCriteriaByAllCty)criteria).maCty);
                    cm.Parameters.AddWithValue("@Ngay", ((FilterCriteriaByAllCty)criteria).ngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByNhanVienNghi)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienNghiAll";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNhanVienNghi)criteria).mabophan);
                    cm.Parameters.AddWithValue("@TuNam", ((FilterCriteriaByNhanVienNghi)criteria).tuNam);
                    cm.Parameters.AddWithValue("@DenNam", ((FilterCriteriaByNhanVienNghi)criteria).denNam);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriaByNhanVienNghi)criteria).loaiNV);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaLichLamViecByBoPhanNgay)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_Select_NhanVienLichLamViecBoPhanNgay";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaLichLamViecByBoPhanNgay)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@NgayTao", ((FilterCriteriaLichLamViecByBoPhanNgay)criteria).ngay.ToShortDateString());
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByNhanVienNghi)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienNghiAll";
                    cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaByNhanVienNghi)criteria).mabophan);
                    cm.Parameters.AddWithValue("@TuNam", ((FilterCriteriaByNhanVienNghi)criteria).tuNam);
                    cm.Parameters.AddWithValue("@DenNam", ((FilterCriteriaByNhanVienNghi)criteria).denNam);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriaByNhanVienNghi)criteria).loaiNV);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaByBoPhan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienByBoPhan";
                    cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaByBoPhan)criteria).maBoPhan);
                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
                    }
                }
            }
            else if (criteria is FilterCriteriaNguoiDaiDienHopDong)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanViensAll_NguoiDaiDienHopDong";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TenNV.GetTenNhanVien(dr));
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
					foreach (TenNV deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TenNV child in this)
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
