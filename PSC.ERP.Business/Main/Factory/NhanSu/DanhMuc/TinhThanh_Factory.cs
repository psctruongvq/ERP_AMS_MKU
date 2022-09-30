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
    public partial class TinhThanh_Factory : BaseFactory<Entities, tblTinhThanh>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TinhThanh_Factory.New().CreateAloneObject();
        }
        public static TinhThanh_Factory New()
        {
            return new TinhThanh_Factory();
        }
        public TinhThanh_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblTinhThanh> GetAll()
        {
            IQueryable<tblTinhThanh> query = from o in ObjectSet orderby o.TenTinhThanh select o;
            return query;
        }
        public tblTinhThanh GetById(int id)
        {
            tblTinhThanh obj = this.ObjectSet.SingleOrDefault(o => o.MaTinhThanh == id);
            return obj;
        }

        #endregion
    }//end class
}
