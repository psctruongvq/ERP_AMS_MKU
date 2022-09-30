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
    public partial class TonGiao_Factory : BaseFactory<Entities, tblnsTonGiao>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TonGiao_Factory.New().CreateAloneObject();
        }
        public static TonGiao_Factory New()
        {
            return new TonGiao_Factory();
        }
        public TonGiao_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsTonGiao> GetAll()
        {
            IQueryable<tblnsTonGiao> query = from o in ObjectSet orderby o.TenTonGiao select o;
            return query;
        }
        public tblnsTonGiao GetById(int id)
        {
            tblnsTonGiao obj = this.ObjectSet.SingleOrDefault(o => o.MaTonGiao == id);
            return obj;
        }

        #endregion
    }//end class
}
