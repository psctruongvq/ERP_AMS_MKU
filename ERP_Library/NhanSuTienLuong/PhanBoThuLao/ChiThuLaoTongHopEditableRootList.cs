
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()]
    public class ChiThuLaoTongHopList : Csla.BusinessListBase<ChiThuLaoTongHopList, ChiThuLaoTongHop>
	{
        public long MaChungTu = 0;

		#region BindingList Overrides
		protected override object AddNewCore()
		{
            ChiThuLaoTongHop item = ChiThuLaoTongHop.NewChiThuLaoTongHopChild();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChiThuLaoTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoTongHopListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChiThuLaoTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoTongHopListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChiThuLaoTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoTongHopListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChiThuLaoTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoTongHopListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChiThuLaoTongHopList()
		{ /* require use of factory method */      
        }

		public static ChiThuLaoTongHopList NewChiThuLaoTongHopList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChiThuLaoTongHopList");
			return new ChiThuLaoTongHopList();
		}

		public static ChiThuLaoTongHopList GetChiThuLaoTongHopList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
			return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteria());
		}

        public static ChiThuLaoTongHopList GetChiThuLaoListByNgayLap_TheoDoiChiThuLao(int userID, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByNgayLap_TheoDoiChiThuLao(userID, tuNgay, denNgay));
        }

        public static ChiThuLaoTongHopList GetChiThuLaoListByNgayLap_TheoDoiChiThuLao_MaLoaiChi(int userID, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi(userID, tuNgay, denNgay));
        }
        public static ChiThuLaoTongHopList GetChiThuLaoListByNgayLap_TheoDoiChiThuLao_MaLoaiChi_DVCQ(int userID, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi_DVCQ(userID, tuNgay, denNgay));
        }

        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByKetChuyen(int maChuongTrinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByKetChuyen(maChuongTrinh));
        }

        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByUser(int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByUser(userID));
        }
        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByUserAndMaChiThuLao(int userID, long maChiThuLao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByUserAndMaChiThuLao(userID, maChiThuLao));
        }

        //Add New
        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(int userID, long maChiThuLao,int maLoaiChi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi(userID, maChiThuLao,maLoaiChi));
        }

        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi(int userID, long maChiThuLao, int maLoaiChi,long maPhieuChi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi(userID, maChiThuLao, maLoaiChi,maPhieuChi));
        }

        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByUser(int userID,DateTime tuNgay,DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByUserNgay(userID, tuNgay, denNgay));
        }
        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByChungTu(long MaChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByChungTu(MaChungTu));
        }
        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByChiPhiSanXuat(long maCT_CPSX)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByChiPhiSanXuat(maCT_CPSX));
        }

        public static ChiThuLaoTongHopList GetChiThuLaoTongHopListByChiPhiSanXuatTheoThang(int Maky, DateTime TuNgay, DateTime DenNgay, int UserID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoTongHopList");
            return DataPortal.Fetch<ChiThuLaoTongHopList>(new FilterCriteriaByChiPhiSanXuatTheoThang(Maky, TuNgay, DenNgay, UserID));
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

        private class FilterCriteriaByNgayLap_TheoDoiChiThuLao
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayLap_TheoDoiChiThuLao(int userID, DateTime tuNgay, DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        private class FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi(int userID, DateTime tuNgay, DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        private class FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi_DVCQ
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi_DVCQ(int userID, DateTime tuNgay, DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        private class FilterCriteriaByChungTu
        {
            public long MaChungTu;
            public FilterCriteriaByChungTu(long _maChungTu)
            {
                MaChungTu = _maChungTu;
            }
        }


        private class FilterCriteriaByKetChuyen
        {
            public int MaChuongTrinh;
            public FilterCriteriaByKetChuyen(int maChuongTrinh)
            {
                MaChuongTrinh = maChuongTrinh;
            }
        }
        private class FilterCriteriaByChiPhiSanXuat
        {
            public long MaCT_CPSX;
            public FilterCriteriaByChiPhiSanXuat(long _maCT_CPSX)
            {
                MaCT_CPSX = _maCT_CPSX;
            }
        }

        private class FilterCriteriaByChiPhiSanXuatTheoThang
        {
            public int MaKy;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int UserID;
            public FilterCriteriaByChiPhiSanXuatTheoThang(int maKy, DateTime tuNgay, DateTime DenNgay, int userID)
            {
                this.MaKy = maKy;
                this.TuNgay = tuNgay;
                this.DenNgay=DenNgay;
                this.UserID=userID;
            }
        }
        private class FilterCriteriaByUserAndMaChiThuLao
        {
            public int UserID;
            public long MaChiThuLao;
            public FilterCriteriaByUserAndMaChiThuLao(int userID, long maChiThuLao)
            {
                this.UserID = userID;
                this.MaChiThuLao = maChiThuLao;
            }
        }

        //Add New
        private class FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi
        {
            public int UserID;
            public long MaChiThuLao;
            public int MaLoaiChi;
            public FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi(int userID, long maChiThuLao,int maLoaiChi)
            {
                this.UserID = userID;
                this.MaChiThuLao = maChiThuLao;
                this.MaLoaiChi = maLoaiChi;
            }
        }

        private class FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi
        {
            public int UserID;
            public long MaChiThuLao;
            public int MaLoaiChi;
            public long MaPhieuChi;
            public FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi(int userID, long maChiThuLao, int maLoaiChi,long maPhieuChi)
            {
                this.UserID = userID;
                this.MaChiThuLao = maChiThuLao;
                this.MaLoaiChi = maLoaiChi;
                this.MaPhieuChi=maPhieuChi;
            }
        }

        private class FilterCriteriaByUser
		{
            public int UserID;
			public FilterCriteriaByUser(int userID)
			{
                this.UserID = userID;
			}
		}
        private class FilterCriteriaByUserNgay
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByUserNgay(int userID,DateTime tuNgay,DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
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
                cm.CommandTimeout = 0;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblcnChiThuLaosAll";
                }
                else if (criteria is FilterCriteriaByUser)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByUser";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUser)criteria).UserID);
                }
                else if (criteria is FilterCriteriaByUserAndMaChiThuLao)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByUserAndMaChiThuLao";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUserAndMaChiThuLao)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaChiTHuLao", ((FilterCriteriaByUserAndMaChiThuLao)criteria).MaChiThuLao);
                }
                else if (criteria is FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByUserAndMaChiThuLao_MaLoaiChi";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaChiTHuLao", ((FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@MaLoaiChi", ((FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi)criteria).MaLoaiChi);
                }
                else if (criteria is FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaChiTHuLao", ((FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@MaLoaiChi", ((FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi)criteria).MaLoaiChi);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterCriteriaByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi)criteria).MaPhieuChi);
                }
                else if(criteria is FilterCriteriaByUserNgay &&(ERP_Library.Security.CurrentUser.IsAdmin||ERP_Library.Security.CurrentUser.IsAdminThuChi)&&Security.CurrentUser.Info.MaCongTy==1)
                {
                    cm.CommandText = "spd_SelecttblcnChiThuLaoByAdmin";                   
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByUserNgay)criteria).TuNgay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByUserNgay)criteria).DenNgay.Date);
                }
                else if (criteria is FilterCriteriaByUserNgay)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByUserNgay";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUserNgay)criteria).UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByUserNgay)criteria).TuNgay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByUserNgay)criteria).DenNgay.Date);
                }
                else if (criteria is FilterCriteriaByChungTu)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTu)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteriaByKetChuyen)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByKetChuyen";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByKetChuyen)criteria).MaChuongTrinh);
     
                 }
                else if (criteria is FilterCriteriaByNgayLap_TheoDoiChiThuLao)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByNgayLap_TheoDoiChiThuLao";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao)criteria).UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao)criteria).TuNgay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao)criteria).DenNgay.Date);
                }
                else if (criteria is FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByNgayLap_TheoDoiChiThuLao_MaLoaiChi";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi)criteria).UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi)criteria).TuNgay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi)criteria).DenNgay.Date);
                }
                else if (criteria is FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi_DVCQ)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByNgayLap_TheoDoiChiThuLao_MaLoaiChi_DVCQ";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi_DVCQ)criteria).UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi_DVCQ)criteria).TuNgay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap_TheoDoiChiThuLao_MaloaiChi_DVCQ)criteria).DenNgay.Date);
                }
                else if (criteria is FilterCriteriaByChiPhiSanXuat)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByChiPhiSanXuat";
                    cm.Parameters.AddWithValue("@MaCT_CPSX", ((FilterCriteriaByChiPhiSanXuat)criteria).MaCT_CPSX);
                }

                else if (criteria is FilterCriteriaByChiPhiSanXuat)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByChiPhiSanXuat";
                    cm.Parameters.AddWithValue("@MaCT_CPSX", ((FilterCriteriaByChiPhiSanXuat)criteria).MaCT_CPSX);
                }
               
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChiThuLaoTongHop.GetChiThuLaoTongHop(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch

		#endregion //Data Access
	}
}
