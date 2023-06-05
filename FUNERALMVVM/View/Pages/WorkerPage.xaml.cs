using FUNERALMVVM.View.Windows;
using FUNERALMVVM.ViewModel.Workers;
using System.Windows.Controls;

namespace FUNERALMVVM.View.Pages
{
    /// <summary>
    /// Interaction logic for WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        private readonly WorkerController _workerController = new();
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

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            ConfigBoss.Head.MakeGeneralConfigFile();
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            ConfigBoss.Head.Upload();
        }

        private void UploadOrder(object sender, System.Windows.RoutedEventArgs e)
        {
            AddInventWindow deleteWorkersWindow = new AddInventWindow();
            deleteWorkersWindow.Show();
        }

        private void Button_Click_3(object sender, System.Windows.RoutedEventArgs e)
        {
            EditWorkersWindow editWorkersWindow = new EditWorkersWindow();
            editWorkersWindow.Show();
        }
    }
}
