using FUNERALMVVM.ViewModel;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly UsersController _usersController = new();
        public MainPage()
        {
            DataContext = _usersController;
            // u must call @checking user for adding data@
            InitializeComponent();
        }
    }
}
