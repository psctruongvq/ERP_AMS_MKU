
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_HoaDonCCDCList : Csla.BusinessListBase<ChungTu_HoaDonCCDCList, ChungTu_HoaDonCCDC>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_HoaDonCCDC item = ChungTu_HoaDonCCDC.NewChungTu_HoaDon();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private ChungTu_HoaDonCCDCList()
        { /* require use of factory method */ }

        public static ChungTu_HoaDonCCDCList NewChungTu_HoaDonList()
        {
            return new ChungTu_HoaDonCCDCList();
        }
        public static ChungTu_HoaDonCCDCList GetChungTu_HoaDonList(long mabuttoan)
        {
            return DataPortal.Fetch<ChungTu_HoaDonCCDCList>(new FilterCriteriaByMaChungTu(mabuttoan));
        }
        public static ChungTu_HoaDonCCDCList GetChungTu_HoaDonByMaHoaDonList(long maHoaDon)
        {
            return DataPortal.Fetch<ChungTu_HoaDonCCDCList>(new FilterCriteriaByHoaDon(maHoaDon));
        }
        public static ChungTu_HoaDonCCDCList GetChungTu_HoaDonListByMaChungTu_HoaDon(long mabuttoan, long maHoaDon)
        {
            return DataPortal.Fetch<ChungTu_HoaDonCCDCList>(new FilterCriteria(mabuttoan, maHoaDon));
        }
        public static ChungTu_HoaDonCCDCList GetChungTu_HoaDonListByMaBuToan(long mabuttoan)
        {
            return DataPortal.Fetch<ChungTu_HoaDonCCDCList>(new FilterCriteriaByMaButToan(mabuttoan));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaByMaChungTu
        {
            public long mabuttoan;

            public FilterCriteriaByMaChungTu(long mabuttoan)
            {
                this.mabuttoan = mabuttoan;

            }
        }
        private class FilterCriteria
        {
            public long mabuttoan;
            public long MaHoaDon;

            public FilterCriteria(long mabuttoan, long maHoaDon)
            {
                this.mabuttoan = mabuttoan;
                this.MaHoaDon = maHoaDon;
            }
        }

        private class FilterCriteriaByHoaDon
        {            
            public long MaHoaDon;

            public FilterCriteriaByHoaDon(long maHoaDon)
            {                
                this.MaHoaDon = maHoaDon;
            }
        }

        private class FilterCriteriaByMaButToan
        {
            public long MaButToan;

            public FilterCriteriaByMaButToan(long maButToan)
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
                cm.CommandTimeout = 0;
                if (criteria is FilterCriteriaByMaChungTu)
                {
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonsChungTu";
                    cm.Parameters.AddWithValue("@maButToan", ((FilterCriteriaByMaChungTu)criteria).mabuttoan);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonsByMaHoaDon";
                    cm.Parameters.AddWithValue("@maButToan", ((FilterCriteria)criteria).mabuttoan);
                    cm.Parameters.AddWithValue("@MaHoaDon", ((FilterCriteria)criteria).MaHoaDon);
                }
                else if (criteria is FilterCriteriaByHoaDon)
                {
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonsByHoaDon";                    
                    cm.Parameters.AddWithValue("@MaHoaDon", ((FilterCriteriaByHoaDon)criteria).MaHoaDon);
                }
                else if (criteria is FilterCriteriaByMaButToan)
                {
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonsByMaButToan";
                    cm.Parameters.AddWithValue("@MaButToan", ((FilterCriteriaByMaButToan)criteria).MaButToan);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTu_HoaDonCCDC.GetChungTu_HoaDon(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch

        internal void Update(SqlTransaction tr, ButToanPhieuNhapXuatCCDC parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                foreach (ChungTu_HoaDonCCDC deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDonCCDC child in this)
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

        #region Data Access - Update
        /// <summary>
        /// Lưu trực tiếp từ ChungTu_HoaDonList
        /// </summary>
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;
            try
            {


                foreach (ChungTu_HoaDonCCDC deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon( deletedChild.MaChungTu, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDonCCDC child in this)
                {
                    if (child.IsNew)                       
                        child.EditChungTu_HoaDon(child.MaChungTu, 0, 1);
                    else                      
                        child.EditChungTu_HoaDon(child.MaChungTu, 0,  2);
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }


            RaiseListChangedEvents = true;
        }


        public void _Update()
        {
            RaiseListChangedEvents = false;
            try
            {
                foreach (ChungTu_HoaDonCCDC deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon(deletedChild.MaChungTu, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDonCCDC child in this)
                {
                    if (child.IsNew)
                        child.EditChungTu_HoaDon(child.MaChungTu, 0, 1);
                    else
                        child.EditChungTu_HoaDon(child.MaChungTu, 0, 2);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            RaiseListChangedEvents = true;
        }
        /// <summary>
        /// Lưu từ class ChungTu->ChungTu_HoaDon
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="MaChungTu"></param>
        /// <param name="maHoaDon"></param>
        public void DataPortal_Update(SqlTransaction tr, ButToan parent, long maHoaDon)
        {
            RaiseListChangedEvents = false;
            try
            {
                foreach (ChungTu_HoaDonCCDC deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDonCCDC child in this)
                {
                    if (child.IsNew)
                        child.EditChungTu_HoaDon(tr, parent.MaButToan, maHoaDon, 1);
                    else
                        child.EditChungTu_HoaDon(tr, parent.MaButToan, maHoaDon, 2);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            RaiseListChangedEvents = true;
        }


        public void DataPortal_Update(SqlTransaction tr, ButToanPhieuNhapXuatCCDC parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                foreach (ChungTu_HoaDonCCDC deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDonCCDC child in this)
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

        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
