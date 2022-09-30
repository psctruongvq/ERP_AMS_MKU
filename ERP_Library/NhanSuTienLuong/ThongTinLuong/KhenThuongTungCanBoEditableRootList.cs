
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhenThuongTungCanBoList : Csla.BusinessListBase<KhenThuongTungCanBoList, KhenThuongTungCanBo>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KhenThuongTungCanBo item = KhenThuongTungCanBo.NewKhenThuongTungCanBo();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KhenThuongTungCanBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongTungCanBoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KhenThuongTungCanBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongTungCanBoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KhenThuongTungCanBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongTungCanBoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KhenThuongTungCanBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongTungCanBoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KhenThuongTungCanBoList()
		{ /* require use of factory method */ }

		public static KhenThuongTungCanBoList NewKhenThuongTungCanBoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhenThuongTungCanBoList");
			return new KhenThuongTungCanBoList();
		}

		public static KhenThuongTungCanBoList GetKhenThuongTungCanBoList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KhenThuongTungCanBoList");
			return DataPortal.Fetch<KhenThuongTungCanBoList>(new FilterCriteria(maNhanVien));
		}

        public static KhenThuongTungCanBoList GetKhenThuongTungCanBoList_TheoTo_Nam(int maChiNhanh, int maPhongBan, int maTo, DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhenThuongTungCanBoList");
            return DataPortal.Fetch<KhenThuongTungCanBoList>(new FilterCriteriaTheoTo_Nam(maChiNhanh, maPhongBan, maTo, TuNgay, DenNgay));
        }

        public static KhenThuongTungCanBoList GetKhenThuongTungCanBoAllList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhenThuongTungCanBoList");
            return DataPortal.Fetch<KhenThuongTungCanBoList>(new FilterCriteriaAll());
        }

        public static KhenThuongTungCanBoList GetKhenThuongTungCanBoListByNgay(int hinhThuc,int danhHieu,int maCapQuyetDinh,long maNhanVien,int maBoPhan,DateTime Tungay, DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhenThuongTungCanBoList");
            return DataPortal.Fetch<KhenThuongTungCanBoList>(new FilterCriteriaByNgay(hinhThuc,danhHieu,maCapQuyetDinh,maNhanVien,maBoPhan, Tungay,Denngay));
        }
        public static KhenThuongTungCanBoList GetKhenThuongTungCanBoListBySoQD(string SoQD, DateTime Tungay, DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhenThuongTungCanBoList");
            return DataPortal.Fetch<KhenThuongTungCanBoList>(new FilterCriteriaBySoQD(SoQD, Tungay,Denngay));
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
                this.MaChiNhanh = maChiNhanh;
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

        private class FilterCriteriaByNgay
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public int MaDanhHieu;
            public int MaHinhThuc;
            public int MaCapQuyetDinh;
            public long MaNhanVien;
            public int MaBoPhan;
            public FilterCriteriaByNgay(int hinhThuc, int danhHieu,int maCapQuyetDinh, long maNhanVien, int maBoPhan, DateTime Tungay, DateTime Denngay)
            {
                this.MaHinhThuc = hinhThuc;
                this.MaDanhHieu = danhHieu;
                this.MaCapQuyetDinh = maCapQuyetDinh;
                this.MaNhanVien = maNhanVien;
                this.MaBoPhan = maBoPhan;
                this.Tungay = Tungay;
                this.Denngay = Denngay;
            }
        }
        private class FilterCriteriaBySoQD
        {
            public DateTime Tungay;
            public DateTime Denngay;
            public string SoQD;

            public FilterCriteriaBySoQD(string SoQD,DateTime Tungay, DateTime Denngay)
            {
                this.SoQD = SoQD;
                this.Tungay = Tungay;
                this.Denngay = Denngay;
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
                        cm.CommandText = "SelecttblnsKhenThuongTungCanBoTheoNhanVien";
                        cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KhenThuongTungCanBo.GetKhenThuongTungCanBo(dr));
                        }
                    }//using
                }
                else if (criteria is FilterCriteriaTheoTo_Nam)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelecttblnsKhenThuongTungCanBoTheoTo_Nam";
                        cm.Parameters.AddWithValue("@MaChiNhanh", ((FilterCriteriaTheoTo_Nam)criteria).MaChiNhanh);
                        cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteriaTheoTo_Nam)criteria).MaPhongBan);
                        cm.Parameters.AddWithValue("@MaTo", ((FilterCriteriaTheoTo_Nam)criteria).MaTo);
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaTheoTo_Nam)criteria).TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaTheoTo_Nam)criteria).DenNgay);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KhenThuongTungCanBo.GetKhenThuongTungCanBo(dr));
                        }
                    }//using
                }
                else if (criteria is FilterCriteriaAll)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelecttblnsKhenThuongTungCanBosAll";
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KhenThuongTungCanBo.GetKhenThuongTungCanBo(dr));
                        }
                    }//using
                }
                else  if (criteria is FilterCriteriaByNgay)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblnsKhenThuongTungCanBoTheoNgay";
                        cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaByNgay)criteria).Tungay);
                        cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaByNgay)criteria).Denngay);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNgay)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByNgay)criteria).MaNhanVien);
                        cm.Parameters.AddWithValue("@MaDanhHieu", ((FilterCriteriaByNgay)criteria).MaDanhHieu);
                        cm.Parameters.AddWithValue("@MaCapQuyetDinh", ((FilterCriteriaByNgay)criteria).MaCapQuyetDinh);
                        cm.Parameters.AddWithValue("@MaHinhThucKhenThuong", ((FilterCriteriaByNgay)criteria).MaHinhThuc);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KhenThuongTungCanBo.GetKhenThuongTungCanBo(dr));
                        }
                    }//using
                }
                else if (criteria is FilterCriteriaBySoQD)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelecttblnsKhenThuongTungCanBoTheoSoQD";
                        cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaBySoQD)criteria).Tungay);
                        cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaBySoQD)criteria).Denngay);
                        cm.Parameters.AddWithValue("@SoQD", ((FilterCriteriaBySoQD)criteria).SoQD);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(KhenThuongTungCanBo.GetKhenThuongTungCanBo(dr));
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

			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					// loop through each deleted child object
					foreach (KhenThuongTungCanBo deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KhenThuongTungCanBo child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr,this);
					}

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
		
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
