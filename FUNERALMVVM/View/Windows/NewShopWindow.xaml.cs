using FUNERALMVVM.ViewModel;
using System.Windows;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Interaction logic for NewShopWindow.xaml
    /// </summary>
    public partial class NewShopWindow : Window
    {
        private NewShopController _newShopController;
        private HeadStorageController _headStorageController;

        public NewShopWindow(HeadStorageController headStorageController)
        {
            _headStorageController = headStorageController;
            _newShopController = new NewShopController(_headStorageController);
            DataContext = _newShopController;
            InitializeComponent();
        }
    }
}
