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
    public class CT_NghiepVuDieuChuyenChiTietTaiSan_Factory : BaseFactory<Entities, tblCT_NghiepVuDieuChuyenChiTiet>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return CT_NghiepVuDieuChuyenChiTietTaiSan_Factory.New().CreateAloneObject();
        }
        public static CT_NghiepVuDieuChuyenChiTietTaiSan_Factory New()
        {
            return new CT_NghiepVuDieuChuyenChiTietTaiSan_Factory();
        }
        public CT_NghiepVuDieuChuyenChiTietTaiSan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDeleteCT_NghiepVuDieuChuyenChiTietTaiSan(Entities context, List<Object> deleteList)
        {
            //xóa chi tiết nghiệp vụ đổi chi tiết
            foreach (tblCT_NghiepVuDieuChuyenChiTiet item in deleteList)
            {
                //trả lại dữ liệu về ban đầu lúc chưa thực hiện nghiệp vụ
                //tblChiTietTaiSanCaBiet chiTietTSCu = item.tblChiTietTaiSanCaBiet;
                //tblChiTietTaiSanCaBiet chiTietTSMoi = item.tblChiTietTaiSanCaBiet1;
                //nguyên giá, số lượng, tình trạng ngưng sử dụng hay còn sử dụng
                //if (chiTietTSCu.SoLuong == chiTietTSMoi.SoLuong)
                //{
                //    chiTietTSCu.NguyenGia = chiTietTSMoi.NguyenGia;
                //    chiTietTSMoi.SoLuong = chiTietTSMoi.SoLuong;
                //}
                ////trường hợp không đổi hết chi tiết
                //else
                //{
                //    chiTietTSCu.NguyenGia += chiTietTSMoi.NguyenGia;
                //    chiTietTSCu.SoLuong += chiTietTSMoi.SoLuong;
                //}
                //chiTietTSCu.NgungSuDung = null;//hay bằng 0 cũng được

                //xóa chi tiết nghiệp vụ điều chuyển chi tiết tài sản
                context.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
