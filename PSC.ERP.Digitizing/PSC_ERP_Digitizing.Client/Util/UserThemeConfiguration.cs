using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERP_Digitizing.Client.Util
{
    public class UserThemeConfiguration
    {

        public static void SetTheme(String name)
        {
            BasicInfo.User.UserInterfaceTheme = name;
            BasicInfo.UserFactory.SaveChangesWithoutTrackingLog();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = name;

        }
        public static void ReloadUserInterfaceTheme()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = BasicInfo.User.UserInterfaceTheme;
        }
        public static void RegisterBonusSkins()
        {
            //đăng ký devexpress bonus skins
            DevExpress.UserSkins.BonusSkins.Register();
        }


    }
}
