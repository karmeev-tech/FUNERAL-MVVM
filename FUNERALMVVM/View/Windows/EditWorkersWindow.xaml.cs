using FUNERALMVVM.ViewModel.Workers;
using System.Windows;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWorkersWindow.xaml
    /// </summary>
    public partial class EditWorkersWindow : Window
    {
        public EditWorkersWindow()
        {
            DataContext = new EditWorkersVM(this);
            InitializeComponent();
        }
    }
}
