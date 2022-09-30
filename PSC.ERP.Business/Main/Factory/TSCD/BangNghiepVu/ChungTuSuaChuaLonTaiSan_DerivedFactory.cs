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
    public class ChungTuSuaChuaLonTaiSan_DerivedFactory : ChungTu_Factory
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        //int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        public static BaseEntityObject CreateStandAloneObject()
        {
            return ChungTuSuaChuaLonTaiSan_DerivedFactory.New().CreateAloneObject();
        }
        public static ChungTuSuaChuaLonTaiSan_DerivedFactory New()
        {
            return new ChungTuSuaChuaLonTaiSan_DerivedFactory();
        }
        public ChungTuSuaChuaLonTaiSan_DerivedFactory()
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

            //xác định loại chứng từ là chứng từ sửa chữa lớn tài sản
            chungTu.MaLoaiChungTu = PSC_ERP_Global.TSCD.MaLoaiChungTuSuaChuaLonTSCD;
            chungTu.MaCongTy = _user.MaCongTy;
            //tạo mới tiền tệ cho chứng từ
            chungTu.tblTienTe = TienTe_Factory.New().CreateAloneObject();
            chungTu.tblTienTe.TiGiaQuyDoi = 1;
            //tạo mới định khoản
            chungTu.tblDinhKhoan = DinhKhoan_Factory.New().CreateAloneObject();

            //Phát sinh số chứng từ mới
            //chungTu.MaChungTuQL = Get_NextMaChungTuQL_ByYear(ngayHeThong.Year, PSC_ERP_Global.Main.UserID);
            chungTu.MaChungTuQL = Get_NextMaChungTuQL_ByYear_And_Month(ngayHeThong.Year, ngayHeThong.Month, _user.MaCongTy);
            //chungTu.SoChungTu = base.Get_NextSoChungTuPhieuKeToanTaiSan(ngayHeThong.Year, PSC_ERP_Global.Main.UserID);
            chungTu.SoChungTu = base.Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(ngayHeThong.Year, ngayHeThong.Month, _user.MaCongTy);
            //tạo nghiệp vụ
            tblNghiepVuSuaChuaLon nghiepVu = NghiepVuSuaChuaLon_Factory.New().CreateAloneObject();
            chungTu.tblNghiepVuSuaChuaLons.Add(nghiepVu);
            //gán nguồn mặc định
            nghiepVu.NguonMua = Convert.ToBoolean(LoaiNguonMuaEnum.Le);
            //gán user lập
            chungTu.MaNguoiLap = PSC_ERP_Global.Main.UserID;
            chungTu.MaBoPhanDangNhap = PSC_ERP_Global.Main.MaBoPhanCuaUser;
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;
            return chungTu;
        }

        //public  String IncreaseMaChungTuQL(String soHieu, int year, int userID)
        //{
        //    int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLSuaChuaLonTaiSan_IncreasePart;

        //    string newCode = "";

        //    int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
        //    int soMoi = max + 1;
        //    string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

        //    newCode = FillFormat("{0}SCTS/{1}/{2}/{3}", stringSoMoi, year, userID);
        //    return newCode;
        //}

        public String IncreaseMaChungTuQL_ByYear_and_Month(String soHieu, int year, int month, int maCongTy)
        {
            // app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            // tblCongTy congTy = CongTy_Factory.New().Get_ByID(_user.MaCongTy);
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            string newCode = "";
            int max = int.Parse(soHieu.Substring(4, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            newCode = String.Format("SCTS{0}-{1}{2}/{3}-{4}", stringSoMoi, nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);
            return newCode;
        }
        private String CreateFirst_MaChungTuQL_ByYear_And_Month(int year, int month, int maCongTy)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            result = String.Format("SCTS{0}-{1}{2}/{3}-{4}", new String('0', sizeOfNumber - 1) + "1", nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);
            return result;
        }

        private string FillFormat(String format, string stringSoMoi, int year, int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(userID);
            tblnsBoPhan boPhan = BoPhan_Factory.New().Get_ByID((_user.MaBoPhan));
            String maBoPhanQL = "";
            if (boPhan != null)
                maBoPhanQL = boPhan.MaBoPhanQL ?? String.Empty;
            String soChungTuMoi = String.Format(format, stringSoMoi, (_user.MaQLUser ?? String.Empty), maBoPhanQL, year);
            return soChungTuMoi;
        }

        public String Get_NextMaChungTuQL_ByYear_And_Month(int year, int month, int maCongTy)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            String result = "";
            String maxCode = Get_MaxMaChungTuQL_ByYear_And_Month(year, month, maCongTy);

            if (!String.IsNullOrWhiteSpace(maxCode))
                result = IncreaseMaChungTuQL_ByYear_and_Month(maxCode, year, month, maCongTy);
            else
                result = CreateFirst_MaChungTuQL_ByYear_And_Month(year, month, maCongTy);

            return result;
        }

        private String Get_MaxMaChungTuQL_ByYear_And_Month(int year, int month, int maCongTy)
        {
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            string namThang = $"{nam}{thang}";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLSuaChuaLonTaiSan_IncreasePart;
            var code = (from o in this.ObjectSet
                           where o.NgayLap.Value.Year == year
                           && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuSuaChuaLonTSCD
                           && o.MaCongTy.Value == maCongTy
                           && (o.MaChungTuQL).Substring(9, 4) == namThang
                           orderby o.MaChungTuQL.Substring(4, sizeOfNumber) descending
                           select o.MaChungTuQL).Take(1);

            return (code.ToList()).Any() ?  (code.ToList()).First() :null ;
        }


        public override IQueryable<tblChungTu> GetAll()
        {
            IQueryable<tblChungTu> query = from o in this.ObjectSet
                                           where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuSuaChuaLonTSCD
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }

        public override tblChungTu Get_ChungTu_ByMaChungTu(long maChungTu)
        {
            tblChungTu obj = (from o in this.ObjectSet
                              where o.MaChungTu == maChungTu
                              && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuSuaChuaLonTSCD
                              select o).SingleOrDefault();
            return obj;
        }

        public void XoaChungTu(tblChungTu chungTu)
        {
            try
            {
                tblNghiepVuSuaChuaLon nghiepVu = chungTu.tblNghiepVuSuaChuaLons.FirstOrDefault();
                //xóa nghiệp vụ
                NghiepVuSuaChuaLon_Factory.FullDelete(this.Context, nghiepVu);
            }
            catch (System.Exception ex)
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

            //

        }


        public IQueryable<tblChungTu> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, Decimal soTien, Decimal soTienDen, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 maDoiTac, Int32 userID = 0)
        {
            IQueryable<tblChungTu> query = null;
            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userID))
                isAdmin = true;

            IQueryable<tblChungTu> chungTuList = from o in this.ObjectSet
                                                 where (o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuSuaChuaLonTSCD
                                                      && o.MaCongTy == _user.MaCongTy) &&
                                                      (o.MaNguoiLap == userID || isAdmin == true || userID == 0 || o.app_users.app_UserChild1.Any(x => x.UserID == userID))
                                                 select o;

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
