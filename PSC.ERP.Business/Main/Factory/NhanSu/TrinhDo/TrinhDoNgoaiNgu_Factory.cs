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
    public partial class TrinhDoNgoaiNgu_Factory : BaseFactory<Entities, tblnsTrinhDoNgoaiNgu>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TrinhDoNgoaiNgu_Factory.New().CreateAloneObject();
        }
        public static TrinhDoNgoaiNgu_Factory New()
        {
            return new TrinhDoNgoaiNgu_Factory();
        }
        public TrinhDoNgoaiNgu_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsTrinhDoNgoaiNgu> GetAll()
        {
            IQueryable<tblnsTrinhDoNgoaiNgu> query = from o in ObjectSet orderby o.MaQuanLy select o;
            return query;
        }
        public tblnsTrinhDoNgoaiNgu GetById(int id)
        {
            tblnsTrinhDoNgoaiNgu obj = this.ObjectSet.SingleOrDefault(o => o.MaTrinhDoNN == id);
            return obj;
        }

        #endregion
    }//end class
}
