
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_MucTMBCTaiChinhList : Csla.BusinessListBase<CT_MucTMBCTaiChinhList, CT_MucTMBCTaiChinh>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CT_MucTMBCTaiChinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_MucTMBCTaiChinhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CT_MucTMBCTaiChinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_MucTMBCTaiChinhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CT_MucTMBCTaiChinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_MucTMBCTaiChinhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CT_MucTMBCTaiChinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_MucTMBCTaiChinhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CT_MucTMBCTaiChinhList()
		{ /* require use of factory method */ }

		public static CT_MucTMBCTaiChinhList NewCT_MucTMBCTaiChinhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CT_MucTMBCTaiChinhList");
			return new CT_MucTMBCTaiChinhList();
		}

		public static CT_MucTMBCTaiChinhList GetCT_MucTMBCTaiChinhList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CT_MucTMBCTaiChinhList");
			return DataPortal.Fetch<CT_MucTMBCTaiChinhList>(new FilterCriteria());
		}

        public static CT_MucTMBCTaiChinhList GetCT_MucTMBCTaiChinhListbyMaThongTu(int maThongTu,byte isNHNN)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CT_MucTMBCTaiChinhList");
            return DataPortal.Fetch<CT_MucTMBCTaiChinhList>(new FilterCriteriabyMaThongTu(maThongTu,isNHNN));
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

        private class FilterCriteriabyMaThongTu
        {
            public int MaThongTu = 0;
            public byte IsNHNN = 0;
            public FilterCriteriabyMaThongTu(int maThongTu,byte isNHNN)
            {
                MaThongTu = maThongTu;
                IsNHNN = isNHNN;
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
                if(criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblCT_MucTMBCTaiChinhesAll";
                }
                else if(criteria is FilterCriteriabyMaThongTu)
                {
                    cm.CommandText = "spd_SelecttblCT_MucTMBCTaiChinhesbyMaThongTu";
                    cm.Parameters.AddWithValue("@MaThongTu",((FilterCriteriabyMaThongTu)criteria).MaThongTu);
                    cm.Parameters.AddWithValue("@isNHNN",((FilterCriteriabyMaThongTu)criteria).IsNHNN);
                }
               


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(CT_MucTMBCTaiChinh.GetCT_MucTMBCTaiChinh(dr));
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
					foreach (CT_MucTMBCTaiChinh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (CT_MucTMBCTaiChinh child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
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
