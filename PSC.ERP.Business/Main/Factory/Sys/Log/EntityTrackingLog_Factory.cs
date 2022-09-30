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
using PSC_ERP_Business.Main.Predefined;
namespace PSC_ERP_Business.Main.Factory
{
    public class EntityTrackingLog_Factory : BaseFactory<Entities, EntityTrackingLog>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return EntityTrackingLog_Factory.New().CreateAloneObject();
        }
        public static EntityTrackingLog_Factory New()
        {
            return new EntityTrackingLog_Factory();
        }
        public EntityTrackingLog_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        #region Helper

        private IEnumerable<EntityTrackingLog> GetEntityTrackingListBy_LogType_UserId_TuNgayDenNgay(String logType, Int32 UserID, DateTime tuNgay, DateTime denNgay)
        {
            DateTime atEndOfDenNgay = denNgay.EndOfDay();

            IEnumerable<EntityTrackingLog> list;
            list = from o in this.ObjectSet
                   where o.LogType == logType && o.UserID == UserID && (tuNgay.Date <= o.LogDate && o.LogDate <= atEndOfDenNgay)
                   orderby o.LogDate descending
                   select o;
            return list;
        }

        private IEnumerable<EntityTrackingLog> GetEntityTrackingListBy_LogType_UserId_TuNgayDenNgay_BusinessCode(String logType, Int32 UserID, DateTime tuNgay, DateTime denNgay, BusinessCodeEnum businessCode = BusinessCodeEnum.ALL)
        {
            DateTime atEndOfDenNgay = denNgay.EndOfDay();

            IEnumerable<EntityTrackingLog> list;


            String businessCodeString = businessCode.ToString();
            String allString = BusinessCodeEnum.ALL.ToString();
            list = from o in this.ObjectSet
                   where o.LogType == logType && o.UserID == UserID && (tuNgay.Date <= o.LogDate && o.LogDate <= atEndOfDenNgay)
                    && (businessCodeString == allString || o.BusinessCode == businessCodeString)
                   orderby o.LogDate descending
                   select o;

            return list;
        }
        #endregion


        public IEnumerable<EntityTrackingLog> Get_EntityTrackingList_Added_byUser_TuNgayDenNgay(Int32 UserID, DateTime tuNgay, DateTime denNgay, BusinessCodeEnum businessCode = BusinessCodeEnum.ALL)
        {//lấy danh sách nhật ký thêm dữ liệu theo AppUser từ ngày đến ngày

            return GetEntityTrackingListBy_LogType_UserId_TuNgayDenNgay_BusinessCode("Added", UserID, tuNgay, denNgay, businessCode);
        }

        public IEnumerable<EntityTrackingLog> Get_EntityTrackingList_Modified_byUser_TuNgayDenNgay(Int32 UserID, DateTime tuNgay, DateTime denNgay, BusinessCodeEnum businessCode = BusinessCodeEnum.ALL)
        {//lấy danh sách nhật ký sửa dữ liệu theo AppUser từ ngày đến ngày
            return GetEntityTrackingListBy_LogType_UserId_TuNgayDenNgay_BusinessCode("Modified", UserID, tuNgay, denNgay, businessCode);
        }
        public IEnumerable<EntityTrackingLog> Get_EntityTrackingList_Deleted_byUser_TuNgayDenNgay(Int32 UserID, DateTime tuNgay, DateTime denNgay, BusinessCodeEnum businessCode = BusinessCodeEnum.ALL)
        {//lấy danh sách nhật ký xóa dữ liệu theo AppUser từ ngày đến ngày
            return GetEntityTrackingListBy_LogType_UserId_TuNgayDenNgay_BusinessCode("Deleted", UserID, tuNgay, denNgay, businessCode);
        }
        #endregion


    }//end class
}
