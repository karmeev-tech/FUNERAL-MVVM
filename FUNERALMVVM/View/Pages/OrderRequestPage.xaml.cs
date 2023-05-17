using FUNERALMVVM.ViewModel.Shop;
using Infrastructure.Model.Storage;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderRequestPage.xaml
    /// </summary>
    public partial class OrderRequestPage : Page
    {
        private readonly OrderRequestVM _orderRequestVM;
        public OrderRequestPage()
        {
            _orderRequestVM = new();
            DataContext = _orderRequestVM;
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                StorageItemEntity dataRowView = (StorageItemEntity)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                _orderRequestVM.DeleteItem(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
