using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangCongList : Csla.BusinessListBase<BangCongList, BangCong>
	{   
 
		#region Authorization Rules
		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangCongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangCongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangCongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangCongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangCongList()
		{ /* require use of factory method */ }

		public static BangCongList NewBangCongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangCongList");
			return new BangCongList();
		}

		public static BangCongList GetBangCongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangCongList");
			return DataPortal.Fetch<BangCongList>(new FilterCriteria());
		}
        public static BangCongList GetBangCongList(int MaBoPhan,DateTime NgayChamCong,int MaCa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCongList");
            return DataPortal.Fetch<BangCongList>(new FilterCriteria(MaBoPhan,NgayChamCong,MaCa));
        }
        public static BangCongList TimNhanVienTheoKyLuong(long MaNhanVien, int MaKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCongList");
            return DataPortal.Fetch<BangCongList>(new FilterCriteria_TimNhanVienTheoKyLuong(MaNhanVien, MaKy));
        }
        public static BangCongList TimNhanVienTheoSoGioHC(DateTime Ngay,int MaBoPhan, decimal Tu,decimal Den)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCongList");

            return DataPortal.Fetch<BangCongList>(new FilterCriteria_TimNhanVien_TheoGioHC(Ngay, MaBoPhan, Tu, Den));
        }

        public static BangCongList GetDSNhanVienNghi(DateTime Ngay, int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCongList");

            return DataPortal.Fetch<BangCongList>(new FilterCriteria( MaBoPhan, Ngay,true));
        }
        public static BangCongList TimNhanVien(DateTime ngay, int maBoPhan, string chuoi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChamCongNhanVienList");
            return DataPortal.Fetch<BangCongList>(new FilterCriteria_TimNhanVien(ngay, maBoPhan, chuoi));
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

            public DateTime NgayChamCong;
            public int MaCa=0;
            public int MaBoPhan;
            public bool Nghi = false;

            public FilterCriteria(int MaBoPhan,DateTime Ngay, int Ca)
            {
                this.NgayChamCong = Ngay;
                this.MaCa = Ca;
                this.MaBoPhan = MaBoPhan;
            }
            public FilterCriteria(int MaBoPhan, DateTime Ngay, bool _Nghi)
            {
                this.NgayChamCong = Ngay;
                this.MaBoPhan = MaBoPhan;
                this.Nghi = _Nghi;
            }
		}
        private class FilterCriteria_TimNhanVienTheoKyLuong
        {
            public long MaNhanVien;
            public int MaKy;
            public FilterCriteria_TimNhanVienTheoKyLuong(long MaNhanVien, int MaKy)
            {
                this.MaNhanVien = MaNhanVien;
                this.MaKy = MaKy;
            }
        }
        private class FilterCriteria_TimNhanVien_TheoGioHC
        {
            public DateTime Ngay;
            public int MaBoPhan;
            public decimal Tu, Den;

            public FilterCriteria_TimNhanVien_TheoGioHC(DateTime ngay, int maBoPhan, decimal tu, decimal den)
            {
                this.Ngay = ngay;
                this.MaBoPhan = maBoPhan;
                this.Tu = tu;
                this.Den = den;
            }
        }
        private class FilterCriteria_TimNhanVien
        {
            public DateTime Ngay;
            public int MaBoPhan;
            public string chuoiTimNhanVien;

            public FilterCriteria_TimNhanVien(DateTime ngay, int MaBoPhan, string chuoi)
            {
                this.Ngay = ngay;
                this.MaBoPhan = MaBoPhan;
                this.chuoiTimNhanVien = chuoi;
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

                    if (((FilterCriteria)criteria).Nghi)
                    {
                        cm.CommandText = "spd_ChamCong_NhanVienNghi_N";
                    }
                    else
                    {
                        cm.CommandText = "spd_LayDSChamCongNV";
                        cm.Parameters.AddWithValue("@MaCa", ((FilterCriteria)criteria).MaCa);
                    }
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@NgayChamCong", ((FilterCriteria)criteria).NgayChamCong);
                    //if (criteria.MaCa != 0)
                    //    cm.CommandText += " and MaQuanLy='" + (CaLamViec.GetCaLamViec(criteria.MaCa)).MaQuanLy + "'";
                    //if (!criteria.NgayChamCong.Equals(DateTime.Parse("1/1/0001")))
                    //    cm.CommandText += " and NgayChamCong='" + criteria.NgayChamCong + "'";
                }
                else if (criteria is FilterCriteria_TimNhanVien)
                {
                    cm.CommandText = "spd_ChamCongBangTay_TimNhanVien_N";
                    cm.Parameters.AddWithValue("@NgayChamCong", ((FilterCriteria_TimNhanVien)criteria).Ngay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_TimNhanVien)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@Chuoi", ((FilterCriteria_TimNhanVien)criteria).chuoiTimNhanVien);
                }
                else if (criteria is FilterCriteria_TimNhanVienTheoKyLuong)
                {
                    cm.CommandText = "spd_TimNhanVienTheoKyLuong_N";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria_TimNhanVienTheoKyLuong)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteria_TimNhanVienTheoKyLuong)criteria).MaKy);
                }
                else if (criteria is FilterCriteria_TimNhanVien_TheoGioHC)
                {
                    cm.CommandText = "spd_TimNhanVien_TheoGioHC_N";
                    cm.Parameters.AddWithValue("@Ngay", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).Ngay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@Tu", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).Tu);
                    cm.Parameters.AddWithValue("@Den", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).Den);
                }
               
                try
                {
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BangCong.GetBangCong(dr));
                    }
                }
                catch (Exception ex) 
                { }
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
				foreach (BangCong deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (BangCong child in this)
				{
					if (child.IsNew)
						child.Insert(cn,this);
					else
                        child.Update(cn, this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
