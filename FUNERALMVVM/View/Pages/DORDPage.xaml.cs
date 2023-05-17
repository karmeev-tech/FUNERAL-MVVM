using Domain.Dord;
using Domain.Shop;
using FUNERALMVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for DORDPage.xaml
    /// </summary>
    public partial class DORDPage : Page
    {
        private DORDController _dORDController = new();
        public DORDPage()
        {
            DataContext = _dORDController;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDord dataRowView = (OrderDord)((Button)e.Source).DataContext;
                string name = dataRowView.ModelFuneral;
                _dORDController.DeleteOrder(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                DordEntity dataRowView = (DordEntity)((Button)e.Source).DataContext;
                string name = dataRowView.ManagerName;
                _dORDController.DeleteDord(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                ShoppingItem dataRowView = (ShoppingItem)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                _dORDController.DeleteItem(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
