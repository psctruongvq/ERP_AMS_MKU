
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhamChuaBenhList : Csla.BusinessListBase<KhamChuaBenhList, KhamChuaBenh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KhamChuaBenh item = KhamChuaBenh.NewKhamChuaBenh();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KhamChuaBenhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhamChuaBenhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KhamChuaBenhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhamChuaBenhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KhamChuaBenhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhamChuaBenhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KhamChuaBenhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhamChuaBenhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KhamChuaBenhList()
		{ /* require use of factory method */ }

		public static KhamChuaBenhList NewKhamChuaBenhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhamChuaBenhList");
			return new KhamChuaBenhList();
		}

		public static KhamChuaBenhList GetKhamChuaBenhList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KhamChuaBenhList");
			return DataPortal.Fetch<KhamChuaBenhList>(new FilterCriteria(maNhanVien));
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
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
                cm.CommandText = "spd_SelecttblnsThongTinKhamChuaBenhesAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(KhamChuaBenh.GetKhamChuaBenh(dr));
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
					foreach (KhamChuaBenh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KhamChuaBenh child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
