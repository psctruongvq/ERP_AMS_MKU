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
    public partial class tblChungTu_LenhChuyenTien_Factory : BaseFactory<Entities, tblChungTu_LenhChuyenTien>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return tblChungTu_LenhChuyenTien_Factory.New().CreateAloneObject();
        }
        public static tblChungTu_LenhChuyenTien_Factory New()
        {
            return new tblChungTu_LenhChuyenTien_Factory();
        }
        public tblChungTu_LenhChuyenTien_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, List<Object> deleteList)
        {

            foreach (tblChungTu_LenhChuyenTien ct_dn in deleteList)
            {

                context.tblChungTu_LenhChuyenTien.DeleteObject(ct_dn);
            }
          
        }
        #endregion
    }//end class
}
