using FUNERALMVVM.ViewModel;
using System.Windows;

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
    }
}
