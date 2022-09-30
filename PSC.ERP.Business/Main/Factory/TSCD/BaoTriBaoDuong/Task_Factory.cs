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
    public class Task_Factory :  BaseFactory<Entities, Task>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Task_Factory.New().CreateAloneObject();
        }
        public static Task_Factory New()
        {
            return new Task_Factory();
        }
        public Task_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static Task NewTask()
        {
            //Khởi tạo task
           Task task = Task_Factory.New().CreateAloneObject();
            //Set giá trị mặc định cho task
            task.StartTime = AppUser_Factory.New().SystemDate;
            task.EndTime = AppUser_Factory.New().SystemDate;
            task.ActualStartTime = AppUser_Factory.New().SystemDate;
            task.ActualEndTime = AppUser_Factory.New().SystemDate;
            task.PercentComplete = 0;
            task.TaskJobIndex = 0;
            task.Cost = 0;
            task.ActualCost = 0;

            return task;       
        }
        public IQueryable<Task> Get_DanhSachTaskByProjectID(int projectID)
        {
            IQueryable<Task> query = (from o in this.ObjectSet
                                      where o.Resource.ProjectID == projectID
                                      select o);
            return query;
        }

        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            foreach (Task item in deleteList)
            {
                //xóa Task_ProjectEmployeeResource
                Task_ProjectEmployeeResource_Factory.FullDelete(context, item.Task_ProjectEmployeeResource.ToArray<Object>());
                //xóa Task_Asset
                Task_Asset_Factory.FullDelete(context, item.Task_Asset.ToArray<Object>());
                //xóa TaskDependency
                TaskDependency_Factory.FullDelete(context, item.TaskDependencies.ToArray<Object>());
                TaskDependency_Factory.FullDelete(context, item.TaskDependencies1.ToArray<Object>());
                //xóa Task
                context.Tasks.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
