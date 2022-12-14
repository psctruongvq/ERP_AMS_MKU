
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class TruyLuongNhanVienList : Csla.BusinessListBase<TruyLuongNhanVienList, TruyLuongNhanVien>
    {
        private int _MaKyTinhLuong;

        private int _IDDefault = -1;
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            TruyLuongNhanVien item = TruyLuongNhanVien.NewTruyLuongNhanVienChild(_IDDefault);
            _IDDefault--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private TruyLuongNhanVienList()
        { /* require use of factory method */ }

        public static TruyLuongNhanVienList NewTruyLuongNhanVienList()
        {
            return new TruyLuongNhanVienList();
        }

        public static TruyLuongNhanVienList GetTruyLuongNhanVienList(int MaKyTinhLuong)
        {
            return DataPortal.Fetch<TruyLuongNhanVienList>(new FilterCriteria(MaKyTinhLuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;
            public FilterCriteria(int maKyTinhLuong)
            {
                MaKyTinhLuong = maKyTinhLuong;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;
            _MaKyTinhLuong = criteria.MaKyTinhLuong;

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

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_TruyLuongNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TruyLuongNhanVien.GetTruyLuongNhanVien(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (TruyLuongNhanVien deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (TruyLuongNhanVien child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access

        public void ThemTruyLuong(ERP_Library.ThemTruyLuongNhanVienChild item, DateTime DenKy)
        {
            if (KiemTraTonTai(item.MaQuyetDinh)) return;

            ERP_Library.TruyLuongNhanVien them = TruyLuongNhanVien.NewTruyLuongNhanVienChild(item.MaQuyetDinh);
            them.TenBoPhan = item.TenBoPhan;
            them.TenNhanVien = item.TenNhanVien;
            them.HeSoCu = item.HeSoCu;
            them.HeSoMoi = item.HeSoMoi;
            them.KyTinhLuongApDung = _MaKyTinhLuong;
            them.NgayHieuLuc = item.NgayHieuLuc;
            them.SoQuyetDinh = item.SoQuyetDinh;
            them.TuKy = new DateTime(item.NgayHieuLuc.Year, item.NgayHieuLuc.Month, 1);
            them.DenKy = DenKy;
            this.Add(them);
        }
        private bool KiemTraTonTai(int MaQuyetDinh)
        {
            //kiểm tra 1 quyết định nâng lương đã được đưa vào danh sách truy lương
            foreach (ERP_Library.TruyLuongNhanVien item in this)
            {
                if (item.MaQuyetDinh == MaQuyetDinh)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Cập nhật lại dữ liệu truy lương
        /// </summary>
        public void XuLyTruyLuong()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Transaction = tr;
                    cm.CommandText = "spd_Insert_TruyLuongNhanVien";
                    try
                    {
                        foreach (TruyLuongNhanVien item in this)
                        {
                            cm.Parameters.Clear();
                            cm.Parameters.AddWithValue("@MaQuyetDinh", item.MaQuyetDinh);
                            cm.Parameters.AddWithValue("@KyTinhLuongApDung", item.KyTinhLuongApDung);
                            cm.Parameters.AddWithValue("@TuKy", item.TuKy);
                            cm.Parameters.AddWithValue("@DenKy", item.DenKy);
                            cm.Parameters.AddWithValue("@SoKy", item.SoKy);
                            cm.Parameters.AddWithValue("@TraLuongQuaTK", item.TraLuongQuaTK);
                            cm.ExecuteNonQuery();
                        }
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        throw ex;
                    }
                }
                cn.Close();
            }
        }
    }
}
