
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangKeList : Csla.BusinessListBase<BangKeList, BangKe>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangKeList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangKeListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangKeList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangKeListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangKeList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangKeListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangKeList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangKeListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangKeList()
		{ /* require use of factory method */ }

		public static BangKeList NewBangKeList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangKeList");
			return new BangKeList();
		}

		public static BangKeList GetBangKeList(long maChungTu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangKeList");
			return DataPortal.Fetch<BangKeList>(new FilterCriteria(maChungTu));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
           public long MaChungTu;
			public FilterCriteria( long maChungTu)
			{
                this.MaChungTu = maChungTu;
			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_BaoCaoChungTuGhiSo]";
                cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria)criteria).MaChungTu);


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BangKe.GetBangKe(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				// loop through each deleted child object
				foreach (BangKe deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (BangKe child in this)
				{
					if (child.IsNew)
						child.Insert(cn,this);
					else
						child.Update(cn,this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
