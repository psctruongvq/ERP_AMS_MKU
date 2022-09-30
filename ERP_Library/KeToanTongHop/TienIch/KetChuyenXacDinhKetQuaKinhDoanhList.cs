using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KetChuyenXacDinhKetQuaKinhDoanhList : Csla.BusinessListBase<KetChuyenXacDinhKetQuaKinhDoanhList, KetChuyenXacDinhKetQuaKinhDoanh>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KetChuyenXacDinhKetQuaKinhDoanh item = KetChuyenXacDinhKetQuaKinhDoanh.NewKetChuyenXacDinhKetQuaKinhDoanh();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KetChuyenXacDinhKetQuaKinhDoanhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenXacDinhKetQuaKinhDoanhListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KetChuyenXacDinhKetQuaKinhDoanhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenXacDinhKetQuaKinhDoanhListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KetChuyenXacDinhKetQuaKinhDoanhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenXacDinhKetQuaKinhDoanhListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KetChuyenXacDinhKetQuaKinhDoanhList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KetChuyenXacDinhKetQuaKinhDoanhListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KetChuyenXacDinhKetQuaKinhDoanhList()
        { /* require use of factory method */ }

        public static KetChuyenXacDinhKetQuaKinhDoanhList NewKetChuyenXacDinhKetQuaKinhDoanhList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KetChuyenXacDinhKetQuaKinhDoanhList");
            return new KetChuyenXacDinhKetQuaKinhDoanhList();
        }

        public static KetChuyenXacDinhKetQuaKinhDoanhList GetKetChuyenXacDinhKetQuaKinhDoanhList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KetChuyenXacDinhKetQuaKinhDoanhList");
            return DataPortal.Fetch<KetChuyenXacDinhKetQuaKinhDoanhList>(new FilterCriteria());
        }

        public static KetChuyenXacDinhKetQuaKinhDoanhList GetKetChuyenXacDinhKetQuaKinhDoanhListForLoadDataKetChuyenXDKQKD(int maloaiKC,DateTime ngaylap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KetChuyenXacDinhKetQuaKinhDoanhList");
            return DataPortal.Fetch<KetChuyenXacDinhKetQuaKinhDoanhList>(new FilterCriteriaForLoadDataKetChuyenXDKQKD(maloaiKC,ngaylap));
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
        private class FilterCriteriaForLoadDataKetChuyenXDKQKD
        {
            public int MaLoaiKC;
            public DateTime NgayLap;

            public FilterCriteriaForLoadDataKetChuyenXDKQKD(int maloaiKC, DateTime ngayLap)
            {
                MaLoaiKC = maloaiKC;
                NgayLap = ngayLap;
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
                if (criteria is FilterCriteriaForLoadDataKetChuyenXDKQKD)
                {
                    cm.CommandText = "spd_LoadDataKetChuyenXDKQKD";
                    cm.Parameters.AddWithValue("@MaLoaiKC", ((FilterCriteriaForLoadDataKetChuyenXDKQKD)criteria).MaLoaiKC);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterCriteriaForLoadDataKetChuyenXDKQKD)criteria).NgayLap);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KetChuyenXacDinhKetQuaKinhDoanh.GetKetChuyenXacDinhKetQuaKinhDoanhForLoadDataKetChuyenXDKQKD(dr));
                    }
                }
                else
                {
                    cm.CommandText = "spd_SelecttblKetChuyenXacDinhKetQuaKinhDoanhsAll";


                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KetChuyenXacDinhKetQuaKinhDoanh.GetKetChuyenXacDinhKetQuaKinhDoanh(dr));
                    }
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
                foreach (KetChuyenXacDinhKetQuaKinhDoanh deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (KetChuyenXacDinhKetQuaKinhDoanh child in this)
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
