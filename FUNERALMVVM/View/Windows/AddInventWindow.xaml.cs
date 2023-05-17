using FUNERALMVVM.ViewModel.Invent;
using Infrastructure.Model.Storage;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddInventWindow.xaml
    /// </summary>
    public partial class AddInventWindow : Window
    {
        private InventVM _inventVM;
        public AddInventWindow()
        {
            _inventVM = new InventVM();
            DataContext = _inventVM;
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                StorageItemEntity dataRowView = (StorageItemEntity)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                _inventVM.DeleteItem(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
