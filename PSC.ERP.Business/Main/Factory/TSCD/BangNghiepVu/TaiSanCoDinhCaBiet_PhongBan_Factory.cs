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
    public class TaiSanCoDinhCaBiet_PhongBan_Factory : BaseFactory<Entities, tblTaiSanCoDinhCaBiet_PhongBan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TaiSanCoDinhCaBiet_PhongBan_Factory.New().CreateAloneObject();
        }
        public static TaiSanCoDinhCaBiet_PhongBan_Factory New()
        {
            return new TaiSanCoDinhCaBiet_PhongBan_Factory();
        }
        public TaiSanCoDinhCaBiet_PhongBan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public Boolean KiemTraTSCDCaBietDaDuocPhanBo(int maTSCDCaBiet)
        {
            Boolean result = this.ObjectSet.Any(x => x.MaTSCDCaBiet == maTSCDCaBiet);
            return result;
        }
        public tblTaiSanCoDinhCaBiet_PhongBan Get_PhanBoSauCung_ByMaTSCDCaBiet(int maTSCDCaBiet)
        {//chua test

            tblTaiSanCoDinhCaBiet_PhongBan obj = (from o in this.ObjectSet
                                                  where o.MaTSCDCaBiet == maTSCDCaBiet
                                                  orderby o.NgayPhanBo descending, o.MaPhanBoSuDung descending
                                                  select o).FirstOrDefault();

            return obj;
        }

        public tblTaiSanCoDinhCaBiet_PhongBan Get_PhanBoSauCung_ByMaTSCDCaBiet(int maTSCDCaBiet, int maPhongban)
        {//chua test

            tblTaiSanCoDinhCaBiet_PhongBan obj = (from o in this.ObjectSet
                                                  where o.MaTSCDCaBiet == maTSCDCaBiet && o.MaPhongBan == maPhongban
                                                  orderby o.NgayPhanBo descending, o.MaPhanBoSuDung descending
                                                  select o).FirstOrDefault();

            return obj;
        }

        public tblTaiSanCoDinhCaBiet_PhongBan Get_PhanBoDauTien_ByMaTSCDCaBiet(int maTSCDCaBiet)
        {//chua test

            tblTaiSanCoDinhCaBiet_PhongBan obj = (from o in this.ObjectSet
                                                  where o.MaTSCDCaBiet == maTSCDCaBiet
                                                  orderby o.NgayPhanBo ascending, o.MaPhanBoSuDung ascending
                                                  select o).FirstOrDefault();

            return obj;
        }

        public tblTaiSanCoDinhCaBiet_PhongBan Get_PhanBoDauTien_ByMaTSCDCaBiet(int maTSCDCaBiet, int maPhongban)
        {//chua test

            tblTaiSanCoDinhCaBiet_PhongBan obj = (from o in this.ObjectSet
                                                  where o.MaTSCDCaBiet == maTSCDCaBiet && o.MaPhongBan == maPhongban
                                                  orderby o.NgayPhanBo ascending, o.MaPhanBoSuDung ascending
                                                  select o).FirstOrDefault();

            return obj;
        }

        public IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> Get_DanhSachTheoPhongBan(int maPhongban)
        {//phân bổ tài sản đang hiện hữu ở phòng ban
            //truy vấn này chỉ được thao tác thông qua this.Context (cấm truy vấn thông qua this.ObjectSet)
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> query = (from o in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
                                                                where (o.MaPhongBan == maPhongban || maPhongban == 0)
                                                                  && o.MaPhanBoSuDung ==
                                                                      (from x in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
                                                                       where x.MaTSCDCaBiet == o.MaTSCDCaBiet
                                                                       orderby x.NgayPhanBo descending, x.MaPhanBoSuDung descending
                                                                       select x.MaPhanBoSuDung).FirstOrDefault()
                                                                orderby o.NgayPhanBo ascending, o.MaPhanBoSuDung ascending
                                                                select o);

            return query;
        }
        public IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> Get_DanhSachTheoPhongBan_ViTri(int maPhongban, int maViTri)
        {//phân bổ tài sản đang hiện hữu ở phòng ban
            //truy vấn này chỉ được thao tác thông qua this.Context (cấm truy vấn thông qua this.ObjectSet)
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> query = (from o in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
                                                                where (o.MaPhongBan == maPhongban || maPhongban == 0) && (o.MaViTri == maViTri || maViTri == 0)
                                                                  && o.MaPhanBoSuDung ==
                                                                      (from x in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
                                                                       where x.MaTSCDCaBiet == o.MaTSCDCaBiet
                                                                       orderby x.NgayPhanBo descending, x.MaPhanBoSuDung descending
                                                                       select x.MaPhanBoSuDung).FirstOrDefault()
                                                                orderby o.NgayPhanBo ascending, o.MaPhanBoSuDung ascending
                                                                select o);

            return query;
        }
        public IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> Get_DanhSachTheoPhongBanDenNgay(int maPhongban, DateTime denNgay)
        {//phân bổ tài sản hiện hữu ở phòng ban đến ngày
            //truy vấn này chỉ được thao tác thông qua this.Context (cấm truy vấn thông qua this.ObjectSet)
            IQueryable<tblTaiSanCoDinhCaBiet_PhongBan> query = (from o in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
                                                                where (o.MaPhongBan == maPhongban || maPhongban == 0)
                                                                  && o.NgayPhanBo <= denNgay
                                                                  && o.MaPhanBoSuDung ==
                                                                      (from x in this.Context.tblTaiSanCoDinhCaBiet_PhongBan
                                                                       where x.MaTSCDCaBiet == o.MaTSCDCaBiet
                                                                        && x.NgayPhanBo <= denNgay
                                                                       orderby x.NgayPhanBo descending, x.MaPhanBoSuDung descending
                                                                       select x.MaPhanBoSuDung).FirstOrDefault()
                                                                orderby o.NgayPhanBo ascending, o.MaPhanBoSuDung ascending
                                                                select o);

            return query;
        }

        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblTaiSanCoDinhCaBiet_PhongBan item in deleteList)
            {
                context.tblTaiSanCoDinhCaBiet_PhongBan.DeleteObject(item);
            }

        }
        #endregion
    }//end class
}
