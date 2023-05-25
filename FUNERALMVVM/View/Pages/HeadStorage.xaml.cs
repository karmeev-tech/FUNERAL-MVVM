using FUNERALMVVM.ViewModel;
using Infrastructure.Model.Storage;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for HeadStorage.xaml
    /// </summary>
    public partial class HeadStorage : Page
    {
        private readonly HeadStorageController _headStorageController;
        public HeadStorage()
        {
            _headStorageController = new();
            DataContext = _headStorageController;
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                StorageItemEntity dataRowView = (StorageItemEntity)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                _headStorageController.DeleteItem(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
