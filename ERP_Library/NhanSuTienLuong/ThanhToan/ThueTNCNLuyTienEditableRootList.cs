
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThueTNCNLuyTienList : Csla.BusinessListBase<ThueTNCNLuyTienList, ThueTNCNLuyTien>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ThueTNCNLuyTien item = ThueTNCNLuyTien.NewThueTNCNLuyTien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThueTNCNLuyTienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNLuyTienListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThueTNCNLuyTienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNLuyTienListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThueTNCNLuyTienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNLuyTienListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThueTNCNLuyTienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThueTNCNLuyTienListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThueTNCNLuyTienList()
        { /* require use of factory method */ }

        public static ThueTNCNLuyTienList NewThueTNCNLuyTienList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThueTNCNLuyTienList");
            return new ThueTNCNLuyTienList();
        }

        public static ThueTNCNLuyTienList GetThueTNCNLuyTienList(DateTime denNgay, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThueTNCNLuyTienList");
            return DataPortal.Fetch<ThueTNCNLuyTienList>(new FilterCriteria_TongHopNopThue(denNgay, maBoPhan));
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

        private class FilterCriteria_TongHopNopThue
        {
            public DateTime _denNgay;
            public int _maBoPhan;
            public FilterCriteria_TongHopNopThue(DateTime denNgay, int maBoPhan)
            {
                this._denNgay = denNgay;
                this._maBoPhan = maBoPhan;
            }
        }

        private class FilterCriteria_ChiTietNopThue
        {
            public DateTime _tuNgay;
            public DateTime _denNgay;
            public int _maBoPhan;
            public FilterCriteria_ChiTietNopThue(DateTime tuNgay,DateTime denNgay, int maBoPhan)
            {
                this._tuNgay = tuNgay;
                this._denNgay = denNgay;
                this._maBoPhan = maBoPhan;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblThueTNCNLuyTienList";
                }
                else if (criteria is FilterCriteria_TongHopNopThue)
                {
                    cm.CommandText = "spd_DanhSachTongHopThueTNCN";
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_TongHopNopThue)criteria)._denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_TongHopNopThue)criteria)._maBoPhan);
                    cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThueTNCNLuyTien.GetThueTNCNLuyTien(dr));
                    }
                }
                else if (criteria is FilterCriteria_ChiTietNopThue)
                {
                    cm.CommandText = "spd_DanhSachChiTietThueTNCN";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ChiTietNopThue)criteria)._tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ChiTietNopThue)criteria)._denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_ChiTietNopThue)criteria)._maBoPhan);
                    cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThueTNCNLuyTien.GetThueTNCNLuyTien_NgoaiDoan(dr));
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
                    foreach (ThueTNCNLuyTien deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThueTNCNLuyTien child in this)
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
