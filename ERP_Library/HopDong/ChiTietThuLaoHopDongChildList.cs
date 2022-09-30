using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietThuLaoHopDongList : Csla.BusinessListBase<ChiTietThuLaoHopDongList, ChiTietThuLaoHopDong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietThuLaoHopDong item = ChiTietThuLaoHopDong.NewChiTietThuLaoHopDong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietThuLaoHopDongList NewChiTietThuLaoHopDongList()
        {
            return new ChiTietThuLaoHopDongList();
        }

        internal static ChiTietThuLaoHopDongList GetChiTietThuLaoHopDongList(long maHopDong)
        {
            return new ChiTietThuLaoHopDongList(maHopDong);
        }

        private ChiTietThuLaoHopDongList()
        {
            MarkAsChild();
        }

        private ChiTietThuLaoHopDongList(long maHopDong)
        {
            MarkAsChild();
            Fetch(maHopDong);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(long maHopDong)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "usp_SelecttblChiTietThuLaoHopDongsList";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiTietThuLaoHopDong.GetChiTietThuLaoHopDong(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, HopDongThuChi parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietThuLaoHopDong deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietThuLaoHopDong child in this)
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
