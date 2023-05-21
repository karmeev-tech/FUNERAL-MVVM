using FUNERALMVVM.View;
using FUNERALMVVM.ViewModel;
using System.Diagnostics;
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
            textPassword.Password = new("password");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           _authentication.Password = textPassword.Password;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Process process = new Process();
            //process.StartInfo.FileName = "net.exe";
            //process.StartInfo.Arguments = "stop MongoDB";
            //process.Start();
            Close();
        }
    }
}
