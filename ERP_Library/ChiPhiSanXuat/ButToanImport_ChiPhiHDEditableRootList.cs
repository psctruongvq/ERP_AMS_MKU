
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToanImport_ChiPhiHDList : Csla.BusinessListBase<ButToanImport_ChiPhiHDList, ButToanImport_ChiPhiHD>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ButToanImport_ChiPhiHD item = ButToanImport_ChiPhiHD.NewButToanImport_ChiPhiHD();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ButToanImport_ChiPhiHDList()
		{ /* require use of factory method */ }

		public static ButToanImport_ChiPhiHDList NewButToanImport_ChiPhiHDList()
		{
			return new ButToanImport_ChiPhiHDList();
		}

		public static ButToanImport_ChiPhiHDList GetButToanImport_ChiPhiHDList(int maChiPhiHD, int maButToan)
		{
			return DataPortal.Fetch<ButToanImport_ChiPhiHDList>(new FilterCriteria(maChiPhiHD, maButToan));
		}
        public static ButToanImport_ChiPhiHDList GetButToanImport_ChiPhiHDList( int maButToan)
        {
            return DataPortal.Fetch<ButToanImport_ChiPhiHDList>(new FilterCriteriaButToan( maButToan));
        }
        public static ButToanImport_ChiPhiHDList GetButToanImport_ChiPhiHDList(DateTime tuNgay,DateTime denNgay,string noTK,string coTK,string maBoPhan)
        {
            return DataPortal.Fetch<ButToanImport_ChiPhiHDList>(new FilterCriteriaButToanByNgay(tuNgay,denNgay,noTK,coTK,maBoPhan));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaChiPhiHD;
			public int MaButToan;

			public FilterCriteria(int maChiPhiHD, int maButToan)
			{
				this.MaChiPhiHD = maChiPhiHD;
				this.MaButToan = maButToan;
			}
		}
        private class FilterCriteriaButToanByNgay
        {
            public DateTime tuNgay;
            public DateTime denNgay;
            public string NoTK;
            public string CoTK;
            public string MaBoPhan;
            public FilterCriteriaButToanByNgay(DateTime tuNgay,DateTime denNgay,string noTK,string coTK,string maBoPhan)
            {
                this.tuNgay = tuNgay;
                this.denNgay = denNgay;
                this.NoTK = noTK;
                this.CoTK = coTK;
                this.MaBoPhan = maBoPhan;
            }
        }
        private class FilterCriteriaButToan
        {            
            public int MaButToan;
            public FilterCriteriaButToan(int maButToan)
            {                
                this.MaButToan = maButToan;
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
                    cm.CommandText = "SelecttblButToanImport_ChiPhiHDsAll";
                    cm.Parameters.AddWithValue("@MaChiPhiHD",((FilterCriteria)criteria).MaChiPhiHD);
                    cm.Parameters.AddWithValue("@MaButToan", ((FilterCriteria)criteria).MaButToan);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }
                else if (criteria is FilterCriteriaButToan)
                {
                    cm.CommandText = "SelecttblButToanImport_ChiPhiHDByButToan";
                    cm.Parameters.AddWithValue("@MaButToan", ((FilterCriteriaButToan)criteria).MaButToan);
                }
                else if (criteria is FilterCriteriaButToanByNgay)
                {
                    cm.CommandText = "SelecttblButToanImport_ChiPhiHDByNgayLap";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaButToanByNgay)criteria).tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaButToanByNgay)criteria).denNgay);
                    cm.Parameters.AddWithValue("@NoTK", ((FilterCriteriaButToanByNgay)criteria).NoTK);
                    cm.Parameters.AddWithValue("@CoTK", ((FilterCriteriaButToanByNgay)criteria).CoTK);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaButToanByNgay)criteria).MaBoPhan);
                 
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ButToanImport_ChiPhiHD.GetButToanImport_ChiPhiHD(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		public  void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

            SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
                    //// loop through each deleted child object
                    //foreach (ButToanImport_ChiPhiHD deletedChild in DeletedList)
                    //    deletedChild.DeleteSelf(tr);
                    //DeletedList.Clear();

					// loop through each non-deleted child object
                    foreach (ButToanImport_ChiPhiHD child in this)
                    {
                        if (child.IsDirty)
                            child.Update(tr);
                    }
                    tr.Commit();
					
				}
				catch
				{
					
					throw;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
