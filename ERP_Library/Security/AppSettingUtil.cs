using System.Configuration;

namespace ERP_Library
{
    public class AppSettingUtil
    {
        public static string GetAppSettingKey(string msgConstantKey)
        {   //can add References System.Configuration
            string msg;
            try
            {
                msg = ConfigurationManager.AppSettings[msgConstantKey];
                //msg = ConfigurationSettings.AppSettings[msgConstantKey];
            }
            catch
            {
                msg = string.Empty;
                //throw new Exception(msgConstantKey + " not found!!!");
            }
            return msg;
        }

        public static void WriteSetting(string key, string value)
        {
            // Open App.Config of executable
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Add an Application Setting.
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void RemoveSetting(string key)
        {
            // Open App.Config of executable
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Add an Application Setting.
            config.AppSettings.Settings.Remove(key);
            //config.AppSettings.Settings.Add(key, value);
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }

    }

}
