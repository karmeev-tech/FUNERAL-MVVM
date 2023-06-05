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

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var result = LastNameDead.Text;
            if (result!="")
            {
                result = result.Substring(0, 1).ToUpper() + result.Remove(0,1);  
            }
            LastNameDead.Text = result;
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            var result = NameDead.Text;
            if (result != "")
            {
                result = result.Substring(0, 1).ToUpper() + result.Remove(0, 1);
            }
            NameDead.Text = result;
        }

        private void ThirdNameDead_LostFocus(object sender, RoutedEventArgs e)
        {
            var result = ThirdNameDead.Text;
            if (result != "")
            {
                result = result.Substring(0, 1).ToUpper() + result.Remove(0, 1);
            }
            ThirdNameDead.Text = result;
        }

        private void tb31_LostFocus(object sender, RoutedEventArgs e)
        {
            var result = tb31.Text;
            if (result != "")
            {
                result = result.Substring(0, 1).ToUpper() + result.Remove(0, 1);
            }
            tb31.Text = result;
        }

        private void tb6_LostFocus(object sender, RoutedEventArgs e)
        {
            var result = tb6.Text;
            if (result != "")
            {
                result = result.Substring(0, 1).ToUpper() + result.Remove(0, 1);
            }
            tb6.Text = result;
        }

        private void tb32_LostFocus(object sender, RoutedEventArgs e)
        {
            var result = tb32.Text;
            if (result != "")
            {
                result = result.Substring(0, 1).ToUpper() + result.Remove(0, 1);
            }
            tb32.Text = result;
        }
    }
}
