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
    public partial class tblChungTu_DeNghiChuyenKhoan_Factory : BaseFactory<Entities, tblChungTu_DeNghiChuyenKhoan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return tblChungTu_DeNghiChuyenKhoan_Factory.New().CreateAloneObject();
        }
        public static tblChungTu_DeNghiChuyenKhoan_Factory New()
        {
            return new tblChungTu_DeNghiChuyenKhoan_Factory();
        }
        public tblChungTu_DeNghiChuyenKhoan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, List<Object> deleteList)
        {

            foreach (tblChungTu_DeNghiChuyenKhoan ct_dn in deleteList)
            {

                context.tblChungTu_DeNghiChuyenKhoan.DeleteObject(ct_dn);
            }
          
        }
        #endregion
    }//end class
}
