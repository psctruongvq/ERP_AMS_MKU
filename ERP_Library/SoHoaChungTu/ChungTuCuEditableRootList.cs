using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTuCuList : Csla.BusinessListBase<ChungTuCuList, ChungTuCu>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChungTuCuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTuCuListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChungTuCuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTuCuListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChungTuCuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTuCuListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChungTuCuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTuCuListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChungTuCuList()
		{ /* require use of factory method */ }

		public static ChungTuCuList NewChungTuCuList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTuCuList");
			return new ChungTuCuList();
		}

		public static ChungTuCuList GetChungTuCuListByNgayLap(DateTime tuNgay,DateTime denNgay)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChungTuCuList");
            return DataPortal.Fetch<ChungTuCuList>(new FilterCriteriaCuByNgayLap(tuNgay, denNgay));
		}
        public static ChungTuCuList GetChungTuMoiListByNgayLap(DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuCuList");
            return DataPortal.Fetch<ChungTuCuList>(new FilterCriteriaMoiByNgayLap(tuNgay, denNgay));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        private class FilterCriteriaCuByNgayLap
		{
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaCuByNgayLap(DateTime tuNgay, DateTime denNgay)
			{
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
     		}
		}
        private class FilterCriteriaMoiByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaMoiByNgayLap(DateTime tuNgay, DateTime denNgay)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
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

                if (criteria is FilterCriteriaCuByNgayLap)
                {
                    cm.CommandText = "spd_SelecttblChungTuCusAllByNgayLap";
                    cm.Parameters.Add("@TuNgay",((FilterCriteriaCuByNgayLap)criteria).TuNgay);
                    cm.Parameters.Add("@DenNgay", ((FilterCriteriaCuByNgayLap)criteria).DenNgay);
                }
                if (criteria is FilterCriteriaMoiByNgayLap)
                {
                    cm.CommandText = "spd_SelecttblChungTuMoisAllByNgayLap";
                    cm.Parameters.Add("@TuNgay", ((FilterCriteriaMoiByNgayLap)criteria).TuNgay);
                    cm.Parameters.Add("@DenNgay", ((FilterCriteriaMoiByNgayLap)criteria).DenNgay);
                }


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChungTuCu.GetChungTuCu(dr));
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
					foreach (ChungTuCu deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ChungTuCu child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
                            child.Update(tr, this);
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
