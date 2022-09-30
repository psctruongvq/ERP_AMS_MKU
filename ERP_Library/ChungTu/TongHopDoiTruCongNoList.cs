
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TongHopDoiTruCongNoList : Csla.BusinessListBase<TongHopDoiTruCongNoList, TongHopDoiTruCongNo>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TongHopDoiTruCongNo item = TongHopDoiTruCongNo.NewTongHopDoiTruCongNo();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TongHopDoiTruCongNoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopDoiTruCongNoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TongHopDoiTruCongNoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopDoiTruCongNoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TongHopDoiTruCongNoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopDoiTruCongNoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TongHopDoiTruCongNoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopDoiTruCongNoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TongHopDoiTruCongNoList()
		{ /* require use of factory method */ }

		public static TongHopDoiTruCongNoList NewTongHopDoiTruCongNoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TongHopDoiTruCongNoList");
			return new TongHopDoiTruCongNoList();
		}

		public static TongHopDoiTruCongNoList GetTongHopDoiTruCongNoListByNgay(DateTime tuNgay,DateTime denNgay,int loai)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TongHopDoiTruCongNoList");
            return DataPortal.Fetch<TongHopDoiTruCongNoList>(new FilterCriteriaByNgay(tuNgay, denNgay, loai));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteriaByNgay
		{
            public DateTime _tuNgay,_denNgay;
            public int _loai;
            public FilterCriteriaByNgay(DateTime tuNgay, DateTime denNgay,int loai)
            {
                this._tuNgay = tuNgay;
                this._denNgay = denNgay;
                this._loai = loai;
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
                if (criteria is FilterCriteriaByNgay)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetDoiTruCongNo";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgay)criteria)._tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgay)criteria)._denNgay);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByNgay)criteria)._loai);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TongHopDoiTruCongNo.GetTongHopDoiTruCongNo(dr));
                }
            }
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
                    foreach (TongHopDoiTruCongNo deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (TongHopDoiTruCongNo child in this)
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
