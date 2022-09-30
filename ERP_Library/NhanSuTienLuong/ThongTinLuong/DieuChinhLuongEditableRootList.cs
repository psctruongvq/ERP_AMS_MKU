
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DieuChinhLuongList : Csla.BusinessListBase<DieuChinhLuongList, DieuChinhLuong>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DieuChinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChinhLuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DieuChinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChinhLuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DieuChinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChinhLuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DieuChinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChinhLuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DieuChinhLuongList()
		{ /* require use of factory method */ }

		public static DieuChinhLuongList NewDieuChinhLuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DieuChinhLuongList");
			return new DieuChinhLuongList();
		}

		public static DieuChinhLuongList GetDieuChinhLuongList(int mabophan, int maky)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DieuChinhLuongList");
			return DataPortal.Fetch<DieuChinhLuongList>(new FilterCriteria(mabophan,maky));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
           
            public int maky;
            public int mabophan;

			public FilterCriteria(int mabophan, int maky)
			{
                this.mabophan = mabophan;
                this.maky = maky;
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
                cm.CommandText = "spd_SelecttblnsDieuChinhLuongBy_Lyluong";
                cm.Parameters.AddWithValue("@mabophan", ((FilterCriteria)criteria).mabophan);
                cm.Parameters.AddWithValue("@maky", ((FilterCriteria)criteria).maky);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(DieuChinhLuong.GetDieuChinhLuong(dr));
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
					foreach (DieuChinhLuong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (DieuChinhLuong child in this)
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

