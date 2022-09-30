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
    public partial class ChucVu_Factory : BaseFactory<Entities, tblnsChucVu>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChucVu_Factory.New().CreateAloneObject();
        }
        public static ChucVu_Factory New()
        {
            return new ChucVu_Factory();
        }
        public ChucVu_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsChucVu> GetAll()
        {
            IQueryable<tblnsChucVu> query = from o in ObjectSet orderby o.TenChucVu select o;
            return query;
        }
        public tblnsChucVu GetById(int id)
        {
            tblnsChucVu obj = this.ObjectSet.SingleOrDefault(o => o.MaChucVu == id);
            return obj;
        }

        #endregion
    }//end class
}
