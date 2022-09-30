//1
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ERP_Library;
using ERP_Library.Security;
using System.Collections;


namespace ERP_Library
{ 
	[Serializable()] 
	public class ChuongTrinhList : Csla.BusinessListBase<ChuongTrinhList, ChuongTrinh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChuongTrinh item = ChuongTrinh.NewChuongTrinh();
            if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 22)
                item.MaQL = "TFSDV22" + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString();
            else if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 26)
                item.MaQL = "HTVCDV26";

			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChuongTrinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChuongTrinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChuongTrinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChuongTrinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChuongTrinhList()
		{ /* require use of factory method */ }

		public static ChuongTrinhList NewChuongTrinhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChuongTrinhList");
			return new ChuongTrinhList();
		}
        public static ChuongTrinhList GetChuongTrinhList(bool Kieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhList");
            return DataPortal.Fetch<ChuongTrinhList>(new FilterCriteriaByHoanTat(Kieu));
        }
        /// <summary>
        /// Lấy tất cả chương trình theo công ty đăng nhập
        /// </summary>
        /// <returns></returns>
        public static ChuongTrinhList GetChuongTrinhList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhList");
            return DataPortal.Fetch<ChuongTrinhList>(new FilterCriteriaAll());
        }
        public static ChuongTrinhList GetChuongTrinhList(int Kieu,int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhList");
            return DataPortal.Fetch<ChuongTrinhList>(new FilterCriteriaUser(Kieu,userID));
        }
		public static ChuongTrinhList GetChuongTrinhList(int Kieu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhList");
			return DataPortal.Fetch<ChuongTrinhList>(new FilterCriteria(Kieu));
		}
        public static ChuongTrinhList GetChuongTrinhListByNguon(int nguon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhList");
            return DataPortal.Fetch<ChuongTrinhList>(new FilterCriteriaByNguon(nguon));
        }
        public static ChuongTrinhList GetChuongTrinhList_ChaNull(int hoanTat,int maCongTy,int maChuongTrinhSearch)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhList");
            return DataPortal.Fetch<ChuongTrinhList>(new FilterCriteriaByMaChaNull(hoanTat,maCongTy,maChuongTrinhSearch));
        }
        public static ChuongTrinhList ChuongTrinhList_Con(int hoanTat, int maCongTy,int maChuongTrinhCha)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhList");
            return DataPortal.Fetch<ChuongTrinhList>(new FilterCriteriaByMaChuongTrinhCha(hoanTat, maCongTy, maChuongTrinhCha));
        }
      
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int Kieu;
			public FilterCriteria(int kieu)
			{
                this.Kieu = kieu;
			}
		}
        private class FilterCriteriaAll
		{            
            public FilterCriteriaAll()
			{
                
			}
		}
        private class FilterCriteriaByHoanTat
        {
            public bool Kieu;
            public FilterCriteriaByHoanTat(bool kieu)
            {
                this.Kieu = kieu;
            }
        }
        private class FilterCriteriaUser
        {
            public int Kieu;
            public int UserID;
            public FilterCriteriaUser(int kieu, int userID)
            {
                this.Kieu = kieu;
                this.UserID = userID;
            }
        }
        
        private class FilterCriteriaByNguon
        {
           
            public int Nguon;
            public FilterCriteriaByNguon(int nguon)
            {
               
                this.Nguon = nguon;
            }
        }
        private class FilterCriteriaByMaChaNull
        {
            public int HoanTat;
            public int MaCongTy;
            public int MaChuongTrinhSearch;
            public FilterCriteriaByMaChaNull(int hoanTat,int maCongTy,int maChuongTrinhSearch)
            {
                this.HoanTat = hoanTat;
                this.MaCongTy = maCongTy;
                this.MaChuongTrinhSearch = maChuongTrinhSearch;
            }
        }
        private class FilterCriteriaByMaChuongTrinhCha
        {
            public int HoanTat;
            public int MaCongTy;
            public int MaChuongTrinhCha;
            public FilterCriteriaByMaChuongTrinhCha(int hoanTat, int maCongTy,int maChuongTrinhCha)
            {
                this.HoanTat = hoanTat;
                this.MaCongTy = maCongTy;
                this.MaChuongTrinhCha = maChuongTrinhCha;
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
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 1800;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhesAll";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteria)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }
                else if (criteria is FilterCriteriaByMaChaNull)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhByMaChaNull";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaByMaChaNull)criteria).HoanTat);
                    cm.Parameters.AddWithValue("@MaChuongTrinhSearch", ((FilterCriteriaByMaChaNull)criteria).MaChuongTrinhSearch);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }
                else if (criteria is FilterCriteriaByMaChuongTrinhCha)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhByMaCha";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaByMaChuongTrinhCha)criteria).HoanTat);
                    cm.Parameters.AddWithValue("@MaChuongTrinhCha", ((FilterCriteriaByMaChuongTrinhCha)criteria).MaChuongTrinhCha);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }
                else if (criteria is FilterCriteriaUser)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhUser";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaUser)criteria).Kieu);
                    cm.Parameters.AddWithValue("@User", ((FilterCriteriaUser)criteria).UserID);
                }
                else if (criteria is FilterCriteriaByNguon)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhByMaNguon";
                    cm.Parameters.AddWithValue("@MaNguon", ((FilterCriteriaByNguon)criteria).Nguon);

                }
                else if (criteria is FilterCriteriaByHoanTat)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinheByChuaHoanTat";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhByAll";
                    cm.Parameters.AddWithValue("@MaCongTy",ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChuongTrinh.GetChuongTrinh(dr));
                }
                
            }//using
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
					foreach (ChuongTrinh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ChuongTrinh child in this)
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
