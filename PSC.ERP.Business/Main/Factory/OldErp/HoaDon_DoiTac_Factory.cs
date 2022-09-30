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
    public partial class HoaDon_DoiTac_Factory : BaseFactory<Entities, tblHoaDon_DoiTac>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return HoaDon_DoiTac_Factory.New().CreateAloneObject();
        }
        public static HoaDon_DoiTac_Factory New()
        {
            return new HoaDon_DoiTac_Factory();
        }
        public HoaDon_DoiTac_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public virtual tblHoaDon_DoiTac Get_HoaDon_DoiTac_ByMaHoaDon(long maHoaDon)
        {
            tblHoaDon_DoiTac obj = (from o in this.ObjectSet
                             where o.MaHoaDon == maHoaDon
                             select o).FirstOrDefault();
            return obj;
        }

        public static void FullDelete(Entities context, List<Object> deleteList)
        {

            foreach (tblHoaDon_DoiTac obj in deleteList)
            {
                context.tblHoaDon_DoiTac.DeleteObject(obj);
            }

        }
        #endregion
    }//end class
}
