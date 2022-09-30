using System;
using System.Linq;
using PSC_ERP_Core;

using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;

namespace PSC_ERP_Business.Main.Factory
{
    public class Project_Factory : BaseFactory<Entities, Project>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private List<Int32> LoaiHoaDonTaiSanList_ = new List<Int32> { (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan };
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Project_Factory.New().CreateAloneObject();
        }
        public static Project_Factory New()
        {
            return new Project_Factory();
        }
        public Project_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, params Object[] deleteList)
        {
            foreach (Project item in deleteList)
            {
                //xóa Resource
                Resource_Factory.FullDelete(context, item.Resources.ToArray<Object>());
                //xóa ProjectEmployeeResource
                ProjectEmployeeResource_Factory.FullDelete(context, item.ProjectEmployeeResources.ToArray<Object>());
                // Xóa project
                context.Projects.DeleteObject(item);
            }
        }
        public Project Get_ProjectByProjectID(int projectID)
        {
            var query = (from o in this.ObjectSet
                         where o.ID == projectID
                         select o).SingleOrDefault();
            return query;

        }
        public IQueryable<Project> TimKiem(LoaiTimProjectEnum loaiTim, CompareTypeEnum compareType, DateTime tuNgay, DateTime denNgay, Int32 userID = 0)
        {
            IQueryable<Project> query = null;
            Boolean isAdmin = false;
            //if (AppUser_Factory.New().CheckIsAdmin(userID))
            //    isAdmin = true;
            //IQueryable<Project> projectList = from o in this.ObjectSet
            //                                  where (isAdmin == true || userID == 0 || (o.UserID ?? 0) == userID
            //                                   || o.AppUser.AppUserAccepts1.Any(x => x.UserID == userID))
            //                                  select o;
            IQueryable<Project> projectList = from o in this.ObjectSet
                                              where o.app_users.UserID == userID
                                              select o;
            switch (loaiTim)
            {
                case LoaiTimProjectEnum.TatCa:
                    query = projectList;
                    break;
                case LoaiTimProjectEnum.NgayLap://tìm theo ngày chứng từ
                    {
                        switch (compareType)
                        {
                            case CompareTypeEnum.Equal:
                                query = from o in projectList
                                        where o.CreateDate == tuNgay.Date
                                        orderby o.CreateDate descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThan:
                                query = from o in projectList
                                        where o.CreateDate < tuNgay.Date
                                        orderby o.CreateDate descending
                                        select o;
                                break;
                            case CompareTypeEnum.LessThanOrEqual:
                                query = from o in projectList
                                        where o.CreateDate <= tuNgay.Date
                                        orderby o.CreateDate descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThanOrEqual:
                                query = from o in projectList
                                        where o.CreateDate >= tuNgay.Date
                                        orderby o.CreateDate descending
                                        select o;
                                break;
                            case CompareTypeEnum.GreaterThan:
                                query = from o in projectList
                                        where o.CreateDate > tuNgay.Date
                                        orderby o.CreateDate descending
                                        select o;
                                break;
                            case CompareTypeEnum.Between:
                                query = from o in projectList
                                        where o.CreateDate >= tuNgay.Date
                                         && o.CreateDate <= denNgay.Date
                                        orderby o.CreateDate descending
                                        select o;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            return query;
        }
        #endregion
    }//end class
}
