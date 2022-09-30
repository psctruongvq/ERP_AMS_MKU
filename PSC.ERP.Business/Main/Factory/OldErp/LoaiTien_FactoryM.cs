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
    public partial class LoaiTien_Factory : BaseFactory<Entities, tblLoaiTien>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return LoaiTien_Factory.New().CreateAloneObject();
        }
        public static LoaiTien_Factory New()
        {
            return new LoaiTien_Factory();
        }
        public LoaiTien_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblLoaiTien Get_ByID(Int32 maLoaiTien)
        {
            var result = (from o in this.ObjectSet
                          where o.MaLoaiTien == maLoaiTien
                          select o).SingleOrDefault();
            return result;
        }

        public IQueryable<tblLoaiTien> GetAll()
        {
            IQueryable<tblLoaiTien> query = from o in this.ObjectSet
                                          // where o.MaLoaiChungTu == PSC_ERP_Global.TSCD.MaLoaiChungTuDieuChinhGiaTri
                                           //orderby o.NgayLap descending
                                           select o;
            return query;
        }
        #endregion
    }//end class
}
