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
    public partial class LoaiChungTu_Factory : BaseFactory<Entities, tblLoaiChungTu>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return LoaiChungTu_Factory.New().CreateAloneObject();
        }
        public static LoaiChungTu_Factory New()
        {
            return new LoaiChungTu_Factory();
        }
        public LoaiChungTu_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblLoaiChungTu Get_LoaiChungTu_ByMaLoaiChungTu(long maLoaiChungTu)
        {
            tblLoaiChungTu obj = (from o in this.ObjectSet
                              where o.MaLoaiCT == maLoaiChungTu
                              select o).SingleOrDefault();
            return obj;
        }

        #endregion
    }//end class
}
