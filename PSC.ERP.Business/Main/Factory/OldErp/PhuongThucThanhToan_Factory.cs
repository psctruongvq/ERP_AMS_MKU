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
    public partial class PhuongThucThanhToan_Factory : BaseFactory<Entities, tblPhuongThucThanhToan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return PhuongThucThanhToan_Factory.New().CreateAloneObject();
        }
        public static PhuongThucThanhToan_Factory New()
        {
            return new PhuongThucThanhToan_Factory();
        }
        public PhuongThucThanhToan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        #endregion
    }//end class
}
