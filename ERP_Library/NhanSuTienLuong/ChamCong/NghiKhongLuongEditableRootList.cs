
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NghiKhongLuongList : Csla.BusinessListBase<NghiKhongLuongList, NghiKhongLuong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NghiKhongLuong item = NghiKhongLuong.NewNghiKhongLuong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private NghiKhongLuongList()
		{ /* require use of factory method */ }

		public static NghiKhongLuongList NewNghiKhongLuongList()
		{
			return new NghiKhongLuongList();
		}

		public static NghiKhongLuongList GetNghiKhongLuongList(long MaNhanVien)
		{
			return DataPortal.Fetch<NghiKhongLuongList>(new FilterCriteria(MaNhanVien));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public long MaNhanVien ;
			public FilterCriteria(long manhanvien )
			{
                this.MaNhanVien = manhanvien;
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
                cm.CommandText = "[spd_SelecttblnsNghiKhongLuongsAll]";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NghiKhongLuong.GetNghiKhongLuong(dr));
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
				foreach (NghiKhongLuong deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (NghiKhongLuong child in this)
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
