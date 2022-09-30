
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DotGiaoHangHDMBList : Csla.BusinessListBase<DotGiaoHangHDMBList, DotGiaoHangHDMB>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			DotGiaoHangHDMB item = DotGiaoHangHDMB.NewDotGiaoHangHDMB();
			this.Add(item);
			return item;
		}

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

		#endregion //BindingList Overrides

		#region Factory Methods
		public static DotGiaoHangHDMBList NewDotGiaoHangHDMBList()
		{
			return new DotGiaoHangHDMBList();
		}

		public static DotGiaoHangHDMBList GetDotGiaoHangHDMBList(long maHopDong)
		{
            return DataPortal.Fetch<DotGiaoHangHDMBList>(new FilterCriteria(maHopDong));
		}

		private DotGiaoHangHDMBList()
        {
            //DotGiaoHangHDMB item = DotGiaoHangHDMB.NewDotGiaoHangHDMB();
            //this.Add(item);
            MarkAsChild();
		}

		private DotGiaoHangHDMBList(SafeDataReader dr)
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
            try
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDotGiaoHangHDMBsByMaHopDongMuaBan";
                    cm.Parameters.AddWithValue("@MaHopDongMuaBan", criteria.MaHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DotGiaoHangHDMB.GetDotGiaoHangHDMB(dr));
                    }
                }//using
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        #endregion //Data Access - Fetch

		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(DotGiaoHangHDMB.GetDotGiaoHangHDMB(dr));

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, HopDongMuaBan parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (DotGiaoHangHDMB deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (DotGiaoHangHDMB child in this)
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
