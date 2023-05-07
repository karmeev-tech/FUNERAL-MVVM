using Domain.Complect;
using Domain.Services.Entity;
using FUNERALMVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FuneralClient.View.Windows
{
    /// <summary>
    /// Interaction logic for ServicesWindow.xaml
    /// </summary>
    public partial class ServicesWindow : Window
    {
        private readonly ServicesController _servicesController;
        public ServicesWindow()
        {
            _servicesController = new(this);
            DataContext = _servicesController;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service dataRowView = (Service)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                _servicesController.DeleteItem(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
