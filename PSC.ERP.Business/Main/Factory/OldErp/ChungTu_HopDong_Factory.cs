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
    public partial class ChungTu_HopDong_Factory : BaseFactory<Entities, tblChungTu_HopDong>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChungTu_HopDong_Factory.New().CreateAloneObject();
        }
        public static ChungTu_HopDong_Factory New()
        {
            return new ChungTu_HopDong_Factory();
        }
        public ChungTu_HopDong_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //foreach (tblChungTu_HopDong item in deleteList)
            //{
            //    context.DeleteObject(item);
            //}
            BaseFactory<Entities, tblChungTu_HopDong>.DeleteHelper(context, deleteList);

        }
        #endregion
    }//end class
}
