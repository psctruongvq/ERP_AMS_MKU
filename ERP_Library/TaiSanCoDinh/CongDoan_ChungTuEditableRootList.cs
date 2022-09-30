
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CongDoan_ChungTuList : Csla.BusinessListBase<CongDoan_ChungTuList, CongDoan_ChungTu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongDoan_ChungTu item = CongDoan_ChungTu.NewCongDoan_ChungTu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private CongDoan_ChungTuList()
        { /* require use of factory method */ }

        public static CongDoan_ChungTuList NewCongDoan_ChungTuList()
        {
            return new CongDoan_ChungTuList();
        }

        public static CongDoan_ChungTuList GetCongDoan_ChungTuList()
        {
            return DataPortal.Fetch<CongDoan_ChungTuList>(new FilterCriteria());
        }
        public static CongDoan_ChungTuList GetCongDoan_ChungTuList(DateTime tuNgay, DateTime denNgay, int loaiChungTu)
        {
            return DataPortal.Fetch<CongDoan_ChungTuList>(new FilterCriteriaByNgay(tuNgay,denNgay,loaiChungTu ));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
      
         private class FilterCriteriaByNgay
        {
            public DateTime tuNgay;
            public DateTime denNgay;
            public int loaiChungTu;
            public FilterCriteriaByNgay(DateTime _tuNgay,DateTime _denNgay, Int32 _loaiChungTu)
            {
                this.tuNgay = _tuNgay;
                this.denNgay = _denNgay;
                this.loaiChungTu=_loaiChungTu;
            }
        }
        private class FilterCriteria
        {

            public FilterCriteria()
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
                    cm.CommandText = "SelecttblCongDoan_ChungTusAll";
                }
                else if (criteria is FilterCriteriaByNgay)
                {
                    cm.CommandText = "SelecttblCongDoan_ChungTuByNgay";
                    cm.Parameters.AddWithValue("@TuNgay",((FilterCriteriaByNgay)criteria).tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgay)criteria).denNgay);
                    cm.Parameters.AddWithValue("@LoaiChungTu", ((FilterCriteriaByNgay)criteria).loaiChungTu);
                    cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongDoan_ChungTu.GetCongDoan_ChungTu(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {

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
                        foreach (CongDoan_ChungTu deletedChild in DeletedList)
                            deletedChild.DeleteSelf(tr);
                        DeletedList.Clear();

                        // loop through each non-deleted child object
                        foreach (CongDoan_ChungTu child in this)
                        {
                            if (child.IsNew)
                                child.Insert(tr, child);
                            else
                                child.Update(tr, child);
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
}
