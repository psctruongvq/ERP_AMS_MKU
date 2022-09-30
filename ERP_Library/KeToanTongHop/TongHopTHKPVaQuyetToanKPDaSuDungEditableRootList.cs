
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TongHopTHKPVaQuyetToanKPDaSuDungList : Csla.BusinessListBase<TongHopTHKPVaQuyetToanKPDaSuDungList, TongHopTHKPVaQuyetToanKPDaSuDung>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TongHopTHKPVaQuyetToanKPDaSuDungList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopTHKPVaQuyetToanKPDaSuDungListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TongHopTHKPVaQuyetToanKPDaSuDungList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopTHKPVaQuyetToanKPDaSuDungListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TongHopTHKPVaQuyetToanKPDaSuDungList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopTHKPVaQuyetToanKPDaSuDungListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TongHopTHKPVaQuyetToanKPDaSuDungList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopTHKPVaQuyetToanKPDaSuDungListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TongHopTHKPVaQuyetToanKPDaSuDungList()
		{ /* require use of factory method */ }

		public static TongHopTHKPVaQuyetToanKPDaSuDungList NewTongHopTHKPVaQuyetToanKPDaSuDungList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TongHopTHKPVaQuyetToanKPDaSuDungList");
			return new TongHopTHKPVaQuyetToanKPDaSuDungList();
		}

		public static TongHopTHKPVaQuyetToanKPDaSuDungList GetTongHopTHKPVaQuyetToanKPDaSuDungList(int maKy, int quy, int nam, DateTime tuNgay, DateTime denNgay, int loai )
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TongHopTHKPVaQuyetToanKPDaSuDungList");
			return DataPortal.Fetch<TongHopTHKPVaQuyetToanKPDaSuDungList>(new FilterCriteria(maKy, quy, nam, tuNgay, denNgay, loai));
		}


		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int MaKy;
            public int Quy;
            public int Nam;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int Loai;

			public FilterCriteria( int maKy, int quy, int nam, DateTime tuNgay, DateTime denNgay, int loai)
			{
                Loai = loai;
                MaKy = maKy;
                Quy = quy;
                Nam = nam;
                TuNgay = tuNgay;
                DenNgay = denNgay;
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
                cm.CommandText = "spd_TongHopTHKPVaQuyetToanKPDaSuDung";
                cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);
                cm.Parameters.AddWithValue("@Quy", criteria.Quy);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);
                cm.Parameters.AddWithValue("@Loai", criteria.Loai);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TongHopTHKPVaQuyetToanKPDaSuDung.GetTongHopTHKPVaQuyetToanKPDaSuDung(dr));
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
					foreach (TongHopTHKPVaQuyetToanKPDaSuDung deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TongHopTHKPVaQuyetToanKPDaSuDung child in this)
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
