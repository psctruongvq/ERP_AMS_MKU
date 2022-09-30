
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyLuatTheoNhanVienList : Csla.BusinessListBase<KyLuatTheoNhanVienList, KyLuatTheoNhanVien>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KyLuatTheoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyLuatTheoNhanVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KyLuatTheoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyLuatTheoNhanVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KyLuatTheoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyLuatTheoNhanVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KyLuatTheoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyLuatTheoNhanVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KyLuatTheoNhanVienList()
		{ /* require use of factory method */ }

		public static KyLuatTheoNhanVienList NewKyLuatTheoNhanVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyLuatTheoNhanVienList");
			return new KyLuatTheoNhanVienList();
		}

		public static KyLuatTheoNhanVienList GetKyLuatTheoNhanVienList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KyLuatTheoNhanVienList");
			return DataPortal.Fetch<KyLuatTheoNhanVienList>(new FilterCriteria(maNhanVien));
		}

        public static KyLuatTheoNhanVienList GetKyLuatTheoNhanVienList_To_Nam(int MaChiNhanh, int MaPhongBan, int MaTo, DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyLuatTheoNhanVienList");
             return DataPortal.Fetch<KyLuatTheoNhanVienList>(new FilterCriteriaTheoTo_Nam(MaChiNhanh,MaPhongBan,MaTo,TuNgay,DenNgay));
        }

        public static KyLuatTheoNhanVienList GetKyLuatTheoNhanVienList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyLuatTheoNhanVienList");
            return DataPortal.Fetch<KyLuatTheoNhanVienList>(new FilterCriteriaAll());
        }
        public static KyLuatTheoNhanVienList GetKyLuatTheoNhanVienListByNgayLap(DateTime tungay, DateTime denngay,int maHinhThuc,long maNhanVien,int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyLuatTheoNhanVienList");
            return DataPortal.Fetch<KyLuatTheoNhanVienList>(new FilterCriteriaByNgay(tungay,denngay,maHinhThuc,maNhanVien,maBoPhan));
        }
        public static KyLuatTheoNhanVienList GetKyLuatTheoNhanVienListByNgay(int maHinhThuc, int MaCapQuyetDinh, long maNhanVien, int maBophan, DateTime tuNgay, DateTime denNgay)
        {
            return DataPortal.Fetch<KyLuatTheoNhanVienList>(new FilterCriteriaByNhanVien(tuNgay,denNgay,maHinhThuc,MaCapQuyetDinh,maNhanVien,maBophan));
        }
        //public static KyLuatTheoNhanVienList GetKyLuatTheoNhanVienListByNgayKetThuc(DateTime tungay, DateTime denngay)
        //{
        //    if (!CanGetObject())
        //        throw new System.Security.SecurityException("User not authorized to view a KyLuatTheoNhanVienList");
        //    return DataPortal.Fetch<KyLuatTheoNhanVienList>(new FilterCriteriaByNgayKetThuc(tungay, denngay, maHinhThuc, maNhanVien, maBoPhan));
        //}
        public static KyLuatTheoNhanVienList GetKyLuatTheoNhanVienListBySoQD(string SoQD, DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyLuatTheoNhanVienList");
            return DataPortal.Fetch<KyLuatTheoNhanVienList>(new FilterCriteriaBySoQD(SoQD,tungay,denngay));
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
        private class FilterCriteriaTheoTo_Nam
        {
            public int MaChiNhanh;
            public int MaPhongBan;
            public int MaTo;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaTheoTo_Nam(int maChiNhanh, int maPhongBan, int maTo, DateTime tuNgay, DateTime denNgay)
            {
                this.MaChiNhanh=maChiNhanh;
                this.MaPhongBan = maPhongBan;
                this.MaTo = maTo;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
            }
        }

        private class FilterCriteriaByNgayKetThuc
        {
            public DateTime Tungay;
            public DateTime Denngay;
        
            public FilterCriteriaByNgayKetThuc(DateTime tungay, DateTime denngay)
            {
                this.Tungay = tungay;
                this.Denngay = denngay;
                
            }
        }
        private class FilterCriteriaByNgay
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public int MaHinhThuc;
            
            public long MaNhanVien;
            public int MaBoPhan;
            public FilterCriteriaByNgay(DateTime tungay, DateTime denngay, int maHinhThuc, long maNhanVien, int maBoPhan)
            {
                this.Tungay = tungay;
                this.Denngay = denngay;
                this.MaHinhThuc = maHinhThuc;
                this.MaNhanVien = maNhanVien;
                this.MaBoPhan = maBoPhan;
               
            }
        }
        private class FilterCriteriaByNhanVien
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public int MaHinhThuc;
            public int MaCapQuyetDinh;
            public long MaNhanVien;
            public int MaBoPhan;
            public FilterCriteriaByNhanVien(DateTime tungay, DateTime denngay, int maHinhThuc,int maCapQuyetDinh, long maNhanVien, int maBoPhan)
            {
                this.Tungay = tungay;
                this.Denngay = denngay;
                this.MaHinhThuc = maHinhThuc;
                this.MaNhanVien = maNhanVien;
                this.MaBoPhan = maBoPhan;
                this.MaCapQuyetDinh = maCapQuyetDinh;
            }
        }
        
        private class FilterCriteriaBySoQD
        {
            public DateTime tungay; 
            public DateTime denngay; 
            public string SoQD;

            public FilterCriteriaBySoQD(string soQD,DateTime tungay, DateTime denngay)
            {
                this.SoQD = soQD;
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

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
            try
            {
                if (criteria is FilterCriteria)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsKyLuatTungNhanViens";
                        cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KyLuatTheoNhanVien.GetKyLuatTheoNhanVien(dr));
                        }
                    }//using
                }
                else if (criteria is FilterCriteriaAll)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsKyLuatTungNhanViensAll";
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KyLuatTheoNhanVien.GetKyLuatTheoNhanVien(dr));
                        }
                    }//using
                }
                else if (criteria is FilterCriteriaTheoTo_Nam)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsKyLuatTungNhanVienTheoTo_Nam";
                        cm.Parameters.AddWithValue("@MaChiNhanh", ((FilterCriteriaTheoTo_Nam)criteria).MaChiNhanh);
                        cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaTheoTo_Nam)criteria).MaPhongBan);
                        cm.Parameters.AddWithValue("@MaTo", ((FilterCriteriaTheoTo_Nam)criteria).MaTo);
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaTheoTo_Nam)criteria).TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaTheoTo_Nam)criteria).DenNgay);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KyLuatTheoNhanVien.GetKyLuatTheoNhanVien(dr));
                        }
                    }//using
                }

                else if (criteria is FilterCriteriaByNgay)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsKyLuatTungNhanViensByNgay";
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgay)criteria).Tungay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgay)criteria).Denngay);
                        cm.Parameters.AddWithValue("@MaHinhThuc", ((FilterCriteriaByNgay)criteria).MaHinhThuc);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNgay)criteria).MaNhanVien);
                        cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByNgay)criteria).MaBoPhan);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KyLuatTheoNhanVien.GetKyLuatTheoNhanVien(dr));
                        }
                    }//using
                }
                else if (criteria is FilterCriteriaByNhanVien)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsKyLuatTungNhanViensByNhanVien";
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNhanVien)criteria).Tungay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNhanVien)criteria).Denngay);
                        cm.Parameters.AddWithValue("@MaHinhThuc", ((FilterCriteriaByNhanVien)criteria).MaHinhThuc);
                        cm.Parameters.AddWithValue("@MaCapQuyetDinh", ((FilterCriteriaByNhanVien)criteria).MaCapQuyetDinh);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNhanVien)criteria).MaNhanVien);
                        cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByNhanVien)criteria).MaBoPhan);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KyLuatTheoNhanVien.GetKyLuatTheoNhanVien(dr));
                        }
                    }//using
                }
                else if (criteria is FilterCriteriaBySoQD)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsKyLuatTungNhanViensBySoQD";
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaBySoQD)criteria).tungay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaBySoQD)criteria).denngay);
                        cm.Parameters.AddWithValue("@SoQD", ((FilterCriteriaBySoQD)criteria).SoQD);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KyLuatTheoNhanVien.GetKyLuatTheoNhanVien(dr));
                        }
                    }//using
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

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();
                try
                {
                    // loop through each deleted child object
                    foreach (KyLuatTheoNhanVien deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (KyLuatTheoNhanVien child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn);
                        else
                            child.Update(cn);
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
