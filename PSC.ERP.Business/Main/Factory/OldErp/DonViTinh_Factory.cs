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

namespace PSC_ERP_Business.Main.Factory
{
    public partial class DonViTinh_Factory : BaseFactory<Entities, tblDonViTinh>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DonViTinh_Factory.New().CreateAloneObject();
        }
        public static DonViTinh_Factory New()
        {
            return new DonViTinh_Factory();
        }
        public DonViTinh_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblDonViTinh get_DonViTinh_ByTen(string ten)
        {
            tblDonViTinh query = (from o in this.ObjectSet
                                  where o.TenDonViTinh.ToLower() == ten.ToLower()
                                  select o).SingleOrDefault();
            return query;
        }
        #endregion
    }//end class
}
