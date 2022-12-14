//
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{
    [Serializable()]
    public class PhuCapNhanVienList : Csla.BusinessListBase<PhuCapNhanVienList, PhuCapNhanVien>
    {
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            PhuCapNhanVien item = PhuCapNhanVien.NewPhuCapNhanVienChild();
            item._maChiTiet = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private PhuCapNhanVienList()
        { /* require use of factory method */ }

        public static PhuCapNhanVienList NewPhuCapNhanVienList()
        {
            return new PhuCapNhanVienList();
        }

        public static PhuCapNhanVienList GetPhuCapNhanVienList(int MaKyTinhLuong, int MaKyPhuCap, int MaBoPhan, int MaLoaiPhuCap, int MaNhomPC)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteria(MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC));
        }
        public static PhuCapNhanVienList GetPhuCapNhanVienList(int MaKyTinhLuong, int MaKyPhuCap, int MaBoPhan, int MaLoaiPhuCap, int MaNhomPC, int ThanhToan)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteria_ByThanhToan(MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC, ThanhToan));
        }
        public static PhuCapNhanVienList GetPhuCapNhanVienList(long MaChungTu)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteria_ByMaChungTu(MaChungTu));
        }

        public static PhuCapNhanVienList GetNhapPhuCapList(int MaKyTinhLuong, int MaKyPhuCap)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterNhap(MaKyTinhLuong, MaKyPhuCap));
        }
        public static PhuCapNhanVienList GetNhapPhuCapListByKyTinhLuongMaLoaiPhuCap(int MaKyTinhLuong, int MaLoaiPhuCap)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteriaKyTinhLuongKyPhuCap(MaKyTinhLuong, MaLoaiPhuCap));
        }
        public static PhuCapNhanVienList GetNhapPhuCapListByNgay(DateTime TuNgay, DateTime DenNgay,bool thanhToan)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterKhenThuongByNgay(TuNgay,DenNgay,thanhToan));
        }

        public static PhuCapNhanVienList GetNhapPhuCapListByNgay_CacKhoanTruLuong(DateTime TuNgay, DateTime DenNgay)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterPhuCapListByNgay_CacKhoanTruLuong(TuNgay, DenNgay));
        }

        public static PhuCapNhanVienList GetNhapPhuCapByNgay_CacKhoanTruLuong(int maKyTinhLuong, int maLoaiPC,DateTime ngaylap)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterPhuCapByNgay_CacKhoanTruLuong(maKyTinhLuong,maLoaiPC,ngaylap));
        }

        public static PhuCapNhanVienList GetNhapPhuCapListByNgay_MaLoaiChi(DateTime TuNgay, DateTime DenNgay, bool thanhToan,int maLoaiChi)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterKhenThuongByNgay_MaLoaiChi(TuNgay, DenNgay, thanhToan,maLoaiChi));
        }

        public static PhuCapNhanVienList GetNhapPhuCapListByNgay(int maKy, int maLoaiPhuCap, string soQuyetDinh, string maPhieuChi,bool thanhToan)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterKhenThuongIsUpdate(maKy, maLoaiPhuCap, soQuyetDinh, maPhieuChi,thanhToan));
        }

        public static PhuCapNhanVienList GetNhapPhuCapListByNgayChuyenKhoan_MaLoaiChi(int maKy, int maLoaiPhuCap, string soQuyetDinh, string maPhieuChi, bool thanhToan, DateTime ngayLap)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi(maKy, maLoaiPhuCap, soQuyetDinh, maPhieuChi, thanhToan,ngayLap));
        }

        public static PhuCapNhanVienList GetNhapPhuCapListByNgay_MaLoaiChi(int maKy, int maLoaiPhuCap, string soQuyetDinh, string maPhieuChi, bool thanhToan, long maChiThuLao, int maLoaiChi, DateTime ngayLap)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterKhenThuongIsUpdate_MaLoaiChi(maKy, maLoaiPhuCap, soQuyetDinh, maPhieuChi, thanhToan,maChiThuLao,maLoaiChi,ngayLap));
        }

        public static PhuCapNhanVienList GetNhapPhuCapListByDangPhi(int maKy, int maLoaiPhuCap)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteriaByDangPhi(maKy, maLoaiPhuCap));
        }
        public static PhuCapNhanVienList GetNhapPhuCapListUpdateDangPhi(int maKy, int maLoaiPhuCap)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteriaUpdateDangPhi(maKy, maLoaiPhuCap));
        }
        public static PhuCapNhanVienList GetNhapPhuCapListUpdateDangPhi1(int maKy, int maLoaiPhuCap,int maNhom)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteriaUpdateDangPhi1(maKy, maLoaiPhuCap,maNhom));
        }

        public static PhuCapNhanVienList GetPhuCapNhanVienListForUpdateMaPhieuChi(int MaKyTinhLuong, int MaKyPhuCap, int MaBoPhan, int MaLoaiPhuCap, int MaNhomPC)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteriaForUpdateMaPhieuChi(MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC));
        }

        public static PhuCapNhanVienList GetPhuCapNhanVienListTruongHopNghiForUpdateMaPhieuChi(int MaKyTinhLuong, int MaKyPhuCap, int MaBoPhan, int MaLoaiPhuCap, int MaNhomPC)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteriaTruongHopNghiForUpdateMaPhieuChi(MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC));
        }
        public static PhuCapNhanVienList GetPhuCapNhanVienListForTruongHopNghi(int MaKyTinhLuong, int MaKyPhuCap, int MaBoPhan, int MaLoaiPhuCap, int MaNhomPC)
        {
            return DataPortal.Fetch<PhuCapNhanVienList>(new FilterCriteriaForTruongHopNghi(MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaUpdateDangPhi1
        {
            public int MaKyTinhLuong;
            public int MaLoaiPhuCap;
            public int MaNhom;
            public FilterCriteriaUpdateDangPhi1(int maKyTinhLuong, int maLoaiPhuCap,int maNhom)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaLoaiPhuCap = maLoaiPhuCap;
                MaNhom = maNhom;
            }
        }
        [Serializable()]
        private class FilterCriteriaUpdateDangPhi
        {
            public int MaKyTinhLuong, MaLoaiPhuCap;
            public FilterCriteriaUpdateDangPhi(int maKyTinhLuong, int maLoaiPhuCap)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaLoaiPhuCap = maLoaiPhuCap;
            }
        }
         [Serializable()]
        private class FilterCriteriaKyTinhLuongKyPhuCap
        {
            public int MaKyTinhLuong;
            public int  MaLoaiPhuCap;
            public FilterCriteriaKyTinhLuongKyPhuCap(int maKyTinhLuong, int maLoaiPhuCap)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaLoaiPhuCap = maLoaiPhuCap;
            }
        }
        
        [Serializable()]
        private class FilterCriteriaByDangPhi
        {
            public int MaKyTinhLuong,  MaLoaiPhuCap;
            public FilterCriteriaByDangPhi(int maKyTinhLuong, int maLoaiPhuCap)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaLoaiPhuCap = maLoaiPhuCap;
            }
        }


        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC;
            public FilterCriteria(int maKyTinhLuong, int maKyPhuCap, int maBoPhan, int maLoaiPhuCap, int maNhomPC)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaBoPhan = maBoPhan;
                MaLoaiPhuCap = maLoaiPhuCap;
                this.MaNhomPC = maNhomPC;
            }
        }

        [Serializable()]
        private class FilterCriteriaForUpdateMaPhieuChi
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC;
            public FilterCriteriaForUpdateMaPhieuChi(int maKyTinhLuong, int maKyPhuCap, int maBoPhan, int maLoaiPhuCap, int maNhomPC)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaBoPhan = maBoPhan;
                MaLoaiPhuCap = maLoaiPhuCap;
                this.MaNhomPC = maNhomPC;
            }
        }

        [Serializable()]
        private class FilterCriteriaTruongHopNghiForUpdateMaPhieuChi
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC;
            public FilterCriteriaTruongHopNghiForUpdateMaPhieuChi(int maKyTinhLuong, int maKyPhuCap, int maBoPhan, int maLoaiPhuCap, int maNhomPC)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaBoPhan = maBoPhan;
                MaLoaiPhuCap = maLoaiPhuCap;
                this.MaNhomPC = maNhomPC;
            }
        }

        [Serializable()]
        private class FilterCriteriaForTruongHopNghi
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC;
            public FilterCriteriaForTruongHopNghi(int maKyTinhLuong, int maKyPhuCap, int maBoPhan, int maLoaiPhuCap, int maNhomPC)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaBoPhan = maBoPhan;
                MaLoaiPhuCap = maLoaiPhuCap;
                this.MaNhomPC = maNhomPC;
            }
        }

        [Serializable()]
        private class FilterCriteria_ByThanhToan
        {
            public int MaKyTinhLuong, MaKyPhuCap, MaBoPhan, MaLoaiPhuCap, MaNhomPC, ThanhToan;
            public FilterCriteria_ByThanhToan(int maKyTinhLuong, int maKyPhuCap, int maBoPhan, int maLoaiPhuCap, int maNhomPC, int thanhToan)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
                MaBoPhan = maBoPhan;
                MaLoaiPhuCap = maLoaiPhuCap;
                this.MaNhomPC = maNhomPC;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterNhap
        {
            public int MaKyTinhLuong, MaKyPhuCap;
            public FilterNhap(int maKyTinhLuong, int maKyPhuCap)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaKyPhuCap = maKyPhuCap;
            }
        }

        private class FilterKhenThuongByNgay
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool ThanhToan;
            public FilterKhenThuongByNgay(DateTime tuNgay, DateTime denNgay,bool thanhToan)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterPhuCapListByNgay_CacKhoanTruLuong
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterPhuCapListByNgay_CacKhoanTruLuong(DateTime tuNgay, DateTime denNgay)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        private class FilterPhuCapByNgay_CacKhoanTruLuong
        {
            public int MaKyTinhLuong;
            public int MaLoaiPC;
            public DateTime NgayLap;
            public FilterPhuCapByNgay_CacKhoanTruLuong(int maKyTinhLuong,int maLoaiPhuCap,DateTime ngayLap)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaLoaiPC = maLoaiPhuCap;
                this.NgayLap = ngayLap;
            }
        }

        private class FilterKhenThuongByNgay_MaLoaiChi
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool ThanhToan;
            public int MaLoaiChi;
            public FilterKhenThuongByNgay_MaLoaiChi(DateTime tuNgay, DateTime denNgay, bool thanhToan,int maLoaiChi)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.ThanhToan = thanhToan;
                this.MaLoaiChi = maLoaiChi;
            }
        }

        private class FilterKhenThuongIsUpdate
        {
            public int MaKy;
            public int MaLoaiPhuCap;
            public string SoQuyetDinh;
            public string MaPhieuChi;
            public bool ThanhToan;
            public FilterKhenThuongIsUpdate(int maKy, int maLoaiPhuCap, string soQuyetDinh, string maPhieuChi,bool thanhToan)
            {
                this.MaKy = maKy;
                this.MaLoaiPhuCap = maLoaiPhuCap;
                this.SoQuyetDinh = soQuyetDinh;
                this.MaPhieuChi = maPhieuChi;
                this.ThanhToan = thanhToan;
            }
        }

        private class FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi
        {
            public int MaKy;
            public int MaLoaiPhuCap;
            public string SoQuyetDinh;
            public string MaPhieuChi;
            public bool ThanhToan;
            public DateTime NgayLap;
            public FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi(int maKy, int maLoaiPhuCap, string soQuyetDinh, string maPhieuChi, bool thanhToan, DateTime ngayLap)
            {
                this.MaKy = maKy;
                this.MaLoaiPhuCap = maLoaiPhuCap;
                this.SoQuyetDinh = soQuyetDinh;
                this.MaPhieuChi = maPhieuChi;
                this.ThanhToan = thanhToan;
                this.NgayLap = ngayLap;
            }
        }

        private class FilterKhenThuongIsUpdate_MaLoaiChi
        {
            public int MaKy;
            public int MaLoaiPhuCap;
            public string SoQuyetDinh;
            public string MaPhieuChi;
            public bool ThanhToan;
            public long MaChiThuLao;
            public int MaLoaiChi;
            public DateTime NgayLap;
            public FilterKhenThuongIsUpdate_MaLoaiChi(int maKy, int maLoaiPhuCap, string soQuyetDinh, string maPhieuChi, bool thanhToan, long maChiThuLao, int maLoaiChi, DateTime ngayLap)
            {
                this.MaKy = maKy;
                this.MaLoaiPhuCap = maLoaiPhuCap;
                this.SoQuyetDinh = soQuyetDinh;
                this.MaPhieuChi = maPhieuChi;
                this.ThanhToan = thanhToan;
                this.MaChiThuLao = maChiThuLao;
                this.MaLoaiChi = maLoaiChi;
                this.NgayLap = ngayLap;
            }
        }

        private class FilterCriteria_ByMaChungTu
        {
            public long MaChungTu = 0;
            public FilterCriteria_ByMaChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
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
                    try
                    {
                        cm.CommandText = "spd_Select_PhuCapNhanVienList";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteria)criteria).MaKyPhuCap);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteria)criteria).MaLoaiPhuCap);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@MaNhomPC", ((FilterCriteria)criteria).MaNhomPC);

                       
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else if (criteria is FilterCriteriaForUpdateMaPhieuChi)
                {
                    try
                    {
                        cm.CommandText = "spd_Select_PhuCapNhanVienListForUpdateMaPhieuChi";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaForUpdateMaPhieuChi)criteria).MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteriaForUpdateMaPhieuChi)criteria).MaKyPhuCap);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaForUpdateMaPhieuChi)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteriaForUpdateMaPhieuChi)criteria).MaLoaiPhuCap);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@MaNhomPC", ((FilterCriteriaForUpdateMaPhieuChi)criteria).MaNhomPC);


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else if (criteria is FilterCriteriaTruongHopNghiForUpdateMaPhieuChi)
                {
                    try
                    {
                        cm.CommandText = "spd_Select_PhuCapNhanVienListTruongHopNghiForUpdateMaPhieuChi";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaTruongHopNghiForUpdateMaPhieuChi)criteria).MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteriaTruongHopNghiForUpdateMaPhieuChi)criteria).MaKyPhuCap);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaTruongHopNghiForUpdateMaPhieuChi)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteriaTruongHopNghiForUpdateMaPhieuChi)criteria).MaLoaiPhuCap);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@MaNhomPC", ((FilterCriteriaTruongHopNghiForUpdateMaPhieuChi)criteria).MaNhomPC);


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else if (criteria is FilterCriteriaForTruongHopNghi)
                {
                    try
                    {
                        cm.CommandText = "spd_Select_PhuCapNhanVienListForTruongHopNghi";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaForTruongHopNghi)criteria).MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteriaForTruongHopNghi)criteria).MaKyPhuCap);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaForTruongHopNghi)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteriaForTruongHopNghi)criteria).MaLoaiPhuCap);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@MaNhomPC", ((FilterCriteriaForTruongHopNghi)criteria).MaNhomPC);


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else if (criteria is FilterCriteria_ByThanhToan)
                {
                    try
                    {
                        cm.CommandText = "spd_Select_PhuCapNhanVienList_ByThanhToan";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria_ByThanhToan)criteria).MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteria_ByThanhToan)criteria).MaKyPhuCap);
                        cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_ByThanhToan)criteria).MaBoPhan);
                        cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteria_ByThanhToan)criteria).MaLoaiPhuCap);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.Parameters.AddWithValue("@MaNhomPC", ((FilterCriteria_ByThanhToan)criteria).MaNhomPC);
                        cm.Parameters.AddWithValue("@ThanhToan", ((FilterCriteria_ByThanhToan)criteria).ThanhToan);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else if (criteria is FilterCriteriaByDangPhi)
                {
                    //sử dụng không đúng class
                    cm.CommandText = "spd_Select_PhuCapNhanVienListByDangPhi";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByDangPhi)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteriaByDangPhi)criteria).MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@UserID", (ERP_Library.Security.CurrentUser.Info.UserID));
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetPhuCap_DangPhi(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteria_ByMaChungTu)
                {
                    //sử dụng không đúng class
                    cm.CommandText = "spd_Select_PhuCapNhanVienList_ByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByMaChungTu)criteria).MaChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetPhuCapNhanVien(dr));
                    }
                    return;
                }

                else if (criteria is FilterCriteriaUpdateDangPhi)
                {
                    cm.CommandText = "spd_Select_PhuCapNhanVienListUpdateDangPhi";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaUpdateDangPhi)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteriaUpdateDangPhi)criteria).MaLoaiPhuCap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetPhuCapNhanVien(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteriaUpdateDangPhi1)
                {
                    cm.CommandText = "spd_Select_PhuCapNhanVienListUpdateDangPhi1";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaUpdateDangPhi1)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterCriteriaUpdateDangPhi1)criteria).MaNhom);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterCriteriaUpdateDangPhi1)criteria).MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetPhuCapNhanVien(dr));
                    }
                    return;
                }
                else if (criteria is FilterKhenThuongByNgay)
                {
                    //sử dụng không đúng class
                    cm.CommandText = "spd_SelectThuongByNgayLap";                    
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterKhenThuongByNgay)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterKhenThuongByNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterKhenThuongByNgay)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetKhenThuongList(dr));
                    }
                    return;
                }
                else if (criteria is FilterPhuCapByNgay_CacKhoanTruLuong)
                {
                    cm.CommandText = "spd_SelectPhuCapNhanVienListByNgayLap_CacKhoanTruLuong_NotGroup";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterPhuCapByNgay_CacKhoanTruLuong)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaLoaiPC", ((FilterPhuCapByNgay_CacKhoanTruLuong)criteria).MaLoaiPC);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterPhuCapByNgay_CacKhoanTruLuong)criteria).NgayLap);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetPhuCapNhanVien(dr));
                    }
                    return;
                }
                else if (criteria is FilterPhuCapListByNgay_CacKhoanTruLuong)
                {
                    cm.CommandText = "spd_SelectPhuCapNhanVienListByNgayLap_CacKhoanTruLuong";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterPhuCapListByNgay_CacKhoanTruLuong)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterPhuCapListByNgay_CacKhoanTruLuong)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetKhenThuongList(dr));
                    }
                    return;
                }
                else if (criteria is FilterKhenThuongByNgay_MaLoaiChi)
                {
                    //sử dụng không đúng class
                    cm.CommandText = "spd_SelectThuongByNgayLap_MaLoaiChi";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterKhenThuongByNgay_MaLoaiChi)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterKhenThuongByNgay_MaLoaiChi)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterKhenThuongByNgay_MaLoaiChi)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@MaLoaiChi", ((FilterKhenThuongByNgay_MaLoaiChi)criteria).MaLoaiChi);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetKhenThuongList(dr));
                    }
                    return;
                }
                else if (criteria is FilterKhenThuongIsUpdate)
                {
                    cm.CommandText = "spd_SelectThuongIsUpDate";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterKhenThuongIsUpdate)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterKhenThuongIsUpdate)criteria).MaLoaiPhuCap);                    
                    cm.Parameters.AddWithValue("@SoQuyetDinh", ((FilterKhenThuongIsUpdate)criteria).SoQuyetDinh);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterKhenThuongIsUpdate)criteria).MaPhieuChi);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterKhenThuongIsUpdate)criteria).ThanhToan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetPhuCapNhanVien(dr));
                    }
                    return;
                    
                }
                else if (criteria is FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi)
                {
                    cm.CommandText = "spd_SelectThuongIsUpDateChuyenKhoan_MaLoaiChi";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi)criteria).MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@SoQuyetDinh", ((FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi)criteria).SoQuyetDinh);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi)criteria).MaPhieuChi);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterKhenThuongIsUpdateChuyenKhoan_MaLoaiChi)criteria).NgayLap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetPhuCapNhanVien(dr));
                    }
                    return;

                }
                else if (criteria is FilterKhenThuongIsUpdate_MaLoaiChi)
                {
                    cm.CommandText = "spd_SelectThuongIsUpDate_MaLoaiChi";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterKhenThuongIsUpdate_MaLoaiChi)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaLoaiPhuCap", ((FilterKhenThuongIsUpdate_MaLoaiChi)criteria).MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@SoQuyetDinh", ((FilterKhenThuongIsUpdate_MaLoaiChi)criteria).SoQuyetDinh);
                    cm.Parameters.AddWithValue("@MaPhieuChi", ((FilterKhenThuongIsUpdate_MaLoaiChi)criteria).MaPhieuChi);
                    cm.Parameters.AddWithValue("@ThanhToan", ((FilterKhenThuongIsUpdate_MaLoaiChi)criteria).ThanhToan);
                    cm.Parameters.AddWithValue("@MaChiThuLao", ((FilterKhenThuongIsUpdate_MaLoaiChi)criteria).MaChiThuLao);
                    cm.Parameters.AddWithValue("@MaLoaiChi", ((FilterKhenThuongIsUpdate_MaLoaiChi)criteria).MaLoaiChi);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@NgayLap", ((FilterKhenThuongIsUpdate_MaLoaiChi)criteria).NgayLap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhuCapNhanVien.GetPhuCapNhanVien(dr));
                    }
                    return;

                }
                else 
                {
                    cm.CommandText = "spd_Select_NhapPhuCapList";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterNhap)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterNhap)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhuCapNhanVien.GetPhuCapNhanVien(dr));
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
                    foreach (PhuCapNhanVien deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (PhuCapNhanVien child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch(Exception ex)
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update

        public static bool KiemTraBoPhanTheoSoChungTu(string strSoChungTu)
        {
            bool bAll = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraBoPhanTinhThue_PhuCap";
                    cm.Parameters.AddWithValue("@SoChungTu", strSoChungTu);
                    int sodong = Convert.ToInt32(cm.ExecuteNonQuery());
                    if (sodong > 1)
                        bAll = true;
                }
                cn.Close();
            }
            return bAll;
        }

        #endregion //Data Access
    }
}
