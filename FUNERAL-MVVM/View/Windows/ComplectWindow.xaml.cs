using Domain.Complect;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Storage;
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
        private readonly ComplectController _complectController;
        public KomplektWindow()
        {
            _complectController = new ComplectController(this);
            DataContext = _complectController;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemComplectEntity dataRowView = (ItemComplectEntity)((Button)e.Source).DataContext;
                string name = dataRowView.Name;
                _complectController.DeleteItem(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
