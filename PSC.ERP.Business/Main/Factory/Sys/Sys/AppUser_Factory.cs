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
    public class AppUser_Factory : BaseFactory<Entities, AppUser>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return AppUser_Factory.New().CreateAloneObject();
        }
        public static AppUser_Factory New()
        {
            return new AppUser_Factory();
        }
        public AppUser_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public AppUser Get_AppUserByUserNameAndPassword(String userName, String password)
        {
            var result = (from user in this.ObjectSet
                          where user.UserName.ToLower().Equals(userName.ToLower()) && user.Password.ToLower().Equals(password.ToLower())
                          select user).SingleOrDefault();
            return result;
        }
        #endregion
    }//end class
}
