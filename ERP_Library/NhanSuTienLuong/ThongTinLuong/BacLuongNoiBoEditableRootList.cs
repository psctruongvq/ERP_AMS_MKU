
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BacLuongNoiBoList : Csla.BusinessListBase<BacLuongNoiBoList, BacLuongNoiBo>
	{
		#region BindingList Overrides
		protected override object  AddNewCore()
{
 			BacLuongNoiBo item = BacLuongNoiBo.NewBacLuongNoiBo();
			this.Add(item);
			return item;
	
        }
        #endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BacLuongNoiBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongNoiBoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BacLuongNoiBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongNoiBoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BacLuongNoiBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongNoiBoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BacLuongNoiBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongNoiBoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BacLuongNoiBoList()
		{ /* require use of factory method */ }

		public static BacLuongNoiBoList NewBacLuongNoiBoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BacLuongNoiBoList");
			return new BacLuongNoiBoList();
		}

		public static BacLuongNoiBoList GetBacLuongNoiBoList(int maNgachLuongCB)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BacLuongNoiBoList");
			return DataPortal.Fetch<BacLuongNoiBoList>(new FilterCriteria(maNgachLuongCB));
		}
        public static BacLuongNoiBoList GetBacLuongNoiBoListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BacLuongNoiBoList");
            return DataPortal.Fetch<BacLuongNoiBoList>(new FilterCriteriaAll());
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaNgachLuongCB;

			public FilterCriteria(int maNgachLuongCB)
			{
				this.MaNgachLuongCB = maNgachLuongCB;
			}
		}
        [Serializable()]
        private class FilterCriteriaAll
        {


            public FilterCriteriaAll()
            {
                
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
                    cm.CommandText = "spd_SelecttblnsBacLuongNoiBo_byNgach";
                    cm.Parameters.AddWithValue("@MaNgachLuongNoiBo",((FilterCriteria) criteria).MaNgachLuongCB);
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblnsBacLuongNoiBosAll";
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BacLuongNoiBo.GetBacLuongNoiBo(dr));
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
					foreach (BacLuongNoiBo deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BacLuongNoiBo child in this)
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
