using System;
using System.Linq;
using PSC_ERP_Core;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class CongTy_Factory : BaseFactory<Entities, tblCongTy>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static BaseEntityObject CreateStandAloneObject()
        {
            return CongTy_Factory.New().CreateAloneObject();
        }
        public static CongTy_Factory New()
        {
            return new CongTy_Factory();
        }
        public CongTy_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom       
        public tblCongTy GetCongTy_TheoMaQuanLy(string  maQuanLy)
        {
            var result = (from o in this.ObjectSet
                          where o.MaCongTyQuanLy == maQuanLy
                          select o).SingleOrDefault();
            return result;
        }

        //-------------
        public tblCongTy Get_ByID(Int32 maCongTy)
        {
            var result = (from o in this.ObjectSet
                          where o.MaCongTy == maCongTy
                          select o).SingleOrDefault();
            return result;
        }
        #endregion
    }//end class
}
