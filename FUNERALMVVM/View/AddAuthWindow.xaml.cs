using FUNERALMVVM.ViewModel;
using System.Windows;

namespace FUNERALMVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddAuthWindow.xaml
    /// </summary>
    public partial class AddAuthWindow : Window
    {
        public AddAuthWindow()
        {
            DataContext = new RegistrationController();
            InitializeComponent();
        }
    }
}
