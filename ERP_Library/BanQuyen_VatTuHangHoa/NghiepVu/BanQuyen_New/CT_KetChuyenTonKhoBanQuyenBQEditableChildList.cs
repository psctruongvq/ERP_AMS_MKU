
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_KetChuyenTonKhoBanQuyenBQList : Csla.BusinessListBase<CT_KetChuyenTonKhoBanQuyenBQList, CT_KetChuyenTonKhoBanQuyenBQ>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_KetChuyenTonKhoBanQuyenBQ item = CT_KetChuyenTonKhoBanQuyenBQ.NewCT_KetChuyenTonKhoBanQuyen();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_KetChuyenTonKhoBanQuyenBQList NewCT_KetChuyenTonKhoBanQuyenList()
        {
            return new CT_KetChuyenTonKhoBanQuyenBQList();
        }

        //internal static CT_KetChuyenTonKhoBanQuyenList GetCT_KetChuyenTonKhoBanQuyenList(SafeDataReader dr)
        //{
        //    return new CT_KetChuyenTonKhoBanQuyenList(dr);
        //}
        internal static CT_KetChuyenTonKhoBanQuyenBQList GetCT_KetChuyenTonKhoBanQuyenList(long MaKetChuyenBQ)
        {
            return new CT_KetChuyenTonKhoBanQuyenBQList(MaKetChuyenBQ);
        }
        internal static CT_KetChuyenTonKhoBanQuyenBQList GetCT_KetChuyenTonKhoBanQuyenList(int maKho)
        {
            return new CT_KetChuyenTonKhoBanQuyenBQList(maKho);
        }

        private CT_KetChuyenTonKhoBanQuyenBQList()
        {
            MarkAsChild();
        }

        //private CT_KetChuyenTonKhoBanQuyenList(SafeDataReader dr)
        //{
        //    MarkAsChild();
        //    Fetch(dr);
        //}
        private CT_KetChuyenTonKhoBanQuyenBQList(long MaKetChuyenBQ)
        {
            MarkAsChild();
            Fetch(MaKetChuyenBQ);
        }
        private CT_KetChuyenTonKhoBanQuyenBQList(int maKho)
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
                            this.Add(CT_KetChuyenTonKhoBanQuyenBQ.GetCT_KetChuyenTonKhoBanQuyen(dr, true));
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
                            this.Add(CT_KetChuyenTonKhoBanQuyenBQ.GetCT_KetChuyenTonKhoBanQuyen(dr, false));
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

        internal void Update(SqlTransaction tr, KetChuyenTonKhoBanQuyenBQ parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_KetChuyenTonKhoBanQuyenBQ deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_KetChuyenTonKhoBanQuyenBQ child in this)
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
