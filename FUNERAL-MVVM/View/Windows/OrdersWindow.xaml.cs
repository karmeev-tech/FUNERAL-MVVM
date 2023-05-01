using FUNERALMVVM.ViewModel;
using System.Windows;
namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            DataContext = new ServicesController(this);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Opacity = 0;
            //this.Close();
        }
    }
}
