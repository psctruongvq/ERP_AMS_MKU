
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKyHopDongList : Csla.BusinessListBase<SoDuDauKyHopDongList, SoDuDauKyHopDong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            SoDuDauKyHopDong item = SoDuDauKyHopDong.NewSoDuDauKyHopDong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKyHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHopDongListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKyHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHopDongListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKyHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHopDongListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKyHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHopDongListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKyHopDongList()
        { /* require use of factory method */ }

        public static SoDuDauKyHopDongList NewSoDuDauKyHopDongList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyHopDongList");
            return new SoDuDauKyHopDongList();
        }

        public static SoDuDauKyHopDongList GetSoDuDauKyHopDongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyHopDongList");
            return DataPortal.Fetch<SoDuDauKyHopDongList>(new FilterCriteria());
        }

        public static SoDuDauKyHopDongList GetSoDuDauKyHopDongList(int iMaKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyHopDongList");
            return DataPortal.Fetch<SoDuDauKyHopDongList>(new FilterCriteria_ByMaKy(iMaKy));
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

        private class FilterCriteria_ByMaKy
        {
            public int _iMaKy = 0;
            public FilterCriteria_ByMaKy(int iMaKy)
            {
                _iMaKy = iMaKy;
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
            int maBoPhan = Security.CurrentUser.Info.MaBoPhan;
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;

                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblSoDuDauKyTheoHopDongsAll";
                }
                else if (criteria is FilterCriteria_ByMaKy)
                {
                    int iValue = KiemTraKyKetChuyen(((FilterCriteria_ByMaKy)criteria)._iMaKy, maBoPhan);
                    if (iValue > 0)
                    {
                        bIsOld = true;
                    }

                    cm.CommandText = "spd_SelecttblSoDuDauKyTheoHopDong_ByMaKy";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteria_ByMaKy)criteria)._iMaKy);
                    cm.Parameters.AddWithValue("@IsOld", bIsOld);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(SoDuDauKyHopDong.GetSoDuDauKyHopDong(dr, bIsOld));
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
                    foreach (SoDuDauKyHopDong deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (SoDuDauKyHopDong child in this)
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

        public int KiemTraKyKetChuyen(int MaKy, int MaBoPhan)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoDuHopDong";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);

                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }
    }
}
