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
    public class ChungTuDieuChuyenNgoai_DerivedFactory : ChungTu_Factory
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChungTuDieuChuyenNgoai_DerivedFactory.New().CreateAloneObject();
        }
        public static ChungTuDieuChuyenNgoai_DerivedFactory New()
        {
            return new ChungTuDieuChuyenNgoai_DerivedFactory();
        }
        public ChungTuDieuChuyenNgoai_DerivedFactory()
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
            chungTu.MaLoaiChungTu = PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChuyenNgoai;

            //tạo mới tiền tệ cho chứng từ
            chungTu.tblTienTe = TienTe_Factory.New().CreateAloneObject();
            chungTu.tblTienTe.TiGiaQuyDoi = 1;
            //tạo mới định khoản
            chungTu.tblDinhKhoan = DinhKhoan_Factory.New().CreateAloneObject();

            //Tạo mới nghiệp vụ
            tblNVThanhLyvaDieuChuyenNgoaiTSCD nghiepVu = NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.New().CreateAloneObject();
            nghiepVu.DieuChuyenNgoai = true;
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;

            chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.Add(nghiepVu);

            //Phát sinh số chứng từ mới
            chungTu.MaChungTuQL = Get_NextMaChungTuQL_ByYear(ngayHeThong.Year, PSC_ERP_Global.Main.UserID);
            chungTu.SoChungTu = base.Get_NextSoChungTuPhieuKeToanTaiSan(ngayHeThong.Year, PSC_ERP_Global.Main.UserID);

            //gán user lập
            chungTu.MaNguoiLap = PSC_ERP_Global.Main.UserID;
            chungTu.MaBoPhanDangNhap = PSC_ERP_Global.Main.MaBoPhanCuaUser;
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;
            return chungTu;
        }

        public  String IncreaseMaChungTuQL(String soHieu, int year, int userID)
        {

            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLDieuChuyenNgoai_IncreasePart;

            string code = "";

            int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            code = FillFormat("DCBN{0}/{1}/{2}/{3}", stringSoMoi, year, userID);


            return code;

        }
        private String CreateFirst_MaChungTuQL_ByYear(int year, int userID)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLDieuChuyenNgoai_IncreasePart;


            result = FillFormat("DCBN{0}/{1}/{2}/{3}", new String('0', sizeOfNumber - 1) + "1", year, userID);

            return result;
        }
        private  string FillFormat(String format, string stringSoMoi, int year, int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(userID);
            tblnsBoPhan boPhan = BoPhan_Factory.New().Get_ByID((_user.MaBoPhan));
            String maBoPhanQL = "";
            if (boPhan != null)
                maBoPhanQL = boPhan.MaBoPhanQL ?? String.Empty;
            String code = String.Format(format, stringSoMoi, (_user.MaQLUser ?? String.Empty), maBoPhanQL, year);
            return code;
        }
        private String Get_MaxMaChungTuQL_ByYear(int year, int userID)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLDieuChuyenNgoai_IncreasePart;
            String code = (from o in this.ObjectSet
                           where o.NgayLap.Value.Year == year
                           && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChuyenNgoai
                           && o.MaNguoiLap == userID
                           orderby o.MaChungTuQL.Substring(4, sizeOfNumber) descending
                           select o.MaChungTuQL).FirstOrDefault();

            return code;
        }
        public String Get_NextMaChungTuQL_ByYear(int year, int userID)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLDieuChuyenNgoai_IncreasePart;
            String result = "";

            String maxCode = Get_MaxMaChungTuQL_ByYear(year, userID);

            if (!String.IsNullOrWhiteSpace(maxCode))
                result = IncreaseMaChungTuQL(maxCode, year, userID);
            else
                result = CreateFirst_MaChungTuQL_ByYear(year, userID);

            return result;
        }


        public override IQueryable<tblChungTu> GetAll()
        {
            IQueryable<tblChungTu> query = from o in this.ObjectSet
                                           where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChuyenNgoai
                                           orderby o.NgayLap descending
                                           select o;
            return query;
        }

        public override tblChungTu Get_ChungTu_ByMaChungTu(long maChungTu)
        {
            tblChungTu obj = (from o in this.ObjectSet
                              where o.MaChungTu == maChungTu
                              && o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChuyenNgoai
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
                NVThanhLyvaDieuChuyenNgoaiTSCD_Factory.FullDelete(this.Context, nghiepVu);
                //clear chi tiết
                BaseFactory<Entities, tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD>.DeleteHelper(this.Context, nghiepVu.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD);

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

        }

        public IQueryable<tblChungTu> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, Decimal soTien, Decimal soTienDen, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 maDoiTac, Int32 userID = 0)
        {
            IQueryable<tblChungTu> query = null;
            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userID))
                isAdmin = true;
            IQueryable<tblChungTu> chungTuList = from o in this.ObjectSet
                                                 where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChuyenNgoai
                                                 && (o.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.FirstOrDefault().DieuChuyenNgoai ?? false) == true
                                                            && (isAdmin == true || userID == 0 || o.MaNguoiLap == userID
                                                             || o.app_users.app_UserThuLao1.Any(x => x.UserID == userID))
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
