
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TSCDCaBietTimKiemList : Csla.BusinessListBase<TSCDCaBietTimKiemList,TSCDCaBiet>// TSCDCaBietTimKiem>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TSCDCaBietTimKiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TSCDCaBietTimKiemListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TSCDCaBietTimKiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TSCDCaBietTimKiemListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TSCDCaBietTimKiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TSCDCaBietTimKiemListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TSCDCaBietTimKiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TSCDCaBietTimKiemListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TSCDCaBietTimKiemList()
		{ /* require use of factory method */ }

		public static TSCDCaBietTimKiemList NewTSCDCaBietTimKiemList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TSCDCaBietTimKiemList");
			return new TSCDCaBietTimKiemList();
		}

		public static TSCDCaBietTimKiemList GetTSCDCaBietTimKiemList(string chuoiTK)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TSCDCaBietTimKiemList");
            return DataPortal.Fetch<TSCDCaBietTimKiemList>(new FilterCriteria(chuoiTK));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public string _chuoiTK;
			public FilterCriteria(string chuoiTK)
			{
                _chuoiTK = chuoiTK;
			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
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

		private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_TimTaiSanCoDinhCaBiet_ChuoiTimKiem_Test";
                cm.Parameters.AddWithValue("@ChuoiTimKiem", criteria._chuoiTK);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                        this.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                        //this.Add(TSCDCaBietTimKiem.GetTSCDCaBietTimKiem(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


        //#region Data Access - Update
        //protected override void DataPortal_Update()
        //{
        //    RaiseListChangedEvents = false;

        //    SqlTransaction tr;

        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();

        //        tr = cn.BeginTransaction();
        //        try
        //        {
        //            // loop through each deleted child object
        //            foreach (TSCDCaBietTimKiem deletedChild in DeletedList)
        //                deletedChild.DeleteSelf(tr);
        //            DeletedList.Clear();

        //            // loop through each non-deleted child object
        //            foreach (TSCDCaBietTimKiem child in this)
        //            {
        //                if (child.IsNew)
        //                    child.Insert(tr);
        //                else
        //                    child.Update(tr);
        //            }

        //            tr.Commit();
        //        }
        //        catch
        //        {
        //            tr.Rollback();
        //            throw;
        //        }
        //    }//using SqlConnection

        //    RaiseListChangedEvents = true;
        //}
        //#endregion //Data Access - Update
		#endregion //Data Access
	}
}
