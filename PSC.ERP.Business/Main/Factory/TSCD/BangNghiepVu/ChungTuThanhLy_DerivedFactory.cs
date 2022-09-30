using ERP_Library.Security;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using PSC_ERP_Core;
using System;
using System.Data;
using System.Linq;

namespace PSC_ERP_Business.Main.Factory
{
    public class ChungTuThanhLy_DerivedFactory : ChungTu_Factory
    {
        //int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        //int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        //int _groupID = ERP_Library.Security.CurrentUser.Info.GroupID;
         UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

#pragma warning disable CS0108 // 'ChungTuThanhLy_DerivedFactory.CreateStandAloneObject()' hides inherited member 'ChungTu_Factory.CreateStandAloneObject()'. Use the new keyword if hiding was intended.
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
#pragma warning restore CS0108 // 'ChungTuThanhLy_DerivedFactory.CreateStandAloneObject()' hides inherited member 'ChungTu_Factory.CreateStandAloneObject()'. Use the new keyword if hiding was intended.
        {
            return ChungTuThanhLy_DerivedFactory.New().CreateAloneObject();
        }
#pragma warning disable CS0108 // 'ChungTuThanhLy_DerivedFactory.New()' hides inherited member 'ChungTu_Factory.New()'. Use the new keyword if hiding was intended.
        public static ChungTuThanhLy_DerivedFactory New()
#pragma warning restore CS0108 // 'ChungTuThanhLy_DerivedFactory.New()' hides inherited member 'ChungTu_Factory.New()'. Use the new keyword if hiding was intended.
        {
            return new ChungTuThanhLy_DerivedFactory();
        }
        public ChungTuThanhLy_DerivedFactory()
            : base()
        {

        }

        #region Custom
        public tblChungTu NewChungTu()
        {
            //khởi tạo mới chứng từ được quản lý bởi factory
            tblChungTu chungTu = chungTu = this.CreateManagedObject();

            DateTime ngayHeThong = app_users_Factory.New().SystemDate;

            //xác định ngày chứng từ
            chungTu.NgayLap = DateTime.MinValue.AddDays(1);
            chungTu.NgayLap = ngayHeThong;

            //xác định loại chứng từ
            chungTu.MaLoaiChungTu = PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy;

            //tạo mới tiền tệ cho chứng từ
            chungTu.tblTienTe = TienTe_Factory.New().CreateAloneObject();
            chungTu.tblTienTe.TiGiaQuyDoi = 1;
            //tạo mới định khoản
            chungTu.tblDinhKhoan = DinhKhoan_Factory.New().CreateAloneObject();

            //Tạo mới nghiệp
            tblNVThanhLyvaDieuChuyenNgoaiTSCD nghiepVu = NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.New().CreateAloneObject();
            nghiepVu.ThanhLy = true;
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;


            chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.Add(nghiepVu);

            //Phát sinh số chứng từ mới
            chungTu.MaChungTuQL = Get_NextMaChungTuQL_ByYear_And_Month(ngayHeThong.Year, ngayHeThong.Month, PSC_ERP_Global.Main.UserID);
            chungTu.SoChungTu = base.Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(ngayHeThong.Year, ngayHeThong.Month, _user.MaCongTy);

            //gán user lập
            chungTu.MaNguoiLap = PSC_ERP_Global.Main.UserID;
            chungTu.MaBoPhanDangNhap = PSC_ERP_Global.Main.MaBoPhanCuaUser;
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;
            return chungTu;
        }

        //public static String IncreaseMaChungTuQL(String soHieu, int year, int userID)
        //{
        //    int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLThanhLy_IncreasePart;
        //    string soChungTuMoi = "";
        //    int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
        //    int soMoi = max + 1;
        //    string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
        //    soChungTuMoi = FillFormat("{0}TLTS/{1}/{2}/{3}", stringSoMoi, year, userID);           
        //    return soChungTuMoi;

        //}
        public  String IncreaseMaChungTuQL_ByYear_And_Month(String soHieu, int year, int month, int userID)
        {
           // app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLThanhLy_IncreasePart;
            string soChungTuMoi = "";
            int max = int.Parse(soHieu.Substring(4, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            soChungTuMoi = String.Format("TLTS{0}-{1}{2}/{3}-{4}", stringSoMoi, nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);
            return soChungTuMoi;

        }
        //private String CreateFirst_MaChungTuQL_ByYear(int year, int userID)
        //{
        //    String result = "";
        //    Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLThanhLy_IncreasePart;


        //    result = FillFormat("{0}TLTS/{1}/{2}/{3}", new String('0', sizeOfNumber - 1) + "1", year, userID);

        //    return result;
        //}
        private String CreateFirst_MaChungTuQL_ByYear_And_Month(int year, int month, int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLThanhLy_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            result = String.Format("TLTS{0}-{1}{2}/{3}-{4}", new String('0', sizeOfNumber - 1) + "1", nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);

            return result;
        }
        //private static string FillFormat(String format, string stringSoMoi, int year, int userID)
        //{
        //    app_users user = app_users_Factory.New().Get_AppUserByUserID(userID);
        //    tblnsBoPhan boPhan = BoPhan_Factory.New().Get_ByID((user.MaBoPhan ?? 0));
        //    String maBoPhanQL = "";
        //    if (boPhan != null)
        //        maBoPhanQL = boPhan.MaBoPhanQL ?? String.Empty;
        //    String soChungTuMoi = String.Format(format, stringSoMoi, (user.MaQLUser ?? String.Empty), maBoPhanQL, year);
        //    return soChungTuMoi;
        //}
        //private String Get_MaxMaChungTuQL_ByYear(int year, int userID)
        //{
        //    Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLThanhLy_IncreasePart;
        //    String code = (from o in this.ObjectSet
        //                   where o.NgayLap.Value.Year == year
        //                   && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy
        //                   && o.MaNguoiLap == userID
        //                   orderby o.MaChungTuQL.Substring(0, sizeOfNumber) descending
        //                   select o.MaChungTuQL).FirstOrDefault();

        //    return code;
        //}
        //public String Get_NextMaChungTuQL_ByYear(int year, int userID)
        //{
        //    Int32 size = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLThanhLy_IncreasePart;
        //    String result = "";

        //    String maxCode = Get_MaxMaChungTuQL_ByYear(year, userID);

        //    if (!String.IsNullOrWhiteSpace(maxCode))
        //        result = IncreaseMaChungTuQL(maxCode, year, userID);
        //    else
        //        result = CreateFirst_MaChungTuQL_ByYear(year, userID);

        //    return result;
        //}
        private String Get_MaxMaChungTuQL_ByYear_And_Month(int year, int month, int userID)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLThanhLy_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            string namThang = $"{nam}{thang}";

            var code = (from o in this.ObjectSet
                        where o.NgayLap.Value.Year == year
                        && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy
                        && o.MaCongTy.Value == ERP_Library.Security.CurrentUser.Info.MaCongTy
                        && (o.MaChungTuQL).Substring(9, 4) == namThang
                        orderby o.MaChungTuQL.Substring(4, sizeOfNumber) descending
                        select o.MaChungTuQL).Take(1);

            return (code.ToList()).Any() ? (code.ToList()).First() : null;
        }
        public String Get_NextMaChungTuQL_ByYear_And_Month(int year, int month, int userID)
        {
#pragma warning disable CS0219 // The variable 'size' is assigned but its value is never used
              Int32 size = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLThanhLy_IncreasePart;
#pragma warning restore CS0219 // The variable 'size' is assigned but its value is never used
            String result = "";

            String maxCode = Get_MaxMaChungTuQL_ByYear_And_Month(year, month, userID);

            if (!String.IsNullOrWhiteSpace(maxCode))
                result = IncreaseMaChungTuQL_ByYear_And_Month(maxCode, year, month, userID);
            else
                result = CreateFirst_MaChungTuQL_ByYear_And_Month(year, month, userID);

            return result;
        }

        public override IQueryable<tblChungTu> GetAll()
        {
            IQueryable<tblChungTu> query = from o in this.ObjectSet
                                           where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }

        public override tblChungTu Get_ChungTu_ByMaChungTu(long maChungTu)
        {
            tblChungTu obj = (from o in this.ObjectSet
                              where o.MaChungTu == maChungTu
                              && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy
                              select o).SingleOrDefault();
            return obj;
        }

        public void FullDelete(tblChungTu chungTu)
        {
            try
            {
                tblNVThanhLyvaDieuChuyenNgoaiTSCD nghiepVu = chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.FirstOrDefault();

                foreach (tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD item in nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD)
                {
                    //Cập nhật lại tài sản cố định cá biệt
                    item.tblTaiSanCoDinhCaBiet.ThanhLy = false;
                    item.tblTaiSanCoDinhCaBiet.NgayThanhLy = null;
                    item.tblTaiSanCoDinhCaBiet.MaNghiepVuThanhLy = null;

                    //Cập nhật lại đã thực hiện nghiệp vụ trong duyệt tài sản cá biệt phòng ban
                    item.tblDuyetTSCD.DaThucHienNghiepVu = false;
                }
                //Xóa nghiệp vụ thanh lý
                NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.FullDelete(this.Context, nghiepVu);
                //xóa chi tiết
                BaseFactory<Entities, tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD>.DeleteHelper(this.Context, nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD);

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (System.Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }

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

        public IQueryable<tblChungTu> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, Decimal soTien, Decimal soTienDen, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 maDoiTac, Int32 userID = 0)
        {
            IQueryable<tblChungTu> query = null;
            IQueryable<tblChungTu> chungTuList = null;
            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userID))
                isAdmin = true;
            //if (_user.GroupID == 38 && _user.MaCongTy == 14) {
            //     chungTuList = from o in this.ObjectSet
            //                                         where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy
            //                                         && o.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.FirstOrDefault().ThanhLy == true
            //                                         && o.TrangThai>=1
            //                                                    //&& (isAdmin == true || userID == 0 || o.MaNguoiLap == userID
            //                                                    // || o.app_users.app_UserChild1.Any(x => x.UserID == userID))
            //                                         select o;
            //}
            //else {
                 chungTuList = from o in this.ObjectSet
                                                     where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy
                                                     && o.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.FirstOrDefault().ThanhLy == true
                                                                && (isAdmin == true || userID == 0 || o.MaNguoiLap == userID
                                                                 || o.app_users.app_UserChild1.Any(x => x.UserID == userID))
                                                     select o;
            //}
            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = chungTuList;//this.GetAll();
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {
                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in chungTuList
                                    where o.SoChungTu == soChungTu
                                    orderby o.NgayLap descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in chungTuList
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
                                query = from o in chungTuList
                                        where o.NgayLap == ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in chungTuList
                                        where o.NgayLap < ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in chungTuList
                                        where o.NgayLap <= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in chungTuList
                                        where o.NgayLap >= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in chungTuList
                                        where o.NgayLap > ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in chungTuList
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
                            query = from o in chungTuList
                                    where o.tblTienTe.ThanhTien == soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThan:
                            query = from o in chungTuList
                                    where o.tblTienTe.ThanhTien < soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.LessThanOrEqual:
                            query = from o in chungTuList
                                    where o.tblTienTe.ThanhTien <= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThanOrEqual:
                            query = from o in chungTuList
                                    where o.tblTienTe.ThanhTien >= soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.GreaterThan:
                            query = from o in chungTuList
                                    where o.tblTienTe.ThanhTien > soTien
                                    orderby o.NgayLap descending
                                    select o;
                            break;
                        case CompareTypeEnum.Between:
                            query = from o in chungTuList
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
                    query = from o in chungTuList
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
