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
using System.Collections;
using PSC_ERP_Common.Ado.Net;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class ChiPhiThucHien_Factory : BaseFactory<Entities, tblChiPhiThucHien>
    {
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChiPhiThucHien_Factory.New().CreateAloneObject();
        }
        public static ChiPhiThucHien_Factory New()
        {
            return new ChiPhiThucHien_Factory();
        }
        public ChiPhiThucHien_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblChiPhiThucHien GetChiPhiThucHienByID(long machiphithuchien)
        {
            tblChiPhiThucHien cpth = (from o in this.ObjectSet
                                  where o.MaChiPhiThucHien==machiphithuchien
                                      select o).SingleOrDefault<tblChiPhiThucHien>();
            return cpth;
        }

        public static void FullDelete(Entities context, List<tblChiPhiThucHien> deleteList)
        {
            foreach (tblChiPhiThucHien cpthDel in deleteList)
            {
                context.tblChiPhiThucHiens.DeleteObject(cpthDel);
            }
        }
        

        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            BaseFactory<Entities, tblChiPhiThucHien>.DeleteHelper(context, deleteList);
        }
        #endregion
    }//end class
}
