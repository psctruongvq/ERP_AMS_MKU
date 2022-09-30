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
    public class ProjectEmployeeResource_Factory :  BaseFactory<Entities, ProjectEmployeeResource>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ProjectEmployeeResource_Factory.New().CreateAloneObject();
        }
        public static ProjectEmployeeResource_Factory New()
        {
            return new ProjectEmployeeResource_Factory();
        }
        public ProjectEmployeeResource_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public IQueryable<ProjectEmployeeResource> Get_DanhSachProjectEmployeeResourceByProjectID(int projectID)
        {
            IQueryable<ProjectEmployeeResource> query = (from o in this.ObjectSet
                                                        where o.ProjectID == projectID
                                                        select o);
            return query;
        }

        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            foreach (ProjectEmployeeResource item in deleteList)
            {
                //xóa Task_ProjectEmployeeResource
                Task_ProjectEmployeeResource_Factory.FullDelete(context, item.Task_ProjectEmployeeResource.ToArray<Object>());
                //Xóa ProjectEmployeeResource
                context.ProjectEmployeeResources.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
