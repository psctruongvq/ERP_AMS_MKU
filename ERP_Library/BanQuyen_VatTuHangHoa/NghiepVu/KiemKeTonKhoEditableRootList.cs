
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KiemKeTonKhoList : Csla.BusinessListBase<KiemKeTonKhoList, KiemKeTonKho>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KiemKeTonKho item = KiemKeTonKho.NewKiemKeTonKho();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KiemKeTonKhoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KiemKeTonKhoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KiemKeTonKhoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KiemKeTonKhoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KiemKeTonKhoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KiemKeTonKhoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KiemKeTonKhoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KiemKeTonKhoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KiemKeTonKhoList()
		{ /* require use of factory method */ }

		public static KiemKeTonKhoList NewKiemKeTonKhoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KiemKeTonKhoList");
			return new KiemKeTonKhoList();
		}

		public static KiemKeTonKhoList GetKiemKeTonKhoList(int maKy,int maKho, long maNhanVien,  int ngayLap, DateTime tuNgay,DateTime denNgay)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KiemKeTonKhoList");
			return DataPortal.Fetch<KiemKeTonKhoList>(new FilterCriteria(maKy, maKho, maNhanVien, ngayLap,tuNgay,denNgay));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaKy=-1;
            public int MaKho;
			public long MaNhanVien;
            public int NgayLap;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteria(int maKy,int maKho, long maNhanVien, int ngayLap, DateTime tuNgay, DateTime denNgay)
			{
				this.MaKy = maKy;
                this.MaKho=maKho;
				this.MaNhanVien = maNhanVien;
                this.NgayLap = ngayLap;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
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
            if(criteria.MaKy==-1)
			    using (SqlCommand cm = tr.Connection.CreateCommand())
			    {
				    cm.Transaction = tr;
				    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblKiemKeTonKhosAll";
                                      
				    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				    {
					    while (dr.Read())
						    this.Add(KiemKeTonKho.GetKiemKeTonKho(dr));
				    }
			    }//using
            else
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblKiemKeTonKhosByAll";
                    cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);
                    cm.Parameters.AddWithValue("@MaKho", criteria.MaKho);                   
                    cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                    cm.Parameters.AddWithValue("@NgayLap", criteria.NgayLap);
                    cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);                     

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KiemKeTonKho.GetKiemKeTonKho(dr));
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
					foreach (KiemKeTonKho deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KiemKeTonKho child in this)
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
