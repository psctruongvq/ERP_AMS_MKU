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
    public partial class TrinhDoHocVan_Factory : BaseFactory<Entities, tblnsTrinhDoHocVan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TrinhDoHocVan_Factory.New().CreateAloneObject();
        }
        public static TrinhDoHocVan_Factory New()
        {
            return new TrinhDoHocVan_Factory();
        }
        public TrinhDoHocVan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsTrinhDoHocVan> GetAll()
        {
            IQueryable<tblnsTrinhDoHocVan> query = from o in ObjectSet orderby o.MaQuanLy select o;
            return query;
        }
        public tblnsTrinhDoHocVan GetById(int id)
        {
            tblnsTrinhDoHocVan obj = this.ObjectSet.SingleOrDefault(o => o.MaTrinhDoHocVan == id);
            return obj;
        }

        #endregion
    }//end class
}
