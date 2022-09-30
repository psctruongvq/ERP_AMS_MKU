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
    public class Task_ProjectEmployeeResource_Factory :  BaseFactory<Entities, Task_ProjectEmployeeResource>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Task_ProjectEmployeeResource_Factory.New().CreateAloneObject();
        }
        public static Task_ProjectEmployeeResource_Factory New()
        {
            return new Task_ProjectEmployeeResource_Factory();
        }
        public Task_ProjectEmployeeResource_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        //public Task_ProjectEmployeeResource GetTask_ProjectEmployeeResourceByProjectEmployeeResouID(int projectEmployeeResourceID)
        //{ 
        //       Task_ProjectEmployeeResource query = from o in this.ObjectSet
        //                                            where o.id
        //}


        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            foreach (Task_ProjectEmployeeResource item in deleteList)
            {
                //Xóa Task_ProjectEmployeeResource
                context.Task_ProjectEmployeeResource.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
