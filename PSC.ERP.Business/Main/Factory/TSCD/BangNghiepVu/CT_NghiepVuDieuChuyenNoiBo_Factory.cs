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
    public class CT_NghiepVuDieuChuyenNoiBo_Factory : BaseFactory<Entities, tblCT_NghiepVuDieuChuyenNoiBo>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return CT_NghiepVuDieuChuyenNoiBo_Factory.New().CreateAloneObject();
        }
        public static CT_NghiepVuDieuChuyenNoiBo_Factory New()
        {
            return new CT_NghiepVuDieuChuyenNoiBo_Factory();
        }
        public CT_NghiepVuDieuChuyenNoiBo_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDeleteCT_NghiepVuDieuChuyenNoiBo(Entities context, List<Object> deleteList)
        {
            //xóa chi tiết nghiệp vụ điều chuyển nội bộ
            foreach (tblCT_NghiepVuDieuChuyenNoiBo item in deleteList)
            {
                //xóa tài sản cá biệt phòng ban
                BaseFactory<Entities, tblTaiSanCoDinhCaBiet_PhongBan>.DeleteHelper(context, item.tblTaiSanCoDinhCaBiet_PhongBan);
                //Cập nhật lại đã thực hiện nghiệp vụ trong tài sản cá biệt phòng ban
                if (item.tblDuyetTSCD!=null)
                    item.tblDuyetTSCD.DaThucHienNghiepVu = false;

                //xóa chi tiết nghiệp vụ điều chuyển nội bộ
                context.DeleteObject(item);
            }
        }
        public IQueryable<tblCT_NghiepVuDieuChuyenNoiBo> Get_CT_NghiepVuDieuChuyenNoiBo_ByTuNgayAndDenNgayAndMaPhongBanGiaoAndMaPhongBanNhan_PhucVuLichSuDieuChuyenNoiBo(int maPhongBanGiao, int maPhongBanNhan, DateTime tuNgay, DateTime denNgay)
        {
            IQueryable<tblCT_NghiepVuDieuChuyenNoiBo> query = (
                                                                   from o in this.ObjectSet
                                                                   join a in this.Context.tblNghiepVuDieuChuyenNoiBoes on o.MaNghiepVuDieuChuyen equals a.MaNghiepVuDieuChuyenNoiBo
                                                                   where a.NgayChungTu >= tuNgay && a.NgayChungTu <= denNgay
                                                                           && (a.MaPhongBanGiao == maPhongBanGiao || maPhongBanGiao == 0)
                                                                           && (a.MaPhongBanNhan == maPhongBanNhan || maPhongBanNhan == 0)
                                                                   select o
                                                               );
            return query;

        }
        #endregion
    }//end class
}
