using Infrastructure.Mongo;
using System.Windows;

namespace FUNERALMVVM.View
{
    /// <summary>
    /// Interaction logic for WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public WorkWindow()
        {
            InitializeComponent();
            Head.IsChecked = true;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            MongoItems.ConnectAndDeleteAllFiles();
            MongoFuneral.ConnectAndDeleteAllFiles();
        }
    }
}
