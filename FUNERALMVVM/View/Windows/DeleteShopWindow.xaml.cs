using FUNERALMVVM.ViewModel;
using FUNERALMVVM.ViewModel.Shop;
using System.Windows;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Interaction logic for DeleteShopWindow.xaml
    /// </summary>
    public partial class DeleteShopWindow : Window
    {
        private HeadStorageController _headStorageController;
        private DeleteShopController _deleteShopController;
        public DeleteShopWindow(HeadStorageController headStorageController)
        {
            _headStorageController = headStorageController;
            _deleteShopController = new(_headStorageController);
            DataContext = _deleteShopController;
            InitializeComponent();
        }
    }
}
