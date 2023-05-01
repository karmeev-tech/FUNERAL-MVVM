using FUNERALMVVM.ViewModel;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для StoragePage.xaml
    /// </summary>
    public partial class StoragePage : Page
    {
        public StoragePage()
        {
            DataContext = new StorageController();
            InitializeComponent();
        }
    }
}
