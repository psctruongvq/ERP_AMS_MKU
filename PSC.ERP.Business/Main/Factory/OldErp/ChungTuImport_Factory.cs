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
    public partial class ChungTuImport_Factory : BaseFactory<Entities, tblChungTuImport>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChungTuImport_Factory.New().CreateAloneObject();
        }
        public static ChungTuImport_Factory New()
        {
            return new ChungTuImport_Factory();
        }
        public ChungTuImport_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        public IQueryable<tblChungTuImport> GetListBy_MaLoaiChungTu_MaBoPhan_Nam(Int32? maLoaiChungTu, Int32? maBoPhan, Int32? nam)
        {
            Boolean tatCaLoaiChungTu = ((maLoaiChungTu ?? 0) == 0);
            Boolean tatCaBoPhan = ((maBoPhan ?? 0) == 0);
            Boolean tatCaNam = ((nam ?? 0) == 0);
            var query = from o in this.ObjectSet
                        where (tatCaLoaiChungTu || o.MaLoaiChungTu == maLoaiChungTu)
                            && (tatCaBoPhan || o.MaBoPhan == maBoPhan)
                            && (tatCaNam || o.NgayLap.Value.Year == nam)
                        orderby o.SoChungTu
                        select o;
            return query;
        }

        #endregion
    }//end class
}
