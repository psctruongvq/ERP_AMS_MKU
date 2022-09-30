using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class DeNghiThanhToanList : Csla.BusinessListBase<DeNghiThanhToanList, DeNghiThanhToan>
    {
        internal string _MaPhanHe = "";
        #region BindingList Overrides
        private long iddef = -1;
        protected override object AddNewCore()
        {
            DeNghiThanhToan item = DeNghiThanhToan.NewDeNghiThanhToanChild();
            item._maPhieu = iddef--;
            item.MaPhanHe = _MaPhanHe;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private DeNghiThanhToanList()
        { /* require use of factory method */ }

        public static DeNghiThanhToanList NewDeNghiThanhToanList(string MaPhanHe)
        {
            DeNghiThanhToanList item = new DeNghiThanhToanList();
            item._MaPhanHe = MaPhanHe;
            return item;
        }

        public static DeNghiThanhToanList GetDeNghiThanhToanList(DateTime TuNgay, DateTime DenNgay, string MaPhanHe)
        {
            return DataPortal.Fetch<DeNghiThanhToanList>(new FilterCriteria(TuNgay, DenNgay, MaPhanHe));
        }
        public static DeNghiThanhToanList GetDeNghiThanhToanAllList(int maUserID,int loai)
        {
            return DataPortal.Fetch<DeNghiThanhToanList>(new FilterCriteriaAll(maUserID,loai));
        }
        public static DeNghiThanhToanList GetDeNghiThanhToanByChungTu(long SoChungTu)
        {
            return DataPortal.Fetch<DeNghiThanhToanList>(new FilterCriteriaByChungTu(SoChungTu));
        }
        
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay, DenNgay;
            public string MaPhanHe;
            public FilterCriteria(DateTime tuNgay, DateTime denNgay, string maPhanHe)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
                MaPhanHe = maPhanHe;
            }
        }
        private class FilterCriteriaAll
        {
           public int MaUserID;
            public int Loai;
            public FilterCriteriaAll(int maUserID,int loai)
            {
                this.MaUserID = maUserID;
                this.Loai = loai;
                
            }
        }
        private class FilterCriteriaByChungTu
        {
            public long SoChungTu;
            public FilterCriteriaByChungTu(long soChungTu)
            {
                SoChungTu = soChungTu;
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
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_DeNghiThanhToanList";
                    cm.Parameters.AddWithValue("@TuNgay",((FilterCriteria)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay",((FilterCriteria)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaPhanHe", ((FilterCriteria)criteria).MaPhanHe);
                    if (ERP_Library.Security.CurrentUser.IsAdminNhanSu)
                        cm.Parameters.AddWithValue("@UserID", 0);
                    else
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiThanhToan.GetDeNghiThanhToan(dr));
                    }
                    _MaPhanHe = ((FilterCriteria)criteria).MaPhanHe;
                }//using
            }
            else if (criteria is FilterCriteriaAll)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_DeNghiThanhToanAllList";
                    cm.Parameters.AddWithValue("@MaUserID", ((FilterCriteriaAll)criteria).MaUserID);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaAll)criteria).Loai);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiThanhToan.GetDeNghiThanhToan(dr));
                    }
                }//using
                
            }
            else if (criteria is FilterCriteriaByChungTu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_DeNghiThanhToanAllListByChungTu";
                    cm.Parameters.AddWithValue("@SoChungTu", ((FilterCriteriaByChungTu)criteria).SoChungTu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiThanhToan.GetDeNghiThanhToan(dr));
                    }
                }//using
                //
              
            }
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
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
                    foreach (DeNghiThanhToan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DeNghiThanhToan child in this)
                    {
                        if (child.IsNew)
                        {
                            child.Insert(tr);
                            foreach (DeNghiThanhToan_ChungTu item in child.ChungTu)
                            {
                                item.MaPhieu = child.MaPhieu;
                            }
                        }
                        else
                            child.Update(tr);
                    }
                    tr.Commit();

                    foreach (DeNghiThanhToan item in this)
                    {
                        foreach (DeNghiThanhToan_ChungTu child in item.ChungTu)
                        {
                            child.MaPhieu = item.MaPhieu;                            
                        }
                        item.ChungTu.ApplyEdit();
                        item.ChungTu.Save();
                    }

                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        // them
        public void DataPortal_Update(SqlTransaction tr)
        {
            RaiseListChangedEvents = false;
            try
            {
                foreach (DeNghiThanhToan child in this)
                {
                    if (!child.IsNew)
                        child.Update(tr);   
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
