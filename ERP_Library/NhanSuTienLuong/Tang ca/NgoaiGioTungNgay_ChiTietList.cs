
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NgoaiGioTungNgay_ChiTietList : Csla.BusinessListBase<NgoaiGioTungNgay_ChiTietList, NgoaiGioTungNgay_ChiTiet>
    {
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            NgoaiGioTungNgay_ChiTiet item = NgoaiGioTungNgay_ChiTiet.NewNgoaiGioTungNgay_ChiTietChild();
            item._maChiTiet = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static NgoaiGioTungNgay_ChiTietList NewNgoaiGioTungNgay_ChiTietList()
        {
            return new NgoaiGioTungNgay_ChiTietList();
        }

        internal static NgoaiGioTungNgay_ChiTietList GetNgoaiGioTungNgay_ChiTietList(SafeDataReader dr)
        {
            return new NgoaiGioTungNgay_ChiTietList(dr);
        }

        internal static NgoaiGioTungNgay_ChiTietList GetNgoaiGioTungNgay_ChiTietList(int MaNgoaiGio)
        {
            return new NgoaiGioTungNgay_ChiTietList(MaNgoaiGio);
        }

        private NgoaiGioTungNgay_ChiTietList()
        {
            MarkAsChild();
        }

        private NgoaiGioTungNgay_ChiTietList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        private NgoaiGioTungNgay_ChiTietList(int MaNgoaiGio)
        {
            MarkAsChild();
            Fetch(MaNgoaiGio);
        }

        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(NgoaiGioTungNgay_ChiTiet.GetNgoaiGioTungNgay_ChiTiet(dr));

            RaiseListChangedEvents = true;
        }

        private void Fetch(int MaNgoaiGio)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.Transaction = tr;
                cm.CommandText = "spd_Select_NgoaiGioTungNgay_ChiTietList";
                cm.Parameters.AddWithValue("@MaNgoaiGio", MaNgoaiGio);
                try
                {
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(NgoaiGioTungNgay_ChiTiet.GetNgoaiGioTungNgay_ChiTiet(dr));
                        }
                    }
                    tr.Commit();
                }
                catch 
                {
                    tr.Rollback();
                }
                cn.Close();
            }

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, NgoaiGioTungNgay_TongHop parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (NgoaiGioTungNgay_ChiTiet deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (NgoaiGioTungNgay_ChiTiet child in this)
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
