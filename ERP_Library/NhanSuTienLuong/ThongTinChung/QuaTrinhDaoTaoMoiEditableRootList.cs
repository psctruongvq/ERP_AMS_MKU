
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhDaoTaoMoiList : Csla.BusinessListBase<QuaTrinhDaoTaoMoiList, QuaTrinhDaoTaoMoi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuaTrinhDaoTaoMoi item = QuaTrinhDaoTaoMoi.NewQuaTrinhDaoTaoMoi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhDaoTaoMoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhDaoTaoMoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhDaoTaoMoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhDaoTaoMoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhDaoTaoMoiList()
		{ /* require use of factory method */ }

		public static QuaTrinhDaoTaoMoiList NewQuaTrinhDaoTaoMoiList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhDaoTaoMoiList");
			return new QuaTrinhDaoTaoMoiList();
		}

		public static QuaTrinhDaoTaoMoiList GetQuaTrinhDaoTaoMoiList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhDaoTaoMoiList");
			return DataPortal.Fetch<QuaTrinhDaoTaoMoiList>(new FilterCriteria(maNhanVien));
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
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsQuaTrinhDaoTaosAll";
				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuaTrinhDaoTaoMoi.GetQuaTrinhDaoTaoMoi(dr));
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
                try
                {
                    // loop through each deleted child object
                    foreach (QuaTrinhDaoTaoMoi deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (QuaTrinhDaoTaoMoi child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn);
                        else
                            child.Update(cn);
                    }
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
