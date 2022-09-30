
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietChungTuNganHangList : Csla.BusinessListBase<ChiTietChungTuNganHangList, ChiTietChungTuNganHang>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietChungTuNganHang item = ChiTietChungTuNganHang.NewChiTietChungTuNganHang();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietChungTuNganHangList NewChiTietChungTuNganHangList()
        {
            return new ChiTietChungTuNganHangList();
        }

        internal static ChiTietChungTuNganHangList GetChiTietChungTuNganHangList(SafeDataReader dr)
        {
            return new ChiTietChungTuNganHangList(dr);
        }

        public static ChiTietChungTuNganHangList GetChiTietChungTuNganHangList(long maChungTu)
        {
            return DataPortal.Fetch<ChiTietChungTuNganHangList>(new FilterCriteria(maChungTu));
        }

        public static ChiTietChungTuNganHangList GetChiTietChungTuNganHangList_ByDeNghiChuyenKhoan(long maDeNghi)
        {
            return DataPortal.Fetch<ChiTietChungTuNganHangList>(new FilterCriteria_ByDeNghi(maDeNghi));
        }

        private ChiTietChungTuNganHangList()
        {
            MarkAsChild();
        }

        private ChiTietChungTuNganHangList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaChungTu;

            public FilterCriteria(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }

        private class FilterCriteria_ByDeNghi
        {
            public long _maDeNghi;

            public FilterCriteria_ByDeNghi(long maDeNghi)
            {
                this._maDeNghi = maDeNghi;
            }
        }
        #endregion //Filter Criteria

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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblChiTietChungTuNganHangsByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteria_ByDeNghi)
                {
                    cm.CommandText = "spd_SelecttblChiTietChungTuNganHangsByMaDeNghi";
                    cm.Parameters.AddWithValue("@MaDeNghi", ((FilterCriteria_ByDeNghi)criteria)._maDeNghi);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietChungTuNganHang.GetChiTietChungTuNganHang(dr));
                }

            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiTietChungTuNganHang.GetChiTietChungTuNganHang(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTuNganHang parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietChungTuNganHang deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietChungTuNganHang child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }

        public void DataPortal_Delete(SqlTransaction tr)
        {
            foreach (ChiTietChungTuNganHang child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}
