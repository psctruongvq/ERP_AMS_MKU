
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DaoTaoNgoai_ChiTietList : Csla.BusinessListBase<DaoTaoNgoai_ChiTietList, DaoTaoNgoai_ChiTietListChild>
    {
        private int _defaultID = -1;
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DaoTaoNgoai_ChiTietListChild item = DaoTaoNgoai_ChiTietListChild.NewDaoTaoNgoai_ChiTietListChild();
            item._maDTNgoaiChiTiet = _defaultID;
            _defaultID--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static DaoTaoNgoai_ChiTietList NewDaoTaoNgoai_ChiTietList()
        {
            return new DaoTaoNgoai_ChiTietList();
        }

        internal static DaoTaoNgoai_ChiTietList GetDaoTaoNgoai_ChiTietList(SafeDataReader dr)
        {
            return new DaoTaoNgoai_ChiTietList(dr);
        }

        private DaoTaoNgoai_ChiTietList()
        {
            MarkAsChild();
        }

        private DaoTaoNgoai_ChiTietList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(DaoTaoNgoai_ChiTietListChild.GetDaoTaoNgoai_ChiTietListChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, DaoTaoNgoai parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (DaoTaoNgoai_ChiTietListChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (DaoTaoNgoai_ChiTietListChild child in this)
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
