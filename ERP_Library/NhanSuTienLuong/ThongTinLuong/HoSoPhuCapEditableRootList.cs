
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoSoPhuCapList : Csla.BusinessListBase<HoSoPhuCapList, HoSoPhuCap>
	{
		#region BindingList   Overrides
		protected override object AddNewCore()
		{
			HoSoPhuCap item = HoSoPhuCap.NewHoSoPhuCap();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HoSoPhuCapList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoPhuCapListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HoSoPhuCapList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoPhuCapListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HoSoPhuCapList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoPhuCapListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HoSoPhuCapList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoPhuCapListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HoSoPhuCapList()
		{ /* require use of factory method */ }

		public static HoSoPhuCapList NewHoSoPhuCapList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HoSoPhuCapList");
			return new HoSoPhuCapList();
		}

		public static HoSoPhuCapList GetHoSoPhuCapList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HoSoPhuCapList");
			return DataPortal.Fetch<HoSoPhuCapList>(new FilterCriteria(maNhanVien));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public long MaNhanVien;
            //public int MaLoaiPhuCap;

			public FilterCriteria(long maNhanVien)
			{
                this.MaNhanVien = maNhanVien;
                //this.MaLoaiPhuCap = maLoaiPhuCap;
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
                cm.CommandText = "spd_SelecttblnsHoSoPhuCapsAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                //cm.Parameters.AddWithValue("@MaLoaiPhuCap", criteria.MaLoaiPhuCap);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(HoSoPhuCap.GetHoSoPhuCap(dr));
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
				foreach (HoSoPhuCap deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (HoSoPhuCap child in this)
				{
					if (child.IsNew)
						child.Insert(cn, this);
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
