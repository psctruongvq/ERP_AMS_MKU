
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class DeNghiThuList : Csla.BusinessListBase<DeNghiThuList, DeNghiThu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DeNghiThu item = DeNghiThu.NewDeNghiThu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeNghiThuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThuListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeNghiThuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThuListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeNghiThuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThuListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeNghiThuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiThuListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DeNghiThuList()
        { /* require use of factory method */ }

        public static DeNghiThuList NewDeNghiThuList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiThuList");
            return new DeNghiThuList();
        }

        public static DeNghiThuList GetDeNghiThuList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiThuList");
            return DataPortal.Fetch<DeNghiThuList>(new FilterCriteria());
        }
        public static DeNghiThuList GetDeNghiThuListByChungTu(long MaChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiThuList");
            return DataPortal.Fetch<DeNghiThuList>(new FilterCriteriaByChungTu(MaChungTu));
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
        private class FilterCriteriaByChungTu
        {
            public long MaChungTu;
            public FilterCriteriaByChungTu(long machungtu)
            {
                MaChungTu = machungtu;
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
                    cm.CommandText = "sp_SelecttblDeNghiThusAll";

                }
                else if (criteria is FilterCriteriaByChungTu)
                {
                    cm.CommandText = "sp_SelecttblDeNghiThusAllByChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTu)criteria).MaChungTu);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DeNghiThu.GetDeNghiThu(dr));
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
                    foreach (DeNghiThu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DeNghiThu child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
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
        public void DataPortal_Update(SqlTransaction tr)
        {
            RaiseListChangedEvents = false;
            try
            {
                foreach (DeNghiThu child in this)
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
