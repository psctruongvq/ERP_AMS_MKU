using System;
using System.Linq;
using PSC_ERP_Core;
using System.Data;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using ERP_Library.Security;

namespace PSC_ERP_Business.Main.Factory
{
    public class ChungTuGhiTangTaiSan_DerivedFactory : ChungTu_Factory
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         UserInfo _user = ERP_Library.Security.CurrentUser.Info;
       // static  UserItem _user = UserItem.GetUserItem(CurrentUser.Info.UserID);
        public static BaseEntityObject CreateStandAloneObject()
        {
            return ChungTuGhiTangTaiSan_DerivedFactory.New().CreateAloneObject();
        }
        public static ChungTuGhiTangTaiSan_DerivedFactory New()
        {
            return new ChungTuGhiTangTaiSan_DerivedFactory();
        }
        public ChungTuGhiTangTaiSan_DerivedFactory(): base()
        {

        }

        #region Custom
        public tblChungTu NewChungTuGhiTangTaiSan()
        {
            //khởi tạo mới chứng từ được quản lý bởi factory
            tblChungTu chungTu = this.CreateManagedObject();
            DateTime ngayHeThong = app_users_Factory.New().SystemDate;
            //xác định ngày chứng từ
            chungTu.NgayLap = DateTime.MinValue;
            chungTu.NgayLap = ngayHeThong;
            chungTu.NgayHeThong = ngayHeThong;
            chungTu.NgayThucHien = ngayHeThong;
            //xác định loại chứng từ là chứng từ ghi tăng tài sản
            chungTu.MaLoaiChungTu = PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD;
             //tạo mới tiền tệ cho chứng từ
            chungTu.tblTienTe = TienTe_Factory.New().CreateAloneObject();
            chungTu.tblTienTe.TiGiaQuyDoi = 1;
            //tạo mới định khoản
            chungTu.tblDinhKhoan = DinhKhoan_Factory.New().CreateAloneObject();
            chungTu.MaCongTy = _user.MaCongTy;
            //gan mã bằng giá trị rỗng trước
            chungTu.MaChungTuQL = "";
            //chungTu.SoChungTu = "";
            //Phát sinh mã
            chungTu.MaChungTuQL = Get_NextMaChungTuQL_ByYear_And_Month(ngayHeThong.Year, ngayHeThong.Month, _user.MaCongTy);
             chungTu.SoChungTu = base.Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(ngayHeThong.Year, ngayHeThong.Month, _user.MaCongTy);
            //gán user lập
            chungTu.MaNguoiLap = _user.UserID;
            chungTu.MaBoPhanDangNhap = PSC_ERP_Global.Main.MaBoPhanCuaUser;
            return chungTu;
        }
        private String CreateFirst_MaChungTuQL_ByYear_And_Month(int year, int month, int maCongTy)
        {
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(_user.MaCongTy);
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            result = String.Format("GTTS{0}-{1}{2}/{3}-{4}", new String('0', sizeOfNumber - 1) + "1", nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);
            return result;
        }

        private String Get_MaxMaChungTuQL_ByYear_And_Month(int year, int month, int maCongTy)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            string namThang = $"{nam}{thang}";
            var code = (from p in this.ObjectSet
                        where p.NgayLap.Value.Year == year
                        && p.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                        && p.MaCongTy.Value == maCongTy
                        && (p.MaChungTuQL).Substring(9, 4) == namThang
                        orderby p.MaChungTuQL.Substring(4, sizeOfNumber) descending
                 select p.MaChungTuQL).Take(1);

            return (code.ToList()).Any() ? (code.ToList()).First() : null;
        }
        public String IncreaseMaChungTuQL_ByYear_and_Month(String soHieu, int year, int month, int maCongTy)
        {
           // tblCongTy congTy = CongTy_Factory.New().Get_ByID(_user.MaCongTy);
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            string newCode = "";
            int max = int.Parse(soHieu.Substring(4, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            newCode = String.Format("GTTS{0}-{1}{2}/{3}-{4}", stringSoMoi, nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);
            return newCode;
        }
        
     
        public String Get_NextMaChungTuQL_ByYear_And_Month(int year, int month, int maCongTy)
        {
            String result = "";
            String maxCode = Get_MaxMaChungTuQL_ByYear_And_Month(year, month, maCongTy);

            if (!String.IsNullOrWhiteSpace(maxCode))
                result = IncreaseMaChungTuQL_ByYear_and_Month(maxCode, year, month, maCongTy);
            else
                result = CreateFirst_MaChungTuQL_ByYear_And_Month(year, month, maCongTy);
            return result;
        }

        public override IQueryable<tblChungTu> GetAll()
        {
            IQueryable<tblChungTu> query = from o in this.ObjectSet
                                           where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }

        public override tblChungTu Get_ChungTu_ByMaChungTu(long maChungTu)
        {
            tblChungTu obj = (from o in this.ObjectSet
                              where o.MaChungTu == maChungTu
                              && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                              select o).SingleOrDefault();
            return obj;
        }

        public void XoaChungTuGhiTangTSCDCaBiet(tblChungTu chungTu)
        {
            //clear tài sản cá biệt
            TaiSanCoDinhCaBiet_Factory.FullDeleteTSCDCaBiet(context: this.Context, deleteList: chungTu.tblTaiSanCoDinhCaBiets.ToList<Object>());
            //xóa tiền tệ
            if (chungTu.tblTienTe != null)
                this.Context.tblTienTes.DeleteObject(chungTu.tblTienTe);
            //xóa chứng từ hợp đồng
            ChungTu_HopDong_Factory.FullDelete(this.Context, chungTu.tblChungTu_HopDong.ToList<Object>());
            //xóa hóa đơn
            ChungTu_HoaDon_Factory.FullDelete(this.Context, chungTu.tblChungTu_HoaDon.ToList<Object>());
            //new
            ChungTu_HoaDonTaiSan_Factory.FullDelete(this.Context, chungTu.tblChungTu_HoaDonTaiSan.ToList<Object>());
            //
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
        }

        public IQueryable<tblChungTu> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, Decimal soTien, Decimal soTienDen, DateTime ngayChungTu, DateTime ngayChungTuDen, Int64 maDoiTac, Int32 userID = 0)
        {
            IQueryable<tblChungTu> query = null;
            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userID))
                isAdmin = true;
            IQueryable<tblChungTu> chungTuGhiTangList = from o in this.ObjectSet
                                                        where (o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                                             && o.MaCongTy== _user.MaCongTy) && 
                                                             (o.MaNguoiLap == userID || isAdmin == true || userID == 0 || o.app_users.app_UserChild1.Any(x => x.UserID == userID))
                                                        select o;
            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = chungTuGhiTangList;
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {
                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in chungTuGhiTangList
                                    where o.SoChungTu == soChungTu
                                    orderby o.NgayLap descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in chungTuGhiTangList
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
                                query = from o in chungTuGhiTangList
                                        where o.NgayLap == ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in chungTuGhiTangList
                                        where o.NgayLap < ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in chungTuGhiTangList
                                        where o.NgayLap <= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in chungTuGhiTangList
                                        where o.NgayLap >= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in chungTuGhiTangList
                                        where o.NgayLap > ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in chungTuGhiTangList
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
                            query = from o in chungTuGhiTangList
                                    where o.tblTienTe.ThanhTien == soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in chungTuGhiTangList
                                    where o.tblTienTe.ThanhTien < soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in chungTuGhiTangList
                                    where o.tblTienTe.ThanhTien <= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in chungTuGhiTangList
                                    where o.tblTienTe.ThanhTien >= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in chungTuGhiTangList
                                    where o.tblTienTe.ThanhTien > soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.Between:
                            query = from o in chungTuGhiTangList
                                    where o.tblTienTe.ThanhTien >= soTien
                                     && o.tblTienTe.ThanhTien <= soTienDen
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        default:
                            break;
                    }
                    break;
                case LoaiTimChungTuEnum.DoiTac://tìm theo mã đối tác
                    query = from o in chungTuGhiTangList
                            where o.MaDoiTuong == maDoiTac
                            orderby o.NgayLap descending
                            select o;
                    break;
                default:
                    break;
            }

            return query;
        }

        #endregion
    }//end class
}
