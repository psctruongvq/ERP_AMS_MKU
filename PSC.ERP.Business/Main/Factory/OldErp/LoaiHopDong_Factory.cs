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
    public partial class LoaiHopDong_Factory : BaseFactory<Entities, tblLoaiHopDong>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return LoaiHopDong_Factory.New().CreateAloneObject();
        }
        public static LoaiHopDong_Factory New()
        {
            return new LoaiHopDong_Factory();
        }
        public LoaiHopDong_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        
        #endregion
    }//end class
}
