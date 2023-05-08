using FUNERALMVVM.ViewModel;
using System.Reflection.Metadata;
using System.Windows;
using System;
using System.Windows.Controls;
using LegacyInfrastructure.Storage;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for HeadStorage.xaml
    /// </summary>
    public partial class HeadStorage : Page
    {
        public HeadStorage()
        {
            DataContext = new HeadStorageController();
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                ShopItem dataRowView = (ShopItem)((Button)e.Source).DataContext;
                string name = dataRowView.Name;

                IShopRepos shopRepos = new ShopRepos();
                shopRepos.DeleteInWorkspace(name);
                shopRepos.DeleteInDB(name);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                HeadStorageController vm = new();
                this.DataContext = vm;
            }
        }
    }
}
