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
    public partial class TieuMucNganSach_Factory : BaseFactory<Entities, tblTieuMucNganSach>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TieuMucNganSach_Factory.New().CreateAloneObject();
        }
        public static TieuMucNganSach_Factory New()
        {
            return new TieuMucNganSach_Factory();
        }
        public TieuMucNganSach_Factory()
            : base(Database.NewEntities())
        {

        }
        //pcm
        #region Custom
        #region Lấy danh sách tất cả Tiểu mục ngân sách
        public override IQueryable<tblTieuMucNganSach> GetAll()
        {
            IQueryable<tblTieuMucNganSach> query = from o in this.ObjectSet
                                                  orderby o.MaQuanLy
                                                  select o;

            return query;
        }
        #endregion

        #region Lấy Loại đối tượng theo Mã
        public tblTieuMucNganSach Get_TieuMucNganSachbyMa(int maTieuMuc)
        {

            var query = (from o in this.ObjectSet
                         where o.MaTieuMuc == maTieuMuc
                         select o).SingleOrDefault();
            return query;
        }

        public tblTieuMucNganSach Get_TieuMucNganSachbyMaQuanLy(String maQuanLy)
        {

            var query = (from o in this.ObjectSet
                         where o.MaQuanLy == maQuanLy
                         select o).SingleOrDefault();
            return query;
        }
        #endregion

        #endregion
    }//end class
}
