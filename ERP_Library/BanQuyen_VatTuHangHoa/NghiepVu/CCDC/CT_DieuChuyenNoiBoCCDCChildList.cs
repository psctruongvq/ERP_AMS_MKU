using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_DieuChuyenNoiBoCCDCChildList : Csla.BusinessListBase<CT_DieuChuyenNoiBoCCDCChildList, CT_DieuChuyenNoiBoCCDCChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_DieuChuyenNoiBoCCDCChild item = CT_DieuChuyenNoiBoCCDCChild.NewCT_DieuChuyenNoiBoCCDCChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_DieuChuyenNoiBoCCDCChildList NewCT_DieuChuyenNoiBoCCDCChildList()
        {
            return new CT_DieuChuyenNoiBoCCDCChildList();
        }

        internal static CT_DieuChuyenNoiBoCCDCChildList GetCT_DieuChuyenNoiBoCCDCChildList(SafeDataReader dr)
        {
            return new CT_DieuChuyenNoiBoCCDCChildList(dr);
        }

        internal static CT_DieuChuyenNoiBoCCDCChildList GetCT_DieuChuyenNoiBoCCDCChildList(int maDieuChuyen)
        {
            return new CT_DieuChuyenNoiBoCCDCChildList(maDieuChuyen);
        }

        private CT_DieuChuyenNoiBoCCDCChildList()
        {
            MarkAsChild();
        }

        private CT_DieuChuyenNoiBoCCDCChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }

        private CT_DieuChuyenNoiBoCCDCChildList(int maDieuChuyen)
        {
            MarkAsChild();
            Fetch(maDieuChuyen);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(CT_DieuChuyenNoiBoCCDCChild.GetCT_DieuChuyenNoiBoCCDCChild(dr));

            RaiseListChangedEvents = true;
        }

        private void Fetch(int maDieuChuyen)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn=new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using(SqlCommand cm=cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_DieuChuyenNoiBoCCDCsAll";
                    cm.Parameters.AddWithValue("@MaDieuChuyen", maDieuChuyen);
                    using(SafeDataReader dr=new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_DieuChuyenNoiBoCCDCChild.GetCT_DieuChuyenNoiBoCCDCChild(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        internal void Update( SqlTransaction tr, DieuChuyenNoiBoCCDC parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_DieuChuyenNoiBoCCDCChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_DieuChuyenNoiBoCCDCChild child in this)
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
