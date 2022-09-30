
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThuLaoNhanVienNgoaiDai_ChiTietList : Csla.BusinessListBase<ThuLaoNhanVienNgoaiDai_ChiTietList, ThuLaoNhanVienNgoaiDai_ChiTietChild>
    {
        #region BindingList Overrides
        private long iddef = -1;
        protected override object AddNewCore()
        {
            ThuLaoNhanVienNgoaiDai_ChiTietChild item = ThuLaoNhanVienNgoaiDai_ChiTietChild.NewThuLaoNhanVienNgoaiDai_ChiTietChild();
            item._maChiTiet = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ThuLaoNhanVienNgoaiDai_ChiTietList NewThuLaoNhanVienNgoaiDai_ChiTietList()
        {
            return new ThuLaoNhanVienNgoaiDai_ChiTietList();
        }

        internal static ThuLaoNhanVienNgoaiDai_ChiTietList GetThuLaoNhanVienNgoaiDai_ChiTietList(int MaThuLao)
        {
            return new ThuLaoNhanVienNgoaiDai_ChiTietList(MaThuLao);
        }

        private ThuLaoNhanVienNgoaiDai_ChiTietList()
        {
        }

        private ThuLaoNhanVienNgoaiDai_ChiTietList(int MaThuLao)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Select_ThuLaoNhanVienNgoaiDai_ChiTietList";
                        cm.Parameters.AddWithValue("@MaThuLao", MaThuLao);
                        SafeDataReader dr = new SafeDataReader(cm.ExecuteReader());
                        Fetch(dr);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                cn.Close();
            }
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ThuLaoNhanVienNgoaiDai_ChiTietChild.GetThuLaoNhanVienNgoaiDai_ChiTietChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ThuLaoNhanVienNgoaiDai parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ThuLaoNhanVienNgoaiDai_ChiTietChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ThuLaoNhanVienNgoaiDai_ChiTietChild child in this)
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
