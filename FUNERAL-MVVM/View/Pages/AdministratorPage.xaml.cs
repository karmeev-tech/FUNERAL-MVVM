using FUNERALMVVM.ViewModel;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        private readonly UsersController _usersController = new();
        public AdministratorPage()
        {
            DataContext = _usersController;
            InitializeComponent();
        }
    }
}
