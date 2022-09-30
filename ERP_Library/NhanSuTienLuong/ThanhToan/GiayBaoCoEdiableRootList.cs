
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class GiayBaoCoList : Csla.BusinessListBase<GiayBaoCoList, GiayBaoCo>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            GiayBaoCo item = GiayBaoCo.NewGiayBaoCo();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayBaoCoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCoListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayBaoCoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCoListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayBaoCoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCoListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayBaoCoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCoListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayBaoCoList()
        { /* require use of factory method */ }

        public static GiayBaoCoList NewGiayBaoCoList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayBaoCoList");
            return new GiayBaoCoList();
        }

        public static GiayBaoCoList GetGiayBaoCoList(int userId, int lapBangKe, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBaoCoList");
            return DataPortal.Fetch<GiayBaoCoList>(new FilterCriteria(userId, lapBangKe, Loai));
        }

        public static GiayBaoCoList GetGiayBaoCoList(DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBaoCoList");
            return DataPortal.Fetch<GiayBaoCoList>(new FilterCriteriaByNgay(tuNgay, denNgay));
        }

        public static GiayBaoCoList GetGiayBaoCoList(DateTime tuNgay, DateTime denNgay, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBaoCoList");
            return DataPortal.Fetch<GiayBaoCoList>(new FilterCriteria_ByNgayLoai(tuNgay, denNgay, Loai));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int UserId;
            public int LapBangKe;
            public int LoaiGBC = 0;

            public FilterCriteria(int userId, int lapBangKe, int Loai)
            {
                this.UserId = userId;
                this.LapBangKe = lapBangKe;
                this.LoaiGBC = Loai;
            }
        }

        private class FilterCriteriaByNgay
        {
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterCriteriaByNgay(DateTime tuNgay, DateTime denNgay)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        private class FilterCriteria_ByNgayLoai
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int Loai = 0;

            public FilterCriteria_ByNgayLoai(DateTime tuNgay, DateTime denNgay, int Loai)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.Loai = Loai;
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
                    cm.CommandText = "spd_SelecttblGiayBaoCosAll";
                    cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@LapBangKe", ((FilterCriteria)criteria).LapBangKe);
                    cm.Parameters.AddWithValue("@LoaiGBC", ((FilterCriteria)criteria).LoaiGBC);
                }
                else if (criteria is FilterCriteria_ByNgayLoai)
                {
                    cm.CommandText = "spd_SelecttblGiayBaoCo_ByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgayLoai)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgayLoai)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@LoaiGBC", ((FilterCriteria_ByNgayLoai)criteria).Loai);
                    cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(GiayBaoCo.GetGiayBaoCo(dr));
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
                    foreach (GiayBaoCo deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (GiayBaoCo child in this)
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
