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
    public class MucNganSach_Factory : BaseFactory<Entities, tblMucNganSach>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return MucNganSach_Factory.New().CreateAloneObject();
        }
        public static MucNganSach_Factory New()
        {
            return new MucNganSach_Factory();
        }
        public MucNganSach_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        #region Lấy danh sách tất cả Mục ngân sách
        public override IQueryable<tblMucNganSach> GetAll()
        {
            IQueryable<tblMucNganSach> query = from o in this.ObjectSet
                                                  orderby o.MaMucNganSachQL
                                                  select o;

            return query;
        }
        #endregion

        #region Lấy Mục Ngân sách theo Mã
        public tblMucNganSach Get_MucNganSachbyMa(int maMucNganSach)
        {

            var query = (from o in this.ObjectSet
                         where o.MaMucNganSach == maMucNganSach
                         select o).SingleOrDefault();
            return query;
        }
        #endregion

        #endregion
    }//end class
}
