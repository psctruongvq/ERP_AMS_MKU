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
    public class ChiTietNguyenGiaTSCD_Factory : BaseFactory<Entities, tblChiTietNguyenGiaTSCD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChiTietNguyenGiaTSCD_Factory.New().CreateAloneObject();
        }
        public static ChiTietNguyenGiaTSCD_Factory New()
        {
            return new ChiTietNguyenGiaTSCD_Factory();
        }
        public ChiTietNguyenGiaTSCD_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblChiTietNguyenGiaTSCD Get_ChiTietNguyenGiaDauTienCuaTaiSanCaBiet(Int32 maTSCDCaBiet)
        {
            tblChiTietNguyenGiaTSCD obj = (from o in this.ObjectSet
                                           where o.MaTSCDCaBiet == maTSCDCaBiet
                                           orderby o.MaChiTiet ascending
                                           select o).FirstOrDefault();
            return obj;
        }

        //public tblChiTietNguyenGiaTSCD Get_ChiTietNguyenGiaCuoiCungCuaTaiSanCaBiet(Int32 maTSCDCaBiet)
        //{
        //    tblChiTietNguyenGiaTSCD obj = (from o in this.ObjectSet
        //                                   where o.MaTSCDCaBiet == maTSCDCaBiet
        //                                   orderby o.NgayThucHien descending, o.MaChiTiet descending
        //                                   select o).FirstOrDefault();
        //    return obj;
        //}

        //public tblChiTietNguyenGiaTSCD Get_ChiTietNguyenGiaCuaTaiSanCaBietDenNgay(Int32 maTSCDCaBiet, DateTime denNgay)
        //{
        //    tblChiTietNguyenGiaTSCD obj = (from o in this.ObjectSet
        //                                   where o.MaTSCDCaBiet == maTSCDCaBiet && o.NgayThucHien <= denNgay
        //                                   orderby o.NgayThucHien descending, o.MaChiTiet descending
        //                                   select o).FirstOrDefault();
        //    return obj;
        //}
        public IQueryable<tblChiTietNguyenGiaTSCD> Get_DanhSachChiTietNguyenGiaSauCungDenNgay(DateTime denNgay)
        {//chi tiết nguyên giá sau cùng đến ngày
            //truy vấn này chỉ được thao tác thông qua this.Context (cấm truy vấn thông qua this.ObjectSet)
            IQueryable<tblChiTietNguyenGiaTSCD> query = (from o in this.Context.tblChiTietNguyenGiaTSCDs
                                                         where o.NgayThucHien <= denNgay
                                                           && o.MaChiTiet ==
                                                               (from x in this.Context.tblChiTietNguyenGiaTSCDs
                                                                where x.MaTSCDCaBiet == o.MaTSCDCaBiet
                                                                 && x.NgayThucHien <= denNgay
                                                                orderby x.NgayThucHien descending, x.MaChiTiet descending
                                                                select x.MaChiTiet).FirstOrDefault()
                                                         orderby o.NgayThucHien ascending, o.MaChiTiet ascending
                                                         select o);

            return query;
        }

        public decimal SumNguyenGiaDenNgay_ByMaTSCDCaBiet(DateTime denNgay, Int32 maTSCDCaBiet)
        {
            Decimal? kq = (from o in this.ObjectSet
                           where o.MaTSCDCaBiet == maTSCDCaBiet && o.NgayThucHien <= denNgay
                           group o by o.MaTSCDCaBiet into g
                           select g.Sum(x => x.SoTien)).SingleOrDefault();

            return (kq == null ? 0 : kq.Value);
        }

        public static void FullDelete(Entities context, List<Object> deleteList)
        {

            foreach (tblChiTietNguyenGiaTSCD chiTiet in deleteList)
            {
                context.tblChiTietNguyenGiaTSCDs.DeleteObject(chiTiet);
            }
        }
        #endregion
    }//end class
}
