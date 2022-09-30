
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class TaiTroList : Csla.BusinessListBase<TaiTroList, TaiTro>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            TaiTro item = TaiTro.NewTaiTro();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TaiTroList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiTroListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TaiTroList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiTroListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TaiTroList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiTroListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TaiTroList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiTroListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TaiTroList()
        { /* require use of factory method */ }

        public static TaiTroList NewTaiTroList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TaiTroList");
            return new TaiTroList();
        }

        public static TaiTroList GetTaiTroList(DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TaiTroList");
            return DataPortal.Fetch<TaiTroList>(new FilterCriteria_ByNgayLap(TuNgay, DenNgay));
        }

        public static TaiTroList GetTaiTroList(long MaDoiTuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TaiTroList");
            return DataPortal.Fetch<TaiTroList>(new FilterCriteria_ByDoiTuong(MaDoiTuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public FilterCriteria()
            {

            }
        }

        private class FilterCriteria_ByNgayLap
        {
            public DateTime _TuNgay;
            public DateTime _DenNgay;
            public FilterCriteria_ByNgayLap(DateTime TuNgay, DateTime DenNgay)
            {
                this._TuNgay = TuNgay;
                this._DenNgay = DenNgay;
            }
        }

        private class FilterCriteria_ByDoiTuong
        {
            public long _MaDoiTuong = 0;
            public FilterCriteria_ByDoiTuong(long MaDoiTuong)
            {
                this._MaDoiTuong = MaDoiTuong;
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
                    cm.CommandText = "spd_SelecttblTaiTrosAll";
                }
                else if (criteria is FilterCriteria_ByNgayLap)
                {
                    cm.CommandText = "spd_SelecttblTaiTro_ByNgayLap";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgayLap)criteria)._TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgayLap)criteria)._DenNgay);
                    //Có truyền UserID xuống nhưng không lấy theo UserID vì không biết thế nào. Cần thì bổ sung thêm
                    cm.Parameters.AddWithValue("@userID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteria_ByDoiTuong)
                {
                    cm.CommandText = "spd_SelecttblTaiTro_ByDoiTuong";
                    cm.Parameters.AddWithValue("@MaDoiTuong", ((FilterCriteria_ByDoiTuong)criteria)._MaDoiTuong);
                    //Có truyền UserID xuống nhưng không lấy theo UserID vì không biết thế nào. Cần thì bổ sung thêm
                    cm.Parameters.AddWithValue("@userID", Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TaiTro.GetTaiTro(dr));
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
                    foreach (TaiTro deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (TaiTro child in this)
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
        #endregion //Data Access
    }
}
