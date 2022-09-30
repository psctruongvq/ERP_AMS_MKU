
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_ChiPhiSanXuatList : Csla.BusinessListBase<ChungTu_ChiPhiSanXuatList, ChungTu_ChiPhiSanXuat>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_ChiPhiSanXuat item = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private ChungTu_ChiPhiSanXuatList()
        { /* require use of factory method */
        }

        public static ChungTu_ChiPhiSanXuatList NewChungTu_ChiPhiSanXuatList()
        {
            return new ChungTu_ChiPhiSanXuatList();
        }

        public static ChungTu_ChiPhiSanXuatList GetChungTu_ChiPhiSanXuatList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_ChiPhiSanXuatList>(new FilterCriteria(maChungTu));
        }
        public static ChungTu_ChiPhiSanXuatList GetChungTu_ChiPhiSanXuatByButToanList(int maButToan)
        {
            return DataPortal.Fetch<ChungTu_ChiPhiSanXuatList>(new FilterCriteriaByButToan(maButToan));
        }

        public static ChungTu_ChiPhiSanXuatList GetChungTu_ChiPhiSanXuatByButToanListByKetChuyen()
        {
            return DataPortal.Fetch<ChungTu_ChiPhiSanXuatList>(new FilterCriteriaByButToanByKetChuyen());
        }

        public static ChungTu_ChiPhiSanXuatList GetChungTu_ChiPhiSanXuatByButToanListByKetChuyen_New()
        {
            return DataPortal.Fetch<ChungTu_ChiPhiSanXuatList>(new FilterCriteriaByButToanByKetChuyen_New());
        }
        /// <summary>
        /// Phuong thuc tam thoi, duoc su dung 1 lan
        /// </summary>
        /// <returns></returns>
        public static ChungTu_ChiPhiSanXuatList GetChungTu_ChiPhiSanXuatUpdateDataTemp()
        {
            return DataPortal.Fetch<ChungTu_ChiPhiSanXuatList>(new FilterCriteriaByTemp());
        }
        #endregion //Factory Methods

        #region Data Access

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
        private class FilterCriteriaByTemp
        {
            public FilterCriteriaByTemp()
            {

            }
        }
        private class FilterCriteriaByButToan
        {
            public int MaButToan;

            public FilterCriteriaByButToan(int maButToan)
            {
                this.MaButToan = maButToan;
            }
        }

        private class FilterCriteriaByButToanByKetChuyen
        {

            public FilterCriteriaByButToanByKetChuyen()
            {
            }
        }

        private class FilterCriteriaByButToanByKetChuyen_New
        {

            public FilterCriteriaByButToanByKetChuyen_New()
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
                cm.CommandTimeout = 90;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "SelecttblCT_ChiPhiSanXuatByChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria)criteria).MaChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_ChiPhiSanXuat.GetChungTu_ChiPhiSanXuat(dr));
                    }
                }
                else if (criteria is FilterCriteriaByButToan)
                {
                    cm.CommandText = "SelecttblCT_ChiPhiSanXuatByButToan";
                    cm.Parameters.AddWithValue("@MaButToan", ((FilterCriteriaByButToan)criteria).MaButToan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_ChiPhiSanXuat.GetChungTu_ChiPhiSanXuat(dr));
                    }
                }

                else if (criteria is FilterCriteriaByButToanByKetChuyen)
                {
                    cm.CommandText = "Spd_SelecttblCT_ChiPhiSanXuatByKetChuyen";
                     using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_ChiPhiSanXuat.GetChungTu_ChiPhiSanXuat(dr));
                    }
                }

                else if (criteria is FilterCriteriaByButToanByKetChuyen_New)
                {
                    cm.CommandText = "Spd_SelecttblCT_ChiPhiSanXuatByKetChuyen_New";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_ChiPhiSanXuat.GetChungTu_ChiPhiSanXuat(dr));
                    }
                }
           
                else if (criteria is FilterCriteriaByTemp)
                {
                    cm.CommandText = "Spd_SelectChiPhi_ButToan_UpdateData";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_ChiPhiSanXuat.GetChungTu_ChiPhiSanXuatUpdateDataTemp(dr));
                    }

                }

            }//using
        }
        #endregion //Data Access - Fetch


        public void DataPortal_Update(SqlTransaction tr, long MaChungTu, string soChungTu, int maButToan)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ChungTu_ChiPhiSanXuat deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChungTu_ChiPhiSanXuat child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, MaChungTu, soChungTu, maButToan);
                    else
                        child.Update(tr, MaChungTu, soChungTu, maButToan);
                }
            }

            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }


            RaiseListChangedEvents = true;
        }
        /*
        /// <summary>
        /// Phương thức sử dụng trường hợp ButToan-ChiPhiSanXuat
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="maButToan"></param>
        /// 
      
        public void DataPortal_Update(SqlTransaction tr,int maButToan)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ChungTu_ChiPhiSanXuat deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChungTu_ChiPhiSanXuat child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, MaChungTu, soChungTu);
                    else
                        child.Update(tr, MaChungTu, soChungTu);
                }
            }

            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }


            RaiseListChangedEvents = true;
        }*/
        protected override void DataPortal_Update()
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
                    foreach (ChungTu_ChiPhiSanXuat deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTu_ChiPhiSanXuat child in this)
                    {
                        if (child.IsNew)
                            child.ExecuteInsertDataTemp(tr);
                        else
                            child.ExecuteUpdateTemp(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                    //tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        public void DataPortal_Delete(SqlTransaction tr)
        {

            // loop through each deleted child object
            foreach (ChungTu_ChiPhiSanXuat child in this)
            {
                child.DeleteSelf(tr);
            }

        }
        #endregion //Data Access
    }
}
