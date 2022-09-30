
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietGiayRutTienList : Csla.BusinessListBase<ChiTietGiayRutTienList, ChiTietGiayRutTien>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietGiayRutTien item = ChiTietGiayRutTien.NewChiTietGiayRutTien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietGiayRutTienList NewChiTietGiayRutTienList()
        {
            return new ChiTietGiayRutTienList();
        }

        internal static ChiTietGiayRutTienList GetChiTietGiayRutTienList(SafeDataReader dr)
        {
            return new ChiTietGiayRutTienList(dr);
        }

        public static ChiTietGiayRutTienList GetChiTietGiayRutTienList(long MaGiayRutTien)
        {
            return DataPortal.Fetch<ChiTietGiayRutTienList>(new FilterCriteria_ByMaGiayRutTien(MaGiayRutTien));
        }

        private ChiTietGiayRutTienList()
        {
            MarkAsChild();
        }

        private ChiTietGiayRutTienList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        [Serializable()]
        private class FilterCriteria
        {
            public long MaPhieu;

            public FilterCriteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
            }
        }

        private class FilterCriteria_ByMaGiayRutTien
        {
            public long _MaGiayRutTien;

            public FilterCriteria_ByMaGiayRutTien(long MaGiayRutTien)
            {
                this._MaGiayRutTien = MaGiayRutTien;
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
                    cm.CommandText = "spd_SelecttblCT_GiayRutTiensAll";
                }
                else if (criteria is FilterCriteria_ByMaGiayRutTien)
                {
                    cm.CommandText = "spd_SelecttblCT_GiayRutTiensByMaGiayRutTien";
                    cm.Parameters.AddWithValue("@MaGiayRutTien", ((FilterCriteria_ByMaGiayRutTien)criteria)._MaGiayRutTien);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietGiayRutTien.GetChiTietGiayRutTien(dr));
                }

            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiTietGiayRutTien.GetChiTietGiayRutTien(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, GiayRutTien parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietGiayRutTien deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietGiayRutTien child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }

        public void DataPortal_Delete(SqlTransaction tr)
        {
            foreach (ChiTietGiayRutTien child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}
