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
    public partial class DiaChi_Factory : BaseFactory<Entities, tblDiaChi>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DiaChi_Factory.New().CreateAloneObject();
        }
        public static DiaChi_Factory New()
        {
            return new DiaChi_Factory();
        }
        public DiaChi_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        #endregion
    }//end class
}
