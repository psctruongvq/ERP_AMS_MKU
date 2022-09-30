using System;
using System.Linq;
using PSC_ERP_Core;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using ERP_Library.Security;

namespace PSC_ERP_Business.Main.Factory
{
    public class NghiepVuDieuChuyenNoiBo_Factory : BaseFactory<Entities, tblNghiepVuDieuChuyenNoiBo>
    {
          UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        //private static UserItem _user = UserItem.GetUserItem(ERP_Library.Security.CurrentUser.Info.UserID);
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static BaseEntityObject CreateStandAloneObject()
        {
            return NghiepVuDieuChuyenNoiBo_Factory.New().CreateAloneObject();
        }
        public static NghiepVuDieuChuyenNoiBo_Factory New()
        {
            return new NghiepVuDieuChuyenNoiBo_Factory();
        }
        public NghiepVuDieuChuyenNoiBo_Factory()
            : base(Database.NewEntities())
        {
        }

        #region Custom
        public Boolean KiemTraTrungSoChungTu(tblNghiepVuDieuChuyenNoiBo chungTu)
        {
            bool trungSoChungTu = KiemTraTrungSoChungTu_Helper(chungTu.MaNghiepVuDieuChuyenNoiBo, chungTu.SoChungTu);

            return trungSoChungTu;
        }
        private Boolean KiemTraTrungSoChungTu_Helper(Int32 maChungTu, String soChungTu)
        {
            bool trungSoChungTu = false;

            String soChungTuLower = soChungTu.ToLower();

            trungSoChungTu = (from o in this.ObjectSet
                              where
                                o.SoChungTu.ToLower() == soChungTuLower
                                && (maChungTu == 0 || o.MaNghiepVuDieuChuyenNoiBo != maChungTu)
                              select true).SingleOrDefault();

            return trungSoChungTu;
        }
        public tblNghiepVuDieuChuyenNoiBo NewChungTu(Int32 maPhongBanGiao, DateTime ngayHeThong)
        {
            //khởi tạo nghiệp vụ điều chuyển nội bộ
            tblNghiepVuDieuChuyenNoiBo nghiepVu = this.CreateManagedObject();
            nghiepVu.MaPhongBanGiao = maPhongBanGiao;
            //DateTime ngayHeThong = app_users_Factory.New().SystemDate.Date;//bị lỗi ko lấy được ngày hệ thống khi sử dụng this.SystemDate ở factory này
            nghiepVu.NgayChungTu = ngayHeThong;
            ////Phát sinh số chứng từ mới
            nghiepVu.SoChungTu = NghiepVuDieuChuyenNoiBo_Factory.New().Get_NextSoChungTu_ByYear_And_Month(ngayHeThong.Year, ngayHeThong.Month, _user.UserID);
            ////gán user lập
            nghiepVu.UserID = _user.UserID;

            return nghiepVu;
        }

       //
        public  String IncreaseSoChungTu_ByYear_and_Month(String soHieu, int year, int month)
        {
           // tblCongTy congTy = CongTy_Factory.New().Get_ByID(_user.MaCongTy);
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;
            string soChungTuMoi = "";
            int max = int.Parse(soHieu.Substring(4, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            soChungTuMoi = String.Format("ĐCNB{0}-{1}{2}/{3}-{4}", stringSoMoi, nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);

            return soChungTuMoi;
        }
       
        private String CreateFirst_SoChungTu_ByYear_And_Month(int year, int month)
        {
          //  tblCongTy congTy = CongTy_Factory.New().Get_ByID(_user.MaCongTy);
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            result = String.Format("ĐCNB{0}-{1}{2}/{3}-{4}", new String('0', sizeOfNumber - 1) + "1", nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);

            return result;
        }

        private String Get_MaxSoChungTu_ByYear_And_Month(int year, int month, int userID)
        {
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            string namThang = $"{nam}{thang}";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;
            var soChungTu = (from o in this.ObjectSet
                                join user in Context.app_users on o.UserID equals user.UserID
                                join cty in Context.tblCongTies on user.MaCongTy equals cty.MaCongTy
                                where  o.NgayChungTu.Year == year
                                && user.MaCongTy == ERP_Library.Security.CurrentUser.Info.MaCongTy
                                //&& o.UserID == userID
                                 && (o.SoChungTu).Substring(9, 4) == namThang
                                orderby o.SoChungTu.Substring(4, sizeOfNumber) descending
                                select o.SoChungTu).Take(1);


            return (soChungTu.ToList()).Any() ? (soChungTu.ToList()).First() : null;
        }
        public String Get_NextSoChungTu_ByYear_And_Month(int year, int month, int userID)
        {
            String result = "";
            String maxSoHieu = Get_MaxSoChungTu_ByYear_And_Month(year, month,userID);

            if (!String.IsNullOrWhiteSpace(maxSoHieu))
                result = IncreaseSoChungTu_ByYear_and_Month(maxSoHieu,  year, month);
            else
                result = CreateFirst_SoChungTu_ByYear_And_Month(year, month);

            return result;
        }
        public void FullDeleteNghiepVu(tblNghiepVuDieuChuyenNoiBo nghiepVu)
        {
            // Xóa tài sản cá biệt phòng ban
            foreach (tblCT_NghiepVuDieuChuyenNoiBo chiTiet in nghiepVu.tblCT_NghiepVuDieuChuyenNoiBo)
            {
                //chiTiet.tblTaiSanCoDinhCaBiet_PhongBan.Clear();
                BaseFactory<Entities, tblTaiSanCoDinhCaBiet_PhongBan>.DeleteHelper(this.Context, chiTiet.tblTaiSanCoDinhCaBiet_PhongBan);
                //Cập nhật lại đã thực hiện nghiệp vụ trong duyệt tài sản cố định cá biệt
                if(chiTiet.tblDuyetTSCD != null)
                    chiTiet.tblDuyetTSCD.DaThucHienNghiepVu = false;
            }
            // Xóa chi tiết nghiệp vụ điều chuyển nội bộ
            //nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Clear();
            BaseFactory<Entities, tblCT_NghiepVuDieuChuyenNoiBo>.DeleteHelper(this.Context, nghiepVu.tblCT_NghiepVuDieuChuyenNoiBo);

            // Xóa nghiệp vụ điều chuyển nội bộ
            this.DeleteObject(nghiepVu);
        }
        public override IQueryable<tblNghiepVuDieuChuyenNoiBo> GetAll()
        {
            IQueryable<tblNghiepVuDieuChuyenNoiBo> query = from o in this.ObjectSet
                                                           orderby o.NgayChungTu descending
                                                           select o;
            return query;
        }

        public tblNghiepVuDieuChuyenNoiBo Get_NghiepVuDieuChuyenNoiBoTheoMaNghiepVuDieuChuyenNoiBo(int maNghiepVuDieuChuyenNoBo)
        {
            var query = (from o in this.ObjectSet
                         where o.MaNghiepVuDieuChuyenNoiBo == maNghiepVuDieuChuyenNoBo
                         select o).SingleOrDefault();
            return query;
        }

        public IQueryable<tblNghiepVuDieuChuyenNoiBo> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 userID = 0)
        {
            IQueryable<tblNghiepVuDieuChuyenNoiBo> query = null;
            Boolean isAdmin = false;
            if (app_users_Factory.New().CheckIsAdmin(userID))
                isAdmin = true;
            IQueryable<tblNghiepVuDieuChuyenNoiBo> nghiepVuList = from o in this.ObjectSet
                                                                  where ((isAdmin == true || userID == 0 || (o.UserID ?? 0) == userID
                                                                   || o.app_users.app_UserChild1.Any(x => x.UserID == userID)))
                                                                  select o;
            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = nghiepVuList;//GetAll();
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {
                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in nghiepVuList
                                    where o.SoChungTu == soChungTu
                                    orderby o.NgayChungTu descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in nghiepVuList
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
                                query = from o in nghiepVuList
                                        where o.NgayChungTu == ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu < ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu <= ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu >= ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in nghiepVuList
                                        where o.NgayChungTu > ngayChungTu.Date
                                        orderby o.NgayChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in nghiepVuList
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
        #endregion
    }//end class
}
