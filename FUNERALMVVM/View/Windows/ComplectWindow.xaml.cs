using FUNERALMVVM.View.Pages;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.Storage;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Interaction logic for KomplektWindow.xaml
    /// </summary>
    public partial class KomplektWindow : Window
    {
        public readonly ComplectController _complectController;
        public OrderPage _orderPage;
        public KomplektWindow(OrderPage orderPage)
        {
            _orderPage = orderPage;
            _complectController = new ComplectController(this, orderPage);
            DataContext = _complectController;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StorageItemEntity dataRowView = (StorageItemEntity)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                int count = dataRowView.Count;
                _complectController.DeleteItem(name, count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
