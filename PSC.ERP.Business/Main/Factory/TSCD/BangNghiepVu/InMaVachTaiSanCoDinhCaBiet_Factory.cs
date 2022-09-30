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

namespace PSC_ERP_Business.Main.Factory
{
    public class InMaVachTaiSanCoDinhCaBiet_Factory : BaseFactory<Entities, tblInMaVachTaiSanCoDinhCaBiet>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return InMaVachTaiSanCoDinhCaBiet_Factory.New().CreateAloneObject();
        }
        public static InMaVachTaiSanCoDinhCaBiet_Factory New()
        {
            return new InMaVachTaiSanCoDinhCaBiet_Factory();
        }
        public InMaVachTaiSanCoDinhCaBiet_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        public static void FullDeleteInMaVachTSCDCaBiet(Entities context, List<Object> deleteList)
        {
            foreach (tblInMaVachTaiSanCoDinhCaBiet item in deleteList)
            {
                context.DeleteObject(item);
            }
        }

        public IQueryable<tblInMaVachTaiSanCoDinhCaBiet> Get_DanhSachInMaVachTaiSanCoDinhCaBiet_ByMaPhongBanAndMaNhomTSAndMaLoaiTSAndMaTSCD(Int32 maPhongBan, Int32 maNhomTS, Int32 maLoaiTS, Int32 maTaiCoDinh, Int32 maCongTy)//, DateTime tuNgay, DateTime denNgay)
        {
            TaiSanCoDinhCaBiet_PhongBan_Factory tempFactory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
            tempFactory.Context = this.Context;
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> phanBoTheoPhongBanList = tempFactory.Get_DanhSachTheoPhongBan(maPhongBan);

            IQueryable<tblInMaVachTaiSanCoDinhCaBiet> query = (
                                                     from o in this.ObjectSet
                                                     join a in phanBoTheoPhongBanList on o.MaTSCDCaBiet equals a.MaTSCDCaBiet
                                                     where
                                                          (o.tblTaiSanCoDinhCaBiet.ThanhLy ?? false) == false
                                                         && (o.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ID == maTaiCoDinh || maTaiCoDinh == 0)
                                                         && (o.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.ParentID == maLoaiTS || maLoaiTS == 0)
                                                         && (o.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.tblDanhMucTSCD2.LoaiTaiSanThuocNhomTaiSan == maNhomTS || maNhomTS == 0)
                                                         && (o.tblTaiSanCoDinhCaBiet.MaCongTy == maCongTy || maCongTy == 0)
                                                     orderby o.tblTaiSanCoDinhCaBiet.SoHieu ascending
                                                     select o);

            return query;

        }
        #endregion
    }//end class
}
