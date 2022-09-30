
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DieuKienPhuCapList : Csla.BusinessListBase<DieuKienPhuCapList, DieuKienPhuCapChild>
    {
        private int _defaultid = -1;
        internal PhuCapChild _parent;

        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DieuKienPhuCapChild item = DieuKienPhuCapChild.NewDieuKienPhuCapChild();
            item._maDieuKien = _defaultid;
            _defaultid--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static DieuKienPhuCapList NewDieuKienPhuCapList()
        {
            return new DieuKienPhuCapList();
        }

        internal static DieuKienPhuCapList GetDieuKienPhuCapList(SafeDataReader dr)
        {
            return new DieuKienPhuCapList(dr);
        }

        internal static DieuKienPhuCapList GetDieuKienPhuCapByMaPhuCap(int MaPhuCap)
        {
            return DataPortal.Fetch<DieuKienPhuCapList>(new FilterCriteria(MaPhuCap));
        }

        private DieuKienPhuCapList()
        {
            MarkAsChild();
            this.ListChanged += new System.ComponentModel.ListChangedEventHandler(DieuKienPhuCapList_ListChanged);
        }

        void DieuKienPhuCapList_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (_parent != null)
            {
                string s = "", a = "";
                foreach (DieuKienPhuCapChild i in this)
                {
                    a = i.DieuKien + i.CongThuc + i.GiaTri;

                    if (s == "") s = a;
                    else s += " AND " + a;
                }
                _parent.DieuKien = s;
            }
        }

        private DieuKienPhuCapList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaPhuCap;

            public FilterCriteria(int maLoaiPhuCap)
            {
                this.MaPhuCap= maLoaiPhuCap;
            }
        }
        #endregion //Filter Criteria

        #region Data Access
        private void DataPortal_Fetch(FilterCriteria criteria)
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

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_DieuKienPhuCapList";
                cm.Parameters.AddWithValue("@MaPhuCap", criteria.MaPhuCap);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DieuKienPhuCapChild.GetDieuKienPhuCapChild(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(DieuKienPhuCapChild.GetDieuKienPhuCapChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, PhuCapChild parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (DieuKienPhuCapChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (DieuKienPhuCapChild child in this)
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
