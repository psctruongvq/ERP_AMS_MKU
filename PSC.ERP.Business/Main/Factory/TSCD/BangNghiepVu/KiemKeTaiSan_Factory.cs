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
    public class KiemKeTaiSan_Factory : BaseFactory<Entities, tblKiemKeTaiSan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return KiemKeTaiSan_Factory.New().CreateAloneObject();
        }
        public static KiemKeTaiSan_Factory New()
        {
            return new KiemKeTaiSan_Factory();
        }
        public KiemKeTaiSan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDeleteKiemKeTaiSan(Entities context, List<Object> deleteList)
        {
            //xóa kiểm kê tài sản
            foreach (tblKiemKeTaiSan item in deleteList)
            {
                context.DeleteObject(item);
            }
        }

        public void DeleteKiemKeTaiSan(List<tblKiemKeTaiSan> kiemKeTaiSanList)
        {
            //xóa kiểm kê tài sản
            foreach (tblKiemKeTaiSan item in kiemKeTaiSanList)
            {
                this.DeleteObject(item);
            }
        }

        public IQueryable<tblKiemKeTaiSan> Get_DanhSachKiemKeTaiSanTheoNgayKiemKe_PhucVuKiemKeTaiSan(DateTime tuNgay, DateTime denNgay, int userID, bool isAdmin)
        {
            IQueryable<tblKiemKeTaiSan> query = (from o in this.ObjectSet
                                                 where o.NgayKiemKe >= tuNgay
                                                 && o.NgayKiemKe <= denNgay
                                                 && ((o.UserID == userID && isAdmin ==false)  || (isAdmin==true))
                                                 orderby o.NgayKiemKe ascending
                                                 select o);
            return query;
        }
        public tblKiemKeTaiSan Get_TaiSanCoDinhCaBiet_BySoHieu_MaPhongBan_NgayKiemKe(string soHieu, Int32 maPhongBan, DateTime ngayKiemKe)
        {
            tblKiemKeTaiSan obj = (from o in this.ObjectSet
                                   where o.SoHieuTSCDCaBiet == soHieu && o.MaPhongBan == maPhongBan && o.NgayKiemKe == ngayKiemKe
                                   select o).SingleOrDefault();
            return obj;
        }
        public tblKiemKeTaiSan Get_TaiSanCoDinhCaBiet_BySoHieu_MaViTri_NgayKiemKe(string soHieu, Int32 maViTri, DateTime ngayKiemKe, int MaCongTy)
        {
            tblKiemKeTaiSan obj = (from o in this.ObjectSet
                                   //where o.SoHieuTSCDCaBiet == soHieu && o.MaViTri == maViTri && o.NgayKiemKe == ngayKiemKe
                                   where o.SoHieuTSCDCaBiet == soHieu && o.MaViTri == maViTri && o.NgayKiemKe == ngayKiemKe && o.MaCongTy== MaCongTy
                                   select o).SingleOrDefault();
            return obj;
        }
        public IQueryable<tblKiemKeTaiSan> Get_TaiSanCoDinhCaBiet_MaPhongBan_NgayKiemKe(Int32 maPhongBan, DateTime ngayKiemKe)
        {
            IQueryable<tblKiemKeTaiSan> query = (from o in this.ObjectSet
                                                 where o.MaViTri == maPhongBan && o.NgayKiemKe == ngayKiemKe
                                                 orderby o.MaTSCDCaBiet, o.SoHieuTSCDCaBiet
                                                 select o);
            return query;
        }
        public Boolean Check_ViTriChuaKiemKe_TheoNgay(Int32 maViTriKiemKe, DateTime ngayKiemKe)
        {
            IQueryable<tblKiemKeTaiSan> query = (from o in this.ObjectSet
                                                 where o.MaViTriKiemKe == maViTriKiemKe && o.NgayKiemKe == ngayKiemKe
                                                 orderby o.MaTSCDCaBiet, o.SoHieuTSCDCaBiet
                                                 select o);
            return query.Count() > 0;
        }
        public IQueryable<tblKiemKeTaiSan> Get_TaiSanCoDinhCaBiet_TrongDanhSachXuLyKiemKe(int maCongTy)
        {
            IQueryable<tblKiemKeTaiSan> query = (from o in this.ObjectSet
                                                 where o.TrangthaiSauKiemKe == "trongdanhsachxuly" && o.MaCongTy == maCongTy
                                                 orderby o.MaTSCDCaBiet
                                                 select o);
            return query;
        }
        //Date: 30/11/2020  
        public IQueryable<tblKiemKeTaiSan> Get_TaiSanCoDinhCaBiet_MaPhongBan_NgayKiemKe_MaCongTy(Int32 maPhongBan, DateTime ngayKiemKe, int MaCongTy)
        {
            IQueryable<tblKiemKeTaiSan> query = (from o in this.ObjectSet
                                                 where o.MaViTriKiemKe == maPhongBan && o.NgayKiemKe == ngayKiemKe && o.MaCongTy==MaCongTy
                                                 orderby o.TaiSanThua,o.MaTSCDCaBiet ,o.SoHieuTSCDCaBiet
                                                 select o);
            return query;
        }


        #endregion
    }//end class
}
