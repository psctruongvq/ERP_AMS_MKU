
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_KetChuyenTonKhoBanQuyenList : Csla.BusinessListBase<CT_KetChuyenTonKhoBanQuyenList, CT_KetChuyenTonKhoBanQuyen>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_KetChuyenTonKhoBanQuyen item = CT_KetChuyenTonKhoBanQuyen.NewCT_KetChuyenTonKhoBanQuyen();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_KetChuyenTonKhoBanQuyenList NewCT_KetChuyenTonKhoBanQuyenList()
        {
            return new CT_KetChuyenTonKhoBanQuyenList();
        }

        //internal static CT_KetChuyenTonKhoBanQuyenList GetCT_KetChuyenTonKhoBanQuyenList(SafeDataReader dr)
        //{
        //    return new CT_KetChuyenTonKhoBanQuyenList(dr);
        //}
        internal static CT_KetChuyenTonKhoBanQuyenList GetCT_KetChuyenTonKhoBanQuyenList(long MaKetChuyenBQ)
        {
            return new CT_KetChuyenTonKhoBanQuyenList(MaKetChuyenBQ);
        }
        internal static CT_KetChuyenTonKhoBanQuyenList GetCT_KetChuyenTonKhoBanQuyenList(int maKho)
        {
            return new CT_KetChuyenTonKhoBanQuyenList(maKho);
        }

        private CT_KetChuyenTonKhoBanQuyenList()
        {
            MarkAsChild();
        }

        //private CT_KetChuyenTonKhoBanQuyenList(SafeDataReader dr)
        //{
        //    MarkAsChild();
        //    Fetch(dr);
        //}
        private CT_KetChuyenTonKhoBanQuyenList(long MaKetChuyenBQ)
        {
            MarkAsChild();
            Fetch(MaKetChuyenBQ);
        }
        private CT_KetChuyenTonKhoBanQuyenList(int maKho)
        {
            MarkAsChild();
            Fetch(maKho);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(long MaKetChuyenBQ)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_KetChuyenTonKhoBanQuyensByAndMaKetChuyen";
                    cm.Parameters.AddWithValue("@MaKetChuyenBQ", MaKetChuyenBQ);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_KetChuyenTonKhoBanQuyen.GetCT_KetChuyenTonKhoBanQuyen(dr, true));
                    }
                }
            }

            RaiseListChangedEvents = true;
        }
        private void Fetch(int maKho)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_KetChuyenTonKhoBanQuyensByMaKho";
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_KetChuyenTonKhoBanQuyen.GetCT_KetChuyenTonKhoBanQuyen(dr, false));
                    }
                }
            }

            RaiseListChangedEvents = true;
        }

        //private void Fetch(SafeDataReader dr)
        //{
        //    RaiseListChangedEvents = false;

        //    while (dr.Read())
        //        this.Add(CT_KetChuyenTonKhoBanQuyen.GetCT_KetChuyenTonKhoBanQuyen(dr,true));

        //    RaiseListChangedEvents = true;
        //}

        internal void Update(SqlTransaction tr, KetChuyenTonKhoBanQuyen parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_KetChuyenTonKhoBanQuyen deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_KetChuyenTonKhoBanQuyen child in this)
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
