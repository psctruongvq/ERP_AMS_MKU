
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangCanDoiKeToanList : Csla.BusinessListBase<BangCanDoiKeToanList, BangCanDoiKeToan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BangCanDoiKeToan item = BangCanDoiKeToan.NewBangCanDoiKeToan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangCanDoiKeToanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangCanDoiKeToanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangCanDoiKeToanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangCanDoiKeToanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangCanDoiKeToanList()
		{ /* require use of factory method */ }

		public static BangCanDoiKeToanList NewBangCanDoiKeToanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangCanDoiKeToanList");
			return new BangCanDoiKeToanList();
		}

		public static BangCanDoiKeToanList GetBangCanDoiKeToanList(int maThongTu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanList");
			return DataPortal.Fetch<BangCanDoiKeToanList>(new FilterCriteria(maThongTu));
		}

        public static BangCanDoiKeToanList GetBangCanDoiKeToanListforNHNN(int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanList");
            return DataPortal.Fetch<BangCanDoiKeToanList>(new FilterCriteriaforNHNN(maThongTu));
        }

        public static BangCanDoiKeToanList GetBangCanDoiKeToanListbyMaThongTu(int maThongTu,byte isNHNN)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanList");
            return DataPortal.Fetch<BangCanDoiKeToanList>(new FilterCriteriabyMaThongTu(maThongTu,isNHNN));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int MaThongTu = 0;

			public FilterCriteria(int maThongTu)
			{
                MaThongTu = maThongTu;
			}
		}
        [Serializable()]
        private class FilterCriteriaforNHNN
        {
            public int MaThongTu = 0;

            public FilterCriteriaforNHNN(int maThongTu)
            {
                MaThongTu = maThongTu;
            }
        }

        [Serializable()]
        private class FilterCriteriabyMaThongTu
        {
            public int MaThongTu = 0;
            public byte isNHNN = 0;

            public FilterCriteriabyMaThongTu(int maThongTu,byte _isNHNN)
            {
                MaThongTu = maThongTu;
                isNHNN = _isNHNN;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblBangCanDoiKeToansforThongTu";
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteria)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriaforNHNN)
                {
                    cm.CommandText = "spd_SelecttblBangCanDoiKeToansforNHNN";
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaforNHNN)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriabyMaThongTu)
                {
                    cm.CommandText = "spd_SelecttblBangCanDoiKeToansbyMaThongTu";
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriabyMaThongTu)criteria).MaThongTu);
                    cm.Parameters.AddWithValue("@isNHNN", ((FilterCriteriabyMaThongTu)criteria).isNHNN);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BangCanDoiKeToan.GetBangCanDoiKeToan(dr));
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
					foreach (BangCanDoiKeToan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BangCanDoiKeToan child in this)
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
