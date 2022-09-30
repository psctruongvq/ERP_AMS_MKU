using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class DeNghiChuyenKhoanList : Csla.BusinessListBase<DeNghiChuyenKhoanList, DeNghiChuyenKhoan>
    {
        internal string _MaPhanHe = "";
        #region BindingList Overrides
        private long iddef = -1;
        protected override object AddNewCore()
        {
            DeNghiChuyenKhoan item = DeNghiChuyenKhoan.NewDeNghiChuyenKhoanChild();
            item._maPhieu = iddef--;
            item.MaPhanHe = _MaPhanHe;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private DeNghiChuyenKhoanList()
        { /* require use of factory method */ }

        public static DeNghiChuyenKhoanList NewDeNghiChuyenKhoanList(string MaPhanHe)
        {
            DeNghiChuyenKhoanList item = new DeNghiChuyenKhoanList();
            item._MaPhanHe = MaPhanHe;
            return item;
        }

        public static DeNghiChuyenKhoanList GetDeNghiChuyenKhoanList(DateTime TuNgay, DateTime DenNgay, string MaPhanHe, bool Loai)
        {
            return DataPortal.Fetch<DeNghiChuyenKhoanList>(new FilterCriteria(TuNgay, DenNgay, MaPhanHe, Loai));
        }
        public static DeNghiChuyenKhoanList GetDeNghiChuyenKhoanAllList()
        {
            return DataPortal.Fetch<DeNghiChuyenKhoanList>(new FilterCriteriaAll());
        }
        public static DeNghiChuyenKhoanList GetDeNghiChuyenKhoanByChungTu(long SoChungTu)
        {
            return DataPortal.Fetch<DeNghiChuyenKhoanList>(new FilterCriteriaByChungTu(SoChungTu));
        }
        public static DeNghiChuyenKhoanList GetDeNghiChuyenKhoanByNgayLap(DateTime tuNgay,DateTime denNgay)
        {
            return DataPortal.Fetch<DeNghiChuyenKhoanList>(new FilterCriteriaByNgayLap(tuNgay,denNgay));
        }
        public static DeNghiChuyenKhoanList GetDeNghiChuyenKhoan_ChuaLapCT()
        {
            return DataPortal.Fetch<DeNghiChuyenKhoanList>(new FilterCriteria_ChuaLapCT());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay, DenNgay;
            public string MaPhanHe;
            public bool Loai;

            public FilterCriteria(DateTime tuNgay, DateTime denNgay, string maPhanHe, bool loai)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
                MaPhanHe = maPhanHe;
                Loai = loai;
            }
        }
        private class FilterCriteriaAll
        {

            public FilterCriteriaAll()
            {
                
            }
        }

        private class FilterCriteria_ChuaLapCT
        {
            public FilterCriteria_ChuaLapCT()
            {

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
        private class FilterCriteriaByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayLap(DateTime _tuNgay,DateTime _denNgay)
            {
                this.TuNgay = _tuNgay;
                this.DenNgay = _denNgay;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        protected override void DataPortal_Fetch(object criteria)
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
                    
                    cm.CommandText = "spd_Select_DeNghiChuyenKhoanList";
                    cm.Parameters.AddWithValue("@TuNgay",((FilterCriteria)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay",((FilterCriteria)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaPhanHe", ((FilterCriteria)criteria).MaPhanHe);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria)criteria).Loai);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(dr));
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
                        cm.CommandText = "spd_Select_DeNghiChuyenKhoanAllList";


                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(dr));
                        }
                    }//using
                
                    
            }
            else if (criteria is FilterCriteriaByChungTu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_DeNghiChuyenKhoanAllListByChungTu";
                    cm.Parameters.AddWithValue("@SoChungTu", ((FilterCriteriaByChungTu)criteria).SoChungTu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByNgayLap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_DeNghiChuyenKhoanAllListByNgayLap";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap)criteria).TuNgay.Date);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap)criteria).DenNgay.Date);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_ChuaLapCT)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;

                    cm.CommandText = "spd_Select_DeNghiChuyenKhoan_ChuaLapCT";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiChuyenKhoan.GetDeNghiChuyenKhoan_New(dr));
                    }
                }//using
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
                    foreach (DeNghiChuyenKhoan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DeNghiChuyenKhoan child in this)
                    {
                        if (child.IsNew)
                        {
                            child.Insert(tr);
                            foreach (DeNghiChuyenKhoan_ChungTu item in child.ChungTu)
                            {
                                item.MaPhieu = child.MaPhieu;
                            }
                        }
                        else
                            child.Update(tr);
                    }
                    tr.Commit();

                    foreach (DeNghiChuyenKhoan item in this)
                    {
                        foreach (DeNghiChuyenKhoan_ChungTu child in item.ChungTu)
                        {
                            child.MaPhieu = item.MaPhieu;                            
                        }
                        item.ChungTu.ApplyEdit();
                        item.ChungTu.Save();
                    }
                    //

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
                foreach (DeNghiChuyenKhoan child in this)
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
