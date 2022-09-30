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
namespace PSC_ERP_Business.Main.Factory
{
    public partial class app_UserChild_Factory : BaseFactory<Entities, app_UserChild>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return app_UserChild_Factory.New().CreateAloneObject();
        }
        public static app_UserChild_Factory New()
        {
            return new app_UserChild_Factory();
        }
        public app_UserChild_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public app_UserChild Get_AppUserByUserID(Int32 userID)
        {
            var result = (from user in this.ObjectSet
                          where user.UserID == userID
                          select user).SingleOrDefault();
            return result;
        }
        
        #endregion
    }//end class
}
