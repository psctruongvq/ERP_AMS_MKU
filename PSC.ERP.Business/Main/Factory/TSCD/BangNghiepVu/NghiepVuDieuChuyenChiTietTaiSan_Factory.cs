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
    public class NghiepVuDieuChuyenChiTietTaiSan_Factory : BaseFactory<Entities, tblNghiepVuDieuChuyenChiTiet>
    {
         UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NghiepVuDieuChuyenChiTietTaiSan_Factory.New().CreateAloneObject();
        }
        public static NghiepVuDieuChuyenChiTietTaiSan_Factory New()
        {
            return new NghiepVuDieuChuyenChiTietTaiSan_Factory();
        }
        public NghiepVuDieuChuyenChiTietTaiSan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public Boolean KiemTraTrungSoChungTu(tblNghiepVuDieuChuyenChiTiet chungTu)
        {
            bool trungSoChungTu = KiemTraTrungSoChungTu_Helper(chungTu.MaNghiepVuDieuChuyenChiTiet, chungTu.SoChungTu);

            return trungSoChungTu;
        }
        private Boolean KiemTraTrungSoChungTu_Helper(Int64 maChungTu, String soChungTu)
        {
            bool trungSoChungTu = false;

            String soChungTuLower = soChungTu.ToLower();

            trungSoChungTu = (from o in this.ObjectSet
                              where
                                o.SoChungTu.ToLower() == soChungTuLower
                                && (maChungTu == 0 || o.MaNghiepVuDieuChuyenChiTiet != maChungTu)
                              select true).SingleOrDefault();
            //if (maChungTu == 0)
            //{
            //    trungSoChungTu = (from o in this.ObjectSet
            //                      where o.SoChungTu.ToLower() == soChungTuLower
            //                      select true).SingleOrDefault();

            //}
            //else
            //{
            //    trungSoChungTu = (from o in this.ObjectSet
            //                      where o.MaNghiepVuDieuChuyenNoiBo != maChungTu
            //                        && o.SoChungTu.ToLower() == soChungTuLower
            //                      select true).SingleOrDefault();
            //}

            return trungSoChungTu;
        }


        public tblNghiepVuDieuChuyenChiTiet NewChungTu(Int32 maPhongBan)
        {
            DateTime ngayHeThong = app_users_Factory.New().SystemDate;//bị lỗi ko lấy được ngày hệ thống khi sử dụng this.SystemDate ở factory này
            //khởi tạo nghiệp vụ điều chuyển nội bộ
            tblNghiepVuDieuChuyenChiTiet nghiepVu = this.CreateManagedObject();
            //nghiepVu.MaPhongBanGiao = maPhongBanGiao;

            nghiepVu.NgayTaoChungTu = ngayHeThong;
            ////Phát sinh số chứng từ mới
            nghiepVu.SoChungTu = NghiepVuDieuChuyenChiTietTaiSan_Factory.New().Get_NextSoChungTu_ByYear(ngayHeThong.Year, PSC_ERP_Global.Main.UserID);

            ////gán user lập
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;

            return nghiepVu;
        }

        public  String IncreaseSoChungTu(String soHieu, int year, int userID)
        {

            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;


            string soChungTuMoi = "";


            int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            soChungTuMoi = FillFormat("{0}/ĐCCT/{1}/{2}/{3}", stringSoMoi, year, userID);
            return soChungTuMoi;

        }

        private String CreateFirst_SoChungTu_ByYear(int year, int userID)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;


            result = FillFormat("{0}/ĐCCT/{1}/{2}/{3}", new String('0', sizeOfNumber - 1) + "1", year, userID);

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
        private String Get_MaxSoChungTu_ByYear(int year, int userID)
        {
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;
            String soChungTu = (from o in this.ObjectSet
                                where o.NgayTaoChungTu.Value.Year == year
                                && o.UserID == userID
                                orderby o.SoChungTu.Substring(0, sizeOfNumber) descending
                                select o.SoChungTu).FirstOrDefault();

            return soChungTu;
        }

        public String Get_NextSoChungTu_ByYear(int year, int userID)
        {
            Int32 size = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;
            String result = "";


            String maxSoHieu = Get_MaxSoChungTu_ByYear(year, userID);


            if (!String.IsNullOrWhiteSpace(maxSoHieu))
                result = IncreaseSoChungTu(maxSoHieu, year, userID);
            else
                result = CreateFirst_SoChungTu_ByYear(year, userID);

            return result;
        }
        public void FullDeleteNghiepVu(tblNghiepVuDieuChuyenChiTiet nghiepVu)
        {            
            // Xóa chi tiết nghiệp vụ điều chuyển nội bộ
            //nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Clear();
            //BaseFactory<Entities, tblCT_NghiepVuDieuChuyenChiTiet>.DeleteHelper(this.Context, nghiepVu.tblCT_NghiepVuDieuChuyenChiTiet);
            CT_NghiepVuDieuChuyenChiTietTaiSan_Factory.FullDeleteCT_NghiepVuDieuChuyenChiTietTaiSan(this.Context, nghiepVu.tblCT_NghiepVuDieuChuyenChiTiet.ToList<Object>());

            // Xóa nghiệp vụ điều chuyển nội bộ
            this.DeleteObject(nghiepVu);
        }
        public override IQueryable<tblNghiepVuDieuChuyenChiTiet> GetAll()
        {
            IQueryable<tblNghiepVuDieuChuyenChiTiet> query = from o in this.ObjectSet
                                                           orderby o.NgayTaoChungTu descending
                                                           select o;
            return query;
        }


        public tblNghiepVuDieuChuyenChiTiet Get_NghiepVuDieuChuyenChiTietTaiSanTheoMaNghiepVuDieuChuyenChiTiet(int maNghiepVuDieuChuyenChiTiet)
        {
            var query = (from o in this.ObjectSet
                         where o.MaNghiepVuDieuChuyenChiTiet == maNghiepVuDieuChuyenChiTiet
                         select o).SingleOrDefault();
            return query;
        }



        public IQueryable<tblNghiepVuDieuChuyenChiTiet> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 userID = 0)
        {
            IQueryable<tblNghiepVuDieuChuyenChiTiet> query = null;
            //Boolean isAdmin = false;
            //if (app_users_Factory.New().CheckIsAdmin(userID))
            //    isAdmin = true;
            //IQueryable<tblNghiepVuDieuChuyenChiTiet> query = from o in this.ObjectSet
            //                                                        where (isAdmin == true || userID == 0)// || (o.UserID ?? 0) == userID
            //                                                       || o.app_users.app_UserThuLao1.Any(x => x.UserID == userID))
            //                                                      select o;
            switch (loaiTim)
            {
                case LoaiTimChungTuEnum.TatCa:
                    query = this.GetAll();
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {
                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in query
                                    where o.SoChungTu == soChungTu
                                    orderby o.NgayTaoChungTu descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in query
                                    where o.SoChungTu.ToLower().Contains(soChungTuLower)
                                    orderby o.NgayTaoChungTu descending
                                    select o;
                        }

                    }
                    break;
                case LoaiTimChungTuEnum.NgayLap://tìm theo ngày chứng từ
                    {
                        switch (compareType)
                        {
                            case CompareTypeEnum.Equal:
                                query = from o in query
                                        where o.NgayTaoChungTu == ngayChungTu.Date
                                        orderby o.NgayTaoChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in query
                                        where o.NgayTaoChungTu < ngayChungTu.Date
                                        orderby o.NgayTaoChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in query
                                        where o.NgayTaoChungTu <= ngayChungTu.Date
                                        orderby o.NgayTaoChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in query
                                        where o.NgayTaoChungTu >= ngayChungTu.Date
                                        orderby o.NgayTaoChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in query
                                        where o.NgayTaoChungTu > ngayChungTu.Date
                                        orderby o.NgayTaoChungTu descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in query
                                        where o.NgayTaoChungTu >= ngayChungTu.Date
                                         && o.NgayTaoChungTu <= ngayChungTuDen.Date
                                        orderby o.NgayTaoChungTu descending
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
