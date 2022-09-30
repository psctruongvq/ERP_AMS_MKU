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
    public partial class TienTe_Factory : BaseFactory<Entities, tblTienTe>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TienTe_Factory.New().CreateAloneObject();
        }
        public static TienTe_Factory New()
        {
            return new TienTe_Factory();
        }

        public TienTe_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblTienTe Get_ChungTu_ByMaChungTu(long maTienTe)
        {
            tblTienTe obj = (from o in this.ObjectSet
                             where o.MaTienTe == maTienTe
                             select o).SingleOrDefault();
            return obj;
        }
        #endregion
    }//end class
}
