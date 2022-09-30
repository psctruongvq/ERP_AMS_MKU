using System;
using System.Collections.Generic;
using System.Linq;
using PSC_ERP_Core;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public class BoSungDungCuPhuTung_Factory : BaseFactory<Entities, tblBoSungDungCuPhuTung>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static BaseEntityObject CreateStandAloneObject()
        {
            return BoSungDungCuPhuTung_Factory.New().CreateAloneObject();
        }
        public static BoSungDungCuPhuTung_Factory New()
        {
            return new BoSungDungCuPhuTung_Factory();
        }
        public BoSungDungCuPhuTung_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static tblBoSungDungCuPhuTung BasicClonePhuTungGhiTang(tblBoSungDungCuPhuTung dungCuPhuTung)
        {
            tblBoSungDungCuPhuTung clonedObject = BoSungDungCuPhuTung_Factory.New().CreateAloneObject();
            clonedObject.MaDungCuPhuTung = dungCuPhuTung.MaDungCuPhuTung;
            clonedObject.ChiPhi = dungCuPhuTung.ChiPhi;
            clonedObject.DonGia = dungCuPhuTung.DonGia;
            clonedObject.GhiChu = dungCuPhuTung.GhiChu;
            //clonedObject.LaDCPTSuaChuaLon = dungCuPhuTung.LaDCPTSuaChuaLon;
            //clonedObject.MaChiTietNghiepVuSuaChuaLon = dungCuPhuTung.MaChiTietNghiepVuSuaChuaLon;

            clonedObject.MaDVT = dungCuPhuTung.MaDVT;
            clonedObject.MaQuanLy = dungCuPhuTung.MaQuanLy;
            clonedObject.MaTSCDCaBiet = dungCuPhuTung.MaTSCDCaBiet;
            clonedObject.NgayNhan = dungCuPhuTung.NgayNhan;
            clonedObject.NgaySuDung = dungCuPhuTung.NgaySuDung;

            clonedObject.SoLuong = dungCuPhuTung.SoLuong;
            clonedObject.Ten = dungCuPhuTung.Ten;
            clonedObject.TongGiaTri = dungCuPhuTung.TongGiaTri;
            clonedObject.UserID = dungCuPhuTung.UserID;
            return clonedObject;
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblBoSungDungCuPhuTung item in deleteList)
            {
                //01-xóa chi tiết nguyên giá phát sinh từ nghiệp vụ sửa chữa lớn nếu có
                ChiTietNguyenGiaTSCD_Factory.FullDelete(context, item.tblChiTietNguyenGiaTSCDs.ToList<Object>());//BaseFactory<Entities, tblChiTietNguyenGiaTSCD>.DeleteHelper(context, item.tblChiTietNguyenGiaTSCDs);
                //02-xóa dụng cụ phụ tùng
                context.tblBoSungDungCuPhuTungs.DeleteObject(item);
            }
            //BaseFactory<Entities, tblBoSungDungCuPhuTung>.DeleteHelper(context, deleteList);
        }
        #endregion
    }//end class
}
