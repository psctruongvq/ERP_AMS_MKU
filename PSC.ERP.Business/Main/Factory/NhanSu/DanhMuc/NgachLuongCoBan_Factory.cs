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
    public partial class NgachLuongCoBan_Factory : BaseFactory<Entities, tblnsNgachLuongCoBan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NgachLuongCoBan_Factory.New().CreateAloneObject();
        }
        public static NgachLuongCoBan_Factory New()
        {
            return new NgachLuongCoBan_Factory();
        }
        public NgachLuongCoBan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsNgachLuongCoBan> GetAll()
        {
            IQueryable<tblnsNgachLuongCoBan> query = from o in ObjectSet orderby o.TenNgachLuongCoBan select o;
            return query;
        }
        public tblnsNgachLuongCoBan GetById(int id)
        {
            tblnsNgachLuongCoBan obj = this.ObjectSet.SingleOrDefault(o => o.MaNgachLuongCoBan == id);
            return obj;
        }

        #endregion
    }//end class
}
