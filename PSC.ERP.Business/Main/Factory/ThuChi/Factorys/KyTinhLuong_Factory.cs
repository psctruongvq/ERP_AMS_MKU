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
    public partial class KyTinhLuong_Factory : BaseFactory<Entities, tblnsKyTinhLuong>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return KyTinhLuong_Factory.New().CreateAloneObject();
        }
        public static KyTinhLuong_Factory New()
        {
            return new KyTinhLuong_Factory();
        }
        public KyTinhLuong_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public IQueryable<tblnsKyTinhLuong> GetKyTinhLuongByMaCongTy(int maCongTy)
        {
            IQueryable<tblnsKyTinhLuong> query = from o in this.ObjectSet
                                               join kk in this.Context.tblnsKhoaKyLuongs.AsQueryable<tblnsKhoaKyLuong>() on o.MaKy equals kk.MaKyTinhLuong
                                               where kk.MaCongTy==maCongTy
                                               orderby o.NgayBatDau descending
                                               select o;

            return query;
        }

        public tblnsKyTinhLuong GetKyTinhLuongByIDMaKy_MaCongTy(int maKy, int maCongTy)
        {
            var query = (from o in this.ObjectSet
                         join kk in this.Context.tblnsKhoaKyLuongs.AsQueryable<tblnsKhoaKyLuong>() on o.MaKy equals kk.MaKyTinhLuong
                         where o.MaKy == maKy && kk.MaCongTy == maCongTy
                         select o).SingleOrDefault();
            return query;
        }
        #endregion
    }//end class
}
