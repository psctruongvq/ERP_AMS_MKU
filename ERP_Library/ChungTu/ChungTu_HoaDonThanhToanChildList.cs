using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_HoaDonThanhToanChildList : Csla.BusinessListBase<ChungTu_HoaDonThanhToanChildList, ChungTu_HoaDonThanhToan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_HoaDonThanhToan item = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        public void Remove(long maChungTu_HoaDonThanhToan)
        {
            foreach (ChungTu_HoaDonThanhToan item in this)
            {
                if (item.Id == maChungTu_HoaDonThanhToan)
                {
                    Remove(item);
                    break;
                }
            }
        }

        #region Factory Methods
        public static ChungTu_HoaDonThanhToanChildList NewChungTu_HoaDonThanhToanChildList()
        {
            return new ChungTu_HoaDonThanhToanChildList();
        }

        internal static ChungTu_HoaDonThanhToanChildList GetChungTu_HoaDonThanhToanChildList(SafeDataReader dr)
        {
            return new ChungTu_HoaDonThanhToanChildList(dr);
        }

        public static ChungTu_HoaDonThanhToanChildList GetChungTu_HoaDonThanhToanChildListByChungTu(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_HoaDonThanhToanChildList>(new FilterCriteriaByChungTu(maChungTu));
        }

        public static ChungTu_HoaDonThanhToanChildList GetChungTu_HoaDonThanhToanChildListByIdDTCN(int IdDTCN)
        {
            return DataPortal.Fetch<ChungTu_HoaDonThanhToanChildList>(new FilterCriteriaByIdDTCN(IdDTCN));
        }

        public static ChungTu_HoaDonThanhToanChildList GetChungTu_HoaDonThanhToanChildListByHoaDon(long IdHoaDon)
        {
            return DataPortal.Fetch<ChungTu_HoaDonThanhToanChildList>(new FilterCriteriaByHoaDon(IdHoaDon));
        }

        private ChungTu_HoaDonThanhToanChildList()
        {
            MarkAsChild();
        }

        private ChungTu_HoaDonThanhToanChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaByChungTu
        {
            public long MaChungTu;

            public FilterCriteriaByChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        [Serializable()]
        private class FilterCriteriaByHoaDon
        {
            public long IdHoaDon;

            public FilterCriteriaByHoaDon(long idHD)
            {
                this.IdHoaDon = idHD;
            }
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
                cm.CommandTimeout = 0;
                if (criteria is FilterCriteriaByChungTu)
                {
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonThanhToansByChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTu)criteria).MaChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_HoaDonThanhToan.GetChungTu_HoaDonThanhToan(dr));
                    }
                }
                else if (criteria is FilterCriteriaByIdDTCN)
                {
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonThanhToansByIdDTCN";
                    cm.Parameters.AddWithValue("@IdDTCN", ((FilterCriteriaByIdDTCN)criteria).IdDTCN);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                           this.Add(ChungTu_HoaDonThanhToan.GetChungTu_HoaDonThanhToan_deXoa(dr));
                    }
                }
                else if (criteria is FilterCriteriaByHoaDon)
                {
                    cm.CommandText = "spd_GetChungTuHoaDonByMaHoaDon";
                    cm.Parameters.AddWithValue("@MaHoaDon", ((FilterCriteriaByHoaDon)criteria).IdHoaDon);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_HoaDonThanhToan.GetChungTu_HoaDonThanhToan(dr));
                    }
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChungTu_HoaDonThanhToan.GetChungTu_HoaDonThanhToan(dr));

            RaiseListChangedEvents = true;
        }

        #endregion Data Access - Fetch

        #region Parent ChungTu
        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_HoaDonThanhToan deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_HoaDonThanhToan child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        } 
        #endregion//Parent ChungTu

        #region Update Parent: HoaDon
        internal void Update(SqlTransaction tr, HoaDon parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                foreach (ChungTu_HoaDonThanhToan deletedChild in DeletedList)
                //deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                {
                    deletedChild.DeleteSelf(tr);                    
                }
                DeletedList.Clear();
                foreach (ChungTu_HoaDonThanhToan child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }

            RaiseListChangedEvents = true;
        }
        #endregion// Update Parent: HoaDon

        #region Parent DoiTruCongNo
        internal void Update(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_HoaDonThanhToan deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_HoaDonThanhToan child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion//Parent ChungTu

        #endregion //Data Access

    }
}
