
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVienNgoaiDaiList : Csla.BusinessListBase<NhanVienNgoaiDaiList, NhanVienNgoaiDai>
    {//
        #region BindingList Overrides
        private long iddef = -1;
        protected override object AddNewCore()
        {
            NhanVienNgoaiDai item = NhanVienNgoaiDai.NewNhanVienNgoaiDaiChild();
            item._maNhanVien = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private NhanVienNgoaiDaiList()
        { /* require use of factory method */ }

        public static NhanVienNgoaiDaiList NewNhanVienNgoaiDaiList()
        {
            NhanVienNgoaiDaiList list = new NhanVienNgoaiDaiList();
            return list;
        }

        public static NhanVienNgoaiDaiList GetNhanVienNgoaiDaiList()
        {
            return DataPortal.Fetch<NhanVienNgoaiDaiList>(new FilterCriteria());
        }
        public static NhanVienNgoaiDaiList GetNhanVienNgoaiDaiList(int maBoPhan, int loaiNhanVien)
        {
            return DataPortal.Fetch<NhanVienNgoaiDaiList>(new FilterCriteriabyBoPhan(maBoPhan, loaiNhanVien));
        }

        public static NhanVienNgoaiDaiList GetNhanVienNgoaiDaiList_ByMaBoPhan(int maBoPhan)
        {
            return DataPortal.Fetch<NhanVienNgoaiDaiList>(new FilterCriteriabyMaBoPhan(maBoPhan));
        }
        public static NhanVienNgoaiDaiList GetChungTuThueTNCNNhanVienNgoaiDaiList_ByNgayLapAndMaChungTu(DateTime tuNgay, DateTime denNgay, int maChungTu)
        {
            return DataPortal.Fetch<NhanVienNgoaiDaiList>(new FilterCriteriaByNgayLapAndMaChungTu(tuNgay, denNgay, maChungTu));
        }
        public static NhanVienNgoaiDaiList GetChungTuThueTNCNNhanVienNgoaiDaiListforTienMat_ByNgayLapAndMaChungTu(DateTime tuNgay, DateTime denNgay, long maChungTu)
        {
            return DataPortal.Fetch<NhanVienNgoaiDaiList>(new FilterCriteriaforTienMatByNgayLapAndMaChungTu(tuNgay, denNgay, maChungTu));
        }
        public static NhanVienNgoaiDaiList GetDanhSachChotThuecCongTacVienList_ByMaKyTinhLuong(int maKyTinhLuong)
        {
            return DataPortal.Fetch<NhanVienNgoaiDaiList>(new FilterCriteriaByMaKyTinhLuong(maKyTinhLuong));
        }
        public static NhanVienNgoaiDaiList GetChungTuThueTNCNNhanVienNgoaiDaiList_ByNgayLap(DateTime tuNgay, DateTime denNgay)
        {
            return DataPortal.Fetch<NhanVienNgoaiDaiList>(new FilterCriteriaByNgayLap(tuNgay, denNgay));
        }
        public static NhanVienNgoaiDaiList GetNhanVienNgoaiDaiListBySuDung(bool suDung)
        {
            return DataPortal.Fetch<NhanVienNgoaiDaiList>(new FilterCriteriaBySuDung(suDung));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriabyBoPhan
        {
            public int MaBoPhan;
            public int LoaiNhanVien;
            public FilterCriteriabyBoPhan(int mabophan, int loaiNhanVien)
            {
                this.MaBoPhan = mabophan;
                this.LoaiNhanVien = loaiNhanVien;
            }
        }
        private class FilterCriteriaByMaKyTinhLuong
        {
            public int MaKyTinhLuong;
            public FilterCriteriaByMaKyTinhLuong(int maKyTinhLuong)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
            }
        }

        private class FilterCriteriaByNgayLapAndMaChungTu
        {
            public int MaChungTu;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayLapAndMaChungTu(DateTime tuNgay, DateTime denNgay, int maChungTu)
            {
                this.MaChungTu = maChungTu;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        private class FilterCriteriaforTienMatByNgayLapAndMaChungTu
        {
            public long MaChungTu;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaforTienMatByNgayLapAndMaChungTu(DateTime tuNgay, DateTime denNgay, long maChungTu)
            {
                this.MaChungTu = maChungTu;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        private class FilterCriteriaByNgayLap
        {
            public int MaChungTu;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayLap(DateTime tuNgay, DateTime denNgay)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        private class FilterCriteriabyMaBoPhan
        {
            public int MaBoPhan;
            public FilterCriteriabyMaBoPhan(int mabophan)
            {
                this.MaBoPhan = mabophan;
            }
        }

        private class FilterCriteria
        {

            public FilterCriteria()
            {

            }
        }

        private class FilterCriteriaBySuDung
        {
            public bool SuDung;

            public FilterCriteriaBySuDung(bool suDung)
            {
                this.SuDung = suDung;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
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
                    cm.CommandText = "spd_Select_NhanVienNgoaiDaiList";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVienNgoaiDai.GetNhanVienNgoaiDai(dr));
                    }
                    return;
                }
                if (criteria is FilterCriteriaByMaKyTinhLuong)
                {
                    cm.CommandText = "spd_DanhSachChotThueCongTacVienTheoThang";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByMaKyTinhLuong)criteria).MaKyTinhLuong);
               
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVienNgoaiDai.GetChungTuKhauTruThueNhanVienNgoaiDai(dr));
                    }
                    return;
                }
                if (criteria is FilterCriteriaBySuDung)
                {
                    cm.CommandText = "[spd_Select_NhanVienNgoaiDaiListBySuDung]";
                    cm.Parameters.AddWithValue("@SuDung", ((FilterCriteriaBySuDung)criteria).SuDung);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVienNgoaiDai.GetNhanVienNgoaiDai(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteriabyBoPhan)
                {
                    cm.CommandText = "spd_Select_NhanVienNgoaiDaiListByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriabyBoPhan)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNhanVien", ((FilterCriteriabyBoPhan)criteria).LoaiNhanVien);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVienNgoaiDai.GetNhanVienNgoaiDai(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteriabyMaBoPhan)
                {
                    cm.CommandText = "spd_Select_NhanVienNgoaiDaiListByMaBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriabyMaBoPhan)criteria).MaBoPhan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVienNgoaiDai.GetNhanVienNgoaiDai(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteriaByNgayLapAndMaChungTu)
                {
                    cm.CommandText = "spd_SelectChungTuKhauTruThueThuNhapCaNhanNhanVienNgoaiDai";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLapAndMaChungTu)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLapAndMaChungTu)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByNgayLapAndMaChungTu)criteria).MaChungTu);
                    cm.CommandTimeout = 0;
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        
                        while (dr.Read())
                            this.Add(NhanVienNgoaiDai.GetChungTuKhauTruThueNhanVienNgoaiDai(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteriaforTienMatByNgayLapAndMaChungTu)
                {
                    cm.CommandText = "spd_SelectChungTuKhauTruThueThuNhapCaNhanNhanVienNgoaiDaiforTienMat";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaforTienMatByNgayLapAndMaChungTu)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaforTienMatByNgayLapAndMaChungTu)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaforTienMatByNgayLapAndMaChungTu)criteria).MaChungTu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVienNgoaiDai.GetChungTuKhauTruThueNhanVienNgoaiDai_TienMat(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteriaByNgayLap)
                {
                    cm.CommandText = "spd_SelectTongHopChungTuKhauTruThueThuNhapCaNhanNhanVienNgoaiDai";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap)criteria).DenNgay);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NhanVienNgoaiDai.GetChungTuKhauTruThueNhanVienNgoaiDai(dr));
                    }
                    return;
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
                    foreach (NhanVienNgoaiDai deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NhanVienNgoaiDai child in this)
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
    }
}
