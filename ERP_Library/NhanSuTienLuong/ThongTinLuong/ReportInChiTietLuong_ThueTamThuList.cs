
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_ThueTamThuList : Csla.ReadOnlyListBase<InChiTietLuong_ThueTamThuList, InChiTietLuong_ThueTamThuChild>
    {

        #region Factory Methods
        internal static InChiTietLuong_ThueTamThuList GetInChiTietLuong_ThueTamThuList(SafeDataReader dr)
        {
            return new InChiTietLuong_ThueTamThuList(dr);
        }

        private InChiTietLuong_ThueTamThuList(SafeDataReader dr)
        {
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

            while (dr.Read())
                this.Add(InChiTietLuong_ThueTamThuChild.GetInChiTietLuong_ThueTamThuChild(dr));

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
