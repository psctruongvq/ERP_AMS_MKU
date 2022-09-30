using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DSHoaDonDichVu_BaoCaoList : Csla.BusinessListBase<DSHoaDonDichVu_BaoCaoList, DSHoaDonDichVu_BaoCao>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DSHoaDonDichVu_BaoCaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DSHoaDonDichVu_BaoCaoListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DSHoaDonDichVu_BaoCaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DSHoaDonDichVu_BaoCaoListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DSHoaDonDichVu_BaoCaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DSHoaDonDichVu_BaoCaoListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DSHoaDonDichVu_BaoCaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DSHoaDonDichVu_BaoCaoListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DSHoaDonDichVu_BaoCaoList()
        { /* require use of factory method */ }

        public static DSHoaDonDichVu_BaoCaoList NewDSHoaDonDichVu_BaoCaoList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DSHoaDonDichVu_BaoCaoList");
            return new DSHoaDonDichVu_BaoCaoList();
        }

        public static DSHoaDonDichVu_BaoCaoList GetDSHoaDonDichVu_BaoCaoList(int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DSHoaDonDichVu_BaoCaoList");
            return DataPortal.Fetch<DSHoaDonDichVu_BaoCaoList>(new FilterCriteria(maky));
        }

        public static DSHoaDonDichVu_BaoCaoList GetReportThue01_1GTGTList(int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DSHoaDonDichVu_BaoCaoList");
            return DataPortal.Fetch<DSHoaDonDichVu_BaoCaoList>(new FilterCriteria_By1(maky));
        }

        public static DSHoaDonDichVu_BaoCaoList GetList_ChonBaoCao_HoaDonMuaVao(int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DSHoaDonDichVu_BaoCaoList");
            return DataPortal.Fetch<DSHoaDonDichVu_BaoCaoList>(new FilterCriteria_ChonBaoCao_HoaDonMuaVao(maky));
        }

        public static DSHoaDonDichVu_BaoCaoList GetList_ChonBaoCao_HoaDonMuaVao_TuKy_DenKy(int tuKy, int denKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DSHoaDonDichVu_BaoCaoList");
            return DataPortal.Fetch<DSHoaDonDichVu_BaoCaoList>(new FilterCriteria_ChonBaoCao_HoaDonMuaVao_TuKy_DenKy(tuKy,denKy));
        }

        public static void Delete_Insert_tblDSHoaDonDichVu(int maky, int loai, DSHoaDonDichVu_BaoCaoList list)
        {
            //loai = 1:hoa don mua vao; 2:hoa don dich vu
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spDelete_tblDSHoaDonDichVu";
                        cm.Parameters.AddWithValue("@MaKy", maky);
                        cm.Parameters.AddWithValue("@loai", loai);
                        cm.Parameters.AddWithValue("@maBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                        cm.ExecuteNonQuery();

                        foreach (DSHoaDonDichVu_BaoCao obj in list)
                        {
                            if (obj.check == true)
                            {
                                obj.MaKy = maky;
                                obj.Loai = loai;
                                obj.Insert(tr);
                            }
                        }
                    }//using

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int maky;
            public FilterCriteria(int maky)
            {
                this.maky = maky;
            }
        }
        private class FilterCriteria_By1
        {
            public int maky;
            public FilterCriteria_By1(int maky)
            {
                this.maky = maky;
            }
        }
        private class FilterCriteria_ChonBaoCao_HoaDonMuaVao
        {
            public int maky;
            //public int maBoPhan;
            public FilterCriteria_ChonBaoCao_HoaDonMuaVao(int _maky)
            {
                this.maky = _maky;
                //this.maBoPhan = _maBoPhan;
            }
        }
        private class FilterCriteria_ChonBaoCao_HoaDonMuaVao_TuKy_DenKy
        {
            public int tuKy;
            public int denKy;
            //public int maBoPhan;
            public FilterCriteria_ChonBaoCao_HoaDonMuaVao_TuKy_DenKy(int _tuKy, int _denKy)
            {
                this.tuKy = _tuKy;
                this.denKy = _denKy;
                //this.maBoPhan = _maBoPhan;
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
                    cm.CommandText = "spd_DSHoaDonDichVu_BaoCao";
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteria)criteria).maky);                   
                }
                else if (criteria is FilterCriteria_By1)
                {
                    cm.CommandText = "spd_reportThue01_1GTGT";
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteria_By1)criteria).maky);

                }
                else if (criteria is FilterCriteria_ChonBaoCao_HoaDonMuaVao)
                {
                    cm.CommandText = "spChonHoaDonBaoCao_ThueGTGTMuaVao";
                    cm.CommandTimeout = 3000;
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteria_ChonBaoCao_HoaDonMuaVao)criteria).maky);
                    cm.Parameters.AddWithValue("@userID", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DSHoaDonDichVu_BaoCao.GetObject_ChonBaoCao_HoaDonMuaVao(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteria_ChonBaoCao_HoaDonMuaVao_TuKy_DenKy)
                {
                    cm.CommandText = "spChonHoaDonBaoCao_ThueGTGTMuaVao_TuKy_DenKy";
                    cm.CommandTimeout = 3000;
                    cm.Parameters.AddWithValue("@tuKy", ((FilterCriteria_ChonBaoCao_HoaDonMuaVao_TuKy_DenKy)criteria).tuKy);
                    cm.Parameters.AddWithValue("@denKy", ((FilterCriteria_ChonBaoCao_HoaDonMuaVao_TuKy_DenKy)criteria).denKy);
                    cm.Parameters.AddWithValue("@userID", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DSHoaDonDichVu_BaoCao.GetObject_ChonBaoCao_HoaDonMuaVao(dr));
                    }
                    return;
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DSHoaDonDichVu_BaoCao.GetDSHoaDonDichVu_BaoCao(dr));
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
                    foreach (DSHoaDonDichVu_BaoCao deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DSHoaDonDichVu_BaoCao child in this)
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
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
