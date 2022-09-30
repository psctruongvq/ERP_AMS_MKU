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
    public class DieuChinhGiaTri_Factory : BaseFactory<Entities, tblDieuChinhGiaTri>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return DieuChinhGiaTri_Factory.New().CreateAloneObject();
        }
        public static DieuChinhGiaTri_Factory New()
        {
            return new DieuChinhGiaTri_Factory();
        }
        public DieuChinhGiaTri_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, tblDieuChinhGiaTri dieuChinhGiaTri)
        {

            //clear chi tiết
            ChiTietDieuChinhGiaTri_Factory.FullDelete(context, dieuChinhGiaTri.tblChiTietDieuChinhGiaTris.ToList<Object>());
            //BaseFactory<Entities, tblChiTietDieuChinhGiaTri>.DeleteHelper(context, dieuChinhGiaTri.tblChiTietDieuChinhGiaTris);

            //xóa nghiệp vụ
            context.tblDieuChinhGiaTris.DeleteObject(dieuChinhGiaTri);

        }
        #endregion
    }//end class
}
