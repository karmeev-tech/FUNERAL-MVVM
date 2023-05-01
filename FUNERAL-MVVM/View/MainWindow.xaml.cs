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
        public MainWindow()
        {
            DataContext = new AuthenticationController(this);
            InitializeComponent();
        }

        // TODO: поправить событие срабатывания
        private void Page_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //OnNextPage();
        }
    }
}
