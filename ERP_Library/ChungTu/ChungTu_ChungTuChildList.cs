using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_ChungTuChildList : Csla.BusinessListBase<ChungTu_ChungTuChildList, ChungTu_ChungTuChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_ChungTuChild item = ChungTu_ChungTuChild.NewChungTu_ChungTuChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChungTu_ChungTuChildList NewChungTu_ChungTuChildList()
        {
            return new ChungTu_ChungTuChildList();
        }

        internal static ChungTu_ChungTuChildList GetChungTu_ChungTuChildList(SafeDataReader dr)
        {
            return new ChungTu_ChungTuChildList(dr);
        }

        internal static ChungTu_ChungTuChildList GetChungTu_ChungTuChildList(long maChungTu)
        {
            return new ChungTu_ChungTuChildList(maChungTu);
        }

        public static ChungTu_ChungTuChildList GetChungTu_ChungTuChildListByIdDTCN(int IdDTCN)
        {
            return DataPortal.Fetch<ChungTu_ChungTuChildList>(new FilterCriteriaByIdDTCN(IdDTCN));
        }
        [Serializable()]
        private class FilterCriteriaByIdDTCN
        {
            public long IdDTCN;

            public FilterCriteriaByIdDTCN(int idDTCN)
            {
                this.IdDTCN = idDTCN;
            }
        }
        private ChungTu_ChungTuChildList()
        {
            MarkAsChild();
        }

        private ChungTu_ChungTuChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }

        private ChungTu_ChungTuChildList(long maChungTu)
        {
            MarkAsChild();
            Fetch(maChungTu);
        }
        #endregion //Factory Methods


        #region Data Access
       
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
                cm.CommandTimeout = 3600;
               if (criteria is FilterCriteriaByIdDTCN)
                {
                    cm.CommandText = "spd_SelecttblChungTu_ChungTuByIdDTCN";
                    cm.Parameters.AddWithValue("@IdDTCN", ((FilterCriteriaByIdDTCN)criteria).IdDTCN);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_ChungTuChild.GetChungTu_ChungTuChild(dr));
                    }
                }                
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChungTu_ChungTuChild.GetChungTu_ChungTuChild(dr));

            RaiseListChangedEvents = true;
        }

        private void Fetch(long maChungTu)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblChungTu_ChungTusAll";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_ChungTuChild.GetChungTu_ChungTuChild(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu parent)
        {
             RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_ChungTuChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_ChungTuChild child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
            
        }
        internal void Update(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_ChungTuChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_ChungTuChild child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;

        }
        #endregion //Data Access

    }
}
