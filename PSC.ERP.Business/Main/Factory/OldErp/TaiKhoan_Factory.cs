using System;
using System.Collections.Generic;
using System.Linq;
using PSC_ERP_Core;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class TaiKhoan_Factory : BaseFactory<Entities, tblTaiKhoan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static BaseEntityObject CreateStandAloneObject()
        {
            return TaiKhoan_Factory.New().CreateAloneObject();
        }
        public static TaiKhoan_Factory New()
        {
            return new TaiKhoan_Factory();
        }
        public TaiKhoan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblTaiKhoan> GetAll()
        {

            IQueryable<tblTaiKhoan> query = base.GetAll().OrderBy(x => x.SoHieuTK);
            return query;
        }
        //public IQueryable<tblTaiKhoan> Get_DanhSachTaiKhoanNo()
        //{

        //    IQueryable<tblTaiKhoan> query = from o in this.ObjectSet
        //                                    where o.LoaiSoDuNo == true
        //                                    orderby o.SoHieuTK
        //                                    select o;
        //    return query;
        //}
        //public IQueryable<tblTaiKhoan> Get_DanhSachTaiKhoanCo()
        //{

        //    IQueryable<tblTaiKhoan> query = from o in this.ObjectSet
        //                                    where o.LoaiSoDuCo == true
        //                                    orderby o.SoHieuTK
        //                                    select o;
        //    return query;
        //}
        public IQueryable<tblTaiKhoan> Get_DanhSachTaiKhoanCoTrongTaiSanCoDinhCaBiet()
        {

            IQueryable<tblTaiKhoan> query = (from o in this.ObjectSet
                                             join a in this.Context.tblTaiSanCoDinhCaBiets on o.SoHieuTK equals a.TaiKhoanDoiUng
                                             orderby o.SoHieuTK
                                             select o).Distinct();
            return query;
        }
        public IQueryable<tblTaiKhoan> Get_DanhSachTaiKhoanCoTrongTaiSanCoDinhCaBiet_ByNam(int nam)
        {

            IQueryable<tblTaiKhoan> query = (from o in this.ObjectSet
                                            join a in this.Context.tblTaiSanCoDinhCaBiets on o.SoHieuTK equals a.TaiKhoanDoiUng
                                            where a.NgaySuDung.Value.Year == nam
                                            orderby o.SoHieuTK
                                            select o).Distinct();
            return query;
        }

        public IQueryable<tblTaiKhoan> Get_DanhSachTaiKhoanCha()
        {
            List<int> dstaikhoancha = ((from o in this.ObjectSet
                                       where o.MaTaiKhoanCha != null
                                       select o.MaTaiKhoanCha.Value).Distinct()).ToList<int>();
            IQueryable<tblTaiKhoan> query = (from o in this.ObjectSet
                                            where dstaikhoancha.Contains(o.MaTaiKhoan)
                                             orderby o.SoHieuTK
                                             select o).Distinct();
            return query;
        }

        public tblTaiKhoan Get_TaiKhoan_ByMaTaiKhoan(int maTaiKhoan)
        {

            tblTaiKhoan obj = (from o in this.ObjectSet
                               where o.MaTaiKhoan == maTaiKhoan
                               select o).SingleOrDefault();
            return obj;
        }
        public tblTaiKhoan Get_TaiKhoan_BySoHieu(String soHieu)
        {

            tblTaiKhoan obj = (from o in this.ObjectSet
                               where o.SoHieuTK == soHieu
                               select o).SingleOrDefault();
            return obj;
        }

        #region M
        public IQueryable<tblTaiKhoan> Get_TaiKhoanbyMaCongTy(int maCongTy)
        {

            IQueryable<tblTaiKhoan> obj = from o in this.ObjectSet
                                           where o.MaCongTy == maCongTy
                                            select o;
            return obj;
        }
        #endregion
        //đã khóa tài khoản trong kỳ
        public Boolean DaKhoaTaiKhoan(Int32 maKy, Int32 userID, int maTaiKhoan )
        {//đã khóa tài khoản trong kỳ
            Boolean result = this.Context.tblKhoaSo_MaTaiKhoan.Any(x => x.MaKy == maKy && x.UserID == userID && x.MaTaiKhoan == maTaiKhoan);
            return result;
        }

        #endregion
    }//end class
}
