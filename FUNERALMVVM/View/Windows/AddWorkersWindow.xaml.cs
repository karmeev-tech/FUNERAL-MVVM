using FUNERALMVVM.ViewModel;
using FUNERALMVVM.ViewModel.Workers;
using System.Drawing;
using System.Windows;
using System.Windows.Media;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Interaction logic for AddWorkersWindow.xaml
    /// </summary>
    public partial class AddWorkersWindow : Window
    {
        public AddWorkersWindow()
        {
            DataContext = new RegistrationController(this);
            InitializeComponent();
        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tb7.Text!=string.Empty && tb9.Text != string.Empty) 
            {
                AddButton.IsEnabled = true;
            }
        }

        private void tbGotFocus(object sender, RoutedEventArgs e)
        {
            tb1.Foreground = new SolidColorBrush(Colors.Black);
            tb2.Foreground = new SolidColorBrush(Colors.Black);
            tb3.Foreground = new SolidColorBrush(Colors.Black);
            tb4.Foreground = new SolidColorBrush(Colors.Black);
            tb5.Foreground = new SolidColorBrush(Colors.Black);
            tb8.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
