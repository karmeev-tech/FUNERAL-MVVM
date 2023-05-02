using FUNERALMVVM.View;
using FUNERALMVVM.ViewModel;
using System.Windows;

namespace FUNERAL_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AuthenticationController _authentication;
        public MainWindow()
        {
            _authentication = new(this);
            DataContext = _authentication;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           _authentication.Password = textPassword.Password;
        }
    }
}
