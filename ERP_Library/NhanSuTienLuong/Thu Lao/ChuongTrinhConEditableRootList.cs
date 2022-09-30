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
	public class ChuongTrinhConList : Csla.BusinessListBase<ChuongTrinhConList, ChuongTrinhCon>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChuongTrinhCon item = ChuongTrinhCon.NewChuongTrinh();
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
		private ChuongTrinhConList()
		{ /* require use of factory method */ }

		public static ChuongTrinhConList NewChuongTrinhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChuongTrinhList");
			return new ChuongTrinhConList();
		}
        public static ChuongTrinhConList GetChuongTrinhList(bool Kieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhConList");
            return DataPortal.Fetch<ChuongTrinhConList>(new FilterCriteriaByHoanTat(Kieu));
        }
        public static ChuongTrinhConList GetChuongTrinhList(int Kieu,int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhConList");
            return DataPortal.Fetch<ChuongTrinhConList>(new FilterCriteriaUser(Kieu,userID));
        }
		public static ChuongTrinhConList GetChuongTrinhList(int Kieu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhConList");
			return DataPortal.Fetch<ChuongTrinhConList>(new FilterCriteria(Kieu));
		}
        public static ChuongTrinhConList GetChuongTrinhListByCon(int MaChuongTrinhCha)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhConList");
            return DataPortal.Fetch<ChuongTrinhConList>(new FilterCriteriaByCon(MaChuongTrinhCha));
        }
        public static ChuongTrinhConList GetChuongTrinhListByNguon(int nguon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhConList");
            return DataPortal.Fetch<ChuongTrinhConList>(new FilterCriteriaByNguon(nguon));
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
        private class FilterCriteriaByCon
		{
            public int MaChuongTrinhCha;
            public FilterCriteriaByCon(int maChuongTrinhCha)
			{
                this.MaChuongTrinhCha = maChuongTrinhCha;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhesAll";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteria)criteria).Kieu);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }
                if (criteria is FilterCriteriaUser)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhUser";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaUser)criteria).Kieu);
                    cm.Parameters.AddWithValue("@User", ((FilterCriteriaUser)criteria).UserID);
                }
                if (criteria is FilterCriteriaByCon)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhByCon";
                    cm.Parameters.AddWithValue("@MaChuongTrinhCha", ((FilterCriteriaByCon)criteria).MaChuongTrinhCha);
                   
                }
                else if (criteria is FilterCriteriaByHoanTat)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinheByChuaHoanTat";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChuongTrinhCon.GetChuongTrinh(dr));
                }
            }//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		
        internal void Update(SqlTransaction tr, ChuongTrinh parent)
        {
            RaiseListChangedEvents = false;




            //tr = cn.BeginTransaction();
            try
            {
                // loop through each deleted child object
                foreach (ChuongTrinhCon deletedChild in DeletedList)
                {



                    deletedChild.DeleteSelf(tr);
                }
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChuongTrinhCon child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }

                //tr.Commit();
            }
            catch
            {
                // tr.Rollback();
                throw;
            }

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
