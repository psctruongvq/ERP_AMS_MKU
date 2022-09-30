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
using ERP_Library.Security;

namespace PSC_ERP_Business.Main.Factory
{
    public class ChungTuDieuChinhGiaTriTaiSan_DerivedFactory : ChungTu_Factory
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChungTuDieuChinhGiaTriTaiSan_DerivedFactory.New().CreateAloneObject();
        }
        public static ChungTuDieuChinhGiaTriTaiSan_DerivedFactory New()
        {
            return new ChungTuDieuChinhGiaTriTaiSan_DerivedFactory();
        }
        public ChungTuDieuChinhGiaTriTaiSan_DerivedFactory()
            : base()
        {

        }

        #region Custom
        public tblChungTu NewChungTu()
        {
            //khởi tạo mới chứng từ được quản lý bởi factory
            tblChungTu chungTu = this.CreateManagedObject();

            DateTime ngayHeThong = app_users_Factory.New().SystemDate;
            //xác định ngày chứng từ
            chungTu.NgayLap = DateTime.MinValue.AddDays(1);
            chungTu.NgayLap = ngayHeThong;

            //xác định loại chứng từ là chứng từ điều chỉnh giá trị
            chungTu.MaLoaiChungTu = PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChinhGiaTri;

            //tạo mới tiền tệ cho chứng từ
            chungTu.tblTienTe = TienTe_Factory.New().CreateAloneObject();
            chungTu.tblTienTe.TiGiaQuyDoi = 1;
            //tạo mới định khoản
            chungTu.tblDinhKhoan = DinhKhoan_Factory.New().CreateAloneObject();

            //Phát sinh số chứng từ mới
            chungTu.MaChungTuQL = Get_NextMaChungTuQL_ByYear(ngayHeThong.Year, PSC_ERP_Global.Main.UserID);
            chungTu.SoChungTu = base.Get_NextSoChungTuPhieuKeToanTaiSan(ngayHeThong.Year, PSC_ERP_Global.Main.UserID);
            //tạo nghiệp vụ
            tblDieuChinhGiaTri nghiepVu = DieuChinhGiaTri_Factory.New().CreateAloneObject();
            //gán nguồn mua mặc định là lẻ
            nghiepVu.NguonMua = ((int)LoaiNguonMuaEnum.Le == 1 ? true : false);//false lẻ
            //
            chungTu.tblDieuChinhGiaTris.Add(nghiepVu);

            //gán user lập
            chungTu.MaNguoiLap = PSC_ERP_Global.Main.UserID;
            chungTu.MaBoPhanDangNhap = PSC_ERP_Global.Main.MaBoPhanCuaUser;
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;
            return chungTu;
        }
        public static void CapNhatLaiTongTienChungTu(tblDieuChinhGiaTri dieuChinhGiaTri)
        {
            //cập nhật lại tổng tiền chứng từ
            Decimal tongTien = 0;
            foreach (var item in dieuChinhGiaTri.tblChiTietDieuChinhGiaTris)
            {
                tongTien += (item.GiaTriTang == null ? 0 : item.GiaTriTang.Value) - (item.GiaTriGiam == null ? 0 : item.GiaTriGiam.Value);
            }
            dieuChinhGiaTri.tblChungTu.tblTienTe.SoTien = tongTien;
        }
        public  String IncreaseMaChungTuQL(String soHieu, int year, int userID)
        {

            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLDieuChinhGiaTaiSan_IncreasePart;


            string newCode = "";


            int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            newCode = FillFormat("{0}DCTS/{1}/{2}/{3}", stringSoMoi, year, userID);


            return newCode;

        }
        private String CreateFirst_MaChungTuQL_ByYear(int year, int userID)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLDieuChinhGiaTaiSan_IncreasePart;


            result = FillFormat("{0}DCTS/{1}/{2}/{3}", new String('0', sizeOfNumber - 1) + "1", year, userID);

            return result;
        }
        private  string FillFormat(String format, string stringSoMoi, int year, int userID)
        {
           // app_users user = app_users_Factory.New().Get_AppUserByUserID(userID);
            tblnsBoPhan boPhan = BoPhan_Factory.New().Get_ByID((_user.MaBoPhan));
            String maBoPhanQL = "";
            if (boPhan != null)
                maBoPhanQL = boPhan.MaBoPhanQL ?? String.Empty;
            String code = String.Format(format, stringSoMoi, (_user.MaQLUser ?? String.Empty), maBoPhanQL, year);
            return code;
        }
        private String Get_MaxMaChungTuQL_ByYear(int year, int userID)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLDieuChinhGiaTaiSan_IncreasePart;
            String code = (from o in this.ObjectSet
                           where o.NgayLap.Value.Year == year
                           && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChinhGiaTri
                           && o.MaNguoiLap == userID
                           orderby o.MaChungTuQL.Substring(0, sizeOfNumber) descending
                           select o.MaChungTuQL).FirstOrDefault();

            return code;
        }
        public String Get_NextMaChungTuQL_ByYear(int year, int userID)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLDieuChinhGiaTaiSan_IncreasePart;
            String result = "";


            String maxSoHieu = Get_MaxMaChungTuQL_ByYear(year, userID);


            if (!String.IsNullOrWhiteSpace(maxSoHieu))
                result = IncreaseMaChungTuQL(maxSoHieu, year, userID);
            else
                result = CreateFirst_MaChungTuQL_ByYear(year, userID);

            return result;
        }


        public override IQueryable<tblChungTu> GetAll()
        {
            IQueryable<tblChungTu> query = from o in this.ObjectSet
                                           where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChinhGiaTri
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }

        public override tblChungTu Get_ChungTu_ByMaChungTu(long maChungTu)
        {
            tblChungTu obj = (from o in this.ObjectSet
                              where o.MaChungTu == maChungTu
                              && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChinhGiaTri
                              select o).SingleOrDefault();
            return obj;
        }

        public void XoaChungTu(tblChungTu chungTu)
        {

            tblDieuChinhGiaTri nghiepVu = chungTu.tblDieuChinhGiaTris.FirstOrDefault();

            //xóa nghiệp vụ
            DieuChinhGiaTri_Factory.FullDelete(this.Context, nghiepVu);

            //xóa tiền tệ
            if (chungTu.tblTienTe != null)
                this.Context.tblTienTes.DeleteObject(chungTu.tblTienTe);

            //xóa chứng từ hợp đồng
            //ChungTu_HopDong_Factory.FullDeleteChungTu_HopDong(this.Context, chungTu.tblChungTu_HopDong.ToList<Object>());

            //xóa hóa đơn
            //ChungTu_HoaDon_Factory.FullDeleteChungTu_HoaDon(this.Context, chungTu.tblChungTu_HoaDon.ToList<Object>());

            tblDinhKhoan dinhKhoan = chungTu.tblDinhKhoan;
            //xóa chứng từ
            this.DeleteObject(chungTu);

            //xóa định khoản, bút toán
            {

                if (dinhKhoan != null)
                {
                    DinhKhoan_Factory.FullDelete(this.Context, dinhKhoan);
                }
            }
            //

        }


        public IQueryable<tblChungTu> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, Decimal soTien, Decimal soTienDen, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 userID = 0)
        {
            IQueryable<tblChungTu> query = null;
            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userID))
                isAdmin = true;
            IQueryable<tblChungTu> chungTuDCGTList = from o in this.ObjectSet
                                                     where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChinhGiaTri
                                                         && (isAdmin == true || userID == 0 || o.MaNguoiLap == userID
                                                          || o.app_users.app_UserThuLao1.Any(x => x.UserID == userID))
                                                     select o;

            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = chungTuDCGTList;//this.GetAll();
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {

                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in chungTuDCGTList
                                    where o.SoChungTu == soChungTu
                                    orderby o.NgayLap descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in chungTuDCGTList
                                    where o.SoChungTu.ToLower().Contains(soChungTuLower)
                                    orderby o.NgayLap descending
                                    select o;
                        }

                    }
                    break;
                case LoaiTimChungTuEnum.NgayLap://tìm theo ngày chứng từ
                    {
                        switch (compareType)
                        {
                            case CompareTypeEnum.Equal:
                                query = from o in chungTuDCGTList
                                        where o.NgayLap == ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in chungTuDCGTList
                                        where o.NgayLap < ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in chungTuDCGTList
                                        where o.NgayLap <= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in chungTuDCGTList
                                        where o.NgayLap >= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in chungTuDCGTList
                                        where o.NgayLap > ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in chungTuDCGTList
                                        where o.NgayLap >= ngayChungTu.Date
                                         && o.NgayLap <= ngayChungTuDen.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case LoaiTimChungTuEnum.SoTien://tìm theo số tiền
                    switch (compareType)
                    {
                        case CompareTypeEnum.Equal:
                            query = from o in chungTuDCGTList
                                    where o.tblTienTe.ThanhTien == soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in chungTuDCGTList
                                    where o.tblTienTe.ThanhTien < soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in chungTuDCGTList
                                    where o.tblTienTe.ThanhTien <= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in chungTuDCGTList
                                    where o.tblTienTe.ThanhTien >= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in chungTuDCGTList
                                    where o.tblTienTe.ThanhTien > soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.Between:
                            query = from o in chungTuDCGTList
                                    where o.tblTienTe.ThanhTien >= soTien
                                     && o.tblTienTe.ThanhTien <= soTienDen
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        default:
                            break;
                    }
                    break;
                //case LoaiTimChungTuEnum.DoiTac://tìm theo mã đối tác
                //    query = from o in chungTuDCGTList
                //            where o.MaDoiTuong == maDoiTac
                //            orderby o.NgayLap descending
                //            select o;
                //    break;
                default:
                    break;
            }

            return query;
        }
        #endregion
    }//end class
}
