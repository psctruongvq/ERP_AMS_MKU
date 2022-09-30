
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChuyenKhoanChuaDuyetList : Csla.BusinessListBase<ChuyenKhoanChuaDuyetList, ChuyenKhoanChuaDuyet>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuyenKhoanChuaDuyetList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenKhoanChuaDuyetListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuyenKhoanChuaDuyetList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenKhoanChuaDuyetListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuyenKhoanChuaDuyetList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenKhoanChuaDuyetListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuyenKhoanChuaDuyetList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenKhoanChuaDuyetListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuyenKhoanChuaDuyetList()
        { /* require use of factory method */ }

        public static ChuyenKhoanChuaDuyetList NewChuyenKhoanChuaDuyetList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuyenKhoanChuaDuyetList");
            return new ChuyenKhoanChuaDuyetList();
        }

        public static ChuyenKhoanChuaDuyetList GetChuyenKhoanChuaDuyetList(DateTime TuNgay,DateTime DenNgay,int MaCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuyenKhoanChuaDuyetList");
            return DataPortal.Fetch<ChuyenKhoanChuaDuyetList>(new FilterCriteria(MaCongTy, TuNgay, DenNgay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int _maCongTy = 0;
            public DateTime _TuNgay;
            public DateTime _DenNgay;
            public FilterCriteria(int MaCongTy, DateTime dtTuNgay, DateTime dtDenNgay)
            {
                this._maCongTy = MaCongTy;
                this._TuNgay = dtTuNgay;
                this._DenNgay = dtDenNgay;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_tblDeNghiChuyenKhoan_ChuaLapChungTu";
                
                cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria)criteria)._maCongTy);
                cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria)._TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria)._DenNgay);
               
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChuyenKhoanChuaDuyet.GetChuyenKhoanChuaDuyet(dr));
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
                foreach (ChuyenKhoanChuaDuyet deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChuyenKhoanChuaDuyet child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn,this);
                    else
                        child.Update(cn,this);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
