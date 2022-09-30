using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CongThucMauBieuBaoCaoList : Csla.BusinessListBase<CongThucMauBieuBaoCaoList, CongThucMauBieuBaoCao>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongThucMauBieuBaoCao item = CongThucMauBieuBaoCao.NewCongThucMauBieuBaoCao();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CongThucMauBieuBaoCaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucMauBieuBaoCaoListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CongThucMauBieuBaoCaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucMauBieuBaoCaoListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CongThucMauBieuBaoCaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucMauBieuBaoCaoListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CongThucMauBieuBaoCaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucMauBieuBaoCaoListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CongThucMauBieuBaoCaoList()
        { /* require use of factory method */ }

        public static CongThucMauBieuBaoCaoList NewCongThucMauBieuBaoCaoList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongThucMauBieuBaoCaoList");
            return new CongThucMauBieuBaoCaoList();
        }


        public static CongThucMauBieuBaoCaoList GetCongThucMauBieuBaoCaoList(byte loaiBaoCao,int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucMauBieuBaoCaoList");
            return DataPortal.Fetch<CongThucMauBieuBaoCaoList>(new FilterCriteria(loaiBaoCao,maThongTu));
        }

        public static CongThucMauBieuBaoCaoList GetCongThucMauBieuBaoCaoMucLienQuanList(byte loaiBaoCao, int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucMauBieuBaoCaoList");
            return DataPortal.Fetch<CongThucMauBieuBaoCaoList>(new FilterCriteriaMucLienQuan(loaiBaoCao, maThongTu));
        }

        public static CongThucMauBieuBaoCaoList GetCongThucMauBieuBaoCaoList_ForTree(byte loaiBaoCao, int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucMauBieuBaoCaoList");
            return DataPortal.Fetch<CongThucMauBieuBaoCaoList>(new FilterCriteria_ForTree(loaiBaoCao, maThongTu));
        }

        public static CongThucMauBieuBaoCaoList GetCongThucMauBieuBaoCaoListByTT(int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucMauBieuBaoCaoList");
            return DataPortal.Fetch<CongThucMauBieuBaoCaoList>(new FilterCriteriaByTT(maThongTu));
        }

        public static CongThucMauBieuBaoCaoList GetBCKQHoatDongKinhDoanhListforLCTT(byte loaiBaoCao, int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucMauBieuBaoCaoList");
            return DataPortal.Fetch<CongThucMauBieuBaoCaoList>(new FilterCriteriaforLCTT(loaiBaoCao, maThongTu));
        }

        public static CongThucMauBieuBaoCaoList GetBCKQHoatDongKinhDoanhListforLCTT_ForTree(byte loaiBaoCao, int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucMauBieuBaoCaoList");
            return DataPortal.Fetch<CongThucMauBieuBaoCaoList>(new FilterCriteriaforLCTT_ForTree(loaiBaoCao, maThongTu));
        }

        public static CongThucMauBieuBaoCaoList GetBCKQHoatDongKinhDoanhListCheckCha(int maMuc, int maThongTu, byte loaiBaoCao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucMauBieuBaoCaoList");
            return DataPortal.Fetch<CongThucMauBieuBaoCaoList>(new FilterCriteriaCheckCha(maMuc, maThongTu, loaiBaoCao));
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
        private class FilterCriteriaMucLienQuan
        {
            public int MaThongTu = 0;
            public byte LoaiBaoCao = 0;

            public FilterCriteriaMucLienQuan(byte loaiBaoCao, int maThongTu)
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
                    cm.CommandText = "spd_SelecttblCongThucMauBieuBaoCaoforThongTu";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteria)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteria)criteria).MaThongTu);
                }
                if (criteria is FilterCriteriaMucLienQuan)
                {
                    cm.CommandText = "spd_SelecttblCongThucMauBieuBaoCaoMucLienQuanforThongTu";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteriaMucLienQuan)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaMucLienQuan)criteria).MaThongTu);
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
                    cm.CommandText = "spd_GetCongThucMauBieuBaoCaoListForTree";
                    cm.Parameters.AddWithValue("@LoaiBaoCao", ((FilterCriteria_ForTree)criteria).LoaiBaoCao);
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteria_ForTree)criteria).MaThongTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CongThucMauBieuBaoCao.GetCongThucMauBieuBaoCao_ForTree(dr));
                    }
                    return;
                }


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongThucMauBieuBaoCao.GetCongThucMauBieuBaoCao(dr));
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
                    foreach (CongThucMauBieuBaoCao deletedChild in DeletedList)
                    {
                        if (deletedChild.MaChiTiet != 0)    //doi tuong cua chi tiet cong thuc
                        {
                            continue;
                        }
                        deletedChild.DeleteSelf(tr);
                    }
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (CongThucMauBieuBaoCao child in this)
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
