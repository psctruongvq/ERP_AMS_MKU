
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiThuLaoList : Csla.BusinessListBase<ChiThuLaoList, ChiThuLao>
	{
        public long MaChungTu = 0;

		#region BindingList Overrides
		protected override object AddNewCore()
		{
            ChiThuLao item = ChiThuLao.NewChiThuLaoChild();
            //ChiThuLao item = ChiThuLao.NewChiThuLao();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChiThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChiThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChiThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChiThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiThuLaoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChiThuLaoList()
		{ /* require use of factory method */      
        }

		public static ChiThuLaoList NewChiThuLaoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChiThuLaoList");
			return new ChiThuLaoList();
		}

		public static ChiThuLaoList GetChiThuLaoList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
			return DataPortal.Fetch<ChiThuLaoList>(new FilterCriteria());
		}

        public static ChiThuLaoList GetChiThuLaoListByKetChuyen(int maChuongTrinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoList>(new FilterCriteriaByKetChuyen(maChuongTrinh));
        }

        public static ChiThuLaoList GetChiThuLaoListByKetChuyen_New(long maCTChiPhiSanXuat)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoList>(new FilterCriteriaByKetChuyen_New(maCTChiPhiSanXuat));
        }

        public static ChiThuLaoList GetChiThuLaoListByUser(int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoList>(new FilterCriteriaByUser(userID));
        }
        public static ChiThuLaoList GetChiThuLaoListByUser(int userID,DateTime tuNgay,DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoList>(new FilterCriteriaByUserNgay(userID, tuNgay, denNgay));
        }

        public static ChiThuLaoList GetChiThuLaoListByChungTu(long MaChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoList>(new FilterCriteriaByChungTu(MaChungTu));
        }
        public static ChiThuLaoList GetChiThuLaoListByChiPhiSanXuat(long maCT_CPSX)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoList>(new FilterCriteriaByChiPhiSanXuat(maCT_CPSX));
        }

        public static ChiThuLaoList GetChiThuLaoListByChiPhiSanXuatTheoThang(int Maky, DateTime TuNgay, DateTime DenNgay, int UserID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiThuLaoList");
            return DataPortal.Fetch<ChiThuLaoList>(new FilterCriteriaByChiPhiSanXuatTheoThang(Maky, TuNgay, DenNgay, UserID));
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

        private class FilterCriteriaByKetChuyen_New
        {
            public long MaCTChiPhiSanXuat;
            public FilterCriteriaByKetChuyen_New(long maCTChiPhiSanXuat)
            {
                MaCTChiPhiSanXuat = maCTChiPhiSanXuat;
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
                else if (criteria is FilterCriteriaByKetChuyen_New)
                {

                    cm.CommandText = "spd_SelecttblcnChiThuLaoByKetChuyen_New";
                    cm.Parameters.AddWithValue("@MaCTChiPhiSanXuat", ((FilterCriteriaByKetChuyen_New)criteria).MaCTChiPhiSanXuat);

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
                else if (criteria is FilterCriteriaByChiPhiSanXuatTheoThang)
                {

                    cm.CommandText = "[spd_DanhSachChiPhiSanXuatTheoThang]";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteriaByChiPhiSanXuatTheoThang)criteria).MaKy);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByChiPhiSanXuatTheoThang)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByChiPhiSanXuatTheoThang)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByChiPhiSanXuatTheoThang)criteria).UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiThuLao.GetChiThuLaoByChiPhiSanXuat(dr));
                    }
                    return;
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChiThuLao.GetChiThuLao(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update

        public void DataPortal_Update(SqlTransaction tr, long MaChungTu, string soChungTu, long maCT_ChiPhiSanXuat, int maChuongTrinh, string tenChuongTrinh)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ChiThuLao deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChiThuLao child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, MaChungTu, soChungTu, maCT_ChiPhiSanXuat, maChuongTrinh, tenChuongTrinh);
                    else
                        child.Update(tr, MaChungTu, soChungTu, maCT_ChiPhiSanXuat, maChuongTrinh, tenChuongTrinh);
                }
            }

            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }


            RaiseListChangedEvents = true;
        }
        public void DataPortal_Delete(SqlTransaction tr, long MaChungTu)
        {
            
            // loop through each deleted child object
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblcnChiThuLaoByChungTu";

                cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);

                cm.ExecuteNonQuery();
            }//using
        }
        public void DataPortal_Delete(SqlTransaction tr)
        {

            // loop through each deleted child object
            foreach (ChiThuLao child in this)
            {
                child.Dataportal_Delete(tr);
            }
            
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
