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
    public class Function_Factory : BaseFactory<Entities, AppFunction>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Function_Factory.New().CreateAloneObject();
        }
        public static Function_Factory New()
        {
            return new Function_Factory();
        }
        public Function_Factory()
            : base(Database.NewEntities())
        {
        }

        public override IQueryable<AppFunction> GetAll()
        {
            IQueryable<AppFunction> query = from o in this.ObjectSet
                                            orderby o.GlobalIdx ascending, o.LocalIdx ascending
                                            select o;
            return query;
        }
        public AppFunction GetFunctionById(int id)
        {

            KeyValuePair<String, object> key = new KeyValuePair<string, Object>("FunctionID", id);
            return base.GetObjectBySingleKey(key);
        }
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            //duyệt qua danh sách
            foreach (AppFunction item in deleteList)
            {
                //xoa phan quyen
                Menu_Factory.FullDelete(context, item.AppMenus.ToList<object>());
                //xóa menu
                context.AppFunctions.DeleteObject(item);
            }
        }
    }//end class
}
