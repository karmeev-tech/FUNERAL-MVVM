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
            Config config = new();

            StartupUri = config.StartupUri;
            //StartupUri = config.WorkUri;

            if (Directory.Exists(ConfigurationManager.AppSettings[config.DordCache]))
            {
                Directory.Delete(ConfigurationManager.AppSettings[config.DordCache], true);
                Directory.CreateDirectory(ConfigurationManager.AppSettings[config.DordCache]);
            }
            Directory.CreateDirectory(ConfigurationManager.AppSettings[config.DordCache]);
            Console.WriteLine(ConfigurationManager.AppSettings[config.DordCache]);
        }
    }
    public class Config
    {
        public string ProgramData { get => Directory.GetCurrentDirectory(); }
        public string DordCache { get => "ProgramDord"; }
        public Uri StartupUri { get => new("/View/MainWindow.xaml", UriKind.Relative); }
        public Uri WorkUri { get => new("/View/WorkWindow.xaml", UriKind.Relative); }
    }
}
