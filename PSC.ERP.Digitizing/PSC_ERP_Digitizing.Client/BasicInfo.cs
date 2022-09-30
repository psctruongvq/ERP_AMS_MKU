using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Digitizing.Client
{
    public class BasicInfo
    {
        //public static PSC_ERP_Business.Main.Factory.AppUser_Factory UserFactory = PSC_ERP_Business.Main.Factory.AppUser_Factory.New();
        public static PSC_ERP_Business.Main.Factory.app_users_Factory UserFactory = PSC_ERP_Business.Main.Factory.app_users_Factory.New();
        //private static AppUser User_ = null;
        private static app_users User_ = null;
        public static app_users User//AppUser User
        {
            get
            {
                if (User_ == null || (PSC_ERP_Global.Main.UserID != User_.UserID))
                {
                    User_ = UserFactory.GetObjectBySingleKey(new KeyValuePair<string, object>(AppUser.UserID_PropertyName, PSC_ERP_Global.Main.UserID));
                    //PSC_ERP_Global.Main.UserID = ERP_Library.Security.CurrentUser.Info.UserID;
                    PSC_ERP_Global.Main.MaBoPhanCuaUser = User_.MaBoPhan ?? 0;
                }
                /*
                if (User_ == null || (PSC_ERP_Global.Main.UserID != (ERP_Library.Security.CurrentUser.Info == null ? 0 : ERP_Library.Security.CurrentUser.Info.UserID)))
                {
                    //if (PSC_ERP_Global.Main.UserID == 0 || (PSC_ERP_Global.Main.UserID != (ERP_Library.Security.CurrentUser.Info == null ? 0 : ERP_Library.Security.CurrentUser.Info.UserID)))
                    {
                        //lay user id tu project ERP_Library
                        try
                        {
                            PSC_ERP_Global.Main.UserID = ERP_Library.Security.CurrentUser.Info.UserID;
                            PSC_ERP_Global.Main.MaBoPhanCuaUser =ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }
                    User_ = UserFactory.GetObjectBySingleKey(new KeyValuePair<string, object>(AppUser.UserID_PropertyName, PSC_ERP_Global.Main.UserID));
                }*/

                return User_;

            }
            set
            {
                User_ = value;
                if (User_ != null)
                    PSC_ERP_Global.Main.UserID = User_.UserID;
                else
                    PSC_ERP_Global.Main.UserID = 0;
            }
        }
        BasicInfo()
        {
        }

        public static void CopyDuLieuDangNhapTuHeThongCuSangHeThongMoi()
        {
            Int32 userID = BasicInfo.User.UserID;
        }
    }
}
