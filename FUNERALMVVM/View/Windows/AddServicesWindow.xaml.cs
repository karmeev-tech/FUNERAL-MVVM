using FUNERALMVVM.ViewModel.Shop;
using Infrastructure.Model.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddServicesWindow.xaml
    /// </summary>
    public partial class AddServicesWindow : Window
    {
        public ServicesManagmentVM _vm = new();
        public AddServicesWindow()
        {
            DataContext = _vm;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceEntity dataRowView = (ServiceEntity)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                string param = dataRowView.Param1;
                _vm.DeleteServ(name + param);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
