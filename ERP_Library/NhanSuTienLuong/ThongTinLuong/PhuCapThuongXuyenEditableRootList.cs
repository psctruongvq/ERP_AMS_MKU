
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhuCapThuongXuyenList : Csla.BusinessListBase<PhuCapThuongXuyenList, PhuCapThuongXuyen>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhuCapThuongXuyen item = PhuCapThuongXuyen.NewPhuCapThuongXuyen();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhuCapThuongXuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapThuongXuyenListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhuCapThuongXuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapThuongXuyenListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhuCapThuongXuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapThuongXuyenListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhuCapThuongXuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapThuongXuyenListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhuCapThuongXuyenList()
		{ /* require use of factory method */ }

		public static PhuCapThuongXuyenList NewPhuCapThuongXuyenList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuCapThuongXuyenList");
			return new PhuCapThuongXuyenList();
		}

		public static PhuCapThuongXuyenList GetPhuCapThuongXuyenList(long MaNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhuCapThuongXuyenList");
			return DataPortal.Fetch<PhuCapThuongXuyenList>(new FilterCriteria(MaNhanVien));
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
                cm.CommandText = "spd_SelecttblnsPhuCapThuongXuyensAll";
				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				//cm.Parameters.AddWithValue("@MaLoaiPhuCapTX", criteria.MaLoaiPhuCapTX);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(PhuCapThuongXuyen.GetPhuCapThuongXuyen(dr));
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
                    foreach (PhuCapThuongXuyen deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhuCapThuongXuyen child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn, this);
                        else
                            child.Update(cn, this);
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
