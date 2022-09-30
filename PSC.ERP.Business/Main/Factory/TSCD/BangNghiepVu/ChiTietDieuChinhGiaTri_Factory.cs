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
    public class ChiTietDieuChinhGiaTri_Factory : BaseFactory<Entities, tblChiTietDieuChinhGiaTri>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChiTietDieuChinhGiaTri_Factory.New().CreateAloneObject();
        }
        public static ChiTietDieuChinhGiaTri_Factory New()
        {
            return new ChiTietDieuChinhGiaTri_Factory();
        }
        public ChiTietDieuChinhGiaTri_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void GomGiaTriTangGiamTuDieuChinhGiaChiTietVaDieuChinhGiaPhuTungVeChiTietNghiepVu(tblChiTietDieuChinhGiaTri chiTietNghiepVu)
        {
            //foreach (var chiTietNghiepVu in _nghiepVu.tblChiTietDieuChinhGiaTris)
            {
                decimal giaTriTang_dcgct = 0;
                decimal giaTriGiam_dcgct = 0;
                foreach (var dcgct in chiTietNghiepVu.tblDieuChinhGiaChiTietTSCaBiets)
                {
                    giaTriTang_dcgct += (dcgct.GiaTriTang != null ? dcgct.GiaTriTang.Value : 0);
                    giaTriGiam_dcgct += (dcgct.GiaTriGiam != null ? dcgct.GiaTriGiam.Value : 0);
                }

                decimal giaTriTang_dcgpt = 0;
                decimal giaTriGiam_dcgpt = 0;
                foreach (var dcgpt in chiTietNghiepVu.tblDieuChinhGiaPhuTungTSCaBiets)
                {
                    giaTriTang_dcgpt += (dcgpt.GiaTriTang != null ? dcgpt.GiaTriTang.Value : 0);
                    giaTriGiam_dcgpt += (dcgpt.GiaTriGiam != null ? dcgpt.GiaTriGiam.Value : 0);
                }

                //chỉ gôm giá trị nếu tồn tại một dòng điều chỉnh giá chi tiết tài sản hoặc điều chỉnh giá phụ tùng có giá trị >0
                if (giaTriTang_dcgct + giaTriTang_dcgpt > 0)
                {
                    chiTietNghiepVu.GiaTriTang = giaTriTang_dcgct + giaTriTang_dcgpt;
                }
                if (giaTriGiam_dcgct + giaTriGiam_dcgpt > 0)
                {
                    chiTietNghiepVu.GiaTriGiam = giaTriGiam_dcgct + giaTriGiam_dcgpt;
                }
                ChungTuDieuChinhGiaTriTaiSan_DerivedFactory.CapNhatLaiTongTienChungTu(chiTietNghiepVu.tblDieuChinhGiaTri);
            }
        }
        public static void GomDonGiaVaChiPhiTuDieuChinhGiaChiTietVeChiTietNghiepVu(tblChiTietDieuChinhGiaTri chiTietNghiepVu)
        {
            //foreach (var chiTietNghiepVu in _nghiepVu.tblChiTietDieuChinhGiaTris)
            {
                decimal donGia_dcgct = 0;
                decimal chiPhi_dcgct = 0;
                foreach (var dcgct in chiTietNghiepVu.tblDieuChinhGiaChiTietTSCaBiets)
                {
                    donGia_dcgct += (dcgct.DonGia != null ? dcgct.DonGia.Value : 0);
                    chiPhi_dcgct += (dcgct.ChiPhi != null ? dcgct.ChiPhi.Value : 0);
                }


                //chỉ gôm giá trị nếu tồn tại một dòng điều chỉnh giá chi tiết tài sản có giá trị >0
                if (donGia_dcgct > 0)
                {
                    chiTietNghiepVu.DonGia = donGia_dcgct;
                }
                if (chiPhi_dcgct > 0)
                {
                    chiTietNghiepVu.ChiPhi = chiPhi_dcgct;
                }
                //\\ChungTuDieuChinhGiaTriTaiSan_DerivedFactory.CapNhatLaiTongTienChungTu(chiTietNghiepVu.tblDieuChinhGiaTri);
            }
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {

            foreach (tblChiTietDieuChinhGiaTri chiTiet in deleteList)
            {
                //xóa điều chỉnh giá chi tiết ts
                DieuChinhGiaChiTietTSCaBiet_Factory.FullDelete(context, chiTiet.tblDieuChinhGiaChiTietTSCaBiets.ToList<Object>());
                //xóa điều chỉnh giá dcpt
                DieuChinhGiaPhuTungTSCaBiet_Factory.FullDelete(context, chiTiet.tblDieuChinhGiaPhuTungTSCaBiets.ToList<Object>());
                //xóa chi tiết nguyên giá
                ChiTietNguyenGiaTSCD_Factory.FullDelete(context, chiTiet.tblChiTietNguyenGiaTSCDs.ToList<Object>());//BaseFactory<Entities, tblChiTietNguyenGiaTSCD>.DeleteHelper(context, chiTiet.tblChiTietNguyenGiaTSCDs);
                //xóa chi tiết điều chỉnh
                context.tblChiTietDieuChinhGiaTris.DeleteObject(chiTiet);
            }

        }
        #endregion
    }//end class
}
