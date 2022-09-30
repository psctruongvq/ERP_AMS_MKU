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
    public class Task_Asset_Factory :  BaseFactory<Entities, Task_Asset>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Task_Asset_Factory.New().CreateAloneObject();
        }
        public static Task_Asset_Factory New()
        {
            return new Task_Asset_Factory();
        }
        public Task_Asset_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            foreach (Task_Asset item in deleteList)
            {
                //
                Task currentTask = item.Task;
                //xóa Task_Asset
                context.Task_Asset.DeleteObject(item);

                //Cập nhật lại phần trăm hoàn tất
                currentTask.PercentComplete = (Int32)currentTask.CapNhatPhanTramHoanTat();
            }
        }
        #endregion
    }//end class
}
