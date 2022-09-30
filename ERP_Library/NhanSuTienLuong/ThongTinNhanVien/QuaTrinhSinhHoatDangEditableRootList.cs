
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhSinhHoatDangList : Csla.BusinessListBase<QuaTrinhSinhHoatDangList, QuaTrinhSinhHoatDang>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuaTrinhSinhHoatDang item = QuaTrinhSinhHoatDang.NewQuaTrinhSinhHoatDang();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhSinhHoatDangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhSinhHoatDangListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhSinhHoatDangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhSinhHoatDangListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhSinhHoatDangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhSinhHoatDangListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhSinhHoatDangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhSinhHoatDangListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhSinhHoatDangList()
		{ /* require use of factory method */ }

		public static QuaTrinhSinhHoatDangList NewQuaTrinhSinhHoatDangList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhSinhHoatDangList");
			return new QuaTrinhSinhHoatDangList();
		}

		public static QuaTrinhSinhHoatDangList GetQuaTrinhSinhHoatDangList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhSinhHoatDangList");
			return DataPortal.Fetch<QuaTrinhSinhHoatDangList>(new FilterCriteria(maNhanVien));
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhSinhHoatDangsAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuaTrinhSinhHoatDang.GetQuaTrinhSinhHoatDang(dr));
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
					foreach (QuaTrinhSinhHoatDang deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (QuaTrinhSinhHoatDang child in this)
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
