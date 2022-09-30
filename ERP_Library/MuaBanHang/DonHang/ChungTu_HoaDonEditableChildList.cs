
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_HoaDonList : Csla.BusinessListBase<ChungTu_HoaDonList, ChungTu_HoaDon>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_HoaDon item = ChungTu_HoaDon.NewChungTu_HoaDon();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private ChungTu_HoaDonList()
        {
            MarkAsChild();
            /* require use of factory method */
        }

        public static ChungTu_HoaDonList NewChungTu_HoaDonList()
        {
            return new ChungTu_HoaDonList();
        }
        public static ChungTu_HoaDonList GetChungTu_HoaDonList(long mabuttoan)
        {
            return DataPortal.Fetch<ChungTu_HoaDonList>(new FilterCriteriaByMaChungTu(mabuttoan));
        }
        public static ChungTu_HoaDonList GetChungTu_HoaDonByMaHoaDonList(long maHoaDon)
        {
            return DataPortal.Fetch<ChungTu_HoaDonList>(new FilterCriteriaByHoaDon(maHoaDon));
        }
        public static ChungTu_HoaDonList GetChungTu_HoaDonListByMaChungTu_HoaDon(long mabuttoan, long maHoaDon)
        {
            return DataPortal.Fetch<ChungTu_HoaDonList>(new FilterCriteria(mabuttoan, maHoaDon));
        }
        public static ChungTu_HoaDonList GetChungTu_HoaDonListByMaBuToan(long mabuttoan)
        {
            return DataPortal.Fetch<ChungTu_HoaDonList>(new FilterCriteriaByMaButToan(mabuttoan));
        }
        public static ChungTu_HoaDonList GetChungTu_HoaDonListByChungTuDev(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_HoaDonList>(new FilterCriteriaByChungTuDev(maChungTu));
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
        private class FilterCriteriaByChungTuDev
        {
            public long MaChungTu;

            public FilterCriteriaByChungTuDev(long maChungTu)
            {
                this.MaChungTu = maChungTu;
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
                bool fromHoaDon = false;
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
                    fromHoaDon = true;
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonsByHoaDon";                    
                    cm.Parameters.AddWithValue("@MaHoaDon", ((FilterCriteriaByHoaDon)criteria).MaHoaDon);
                }
                else if (criteria is FilterCriteriaByMaButToan)
                {
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonsByMaButToan";
                    cm.Parameters.AddWithValue("@MaButToan", ((FilterCriteriaByMaButToan)criteria).MaButToan);
                }
                else if (criteria is FilterCriteriaByChungTuDev)
                {
                    cm.CommandText = "spd_SelecttblChungTu_HoaDonsByChungTuDev";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTuDev)criteria).MaChungTu);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (fromHoaDon)
                    {
                        while (dr.Read())
                            this.Add(ChungTu_HoaDon.GetChungTu_HoaDonByHoaDon(dr));
                    }
                    else
                    {
                        while (dr.Read())
                            this.Add(ChungTu_HoaDon.GetChungTu_HoaDon(dr));
                    }
                }
            }//using
        }
        #endregion //Data Access - Fetch

        #region Update Parent: ButToanPhieuNhapXuat
        internal void Update(SqlTransaction tr, ButToanPhieuNhapXuat parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                foreach (ChungTu_HoaDon deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDon child in this)
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
        #endregion// Update Parent: ButToanPhieuNhapXuat

        #region Update Parent: ButToan
        internal void Update(SqlTransaction tr, ButToan parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                foreach (ChungTu_HoaDon deletedChild in DeletedList)
                    //deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();
                foreach (ChungTu_HoaDon child in this)
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
        #endregion// Update Parent: ButToan

        #region Update Parent: HoaDon
        internal void Update(SqlTransaction tr, HoaDon parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                foreach (ChungTu_HoaDon deletedChild in DeletedList)
                    //deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();
                foreach (ChungTu_HoaDon child in this)
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

        #region Data Access - Update
        /// <summary>
        /// Lưu trực tiếp từ ChungTu_HoaDonList
        /// </summary>
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;
            try
            {
               
                
                foreach (ChungTu_HoaDon deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon( deletedChild.MaChungTu, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDon child in this)
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
                foreach (ChungTu_HoaDon deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon(deletedChild.MaChungTu, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDon child in this)
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
                foreach (ChungTu_HoaDon deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();                
                foreach (ChungTu_HoaDon child in this)
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


        public void DataPortal_Update(SqlTransaction tr, ButToanPhieuNhapXuat parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                foreach (ChungTu_HoaDon deletedChild in DeletedList)
                    deletedChild.EditChungTu_HoaDon(tr, deletedChild.MaButToan, deletedChild.MaHoaDon, 3);
                DeletedList.Clear();
                foreach (ChungTu_HoaDon child in this)
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
