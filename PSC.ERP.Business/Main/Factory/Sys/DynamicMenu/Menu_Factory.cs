using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Data.Linq;
using PSC_ERP_Core;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Business.Main.Factory
{
    public class Menu_Factory : BaseFactory<Entities, PSC_ERP_Business.Main.Model.AppMenu>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Menu_Factory.New().CreateAloneObject();
        }
        public static Menu_Factory New()
        {
            return new Menu_Factory();
        }
        public Menu_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public AppMenu Get_AppMenuByID(Int32 id)
        {
            var result = (from o in this.ObjectSet
                          where o.ID == id
                          select o).SingleOrDefault();
            return result;
        }
        public AppMenu Get_AppMenu_CoIDLonNhat()
        {
            AppMenu obj = (from o in this.ObjectSet
                           orderby o.ID descending
                           select o).FirstOrDefault();
            return obj;
        }

        public IQueryable<AppMenu> Get_DanhSachAppMenuByUserID_DaPhanQuyen(int userID)
        {
            IQueryable<AppMenu> result = (from menu in this.ObjectSet
                                          join x in this.Context.AppMenusRights on menu.ID equals x.MenuID
                                          where x.UserID == userID
                                          orderby menu.LocalIdx
                                          select menu);
            return result;
        }

        //Load menu
        public IQueryable<AppMenu> Get_DanhSachAppMenuByUserID_KieuRibbonPage(string maPhanHe, int userID, bool isAdmin)
        {
            IQueryable<AppMenu> result = (from menu in this.ObjectSet
                                          where 
                                          (menu.ID ==
                                                      (
                                                          from a in this.Context.AppMenusRights
                                                          where a.MenuID == menu.ID
                                                          && (a.UserID == userID && isAdmin == false)//Nếu không phải admin thì lấy theo user
                                                          select a.MenuID
                                                      ).FirstOrDefault()
                                          || (isAdmin == true) // Là admin thì lấy tất cả menus
                                          )
                                          && menu.MaPhanHeQL == maPhanHe
                                          && menu.Type == "RibbonPage"
                                          && (menu.ParentAppMenu.Type == "Ribbon" || menu.ParentAppMenu.Type == "RibbonPageCategory")
                                          orderby menu.LocalIdx ascending
                                          select menu);
            return result;
        }
        public IQueryable<AppMenu> Get_DanhSachAppMenuByUserID_RibbonPageGroup(string maPhanHe, int userID, bool isAdmin, int parentID)
        {
            IQueryable<AppMenu> result = (from menu in this.ObjectSet
                                          where 
                                          (menu.ID ==
                                                      (
                                                          from a in this.Context.AppMenusRights
                                                          where a.MenuID == menu.ID
                                                          && (a.UserID == userID && isAdmin == false)//Nếu không phải admin thì lấy theo user
                                                          select a.MenuID
                                                      ).FirstOrDefault()
                                          || (isAdmin == true) // Là admin thì lấy tất cả menus
                                          )
                                          && menu.MaPhanHeQL == maPhanHe
                                          && menu.Type == "RibbonPageGroup"
                                          && menu.ParentID == parentID
                                          orderby menu.LocalIdx ascending
                                          select menu);
            return result;
        }
        public IQueryable<AppMenu> Get_DanhSachAppMenuByUserID_BarButtonItem(int userID, bool isAdmin, int parentID)
        {
            IQueryable<AppMenu> result = (from menu in this.ObjectSet
                                          where
                                          (menu.ID ==
                                                      (
                                                          from a in this.Context.AppMenusRights
                                                          where a.MenuID == menu.ID
                                                          && (a.UserID == userID && isAdmin == false)//Nếu không phải admin thì lấy theo user
                                                          select a.MenuID
                                                      ).FirstOrDefault()
                                          || (isAdmin == true) // Là admin thì lấy tất cả menus
                                          )
                                          && menu.ParentID == parentID
                                          orderby menu.LocalIdx ascending
                                          select menu);
            return result;
        }
        public IQueryable<AppMenu> Get_DanhSachAppMenuByUserID_BarButtonItem_BarSubItem_BarLinkContainerItem(int userID, bool isAdmin, int parentID)
        {
            IQueryable<AppMenu> result = (from menu in this.ObjectSet
                                          where 
                                          (menu.ID ==
                                                      (
                                                          from a in this.Context.AppMenusRights
                                                          where a.MenuID == menu.ID
                                                          && (a.UserID == userID && isAdmin == false)//Nếu không phải admin thì lấy theo user
                                                          select a.MenuID
                                                      ).FirstOrDefault()
                                          || (isAdmin == true) // Là admin thì lấy tất cả menus
                                          )
                                          && menu.ParentID == parentID
                                          orderby menu.LocalIdx ascending
                                          select menu);
            return result;
        }
        //
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (AppMenu item in deleteList)
            {
                //xoa phan quyen
                AppMenusRight_Factory.FullDelete(context, item.AppMenusRights.ToList<object>());
                //xóa menu
                context.AppMenus.DeleteObject(item);
            }
        }
        #endregion
    }

}
