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
namespace PSC_ERP_Business.Main.Factory//
{
    public partial class DanToc_Factory : BaseFactory<Entities, tblnsDanToc>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DanToc_Factory.New().CreateAloneObject();
        }
        public static DanToc_Factory New()
        {
            return new DanToc_Factory();
        }
        public DanToc_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsDanToc> GetAll()
        {
            IQueryable<tblnsDanToc> query = from o in ObjectSet orderby o.DanToc select o;
            return query;
        }
        public tblnsDanToc GetById(int id)
        {
            tblnsDanToc obj = this.ObjectSet.SingleOrDefault(o => o.MaDanToc == id);
            return obj;
        }

        #endregion
    }//end class
}
