
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThoiViecList : Csla.BusinessListBase<ThoiViecList, ThoiViec>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ThoiViec item = ThoiViec.NewThoiViec();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThoiViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThoiViecListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThoiViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThoiViecListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThoiViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThoiViecListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThoiViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThoiViecListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThoiViecList()
		{ /* require use of factory method */ }

		public static ThoiViecList NewThoiViecList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThoiViecList");
			return new ThoiViecList();
		}

		public static ThoiViecList GetThoiViecList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThoiViecList");
			return DataPortal.Fetch<ThoiViecList>(new FilterCriteria());
		}

        public static ThoiViecList GetThoiViecList(long MaNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThoiViecList");
            return DataPortal.Fetch<ThoiViecList>(new FilterCriteriaByNhanVien(MaNhanVien));
        }

        public static ThoiViecList GetThoiViecListByNgay(DateTime Tungay, DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThoiViecList");
            return DataPortal.Fetch<ThoiViecList>(new FilterCriteriaByNgay(Tungay, Denngay));
        }

        public static ThoiViecList GetThoiViecListTheoSoQD(string SoQuyetDinh,DateTime Tungay, DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThoiViecList");
            return DataPortal.Fetch<ThoiViecList>(new FilterCriteriaBySoQD(SoQuyetDinh, Tungay, Denngay));
        }
        public static ThoiViecList GetThoiViecListSoQD()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThoiViecList");
            return DataPortal.Fetch<ThoiViecList>(new FilterCriteriaSoQD());
        }
        public static ThoiViecList GetThoiViecListByNgayAndNV(DateTime Tungay, DateTime Denngay,long manhanvien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThoiViecList");
            return DataPortal.Fetch<ThoiViecList>(new FilterCriteriaByNgayAndNV(Tungay, Denngay,manhanvien));
        }

        public static ThoiViecList GetThoiViecListChuaPhucHoiByNgay(DateTime Tungay, DateTime Denngay, int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThoiViecList");
            return DataPortal.Fetch<ThoiViecList>(new FilterCriteriaChuaPhucHoiByNgay(Tungay, Denngay, mabophan));
        }
        public static ThoiViecList GetThoiViecListChuaPhucHoiByNgayAndNV(DateTime Tungay, DateTime Denngay, long manhanvien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThoiViecList");
            return DataPortal.Fetch<ThoiViecList>(new FilterCriteriaChuaPhucHoiByNgayAndNV(Tungay, Denngay, manhanvien));
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
        private class FilterCriteriaSoQD
        {
            public FilterCriteriaSoQD()
            {

            }
        }
        private class FilterCriteriaByNgay
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public FilterCriteriaByNgay(DateTime Tungay, DateTime Denngay)
            {
                this.Tungay = Tungay;
                this.Denngay = Denngay;
            }
        }
        private class FilterCriteriaChuaPhucHoiByNgay
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public int mabophan;
            public FilterCriteriaChuaPhucHoiByNgay(DateTime Tungay, DateTime Denngay,int mabophan)
            {
                this.Tungay = Tungay;
                this.Denngay = Denngay;
                this.mabophan = mabophan;
            }
        }
        private class FilterCriteriaByNgayAndNV
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public long manhanvien;
            public FilterCriteriaByNgayAndNV(DateTime Tungay, DateTime Denngay,long manhanvien)
            {
                this.Tungay = Tungay;
                this.Denngay = Denngay;
                this.manhanvien = manhanvien;
            }
        }
        private class FilterCriteriaChuaPhucHoiByNgayAndNV
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public long manhanvien;
            public FilterCriteriaChuaPhucHoiByNgayAndNV(DateTime Tungay, DateTime Denngay, long manhanvien)
            {
                this.Tungay = Tungay;
                this.Denngay = Denngay;
                this.manhanvien = manhanvien;
            }
        }
        private class FilterCriteriaBySoQD
        {
            public string SoQD;
            public DateTime Tungay;
            public DateTime Denngay;
            public FilterCriteriaBySoQD(string SoQD,DateTime Tungay, DateTime Denngay)
            {
                this.SoQD = SoQD;
                this.Tungay = Tungay;
                this.Denngay = Denngay;
            }
        }
        private class FilterCriteriaByNhanVien
        {
            public long maNhanVien;
            public FilterCriteriaByNhanVien(long MaNhanVien)
            {
                this.maNhanVien = MaNhanVien;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                      HamDungChung.ThongBaoLoi(ex);
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
                    cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLDsAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThoiViec.GetThoiViec(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByNhanVien)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLDByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByNhanVien)criteria).maNhanVien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThoiViec.GetThoiViec(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByNgay)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLDByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgay)criteria).Tungay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgay)criteria).Denngay.Date);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThoiViec.GetThoiViec(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaChuaPhucHoiByNgay)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLDChuaPhucHoiByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaChuaPhucHoiByNgay)criteria).Tungay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaChuaPhucHoiByNgay)criteria).Denngay.Date);
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaChuaPhucHoiByNgay)criteria).mabophan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThoiViec.GetThoiViec(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByNgay)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLDByNgayAndNV";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayAndNV)criteria).Tungay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayAndNV)criteria).Denngay.Date);
                    cm.Parameters.AddWithValue("@Manhanvien", ((FilterCriteriaByNgayAndNV)criteria).manhanvien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThoiViec.GetThoiViec(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaChuaPhucHoiByNgayAndNV)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLDChuaPhucHoiByNgayAndNV";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaChuaPhucHoiByNgayAndNV)criteria).Tungay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaChuaPhucHoiByNgayAndNV)criteria).Denngay.Date);
                    cm.Parameters.AddWithValue("@Manhanvien", ((FilterCriteriaChuaPhucHoiByNgayAndNV)criteria).manhanvien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThoiViec.GetThoiViec(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaBySoQD)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLDBySoQD";
                    cm.Parameters.AddWithValue("@SoQD", ((FilterCriteriaBySoQD)criteria).SoQD);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaBySoQD)criteria).Tungay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaBySoQD)criteria).Denngay.Date);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThoiViec.GetThoiViec(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaSoQD)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLDSoQD";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            //this.Add(ThoiViec.GetThoiViec(dr));
                            this.Add(ThoiViec.GetSoQuyetDinh(dr));
                    }
                }//using
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
					foreach (ThoiViec deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ThoiViec child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
