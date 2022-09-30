
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhenThuongList : Csla.BusinessListBase<KhenThuongList, KhenThuong>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KhenThuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KhenThuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KhenThuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KhenThuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhenThuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KhenThuongList()
		{ /* require use of factory method */ }

		public static KhenThuongList NewKhenThuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhenThuongList");
			return new KhenThuongList();
		}

		public static KhenThuongList GetKhenThuongList(int maChucVu, int maCongViec, int maMucDo)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KhenThuongList");
			return DataPortal.Fetch<KhenThuongList>(new FilterCriteria(maChucVu, maCongViec, maMucDo));
		}
        public static KhenThuongList GetKhenThuongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhenThuongList");
            return DataPortal.Fetch<KhenThuongList>(new FilterCriteria());
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaChucVu;
			public int MaCongViec;
			public int MaMucDo;

			public FilterCriteria(int maChucVu, int maCongViec, int maMucDo)
			{
				this.MaChucVu = maChucVu;
				this.MaCongViec = maCongViec;
				this.MaMucDo = maMucDo;
			}
            public FilterCriteria()
            { 
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
                cm.CommandText = "spd_SelecttblnsKhenThuongsAll";
				
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(KhenThuong.GetKhenThuong(dr));
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
				foreach (KhenThuong deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (KhenThuong child in this)
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
