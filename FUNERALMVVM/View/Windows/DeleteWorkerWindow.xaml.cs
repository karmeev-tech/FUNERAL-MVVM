using FUNERALMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
