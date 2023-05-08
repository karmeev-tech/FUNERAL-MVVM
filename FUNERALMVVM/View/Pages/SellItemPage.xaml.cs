using Domain.Complect;
using FUNERALMVVM.ViewModel;
using System.Windows;
using System;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for SellItemPage.xaml
    /// </summary>
    public partial class SellItemPage : Page
    {
        private SellItemController _controller;
        public SellItemPage()
        {
            _controller = new SellItemController();
            DataContext = _controller;
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                ItemComplectEntity dataRowView = (ItemComplectEntity)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                _controller.DeleteItem(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
