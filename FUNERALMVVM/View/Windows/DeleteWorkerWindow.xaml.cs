using FUNERALMVVM.ViewModel.Workers;
using System.Windows;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Interaction logic for DeleteWorkerWindow.xaml
    /// </summary>
    public partial class DeleteWorkerWindow : Window
    {
        public DeleteWorkerWindow()
        {
            DataContext = new DeleteWorkersVM(this);
            InitializeComponent();
        }
    }
}
