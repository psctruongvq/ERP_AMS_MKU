
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ERP_Library.ThanhToan;

namespace ERP_Library
{
    [Serializable()]
    public class DeNghiChuyenKhoan_DichVuList : Csla.BusinessListBase<DeNghiChuyenKhoan_DichVuList, DeNghiChuyenKhoan_DichVu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DeNghiChuyenKhoan_DichVu item = DeNghiChuyenKhoan_DichVu.NewDeNghiChuyenKhoan_DichVu();
            item.MaLoaiChungTu = 201; //Loại Chứng Từ Hóa Đươn Dịch Vụ
            item.LoaiTien = 1;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static DeNghiChuyenKhoan_DichVuList NewDeNghiChuyenKhoan_DichVuList()
        {
            return new DeNghiChuyenKhoan_DichVuList();
        }

        internal static DeNghiChuyenKhoan_DichVuList GetDeNghiChuyenKhoan_DichVuList(SafeDataReader dr)
        {
            return new DeNghiChuyenKhoan_DichVuList(dr);
        }

        public static DeNghiChuyenKhoan_DichVuList GetDeNghiChuyenKhoan_DichVuList(long maDeNghi)
        {
            return DataPortal.Fetch<DeNghiChuyenKhoan_DichVuList>(new FilterCriteria_ByDeNghi(maDeNghi));
        }

        private DeNghiChuyenKhoan_DichVuList()
        {
            MarkAsChild();
        }

        private DeNghiChuyenKhoan_DichVuList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaPhieu;

            public FilterCriteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
            }
        }

        private class FilterCriteria_ByDeNghi
        {
            public long MaDeNghi;

            public FilterCriteria_ByDeNghi(long maDeNghi)
            {
                this.MaDeNghi = maDeNghi;
            }
        }
        #endregion //Filter Criteria

        #region Data Access
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {

            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_DichVusAll";
                }
                else if (criteria is FilterCriteria_ByDeNghi)
                {
                    cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_DichVusByMaDeNghi";
                    cm.Parameters.AddWithValue("@MaDeNghi", ((FilterCriteria_ByDeNghi)criteria).MaDeNghi);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DeNghiChuyenKhoan_DichVu.GetDeNghiChuyenKhoan_DichVu(dr));
                }

            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(DeNghiChuyenKhoan_DichVu.GetDeNghiChuyenKhoan_DichVu(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, DeNghiChuyenKhoan parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (DeNghiChuyenKhoan_DichVu deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (DeNghiChuyenKhoan_DichVu child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }

        public void DataPortal_Delete(SqlTransaction tr)
        {
            foreach (DeNghiChuyenKhoan_DichVu child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}
