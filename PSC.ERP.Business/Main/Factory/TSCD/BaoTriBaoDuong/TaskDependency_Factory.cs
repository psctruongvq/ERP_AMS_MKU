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
    public class TaskDependency_Factory : BaseFactory<Entities, TaskDependency>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return TaskDependency_Factory.New().CreateAloneObject();
        }
        public static TaskDependency_Factory New()
        {
            return new TaskDependency_Factory();
        }
        public TaskDependency_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public IQueryable<TaskDependency> Get_TaskDependencyByProjectID(int projectID)
        {
            IQueryable<TaskDependency> query = (from o in this.ObjectSet
                                                where o.Task.Resource.ProjectID == projectID
                                                select o);
            return query;

        }
        public IQueryable<Task> Get_TaskAll()
        {
            IQueryable<Task> query = (from o in this.Context.Tasks
                                      select o);
            return query;

        }
        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            foreach (TaskDependency item in deleteList)
            {
                //xóa TaskDependency
                context.TaskDependencies.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
