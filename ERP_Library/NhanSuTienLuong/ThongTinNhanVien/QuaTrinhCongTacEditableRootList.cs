
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhCongTacList : Csla.BusinessListBase<QuaTrinhCongTacList, QuaTrinhCongTac>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuaTrinhCongTac item = QuaTrinhCongTac.NewQuaTrinhCongTac();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhCongTacList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhCongTacListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhCongTacList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhCongTacListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhCongTacList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhCongTacListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhCongTacList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhCongTacListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhCongTacList()
		{ /* require use of factory method */ }

		public static QuaTrinhCongTacList NewQuaTrinhCongTacList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhCongTacList");
			return new QuaTrinhCongTacList();
		}

		public static QuaTrinhCongTacList GetQuaTrinhCongTacList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhCongTacList");
			return DataPortal.Fetch<QuaTrinhCongTacList>(new FilterCriteria(maNhanVien));
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
				catch (Exception ex)
				{
					tr.Rollback();
					throw ex;
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhCongTacsAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuaTrinhCongTac.GetQuaTrinhCongTac(dr));
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
					foreach (QuaTrinhCongTac deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (QuaTrinhCongTac child in this)
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
