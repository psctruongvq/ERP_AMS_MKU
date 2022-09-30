
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinNganHangChildList : Csla.BusinessListBase<ThongTinNganHangChildList, ThongTinNganHangChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ThongTinNganHangChild item = ThongTinNganHangChild.NewThongTinNganHangChild();
            this.Add(item);
            
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ThongTinNganHangChildList NewThongTinNganHangChildList()
        {
            return new ThongTinNganHangChildList();
        }

        internal static ThongTinNganHangChildList GetThongTinNganHangChildList(SafeDataReader dr)
        {
            return new ThongTinNganHangChildList(dr);
        }

        public static ThongTinNganHangChildList GetChungTu_GiayBanNgoaiTeChildList(int maTKNganHang)
        {
            return DataPortal.Fetch<ThongTinNganHangChildList>(new FilterCriteria_ByNganHang(maTKNganHang));
        }

        private ThongTinNganHangChildList()
        {
            MarkAsChild();
        }

        private ThongTinNganHangChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long maTTNH;

            public FilterCriteria(long MaTTNH)
            {
                this.maTTNH = MaTTNH;
            }
        }

        private class FilterCriteria_ByNganHang
        {
            public int MaTKNganHang;

            public FilterCriteria_ByNganHang(int maTKNganHang)
            {
                this.MaTKNganHang = maTKNganHang;
            }
        }
        #endregion


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
                    cm.CommandText = "spd_SelecttblnsThongTinNganHang";
                    cm.Parameters.AddWithValue("@MaTTNH", ((FilterCriteria)criteria).maTTNH);
                }
                else if (criteria is FilterCriteria_ByNganHang)
                {
                    cm.CommandText = "spd_SelecttblnsThongTinNganHangsByMaTKNganHang";
                    cm.Parameters.AddWithValue("@MaTKNganHang", ((FilterCriteria_ByNganHang)criteria).MaTKNganHang);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTinNganHangChild.GetThongTinNganHangChild(dr));
                }

            }//using
        }
        #endregion

        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ThongTinNganHangChild.GetThongTinNganHangChild(dr));

            RaiseListChangedEvents = true;
        }
        
        internal void Update(SqlTransaction tr, TK_NganHang parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ThongTinNganHangChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ThongTinNganHangChild child in this)
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
            foreach (ThongTinNganHangChild child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}
