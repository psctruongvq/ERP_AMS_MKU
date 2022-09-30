using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERPNew.Main.Util
{
    public class UserThemeConfiguration
    {

        public static void SetTheme(String name)
        {
            PSC_ERPNew.Main.BasicInfo.User.UserInterfaceTheme = name;
            PSC_ERPNew.Main.BasicInfo.UserFactory.SaveChangesWithoutTrackingLog();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = name;

        }
        public static void ReloadUserInterfaceTheme()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = PSC_ERPNew.Main.BasicInfo.User.UserInterfaceTheme;
        }
        public static void RegisterBonusSkins()
        {
            //đăng ký devexpress bonus skins
            DevExpress.UserSkins.BonusSkins.Register();
        }


    }
}
