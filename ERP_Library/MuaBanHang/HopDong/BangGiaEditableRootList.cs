
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangGiaList : Csla.BusinessListBase<BangGiaList, BangGia>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BangGia item = BangGia.NewBangGia();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangGiaList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangGiaListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangGiaList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangGiaListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangGiaList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangGiaListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangGiaList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangGiaListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangGiaList()
		{ /* require use of factory method */ }

		public static BangGiaList NewBangGiaList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangGiaList");
			return new BangGiaList();
		}

		public static BangGiaList GetBangGiaList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangGiaList");
			return DataPortal.Fetch<BangGiaList>(new FilterCriteria());
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			//public int MaHangHoa;
			//public int MaDonViTinh;

			public FilterCriteria()//(int maHangHoa, int maDonViTinh)
			{
                //this.MaHangHoa = maHangHoa;
                //this.MaDonViTinh = maDonViTinh;
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
                cm.CommandText = "spd_SelecttblBangGiasAll";
				//cm.Parameters.AddWithValue("@MaHangHoa", criteria.MaHangHoa);
				//cm.Parameters.AddWithValue("@MaDonViTinh", criteria.MaDonViTinh);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BangGia.GetBangGia(dr));
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
					foreach (BangGia deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BangGia child in this)
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
