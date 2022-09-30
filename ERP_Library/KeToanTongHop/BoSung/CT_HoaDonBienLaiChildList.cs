using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_HoaDonBienLaiChildList : Csla.BusinessListBase<CT_HoaDonBienLaiChildList, CT_HoaDonBienLaiChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_HoaDonBienLaiChild item = CT_HoaDonBienLaiChild.NewCT_HoaDonBienLaiChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_HoaDonBienLaiChildList NewCT_HoaDonBienLaiChildList()
        {
            return new CT_HoaDonBienLaiChildList();
        }

        internal static CT_HoaDonBienLaiChildList GetCT_HoaDonBienLaiChildList(SafeDataReader dr)
        {
            return new CT_HoaDonBienLaiChildList(dr);
        }

        internal static CT_HoaDonBienLaiChildList GetCT_HoaDonBienLaiChildList(long maHoaDon)
        {
            return new CT_HoaDonBienLaiChildList(maHoaDon);
        }

        private CT_HoaDonBienLaiChildList()
        {
            MarkAsChild();
        }

        private CT_HoaDonBienLaiChildList( long maHoaDon)
        {
            MarkAsChild();
            Fetch(maHoaDon);
        }

        private CT_HoaDonBienLaiChildList(SafeDataReader dr)
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
                this.Add(CT_HoaDonBienLaiChild.GetCT_HoaDonBienLaiChild(dr));

            RaiseListChangedEvents = true;
        }

        private void Fetch(long maHoaDon)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_HoaDonBienLaisAll";
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_HoaDonBienLaiChild.GetCT_HoaDonBienLaiChild(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, HoaDon parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_HoaDonBienLaiChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_HoaDonBienLaiChild child in this)
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
