using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_DieuChuyenNoiBoCongCuDungCuList : Csla.BusinessListBase<CT_DieuChuyenNoiBoCongCuDungCuList, CT_DieuChuyenNoiBoCongCuDungCu>
	{

		#region Factory Methods
		internal static CT_DieuChuyenNoiBoCongCuDungCuList NewCT_DieuChuyenNoiBoCongCuDungCuList()
		{
			return new CT_DieuChuyenNoiBoCongCuDungCuList();
		}
        internal static CT_DieuChuyenNoiBoCongCuDungCuList GetCT_DieuChuyenNoiBoCongCuDungCuList(int maDieuChuyen)
        {
            return DataPortal.Fetch<CT_DieuChuyenNoiBoCongCuDungCuList>(new FilterCriteriaByMaDieuChuyen(maDieuChuyen));
        }
		internal static CT_DieuChuyenNoiBoCongCuDungCuList GetCT_DieuChuyenNoiBoCongCuDungCuList(SafeDataReader dr)
		{
			return new CT_DieuChuyenNoiBoCongCuDungCuList(dr);
		}

		private CT_DieuChuyenNoiBoCongCuDungCuList()
		{
			MarkAsChild();
		}

		private CT_DieuChuyenNoiBoCongCuDungCuList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaByMaDieuChuyen
        {
            public int MaDieuChuyen;
            public FilterCriteriaByMaDieuChuyen(int maDieuChuyen)
            {
                this.MaDieuChuyen = maDieuChuyen;
            }
        }
        #endregion //Filter Criteria
		#region Data Access
        private void DataPortal_Fetch(FilterCriteriaByMaDieuChuyen criteria)
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
        private void ExecuteFetch(SqlTransaction tr, FilterCriteriaByMaDieuChuyen criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectCT_DieuChuyenNoiBoCongCuDungCuList_byMaDieuChuyen";
                cm.Parameters.AddWithValue("@MaDieuChuyen", criteria.MaDieuChuyen);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CT_DieuChuyenNoiBoCongCuDungCu.GetCT_DieuChuyenNoiBoCongCuDungCu(dr));
                }
            }//using
        }
		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(CT_DieuChuyenNoiBoCongCuDungCu.GetCT_DieuChuyenNoiBoCongCuDungCu(dr));

			RaiseListChangedEvents = true;
		}

		internal void Update(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCu parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CT_DieuChuyenNoiBoCongCuDungCu deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CT_DieuChuyenNoiBoCongCuDungCu child in this)
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
