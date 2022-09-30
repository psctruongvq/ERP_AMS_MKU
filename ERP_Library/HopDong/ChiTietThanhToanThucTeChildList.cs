using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietThanhToanThucTeList : Csla.BusinessListBase<ChiTietThanhToanThucTeList, ChiTietThanhToanThucTe>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietThanhToanThucTe item = ChiTietThanhToanThucTe.NewChiTietThanhToanThucTe();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietThanhToanThucTeList NewChiTietThanhToanThucTeList()
        {
            return new ChiTietThanhToanThucTeList();
        }

        internal static ChiTietThanhToanThucTeList GetChiTietThanhToanThucTeList(long maHopDong)
        {
            return new ChiTietThanhToanThucTeList(maHopDong);
        }

        private ChiTietThanhToanThucTeList()
        {
            MarkAsChild();
        }

        private ChiTietThanhToanThucTeList(long maHopDong)
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
                    cm.CommandText = "usp_SelecttblChiTietThanhToanThucTesByMaHopDong";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiTietThanhToanThucTe.GetChiTietThanhToanThucTe(dr));
                    }
                }
            }
            

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, HopDongThuChi parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietThanhToanThucTe deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietThanhToanThucTe child in this)
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
