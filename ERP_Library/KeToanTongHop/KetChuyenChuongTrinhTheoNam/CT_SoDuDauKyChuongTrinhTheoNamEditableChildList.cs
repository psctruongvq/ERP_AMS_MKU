using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_SoDuDauKyChuongTrinhTheoNamList : Csla.BusinessListBase<CT_SoDuDauKyChuongTrinhTheoNamList, CT_SoDuDauKyChuongTrinhTheoNam>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_SoDuDauKyChuongTrinhTheoNam item = CT_SoDuDauKyChuongTrinhTheoNam.NewCT_SoDuDauKyChuongTrinhTheoNam();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_SoDuDauKyChuongTrinhTheoNamList NewCT_SoDuDauKyChuongTrinhTheoNamList()
        {
            return new CT_SoDuDauKyChuongTrinhTheoNamList();
        }

        internal static CT_SoDuDauKyChuongTrinhTheoNamList GetCT_SoDuDauKyChuongTrinhTheoNamList(int maKyKetChuyen)
        {
            return new CT_SoDuDauKyChuongTrinhTheoNamList(maKyKetChuyen);
        }

        private CT_SoDuDauKyChuongTrinhTheoNamList()
        {
            MarkAsChild();
        }

        private CT_SoDuDauKyChuongTrinhTheoNamList(int maKyKetChuyen)
        {
            MarkAsChild();
            Fetch(maKyKetChuyen);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(int maKyKetChuyen)
        {

            RaiseListChangedEvents = false;
            using (SqlConnection cn=new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm=cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectCT_SoDuDauKyChuongTrinhTheoNambyMaKyKetChuyen";
                    cm.Parameters.AddWithValue("@MaKyKetChuyen", maKyKetChuyen);
                    using (SafeDataReader dr =new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_SoDuDauKyChuongTrinhTheoNam.GetCT_SoDuDauKyChuongTrinhTheoNam(dr));  
                    }
                }
                
            }
            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, SoDuDauKyChuongTrinhTheoNam parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_SoDuDauKyChuongTrinhTheoNam deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_SoDuDauKyChuongTrinhTheoNam child in this)
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
