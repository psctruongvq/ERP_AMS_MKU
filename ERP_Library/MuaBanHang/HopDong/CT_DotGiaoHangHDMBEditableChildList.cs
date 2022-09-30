
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_DotGiaoHangHDMBList : Csla.BusinessListBase<CT_DotGiaoHangHDMBList, CT_DotGiaoHangHDMB>
	{
		#region BindingList Overrides
        //protected override object AddNewCore()
        //{
        //    CT_DotGiaoHangHDMB item = CT_DotGiaoHangHDMB.NewCT_DotGiaoHangHDMB();
        //    this.Add(item);
        //    return item;
        //}

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }
		#endregion //BindingList Overrides

		#region Factory Methods
		public static CT_DotGiaoHangHDMBList NewCT_DotGiaoHangHDMBList()
		{
			return new CT_DotGiaoHangHDMBList();
		}

		public static CT_DotGiaoHangHDMBList GetCT_DotGiaoHangHDMBList(int maDotGiaoHang)
		{
            return DataPortal.Fetch<CT_DotGiaoHangHDMBList>(new FilterCriteria(maDotGiaoHang));
		}

		private CT_DotGiaoHangHDMBList()
		{
           // CT_DotGiaoHangHDMB item = CT_DotGiaoHangHDMB.NewCT_DotGiaoHangHDMB();
            //this.Add(item);
			MarkAsChild();
		}

		private CT_DotGiaoHangHDMBList(SafeDataReader dr)
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
            public int MaDotGiaoHang;


            public FilterCriteria(int maDotGiaoHang)
            {
                this.MaDotGiaoHang = maDotGiaoHang;
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
                cm.CommandText = "spd_SelecttblCT_DotGiaoHangHDMBsByMaDotGiaoHang";
                cm.Parameters.AddWithValue("@MaDotGiaoHang", criteria.MaDotGiaoHang);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CT_DotGiaoHangHDMB.GetCT_DotGiaoHangHDMB(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch

		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(CT_DotGiaoHangHDMB.GetCT_DotGiaoHangHDMB(dr));

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, DotGiaoHangHDMB parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_DotGiaoHangHDMB deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_DotGiaoHangHDMB child in this)
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
