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
    public partial class NhomNgachLuongCoBan_Factory : BaseFactory<Entities, tblnsNhomNgachLuongCoBan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return NhomNgachLuongCoBan_Factory.New().CreateAloneObject();
        }
        public static NhomNgachLuongCoBan_Factory New()
        {
            return new NhomNgachLuongCoBan_Factory();
        }
        public NhomNgachLuongCoBan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsNhomNgachLuongCoBan> GetAll()
        {
            IQueryable<tblnsNhomNgachLuongCoBan> query = from o in ObjectSet orderby o.TenNhomNgachLuongCoBan select o;
            return query;
        }
        public tblnsNhomNgachLuongCoBan GetById(int id)
        {
            tblnsNhomNgachLuongCoBan obj = this.ObjectSet.SingleOrDefault(o => o.MaNhomNgachLuongCoBan == id);
            return obj;
        }

        #endregion
    }//end class
}
