
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class GiayNghiPhepNuocNgoai_NuocDenList : Csla.BusinessListBase<GiayNghiPhepNuocNgoai_NuocDenList, GiayNghiPhepNuocNgoai_NuocDenListChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            GiayNghiPhepNuocNgoai_NuocDenListChild item = GiayNghiPhepNuocNgoai_NuocDenListChild.NewGiayNghiPhepNuocNgoai_NuocDenListChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static GiayNghiPhepNuocNgoai_NuocDenList NewGiayNghiPhepNuocNgoai_NuocDenList()
        {
            return new GiayNghiPhepNuocNgoai_NuocDenList();
        }

        internal static GiayNghiPhepNuocNgoai_NuocDenList GetGiayNghiPhepNuocNgoai_NuocDenList(SafeDataReader dr)
        {
            return new GiayNghiPhepNuocNgoai_NuocDenList(dr);
        }

        private GiayNghiPhepNuocNgoai_NuocDenList()
        {
            MarkAsChild();
        }

        private GiayNghiPhepNuocNgoai_NuocDenList(SafeDataReader dr)
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
                this.Add(GiayNghiPhepNuocNgoai_NuocDenListChild.GetGiayNghiPhepNuocNgoai_NuocDenListChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, GiayNghiPhepNuocNgoai parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (GiayNghiPhepNuocNgoai_NuocDenListChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (GiayNghiPhepNuocNgoai_NuocDenListChild child in this)
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
