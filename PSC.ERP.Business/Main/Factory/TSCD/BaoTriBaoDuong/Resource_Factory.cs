using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Core;
using System.Reflection;
using System.ComponentModel;
using System.Data.Linq;

using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main;
using PSC_ERP_Util.DateTimeExtension;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;

namespace PSC_ERP_Business.Main.Factory
{
    public class Resource_Factory : BaseFactory<Entities, Resource>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Resource_Factory.New().CreateAloneObject();
        }
        public static Resource_Factory New()
        {
            return new Resource_Factory();
        }
        public Resource_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public IQueryable<Resource> Get_DanhSachResourceByProjectID(int projectID)
        {
            IQueryable<Resource> query = (from o in this.ObjectSet
                                          where o.ProjectID == projectID
                                          select o);
            return query;
        }
        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            foreach (Resource item in deleteList)
            {
                //xóa Task
                Task_Factory.FullDelete(context, item.Tasks.ToArray<Object>());
                //xóa Resource
                context.Resources.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
