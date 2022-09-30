
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_PhanBoChiPhiCCDCList : Csla.BusinessListBase<CT_PhanBoChiPhiCCDCList, CT_PhanBoChiPhiCCDC>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_PhanBoChiPhiCCDC item = CT_PhanBoChiPhiCCDC.NewCT_PhanBoChiPhiCCDC();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_PhanBoChiPhiCCDCList NewCT_PhanBoChiPhiCCDCList()
        {
            return new CT_PhanBoChiPhiCCDCList();
        }

        internal static CT_PhanBoChiPhiCCDCList GetCT_PhanBoChiPhiCCDCList(int MaPhanBo)
        {
            return new CT_PhanBoChiPhiCCDCList(MaPhanBo, true);
        }
        internal static CT_PhanBoChiPhiCCDCList GetCT_PhanBoChiPhiCCDCNewList(int MaBoPhan)
        {
            return new CT_PhanBoChiPhiCCDCList(MaBoPhan, false);
        }

        internal static CT_PhanBoChiPhiCCDCList GetCT_PhanBoChiPhiCCDCNewList(int MaBoPhan, DateTime ngayPhanBo)
        {
            return new CT_PhanBoChiPhiCCDCList(MaBoPhan, ngayPhanBo);
        }

        internal static CT_PhanBoChiPhiCCDCList GetCT_PhanBoChiPhiCCDCNewList(int MaBoPhan, int maKy)
        {
            return new CT_PhanBoChiPhiCCDCList(MaBoPhan, maKy);
        }

        private CT_PhanBoChiPhiCCDCList()
        {
            MarkAsChild();
        }

        private CT_PhanBoChiPhiCCDCList(int MaPhanBo, bool kieu)
        {
            MarkAsChild();
            Fetch(MaPhanBo, kieu);
        }

        private CT_PhanBoChiPhiCCDCList(int MaPhanBo, DateTime ngayPhanBo)
        {
            MarkAsChild();
            Fetch(MaPhanBo, ngayPhanBo);
        }

        private CT_PhanBoChiPhiCCDCList(int MaPhanBo, int maKy)
        {
            MarkAsChild();
            Fetch(MaPhanBo, maKy);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(int MaPhanBo, bool kieu)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    if (kieu == true)
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblCT_PhanBoChiPhiCCDCsByAndMaPhanBo";
                        cm.Parameters.AddWithValue("@MaPhanBo", MaPhanBo);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(CT_PhanBoChiPhiCCDC.GetCT_PhanBoChiPhiCCDC(dr, true));
                        }
                    }
                    else
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblCT_PhanBoChiPhiCCDCsByAndMaBoPhan";
                        cm.Parameters.AddWithValue("@MaBoPhan", MaPhanBo);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(CT_PhanBoChiPhiCCDC.GetCT_PhanBoChiPhiCCDC(dr, false));
                        }

                    }
                }
            }

            RaiseListChangedEvents = true;
        }

        private void Fetch(int maBoPhan, DateTime ngayPhanBo)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_PhanBoChiPhiCCDCsByAndMaBoPhanandNgayPhanBo";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@NgayPhanBo", ngayPhanBo);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhanBoChiPhiCCDC.GetCT_PhanBoChiPhiCCDC(dr, false));
                    }
                }
            }

            RaiseListChangedEvents = true;
        }

        private void Fetch(int maBoPhan, int maKy)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_PhanBoChiPhiCCDCsByAndMaBoPhanandMaKy";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaKy", maKy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_PhanBoChiPhiCCDC.GetCT_PhanBoChiPhiCCDC(dr, false));
                    }
                }
            }

            RaiseListChangedEvents = true;
        }


        internal void Update(SqlTransaction tr, PhanBoChiPhiCCDC parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_PhanBoChiPhiCCDC deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_PhanBoChiPhiCCDC child in this)
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
