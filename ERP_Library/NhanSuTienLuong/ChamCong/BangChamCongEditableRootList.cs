
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BangChamCong_NewList : Csla.BusinessListBase<BangChamCong_NewList, BangChamCong_New>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangChamCong_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangChamCong_NewListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangChamCong_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangChamCong_NewListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangChamCong_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangChamCong_NewListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangChamCong_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangChamCong_NewListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangChamCong_NewList()
        { /* require use of factory method */ }

        public static BangChamCong_NewList NewBangChamCong_NewList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangChamCong_NewList");
            return new BangChamCong_NewList();
        }

        public static BangChamCong_NewList GetBangChamCong_NewList(int maBoPhan, int thang, int nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangChamCong_NewList");
            return DataPortal.Fetch<BangChamCong_NewList>(new FilterCriteria(maBoPhan, thang, nam));
        }

        public static BangChamCong_NewList GetBangChamCongTamThoi_NewList(int maBoPhan, int thang, int nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangChamCong_NewList");
            return DataPortal.Fetch<BangChamCong_NewList>(new FilterCriteria_TamThoi(maBoPhan, thang, nam));
        }

        public static BangChamCong_NewList GetBangChamCong_NewList_ByDaDuyet(int maBoPhan, int thang, int nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangChamCong_NewList");
            return DataPortal.Fetch<BangChamCong_NewList>(new FilterCriteria_DaDuyet(maBoPhan, thang, nam));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaBoPhan;
            public int Thang;
            public int Nam;
            public FilterCriteria(int maBoPhan, int thang, int nam)
            {
                this.MaBoPhan = maBoPhan;
                this.Thang = thang;
                this.Nam = nam;
            }
        }

        private class FilterCriteria_TamThoi
        {
            public int MaBoPhan;
            public int Thang;
            public int Nam;
            public FilterCriteria_TamThoi(int maBoPhan, int thang, int nam)
            {
                this.MaBoPhan = maBoPhan;
                this.Thang = thang;
                this.Nam = nam;
            }
        }

        private class FilterCriteria_DaDuyet
        {
            public int MaBoPhan;
            public int Thang;
            public int Nam;
            public FilterCriteria_DaDuyet(int maBoPhan, int thang, int nam)
            {
                this.MaBoPhan = maBoPhan;
                this.Thang = thang;
                this.Nam = nam;
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
                    cm.CommandText = "spd_BangChamCongNhanVien";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@Thang", ((FilterCriteria)criteria).Thang);
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteria)criteria).Nam);
                }
                else if (criteria is FilterCriteria_TamThoi)
                {
                    cm.CommandText = "spd_BangChamCongNhanVienTamThoi";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_TamThoi)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@Thang", ((FilterCriteria_TamThoi)criteria).Thang);
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteria_TamThoi)criteria).Nam);
                }
                else
                {
                    cm.CommandText = "spd_SelecttblBangCongDuocDuyet";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_DaDuyet)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@Thang", ((FilterCriteria_DaDuyet)criteria).Thang);
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteria_DaDuyet)criteria).Nam);
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangChamCong_New.GetBangChamCong_New(dr));
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
                    foreach (BangChamCong_New deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BangChamCong_New child in this)
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

        public static void DuyetBangCong(int maBoPhan, int thang, int nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DuyetBangChamCong";
                        cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                        cm.Parameters.AddWithValue("@Thang", thang);
                        cm.Parameters.AddWithValue("@Nam", nam);
                        cm.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public static void XoaDuyetBangCong(int maBoPhan, int thang, int nam)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_XoaDuyetBangCong";
                        cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                        cm.Parameters.AddWithValue("@Thang", thang);
                        cm.Parameters.AddWithValue("@Nam", nam);
                        cm.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
        }

        public static bool KiemTraBangCongDuyet(int maBoPhan, int thang, int nam)
        {
            int record = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                
                SqlTransaction tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraDuyetBangCong";
                        cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                        cm.Parameters.AddWithValue("@Thang", thang);
                        cm.Parameters.AddWithValue("@Nam", nam);
                        record = Convert.ToInt32(cm.ExecuteScalar());
                    }
                    tr.Commit();  
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }

            if (record != 0)
                return true;
            return false;
        }

        #endregion //Data Access
    }
}
