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
    public partial class NgoaiNgu_Factory : BaseFactory<Entities, tblnsNgoaiNgu>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NgoaiNgu_Factory.New().CreateAloneObject();
        }
        public static NgoaiNgu_Factory New()
        {
            return new NgoaiNgu_Factory();
        }
        public NgoaiNgu_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsNgoaiNgu> GetAll()
        {
            IQueryable<tblnsNgoaiNgu> query = from o in ObjectSet orderby o.MaQuanLy select o;
            return query;
        }
        public tblnsNgoaiNgu GetById(int id)
        {
            tblnsNgoaiNgu obj = this.ObjectSet.SingleOrDefault(o => o.MaNgoaiNgu == id);
            return obj;
        }

        #endregion
    }//end class
}
