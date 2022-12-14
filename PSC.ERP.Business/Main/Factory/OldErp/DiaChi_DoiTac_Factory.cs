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
    public partial class DiaChi_DoiTac_Factory : BaseFactory<Entities, tblDiaChi_DoiTac>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DiaChi_DoiTac_Factory.New().CreateAloneObject();
        }
        public static DiaChi_DoiTac_Factory New()
        {
            return new DiaChi_DoiTac_Factory();
        }
        public DiaChi_DoiTac_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        
        #endregion
    }//end class
}
