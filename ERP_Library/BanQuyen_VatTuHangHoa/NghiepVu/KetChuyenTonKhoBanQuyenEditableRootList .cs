
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KetChuyenTonKhoBanQuyenList : Csla.BusinessListBase<KetChuyenTonKhoBanQuyenList, KetChuyenTonKhoBanQuyen>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KetChuyenTonKhoBanQuyen item = KetChuyenTonKhoBanQuyen.NewKetChuyenTonKhoBanQuyen();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KetChuyenTonKhoBanQuyenList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenTonKhoBanQuyenListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KetChuyenTonKhoBanQuyenList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenTonKhoBanQuyenListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KetChuyenTonKhoBanQuyenList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenTonKhoBanQuyenListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KetChuyenTonKhoBanQuyenList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenTonKhoBanQuyenListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KetChuyenTonKhoBanQuyenList()
        { /* require use of factory method */ }

        public static KetChuyenTonKhoBanQuyenList NewKetChuyenTonKhoBanQuyenList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KetChuyenTonKhoBanQuyenList");
            return new KetChuyenTonKhoBanQuyenList();
        }

        public static KetChuyenTonKhoBanQuyenList GetKetChuyenTonKhoBanQuyenList(int maKho, int maKy, int maNguoiLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KetChuyenTonKhoBanQuyenList");
            return DataPortal.Fetch<KetChuyenTonKhoBanQuyenList>(new FilterCriteria(maKho, maKy, maNguoiLap));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKho;
            public int MaKy;
            public int MaNguoiLap;

            public FilterCriteria(int maKho, int maKy, int maNguoiLap)
            {
                this.MaKho = maKho;
                this.MaKy = maKy;
                this.MaNguoiLap = maNguoiLap;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
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

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblKetChuyenTonKhoBanQuyensAll";
                cm.Parameters.AddWithValue("@MaKho", criteria.MaKho);
                cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);
                cm.Parameters.AddWithValue("@MaNguoiLap", criteria.MaNguoiLap);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(KetChuyenTonKhoBanQuyen.GetKetChuyenTonKhoBanQuyen(dr));
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
                    foreach (KetChuyenTonKhoBanQuyen deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (KetChuyenTonKhoBanQuyen child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr,this);
                        else
                            child.Update(tr,this);
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
