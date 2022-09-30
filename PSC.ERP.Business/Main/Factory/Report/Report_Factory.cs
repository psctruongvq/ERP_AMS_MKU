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
    public class Report_Factory : BaseFactory<Entities, Report>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return Report_Factory.New().CreateAloneObject();
        }
        public static Report_Factory New()
        {
            return new Report_Factory();
        }
        public Report_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public IQueryable<Object> GetMaPhanHeList()
        {
            IQueryable<Object> query = (from o in this.ObjectSet
                                        orderby o.MaPhanHe
                                        select new { o.MaPhanHe }).Distinct();
            return query;
        }
        public Boolean CheckContainReportKey(String reportKey)
        {
            Boolean result = (from o in this.ObjectSet
                              where o.ReportKey.ToLower() == reportKey.ToLower()
                              select true).FirstOrDefault();
            return result;
        }

        public IQueryable<Report> Get_DanhSachReport_InList_ByMaPhanHe(String maPhanHe)
        {
            //Lấy user admin
            app_users admin = app_users_Factory.New().Get_AppUserAdmin_PhucVuReport();

            IQueryable<Report> query = null;
            if (PSC_ERP_Global.Main.UserID == admin.UserID) // Lấy danh sách report mới nhất theo admin
            {
                query = (from o in this.ObjectSet
                         join y in this.Context.app_users on o.UserID equals y.UserID
                         where o.InList == true
                         && o.MaPhanHe == maPhanHe
                         && o.ReportID ==
                         (
                             from x in this.ObjectSet
                             where o.ReportKey == x.ReportKey
                                   && x.UserID == admin.UserID
                             orderby x.ModifiedDate descending
                             select x.ReportID
                         ).FirstOrDefault()
                         && o.UserID == admin.UserID
                         orderby o.Idx ascending
                         select o);
            }
            else // Danh sách report mới nhất (Nếu admin mới nhất thì lấy admin , nếu user mới nhất thì lấy user)
            {

                IQueryable<Report> queryDanhSachMoiNhatCuaUserAdmin = (from o in this.ObjectSet
                                                                       where o.InList == true
                                                                       && o.MaPhanHe == maPhanHe
                                                                       && o.ReportID ==
                                                                       (
                                                                           from x in this.ObjectSet
                                                                           where o.ReportKey == x.ReportKey
                                                                                 && x.UserID == admin.UserID
                                                                           orderby x.ModifiedDate descending
                                                                           select x.ReportID
                                                                       ).FirstOrDefault()
                                                                       && o.UserID == admin.UserID
                                                                       orderby o.Idx ascending
                                                                       select o);

                IQueryable<Report> queryDanhSachMoiNhatCuaUserThuong = (from o in this.ObjectSet
                                                                        where o.InList == true
                                                                        && o.MaPhanHe == maPhanHe
                                                                        && o.ReportID ==
                                                                        (
                                                                            from x in this.ObjectSet
                                                                            where o.ReportKey == x.ReportKey
                                                                            && x.UserID == PSC_ERP_Global.Main.UserID
                                                                            orderby x.ModifiedDate descending
                                                                            select x.ReportID
                                                                        ).FirstOrDefault()
                                                                        && o.UserID == PSC_ERP_Global.Main.UserID
                                                                        orderby o.Idx ascending
                                                                        select o);

                //Khởi tạo một danh sách chứa các id
                List<Int32> danhSachReportId = new List<int>();

                //Duyệt qua danh sách report mới nhất của user admin
                foreach (Report itemUserAdmin in queryDanhSachMoiNhatCuaUserAdmin)
                {
                    //Lấy report mới nhất trong user thường 
                    Report rptNew = (from o in queryDanhSachMoiNhatCuaUserThuong
                                     where o.ReportKey == itemUserAdmin.ReportKey
                                        && (o.ModifiedDate > itemUserAdmin.ModifiedDate
                                               || (o.ModifiedDate == itemUserAdmin.ModifiedDate
                                                       && o.ReportID > itemUserAdmin.ReportID
                                                   )
                                           )
                                     select o).SingleOrDefault();
                    if (rptNew != null) // Nếu user thường mới nhất thì lấy user thường
                    {
                        danhSachReportId.Add(rptNew.ReportID);
                    }
                    else // Lấy user admin
                    {
                        danhSachReportId.Add(itemUserAdmin.ReportID);
                    }
                }

                //Lấy danh sách report mới nhất dựa vào danh sách reportid
                query = (from o in this.ObjectSet
                         where o.InList == true
                         && o.MaPhanHe == maPhanHe
                         && danhSachReportId.Contains(o.ReportID)
                         orderby o.Idx descending
                         select o);


            }
            return query;
        }
        public IQueryable<Report> Get_DanhSachReportList_ByMaPhanHeAndUserID(String maPhanHe, int userID)
        {
            //Lấy user admin
            app_users admin = app_users_Factory.New().Get_AppUserAdmin_PhucVuReport();

            IQueryable<Report> query = null;
            if (userID == admin.UserID) // Lấy danh sách report mới nhất theo admin
            {
                query = (from o in this.ObjectSet
                         join y in this.Context.app_users on o.UserID equals y.UserID
                         where o.MaPhanHe == maPhanHe
                         && o.ReportID ==
                         (
                             from x in this.ObjectSet
                             where o.ReportKey == x.ReportKey
                                   && x.UserID == admin.UserID
                             orderby x.ModifiedDate descending
                             select x.ReportID
                         ).FirstOrDefault()
                         && o.UserID == admin.UserID
                         orderby o.Idx ascending
                         select o);
            }
            else // Danh sách report mới nhất (Nếu admin mới nhất thì lấy admin , nếu user mới nhất thì lấy user)
            {

                IQueryable<Report> queryDanhSachMoiNhatCuaUserAdmin = (from o in this.ObjectSet
                                                                       where o.MaPhanHe == maPhanHe
                                                                       && o.ReportID ==
                                                                       (
                                                                           from x in this.ObjectSet
                                                                           where o.ReportKey == x.ReportKey
                                                                                 && x.UserID == admin.UserID
                                                                           orderby x.ModifiedDate descending
                                                                           select x.ReportID
                                                                       ).FirstOrDefault()
                                                                       && o.UserID == admin.UserID
                                                                       orderby o.Idx ascending
                                                                       select o);

                IQueryable<Report> queryDanhSachMoiNhatCuaUserThuong = (from o in this.ObjectSet
                                                                        where o.MaPhanHe == maPhanHe
                                                                        && o.ReportID ==
                                                                        (
                                                                            from x in this.ObjectSet
                                                                            where o.ReportKey == x.ReportKey
                                                                            && x.UserID == userID
                                                                            orderby x.ModifiedDate descending
                                                                            select x.ReportID
                                                                        ).FirstOrDefault()
                                                                        && o.UserID == userID////
                                                                        orderby o.Idx ascending
                                                                        select o);

                //Khởi tạo một danh sách chứa các id
                List<Int32> danhSachReportId = new List<int>();

                //Duyệt qua danh sách report mới nhất của user admin
                foreach (Report itemUserAdmin in queryDanhSachMoiNhatCuaUserAdmin)
                {
                    //Lấy report mới nhất trong user thường 
                    Report rptNew = (from o in queryDanhSachMoiNhatCuaUserThuong
                                     where o.ReportKey == itemUserAdmin.ReportKey
                                        && (o.ModifiedDate > itemUserAdmin.ModifiedDate
                                               || (o.ModifiedDate == itemUserAdmin.ModifiedDate
                                                       && o.ReportID > itemUserAdmin.ReportID
                                                   )
                                           )
                                     select o).SingleOrDefault();
                    if (rptNew != null) // Nếu user thường mới nhất thì lấy user thường
                    {
                        danhSachReportId.Add(rptNew.ReportID);
                    }
                    else // Lấy user admin
                    {
                        danhSachReportId.Add(itemUserAdmin.ReportID);
                    }
                }

                //Lấy danh sách report mới nhất dựa vào danh sách reportid
                query = (from o in this.ObjectSet
                         where o.InList == true
                         && o.MaPhanHe == maPhanHe
                         && danhSachReportId.Contains(o.ReportID)
                         orderby o.Idx ascending
                         select o);
            }
            return query;
        }
        public IQueryable<Report> Get_DanhSachReport_OnForm_ByMaPhanHe(String maPhanHe)
        {

            IQueryable<Report> query = from o in this.ObjectSet
                                       where o.OnForm == true
                                       && o.MaPhanHe == maPhanHe
                                       select o;
            return query;
        }
        public Report Get_Report_ByReportKey(String reportKey, int userID)
        {
            //Lấy user admin
            app_users admin = app_users_Factory.New().Get_AppUserAdmin_PhucVuReport();

            Report query = null;
            if (PSC_ERP_Global.Main.UserID == admin.UserID) // Lấy đối tượng mới nhất theo admin
            {
                query = (from o in this.ObjectSet
                         join y in this.Context.app_users on o.UserID equals y.UserID
                         where o.ReportKey == reportKey
                         && o.ReportID ==
                         (
                             from x in this.ObjectSet
                             where o.ReportKey == x.ReportKey
                                   && x.UserID == admin.UserID
                             orderby x.ModifiedDate descending
                             select x.ReportID
                         ).FirstOrDefault()
                         && o.UserID == admin.UserID
                         select o).FirstOrDefault();
            }
            else // Lấy đối tượng mới nhất (Nếu admin mới nhất thì lấy admin , nếu user mới nhất thì lấy user)
            {

                Report reportMoiNhatCuaUserAdmin = (from o in this.ObjectSet
                                                    where o.ReportKey == reportKey
                                                    && o.ReportID ==
                                                    (
                                                        from x in this.ObjectSet
                                                        where o.ReportKey == x.ReportKey
                                                              && x.UserID == admin.UserID
                                                        orderby x.ModifiedDate descending
                                                        select x.ReportID
                                                    ).FirstOrDefault()
                                                    && o.UserID == admin.UserID
                                                    select o).FirstOrDefault();

                Report reportMoiNhatCuaUserThuong = (from o in this.ObjectSet
                                                     where o.ReportKey == reportKey
                                                     && o.ReportID ==
                                                     (
                                                         from x in this.ObjectSet
                                                         where o.ReportKey == x.ReportKey
                                                         && x.UserID == userID// 
                                                         orderby x.ModifiedDate descending
                                                         select x.ReportID
                                                     ).FirstOrDefault()
                                                     && o.UserID == PSC_ERP_Global.Main.UserID
                                                     select o).FirstOrDefault();


                if (reportMoiNhatCuaUserThuong != null && reportMoiNhatCuaUserAdmin != null)// Nếu cả hai đều có report cùng key
                {
                    if (reportMoiNhatCuaUserAdmin.ModifiedDate > reportMoiNhatCuaUserThuong.ModifiedDate)  // Nếu user admin mới nhất thì lấy id admin
                    {
                        query = reportMoiNhatCuaUserAdmin;
                    }
                    else if (reportMoiNhatCuaUserAdmin.ModifiedDate == reportMoiNhatCuaUserThuong.ModifiedDate)
                    {
                        if (reportMoiNhatCuaUserAdmin.ReportID > reportMoiNhatCuaUserThuong.ReportID)
                        {
                            query = reportMoiNhatCuaUserAdmin;
                        }
                        else
                        {
                            query = reportMoiNhatCuaUserThuong;
                        }
                    }
                    else
                    {
                        query = reportMoiNhatCuaUserThuong;
                    }
                }
                else if (reportMoiNhatCuaUserAdmin != null) // Nếu user thường không có report thì lấy của admin
                {
                    query = reportMoiNhatCuaUserAdmin;
                }

            }
            return query;
        }
        public Report Get_Report_ByReportID(Int32 reportID)
        {
            Report obj = (from o in this.ObjectSet
                          where o.ReportID == reportID
                          select o).SingleOrDefault();
            return obj;
        }


        #endregion
    }//end class
}
