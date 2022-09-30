using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CongThucApDungKeToanTongHopRootList : Csla.BusinessListBase<CongThucApDungKeToanTongHopRootList, CongThucApDungKeToanTongHop>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongThucApDungKeToanTongHop item = CongThucApDungKeToanTongHop.NewCongThucApDungKeToanTongHop();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CongThucApDungKeToanTongHopRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucApDungKeToanTongHopRootListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CongThucApDungKeToanTongHopRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucApDungKeToanTongHopRootListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CongThucApDungKeToanTongHopRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucApDungKeToanTongHopRootListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CongThucApDungKeToanTongHopRootList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucApDungKeToanTongHopRootListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CongThucApDungKeToanTongHopRootList()
        { /* require use of factory method */ }

        public static CongThucApDungKeToanTongHopRootList NewCongThucApDungKeToanTongHopRootList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongThucApDungKeToanTongHopRootList");
            return new CongThucApDungKeToanTongHopRootList();
        }

        public static CongThucApDungKeToanTongHopRootList GetCongThucApDungKeToanTongHopRootList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucApDungKeToanTongHopRootList");
            return DataPortal.Fetch<CongThucApDungKeToanTongHopRootList>(new FilterCriteria());
        }

        public static CongThucApDungKeToanTongHopRootList GetCongThucApDungKeToanTongHopRootListByLoaiMauBaoCao(byte loaiBaoCao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucApDungKeToanTongHopRootList");
            return DataPortal.Fetch<CongThucApDungKeToanTongHopRootList>(new FilterCriteriaByLoaiMauBaoCao(loaiBaoCao));
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

        [Serializable()]
        private class FilterCriteriaByLoaiMauBaoCao
        {
            public byte LoaiMauBaoCao;
            public FilterCriteriaByLoaiMauBaoCao(byte loaimaubaocao)
            {
                LoaiMauBaoCao = loaimaubaocao;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblCongThucApDungKeToanTongHopsAll";
                }
                else if (criteria is FilterCriteriaByLoaiMauBaoCao)
                {
                    cm.CommandText = "spd_SelecttblCongThucApDungKeToanTongHopsbyLoaiMauBaoCao";
                    cm.Parameters.AddWithValue("@LoaiMauBaoCao", ((FilterCriteriaByLoaiMauBaoCao)criteria).LoaiMauBaoCao);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongThucApDungKeToanTongHop.GetCongThucApDungKeToanTongHop(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                foreach (CongThucApDungKeToanTongHop deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (CongThucApDungKeToanTongHop child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn);
                    else
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
