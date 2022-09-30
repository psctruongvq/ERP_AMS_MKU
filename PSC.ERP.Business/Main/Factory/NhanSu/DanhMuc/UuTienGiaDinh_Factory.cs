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
    public partial class UuTienGiaDinh_Factory : BaseFactory<Entities, tblnsUuTienGiaDinh>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return UuTienGiaDinh_Factory.New().CreateAloneObject();
        }
        public static UuTienGiaDinh_Factory New()
        {
            return new UuTienGiaDinh_Factory();
        }
        public UuTienGiaDinh_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsUuTienGiaDinh> GetAll()
        {
            IQueryable<tblnsUuTienGiaDinh> query = from o in ObjectSet orderby o.MaQuanLy select o;
            return query;
        }
        public tblnsUuTienGiaDinh GetById(int id)
        {
            tblnsUuTienGiaDinh obj = this.ObjectSet.SingleOrDefault(o => o.MaUuTienGiaDinh == id);
            return obj;
        }

        #endregion
    }//end class
}
