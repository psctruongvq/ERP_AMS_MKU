using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BangKQHDKDHList : Csla.BusinessListBase<BangKQHDKDHList, BangKQHDKDH>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BangKQHDKDH item = BangKQHDKDH.NewBangKQHDKDH();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangKQHDKDHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangKQHDKDHListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangKQHDKDHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangKQHDKDHListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangKQHDKDHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangKQHDKDHListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangKQHDKDHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangKQHDKDHListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangKQHDKDHList()
        { /* require use of factory method */ }

        public static BangKQHDKDHList NewBangKQHDKDHList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangKQHDKDHList");
            return new BangKQHDKDHList();
        }


        public static BangKQHDKDHList GetBangKQHDKDHList(byte loaiBaoCao,int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangKQHDKDHList");
            return DataPortal.Fetch<BangKQHDKDHList>(new FilterCriteria(loaiBaoCao,maThongTu));
        }

        public static BangKQHDKDHList GetBangKQHDKDHList_ForTree(byte loaiBaoCao, int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangKQHDKDHList");
            return DataPortal.Fetch<BangKQHDKDHList>(new FilterCriteria_ForTree(loaiBaoCao, maThongTu));
        }

        public static BangKQHDKDHList GetBangKQHDKDHListByTT(int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangKQHDKDHList");
            return DataPortal.Fetch<BangKQHDKDHList>(new FilterCriteriaByTT(maThongTu));
        }

        public static BangKQHDKDHList GetBCKQHoatDongKinhDoanhListforLCTT(byte loaiBaoCao, int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangKQHDKDHList");
            return DataPortal.Fetch<BangKQHDKDHList>(new FilterCriteriaforLCTT(loaiBaoCao, maThongTu));
        }

        public static BangKQHDKDHList GetBCKQHoatDongKinhDoanhListforLCTT_ForTree(byte loaiBaoCao, int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangKQHDKDHList");
            return DataPortal.Fetch<BangKQHDKDHList>(new FilterCriteriaforLCTT_ForTree(loaiBaoCao, maThongTu));
        }

        public static BangKQHDKDHList GetBCKQHoatDongKinhDoanhListCheckCha(int maMuc, int maThongTu, byte loaiBaoCao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangKQHDKDHList");
            return DataPortal.Fetch<BangKQHDKDHList>(new FilterCriteriaCheckCha(maMuc, maThongTu, loaiBaoCao));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaThongTu = 0;
            public byte LoaiBaoCao = 0;

            public FilterCriteria(byte loaiBaoCao,int maThongTu)
            {
                MaThongTu = maThongTu;
                LoaiBaoCao = loaiBaoCao;
            }
        }
        private class FilterCriteria_ForTree
        {
            public int MaThongTu = 0;
            public byte LoaiBaoCao = 0;

            public FilterCriteria_ForTree(byte loaiBaoCao, int maThongTu)
            {
                MaThongTu = maThongTu;
                LoaiBaoCao = loaiBaoCao;
            }
        }
        private class FilterCriteriaforLCTT
        {
            public int MaThongTu = 0;
            public byte LoaiBaoCao = 0;

            public FilterCriteriaforLCTT(byte loaiBaoCao, int maThongTu)
            {
                MaThongTu = maThongTu;
                LoaiBaoCao = loaiBaoCao;
            }
        }

        private class FilterCriteriaforLCTT_ForTree
        {
            public int MaThongTu = 0;
            public byte LoaiBaoCao = 0;

            public FilterCriteriaforLCTT_ForTree(byte loaiBaoCao, int maThongTu)
            {
                MaThongTu = maThongTu;
                LoaiBaoCao = loaiBaoCao;
            }
        }

        private class FilterCriteriaByTT
        {
            public int MaThongTu = 0;

            public FilterCriteriaByTT( int maThongTu)
            {
                MaThongTu = maThongTu;
            }
        }

        private class FilterCriteriaCheckCha
        {
            public int MaMuc = 0;
            public int MaThongTu = 0;
            public byte LoaiBaoCao = 0;

            public FilterCriteriaCheckCha(int maMuc,int maThongTu,byte loaiBaoCao)
            {
                MaMuc = maMuc;
                MaThongTu = maThongTu;
                LoaiBaoCao = loaiBaoCao;
            }
        }
        #endregion //Filter Criteria

        

        #region Data Access - Fetch

        public void UpdateMucChaLCTT(int maThongTu, int loaiBaoCao)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdateMucChaLCTT";
                    cm.Parameters.AddWithValue("@MaThongTu", maThongTu);
                    cm.Parameters.AddWithValue("@LoaiBaoCao", loaiBaoCao);
                    cm.ExecuteNonQuery();

                }
            }
        }

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
                    cm.CommandText = "spd_SelecttblMauBCKQHDKDforThongTu";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteria)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteria)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriaforLCTT)
                {
                    cm.CommandText = "spd_SelecttblMauBCKQHDKDforThongTu";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteriaforLCTT)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaforLCTT)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriaByTT)
                {
                    cm.CommandText = "spd_CheckDeleteTT1";
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaByTT)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriaCheckCha)
                {
                    cm.CommandText = "spd_CheckDeleteChaLCTT";
                    cm.Parameters.AddWithValue("@MaMuc", ((FilterCriteriaCheckCha)criteria).MaMuc);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaCheckCha)criteria).MaThongTu);
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteriaCheckCha)criteria).LoaiBaoCao);
                }
                else if (criteria is FilterCriteria_ForTree)
                {
                    cm.CommandText = "spd_GetCongThucBangBCKQHDKD";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteria_ForTree)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteria_ForTree)criteria).MaThongTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BangKQHDKDH.GetBangKQHDKDH_ForTree(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteriaforLCTT_ForTree)
                {
                    cm.CommandText = "spd_GetCongThucBangBCKQHDKD";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteriaforLCTT_ForTree)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaforLCTT_ForTree)criteria).MaThongTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BangKQHDKDH.GetBangKQHDKDH_ForTree(dr));
                    }
                    return;
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangKQHDKDH.GetBangKQHDKDH(dr));
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
                    foreach (BangKQHDKDH deletedChild in DeletedList)
                    {
                        if (deletedChild.MaChiTiet != 0)    //doi tuong cua chi tiet cong thuc
                        {
                            continue;
                        }
                        deletedChild.DeleteSelf(tr);
                    }
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BangKQHDKDH child in this)
                    {
                        if (child.MaChiTiet != 0)    //doi tuong cua chi tiet cong thuc
                        {
                            continue;
                        }

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
