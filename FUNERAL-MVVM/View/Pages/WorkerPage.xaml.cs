using FUNERALMVVM.ViewModel;
using Infrastructure.Worker;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        private readonly WorkerController _workerController = new(new WorkerRepos());
        public WorkerPage()
        {
            DataContext = _workerController;
            InitializeComponent();
        }
    }
}
