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
    public class AppMenusRight_Factory : BaseFactory<Entities, AppMenusRight>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return AppMenusRight_Factory.New().CreateAloneObject();
        }
        public static AppMenusRight_Factory New()
        {
            return new AppMenusRight_Factory();
        }
        public AppMenusRight_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public AppMenusRight Get_AppMenusRightByMenuIDAndUserId(Int32 menuID, Int32 userID)
        {
            var obj = (from o in this.ObjectSet
                       where o.MenuID == menuID && o.UserID == userID 
                       select o).SingleOrDefault();
            return obj;
        }
        public IQueryable<AppMenusRight> Get_DanhSachAppMenusRightByUserID(Int32 userID)
        {
            var query = from o in this.ObjectSet
                        where o.UserID == userID
                        select o;
            return query;
        }
        public IQueryable<AppMenusRight> Get_DanhSachAppMenusRightByMenuID(Int32 menuID)
        {
            var query = from o in this.ObjectSet
                        where o.MenuID == menuID
                        select o;
            return query;
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (AppMenusRight item in deleteList)
            {
                //xoa phan quyen
                context.AppMenusRights.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
