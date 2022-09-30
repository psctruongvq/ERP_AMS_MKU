
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DotThanhToanHDMBList : Csla.BusinessListBase<DotThanhToanHDMBList, DotThanhToanHDMB>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			DotThanhToanHDMB item = DotThanhToanHDMB.NewDotThanhToanHDMB();
			this.Add(item);
			return item;
		}
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static DotThanhToanHDMBList NewDotThanhToanHDMBList()
		{
			return new DotThanhToanHDMBList();
		}

		internal static DotThanhToanHDMBList GetDotThanhToanHDMBList(long maHopDong)
		{
            return DataPortal.Fetch<DotThanhToanHDMBList>(new FilterCriteria(maHopDong));
		}

		private DotThanhToanHDMBList()
		{
            //DotThanhToanHDMB item = DotThanhToanHDMB.NewDotThanhToanHDMB();
            //this.Add(item);
			MarkAsChild();
		}

		private DotThanhToanHDMBList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaHopDong;


            public FilterCriteria(long maHopDong)
            {
                this.MaHopDong = maHopDong;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        protected override void DataPortal_Fetch(object criteria)
        {
            if (criteria is FilterCriteria)
            {
                DataPortal_Fetch((FilterCriteria)criteria);
            }
        }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblDotThanhToanHDMBsByMaHopDongMuaBan";
                cm.Parameters.AddWithValue("@MaHopDongMuaBan", criteria.MaHopDong);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                       this.Add(DotThanhToanHDMB.GetDotThanhToanHDMB(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch

		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(DotThanhToanHDMB.GetDotThanhToanHDMB(dr));

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, HopDongMuaBan parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (DotThanhToanHDMB deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (DotThanhToanHDMB child in this)
			{
				if(child.IsNew)
					child.Insert(tr, parent);
				else
					child.Update(tr, parent);
			}

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access
	}
}
