
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVienGiaCanhList : Csla.BusinessListBase<NhanVienGiaCanhList, NhanVienGiaCanh>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhanVienGiaCanh item = NhanVienGiaCanh.NewNhanVienGiaCanh();
            this.Add(item);
            return item;
        }
        //protected override object AddNewCore()
        //{
        //    NhanVienGiaCanh item = NhanVienGiaCanh.NewNhanVienGiaCanh();
        //    this.Add(item);
        //    return item;
        //}
        #endregion //BindingList Overrides

        #region Factory Methods
        public static NhanVienGiaCanhList NewNhanVienGiaCanhList()
        {
            return new NhanVienGiaCanhList();
        }

        public static NhanVienGiaCanhList GetNhanVienGiaCanh()
        {
            //return new HoatDongXaHoiList(dr);
            return DataPortal.Fetch<NhanVienGiaCanhList>(new FilterCriteriaAll());
        }

        public static NhanVienGiaCanhList GetNhanVienGiaCanhList(long maNhanVien)
        {
            //return new HoatDongXaHoiList(dr);
            return DataPortal.Fetch<NhanVienGiaCanhList>(new FilterCriteria(maNhanVien));
        }


        private NhanVienGiaCanhList()
        {
            MarkAsChild();
        }

        private NhanVienGiaCanhList(SafeDataReader dr)
        {
            MarkAsChild();
            //Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;

            public FilterCriteria(long MaNhanVien)
            {
                this.MaNhanVien = MaNhanVien;
            }
        }

        [Serializable()]
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
            }
        }
        #endregion //Filter Criteria

        protected override void DataPortal_Fetch(object criteria)
        {
            if (criteria is FilterCriteria)
            {
                DataPortal_Fetch(criteria);
            }
            else 
            {
                DataPortal_FetchAll((FilterCriteriaAll)criteria);
            }
        }       
        private void DataPortal_FetchAll(FilterCriteriaAll criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetchAll(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }
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
        private void ExecuteFetchAll(SqlConnection cn, FilterCriteriaAll criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                 if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien_GiaCanhesAll";
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVienGiaCanh.GetNhanVienGiaCanh(dr));
                }
            }//using
        }
        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien_GiaCanheByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                }
                
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVienGiaCanh.GetNhanVienGiaCanh(dr));
                }
            }//using
        }


        internal void Update(SqlTransaction tr, NhanVien parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (NhanVienGiaCanh deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (NhanVienGiaCanh child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
