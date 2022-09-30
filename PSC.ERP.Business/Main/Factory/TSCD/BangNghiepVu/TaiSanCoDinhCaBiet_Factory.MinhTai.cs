using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;

namespace PSC_ERP_Business.Main.Factory
{//ccc
    public partial class TaiSanCoDinhCaBiet_Factory
    {

        //Phục vụ duyệt tài sản ///////////////////////////////////////////////////////
        #region Phục vụ duyệt tài sản
        //public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTSCDCaBietTheoPhongBanAndMaTSCD_PhucVuLapDanhSachTSChoDuyet(int maPhongban, int maTSCD, int loaiNghiepVu)
        //{
        //    TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
        //    tempFactory.Context = this.Context;
        //    IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongban);

        //    IQueryable<tblTaiSanCoDinhCaBiet> query = (
        //                                                from o in this.ObjectSet
        //                                                join tspb in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals tspb.MaTSCDCaBiet
        //                                                where
        //                                                    (tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTSCD || maTSCD == 0)
        //                                                    && tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.LaTaiSanCoDinh == true
        //                                                    && (o.ThanhLy ?? false) == false
        //                                                    && o.MaTSCDCaBiet !=
        //                                                    (from y in this.Context.tblDuyetTSCDs
        //                                                     where (y.DaThucHienNghiepVu ?? false) == false && y.MaTSCDCaBiet == tspb.MaTSCDCaBiet
        //                                                        && y.LoaiNghiepVu == loaiNghiepVu
        //                                                     select (y.MaTSCDCaBiet ?? 0)).FirstOrDefault()
        //                                                orderby o.SoHieu ascending
        //                                                select o);

        //    return query;
        //}
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTSCDCaBietTheoPhongBanAndMaTruongAndMaTSCD_PhucVuLapDanhSachTSChoDuyet(int maPhongban,int maViTri, int maTSCD, int loaiNghiepVu)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan_ViTri(maPhongban, maViTri);

            IQueryable<tblTaiSanCoDinhCaBiet> query = (
                                                        from o in this.ObjectSet
                                                        join tspb in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals tspb.MaTSCDCaBiet
                                                        where
                                                            (tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTSCD || maTSCD == 0)
                                                            && tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.LaTaiSanCoDinh == true
                                                            && (o.ThanhLy ?? false) == false
                                                            && o.MaTSCDCaBiet !=
                                                            (from y in this.Context.tblDuyetTSCDs
                                                             where (y.DaThucHienNghiepVu ?? false) == false && y.MaTSCDCaBiet == tspb.MaTSCDCaBiet
                                                                && y.LoaiNghiepVu == loaiNghiepVu
                                                             select (y.MaTSCDCaBiet ?? 0)).FirstOrDefault()
                                                        orderby o.SoHieu ascending
                                                        select o);

            return query;
        }

        //public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTSCDCaBietTheoPhongBanAndMaTruongAndMaTSCD(int maPhongban, int maViTri, int maTSCD, int maCongTy)
        //{
        //    TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
        //    tempFactory.Context = this.Context;
        //    IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan_ViTri(maPhongban, maViTri);

        //    IQueryable<tblTaiSanCoDinhCaBiet> query = (
        //                                                from o in this.ObjectSet
        //                                                join tspb in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals tspb.MaTSCDCaBiet
        //                                                where
        //                                                    (tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTSCD || maTSCD == 0)
        //                                                    && tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.LaTaiSanCoDinh == true
        //                                                    && (o.ThanhLy ?? false) == false
        //                                                    && o.MaCongTy == maCongTy                                                           
        //                                                orderby o.SoHieu ascending
        //                                                select o);

        //    return query;
        //}

        //public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTSCDCaBietTheoPhongBanAndMaTSCDAndLoaiNghiepVu_ChoDuyetVaDaDuyetNhungChuaThucHienNghiepVu(int maPhongban, int maTSCD, int loaiNghiepVu)
        //{
        //    TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
        //    tempFactory.Context = this.Context;
        //    IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongban);

        //    IQueryable<tblTaiSanCoDinhCaBiet> query = (
        //                                                from o in this.ObjectSet
        //                                                join tspb in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals tspb.MaTSCDCaBiet
        //                                                where o.MaTSCDCaBiet ==
        //                                                    (from y in this.Context.tblDuyetTSCDs
        //                                                     where (y.DaThucHienNghiepVu ?? false) == false && y.MaTSCDCaBiet == tspb.MaTSCDCaBiet
        //                                                         //&& (y.DaDuyet ?? false) == false
        //                                                           && y.LoaiNghiepVu == loaiNghiepVu
        //                                                     select (y.MaTSCDCaBiet ?? 0)).FirstOrDefault()
        //                                                    && (tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTSCD || maTSCD == 0)
        //                                                    && tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.LaTaiSanCoDinh == true
        //                                                    && (tspb.MaPhongBan == maPhongban || maPhongban == 0)

        //                                                orderby o.SoHieu ascending
        //                                                select o);
        //    return query;
        //}


        #endregion
        //Phục vụ điều chuyển ngoài ///////////////////////////////////////////////////////
        #region Phục vụ điều chuyển ngoài

        //public void CapNhatTaiSanCoDinhCaBiet_PhucVuThemDieuChuyenNgoai(int maTSCDCB, int maNghiepVuThanhLy)
        //{
        //    var query = (from x in this.ObjectSet
        //                 where x.MaTSCDCaBiet == maTSCDCB
        //                 && (x.MaNghiepVuThanhLy ?? 0) == 0
        //                 select x).FirstOrDefault();
        //    if (query != null)
        //    {
        //        query.ThanhLy = true;
        //        query.NgayThanhLy = this.SystemDate;
        //        query.MaNghiepVuThanhLy = maNghiepVuThanhLy;
        //        this.SaveChanges();
        //    }
        //}

        //public void CapNhatTSCDCaBiet_PhucVuXoaTatCaDieuChuyenNgoaiAndThanhLy(int maTSCDCB)
        //{
        //    var query = (from x in this.ObjectSet
        //                 where x.MaTSCDCaBiet == maTSCDCB
        //                 && (x.MaNghiepVuThanhLy ?? 0) != 0
        //                 && (x.ThanhLy ?? false) == true
        //                 select x).FirstOrDefault();
        //    if (query != null)
        //    {
        //        query.ThanhLy = false;
        //        query.MaNghiepVuThanhLy = null;
        //        query.NgayThanhLy = null;
        //        this.SaveChanges();
        //    }
        //}

        //public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTSCDCaBietTheoMaNghiepVuThanhLy(int maNghiepVuThanhLy)
        //{
        //    IQueryable<tblTaiSanCoDinhCaBiet> query = (
        //                                                from o in this.ObjectSet
        //                                                where o.MaNghiepVuThanhLy == maNghiepVuThanhLy
        //                                                select o);
        //    return query;
        //}

        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaPhongBanAndMaNhomTSAndMaLoaiTSAndMaTSCD_PhucVuInMaVachTaiSan(Int32 maPhongBan, Int32 maNhomTS, Int32 maLoaiTS, Int32 maTaiCoDinh, DateTime tuNgay, DateTime denNgay, Int32 maCongTy)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblTaiSanCoDinhCaBiet> query = (
                                                     from o in this.ObjectSet
                                                     join a in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals a.MaTSCDCaBiet
                                                     where
                                                          (o.ThanhLy ?? false) == false
                                                          && (o.NgayChungTu >= tuNgay && o.NgayChungTu <= denNgay)
                                                         && (o.tblDanhMucTSCD.ID == maTaiCoDinh || maTaiCoDinh == 0)
                                                         && (o.tblDanhMucTSCD.ParentID == maLoaiTS || maLoaiTS == 0)
                                                         && (o.tblDanhMucTSCD.tblDanhMucTSCD2.LoaiTaiSanThuocNhomTaiSan == maNhomTS || maNhomTS == 0)
                                                         && (o.MaCongTy == maCongTy || maCongTy == 0)
                                                            //&& o.MaTSCDCaBiet !=
                                                            // (from x in this.Context.tblInMaVachTaiSanCoDinhCaBiets
                                                            //  where o.MaTSCDCaBiet == x.MaTSCDCaBiet
                                                            //  select (x.MaTSCDCaBiet ?? 0)
                                                            //).FirstOrDefault()
                                                            && o.tblInMaVachTaiSanCoDinhCaBiets.Any(x => x.MaTSCDCaBiet == o.MaTSCDCaBiet) == false
                                                     orderby o.SoHieu ascending
                                                     select o);

            return query;

        }
        #endregion

        #region Phục vụ ngừng và tái sử dụng
        //public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ConSuDung_ByMaPhongBanAndMaTSCD(Int32 maPhongBan, Int32 maTaiCoDinh)
        //{
        //    TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
        //    tempFactory.Context = this.Context;
        //    IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

        //    IQueryable<tblTaiSanCoDinhCaBiet> query = (
        //                                             from o in this.ObjectSet
        //                                             join a in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals a.MaTSCDCaBiet
        //                                             where
        //                                                  (o.ThanhLy ?? false) == false
        //                                                 && (o.tblDanhMucTSCD.ID == maTaiCoDinh || maTaiCoDinh == 0)
        //                                                 && (o.NgungSuDung ?? false) == false

        //                                             orderby o.SoHieu ascending
        //                                             select o);

        //    return query;
        //}

        //public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_NgungSuDung_ByMaPhongBanAndMaTSCD(Int32 maPhongBan, Int32 maTaiCoDinh)
        //{
        //    TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
        //    tempFactory.Context = this.Context;
        //    IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

        //    IQueryable<tblTaiSanCoDinhCaBiet> query = (
        //                                             from o in this.ObjectSet
        //                                             join a in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals a.MaTSCDCaBiet
        //                                             where
        //                                                  (o.ThanhLy ?? false) == false
        //                                                 && (o.tblDanhMucTSCD.ID == maTaiCoDinh || maTaiCoDinh == 0)
        //                                                 && (o.NgungSuDung ?? false) == true
        //                                             orderby o.SoHieu ascending
        //                                             select o);

        //    return query;

        //}
        public Boolean KiemTraTSCDCaBietTrungSoHieu(string soHieu , int maCongTy)
        {
            Boolean result = false;
            result = (from o in this.ObjectSet
                      where o.SoHieu == soHieu && o.MaCongTy == maCongTy
                      select true).SingleOrDefault();
            return result;
        }
        #endregion
    }
}
