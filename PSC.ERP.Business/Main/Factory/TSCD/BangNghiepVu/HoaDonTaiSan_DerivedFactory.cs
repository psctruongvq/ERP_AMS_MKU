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
    public class HoaDonTaiSan_DerivedFactory : HoaDon_Factory
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return HoaDonTaiSan_DerivedFactory.New().CreateAloneObject();
        }
        public static HoaDonTaiSan_DerivedFactory New()
        {
            return new HoaDonTaiSan_DerivedFactory();
        }
        public HoaDonTaiSan_DerivedFactory()
            : base()
        {

        }

        #region Custom
        public tblHoaDon NewHoaDonMuaTaiSan(Boolean coVAT)
        {
            //tạo mới hóa đơn được quản lý
            tblHoaDon hoaDon = this.CreateManagedObject();
            //set ngày mặc định cho hóa đơn
            hoaDon.NgayLap = app_users_Factory.New().SystemDate;
            //Xác định loại hóa đơn
            hoaDon.LoaiHoaDon = (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan;
            //
            hoaDon.KhauTruThue = !coVAT;
            return hoaDon;
        }
        public tblHoaDon NewHoaDonBanTaiSan()
        {
            //tạo mới hóa đơn được quản lý
            tblHoaDon hoaDon = this.CreateManagedObject();

            //Xác định loại hóa đơn
            hoaDon.LoaiHoaDon = (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan;

            return hoaDon;
        }
        public override IQueryable<tblHoaDon> GetAll()
        {
            IQueryable<tblHoaDon> query = from o in this.ObjectSet
                                          //where LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)//
                                          orderby o.NgayLap descending
                                          select o;
            return query;
        }
        public override tblHoaDon Get_HoaDon_ByMaHoaDon(long maHoaDon)
        {
            tblHoaDon obj = (from o in this.ObjectSet
                             where o.MaHoaDon == maHoaDon
                             //&& LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)//
                             select o).SingleOrDefault();
            return obj;
        }

        public IQueryable<tblHoaDon> TimKiem(LoaiTimHoaDonEnum loaiTim, CompareTypeEnum compareType, String soHoaDon, String serial, Decimal soTien, Double phanTramThueVAT, Decimal tienThueVAT, Decimal tongTien, DateTime ngayLap, DateTime ngayLapDen, Int64 maDoiTac)
        {
            IQueryable<tblHoaDon> query = null;


            switch (loaiTim)
            {
                case LoaiTimHoaDonEnum.TatCa:
                    query = this.GetAll();
                    break;
                case LoaiTimHoaDonEnum.SoHoaDon://tìm theo số hóa đơn
                    {

                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                     o.SoHoaDon == soHoaDon
                                    orderby o.NgayLap
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soHoaDonLower = soHoaDon.ToLower();
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.SoHoaDon.ToLower().Contains(soHoaDonLower)
                                    orderby o.NgayLap
                                    select o;
                        }

                    }
                    break;
                case LoaiTimHoaDonEnum.Serial://tìm theo tên hợp đồng
                    if (compareType == CompareTypeEnum.Equal)
                    {
                        query = from o in this.ObjectSet
                                where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                 //&& 
                                o.SoSerial == soHoaDon
                                orderby o.NgayLap
                                select o;
                    }
                    else if (compareType == CompareTypeEnum.Contain)
                    {
                        String serialLower = serial.ToLower();
                        query = from o in this.ObjectSet
                                where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                 //&& 
                                o.SoSerial.ToLower().Contains(serialLower)
                                orderby o.NgayLap
                                select o;
                    }
                    break;
                case LoaiTimHoaDonEnum.NgayLap://tìm theo ngày lập
                    {
                        switch (compareType)
                        {
                            case CompareTypeEnum.Equal:
                                query = from o in this.ObjectSet
                                        where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                         //&& 
                                        o.NgayLap.Value.Date == ngayLap.Date
                                        orderby o.NgayLap
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in this.ObjectSet
                                        where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                         //&& 
                                        o.NgayLap.Value.Date < ngayLap.Date
                                        orderby o.NgayLap
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in this.ObjectSet
                                        where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                         //&& 
                                        o.NgayLap.Value.Date <= ngayLap.Date
                                        orderby o.NgayLap
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in this.ObjectSet
                                        where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                         //&& 
                                        o.NgayLap.Value.Date >= ngayLap.Date
                                        orderby o.NgayLap
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in this.ObjectSet
                                        where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                         //&& 
                                        o.NgayLap.Value.Date > ngayLap.Date
                                        orderby o.NgayLap
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in this.ObjectSet
                                        where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                         //&& 
                                        o.NgayLap.Value.Date >= ngayLap.Date
                                         && o.NgayLap.Value.Date <= ngayLapDen.Date
                                        orderby o.NgayLap
                                        select o;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case LoaiTimHoaDonEnum.SoTien://tìm theo số tiền
                    switch (compareType)
                    {
                        case CompareTypeEnum.Equal:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThanhTien == soTien
                                    orderby o.NgayLap
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThanhTien < soTien
                                    orderby o.NgayLap
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThanhTien <= soTien
                                    orderby o.NgayLap
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThanhTien >= soTien
                                    orderby o.NgayLap
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThanhTien > soTien
                                    orderby o.NgayLap
                                    select o;
                            break;
                        default:
                            break;
                    }
                    break;
                case LoaiTimHoaDonEnum.PhanTramThueVAT://tìm theo % VAT
                    switch (compareType)
                    {
                        case CompareTypeEnum.Equal:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThueSuatVAT == phanTramThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThueSuatVAT < phanTramThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThueSuatVAT <= phanTramThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThueSuatVAT >= phanTramThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThueSuatVAT > phanTramThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        default:
                            break;
                    }
                    break;
                case LoaiTimHoaDonEnum.TienThueVAT://tìm theo tiền thuế VAT
                    switch (compareType)
                    {
                        case CompareTypeEnum.Equal:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThueVAT == tienThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThueVAT < tienThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                     o.ThueVAT <= tienThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                     o.ThueVAT >= tienThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.ThueVAT > tienThueVAT
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        default:
                            break;
                    }
                    break;
                case LoaiTimHoaDonEnum.TongTien://tìm theo tổng tiền
                    switch (compareType)
                    {
                        case CompareTypeEnum.Equal:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                     o.TongTien == tongTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.TongTien < tongTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                     o.TongTien <= tongTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.TongTien >= tongTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in this.ObjectSet
                                    where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                                     //&& 
                                    o.TongTien > tongTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        default:
                            break;
                    }
                    break;
                case LoaiTimHoaDonEnum.DoiTac://tìm theo mã đối tác
                    query = from o in this.ObjectSet
                            where //LoaiHoaDonTaiSanList_.Contains(o.LoaiHoaDon)
                             //&& 
                            o.MaDoiTac == maDoiTac
                            orderby o.NgayLap descending
                            select o;
                    break;
                default:
                    break;
            }

            return query;
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {

            foreach (tblHoaDon obj in deleteList)
            {
                //01 xóa HoaDon_DoiTac
                HoaDon_DoiTac_Factory.FullDelete(context, obj.tblHoaDon_DoiTac.ToList<Object>());
                //02 xóa hóa đơn
                context.tblHoaDons.DeleteObject(obj);
            }

        }
        #endregion
    }//end class
}
