
using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace FUNERALMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Config config = new Config();
            if (Directory.Exists(ConfigurationManager.AppSettings[config.DordCache]))
            {
                Directory.Delete(ConfigurationManager.AppSettings[config.DordCache], true);
                Directory.CreateDirectory(ConfigurationManager.AppSettings[config.DordCache]);
            }
            Directory.CreateDirectory(ConfigurationManager.AppSettings[config.DordCache]);
            Console.WriteLine(ConfigurationManager.AppSettings[config.DordCache]);
        }

        public void SetAppSettings(string appSettings, string value)
        {
            string appSettingValue = ConfigurationManager.AppSettings[appSettings];
            appSettingValue = appSettingValue.Replace("{path}", value);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[appSettings].Value = appSettingValue;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(appSettings);
        }
    }
    public class Config
    {
        public string ProgramData { get => Directory.GetCurrentDirectory(); }
        public string DordCache { get => "ProgramDord"; }
    }
}
