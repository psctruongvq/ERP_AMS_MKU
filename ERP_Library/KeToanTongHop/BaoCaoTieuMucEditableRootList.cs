
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoCaoTieuMucList : Csla.BusinessListBase<BaoCaoTieuMucList, BaoCaoTieuMuc>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BaoCaoTieuMucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoTieuMucListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BaoCaoTieuMucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoTieuMucListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BaoCaoTieuMucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoTieuMucListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BaoCaoTieuMucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoTieuMucListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BaoCaoTieuMucList()
		{ /* require use of factory method */ }

		public static BaoCaoTieuMucList NewBaoCaoTieuMucList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCaoTieuMucList");
			return new BaoCaoTieuMucList();
		}

		public static BaoCaoTieuMucList GetBaoCaoTieuMucList( DateTime tuNgay, DateTime denNgay, string mabophan, string maMucNganSach, string taikhoan, string matieumuc, int nguoilap)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BaoCaoTieuMucList");
			return DataPortal.Fetch<BaoCaoTieuMucList>(new FilterCriteria(tuNgay, denNgay, mabophan, maMucNganSach, taikhoan, matieumuc, nguoilap));
		}

        public static BaoCaoTieuMucList GetBaoCaoTheoMuc(DateTime tuNgay, DateTime denNgay, string mabophan, string maMucNganSach, string matieumuc)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BaoCaoTieuMucList");
            return DataPortal.Fetch<BaoCaoTieuMucList>(new FilterCriteriaTheoMuc(tuNgay, denNgay, mabophan, maMucNganSach, matieumuc));
        }

        //public static BaoCaoTieuMucList GetBaoCaoTieuMucLuyKe(DateTime tuNgay, DateTime denNgay, string mabophan, string maMucNganSach, string taikhoan, string matieumuc, int nguoilap)
        //{
        //    if (!CanGetObject())
        //        throw new System.Security.SecurityException("User not authorized to view a BaoCaoTieuMucList");
        //    return DataPortal.Fetch<BaoCaoTieuMucList>(new FilterCriteriaLuyKe(tuNgay, denNgay, mabophan, maMucNganSach, taikhoan, matieumuc, nguoilap));
        //}


        public static decimal GetBaoCaoTieuMucSoDuDau(DateTime tuNgay, DateTime denNgay, string mabophan, string maMucNganSach, string taikhoan, string matieumuc, int nguoilap)
        {
            decimal giaTriTraVe = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_BaoCaoTieuMucSoDuDau]";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan",mabophan);
                    cm.Parameters.AddWithValue("@MaMucNganSach", maMucNganSach);
                    cm.Parameters.AddWithValue("@MaTieuMuc", matieumuc);

                    cm.Parameters.AddWithValue("@TaiKhoan", taikhoan);
                    cm.Parameters.AddWithValue("@NguoiLap", nguoilap);
                    cm.ExecuteScalar();
                    giaTriTraVe = (decimal)cm.ExecuteScalar();
                }
            }//us

            return giaTriTraVe;
        }


        public static decimal GetBaoCaoTieuMucLuyKe(DateTime tuNgay, DateTime denNgay, string mabophan, string maMucNganSach, string taikhoan, string matieumuc, int nguoilap)
        {
            decimal giaTriTraVe = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_BaoCaoTieuMucLuyKe]";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", mabophan);
                    cm.Parameters.AddWithValue("@MaMucNganSach", maMucNganSach);
                    cm.Parameters.AddWithValue("@MaTieuMuc", matieumuc);

                    cm.Parameters.AddWithValue("@TaiKhoan", taikhoan);
                    cm.Parameters.AddWithValue("@NguoiLap", nguoilap);
                    cm.ExecuteScalar();
                    giaTriTraVe = (decimal)cm.ExecuteScalar();
                }
            }//us

            return giaTriTraVe;
        }

		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
           public DateTime tuNgay;
           public DateTime denNgay;
           public string maBoPhan;
           public string maMucNganSach;
           public string maTaiKhoan;
           public string maTieuMuc;
           public int NguoiLap;
           public FilterCriteria(DateTime tungay, DateTime denngay, string mabophan, string mamucngansach, string mataikhoan, string matieumuc, int nguoilap)
           {
               this.tuNgay = tungay;
               this.denNgay = denngay;
               this.maBoPhan = mabophan;
               this.maMucNganSach = mamucngansach;
               this.maTaiKhoan = mataikhoan;
               this.maTieuMuc = matieumuc;
               this.NguoiLap = nguoilap;
           }
		}


        private class FilterCriteriaTheoMuc
        {
            public DateTime tuNgay;
            public DateTime denNgay;
            public string maBoPhan;
            public string maMucNganSach;            
            public string maTieuMuc;
            
            public FilterCriteriaTheoMuc(DateTime tungay, DateTime denngay, string mabophan, string mamucngansach, string matieumuc)
            {
                this.tuNgay = tungay;
                this.denNgay = denngay;
                this.maBoPhan = mabophan;
                this.maMucNganSach = mamucngansach;
                this.maTieuMuc = matieumuc;              
            }
        }

        private class FilterCriteriaLuyKe
        {
            public DateTime tuNgay;
            public DateTime denNgay;
            public string maBoPhan;
            public string maMucNganSach;
            public string maTaiKhoan;
            public string maTieuMuc;
            public int NguoiLap;
            public FilterCriteriaLuyKe(DateTime tungay, DateTime denngay, string mabophan, string mamucngansach, string mataikhoan, string matieumuc, int nguoilap)
            {
                this.tuNgay = tungay;
                this.denNgay = denngay;
                this.maBoPhan = mabophan;
                this.maMucNganSach = mamucngansach;
                this.maTaiKhoan = mataikhoan;
                this.maTieuMuc = matieumuc;
                this.NguoiLap = nguoilap;
            }
        }

        private class FilterCriteriaSoDuDau
        {
            public DateTime tuNgay;
            public DateTime denNgay;
            public string maBoPhan;
            public string maMucNganSach;
            public string maTaiKhoan;
            public string maTieuMuc;
            public int NguoiLap;
            public FilterCriteriaSoDuDau(DateTime tungay, DateTime denngay, string mabophan, string mamucngansach, string mataikhoan, string matieumuc, int nguoilap)
            {
                this.tuNgay = tungay;
                this.denNgay = denngay;
                this.maBoPhan = mabophan;
                this.maMucNganSach = mamucngansach;
                this.maTaiKhoan = mataikhoan;
                this.maTieuMuc = matieumuc;
                this.NguoiLap = nguoilap;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoTieuMuc";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaMucNganSach", ((FilterCriteria)criteria).maMucNganSach);
                    cm.Parameters.AddWithValue("@MaTieuMuc", ((FilterCriteria)criteria).maTieuMuc);

                    cm.Parameters.AddWithValue("@TaiKhoan", ((FilterCriteria)criteria).maTaiKhoan);
                    cm.Parameters.AddWithValue("@NguoiLap", ((FilterCriteria)criteria).NguoiLap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BaoCaoTieuMuc.GetBaoCaoTieuMuc(dr));
                    }
                }
                if (criteria is FilterCriteriaTheoMuc)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoTieuMucChiTiet";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaTheoMuc)criteria).tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaTheoMuc)criteria).denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaTheoMuc)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaMucNganSach", ((FilterCriteriaTheoMuc)criteria).maMucNganSach);
                    cm.Parameters.AddWithValue("@MaTieuMuc", ((FilterCriteriaTheoMuc)criteria).maTieuMuc);
                   
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BaoCaoTieuMuc.GetBaoCaoTieuMuc(dr));
                    }
                }

                else if (criteria is FilterCriteriaSoDuDau)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_BaoCaoTieuMucSoDuDau]";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaSoDuDau)criteria).tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaSoDuDau)criteria).denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaSoDuDau)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaMucNganSach", ((FilterCriteriaSoDuDau)criteria).maMucNganSach);
                    cm.Parameters.AddWithValue("@MaTieuMuc", ((FilterCriteriaSoDuDau)criteria).maTieuMuc);
                    cm.Parameters.AddWithValue("@TaiKhoan", ((FilterCriteriaSoDuDau)criteria).maTaiKhoan);
                    cm.Parameters.AddWithValue("@NguoiLap", ((FilterCriteriaSoDuDau)criteria).NguoiLap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        //while (dr.Read())
                            this.Add(BaoCaoTieuMuc.GetBaoCaoTieuMucSoTien(dr));
                    }
                }

                else if (criteria is FilterCriteriaLuyKe)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_BaoCaoTieuMucLuyKe]";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaLuyKe)criteria).tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaLuyKe)criteria).denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaLuyKe)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@MaMucNganSach", ((FilterCriteriaLuyKe)criteria).maMucNganSach);
                    cm.Parameters.AddWithValue("@MaTieuMuc", ((FilterCriteriaLuyKe)criteria).maTieuMuc);

                    cm.Parameters.AddWithValue("@TaiKhoan", ((FilterCriteriaLuyKe)criteria).maTaiKhoan);
                    cm.Parameters.AddWithValue("@NguoiLap", ((FilterCriteriaLuyKe)criteria).NguoiLap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BaoCaoTieuMuc.GetBaoCaoTieuMucSoTien(dr));
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
				foreach (BaoCaoTieuMuc deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (BaoCaoTieuMuc child in this)
				{
					if (child.IsNew)
						child.Insert(cn, this);
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
