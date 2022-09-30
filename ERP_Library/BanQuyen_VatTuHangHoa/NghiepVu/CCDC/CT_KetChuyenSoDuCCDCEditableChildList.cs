
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_KetChuyenSoDuCCDCList : Csla.BusinessListBase<CT_KetChuyenSoDuCCDCList, CT_KetChuyenSoDuCCDC>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_KetChuyenSoDuCCDC item = CT_KetChuyenSoDuCCDC.NewCT_KetChuyenSoDuCCDC();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static CT_KetChuyenSoDuCCDCList NewCT_KetChuyenSoDuCCDCList()
        {
            return new CT_KetChuyenSoDuCCDCList();
        }

        //internal static CT_KetChuyenSoDuCCDCList GetCT_KetChuyenSoDuCCDCList(SafeDataReader dr)
        //{
        //    return new CT_KetChuyenSoDuCCDCList(dr);
        //}

        internal static CT_KetChuyenSoDuCCDCList GetCT_KetChuyenSoDuCCDCList(int id)
        {
            return new CT_KetChuyenSoDuCCDCList(id);
        }

        public static CT_KetChuyenSoDuCCDCList GetCT_KetChuyenSoDuCCDCListAllbyNam(int nam)
        {
            return new CT_KetChuyenSoDuCCDCList(nam, true);
        }

        internal static CT_KetChuyenSoDuCCDCList GetCT_KetChuyenTonKhoListByMaKyandBoPhan(int maKy, int maBoPhan, int maKho)
        {
            return new CT_KetChuyenSoDuCCDCList(maKy, maBoPhan, maKho);
        }
        private CT_KetChuyenSoDuCCDCList()
        {
            MarkAsChild();
        }

        //private CT_KetChuyenSoDuCCDCList(SafeDataReader dr)
        //{
        //    MarkAsChild();
        //    Fetch(dr);
        //}

        private CT_KetChuyenSoDuCCDCList(int id)
        {
            MarkAsChild();
            Fetch(id);
        }

        private CT_KetChuyenSoDuCCDCList(int nam,bool getAll)
        {
            FetchAllbyNam(nam);
        }

        private CT_KetChuyenSoDuCCDCList(int maKy, int maBoPhan, int maKho)
        {
            MarkAsChild();
            FetchAllbyMaKyandBoPhanandKho(maKy,maBoPhan, maKho);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(int MaKetChuyen)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_KetChuyenSoDuCCDC_MaKetChuyen";//\\
                    cm.Parameters.AddWithValue("@MaKetChuyen", MaKetChuyen);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())                            
                            this.Add(CT_KetChuyenSoDuCCDC.GetCT_KetChuyenSoDuCCDC(dr,true));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        private void FetchAllbyNam(int nam)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_KetChuyenSoDuCCDCListbyNam";//\\
                    cm.Parameters.AddWithValue("@Nam", nam);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_KetChuyenSoDuCCDC.GetCT_KetChuyenSoDuCCDC(dr,true));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        private void FetchAllbyMaKyandBoPhanandKho(int maKy, int maBoPhan, int maKho)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_KetChuyenSoDuCCDCByMaky";//\\
                    cm.Parameters.AddWithValue("@MaKy", maKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_KetChuyenSoDuCCDC.GetCT_KetChuyenSoDuCCDC(dr,false));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }
        internal void Update(SqlTransaction tr, KyKetChuyenSoDuCCDC parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_KetChuyenSoDuCCDC deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_KetChuyenSoDuCCDC child in this)
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
