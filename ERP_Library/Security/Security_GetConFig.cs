using System;

namespace ERP_Library
{
    public class Security_GetConFig
    {
        public const String ProductCode = "TEST1";
        public const String MaKhachHangSuDungKey = "MaKhachHangSuDung";
        public static String ServerKey = "852f30d8-c33d-4852-b334-d4992477bfc4";//"server";
        public static String DatabaseNameKey = "8052e8e3-8674-4ecf-b743-4f942ecdda43";// "databaseName";
        public static String UsernameKey = "3dc96f98-c440-4011-8b6d-3f76686942d6";//"userName";
        public static String PasswordKey = "399aa7eb-30df-4a0a-ac47-1627a7ce7517";//"password";
        public static string EncryptString(string message)
        {
            return EncryptUtil.EncryptString(message, "System.Windows.Forms.MessageBox");
        }
        public static string DecryptString(string message)
        {
            return EncryptUtil.DecryptString(message, "System.Windows.Forms.MessageBox");
        }
    }
}
