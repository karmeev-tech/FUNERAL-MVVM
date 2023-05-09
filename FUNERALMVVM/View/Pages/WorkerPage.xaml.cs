using FUNERALMVVM.View.Windows;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Worker;
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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddWorkersWindow addWorkersWindow = new AddWorkersWindow();
            addWorkersWindow.Show();
        }

        private void Button_Click2(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteWorkerWindow deleteWorkersWindow = new DeleteWorkerWindow();
            deleteWorkersWindow.Show();
        }
    }
}
