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
    public partial class DinhKhoan_Factory : BaseFactory<Entities, tblDinhKhoan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DinhKhoan_Factory.New().CreateAloneObject();
        }
        public static DinhKhoan_Factory New()
        {
            return new DinhKhoan_Factory();
        }
        public DinhKhoan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, tblDinhKhoan dinhKhoan)
        {
            //xoa but toan cua dinh khoan
            ButToan_Factory.FullDelete(context, dinhKhoan.tblButToans.ToList<Object>());
            //xoa dinh khoan
            context.tblDinhKhoans.DeleteObject(dinhKhoan);
        }
        #endregion
    }//end class
}
