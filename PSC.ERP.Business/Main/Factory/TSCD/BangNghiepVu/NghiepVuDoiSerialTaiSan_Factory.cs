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
    public class NghiepVuDoiSerialTaiSan_Factory : BaseFactory<Entities, tblNghiepVuSuaSoSerialTSCDCB>
    {
         UserInfo _user = ERP_Library.Security.CurrentUser.Info;
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NghiepVuDoiSerialTaiSan_Factory.New().CreateAloneObject();
        }
        public static NghiepVuDoiSerialTaiSan_Factory New()
        {
            return new NghiepVuDoiSerialTaiSan_Factory();
        }
        public NghiepVuDoiSerialTaiSan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public Boolean KiemTraTrungSoChungTu(tblNghiepVuSuaSoSerialTSCDCB chungTu)
        {
            bool trungSoChungTu = KiemTraTrungSoChungTu_Helper(chungTu.ID, chungTu.SoChungTu);

            return trungSoChungTu;
        }
        private Boolean KiemTraTrungSoChungTu_Helper(Int64 maChungTu, String soChungTu)
        {
            bool trungSoChungTu = false;

            String soChungTuLower = soChungTu.ToLower();

            trungSoChungTu = (from o in this.ObjectSet
                              where
                                o.SoChungTu.ToLower() == soChungTuLower
                                && (maChungTu == 0 || o.ID!= maChungTu)
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


        public tblNghiepVuSuaSoSerialTSCDCB NewChungTu()
        {
            DateTime ngayHeThong = app_users_Factory.New().SystemDate;//bị lỗi ko lấy được ngày hệ thống khi sử dụng this.SystemDate ở factory này
            //khởi tạo nghiệp vụ điều chuyển nội bộ
            tblNghiepVuSuaSoSerialTSCDCB nghiepVu = this.CreateManagedObject();
            //nghiepVu.MaPhongBanGiao = maPhongBanGiao;

            nghiepVu.NgayLap = ngayHeThong;
            ////Phát sinh số chứng từ mới
            nghiepVu.SoChungTu = NghiepVuDoiSerialTaiSan_Factory.New().Get_NextSoChungTu_ByYear(ngayHeThong.Year, PSC_ERP_Global.Main.UserID);

            ////gán user lập
            nghiepVu.UserID = PSC_ERP_Global.Main.UserID;

            return nghiepVu;
        }

        public  String IncreaseSoChungTu(String soHieu, int year, int userID)
        {

            int sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;//xài chung size với mã điều chuyển nội bộ
            string soChungTuMoi = "";


            int max = int.Parse(soHieu.Substring(0, sizeOfNumber));
            int soMoi = max + 1;
            string stringSoMoi = new String('0', sizeOfNumber - soMoi.ToString().Length) + soMoi.ToString();

            soChungTuMoi = FillFormat("{0}/ĐSSTS/{1}/{2}/{3}", stringSoMoi, year, userID);
            return soChungTuMoi;

        }

        private String CreateFirst_SoChungTu_ByYear(int year, int userID)
        {
            String result = "";
            Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart;

            result = FillFormat("{0}/ĐSSTS/{1}/{2}/{3}", new String('0', sizeOfNumber - 1) + "1", year, userID);

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
                                where o.NgayLap.Value.Year == year
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
        //xóa nghiệp vụ
        public void FullDeleteNghiepVu(tblNghiepVuSuaSoSerialTSCDCB nghiepVu)
        {            
            // Xóa chi tiết nghiệp vụ đổi số serial
            //nghiepVuDieuChuyenNoiBo.tblCT_NghiepVuDieuChuyenNoiBo.Clear();
            //BaseFactory<Entities, tblCT_NghiepVuDieuChuyenChiTiet>.DeleteHelper(this.Context, nghiepVu.tblCT_NghiepVuDieuChuyenChiTiet);
            SerialTaiSanCoDinhCaBiet_Factory.FullDeleteCT_NghiepVuDoiSerialTaiSan(this.Context, nghiepVu.tblSerialTaiSanCoDinhCaBiets.ToList<Object>());

            // Xóa nghiệp vụ điều chuyển nội bộ
            this.DeleteObject(nghiepVu);
        }
        public override IQueryable<tblNghiepVuSuaSoSerialTSCDCB> GetAll()
        {
            IQueryable<tblNghiepVuSuaSoSerialTSCDCB> query = from o in this.ObjectSet
                                                           orderby o.NgayLap descending
                                                           select o;
            return query;
        }


        public tblNghiepVuSuaSoSerialTSCDCB Get_NghiepVuDieuChuyenChiTietTaiSanTheoMaNghiepVuDieuChuyenChiTiet(long maNghiepVuDieuChuyenChiTiet)
        {
            var query = (from o in this.ObjectSet
                         where o.ID == maNghiepVuDieuChuyenChiTiet
                         select o).SingleOrDefault();
            return query;
        }



        public IQueryable<tblNghiepVuSuaSoSerialTSCDCB> TimKiem(LoaiTimChungTuEnum loaiTim, CompareTypeEnum compareType, String soChungTu, DateTime ngayChungTu, DateTime ngayChungTuDen, Int32 userID = 0)
        {
            IQueryable<tblNghiepVuSuaSoSerialTSCDCB> query = null;
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
                    query = this.GetAll();// query;//GetAll();
                    break;
                case LoaiTimChungTuEnum.SoChungTu://tìm theo số chứng từ
                    {
                        if (compareType == CompareTypeEnum.Equal)
                        {
                            query = from o in query
                                    where o.SoChungTu == soChungTu
                                    orderby o.NgayLap descending
                                    select o;
                        }
                        else if (compareType == CompareTypeEnum.Contain)
                        {
                            String soChungTuLower = soChungTu.ToLower();
                            query = from o in query
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
                                query = from o in query
                                        where o.NgayLap == ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in query
                                        where o.NgayLap < ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in query
                                        where o.NgayLap <= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in query
                                        where o.NgayLap >= ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in query
                                        where o.NgayLap > ngayChungTu.Date
                                        orderby o.NgayLap descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in query
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
                default:
                    break;
            }

            return query;
        }

        #endregion
    }//end class
}
