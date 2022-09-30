using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{ 
	[Serializable()] 
	public class DanhSachPhanBoThuLaoList : Csla.BusinessListBase<DanhSachPhanBoThuLaoList, DanhSachPhanBoThuLao>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DanhSachPhanBoThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachPhanBoThuLaoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DanhSachPhanBoThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachPhanBoThuLaoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DanhSachPhanBoThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachPhanBoThuLaoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DanhSachPhanBoThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachPhanBoThuLaoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DanhSachPhanBoThuLaoList()
		{ /* require use of factory method */ }

		public static DanhSachPhanBoThuLaoList NewDanhSachPhanBoThuLaoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhSachPhanBoThuLaoList");
			return new DanhSachPhanBoThuLaoList();
		}

		public static DanhSachPhanBoThuLaoList GetDanhSachPhanBoThuLaoList(int maKyTinhLuong, DateTime tuNgay,DateTime denNgay, int maBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DanhSachPhanBoThuLaoList");
			return DataPortal.Fetch<DanhSachPhanBoThuLaoList>(new FilterCriteria(maKyTinhLuong,tuNgay,denNgay, maBoPhan));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int _maKyTinhLuong;
            public DateTime _tuNgay;
            public DateTime _denNgay;
            public int _maBoPhan;

            public FilterCriteria(int maKyTinhLuong, DateTime tuNgay, DateTime denNgay, int maBoPhan)
			{
                _maKyTinhLuong = maKyTinhLuong;
                _tuNgay = tuNgay;
                _denNgay = denNgay;
                _maBoPhan = maBoPhan;
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
				cm.CommandText = "Spd_DanhSachPhanBoThuLaoList";

                cm.Parameters.Add("@MaKyTinhLuong",(criteria)._maKyTinhLuong);
                cm.Parameters.Add("@TuNgay", (criteria)._tuNgay);
                cm.Parameters.Add("@DenNgay", (criteria)._denNgay);
                cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(DanhSachPhanBoThuLao.GetDanhSachPhanBoThuLao(dr));
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
					foreach (DanhSachPhanBoThuLao deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (DanhSachPhanBoThuLao child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr,this);
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


