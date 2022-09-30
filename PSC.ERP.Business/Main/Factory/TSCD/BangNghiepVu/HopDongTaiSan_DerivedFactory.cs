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
using PSC_ERP_Common;

namespace PSC_ERP_Business.Main.Factory
{
    public class HopDongTaiSan_DerivedFactory : HopDong_Factory
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return HopDongTaiSan_DerivedFactory.New().CreateAloneObject();
        }
        public static HopDongTaiSan_DerivedFactory New()
        {
            return new HopDongTaiSan_DerivedFactory();
        }
        public HopDongTaiSan_DerivedFactory()
            : base()
        {

        }

        #region Custom
        //public tblHopDong NewHopDongTaiSan()
        //{
        //    //tạo mới hợp đồng được quản lý
        //    tblHopDong hopDong = this.CreateManagedObject();
        //    //tạo mới hợp đồng mua bán
        //    hopDong.tblHopDongMuaBan = HopDongMuaBan_Factory.New().CreateAloneObject();

        //    //Xác định loại hợp đồng tài sản
        //    hopDong.tblHopDongMuaBan.MaLoaiHopDong = 123456;//PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan;

        //    //

        //    return hopDong;
        //}
        public override IQueryable<tblHopDong> GetAll()
        {
            IQueryable<tblHopDong> query = from o in this.ObjectSet
                                           where (o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongMuaSam || o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongDuAn)
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }
        public IQueryable<tblHopDong> GetListByMaHopDongList(List<Int64> danhSachMaHopDong)
        {
            IQueryable<tblHopDong> query = from o in this.ObjectSet
                                           where (o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongMuaSam || o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongDuAn)
                                           && danhSachMaHopDong.Contains(o.MaHopDong)
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }
        public IQueryable<tblHopDong> GetListByMaDoiTac(Int64 maDoiTac)
        {
            IQueryable<tblHopDong> query = from o in this.ObjectSet
                                           where (o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongMuaSam || o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongDuAn)
                                           && o.MaDoiTac == maDoiTac
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }
        public IQueryable<tblHopDong> GetListChuaThanhLyHoacChuaNghiemThuThanhLyByMaDoiTac(Int64 maDoiTac)
        {
            IQueryable<tblHopDong> query = from o in this.ObjectSet
                                           where (o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongMuaSam || o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongDuAn)
                                           && false == o.tblHopDongMuaBan.tblNghiemThuThanhLies.Any(x => x.Loai == 2 || x.Loai == 3)
                                           && o.MaDoiTac == maDoiTac
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }
        public override tblHopDong Get_HopDong_ByMaHopDong(long maHopDong)
        {
            tblHopDong obj = (from o in this.ObjectSet
                              where o.MaHopDong == maHopDong
                                && (o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongMuaSam || o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongDuAn)
                              select o).SingleOrDefault();
            return obj;
        }

        public IQueryable<tblHopDong> TimKiem(LoaiTimHopDongEnum loaiTim, CompareTypeEnum compareType, String soHopDong, String tenHopDong, Decimal soTien, Decimal soTienDen, DateTime ngayKy, DateTime ngayKyDen, Int64 maDoiTac)
        {
            IQueryable<tblHopDong> query = null;

            IQueryable<tblHopDong> danhSachHopDong = from o in this.ObjectSet
                                                     where (o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongMuaSam || o.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongDuAn)
                                                     && false == o.tblHopDongMuaBan.tblNghiemThuThanhLies.Any(x => x.Loai == 2 || x.Loai == 3)
                                                     orderby o.NgayLap descending
                                                     select o;
            switch (loaiTim)
            {
                case LoaiTimHopDongEnum.TatCa:
                    query = this.GetAll();
                    break;
                case LoaiTimHopDongEnum.SoHopDong://tìm theo số hợp đồng
                    {

                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in danhSachHopDong
                                    where o.tblHopDongMuaBan.SoHopDong == soHopDong
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soHopDongLower = soHopDong.ToLower();
                            query = from o in danhSachHopDong
                                    where o.tblHopDongMuaBan.SoHopDong.ToLower().Contains(soHopDongLower)
                                    orderby o.NgayLap descending
                                    select o;
                        }

                    }
                    break;
                case LoaiTimHopDongEnum.TenHopDong://tìm theo tên hợp đồng
                    if (compareType == CompareTypeEnum.Equal)
                    {

                        query = from o in danhSachHopDong
                                where o.TenHopDong == soHopDong
                                orderby o.NgayLap descending
                                select o;
                    }
                    else if (compareType == CompareTypeEnum.Contain)
                    {
                        String tenHopDongLower = tenHopDong.ToLower();
                        query = from o in danhSachHopDong
                                where o.TenHopDong.ToLower().Contains(tenHopDongLower)
                                orderby o.NgayLap descending
                                select o;
                    }
                    break;
                case LoaiTimHopDongEnum.NgayKy://tìm theo ngày ký
                    {
                        switch (compareType)
                        {
                            case CompareTypeEnum.Equal:
                                query = from o in danhSachHopDong
                                        where o.NgayKy.Value.Date == ngayKy.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in danhSachHopDong
                                        where o.NgayKy.Value.Date < ngayKy.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in danhSachHopDong
                                        where o.NgayKy.Value.Date <= ngayKy.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in danhSachHopDong
                                        where o.NgayKy.Value.Date >= ngayKy.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in danhSachHopDong
                                        where o.NgayKy.Value.Date > ngayKy.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in danhSachHopDong
                                        where o.NgayKy.Value.Date >= ngayKy.Date
                                         && o.NgayKy.Value.Date <= ngayKyDen.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case LoaiTimHopDongEnum.SoTien://tìm theo số tiền
                    switch (compareType)
                    {
                        case CompareTypeEnum.Equal:
                            query = from o in danhSachHopDong
                                    where o.tblHopDongMuaBan.TongTien == soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in danhSachHopDong
                                    where o.tblHopDongMuaBan.TongTien < soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in danhSachHopDong
                                    where o.tblHopDongMuaBan.TongTien <= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in danhSachHopDong
                                    where o.tblHopDongMuaBan.TongTien >= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in danhSachHopDong
                                    where o.tblHopDongMuaBan.TongTien > soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.Between:
                            query = from o in danhSachHopDong
                                    where o.tblHopDongMuaBan.TongTien >= soTien
                                     && o.tblHopDongMuaBan.TongTien <= soTienDen
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        default:
                            break;
                    }
                    break;
                case LoaiTimHopDongEnum.DoiTac://tìm theo mã đối tác
                    query = from o in danhSachHopDong
                            where maDoiTac == 0 || o.MaDoiTac == maDoiTac
                            orderby o.NgayLap descending
                            select o;
                    break;
                default:
                    break;
            }

            return query;
        }
        #endregion
    }//end class
}
