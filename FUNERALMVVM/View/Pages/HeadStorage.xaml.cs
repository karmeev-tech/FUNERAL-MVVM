using FUNERALMVVM.ViewModel;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for HeadStorage.xaml
    /// </summary>
    public partial class HeadStorage : Page
    {
        public HeadStorage()
        {
            DataContext = new HeadStorageController();
            InitializeComponent();
        }
    }
}
