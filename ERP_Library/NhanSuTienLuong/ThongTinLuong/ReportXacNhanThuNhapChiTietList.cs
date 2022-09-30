
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class XacNhanThuNhapChiTietList : Csla.ReadOnlyListBase<XacNhanThuNhapChiTietList, XacNhanThuNhapChiTietChild>
    {

        #region Factory Methods
        internal static XacNhanThuNhapChiTietList GetXacNhanThuNhapChiTietList(SafeDataReader dr)
        {
            return new XacNhanThuNhapChiTietList(dr);
        }

        private XacNhanThuNhapChiTietList(SafeDataReader dr)
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
                this.Add(XacNhanThuNhapChiTietChild.GetXacNhanThuNhapChiTietChild(dr));

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
