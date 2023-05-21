using BossInstruments;
using Infrastructure.Context.Mongo;
using Infrastructure.Mongo;
using Microsoft.Extensions.DependencyInjection;
using OrderManager;
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
            string workspace = ConfigurationManager.AppSettings["Workspace"];
            InitCustom(workspace);
            //IntegraTests(workspace);
        }

        public void InitCustom(string workspace)
        {
            if (!Directory.Exists(workspace))
            {
                MessageBox.Show("Установка некорректна");
            }
            new ConfigBoss.Init().Connect();
        }

        public void IntegraTests(string workspace)
        {
            DordMetaFormalizer.SendDord(workspace);
        }
    }
}
