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

namespace PSC_ERP_Business.Main.Factory
{
    public partial class Ky_Factory : BaseFactory<Entities, tblKy>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Ky_Factory.New().CreateAloneObject();
        }
        public static Ky_Factory New()
        {
            return new Ky_Factory();
        }
        public Ky_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        //30/01/2016
        public IQueryable<tblKy> Get_AllKy_OrderBy()
        {
            IQueryable<tblKy> obj = from o in this.ObjectSet
                                    orderby o.NgayBatDau descending, o.NgayKetThuc descending
                                    select o;
            return obj;
        }
        //------------------------------

        public tblKy Get_Ky_CoMaKyLonNhat()
        {
            tblKy obj = (from o in this.ObjectSet
                         orderby o.MaKy descending
                         select o).FirstOrDefault();
            return obj;
        }

        public tblKy Get_KyByMaKy(int maKy)
        {
            tblKy obj = (from o in this.ObjectSet
                         where o.MaKy == maKy
                         select o).SingleOrDefault();
            return obj;
        }

        public Boolean DaTungChayKHHM(int maCongTy)
        {//đã chạy khhm nếu tồn tại dòng trong tblNghiepVuKhauHaoHaoMons
            Boolean result = this.Context.tblNghiepVuKhauHaoHaoMons.Any(x => true == true && x.tblTaiSanCoDinhCaBiet.MaCongTy==maCongTy);//.Count() > 0;
            return result;
        }

        public Boolean DaChayKHHM(Int32 maKy, int maCongTy)
        {//đã chạy khhm nếu tồn tại dòng trong tblNghiepVuKhauHaoHaoMons có mã kỳ = mã kỳ gởi vào
            Boolean result = this.Context.tblNghiepVuKhauHaoHaoMons.Any(x => x.MaKy == maKy && x.tblTaiSanCoDinhCaBiet.MaCongTy==maCongTy);
            return result;
        }

        public Boolean DaKhoaSoTSCD(Int32 maKy, int maCongTy)
        {//đã khóa sổ nếu tồn tại dòng trong tblNghiepVuKhauHaoHaoMons có mã kỳ = mã kỳ gởi vào
            //Boolean result = this.Context.tblNghiepVuKhauHaoHaoMons.Any(x => x.MaKy == maKy && x.tblTaiSanCoDinhCaBiet.MaCongTy==maCongTy);
            Boolean result = this.Context.tblNghiepVuKhauHaoHaoMons.Any(x => x.MaKy >= maKy && x.tblTaiSanCoDinhCaBiet.MaCongTy == maCongTy);// 04/11/2020
            return result;
        }

        public Boolean DaKhoaSoTSCD(DateTime ngay, int maCongTy)
        {
            Int32 maKy = XacDinhMaKy_ByNgay(ngay);
            return DaKhoaSoTSCD(maKy,maCongTy);
        }
        public Int32 XacDinhMaKy_ByNgay(DateTime ngay)
        {
            tblKy obj = XacDinhKy_ByNgay(ngay);
            return (obj == null ? 0 : obj.MaKy);
        }
        public tblKy XacDinhKy_ByNgay(DateTime ngay)
        {
            tblKy obj = (from o in this.ObjectSet
                         where o.NgayBatDau <= ngay.Date
                             && ngay.Date <= o.NgayKetThuc
                         select o).SingleOrDefault();
            return obj;
        }
        #endregion
    }//end class
}
