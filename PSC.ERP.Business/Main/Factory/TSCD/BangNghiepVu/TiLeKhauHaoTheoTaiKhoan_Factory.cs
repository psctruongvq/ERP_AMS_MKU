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
    public class TiLeKhauHaoTheoTaiKhoan_Factory : BaseFactory<Entities, tblTiLeKhauHaoTheoTaiKhoan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TiLeKhauHaoTheoTaiKhoan_Factory.New().CreateAloneObject();
        }
        public static TiLeKhauHaoTheoTaiKhoan_Factory New()
        {
            return new TiLeKhauHaoTheoTaiKhoan_Factory();
        }
        public TiLeKhauHaoTheoTaiKhoan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblTiLeKhauHaoTheoTaiKhoan Get_TiLeKhauHaoTheoTaiKhoan_BySoHieuTaiKhoanAndNam(string soHieuTK, Int32 nam)
        {
            var query = (from o in this.ObjectSet
                         where o.SoHieuTK == soHieuTK && o.Nam == nam
                         select o).SingleOrDefault();

            return query;
        }

        public tblTiLeKhauHaoTheoTaiKhoan GetLast_TiLeKhauHaoTheoTaiKhoan_BySoHieuTaiKhoanAndNam(string soHieuTK, Int32 nam)
        {
            var query = (from o in this.ObjectSet
                         where o.SoHieuTK == soHieuTK && o.Nam == nam
                         orderby o.NgayHieuLuc descending
                         select o
                         ).FirstOrDefault();

            return query;
        }
        public tblTiLeKhauHaoTheoTaiKhoan GetLast_TiLeKhauHaoTheoTaiKhoan_BySoHieuTaiKhoanAndNgayChot(string soHieuTK, DateTime ngayChot)
        {
            var query = (from o in this.ObjectSet
                         where o.SoHieuTK == soHieuTK && o.NgayHieuLuc <= ngayChot
                         orderby o.NgayHieuLuc descending
                         select o
                         ).FirstOrDefault();

            return query;
        }

        public IQueryable<tblTiLeKhauHaoTheoTaiKhoan> Get_DanhSachTiLeKhauHaoTheoTaiKhoan_ByNam(Int32 nam)
        {
            IQueryable<tblTiLeKhauHaoTheoTaiKhoan> query = (from o in this.ObjectSet
                                                            where o.Nam == nam
                                                            select o);

            return query;
        }



        public bool CheckSoHieuTaiKhoanContainInNghiepVuKHHM(string soHieuTK, int year)
        {
            Boolean kq = false;
            kq = (from o in this.Context.tblTaiSanCoDinhCaBiets
                  where o.TaiKhoanDoiUng == soHieuTK // 
                       && o.MaTSCDCaBiet ==
                       (
                        from y in this.Context.tblNghiepVuKhauHaoHaoMons
                        where y.MaTSCDCaBiet == o.MaTSCDCaBiet
                              && y.MaKy ==
                              (
                                   from z in this.Context.tblKies
                                   where z.MaKy == y.MaKy
                                          && z.NgayBatDau.Year == year //                                    
                                   select z.MaKy
                              ).FirstOrDefault()

                        select y.MaTSCDCaBiet
                       ).FirstOrDefault()
                  select true).FirstOrDefault();

            return kq;
        }

        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (tblTiLeKhauHaoTheoTaiKhoan item in deleteList)
            {
                //xóa
                context.tblTiLeKhauHaoTheoTaiKhoans.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
