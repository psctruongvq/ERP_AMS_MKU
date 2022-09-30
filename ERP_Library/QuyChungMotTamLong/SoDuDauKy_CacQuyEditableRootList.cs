
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKy_CacQuyList : Csla.BusinessListBase<SoDuDauKy_CacQuyList, SoDuDauKy_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            SoDuDauKy_CacQuy item = SoDuDauKy_CacQuy.NewSoDuDauKy_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKy_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_CacQuyListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKy_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_CacQuyListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKy_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_CacQuyListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKy_CacQuyList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_CacQuyListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKy_CacQuyList()
        { /* require use of factory method */ }

        public static SoDuDauKy_CacQuyList NewSoDuDauKy_CacQuyList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKy_CacQuyList");
            return new SoDuDauKy_CacQuyList();
        }

        public static SoDuDauKy_CacQuyList GetSoDuDauKy_CacQuyList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKy_CacQuyList");
            return DataPortal.Fetch<SoDuDauKy_CacQuyList>(new FilterCriteria());
        }

        public static SoDuDauKy_CacQuyList GetSoDuDauKy_CacQuyList(int MaKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKy_CacQuyList");
            return DataPortal.Fetch<SoDuDauKy_CacQuyList>(new FilterCriteria_ByKy(MaKy));
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

        private class FilterCriteria_ByKy
        {

            public int _maKy = 0;
            public FilterCriteria_ByKy(int MaKy)
            {
                this._maKy = MaKy;
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
            bool bIsOld = false;
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblSoDuDauKy_CacQuiesAll";
                }
                else if (criteria is FilterCriteria_ByKy)
                {
                    int iValue = KiemTraKyKetChuyen(((FilterCriteria_ByKy)criteria)._maKy);
                    if (iValue > 0)
                    {
                        bIsOld = true;
                    }

                    cm.CommandText = "spd_SelecttblSoDuDauKy_CacQuy_ByMaKy";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteria_ByKy)criteria)._maKy);
                    cm.Parameters.AddWithValue("@IsOld", bIsOld);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(SoDuDauKy_CacQuy.GetSoDuDauKy_CacQuy(dr, bIsOld));
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
                    foreach (SoDuDauKy_CacQuy deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (SoDuDauKy_CacQuy child in this)
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

        #region KiemTraKyKetChuyen
        public int KiemTraKyKetChuyen(int MaKy)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoDuTaiKhoan_CacQuy";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);

                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }
        #endregion 
    }
}
