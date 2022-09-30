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
    public partial class ChucDanh_Factory : BaseFactory<Entities, tblnsChucDanh>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChucDanh_Factory.New().CreateAloneObject();
        }
        public static ChucDanh_Factory New()
        {
            return new ChucDanh_Factory();
        }
        public ChucDanh_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsChucDanh> GetAll()
        {
            IQueryable<tblnsChucDanh> query = from o in ObjectSet orderby o.TenChucDanh select o;
            return query;
        }
        public tblnsChucDanh GetById(int id)
        {
            tblnsChucDanh obj = this.ObjectSet.SingleOrDefault(o => o.MaChucDanh == id);
            return obj;
        }

        #endregion
    }//end class
}
