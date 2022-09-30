
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BCKQHoatDongKinhDoanhList : Csla.BusinessListBase<BCKQHoatDongKinhDoanhList, BCKQHoatDongKinhDoanh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BCKQHoatDongKinhDoanh item = BCKQHoatDongKinhDoanh.NewBCKQHoatDongKinhDoanh();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BCKQHoatDongKinhDoanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BCKQHoatDongKinhDoanhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BCKQHoatDongKinhDoanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BCKQHoatDongKinhDoanhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BCKQHoatDongKinhDoanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BCKQHoatDongKinhDoanhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BCKQHoatDongKinhDoanhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BCKQHoatDongKinhDoanhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BCKQHoatDongKinhDoanhList()
		{ /* require use of factory method */ }

		public static BCKQHoatDongKinhDoanhList NewBCKQHoatDongKinhDoanhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BCKQHoatDongKinhDoanhList");
			return new BCKQHoatDongKinhDoanhList();
		}

		public static BCKQHoatDongKinhDoanhList GetBCKQHoatDongKinhDoanhList(byte loaiBaoCao,int maThongTu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BCKQHoatDongKinhDoanhList");
			return DataPortal.Fetch<BCKQHoatDongKinhDoanhList>(new FilterCriteria(loaiBaoCao,maThongTu));
		}

        public static BCKQHoatDongKinhDoanhList GetBCKQHoatDongKinhDoanhListforNHNN(byte loaiBaoCao, int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BCKQHoatDongKinhDoanhList");
            return DataPortal.Fetch<BCKQHoatDongKinhDoanhList>(new FilterCriteriaforNHNN(loaiBaoCao, maThongTu));
        }

        public static BCKQHoatDongKinhDoanhList GetBCKQHoatDongKinhDoanhListbyMaThongTu(byte loaiBaoCao, int maThongTu,byte isNHNN)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BCKQHoatDongKinhDoanhList");
            return DataPortal.Fetch<BCKQHoatDongKinhDoanhList>(new FilterCriteriabyMaThongTu(loaiBaoCao, maThongTu,isNHNN));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public byte LoaiBaoCao;
            public int MaThongTu;
			public FilterCriteria(byte _loaiBaoCao,int maThongTu)
			{
                LoaiBaoCao = _loaiBaoCao;
                MaThongTu = maThongTu;
			}
		}

        [Serializable()]
        private class FilterCriteriaforNHNN
        {
            public byte LoaiBaoCao;
            public int MaThongTu;
            public FilterCriteriaforNHNN(byte _loaiBaoCao, int maThongTu)
            {
                LoaiBaoCao = _loaiBaoCao;
                MaThongTu = maThongTu;
            }
        }

        [Serializable()]
        private class FilterCriteriabyMaThongTu
        {
            public byte LoaiBaoCao;
            public int MaThongTu;
            public byte isNHNN;
            public FilterCriteriabyMaThongTu(byte _loaiBaoCao, int maThongTu,byte _isNHNN)
            {
                LoaiBaoCao = _loaiBaoCao;
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
                if(criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblMauBCKQHoatDongKinhDoanhesforThongTu";
                    cm.Parameters.AddWithValue("@LoaiBaoCao",((FilterCriteria) criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteria)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriaforNHNN)
                {
                    cm.CommandText = "spd_SelecttblMauBCKQHoatDongKinhDoanhesforNHNN";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteriaforNHNN)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaforNHNN)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriabyMaThongTu)
                {
                    cm.CommandText = "spd_SelecttblMauBCKQHoatDongKinhDoanhesbyMaThongTu";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteriabyMaThongTu)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriabyMaThongTu)criteria).MaThongTu);
                    cm.Parameters.AddWithValue("@isNHNN", ((FilterCriteriabyMaThongTu)criteria).isNHNN);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BCKQHoatDongKinhDoanh.GetBCKQHoatDongKinhDoanh(dr));
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
					foreach (BCKQHoatDongKinhDoanh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BCKQHoatDongKinhDoanh child in this)
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
