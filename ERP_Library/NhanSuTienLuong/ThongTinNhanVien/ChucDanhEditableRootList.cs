
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChucDanhList : Csla.BusinessListBase<ChucDanhList, ChucDanh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChucDanh item = ChucDanh.NewChucDanh();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChucDanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucDanhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChucDanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucDanhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChucDanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucDanhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChucDanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucDanhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChucDanhList()
		{ /* require use of factory method */ }

		public static ChucDanhList NewChucDanhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChucDanhList");
			return new ChucDanhList();
		}

		public static ChucDanhList GetChucDanhList()//int maNhomChucDanh, int maChucVu, int maNgachLuongKinhDoanh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChucDanhList");
            return DataPortal.Fetch<ChucDanhList>(new FilterCriteria());//maNhomChucDanh, maChucVu, maNgachLuongKinhDoanh));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            //public int MaNhomChucDanh;
            //public int MaChucVu;
            //public int MaNgachLuongKinhDoanh;

			public FilterCriteria()//int maNhomChucDanh, int maChucVu, int maNgachLuongKinhDoanh)
			{
                //this.MaNhomChucDanh = maNhomChucDanh;
                //this.MaChucVu = maChucVu;
                //this.MaNgachLuongKinhDoanh = maNgachLuongKinhDoanh;
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
                cm.CommandText = "spd_SelecttblnsChucDanhesAll";
                //cm.Parameters.AddWithValue("@MaNhomChucDanh", criteria.MaNhomChucDanh);
                //cm.Parameters.AddWithValue("@MaChucVu", criteria.MaChucVu);
                //cm.Parameters.AddWithValue("@MaNgachLuongKinhDoanh", criteria.MaNgachLuongKinhDoanh);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChucDanh.GetChucDanh(dr));
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
                    foreach (ChucDanh deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChucDanh child in this)
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
