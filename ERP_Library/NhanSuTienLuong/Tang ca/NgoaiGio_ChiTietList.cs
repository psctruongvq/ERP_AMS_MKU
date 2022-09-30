
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NgoaiGio_ChiTietList : Csla.BusinessListBase<NgoaiGio_ChiTietList, NgoaiGio_ChiTiet>
    {
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            NgoaiGio_ChiTiet item = NgoaiGio_ChiTiet.NewNgoaiGio_ChiTietChild();
            item._maChiTiet = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static NgoaiGio_ChiTietList NewNgoaiGio_ChiTietList()
        {
            return new NgoaiGio_ChiTietList();
        }

        internal static NgoaiGio_ChiTietList GetNgoaiGio_ChiTietList(SafeDataReader dr)
        {
            return new NgoaiGio_ChiTietList(dr);
        }

        internal static NgoaiGio_ChiTietList GetNgoaiGio_ChiTietList(int MaNgoaiGio)
        {
            return new NgoaiGio_ChiTietList(MaNgoaiGio);
        }

        private NgoaiGio_ChiTietList()
        {
            MarkAsChild();
        }

        private NgoaiGio_ChiTietList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        private NgoaiGio_ChiTietList(int MaNgoaiGio)
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
                this.Add(NgoaiGio_ChiTiet.GetNgoaiGio_ChiTiet(dr));

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
                cm.CommandText = "spd_Select_NgoaiGio_ChiTietList";
                cm.Parameters.AddWithValue("@MaNgoaiGio", MaNgoaiGio);
                try
                {
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(NgoaiGio_ChiTiet.GetNgoaiGio_ChiTiet(dr));
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

        internal void Update(SqlTransaction tr, NgoaiGio_TongHop parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (NgoaiGio_ChiTiet deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (NgoaiGio_ChiTiet child in this)
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
