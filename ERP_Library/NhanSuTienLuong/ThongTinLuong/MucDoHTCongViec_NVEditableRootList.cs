
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class MucDoHTCongViec_NVList : Csla.BusinessListBase<MucDoHTCongViec_NVList, MucDoHTCongViec_NV>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            MucDoHTCongViec_NV item = MucDoHTCongViec_NV.NewMucDoHTCongViec_NV();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in MucDoHTCongViec_NVList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViec_NVListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in MucDoHTCongViec_NVList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViec_NVListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in MucDoHTCongViec_NVList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViec_NVListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in MucDoHTCongViec_NVList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViec_NVListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private MucDoHTCongViec_NVList()
        { /* require use of factory method */ }

        public static MucDoHTCongViec_NVList NewMucDoHTCongViec_NVList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a MucDoHTCongViec_NVList");
            return new MucDoHTCongViec_NVList();
        }

        public static MucDoHTCongViec_NVList GetMucDoHTCongViec_NVList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a MucDoHTCongViec_NVList");
            return DataPortal.Fetch<MucDoHTCongViec_NVList>(new FilterCriteria());
        }
        public static MucDoHTCongViec_NVList GetMucDoHTCongViec_NVListbybophan(int mabophan, int makyluong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTayNghe_NVList");
            return DataPortal.Fetch<MucDoHTCongViec_NVList>(new FilterCriteriabybophan(mabophan, makyluong));
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
        private class FilterCriteriabybophan
        {
            public int mabophan;
            public int makyluong;
            public FilterCriteriabybophan(int mabophan,int makyluong)
            {
                this.mabophan = mabophan;
                this.makyluong = makyluong;
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
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
                    cm.CommandText = "spd_SelecttblnsMucDoHTCongViec_NVsAll";
                }
                else if (criteria is FilterCriteriabybophan)
                {
                    cm.CommandText = "spd_SelecttblnsMucDoHTCongViec_NVbybophan";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriabybophan)criteria).mabophan);
                    cm.Parameters.AddWithValue("@makyluong", ((FilterCriteriabybophan)criteria).makyluong);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(MucDoHTCongViec_NV.GetMucDoHTCongViec_NV(dr));
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
                    foreach (MucDoHTCongViec_NV deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (MucDoHTCongViec_NV child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update

        public static void ChuyenDuLieuTheoKy(int kyhientai, int kycanchuyen ,int mabophan)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TblnsMucdoHTCongViec_Chuyenky";
                        cm.Parameters.AddWithValue("@kyhientai", kyhientai);
                        cm.Parameters.AddWithValue("@kycanchuyen", kycanchuyen);
                        cm.Parameters.AddWithValue("@mabophan", mabophan);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }
        }

        public static void CapNhatThemVaoDanhSach(int mabophan, int mamucdo, int kyhientai)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "Spd_InserttblnsMucdoHTCongViec_NVbykyluongUpdate";
                        cm.Parameters.AddWithValue("@mabophan", mabophan);
                        cm.Parameters.AddWithValue("@mamucdo", mamucdo);
                        cm.Parameters.AddWithValue("@maky", kyhientai);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }
        }

        public static void TaoMoiDanhsach(int mabophan, int mamucdo, int kyhientai)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "Spd_InserttblnsMucdoHTCongviec_NVbykyluong";
                        cm.Parameters.AddWithValue("@mabophan", mabophan);
                        cm.Parameters.AddWithValue("@mamucdo", mamucdo);
                        cm.Parameters.AddWithValue("@maky", kyhientai);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }
        }

        public static void CapNhatVaoNhaVien(int kyhientai)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Update_tblnsMucdoHTcongviec_NVinthongtincongtyall";
                        cm.Parameters.AddWithValue("@maky", kyhientai);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }
        }               

        #endregion //Data Access
    }
}
