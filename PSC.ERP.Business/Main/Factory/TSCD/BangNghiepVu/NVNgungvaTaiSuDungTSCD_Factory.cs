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
    public class NVNgungvaTaiSuDungTSCD_Factory : BaseFactory<Entities, tblNVNgungvaTaiSuDungTSCD>
    {
         UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NVNgungvaTaiSuDungTSCD_Factory.New().CreateAloneObject();
        }
        public static NVNgungvaTaiSuDungTSCD_Factory New()
        {
            return new NVNgungvaTaiSuDungTSCD_Factory();
        }
        public NVNgungvaTaiSuDungTSCD_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblNVNgungvaTaiSuDungTSCD NewNVNgungVaTaiSuDung_NgungSuDung()
        {
            DateTime ngayHeThong = app_users_Factory.New().SystemDate;//bị lỗi ko lấy được ngày hệ thống khi sử dụng this.SystemDate ở factory này
            //khởi tạo nghiệp vụ ngừn và tái sử dụng
            tblNVNgungvaTaiSuDungTSCD nghiepVu = this.CreateManagedObject();

            nghiepVu.NgayChungTu = ngayHeThong;

            ////Phát sinh số chứng từ mới
            nghiepVu.SoChungTu = NVNgungvaTaiSuDungTSCD_Factory.New().Get_NextSoChungTu_ByYear_And_Month_NgungSuDung(ngayHeThong.Year, ngayHeThong.Month, PSC_ERP_Global.Main.UserID);

            ////gán user lập
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;

            ///Loại nghiệp vụ ngung su dung
            nghiepVu.TaiSuDung = false;

            return nghiepVu;
        }
        public tblNVNgungvaTaiSuDungTSCD NewNVNgungVaTaiSuDung_TaiSuDung()
        {
            DateTime ngayHeThong = app_users_Factory.New().SystemDate;//bị lỗi ko lấy được ngày hệ thống khi sử dụng this.SystemDate ở factory này
            //khởi tạo nghiệp vụ ngừn và tái sử dụng
            tblNVNgungvaTaiSuDungTSCD nghiepVu = this.CreateManagedObject();

            nghiepVu.NgayChungTu = ngayHeThong;

            ////Phát sinh số chứng từ mới
            nghiepVu.SoChungTu = NVNgungvaTaiSuDungTSCD_Factory.New().Get_NextSoChungTu_ByYear_And_Month_TaiSuDung(ngayHeThong.Year, ngayHeThong.Month, PSC_ERP_Global.Main.UserID);

            ////gán user lập
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;

            ///Loại nghiệp vụ ngung su dung
            nghiepVu.TaiSuDung = true;

            return nghiepVu;
        }
        //public String Get_NextSoChungTu_ByYear_NgungSuDung(int year, int userID)
        //{
        //    Int32 size = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
        //    String result = "";


        //    String maxSoHieu = Get_MaxSoChungTu_ByYear_NgungSuDung(year,userID);

        //    if (!String.IsNullOrWhiteSpace(maxSoHieu))
        //        result = IncreaseSoChungTu_NgungSuDung(maxSoHieu, year,userID);
        //    else
        //        result = CreateFirst_SoChungTu_ByYear_NgungSuDung(year,userID);

        //    return result;
        //}

        //public String Get_NextSoChungTu_ByYear_TaiSuDung(int year, int userID)
        //{
        //    Int32 size = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
        //    String result = "";


        //    String maxSoHieu = Get_MaxSoChungTu_ByYear_TaiSuDung(year,userID);

        //    if (!String.IsNullOrWhiteSpace(maxSoHieu))
        //        result = IncreaseSoChungTu_TaiSuDung(maxSoHieu, year,userID);
        //    else
        //        result = CreateFirst_SoChungTu_ByYear_TaiSuDung(year,userID);

        //    return result;
        //}

        public String Get_NextSoChungTu_ByYear_And_Month_NgungSuDung(int year,int month,int userID)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
            String result = "";


            String maxSoHieu = Get_MaxSoChungTu_ByYear_And_Month_NgungSuDung(year, month,userID);

            if (!String.IsNullOrWhiteSpace(maxSoHieu))
                result = IncreaseSoChungTu_NgungSuDung_ByYear_And_Month(maxSoHieu, year, month,userID);
            else
                result = CreateFirst_SoChungTu_ByYear_And_Month_NgungSuDung(year, month,userID);

            return result;
        }

        public String Get_NextSoChungTu_ByYear_And_Month_TaiSuDung(int year, int month,int userID)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
            String result = "";


            String maxSoHieu = Get_MaxSoChungTu_ByYear_And_Month_TaiSuDung(year, month,userID);

            if (!String.IsNullOrWhiteSpace(maxSoHieu))
                result = IncreaseSoChungTu_TaiSuDung_ByYear_And_Month(maxSoHieu, year, month,userID);
            else
                result = CreateFirst_SoChungTu_ByYear_And_Month_TaiSuDung(year, month,userID);

            return result;
        }
        //private String CreateFirst_SoChungTu_ByYear_NgungSuDung(int year, int userID)
        //{
        //    String result = "";
        //    Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;

        //    result = FillFormat("NSDTS{0}/{1}/{2}/{3}", new String('0', sizeOfNumber - 1) + "1", year, userID);

        //    return result;
        //}
      
        //private String CreateFirst_SoChungTu_ByYear_TaiSuDung(int year, int userID)
        //{
        //    String result = "";
        //    Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;

        //    result = FillFormat("TSDTS{0}/{1}/{2}/{3}", new String('0', sizeOfNumber - 1) + "1", year,userID);

        //    return result;
        //}
        private String CreateFirst_SoChungTu_ByYear_And_Month_NgungSuDung(int year, int month,int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            result = String.Format("NSDTS{0}-{1}{2}/{3}-{4}", new String('0', sizeOfNumber - 1) + "1", nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);

            return result;
        }

        private String CreateFirst_SoChungTu_ByYear_And_Month_TaiSuDung(int year, int month,int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            result = String.Format("TSDTS{0}-{1}{2}/{3}-{4}", new String('0', sizeOfNumber - 1) + "1", nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);

            return result;
        }
        //public static String IncreaseSoChungTu_NgungSuDung(String soHieu, int year, int userID)
        //{
        //    int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;

        //    string soChungTuMoi = "";


        //    int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
        //    int soMoi = max + 1;
        //    string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

        //    soChungTuMoi = FillFormat("NSDTS{0}/{1}/{2}/{3}", stringSoMoi, year,userID);


        //    return soChungTuMoi;

        //}
        public String IncreaseSoChungTu_NgungSuDung_ByYear_And_Month(String soHieu, int year, int month, int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
            string soChungTuMoi = "";
           // int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
            int max = int.Parse(soHieu.Substring(5, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            soChungTuMoi = String.Format("NSDTS{0}-{1}{2}/{3}-{4}", stringSoMoi, nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);
            return soChungTuMoi;
        }
        //public static String IncreaseSoChungTu_TaiSuDung(String soHieu, int year, int userID)
        //{
        //    int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
        //    string soChungTuMoi = "";
        //    int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
        //    int soMoi = max + 1;
        //    string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
        //    soChungTuMoi = FillFormat("TSDTS{0}/{1}/{2}/{3}", stringSoMoi, year,userID);

        //    return soChungTuMoi;
        //}
        public  String IncreaseSoChungTu_TaiSuDung_ByYear_And_Month(String soHieu, int year, int month, int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
            string soChungTuMoi = "";
            int max = int.Parse(soHieu.Substring(5, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            soChungTuMoi = String.Format("TSDTS{0}-{1}{2}/{3}-{4}", stringSoMoi, nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);

            return soChungTuMoi;
        }
        private  string FillFormat(String format, string stringSoMoi, int year, int userID)
        {
           // app_users user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);
            tblnsBoPhan boPhan = BoPhan_Factory.New().Get_ByID((_user.MaBoPhan));
            String maBoPhanQL = "";
            if (boPhan != null)
                maBoPhanQL = boPhan.MaBoPhanQL ?? String.Empty;
            String soChungTuMoi = String.Format(format, stringSoMoi, (_user.MaQLUser ?? String.Empty), maBoPhanQL, year);
            return soChungTuMoi;
        }
        //private String Get_MaxSoChungTu_ByYear_NgungSuDung(int year, int userID)
        //{
        //    Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
        //    String soChungTu = (from o in this.ObjectSet
        //                        where o.NgayChungTu.Year == year
        //                         && (o.TaiSuDung ?? false) == false
        //                         && o.UserID == userID
        //                        orderby o.SoChungTu.Substring(0, sizeOfNumber) descending
        //                        select o.SoChungTu).FirstOrDefault();

        //    return soChungTu;
        //}

        
        private String Get_MaxSoChungTu_ByYear_And_Month_NgungSuDung(int year, int  month,int userID)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            string namThang = $"{nam}{thang}";
            var soChungTu = (from o in this.ObjectSet
                                join user in Context.app_users on o.UserID equals user.UserID
                                join cty in Context.tblCongTies on user.MaCongTy equals cty.MaCongTy
                                where o.NgayChungTu.Year == year
                                && (o.TaiSuDung ?? false) == false
                                //&& o.UserID == userID 
                                && user.MaCongTy == ERP_Library.Security.CurrentUser.Info.MaCongTy
                                && (o.SoChungTu).Substring(10, 4) == namThang
                                orderby o.SoChungTu.Substring(5, sizeOfNumber) descending
                                select o.SoChungTu
                                ).Take(1);

            return (soChungTu.ToList()).Any() ? (soChungTu.ToList()).First() : null;
        }
        private String Get_MaxSoChungTu_ByYear_And_Month_TaiSuDung(int year,int month ,int userID)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            string namThang = $"{nam}{thang}";
            var soChungTu = (
                                from o in this.ObjectSet
                                join user in Context.app_users on  o.UserID equals user.UserID
                                join cty in Context.tblCongTies on user.MaCongTy equals cty.MaCongTy 
                                where o.NgayChungTu.Year == year
                                && (o.TaiSuDung ?? false) == true
                                && user.MaCongTy == ERP_Library.Security.CurrentUser.Info.MaCongTy
                                && (o.SoChungTu).Substring(10, 4) == namThang
                                orderby o.SoChungTu.Substring(5, sizeOfNumber) descending
                                select o.SoChungTu
                                ).Take(1);
            return (soChungTu.ToList()).Any() ? (soChungTu.ToList()).First() : null;

        }

        public void FullDeleteNghiepVu_NgungSuDung(tblNVNgungvaTaiSuDungTSCD nghiepVu)
        {
            // Xóa tài sản cá biệt phòng ban
            foreach (tblCT_NVNgungvaTaiSuDungTSCD chiTiet in nghiepVu.tblCT_NVNgungvaTaiSuDungTSCD)
            {
                chiTiet.tblTaiSanCoDinhCaBiet.NgungSuDung = false;
            }
            // Xóa chi tiết nghiệp vụ ngừng sử dụng

            //nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Clear();
            BaseFactory<Entities, tblCT_NVNgungvaTaiSuDungTSCD>.DeleteHelper(this.Context, nghiepVu.tblCT_NVNgungvaTaiSuDungTSCD);

            // Xóa nghiệp vụ nghiệp vụ ngừng sử dụng
            this.DeleteObject(nghiepVu);
        }

        public void FullDeleteNghiepVu_TaiSuDung(tblNVNgungvaTaiSuDungTSCD nghiepVu)
        {
            //cập nhật lại thông tin ngừng sử dụng cho tài sản cá biệt
            foreach (tblCT_NVNgungvaTaiSuDungTSCD chiTiet in nghiepVu.tblCT_NVNgungvaTaiSuDungTSCD)
            {
                chiTiet.tblTaiSanCoDinhCaBiet.NgungSuDung = true;
            }
            // Xóa chi tiết nghiệp vụ ngừng sử dụng

            //nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Clear();
            BaseFactory<Entities, tblCT_NVNgungvaTaiSuDungTSCD>.DeleteHelper(this.Context, nghiepVu.tblCT_NVNgungvaTaiSuDungTSCD);

            // Xóa nghiệp vụ nghiệp vụ ngừng sử dụng
            this.DeleteObject(nghiepVu);
        }

        public tblNVNgungvaTaiSuDungTSCD Get_DanhSachNVNgungvaTaiSuDungTSCD_ByMaNVNgungvaTaiSuDungTSCD(int maNVNgungvaTaiSuDungTSCD)
        {

            var query = (from o in this.ObjectSet
                         where o.MaNghiepVu == maNVNgungvaTaiSuDungTSCD
                         orderby o.NgayChungTu
                         select o).SingleOrDefault();
            return query;
        }

        public Boolean KiemTraTrungSoChungTu(tblNVNgungvaTaiSuDungTSCD nVNgungvaTaiSuDungTSCD)
        {
            bool trungSoChungTu = KiemTraTrungSoChungTu_Helper(nVNgungvaTaiSuDungTSCD.MaNghiepVu, nVNgungvaTaiSuDungTSCD.SoChungTu);

            return trungSoChungTu;
        }
        private Boolean KiemTraTrungSoChungTu_Helper(Int32 maNghiepVu, String soChungTu)
        {
            bool trungSoChungTu = false;

            String soChungTuLower = soChungTu.ToLower();

            trungSoChungTu = (from o in this.ObjectSet
                              where
                                o.SoChungTu.ToLower() == soChungTuLower
                                && (maNghiepVu == 0 || o.MaNghiepVu != maNghiepVu)
                              select true).SingleOrDefault();
            return trungSoChungTu;
        }
        public IQueryable<tblNVNgungvaTaiSuDungTSCD> TimKiem_NgungSuDung(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 userID = 0)
        {
            IQueryable<tblNVNgungvaTaiSuDungTSCD> query = null;
            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userID))
                isAdmin = true;
            IQueryable<tblNVNgungvaTaiSuDungTSCD> nghiepVuList = from o in this.ObjectSet
                                                                  where (o.TaiSuDung ?? false) == false
                                                                  && (isAdmin == true || userID == 0 || (o.UserID ?? 0) == userID
                                                                   || o.app_users.app_UserChild1.Any(x => x.UserID == userID))
                                                                  select o;
            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = nghiepVuList;
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {
                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in nghiepVuList
                                    where o.SoChungTu == soChungTu
                                    && (o.TaiSuDung ?? false) == false
                                    orderby o.NgayChungTu descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in nghiepVuList
                                    where o.SoChungTu.ToLower().Contains(soChungTuLower)
                                    && (o.TaiSuDung ?? false) == false
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
                                query = from o in nghiepVuList
                                        where o.NgayChungTu == ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == false
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu < ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == false
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu <= ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == false
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu >= ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == false
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu > ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == false
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu >= ngayChungTu.Date
                                         && o.NgayChungTu <= ngayChungTuDen.Date
                                         && (o.TaiSuDung ?? false) == false
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

        public IQueryable<tblNVNgungvaTaiSuDungTSCD> TimKiem_TaiSuDung(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 userID = 0)
        {
            IQueryable<tblNVNgungvaTaiSuDungTSCD> query = null;
            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userID))
                isAdmin = true;
            IQueryable<tblNVNgungvaTaiSuDungTSCD> nghiepVuList = from o in this.ObjectSet
                                                                 where (o.TaiSuDung ?? false) == true
                                                                 && (isAdmin == true || userID == 0 || (o.UserID ?? 0) == userID
                                                                  || o.app_users.app_UserChild1.Any(x => x.UserID == userID))
                                                                 select o;
            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = nghiepVuList;
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {
                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in nghiepVuList
                                    where o.SoChungTu == soChungTu
                                    && (o.TaiSuDung ?? false) == true
                                    orderby o.NgayChungTu descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in nghiepVuList
                                    where o.SoChungTu.ToLower().Contains(soChungTuLower)
                                    && (o.TaiSuDung ?? false) == true
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
                                query = from o in nghiepVuList
                                        where o.NgayChungTu == ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == true
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu < ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == true
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu <= ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == true
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu >= ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == true
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu > ngayChungTu.Date
                                        && (o.TaiSuDung ?? false) == true
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu >= ngayChungTu.Date
                                         && o.NgayChungTu <= ngayChungTuDen.Date
                                         && (o.TaiSuDung ?? false) == true
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
        #endregion
    }//end class
}
