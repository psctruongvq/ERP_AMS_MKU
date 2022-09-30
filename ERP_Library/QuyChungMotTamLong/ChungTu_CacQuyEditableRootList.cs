
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_CacLoaiQuyList : Csla.BusinessListBase<ChungTu_CacLoaiQuyList, ChungTu_CacLoaiQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_CacLoaiQuy item = ChungTu_CacLoaiQuy.NewChungTu_CacLoaiQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTu_CacLoaiQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_CacLoaiQuyListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTu_CacLoaiQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_CacLoaiQuyListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTu_CacLoaiQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_CacLoaiQuyListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTu_CacLoaiQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTu_CacLoaiQuyListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTu_CacLoaiQuyList()
        { /* require use of factory method */ }

        public static ChungTu_CacLoaiQuyList NewChungTu_CacLoaiQuyList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTu_CacLoaiQuyList");
            return new ChungTu_CacLoaiQuyList();
        }

        public static ChungTu_CacLoaiQuyList GetChungTu_CacLoaiQuyList(int maLoaiQuy, int maLoaiChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_CacLoaiQuyList");
            return DataPortal.Fetch<ChungTu_CacLoaiQuyList>(new FilterCriteria(maLoaiQuy, maLoaiChungTu));
        }

        public static ChungTu_CacLoaiQuyList GetChungTu_CacLoaiQuyList(DateTime tuNgay, DateTime denNgay, int maLoaiChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_CacLoaiQuyList");
            return DataPortal.Fetch<ChungTu_CacLoaiQuyList>(new FilterCriteria_ByNgay(tuNgay, denNgay, maLoaiChungTu));
        }

        public static ChungTu_CacLoaiQuyList GetChungTu_CacLoaiQuyList_ThuChi(DateTime tuNgay, DateTime denNgay, int maLoaiChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_CacLoaiQuyList");
            return DataPortal.Fetch<ChungTu_CacLoaiQuyList>(new FilterCriteria_ThuChi(tuNgay, denNgay, maLoaiChungTu));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaLoaiQuy;
            public int MaLoaiChungTu;

            public FilterCriteria(int maLoaiQuy, int maLoaiChungTu)
            {
                this.MaLoaiQuy = maLoaiQuy;
                this.MaLoaiChungTu = maLoaiChungTu;
            }
        }

        private class FilterCriteria_ByNgay
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaLoaiChungTu;

            public FilterCriteria_ByNgay(DateTime tuNgay, DateTime denNgay, int maLoaiChungTu)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaLoaiChungTu = maLoaiChungTu;
            }
        }

        private class FilterCriteria_ThuChi
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaLoaiChungTu;

            public FilterCriteria_ThuChi(DateTime tuNgay, DateTime denNgay, int maLoaiChungTu)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.MaLoaiChungTu = maLoaiChungTu;
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
                if (criteria is FilterCriteria_ThuChi)
                {
                    cm.CommandText = "spd_SelecttblChungTu_CacQuiesByThuChi";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ThuChi)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ThuChi)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", ((FilterCriteria_ThuChi)criteria).MaLoaiChungTu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy_ThuChi(dr));
                    }
                }
                else
                {
                    if (criteria is FilterCriteria)
                    {
                        cm.CommandText = "spd_SelecttblChungTu_CacQuiesByMaLoaiQuy_LoaiChungTu";
                        cm.Parameters.AddWithValue("@MaLoaiQuy", ((FilterCriteria)criteria).MaLoaiQuy);
                        cm.Parameters.AddWithValue("@MaLoaiChungTu", ((FilterCriteria)criteria).MaLoaiChungTu);
                    }
                    else if (criteria is FilterCriteria_ByNgay)
                    {
                        cm.CommandText = "spd_SelecttblChungTu_CacQuiesByNgaylap";
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgay)criteria).TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgay)criteria).DenNgay);
                        cm.Parameters.AddWithValue("@MaLoaiChungTu", ((FilterCriteria_ByNgay)criteria).MaLoaiChungTu);
                    }


                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_CacLoaiQuy.GetChungTu_CacLoaiQuy(dr));
                    }
                }
            }//using
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
                    foreach (ChungTu_CacLoaiQuy deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTu_CacLoaiQuy child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
                        else
                            child.Update(tr, this);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update

        #region Update Thủ Quỹ
        public void Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    foreach (ChungTu_CacLoaiQuy item in this)
                    {
                        item.Update_ThuQuy(item.MachungtuCacquy, item.NgayThuChi, item.MaNguoiThuChi, item.IsThuChi);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;

        }
        #endregion

        #endregion //Data Access
    }
}
