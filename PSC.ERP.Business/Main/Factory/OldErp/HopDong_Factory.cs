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
    public partial class HopDong_Factory : BaseFactory<Entities, tblHopDong>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return HopDong_Factory.New().CreateAloneObject();
        }
        public static HopDong_Factory New()
        {
            return new HopDong_Factory();
        }
        public HopDong_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        public virtual tblHopDong Get_HopDong_ByMaHopDong(long maHopDong)
        {
            tblHopDong obj = (from o in this.ObjectSet
                              where o.MaHopDong == maHopDong
                              select o).SingleOrDefault();
            return obj;
        }

        #endregion
    }//end class
}
