
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class XacNhanThuNhap_ChiTietList : Csla.BusinessListBase<XacNhanThuNhap_ChiTietList, XacNhanThuNhap_ChiTietChild>
    {
        internal XacNhanThuNhap _parent;
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            XacNhanThuNhap_ChiTietChild item = XacNhanThuNhap_ChiTietChild.NewXacNhanThuNhap_ChiTietChild();
            item._maChiTiet = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides


        #region Factory Methods
        internal static XacNhanThuNhap_ChiTietList NewXacNhanThuNhap_ChiTietList()
        {
            return new XacNhanThuNhap_ChiTietList();
        }

        internal static XacNhanThuNhap_ChiTietList GetXacNhanThuNhap_ChiTietList(SafeDataReader dr)
        {
            return new XacNhanThuNhap_ChiTietList(dr);
        }

        internal static XacNhanThuNhap_ChiTietList GetXacNhanThuNhap_ChiTietList(int MaXacNhan)
        {
            XacNhanThuNhap_ChiTietList item;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandText = "spd_Select_XacNhanThuNhap_ChiTietList";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@MaXacNhan", MaXacNhan);
                SafeDataReader dr = new SafeDataReader(cm.ExecuteReader());
                item = new XacNhanThuNhap_ChiTietList(dr);
                cn.Close();
            }
            return item;
        }

        private XacNhanThuNhap_ChiTietList()
        {
            MarkAsChild();
        }

        private XacNhanThuNhap_ChiTietList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(XacNhanThuNhap_ChiTietChild.GetXacNhanThuNhap_ChiTietChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, XacNhanThuNhap parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (XacNhanThuNhap_ChiTietChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (XacNhanThuNhap_ChiTietChild child in this)
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
