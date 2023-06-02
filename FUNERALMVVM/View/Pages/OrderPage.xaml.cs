using FUNERALMVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderController _orderController;
        public OrderPage()
        {
            _orderController = new OrderController(this);
            DataContext = _orderController;
            InitializeComponent();
            FormingButton.Opacity = 0.4;
        }

        private void tb10_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            tb10.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tb13_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void tb12_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                int res = Convert.ToInt32(tb13.Text) - Convert.ToInt32(tb14.Text);
                tb12.Text = res.ToString();
            }
            catch
            {
                MessageBox.Show("Не верные значения цены");
            }
            tb12.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void tb14_GotFocus(object sender, RoutedEventArgs e)
        {
            tb14.Foreground = new SolidColorBrush(Colors.Black);
            tb14.Text = "";
        }

        private void tb29_GotFocus(object sender, RoutedEventArgs e)
        {
            tb29.Foreground = new SolidColorBrush(Colors.Black);
            tb29.Text = "";
        }
        private void tb29_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tb29.Text == "")
            {
                MessageBox.Show("Не верные значения цены");
            }
        }
    }
}
