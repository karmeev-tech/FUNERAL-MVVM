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

        private void Grid_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tb1.Text == string.Empty || tb2.Text == string.Empty || tb3.Text == string.Empty ||
            tb4.Text == string.Empty || tb5.Text == string.Empty || tb6.Text == string.Empty ||
            tb7.Text == string.Empty || tb8.Text == string.Empty || tb9.Text == string.Empty ||
            tb10.Text == string.Empty || tb11.Text == string.Empty || tb12.Text == string.Empty ||
            tb13.Text == string.Empty || tb14.Text == string.Empty || tb15.Text == string.Empty ||
            tb16.Text == string.Empty || tb17.Text == string.Empty || tb18.Text == string.Empty ||
            tb19.Text == string.Empty || tb20.Text == string.Empty || tb21.Text == string.Empty ||
            tb24.Text == string.Empty || tb30.Text == string.Empty || tb31.Text == string.Empty || tb32.Text == string.Empty ||
            tb25.Text == string.Empty || tb26.Text == string.Empty || tb28.Text == string.Empty)
            {
                FormingButton.Opacity = 0.4;
                FormingButton.IsEnabled = false;
            }
            else
            {
                int counter = 0;
                if (tb22.Text != string.Empty)
                {
                    counter++;
                }
                else
                {
                    if (tb121.IsChecked != false)
                    {
                        counter++;
                    }
                }

                if (tb27.Text != string.Empty)
                {
                    counter++;
                }
                else
                {
                    if (tb122.IsChecked != false)
                    {
                        counter++;
                    }
                }

                if (counter != 2)
                {
                    FormingButton.Opacity = 0.4;
                    FormingButton.IsEnabled = false;
                }
                else
                {
                    FormingButton.Opacity = 10;
                    FormingButton.IsEnabled = true;
                }
            }
        }

        private void tb10_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            tb10.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tb13_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            tb13.Foreground = new SolidColorBrush(Colors.Black);
            if (tb13.Text.Contains("+"))
            {
                var sign = tb13.Text.IndexOf("+");
                var first = tb13.Text.Substring(0, sign);
                var second = tb13.Text.Substring(sign + 1);
                var result = Convert.ToInt32(first) + Convert.ToInt32(second);
                tb13.Text = result.ToString();
            }
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
    }
}
