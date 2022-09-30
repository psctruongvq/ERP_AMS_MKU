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
    public class TaskJob_Factory :  BaseFactory<Entities, TaskJob>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TaskJob_Factory.New().CreateAloneObject();
        }
        public static TaskJob_Factory New()
        {
            return new TaskJob_Factory();
        }
        public TaskJob_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom

        public virtual IQueryable<TaskJob> GetAll_SortTaskJobIndexAsc()
        {

            IQueryable<TaskJob> query = from o in ObjectSet orderby o.TaskJobIndex ascending select o;
            return query;
        }
        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            foreach (TaskJob item in deleteList)
            {
                // Xóa task job
                context.TaskJobs.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
