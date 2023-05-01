using FUNERALMVVM.ViewModel;
using System.Windows;

namespace FUNERALMVVM.View.Windows
{
    /// <summary>
    /// Interaction logic for KomplektWindow.xaml
    /// </summary>
    public partial class KomplektWindow : Window
    {
        public KomplektWindow()
        {
            DataContext = new ComplectController(this);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if(this.ErrorResponse.Content != "Ошибка")
            //{
            //    Opacity = 0;
            //    this.Close();
            //}
        }
    }
}
