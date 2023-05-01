using FUNERALMVVM.ViewModel;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для IssuePage.xaml
    /// </summary>
    public partial class IssuePage : Page
    {
        public IssuePage()
        {
            DataContext = new IssueController();
            InitializeComponent();
        }
    }
}
