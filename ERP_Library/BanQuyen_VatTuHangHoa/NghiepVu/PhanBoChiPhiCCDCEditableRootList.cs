
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoChiPhiCCDCList : Csla.BusinessListBase<PhanBoChiPhiCCDCList, PhanBoChiPhiCCDC>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhanBoChiPhiCCDC item = PhanBoChiPhiCCDC.NewPhanBoChiPhiCCDC();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoChiPhiCCDCList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoChiPhiCCDCListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoChiPhiCCDCList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoChiPhiCCDCListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoChiPhiCCDCList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoChiPhiCCDCListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoChiPhiCCDCList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoChiPhiCCDCListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoChiPhiCCDCList()
		{ /* require use of factory method */ }

		public static PhanBoChiPhiCCDCList NewPhanBoChiPhiCCDCList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoChiPhiCCDCList");
			return new PhanBoChiPhiCCDCList();
		}

		public static PhanBoChiPhiCCDCList GetPhanBoChiPhiCCDCList( int maBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoChiPhiCCDCList");
			return DataPortal.Fetch<PhanBoChiPhiCCDCList>(new FilterCriteria( maBoPhan));
		}

        public static PhanBoChiPhiCCDCList GetPhanBoChiPhiCCDCList( int maBoPhan, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoChiPhiCCDCList");
            return DataPortal.Fetch<PhanBoChiPhiCCDCList>(new FilterCriteriaByNgay( maBoPhan, tuNgay, denNgay));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{		
			public int MaBoPhan;
            public int UserID = ERP_Library.Security.CurrentUser.Info.UserID;
            
			public FilterCriteria(int maBoPhan)
			{
				this.MaBoPhan = maBoPhan;				                
			}
		}

        private class FilterCriteriaByNgay
        {          
            public int MaBoPhan;
            public int UserID = ERP_Library.Security.CurrentUser.Info.UserID; 
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterCriteriaByNgay(int maBoPhan, DateTime tuNgay, DateTime denNgay)
            {            
                this.MaBoPhan = maBoPhan;              
                
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
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
                    cm.CommandText = "spd_SelecttblPhanBoChiPhiCCDCsByAndMaNguoiLap";
                    cm.Parameters.AddWithValue("@MaNguoiLap", ((FilterCriteria)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                }
                else if (criteria is FilterCriteriaByNgay)
                {
                    cm.CommandText = "spd_SelecttblPhanBoChiPhiCCDCsByNgay";
                    cm.Parameters.AddWithValue("@MaNguoiLap", ((FilterCriteriaByNgay)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNgay)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgay)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgay)criteria).DenNgay);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(PhanBoChiPhiCCDC.GetPhanBoChiPhiCCDC(dr));
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
					foreach (PhanBoChiPhiCCDC deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhanBoChiPhiCCDC child in this)
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
