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
using ERP_Library.Security;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class ChungTu_Factory : BaseFactory<Entities, tblChungTu>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChungTu_Factory.New().CreateAloneObject();
        }
        public static ChungTu_Factory New()
        {
            return new ChungTu_Factory();
        }
        public ChungTu_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        //bổ sung ngày 18/01/2016
        public tblChungTu GetChungTu_TheoSoChungTu(string soChungTu)
        {
            tblChungTu chungTu = (from o in this.ObjectSet
                                  where o.SoChungTu.Contains(soChungTu)
                                  select o).SingleOrDefault<tblChungTu>();
            return chungTu;
        }
        //------------------------------
        public IQueryable<tblChungTu> GetListBy_MaLoaiChungTu_MaBoPhan_Nam(Int32? maLoaiChungTu, Int32? maBoPhan, Int32? nam)
        {
            Boolean tatCaLoaiChungTu = ((maLoaiChungTu ?? 0) == 0);
            Boolean tatCaBoPhan = ((maBoPhan ?? 0) == 0);
            Boolean tatCaNam = ((nam ?? 0) == 0);
            IQueryable<tblChungTu> query = from o in this.ObjectSet
                                           where (tatCaLoaiChungTu || o.MaLoaiChungTu == maLoaiChungTu)
                                           && (tatCaBoPhan || o.app_users.MaBoPhan == maBoPhan)
                                           && (tatCaNam || o.NgayLap.Value.Year == nam)
                                           orderby o.SoChungTu
                                           select o;
            return query;
        }

        public  String IncreaseSoChungTuPhieuKeToanTaiSan(String soHieu, int year, int userID)
        {
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            string soChungTuMoi = "";
            int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
            soChungTuMoi = FillFormat("{0}K-TS/{1}/{2}/{3}", stringSoMoi, year, userID);
            return soChungTuMoi;
        }
        public  String IncreaseSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(String soHieu, int year, int month, int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            string soChungTuMoi = "";
            string soThuTu = soHieu.Substring(4, sizeOfNumber);
            int max = int.Parse(soThuTu);
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            soChungTuMoi = String.Format("PNTS{0}-{1}{2}/{3}-{4}", stringSoMoi, nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy);
            return soChungTuMoi;
        }
        private String CreateFirst_SoChungTuPhieuKeToanTaiSan(int year, int userID)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            result = FillFormat("{0}K-TS/{1}/{2}/{3}", new String('0', sizeOfNumber - 1) + "1", year, userID);

            return result;
        }
        private String CreateFirst_SoChungTuPhieuKeToanTaiSan_ByYear_and_Month(int year, int month, int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //tblCongTy congTy = CongTy_Factory.New().Get_ByID(user.MaCongTy.Value);
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart;
            String nam = year.ToString().Substring(2), thang = month < 10 ? "0" + month : month.ToString();
            result = String.Format("PNTS{0}-{1}{2}/{3}-{4}", new String('0', sizeOfNumber - 1) + "1", nam, thang, _user.MaQLUser, _user.MaCongTyQuanLy); 

            return result;
        }
        private  string FillFormat(String format, string stringSoMoi, int year, int userID)
        {
            //app_users user = app_users_Factory.New().Get_AppUserByUserID(userID);
            tblnsBoPhan boPhan = BoPhan_Factory.New().Get_ByID((_user.MaBoPhan));
            String maBoPhanQL = "";
            if (boPhan != null)
                maBoPhanQL = boPhan.MaBoPhanQL ?? String.Empty;
            String soChungTuMoi = String.Format(format, stringSoMoi, (_user.MaQLUser ?? String.Empty), maBoPhanQL, year);
            return soChungTuMoi;
        }
        private String Get_MaxSoChungTuPhieuKeToanTaiSan(int year, int userID)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuPhieuKeToanTaiSan_IncreasePart;
            String soChungTu = (from o in this.ObjectSet
                                where o.NgayLap.Value.Year == year
                                && (o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                    || o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChinhGiaTri
                                    || o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuSuaChuaLonTSCD
                                    || o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChuyenNgoai
                                    || o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy
                                    )
                                && o.MaNguoiLap == userID
                                orderby o.SoChungTu.Substring(0, sizeOfNumber) descending
                                select o.SoChungTu).FirstOrDefault();

            return soChungTu;
        }

        private String Get_MaxSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(int year, int month, int maCongTy)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuPhieuKeToanTaiSan_IncreasePart;
            String soChungTu = (from o in this.ObjectSet
                                where o.NgayLap.Value.Year == year
                                && (o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuGhiTangTSCD
                                    || o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChinhGiaTri
                                    || o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuSuaChuaLonTSCD
                                    || o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChuyenNgoai
                                    || o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuThanhLy
                                    )
                                && o.NgayLap.Value.Month == month
                                && o.MaCongTy.Value== maCongTy
                                orderby o.SoChungTu.Substring(4, sizeOfNumber) descending
                                select o.SoChungTu).FirstOrDefault();

            return soChungTu;
        }
        public String Get_NextSoChungTuPhieuKeToanTaiSan(int year, int userID)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_SoChungTuPhieuKeToanTaiSan_IncreasePart;
            String result = "";
            String maxSoChungTu = Get_MaxSoChungTuPhieuKeToanTaiSan(year, userID);
            if (!String.IsNullOrWhiteSpace(maxSoChungTu))
                result = IncreaseSoChungTuPhieuKeToanTaiSan(maxSoChungTu, year, userID);
            else
                result = CreateFirst_SoChungTuPhieuKeToanTaiSan(year, userID);
            return result;
        }

        public String Get_NextSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(int year, int month, int maCongTy)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_SoChungTuPhieuKeToanTaiSan_IncreasePart;
            String result = "";
            String maxSoChungTu = Get_MaxSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(year, month, maCongTy);
            if (!String.IsNullOrWhiteSpace(maxSoChungTu))
                result = IncreaseSoChungTuPhieuKeToanTaiSan_ByYear_and_Month(maxSoChungTu, year, month, maCongTy);
            else
                result = CreateFirst_SoChungTuPhieuKeToanTaiSan_ByYear_and_Month(year, month, maCongTy);

            return result;
        }

        // //////////////////////////////////////////////////////////////////
        public Boolean KiemTraTrungMaChungTuQL(tblChungTu chungTu)
        {
            bool trungMaChungTuQL = KiemTraTrungMaChungTuQL_Helper(chungTu.MaChungTu, chungTu.MaChungTuQL);
            return trungMaChungTuQL;
        }
        private Boolean KiemTraTrungMaChungTuQL_Helper(long maChungTu, String maChungTuQL)
        {
            bool trungMaChungTuQL = false;

            String maChungTuQLLower = maChungTuQL.ToLower();

            trungMaChungTuQL = (from o in this.ObjectSet
                                where
                                  o.MaChungTuQL.ToLower() == maChungTuQLLower
                                  && (maChungTu == 0 || o.MaChungTu != maChungTu)
                                select true).FirstOrDefault();


            return trungMaChungTuQL;
        }
        public Boolean KiemTraTrungSoChungTu(tblChungTu chungTu)
        {
            bool trungSoChungTu = KiemTraTrungSoChungTu_Helper(chungTu.MaChungTu, chungTu.SoChungTu);


            return trungSoChungTu;
        }
        private Boolean KiemTraTrungSoChungTu_Helper(long maChungTu, String soChungTu)
        {
            bool trungSoChungTu = false;

            String soChungTuLower = soChungTu.ToLower();

            trungSoChungTu = (from o in this.ObjectSet
                              where
                                o.SoChungTu.ToLower() == soChungTuLower
                                && (maChungTu == 0 || o.MaChungTu != maChungTu)
                              select true).FirstOrDefault();
            //if (maChungTu == 0)
            //{
            //    trungSoChungTu = (from o in this.ObjectSet
            //                      where o.SoChungTu.ToLower() == soChungTuLower
            //                      select true).SingleOrDefault();

            //}
            //else
            //{
            //    trungSoChungTu = (from o in this.ObjectSet
            //                      where o.MaChungTu != maChungTu
            //                        && o.SoChungTu.ToLower() == soChungTuLower
            //                      select true).SingleOrDefault();
            //}

            return trungSoChungTu;
        }

        public virtual tblChungTu Get_ChungTu_ByMaChungTu(long maChungTu)
        {
            tblChungTu obj = (from o in this.ObjectSet
                              where o.MaChungTu == maChungTu
                              select o).SingleOrDefault();
            return obj;
        }

        //public IQueryable<tblHopDong> TimKiem(LoaiTimHopDongEnum loaiTim, CompareTypeEnum compareType, String soHopDong, String tenHopDong, Decimal soTien, Decimal soTienDen, DateTime ngayKy, DateTime ngayKyDen, Int32 maDoiTac)
        //{
        //    IQueryable<tblHopDong> query = null;

        //    switch (loaiTim)
        //    {
        //        case LoaiTimHopDongEnum.TatCa:
        //            query = this.GetAll();
        //            break;
        //        case LoaiTimHopDongEnum.SoHopDong://tìm theo số hợp đồng
        //            {

        //                if (compareType == CompareTypeEnum.Equal)
        //                {
        //                    query = from o in this.ObjectSet
        //                            where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                             && o.tblHopDongMuaBan.SoHopDong == soHopDong
        //                            orderby o.NgayLap
        //                            select o;
        //                }
        //                else if (compareType == CompareTypeEnum.Contain)
        //                {
        //                    String soHopDongLower = soHopDong.ToLower();
        //                    query = from o in this.ObjectSet
        //                            where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                             && o.tblHopDongMuaBan.SoHopDong.ToLower().Contains(soHopDongLower)
        //                            orderby o.NgayLap
        //                            select o;
        //                }

        //            }
        //            break;
        //        case LoaiTimHopDongEnum.TenHopDong://tìm theo tên hợp đồng
        //            if (compareType == CompareTypeEnum.Equal)
        //            {
        //                query = from o in this.ObjectSet
        //                        where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                         && o.TenHopDong == soHopDong
        //                        orderby o.NgayLap
        //                        select o;
        //            }
        //            else if (compareType == CompareTypeEnum.Contain)
        //            {
        //                String tenHopDongLower = tenHopDong.ToLower();
        //                query = from o in this.ObjectSet
        //                        where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                         && o.TenHopDong.ToLower().Contains(tenHopDongLower)
        //                        orderby o.NgayLap
        //                        select o;
        //            }
        //            break;
        //        case LoaiTimHopDongEnum.NgayKy://tìm theo ngày ký
        //            {
        //                switch (compareType)
        //                {
        //                    case CompareTypeEnum.Equal:
        //                        query = from o in this.ObjectSet
        //                                where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                                 && o.NgayKy.Value.Date == ngayKy.Date
        //                                orderby o.NgayLap
        //                                select o;
        //                        break;
        //                    case CompareTypeEnum.LessThan:
        //                        query = from o in this.ObjectSet
        //                                where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                                 && o.NgayKy.Value.Date < ngayKy.Date
        //                                orderby o.NgayLap
        //                                select o;
        //                        break;
        //                    case CompareTypeEnum.LessThanOrEqual:
        //                        query = from o in this.ObjectSet
        //                                where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                                 && o.NgayKy.Value.Date <= ngayKy.Date
        //                                orderby o.NgayLap
        //                                select o;
        //                        break;
        //                    case CompareTypeEnum.GreaterThanOrEqual:
        //                        query = from o in this.ObjectSet
        //                                where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                                 && o.NgayKy.Value.Date >= ngayKy.Date
        //                                orderby o.NgayLap
        //                                select o;
        //                        break;
        //                    case CompareTypeEnum.GreaterThan:
        //                        query = from o in this.ObjectSet
        //                                where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                                 && o.NgayKy.Value.Date > ngayKy.Date
        //                                orderby o.NgayLap
        //                                select o;
        //                        break;
        //                    case CompareTypeEnum.Between:
        //                        query = from o in this.ObjectSet
        //                                where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                                 && o.NgayKy.Value.Date >= ngayKy.Date
        //                                 && o.NgayKy.Value.Date <= ngayKyDen.Date
        //                                orderby o.NgayLap
        //                                select o;
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //            break;
        //        case LoaiTimHopDongEnum.SoTien://tìm theo số tiền
        //            switch (compareType)
        //            {
        //                case CompareTypeEnum.Equal:
        //                    query = from o in this.ObjectSet
        //                            where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                             && o.tblHopDongMuaBan.TongTien == soTien
        //                            orderby o.NgayLap
        //                            select o;
        //                    break;
        //                case CompareTypeEnum.LessThan:
        //                    query = from o in this.ObjectSet
        //                            where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                             && o.tblHopDongMuaBan.TongTien < soTien
        //                            orderby o.NgayLap
        //                            select o;
        //                    break;
        //                case CompareTypeEnum.LessThanOrEqual:
        //                    query = from o in this.ObjectSet
        //                            where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                             && o.tblHopDongMuaBan.TongTien <= soTien
        //                            orderby o.NgayLap
        //                            select o;
        //                    break;
        //                case CompareTypeEnum.GreaterThanOrEqual:
        //                    query = from o in this.ObjectSet
        //                            where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                             && o.tblHopDongMuaBan.TongTien >= soTien
        //                            orderby o.NgayLap
        //                            select o;
        //                    break;
        //                case CompareTypeEnum.GreaterThan:
        //                    query = from o in this.ObjectSet
        //                            where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                             && o.tblHopDongMuaBan.TongTien > soTien
        //                            orderby o.NgayLap
        //                            select o;
        //                    break;
        //                case CompareTypeEnum.Between:
        //                    query = from o in this.ObjectSet
        //                            where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                             && o.tblHopDongMuaBan.TongTien >= soTien
        //                             && o.tblHopDongMuaBan.TongTien <= soTienDen
        //                            orderby o.NgayLap
        //                            select o;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            break;
        //        case LoaiTimHopDongEnum.DoiTac://tìm theo mã đối tác
        //            query = from o in this.ObjectSet
        //                    where o.tblHopDongMuaBan.MaLoaiHopDong == PSC_ERP_Global.TSCD.MaLoaiHopDongTaiSan
        //                     && o.MaDoiTac == maDoiTac
        //                    orderby o.NgayLap
        //                    select o;
        //            break;
        //        default:
        //            break;
        //    }

        //    return query;
        //}

        #endregion
    }//end class
}
