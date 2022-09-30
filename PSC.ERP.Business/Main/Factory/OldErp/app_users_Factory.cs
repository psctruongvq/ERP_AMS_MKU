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
namespace PSC_ERP_Business.Main.Factory
{
    public partial class app_users_Factory : BaseFactory<Entities, app_users>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return app_users_Factory.New().CreateAloneObject();
        }
        public static app_users_Factory New()
        {
            return new app_users_Factory();
        }
        public app_users_Factory()
            : base(Database.NewEntities())
        {

        }
        public IQueryable<app_users> LayDanhSachUser_TheoMaCongTy(int maCongTy)
        {
            IQueryable<app_users> user = (from o in this.ObjectSet
                              where o.MaCongTy == maCongTy
                              select o);
            return user;
        }
        #region Custom
        //bổ sung ngày 18/01/2016
        public app_users LayUser_TheoPhongBan_MaQuanLy(string maQuanLy, int maPhongBan)
        {
            app_users user = (from o in this.ObjectSet
                              where o.MaBoPhan == maPhongBan && o.MaQLUser.Contains(maQuanLy)
                              select o).SingleOrDefault<app_users>();
            return user;
        }

        //--------------
        public app_users Get_AppUserByUserID(Int32 userID)
        {
            var result = (from user in this.ObjectSet
                          where user.UserID == userID
                          select user).SingleOrDefault();
            return result;
        }
        public bool CheckAdminByUserID_ContainsAdminKeyword(int userID)
        {
            Boolean isAdmin = false;

            isAdmin = (from user in this.ObjectSet.AsParallel()
                       where user.UserID == userID
                        && user.TenDangNhap.ToUpper().Contains("ADMIN")
                       select true).FirstOrDefault();

            return isAdmin;
        }
        public bool CheckIsAdmin(int userID)
        {
            Boolean isAdmin = false;

            isAdmin = (from user in this.ObjectSet
                       where user.UserID == userID
                        && user.TenDangNhap.ToUpper().CompareTo("ADMIN") == 0
                       select true).FirstOrDefault();

            return isAdmin;
        }
        public bool CheckIsAdmin_PhucVuReport(int userID)
        {
            Boolean isAdmin = false;

            isAdmin = (from user in this.ObjectSet
                       where user.UserID == userID
                        && user.TenDangNhap.ToUpper().CompareTo("ADMIN") == 0
                       select true).FirstOrDefault();

            return isAdmin;
        }
        public app_users Get_AppUserAdmin()
        {

            var result = (from user in this.ObjectSet
                          where user.TenDangNhap.ToUpper().CompareTo("ADMIN") == 0
                          select user).SingleOrDefault();

            return result;
        }
        public app_users Get_AppUserAdmin_PhucVuReport()
        {

            var result = (from user in this.ObjectSet
                          where user.TenDangNhap.ToUpper().CompareTo("ADMIN") == 0
                          select user).SingleOrDefault();

            return result;
        }
        public IQueryable<app_users> Get_DanhSachUser_PhucVuTrackingForm()
        {
            //Kiểm tra user đăng nhập có phải admin hay không
            Boolean isAdmin = app_users_Factory.New().CheckAdminByUserID_ContainsAdminKeyword(PSC_ERP_Global.Main.UserID);
            //nếu admin thì lấy hết danh sách user, nếu là user thường thì lấy danh sách có 1 user
            IQueryable<app_users> result = (from user in this.ObjectSet
                                            where
                                                   isAdmin == true || user.UserID == PSC_ERP_Global.Main.UserID
                                            orderby user.TenDangNhap
                                            select user);


            return result;
        }
        public IQueryable<app_users> Get_DanhSachUser_PhucVuReportManager()
        {
            //Kiểm tra user đăng nhập có phải admin hay không
            Boolean isAdmin = app_users_Factory.New().CheckIsAdmin_PhucVuReport(PSC_ERP_Global.Main.UserID);
            //nếu admin thì lấy hết danh sách user, nếu là user thường thì lấy danh sách có 1 user
            IQueryable<app_users> result = (from user in this.ObjectSet
                                            where
                                                  isAdmin == true || user.UserID == PSC_ERP_Global.Main.UserID
                                            orderby user.TenDangNhap
                                            select user);


            return result;
        }
        public app_users Get_AppUserByUserNameAndPassword(String userName, String password)
        {
            var result = (from user in this.ObjectSet
                          where user.TenDangNhap.ToLower().Equals(userName.ToLower()) && user.MatKhau.ToLower().Equals(password.ToLower())
                          select user).SingleOrDefault();
            return result;
        }

        public IQueryable<app_users> Get_AppUserbyBoPhan(int maBoPhan)//pcm
        {
            IQueryable<app_users> result = (from user in this.ObjectSet
                                            where
                                               user.MaBoPhan == maBoPhan
                                               || maBoPhan == 0
                                            orderby user.TenDangNhap
                                            select user);


            return result;
        }
        #endregion
    }//end class
}
