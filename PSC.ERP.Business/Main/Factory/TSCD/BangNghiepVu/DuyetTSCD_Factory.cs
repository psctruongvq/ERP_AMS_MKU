using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Core;
using System.Reflection;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Objects;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main;
using PSC_ERP_Util.DateTimeExtension;
using PSC_ERP_Business.Main.Predefined;

namespace PSC_ERP_Business.Main.Factory
{
    public class DuyetTSCD_Factory : BaseFactory<Entities, tblDuyetTSCD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DuyetTSCD_Factory.New().CreateAloneObject();
        }
        public static DuyetTSCD_Factory New()
        {
            return new DuyetTSCD_Factory();
        }
        public DuyetTSCD_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        //Minh tài viết ngày 21/10/2013
        //public void XoaDuyetTSCDCaBiet(int maTSCDCB)
        //{
        //    var query = (from x in this.ObjectSet
        //                 where x.MaTSCDCaBiet == maTSCDCB && (x.DaThucHienNghiepVu ?? false) == false
        //               && (x.DaDuyet ?? false) == false
        //                 select x).FirstOrDefault();

        //    this.DeleteObject(query);
        //}
        ////Minh tài viết ngày 21/10/2013
        //public void DuyetTSCDCaBiet(int maTSCDCB, int userDuyet)
        //{
        //    var query = (from x in this.ObjectSet
        //                 where x.MaTSCDCaBiet == maTSCDCB && (x.DaThucHienNghiepVu ?? false) == false
        //               && (x.DaDuyet ?? false) == false
        //                 select x).FirstOrDefault();
        //    if (query != null)
        //    {
        //        query.DaDuyet = true;
        //        query.NgayDuyet = this.SystemDate;
        //        query.UserDuyet = userDuyet;
        //        this.SaveChanges();
        //    }
        //}

        ///Delete ///////////////////////////////////////////////////////////////////
        #region Delete
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (tblDuyetTSCD item in deleteList)
            {
                //xóa duyệt tài sản cố định cá biệt
                context.tblDuyetTSCDs.DeleteObject(item);
            }
        }
        #endregion

        public IQueryable<tblDuyetTSCD> Get_DanhSachDuyetTSCDCaBietDaDuyet(LoaiNghiepVuTaiSanEnum loaiNghiepVu, int maPhongBan, int maTaiSanCDCB)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblDuyetTSCD> query = (from o in this.ObjectSet
                                              join x in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals x.MaTSCDCaBiet
                                              //join y in this.Context.tblBoPhanERPNews on x.MaPhongBan equals y.MaBoPhan
                                              where o.DaDuyet == true && o.LoaiNghiepVu == (Int32)loaiNghiepVu
                                              && (x.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTaiSanCDCB || maTaiSanCDCB == 0)
                                              && (o.DaThucHienNghiepVu ?? false) == false
                                              select o);
            return query;
        }
        //
        public IQueryable<tblDuyetTSCD> Get_DanhSachDuyetTSCDCaBietDaDuyet_PhucVuDieuChuyenNoiBo(int maPhongBan, int maTaiSanCDCB)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblDuyetTSCD> query = (from o in this.ObjectSet
                                              join x in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals x.MaTSCDCaBiet
                                              //join y in this.Context.tblBoPhanERPNews on x.MaPhongBan equals y.MaBoPhan
                                              where o.DaDuyet == true && o.LoaiNghiepVu == (int?)LoaiNghiepVuTaiSanEnum.DieuChuyenNoiBo
                                              && (x.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTaiSanCDCB || maTaiSanCDCB == 0)
                                              && (o.DaThucHienNghiepVu ?? false) == false
                                              select o);
            return query;
        }
        //

        public IQueryable<tblDuyetTSCD> Get_DanhSachDuyetTSCDCaBietDaDuyet_PhucVuDieuChuyenNgoai(int maPhongBan, int maTaiSanCDCB)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblDuyetTSCD> query = (from o in this.ObjectSet
                                              join x in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals x.MaTSCDCaBiet
                                              //join y in this.Context.tblBoPhanERPNews on x.MaPhongBan equals y.MaBoPhan
                                              where o.DaDuyet == true && o.LoaiNghiepVu == (int?)LoaiNghiepVuTaiSanEnum.DieuChuyenNgoai
                                              && (x.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTaiSanCDCB || maTaiSanCDCB == 0)
                                              && (o.DaThucHienNghiepVu ?? false) == false
                                              select o);
            return query;
        }

        //
        public IQueryable<tblDuyetTSCD> Get_DanhSachDuyetTSCDCaBietDaDuyet_PhucVuThanhLy(int maPhongBan, int maTaiSanCDCB)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblDuyetTSCD> query = (from o in this.ObjectSet
                                              join x in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals x.MaTSCDCaBiet
                                              //join y in this.Context.tblBoPhanERPNews on x.MaPhongBan equals y.MaBoPhan
                                              where o.DaDuyet == true && o.LoaiNghiepVu == (int?)LoaiNghiepVuTaiSanEnum.ThanhLy
                                              && (x.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTaiSanCDCB || maTaiSanCDCB == 0)
                                              && (o.DaThucHienNghiepVu ?? false) == false
                                              select o);
            return query;
        }
        //Minh tài viết ngày 04/11/2013
        //public void CapNhatDaThucHienNghiepVuTrongDuyetTSCDCaBiet_PhucVuDieuChuyenNgoaiAndThanhLy(int maTSCDCB)
        //{
        //    var query = (from x in this.ObjectSet
        //                 where x.MaTSCDCaBiet == maTSCDCB
        //                 && (x.DaThucHienNghiepVu ?? false) == false
        //                 && (x.DaDuyet ?? false) == true
        //                 select x).FirstOrDefault();
        //    if (query != null)
        //    {
        //        query.DaThucHienNghiepVu = true;
        //        this.SaveChanges();
        //    }
        //}

        //Minh tài viết ngày 04/11/2013
        //public void CapNhatChuaThucHienNghiepVuTrongDuyetTSCDCaBiet_PhucVuDieuChuyenNgoaiAndThanhLy(int maTSCDCB)
        //{
        //    var query = (from x in this.ObjectSet
        //                 where x.MaTSCDCaBiet == maTSCDCB
        //                 && (x.DaThucHienNghiepVu ?? false) == true
        //                 && (x.DaDuyet ?? false) == true
        //                 select x).FirstOrDefault();
        //    if (query != null)
        //    {
        //        query.DaThucHienNghiepVu = false;
        //        this.SaveChanges();
        //    }
        //}

        public IQueryable<tblDuyetTSCD> Get_DanhSachChoDuyetVaDaDuyetNhungChuaThucHienNghiepVuTheoPhongBanAndMaTSCDAndLoaiNghiepVu(int maPhongban, int maTSCD, int loaiNghiepVu, Int32 userIDLap = 0)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongban);

            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userIDLap))
                isAdmin = true;

            IQueryable<tblDuyetTSCD> query = (
                                                       from o in this.Context.tblDuyetTSCDs
                                                       join tspb in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals tspb.MaTSCDCaBiet
                                                       where (o.DaThucHienNghiepVu ?? false) == false
                                                           ///&& (y.DaDuyet ?? false) == false
                                                         && o.LoaiNghiepVu.Value == loaiNghiepVu
                                                         && (o.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTSCD || maTSCD == 0)
                                                         && o.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.LaTaiSanCoDinh == true
                                                          && (isAdmin == true || userIDLap == 0 || o.UserLap == userIDLap)

                                                       orderby o.tblTaiSanCoDinhCaBiet.SoHieu ascending
                                                       select o);
            return query;
        }

        public IQueryable<tblDuyetTSCD> Get_DanhSachChoDuyetVaDaDuyetNhungChuaThucHienNghiepVuTheoPhongBanAndMaViTriAndMaTSCDAndLoaiNghiepVu(int maPhongban, int maViTri, int maTSCD, int loaiNghiepVu, Int32 userIDLap = 0)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan_ViTri(maPhongban, maViTri);

            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userIDLap))
                isAdmin = true;

            IQueryable<tblDuyetTSCD> query = (
                                                       from o in this.Context.tblDuyetTSCDs
                                                       join tspb in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals tspb.MaTSCDCaBiet
                                                       where (o.DaThucHienNghiepVu ?? false) == false
                                                           ///&& (y.DaDuyet ?? false) == false
                                                         && o.LoaiNghiepVu.Value == loaiNghiepVu
                                                         && (o.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTSCD || maTSCD == 0)
                                                         && o.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.LaTaiSanCoDinh == true
                                                          && (isAdmin == true || userIDLap == 0 || o.UserLap == userIDLap)

                                                       orderby o.tblTaiSanCoDinhCaBiet.SoHieu ascending
                                                       select o);
            return query;
        }

        public IQueryable<tblDuyetTSCD> Get_DanhSachChoDuyetRong()
        {
            IQueryable<tblDuyetTSCD> query = (
                                                        from o in this.Context.tblDuyetTSCDs
                                                        where true == false
                                                        select o);
            return query;
        }
        #endregion
    }//end class
}
