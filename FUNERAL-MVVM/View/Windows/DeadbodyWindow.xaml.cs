using FUNERALMVVM.ViewModel;
using System.Windows;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Interaction logic for DeadbodyWindow.xaml
    /// </summary>
    public partial class DeadbodyWindow : Window
    {
        public DeadbodyWindow()
        {
            DataContext = new DeadbodyController(this);
            InitializeComponent();
        }
    }
}
