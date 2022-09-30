
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TMBCTC_CongThucVCSHList : Csla.BusinessListBase<TMBCTC_CongThucVCSHList, TMBCTC_CongThucVCSH>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TMBCTC_CongThucVCSH item = TMBCTC_CongThucVCSH.NewTMBCTC_CongThucVCSH();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TMBCTC_CongThucVCSHList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TMBCTC_CongThucVCSHListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TMBCTC_CongThucVCSHList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TMBCTC_CongThucVCSHListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TMBCTC_CongThucVCSHList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TMBCTC_CongThucVCSHListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TMBCTC_CongThucVCSHList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TMBCTC_CongThucVCSHListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TMBCTC_CongThucVCSHList()
		{ /* require use of factory method */ }

		public static TMBCTC_CongThucVCSHList NewTMBCTC_CongThucVCSHList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TMBCTC_CongThucVCSHList");
			return new TMBCTC_CongThucVCSHList();
		}

		public static TMBCTC_CongThucVCSHList GetTMBCTC_CongThucVCSHList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TMBCTC_CongThucVCSHList");
			return DataPortal.Fetch<TMBCTC_CongThucVCSHList>(new FilterCriteria());
		}

        public static TMBCTC_CongThucVCSHList GetTMBCTC_CongThucVCSHListbyMaThongTu(int maThongTu,byte isNHNN)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TMBCTC_CongThucVCSHList");
            return DataPortal.Fetch<TMBCTC_CongThucVCSHList>(new FilterCriteriabyMaThongTu(maThongTu,isNHNN));
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

        [Serializable()]
        private class FilterCriteriabyMaThongTu
        {
            public int MaThongTu = 0;
            public byte IsNHNN = 0;
            public FilterCriteriabyMaThongTu(int maThongTu, byte isNHNN)
            {
                MaThongTu =maThongTu;
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
                    cm.CommandText = "usp_SelecttblTMBCTC_CongThucVCSHesAll";
                }
                else if (criteria is FilterCriteriabyMaThongTu)
                {
                    cm.CommandText = "usp_SelecttblTMBCTC_CongThucVCSHesbyMaThongTu";
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriabyMaThongTu)criteria).MaThongTu);
                    cm.Parameters.AddWithValue("@isNHNN", ((FilterCriteriabyMaThongTu)criteria).IsNHNN);
                }


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TMBCTC_CongThucVCSH.GetTMBCTC_CongThucVCSH(dr));
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
					foreach (TMBCTC_CongThucVCSH deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TMBCTC_CongThucVCSH child in this)
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
