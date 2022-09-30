
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhuVucList : Csla.BusinessListBase<KhuVucList, KhuVuc>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KhuVuc item = KhuVuc.NewKhuVuc();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KhuVucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhuVucListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KhuVucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhuVucListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KhuVucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhuVucListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KhuVucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhuVucListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KhuVucList()
		{ /* require use of factory method */ }

		public static KhuVucList NewKhuVucList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhuVucList");
			return new KhuVucList();
		}

		public static KhuVucList GetKhuVucList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KhuVucList");
			return DataPortal.Fetch<KhuVucList>(new FilterCriteria());
		}

        public static KhuVucList GetKhuVucList(int MaQuocGia)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhuVucList");
            return DataPortal.Fetch<KhuVucList>(new FilterCriteriaByQuocGia(MaQuocGia));
        }
		#endregion //Factory Methods
        
		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{		
            public FilterCriteria()
			{
				
			}
		}
        private class FilterCriteriaByQuocGia
        {
            public int MaQuocGia;
            public FilterCriteriaByQuocGia(int _MaQuocGia)
            {
                MaQuocGia = _MaQuocGia;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch       

        protected override void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblKhuVucsAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KhuVuc.GetKhuVuc(dr));
                    }
                }
            }//using
            if (criteria is FilterCriteriaByQuocGia)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblKhuVucByMaQuocGia";
                    cm.Parameters.AddWithValue("@MaQuocGia", ((FilterCriteriaByQuocGia)criteria).MaQuocGia);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KhuVuc.GetKhuVuc(dr));
                    }
                }
            }
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
					foreach (KhuVuc deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KhuVuc child in this)
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
