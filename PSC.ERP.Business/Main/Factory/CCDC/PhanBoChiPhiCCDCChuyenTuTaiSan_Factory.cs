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
    public partial class PhanBoChiPhiCCDCChuyenTuTaiSan_Factory : BaseFactory<Entities, tblPhanBoChiPhiCCDCChuyenTuTaiSan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return PhanBoChiPhiCCDCChuyenTuTaiSan_Factory.New().CreateAloneObject();
        }
        public static PhanBoChiPhiCCDCChuyenTuTaiSan_Factory New()
        {
            return new PhanBoChiPhiCCDCChuyenTuTaiSan_Factory();
        }
        public PhanBoChiPhiCCDCChuyenTuTaiSan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public Boolean KiemTraTrungSoChungTu(tblPhanBoChiPhiCCDCChuyenTuTaiSan document)
        {
            bool trungSoChungTu = KiemTraTrungSoChungTu_Helper(document.MaPhanBo, document.SoChungTu);


            return trungSoChungTu;
        }
        private Boolean KiemTraTrungSoChungTu_Helper(Int32 documentID, String documentCode)
        {
            bool trungSoChungTu = false;

            String soChungTuLower = documentCode.ToLower();

            trungSoChungTu = (from o in this.ObjectSet
                              where
                                o.SoChungTu.ToLower() == soChungTuLower
                                && (documentID == 0 || o.MaPhanBo != documentID)
                              select true).SingleOrDefault();


            return trungSoChungTu;
        }

        public Boolean KiemTraTrongNamDaChayPhanBo(tblPhanBoChiPhiCCDCChuyenTuTaiSan document)
        {
            bool daChay = KiemTraTrongNamDaChayPhanBo_Helper(document.MaPhanBo, document.NgayChungTu.Value.Year);


            return daChay;
        }
        private Boolean KiemTraTrongNamDaChayPhanBo_Helper(Int32 documentID, Int32 year)
        {
            bool daChay = false;

            daChay = (from o in this.ObjectSet
                              where
                                o.NgayChungTu.Value.Year == year
                                && (documentID == 0 || o.MaPhanBo != documentID)
                              select true).SingleOrDefault();


            return daChay;
        }

        public tblPhanBoChiPhiCCDCChuyenTuTaiSan TaoMoiChungTuDayDuChiTiet_ManagedObject()
        {
            tblPhanBoChiPhiCCDCChuyenTuTaiSan chungTu = this.CreateManagedObject();
            chungTu.PhanTramPhanBo = 0;
            //ngày chứng từ
            chungTu.NgayChungTu = app_users_Factory.New().SystemDate;
            chungTu.MaUserLap = PSC_ERP_Global.Main.UserID;
            IQueryable<tblCongCuDungCu> ccdcChuaPhanBoHetList = CongCuDungCu_Factory.New().GetList_CCDCChuyenTuTaiSanChuaPhanBoChiPhiHet();
            foreach (var ccdc in ccdcChuaPhanBoHetList)
            {
                tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan chiTietNew = CT_PhanBoChiPhiCCDCChuyenTuTaiSan_Factory.New().CreateAloneObject();
                //đưa chi tiết mới vào danh sách
                chungTu.tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan.Add(chiTietNew);
                //mã ccdc
                chiTietNew.MaCongCuDungCu = ccdc.MaCongCuDungCu;
                //chi phí còn lại trước phân bổ = (Nguyen giá - Lũy kế KH - lũy kế HM) - chi phí đã phân bổ
                chiTietNew.ChiPhiConLaiTruocPhanBo = ((ccdc.NguyenGia ?? 0) - (ccdc.LuyKeKHTaiSanChuyenSang ?? 0) - (ccdc.LuyKeHMTaiSanChuyenSang ?? 0))
                                                        - (ccdc.ChiPhiDaPhanBo ?? 0);

                chiTietNew.PhanTramPhanBo = 0;
                chiTietNew.ChiPhiPhanBo = 0;

            }
            return chungTu;
        }
        public tblPhanBoChiPhiCCDCChuyenTuTaiSan Get_ByID(Int32 documentID)
        {

            var result = (from o in this.ObjectSet
                          where o.MaPhanBo == documentID
                          select o).SingleOrDefault();
            return result;
        }
        public IQueryable<tblPhanBoChiPhiCCDCChuyenTuTaiSan> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, DateTime ngayChungTu, DateTime ngayChungTuDen)
        {
            IQueryable<tblPhanBoChiPhiCCDCChuyenTuTaiSan> query = null;

            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = this.GetAll();
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {
                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in this.ObjectSet
                                    where o.SoChungTu == soChungTu
                                    orderby o.NgayChungTu descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in this.ObjectSet
                                    where o.SoChungTu.ToLower().Contains(soChungTuLower)
                                    orderby o.NgayChungTu descending
                                    select o;
                        }

                    }
                    break;
                case LoaiTimChungTuEnum.NgayLap://tìm theo ngày chứng từ
                    {
                        switch (compareType)
                        {
                            case CompareTypeEnum.Equal:
                                query = from o in this.ObjectSet
                                        where o.NgayChungTu == ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in this.ObjectSet
                                        where o.NgayChungTu < ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in this.ObjectSet
                                        where o.NgayChungTu <= ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in this.ObjectSet
                                        where o.NgayChungTu >= ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in this.ObjectSet
                                        where o.NgayChungTu > ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in this.ObjectSet
                                        where o.NgayChungTu >= ngayChungTu.Date
                                         && o.NgayChungTu <= ngayChungTuDen.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            return query;
        }


        public void FullDelete(params Object[] deleteList)
        {
            FullDelete(this.Context, deleteList);
        }
        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            //duyệt qua danh sách
            foreach (tblPhanBoChiPhiCCDCChuyenTuTaiSan item in deleteList)
            {
                CT_PhanBoChiPhiCCDCChuyenTuTaiSan_Factory.FullDelete(context, item.tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan.ToArray());
                //xóa
                context.tblPhanBoChiPhiCCDCChuyenTuTaiSans.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
