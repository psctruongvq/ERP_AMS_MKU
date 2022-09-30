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
using PSC_ERP_Util.DateTimeExtension;

namespace PSC_ERP_Business.Main.Factory
{
    public class CT_NVNgungvaTaiSuDungTSCD_Factory : BaseFactory<Entities, tblCT_NVNgungvaTaiSuDungTSCD>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return CT_NVNgungvaTaiSuDungTSCD_Factory.New().CreateAloneObject();
        }
        public static CT_NVNgungvaTaiSuDungTSCD_Factory New()
        {
            return new CT_NVNgungvaTaiSuDungTSCD_Factory();
        }
        public CT_NVNgungvaTaiSuDungTSCD_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDeleteCT_NVNgungSuDungTSCD(Entities context, List<Object> deleteList)
        {
            //xóa chi tiết nghiệp vụ ngừng và tái sử dụng
            foreach (tblCT_NVNgungvaTaiSuDungTSCD item in deleteList)
            {
                //Cập nhật lại ngừng sử dụng trong tài sản cố định cá biệt
                item.tblTaiSanCoDinhCaBiet.NgungSuDung = false;

                //xóa chi tiết nghiệp vụ ngừng và tái sử dụng tài sản cố định cá biệt
                context.DeleteObject(item);
            }
        }
        public static void FullDeleteCT_NVTaiSuDungTSCD(Entities context, List<Object> deleteList)
        {
            //xóa chi tiết nghiệp vụ ngừng và tái sử dụng
            foreach (tblCT_NVNgungvaTaiSuDungTSCD item in deleteList)
            {
                //Cập nhật lại ngừng và tái sử dụng sử dụng trong tài sản cố định cá biệt
                item.tblTaiSanCoDinhCaBiet.NgungSuDung = true;

                //xóa chi tiết nghiệp vụ ngừng và tái sử dụng tài sản cố định cá biệt
                context.DeleteObject(item);
            }
        }
        #endregion
    }//end class
}
