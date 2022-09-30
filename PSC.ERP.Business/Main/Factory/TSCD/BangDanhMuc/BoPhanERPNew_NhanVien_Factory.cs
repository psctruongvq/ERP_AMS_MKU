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
    public class BoPhanERPNew_NhanVien_Factory : BaseFactory<Entities, tblBoPhanERPNew_NhanVien>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return BoPhanERPNew_NhanVien_Factory.New().CreateAloneObject();
        }
        public static BoPhanERPNew_NhanVien_Factory New()
        {
            return new BoPhanERPNew_NhanVien_Factory();
        }
        public BoPhanERPNew_NhanVien_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblBoPhanERPNew_NhanVien> GetAll()
        {

            IQueryable<tblBoPhanERPNew_NhanVien> query = this.Context.sp_TSCD_LayDanhSachPhongBanERPNew_NhanVien().AsQueryable();
            return query;
        }
        #endregion
    }//end class
}
