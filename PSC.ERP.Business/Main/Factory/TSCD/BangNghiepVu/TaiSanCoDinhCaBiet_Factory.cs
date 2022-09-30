using System;
using System.Collections.Generic;
using System.Linq;
using PSC_ERP_Core;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class TaiSanCoDinhCaBiet_Factory : BaseFactory<Entities, tblTaiSanCoDinhCaBiet>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TaiSanCoDinhCaBiet_Factory.New().CreateAloneObject();
        }
        public static TaiSanCoDinhCaBiet_Factory New()
        {
            return new TaiSanCoDinhCaBiet_Factory();
        }
        public TaiSanCoDinhCaBiet_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        //bổ sung ngày 22/12/2015
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ByTenChiTietTSCDCB(string tenChiTiet)
        {
            IQueryable<tblTaiSanCoDinhCaBiet> query = from o in this.ObjectSet
                                                      join ct in this.Context.tblChiTietTaiSanCaBiets on o.MaTSCDCaBiet equals ct.MaTSCDCaBiet
                                                      where ct.TenChiTiet == tenChiTiet
                                                      select o;
            return query;
        }
        //
        public IQueryable<string> Get_PhanBoSauCung_ByMaTSCDCaBietTest(int maTSCDCaBiet)
        {//chua test

            IQueryable<string> obj = (from o in this.ObjectSet
                                                     join pb in this.Context.tblTaiSanCoDinhCaBiet_PhongBan on o.MaTSCDCaBiet equals pb.MaTSCDCaBiet
                                                     join vtri in this.Context.tblBoPhanERPNews on pb.MaViTri equals vtri.MaBoPhan
                                                     where o.MaTSCDCaBiet == maTSCDCaBiet
                                                              orderby pb.NgayPhanBo descending, pb.MaPhanBoSuDung descending
                                                              select vtri.TenBoPhan);

            return obj;
        }
        public static Boolean KiemTraTSCDCaBietDaPhatSinhNghiepVuDieuChuyenNoiBo(Int32 maTSCDCaBiet)
        {
            TaiSanCoDinhCaBiet_Factory factory = TaiSanCoDinhCaBiet_Factory.New();
            Boolean result = factory.Context.tblCT_NghiepVuDieuChuyenNoiBo.Any(x => x.MaTSCDCaBiet == maTSCDCaBiet);
            return result;
        }
        public static Boolean KiemTraTSCDCaBietDaPhatSinhNghiepVuInMaVach(Int32 maTSCDCaBiet)
        {
            TaiSanCoDinhCaBiet_Factory factory = TaiSanCoDinhCaBiet_Factory.New();
            Boolean result = factory.Context.tblInMaVachTaiSanCoDinhCaBiets.Any(x => x.MaTSCDCaBiet == maTSCDCaBiet);
            return result;
        }
        public static Boolean KiemTraTSCDCaBietDaPhatSinhNghiepVuSuaChuaLon(Int32 maTSCDCaBiet)
        {
            TaiSanCoDinhCaBiet_Factory factory = TaiSanCoDinhCaBiet_Factory.New();
            Boolean result = factory.Context.tblCT_NghiepVuSuaChuaLon.Any(x => x.MaTSCDCaBiet == maTSCDCaBiet);
            return result;
        }
        public static Boolean KiemTraTSCDCaBietDaPhatSinhNghiepVuDieuChinhGiaTri(Int32 maTSCDCaBiet)
        {
            TaiSanCoDinhCaBiet_Factory factory = TaiSanCoDinhCaBiet_Factory.New();
            Boolean result = factory.Context.tblChiTietDieuChinhGiaTris.Any(x => x.MaTSCDCaBiet == maTSCDCaBiet);
            return result;
        }
        public static Boolean KiemTraTSCDCaBietDaPhatSinhNghiepLapDeNghi(Int32 maTSCDCaBiet)
        {
            TaiSanCoDinhCaBiet_Factory factory = TaiSanCoDinhCaBiet_Factory.New();
            Boolean result = factory.Context.tblDuyetTSCDs.Any(x => x.MaTSCDCaBiet == maTSCDCaBiet);
            return result;
        }
        public static Boolean KiemTraTSCDCaBietDaPhatSinhNghiepThanhLy(Int32 maTSCDCaBiet)
        {
            TaiSanCoDinhCaBiet_Factory factory = TaiSanCoDinhCaBiet_Factory.New();
            Boolean result = factory.Context.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD.Any(x => x.MaTSCDCaBiet == maTSCDCaBiet);
            return result;
        }
        ///Delete ///////////////////////////////////////////////////////////////////
        #region Delete
        public static void FullDeleteTSCDCaBiet(Entities context, List<Object> deleteList)
        {
            //xóa tài s?n
            foreach (tblTaiSanCoDinhCaBiet item in deleteList)
            {
                //xóa t?t c? các phân b? c?a tài s?n
                TaiSanCoDinhCaBiet_PhongBan_Factory.FullDelete(context, item.tblTaiSanCoDinhCaBiet_PhongBan.ToList<Object>());//BaseFactory<Entities, tblTaiSanCoDinhCaBiet_PhongBan>.DeleteHelper(context, item.tblTaiSanCoDinhCaBiet_PhongBan);

                //taiSanCaBiet.tblChiTietDieuChinhGiaTris.Clear();
                //BaseFactory<Entities, tblChiTietDieuChinhGiaTri>.DeleteHelper(context, item.tblChiTietDieuChinhGiaTris);

                //xóa t?t c? chi ti?t c?a tài s?n
                ChiTietTaiSanCaBiet_Factory.FullDelete(context, item.tblChiTietTaiSanCaBiets.ToList<Object>());//BaseFactory<Entities, tblChiTietTaiSanCaBiet>.DeleteHelper(context, item.tblChiTietTaiSanCaBiets);

                //xóa t?t c? d?ng c? ph? tùng c?a tài s?n
                BoSungDungCuPhuTung_Factory.FullDelete(context, item.tblBoSungDungCuPhuTungs.ToList<Object>());//BaseFactory<Entities, tblBoSungDungCuPhuTung>.DeleteHelper(context, item.tblBoSungDungCuPhuTungs);

                //taiSanCaBiet.tblNghiepVuDanhGiaLais.Clear();
                //BaseFactory<Entities, tblNghiepVuDanhGiaLai>.DeleteHelper(this.Context, taiSanCaBiet.tblNghiepVuDanhGiaLais);

                //xóa duyetTSCD c?a tài s?n
                DuyetTSCD_Factory.FullDelete(context, item.tblDuyetTSCDs.ToList<Object>());//BaseFactory<Entities, tblDuyetTSCD>.DeleteHelper(context, item.tblDuyetTSCDs);

                //xóa nghi?p v? kh?u hao hao mòn c?a tài s?n
                NghiepVuKhauHaoHaoMon_Factory.FullDelete(context, item.tblNghiepVuKhauHaoHaoMons.ToList<Object>());//BaseFactory<Entities, tblNghiepVuKhauHaoHaoMon>.DeleteHelper(context, item.tblNghiepVuKhauHaoHaoMons);

                //xóa chi tiết nguyên giá
                ChiTietNguyenGiaTSCD_Factory.FullDelete(context, item.tblChiTietNguyenGiaTSCDs.ToList<Object>());

                //xóa tài s?n chính sau cùng
                context.tblTaiSanCoDinhCaBiets.DeleteObject(item);
            }
        }

        public static void DeleteTSCDCaBiet(Entities context,tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet )
        {
            //xóa t?t c? các phân b? c?a tài s?n
            TaiSanCoDinhCaBiet_PhongBan_Factory.FullDelete(context, taiSanCoDinhCaBiet.tblTaiSanCoDinhCaBiet_PhongBan.ToList<Object>());//BaseFactory<Entities, tblTaiSanCoDinhCaBiet_PhongBan>.DeleteHelper(context, item.tblTaiSanCoDinhCaBiet_PhongBan);

            //taiSanCaBiet.tblChiTietDieuChinhGiaTris.Clear();
            //BaseFactory<Entities, tblChiTietDieuChinhGiaTri>.DeleteHelper(context, item.tblChiTietDieuChinhGiaTris);

            //xóa t?t c? chi ti?t c?a tài s?n
            ChiTietTaiSanCaBiet_Factory.FullDelete(context, taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets.ToList<Object>());//BaseFactory<Entities, tblChiTietTaiSanCaBiet>.DeleteHelper(context, item.tblChiTietTaiSanCaBiets);

            //xóa t?t c? d?ng c? ph? tùng c?a tài s?n
            BoSungDungCuPhuTung_Factory.FullDelete(context, taiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs.ToList<Object>());//BaseFactory<Entities, tblBoSungDungCuPhuTung>.DeleteHelper(context, item.tblBoSungDungCuPhuTungs);

            //taiSanCaBiet.tblNghiepVuDanhGiaLais.Clear();
            //BaseFactory<Entities, tblNghiepVuDanhGiaLai>.DeleteHelper(this.Context, taiSanCaBiet.tblNghiepVuDanhGiaLais);

            //xóa duyetTSCD c?a tài s?n
            DuyetTSCD_Factory.FullDelete(context, taiSanCoDinhCaBiet.tblDuyetTSCDs.ToList<Object>());//BaseFactory<Entities, tblDuyetTSCD>.DeleteHelper(context, item.tblDuyetTSCDs);

            //xóa nghi?p v? kh?u hao hao mòn c?a tài s?n
            NghiepVuKhauHaoHaoMon_Factory.FullDelete(context, taiSanCoDinhCaBiet.tblNghiepVuKhauHaoHaoMons.ToList<Object>());//BaseFactory<Entities, tblNghiepVuKhauHaoHaoMon>.DeleteHelper(context, item.tblNghiepVuKhauHaoHaoMons);

            //xóa chi tiết nguyên giá
            ChiTietNguyenGiaTSCD_Factory.FullDelete(context, taiSanCoDinhCaBiet.tblChiTietNguyenGiaTSCDs.ToList<Object>());

            //xóa tài s?n chính sau cùng
            context.tblTaiSanCoDinhCaBiets.DeleteObject(taiSanCoDinhCaBiet);
        }
        #endregion

        ///Clone ///////////////////////////////////////////////////////////////////
        #region Clone
        public static tblTaiSanCoDinhCaBiet BasicCloneTSCDCaBiet(tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet)
        {
            tblTaiSanCoDinhCaBiet clonedObject = TaiSanCoDinhCaBiet_Factory.New().CreateAloneObject();
            //copy phần chính
            clonedObject.BaoHiem = taiSanCoDinhCaBiet.BaoHiem;
            clonedObject.Barcode = taiSanCoDinhCaBiet.Barcode;
            clonedObject.ChiPhi = taiSanCoDinhCaBiet.ChiPhi;
            clonedObject.DonGia = taiSanCoDinhCaBiet.DonGia;
            clonedObject.CongSuat = taiSanCoDinhCaBiet.CongSuat;
            clonedObject.KhauHaoNam = taiSanCoDinhCaBiet.KhauHaoNam;
            clonedObject.LaTaiSanCu = taiSanCoDinhCaBiet.LaTaiSanCu;
            clonedObject.LoaiNghiepVu = taiSanCoDinhCaBiet.LoaiNghiepVu;
            clonedObject.LuyKeHaoMon = taiSanCoDinhCaBiet.LuyKeHaoMon;
            clonedObject.LuyKeKhauHao = taiSanCoDinhCaBiet.LuyKeKhauHao;
            clonedObject.MaChungTuGhiTang = taiSanCoDinhCaBiet.MaChungTuGhiTang;
            clonedObject.MaNghiepVuThanhLy = taiSanCoDinhCaBiet.MaNghiepVuThanhLy;
            clonedObject.MaNguon = taiSanCoDinhCaBiet.MaNguon;
            clonedObject.MaNhaCungCap = taiSanCoDinhCaBiet.MaNhaCungCap;
            clonedObject.MaTSCD = taiSanCoDinhCaBiet.MaTSCD;
            clonedObject.MaTSCDCaBiet = taiSanCoDinhCaBiet.MaTSCDCaBiet;
            clonedObject.MucDichSuDung = taiSanCoDinhCaBiet.MucDichSuDung;
            clonedObject.NamSX = taiSanCoDinhCaBiet.NamSX;
            clonedObject.NgayChungTu = taiSanCoDinhCaBiet.NgayChungTu;
            clonedObject.NgayHetHanBaoHanh = taiSanCoDinhCaBiet.NgayHetHanBaoHanh;
            clonedObject.NgayNhan = taiSanCoDinhCaBiet.NgayNhan;
            clonedObject.NgaySuDung = taiSanCoDinhCaBiet.NgaySuDung;
            clonedObject.NgayThanhLy = taiSanCoDinhCaBiet.NgayThanhLy;
            clonedObject.NgungSuDung = taiSanCoDinhCaBiet.NgungSuDung;
            clonedObject.NguonMua = taiSanCoDinhCaBiet.NguonMua;
            clonedObject.NguyenGiaConLai = taiSanCoDinhCaBiet.NguyenGiaConLai;
            clonedObject.NguyenGiaMua = taiSanCoDinhCaBiet.NguyenGiaMua;
            clonedObject.NguyenGiaTinhKhauHao = taiSanCoDinhCaBiet.NguyenGiaTinhKhauHao;
            clonedObject.NhomTaiSanDuAn = taiSanCoDinhCaBiet.NhomTaiSanDuAn;
            clonedObject.LoaiTang = taiSanCoDinhCaBiet.LoaiTang;
            clonedObject.Serial = taiSanCoDinhCaBiet.Serial;
            clonedObject.SoChungTu = taiSanCoDinhCaBiet.SoChungTu;
            clonedObject.SoHieu = taiSanCoDinhCaBiet.SoHieu;
            clonedObject.SoHieuCu = taiSanCoDinhCaBiet.SoHieuCu;
            clonedObject.STT = taiSanCoDinhCaBiet.STT;
            clonedObject.SuDung = taiSanCoDinhCaBiet.SuDung;
            clonedObject.TaiKhoanDoiUng = taiSanCoDinhCaBiet.TaiKhoanDoiUng;
            clonedObject.TaiSanTinhBaoHiem = taiSanCoDinhCaBiet.TaiSanTinhBaoHiem;
            clonedObject.ThanhLy = taiSanCoDinhCaBiet.ThanhLy;
            clonedObject.ThoiGianSuDung = taiSanCoDinhCaBiet.ThoiGianSuDung;
            clonedObject.ViTri = taiSanCoDinhCaBiet.ViTri;
            clonedObject.GhiChu = taiSanCoDinhCaBiet.GhiChu;
            clonedObject.TinhKHHMCaBiet = taiSanCoDinhCaBiet.TinhKHHMCaBiet;
            clonedObject.PhanTramThue = taiSanCoDinhCaBiet.PhanTramThue;
            clonedObject.TienThue = taiSanCoDinhCaBiet.TienThue;
            clonedObject.MaTaiKhoan = taiSanCoDinhCaBiet.MaTaiKhoan;
            clonedObject.LaCCDC = taiSanCoDinhCaBiet.LaCCDC;
            clonedObject.MaCongTy = taiSanCoDinhCaBiet.MaCongTy;
            clonedObject.TinhTrang = taiSanCoDinhCaBiet.TinhTrang;
            clonedObject.TenCaBiet = taiSanCoDinhCaBiet.TenCaBiet;
            clonedObject.Model = taiSanCoDinhCaBiet.Model;
            clonedObject.CPU = taiSanCoDinhCaBiet.CPU;
            clonedObject.ChungLoai = taiSanCoDinhCaBiet.ChungLoai;
            clonedObject.RAM = taiSanCoDinhCaBiet.RAM;
            clonedObject.OCung = taiSanCoDinhCaBiet.OCung;
            clonedObject.MaDonViTinh = taiSanCoDinhCaBiet.MaDonViTinh;
            clonedObject.MaQuocGia = taiSanCoDinhCaBiet.MaQuocGia;
            clonedObject.ChiPhiCoThue = taiSanCoDinhCaBiet.ChiPhiCoThue;
            clonedObject.TongNguyenGiaCoThue = taiSanCoDinhCaBiet.TongNguyenGiaCoThue;
            clonedObject.TongNguyenGiaKhongThue = taiSanCoDinhCaBiet.TongNguyenGiaKhongThue;
            clonedObject.SoHoaDon = taiSanCoDinhCaBiet.SoHoaDon;
            clonedObject.SoHopDong = taiSanCoDinhCaBiet.SoHopDong;
            clonedObject.MaTaiKhoanPhanBo = taiSanCoDinhCaBiet.MaTaiKhoanPhanBo;
            //copy chi tiết
            //taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets
            for (int i = 0; i < taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets.Count; i++)
            {
                tblChiTietTaiSanCaBiet chiTiet = taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets.ElementAt(i);
                //
                tblChiTietTaiSanCaBiet clonedChiTiet = ChiTietTaiSanCaBiet_Factory.BasicCloneChiTietTaiSan(chiTiet);
                clonedObject.tblChiTietTaiSanCaBiets.Add(clonedChiTiet);
            }
            //
            //copy dung cu phu tung//new
            for (int i = 0; i < taiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs.Count; i++)
            {
                tblBoSungDungCuPhuTung phuTung = taiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs.ElementAt(i);
                //
                tblBoSungDungCuPhuTung clonedPhuTung = BoSungDungCuPhuTung_Factory.BasicClonePhuTungGhiTang(phuTung);
                clonedObject.tblBoSungDungCuPhuTungs.Add(clonedPhuTung);
            }

            return clonedObject;
        }
        //public static tblChiTietTaiSanCaBiet BasicCloneChiTietTaiSanCaBiet(tblChiTietTaiSanCaBiet chiTietTaiSanCaBiet)
        //{
        //    tblChiTietTaiSanCaBiet clonedObject = ChiTietTaiSanCaBiet_Factory.New().CreateAloneObject();
        //    //clonedObject.LaChiTietSuaChuaLon = chiTietTaiSanCaBiet.LaChiTietSuaChuaLon;
        //    clonedObject.MaChiTiet = chiTietTaiSanCaBiet.MaChiTiet;
        //    clonedObject.MaDVT = chiTietTaiSanCaBiet.MaDVT;
        //    clonedObject.MaQuocGiaSX = chiTietTaiSanCaBiet.MaQuocGiaSX;
        //    clonedObject.MaTSCDCaBiet = chiTietTaiSanCaBiet.MaTSCDCaBiet;
        //    clonedObject.Model = chiTietTaiSanCaBiet.Model;
        //    clonedObject.NamSanXuat = chiTietTaiSanCaBiet.NamSanXuat;
        //    clonedObject.NguyenGia = chiTietTaiSanCaBiet.NguyenGia;
        //    clonedObject.PmCuMaDVT = chiTietTaiSanCaBiet.PmCuMaDVT;
        //    clonedObject.PmCuMaQuocGiaSX = chiTietTaiSanCaBiet.PmCuMaQuocGiaSX;
        //    clonedObject.Serial = chiTietTaiSanCaBiet.Serial;

        //    clonedObject.SoLuong = chiTietTaiSanCaBiet.SoLuong;
        //    clonedObject.TenChiTiet = chiTietTaiSanCaBiet.TenChiTiet;
            
        //    //{
        //    //    String maxSoHieu = "";
        //    //    //String maxSoHieuIncreasePart = "";
        //    //    Int32 maxSoHieuIncreasePart_Int32 = 0;
        //    //    Int32 sizeof_IncreasePart = PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart;
        //    //    foreach (var taiSanCaBiet in chiTietTaiSanCaBiet.tblTaiSanCoDinhCaBiet.tblChungTu.tblTaiSanCoDinhCaBiets)
        //    //    {
        //    //        foreach (var chiTiet in taiSanCaBiet.tblChiTietTaiSanCaBiets)
        //    //        {
        //    //            if (String.IsNullOrWhiteSpace(maxSoHieu))
        //    //            {
        //    //                maxSoHieu = chiTiet.SoHieu;

        //    //            }
        //    //            else
        //    //            {
        //    //                String currentIncreasePart = chiTiet.SoHieu.Substring(chiTiet.SoHieu.Length - sizeof_IncreasePart, sizeof_IncreasePart);
        //    //                if (Convert.ToInt32(currentIncreasePart) > maxSoHieuIncreasePart_Int32)
        //    //                {
        //    //                    maxSoHieu = chiTiet.SoHieu;
        //    //                }
        //    //            }
        //    //            String maxSoHieuIncreasePart = maxSoHieu.Substring(maxSoHieu.Length - sizeof_IncreasePart, sizeof_IncreasePart);
        //    //            maxSoHieuIncreasePart_Int32 = Convert.ToInt32(maxSoHieuIncreasePart);
        //    //        }
        //    //    }

        //    //    clonedObject.SoHieu = ChiTietTaiSanCaBiet_Factory.IncreaseSoHieuChiTietTaiSanCaBiet(maxSoHieu);
        //    //}            

        //    return clonedObject;
        //}
        //public static tblBoSungDungCuPhuTung BasicClonePhuTung(tblBoSungDungCuPhuTung dungCuPhuTung)
        //{
        //    tblBoSungDungCuPhuTung clonedObject = BoSungDungCuPhuTung_Factory.New().CreateAloneObject();
        //    clonedObject.MaDungCuPhuTung = dungCuPhuTung.MaDungCuPhuTung;
        //    clonedObject.ChiPhi = dungCuPhuTung.ChiPhi;
        //    clonedObject.DonGia = dungCuPhuTung.DonGia;
        //    clonedObject.GhiChu = dungCuPhuTung.GhiChu;
        //    clonedObject.LaDCPTSuaChuaLon = dungCuPhuTung.LaDCPTSuaChuaLon;
        //    clonedObject.MaChiTietNghiepVuSuaChuaLon = dungCuPhuTung.MaChiTietNghiepVuSuaChuaLon;

        //    clonedObject.MaDVT = dungCuPhuTung.MaDVT;
        //    clonedObject.MaQuanLy = dungCuPhuTung.MaQuanLy;
        //    clonedObject.MaTSCDCaBiet = dungCuPhuTung.MaTSCDCaBiet;
        //    clonedObject.NgayNhan = dungCuPhuTung.NgayNhan;
        //    clonedObject.NgaySuDung = dungCuPhuTung.NgaySuDung;
            
        //    clonedObject.SoLuong = dungCuPhuTung.SoLuong;
        //    clonedObject.Ten = dungCuPhuTung.Ten;
        //    clonedObject.TongGiaTri = dungCuPhuTung.TongGiaTri;
        //    clonedObject.UserID = dungCuPhuTung.UserID;
        //    return clonedObject;
        //}
        #endregion

        //By SoChungTu ///////////////////////////////////////////////////////////////////
        #region By MaChungTuGhiTang
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSach_TaiSanCoDinhCaBiet_ByMaChungTuGhiTang(Double maChungTuGhiTang)
        {
            IQueryable<tblTaiSanCoDinhCaBiet> query = (from o in this.ObjectSet
                                                       where o.MaChungTuGhiTang == maChungTuGhiTang
                                                       select o);
            return query;
        }

        #endregion

        //By SoChungTu ///////////////////////////////////////////////////////////////////
        #region By SoChungTu
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSach_TaiSanCoDinhCaBiet_BySoChungTu(String soChungTu)
        {
            IQueryable<tblTaiSanCoDinhCaBiet> query = (from o in this.ObjectSet
                                                       where o.SoChungTu == soChungTu
                                                       select o);
            return query;
        }
        
        #endregion
        ///Số hiệu ///////////////////////////////////////////////////////////////////
        #region Số hiệu
        public static String IncreaseSoHieuTSCDCaBiet(String soHieu)
        {
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuTSCDCaBiet_IncreasePart;
            string leftPart = soHieu.Substring(0, soHieu.Length - sizeOfNumber);

            string soHieuMoi = "";//String.Format("{0}{1}1", leftPart, new String('0', sizeOfNumber - 1));

            int max = int.Parse(soHieu.Substring(soHieu.Length - sizeOfNumber, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            soHieuMoi = leftPart + stringSoMoi;

            return soHieuMoi;

        }
        private String CreateFirst_SoHieuTSCDCaBiet_ofTSCD(int maTSCD)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuTSCDCaBiet_IncreasePart;

            String maQuanLyTSCD = (from o in this.Context.tblDanhMucTSCDs
                                   where o.LaTaiSanCoDinh == true
                                   && o.ID == maTSCD
                                   select o.MaQuanLy).SingleOrDefault();

            result = String.Format("{0}{1}1", maQuanLyTSCD, new String('0', sizeOfNumber - 1));

            return result;
        }
        private String Get_MaxSoHieuTSCDCaBiet_ByMaTSCD(int maTSCD)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuTSCDCaBiet_IncreasePart;
            String soHieu = (from o in this.ObjectSet
                             where o.MaTSCD == maTSCD
                             && o.MaCongTy== maCongTy
                             //&& o.MaTSCD == (from x in this.Context.tblDanhMucTSCDs
                             //                where o.MaTSCD == x.ID && x.LaTaiSanCoDinh == true
                             //                select x.ID).FirstOrDefault()
                             orderby o.SoHieu.Substring(o.SoHieu.Length - sizeOfNumber, sizeOfNumber) descending
                             select o.SoHieu).FirstOrDefault();

            return soHieu;
        }
        public String Get_NextSoHieuTSCDCaBiet_ByMaTSCD(int maTSCD)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_SoHieuTSCDCaBiet_IncreasePart;
            String result = "";
            
            String maxSoHieu = Get_MaxSoHieuTSCDCaBiet_ByMaTSCD(maTSCD);

            if (!String.IsNullOrWhiteSpace(maxSoHieu))
                result = IncreaseSoHieuTSCDCaBiet(maxSoHieu);
            else
                result = CreateFirst_SoHieuTSCDCaBiet_ofTSCD(maTSCD);

            return result;
        }
        #endregion
        //By Nhóm ///////////////////////////////////////////////////////////////////
        #region By Nhóm
        public Boolean Any_TaiSanCoDinhCaBiet_ByMaNhomTaiSan(int maNhomTaiSan)
        {
            String maNhomTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maNhomTaiSan && dm.LaNhomTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            Boolean query = (from o in this.ObjectSet
                             where o.tblDanhMucTSCD.MaQuanLy.StartsWith(maNhomTaiSanQuanLy)
                             select true).FirstOrDefault();
            return query;
        }
        public Int32 Count_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaNhomTaiSan(int maNhomTaiSan)
        {
            String maNhomTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maNhomTaiSan && dm.LaNhomTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            Int32 query = (from o in this.ObjectSet
                           where (o.ThanhLy ?? false) == false
                               && o.tblDanhMucTSCD.MaQuanLy.StartsWith(maNhomTaiSanQuanLy)
                           group o by true into g
                           select g.Count()).SingleOrDefault();
            return query;
        }
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaNhomTaiSan(int maNhomTaiSan)
        {
            String maNhomTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maNhomTaiSan && dm.LaNhomTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            var query = from o in this.ObjectSet
                        where (o.ThanhLy ?? false) == false
                            && o.tblDanhMucTSCD.MaQuanLy.StartsWith(maNhomTaiSanQuanLy)
                        select o;
            return query;
        }
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ByMaNhomTaiSan(int maNhomTaiSan)
        {
            String maNhomTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maNhomTaiSan && dm.LaNhomTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            IQueryable<tblTaiSanCoDinhCaBiet> query = from o in this.ObjectSet
                                                      where o.tblDanhMucTSCD.MaQuanLy.StartsWith(maNhomTaiSanQuanLy)
                                                      select o;
            return query;
        }
        #endregion
        //By Loại //////////////////////////////////////////////////////////
        #region By Loại
        public Boolean Any_TaiSanCoDinhCaBiet_ByMaLoaiTaiSan(int maLoaiTaiSan)
        {
            String maLoaiTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maLoaiTaiSan && dm.LaLoaiTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            Boolean query = (from o in this.ObjectSet
                             where o.tblDanhMucTSCD.MaQuanLy.StartsWith(maLoaiTaiSanQuanLy)
                             select true).FirstOrDefault();
            return query;
        }
        public Int32 Count_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaLoaiTaiSan(int maLoaiTaiSan)
        {
            String maLoaiTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maLoaiTaiSan && dm.LaLoaiTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            Int32 query = (from o in this.ObjectSet
                           where (o.ThanhLy ?? false) == false
                               && o.tblDanhMucTSCD.MaQuanLy.StartsWith(maLoaiTaiSanQuanLy)
                           group o by true into g
                           select g.Count()).SingleOrDefault();
            return query;
        }
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaLoaiTaiSan(int maLoaiTaiSan)
        {
            String maLoaiTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maLoaiTaiSan && dm.LaLoaiTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            var query = from o in this.ObjectSet
                        where (o.ThanhLy ?? false) == false
                            && o.tblDanhMucTSCD.MaQuanLy.StartsWith(maLoaiTaiSanQuanLy)
                        select o;
            return query;
        }

        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ByMaLoaiTaiSan(int maLoaiTaiSan)
        {
            String maLoaiTaiSanQuanLy = (from dm in Context.tblDanhMucTSCDs where dm.ID == maLoaiTaiSan && dm.LaLoaiTaiSan == true select dm.MaQuanLy).SingleOrDefault();

            var query = from o in this.ObjectSet
                        where o.tblDanhMucTSCD.MaQuanLy.StartsWith(maLoaiTaiSanQuanLy)
                        select o;
            return null;
        }
        #endregion

        //By TSCD /////////////////////////////////////////
        #region By TSCD
        public Boolean Any_TaiSanCoDinhCaBiet_ByMaTSCD(int maTSCD)
        {
            Boolean query = (from o in this.ObjectSet
                             where o.MaTSCD == maTSCD
                             select true).FirstOrDefault();
            return query;
        }
        public Int32 Count_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaTSCD(int maTSCD)
        {
            Int32 query = (from o in this.ObjectSet
                           where o.MaTSCD == maTSCD
                             && (o.ThanhLy ?? false) == false
                           group o by true into g
                           select g.Count()).SingleOrDefault();
            return query;
        }
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaTSCD(int maTSCD)
        {
            IQueryable<tblTaiSanCoDinhCaBiet> query = from o in this.ObjectSet
                                                      where o.MaTSCD == maTSCD
                                                        && (o.ThanhLy ?? false) == false
                                                        && (o.MaCongTy == maCongTy)
                                                      select o;
            return query;
        }
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ByMaTSCD(int maTSCD)
        {
            IQueryable<tblTaiSanCoDinhCaBiet> query = from o in this.ObjectSet
                                                      where o.MaTSCD == maTSCD
                                                      select o;
            return query;
        }
        public tblTaiSanCoDinhCaBiet Get_TaiSanCoDinhCaBiet_BySoHieu(string soHieu)
        {
            tblTaiSanCoDinhCaBiet obj = (from o in this.ObjectSet
                                         where o.SoHieu == soHieu && o.MaCongTy == maCongTy
                                         select o).SingleOrDefault();
            return obj;
        }
        public tblTaiSanCoDinhCaBiet Get_TaiSanCoDinhCaBiet_BySoHieuCu(string soHieuCu)
        {
            try
            {
                tblTaiSanCoDinhCaBiet obj = (from o in this.ObjectSet
                                             where o.SoHieuCu == soHieuCu && o.MaCongTy == maCongTy
                                             select o).First();
                return obj;
            }
            catch (Exception)
            {

                return null;
            }
           
        }
        public tblTaiSanCoDinhCaBiet Get_TaiSanCoDinhCaBiet_ByMaTSCDCaBiet(Int32 maTSCDCaBiet)
        {
            tblTaiSanCoDinhCaBiet obj = (from o in this.ObjectSet
                                         where o.MaTSCDCaBiet == maTSCDCaBiet
                                         select o).SingleOrDefault();
            return obj;
        }
        #endregion

        //By Phòng ban /////////////////////////////////////////
        #region By Phòng ban
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTSCDCaBietTheoPhongBan(int maPhongban)
        {//tài s?n dang hi?n h?u ? phòng ban

            IQueryable<tblTaiSanCoDinhCaBiet> query = (
                                                        from o in this.ObjectSet
                                                        join tspb in this.Context.tblTaiSanCoDinhCaBiet_PhongBan on o.MaTSCDCaBiet equals tspb.MaTSCDCaBiet
                                                        where tspb.MaPhongBan == maPhongban
                                                                   && tspb.MaPhanBoSuDung ==
                                                                       (from x in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
                                                                        where x.MaTSCDCaBiet == tspb.MaTSCDCaBiet
                                                                        orderby x.NgayPhanBo descending, x.MaPhanBoSuDung descending
                                                                        select x.MaPhanBoSuDung).FirstOrDefault()
                                                        orderby o.SoHieu ascending
                                                        select o);

            return query;
        }

        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTSCDCaBietTheoPhongBanAndMaTSCD(int maPhongban, int maTSCD)
        {
            IQueryable<tblTaiSanCoDinhCaBiet> query = (
                                                        from o in this.ObjectSet
                                                        join tspb in this.Context.tblTaiSanCoDinhCaBiet_PhongBan on o.MaTSCDCaBiet equals tspb.MaTSCDCaBiet
                                                        where (tspb.MaPhongBan == maPhongban || maPhongban == 0)
                                                                   && tspb.MaPhanBoSuDung ==
                                                                       (from x in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
                                                                        where x.MaTSCDCaBiet == tspb.MaTSCDCaBiet
                                                                        orderby x.NgayPhanBo descending, x.MaPhanBoSuDung descending
                                                                        select x.MaPhanBoSuDung).FirstOrDefault()
                                                            && (tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTSCD || maTSCD == 0)
                                                        //&& tspb.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.LaTaiSanCoDinh == true

                                                        orderby o.SoHieu ascending
                                                        select o);

            return query;
        }
        #endregion
        public decimal LuyKeKhauHaoCuaTaiSanCaBietDenNgay(Int32 maTSCDCaBiet, DateTime denNgay)
        {
            Decimal? luyKeKhauHao_TrongNghiepVuKHHM = (from o in this.Context.tblNghiepVuKhauHaoHaoMons
                                                       where o.MaTSCDCaBiet == maTSCDCaBiet
                                                         && o.LoaiKHHM == false//khấu hao
                                                         && o.tblKy.NgayKetThuc <= denNgay
                                                       group o by o.MaTSCDCaBiet into g
                                                       select g.Sum(x => x.SoTien)).SingleOrDefault();

            Decimal? luyKeKhauHao_DauTienTrongChiTietNguyenGia = (from o in this.Context.tblChiTietNguyenGiaTSCDs
                                                                  where o.MaTSCDCaBiet == maTSCDCaBiet
                                                                   && o.NgayThucHien <= denNgay
                                                                  orderby o.MaChiTiet ascending
                                                                  select o.LuyKeKhauHao).FirstOrDefault();
            //cộng 2 kq lại
            Decimal kq = (luyKeKhauHao_TrongNghiepVuKHHM ?? 0)
               + (luyKeKhauHao_DauTienTrongChiTietNguyenGia ?? 0)
                ;
            return kq;
        }
        public tblTaiSanCoDinhCaBiet Get_TrucTiepTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaTSCDCB(int maTSCDCB)
        {
            tblTaiSanCoDinhCaBiet query = (from o in this.ObjectSet
                                           where //(o.ThanhLy ?? false) == false &&
                                                o.MaTSCDCaBiet == maTSCDCB
                                           select o).SingleOrDefault();
            return query;
        }

        public decimal LuyKeHaoMonCuaTaiSanCaBietDenNgay(Int32 maTSCDCaBiet, DateTime denNgay)
        {
            Decimal? luyKeHaoMon_TrongNghiepVuKHHM = (from o in this.Context.tblNghiepVuKhauHaoHaoMons
                                                      where o.MaTSCDCaBiet == maTSCDCaBiet
                                                        && o.LoaiKHHM == true//hao mòn
                                                         && o.tblKy.NgayKetThuc <= denNgay
                                                      group o by o.MaTSCDCaBiet into g
                                                      select g.Sum(x => x.SoTien)).SingleOrDefault();

            Decimal? luyKeHaoMon_DauTienTrongChiTietNguyenGia = (from o in this.Context.tblChiTietNguyenGiaTSCDs
                                                                 where o.MaTSCDCaBiet == maTSCDCaBiet
                                                                    && o.NgayThucHien <= denNgay
                                                                 orderby o.MaChiTiet ascending
                                                                 select o.LuyKeHaoMon).FirstOrDefault();
            //cộng 2 kq lại
            Decimal kq = (luyKeHaoMon_TrongNghiepVuKHHM ?? 0)
               + (luyKeHaoMon_DauTienTrongChiTietNguyenGia ?? 0)
                ;

            return kq;
        }
        public decimal Get_TongNguyenGiaCuaTaiSanCaBiet_BySoHieuTaiKhoanAndNgayChot(DateTime ngayChot, string soHieuTK)
        {
            Decimal nguyenGiaTSCDCaBiet = 0;
            Decimal? nguyenGiaCuaTaiSanCaBiet = (from o in this.ObjectSet
                                                 join a in this.Context.tblChiTietNguyenGiaTSCDs on o.MaTSCDCaBiet equals a.MaTSCDCaBiet
                                                 where o.TaiKhoanDoiUng == soHieuTK
                                                    && a.NgayThucHien <= ngayChot
                                                          && (
                                                                 (
                                                                   (o.ThanhLy ?? false) == false //&&
                                                                    //a.NgayThucHien <= ngayChot
                                                                 )
                                                              ||
                                                                 (
                                                                   (o.ThanhLy ?? false) == true &&
                                                                    o.NgayThanhLy > ngayChot
                                                                 )
                                                             )
                                                 group a by o.TaiKhoanDoiUng into g
                                                 select g.Sum(x => x.SoTien)).SingleOrDefault();
            if (nguyenGiaCuaTaiSanCaBiet != null)
                nguyenGiaTSCDCaBiet = nguyenGiaCuaTaiSanCaBiet.Value;

            return nguyenGiaTSCDCaBiet;
        }
        public decimal Get_TongNguyenGiaCuaTaiSanCaBiet_BySoHieuTaiKhoanAndNamKhauHao(Int32 namKhauHao, string soHieuTK)
        {
            DateTime ngayDauTienCuaNam = Convert.ToDateTime("01/01/" + namKhauHao);
            Decimal nguyenGiaTSCDCaBiet = 0;
            Decimal? nguyenGiaCuaTaiSanCaBiet = (from o in this.ObjectSet
                                                 join a in this.Context.tblChiTietNguyenGiaTSCDs on o.MaTSCDCaBiet equals a.MaTSCDCaBiet
                                                 where o.TaiKhoanDoiUng == soHieuTK
                                                          && a.NgayThucHien < ngayDauTienCuaNam
                                                          && (
                                                                 (
                                                                   (o.ThanhLy ?? false) == false //&&
                                                                    //a.NgayThucHien < ngayDauTienCuaNam
                                                                 )
                                                              ||
                                                                 (
                                                                   (o.ThanhLy ?? false) == true &&
                                                                    o.NgayThanhLy >= ngayDauTienCuaNam
                                                                 )
                                                             )
                                                 group a by o.TaiKhoanDoiUng into g
                                                 select g.Sum(x => x.SoTien)).SingleOrDefault();
            if (nguyenGiaCuaTaiSanCaBiet != null)
                nguyenGiaTSCDCaBiet = nguyenGiaCuaTaiSanCaBiet.Value;

            return nguyenGiaTSCDCaBiet;
        }

        //27/09/2016
        public decimal Get_TongNguyenGiaCuaTaiSanCaBiet_ByMaTSCDCB_DenNgay(DateTime denNgay, Int32 maTSCDCB)
        {
            Decimal nguyenGiaTSCDCaBiet = 0;
            Decimal? nguyenGiaCuaTaiSanCaBiet = (from o in this.ObjectSet
                                                 join a in this.Context.tblChiTietNguyenGiaTSCDs on o.MaTSCDCaBiet equals a.MaTSCDCaBiet
                                                 where o.MaTSCDCaBiet == maTSCDCB
                                                    && a.NgayThucHien <= denNgay
                                                          && (
                                                                 (
                                                                   (o.ThanhLy ?? false) == false //&&
                                                     //a.NgayThucHien <= ngayChot
                                                                 )
                                                              ||
                                                                 (
                                                                   (o.ThanhLy ?? false) == true &&
                                                                    o.NgayThanhLy > denNgay
                                                                 )
                                                             )
                                                 group a by o.TaiKhoanDoiUng into g
                                                 select g.Sum(x => x.SoTien)).SingleOrDefault();
            if (nguyenGiaCuaTaiSanCaBiet != null)
                nguyenGiaTSCDCaBiet = nguyenGiaCuaTaiSanCaBiet.Value;

            return nguyenGiaTSCDCaBiet;
        }

        #endregion

        #region bảo trì bảo dưỡng
        public IQueryable<tblTaiSanCoDinhCaBiet> Get_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaPhongBanAndMaNhomTSAndMaLoaiTSAndMaTSCD(Int32 maPhongBan, Int32 maNhomTS, Int32 maLoaiTS, Int32 maTSCD, DateTime tuNgay, DateTime denNgay)
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
                                                         && (o.tblDanhMucTSCD.ID == maTSCD || maTSCD == 0)
                                                         && (o.tblDanhMucTSCD.ParentID == maLoaiTS || maLoaiTS == 0)
                                                         && (o.tblDanhMucTSCD.tblDanhMucTSCD2.LoaiTaiSanThuocNhomTaiSan == maNhomTS || maNhomTS == 0)
                                                     orderby o.SoHieu ascending
                                                     select o);

            return query;
        }
        #endregion
    }//end class
}
