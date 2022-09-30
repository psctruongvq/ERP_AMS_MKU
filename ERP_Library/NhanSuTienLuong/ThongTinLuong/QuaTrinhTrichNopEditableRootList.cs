
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhTrichNopList : Csla.BusinessListBase<QuaTrinhTrichNopList, QuaTrinhTrichNop>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuaTrinhTrichNop item = QuaTrinhTrichNop.NewQuaTrinhTrichNop();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhTrichNopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhTrichNopListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhTrichNopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhTrichNopListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhTrichNopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhTrichNopListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhTrichNopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhTrichNopListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhTrichNopList()
		{ /* require use of factory method */ }

		public static QuaTrinhTrichNopList NewQuaTrinhTrichNopList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhTrichNopList");
			return new QuaTrinhTrichNopList();
		}

		public static QuaTrinhTrichNopList GetQuaTrinhTrichNopList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhTrichNopList");
            return DataPortal.Fetch<QuaTrinhTrichNopList>(new FilterCriteria(maNhanVien));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public long MaNhanVien;

			public FilterCriteria(long maNhanVien)
			{
                this.MaNhanVien = maNhanVien;
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhTrichNopsAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuaTrinhTrichNop.GetQuaTrinhTrichNop(dr));
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
				foreach (QuaTrinhTrichNop deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (QuaTrinhTrichNop child in this)
				{
					if (child.IsNew)
						child.Insert(cn, this);
					else
						child.Update(cn, this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
