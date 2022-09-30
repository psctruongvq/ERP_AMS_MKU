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
    public partial class ButToan_ChiPhiHD_Factory : BaseFactory<Entities, tblButToan_ChiPhiHD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ButToan_ChiPhiHD_Factory.New().CreateAloneObject();
        }
        public static ButToan_ChiPhiHD_Factory New()
        {
            return new ButToan_ChiPhiHD_Factory();
        }
        public ButToan_ChiPhiHD_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblButToan_ChiPhiHD item in deleteList)
            {
                context.tblButToan_ChiPhiHD.DeleteObject(item);//N
            }
        }
        #endregion
    }//end class
}
