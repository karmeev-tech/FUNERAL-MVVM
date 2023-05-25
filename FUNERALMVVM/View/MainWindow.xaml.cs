using FUNERALMVVM.ViewModel;
using Infrastructure.Context.Mongo;
using Infrastructure.Mongo;
using MongoDB.Driver;
using System.Windows;

namespace FUNERAL_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AuthenticationController _authentication;
        public readonly IMongoDbContext _context;
        protected IMongoCollection<MongoFuneral> _dbCollectionOrders;
        protected IMongoCollection<MongoItems> _dbCollectionItems;
        public MainWindow()
        {
            InitializeComponent();
            _authentication = new(this);
            DataContext = _authentication;
            textPassword.Password = new("password");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _authentication.Password = textPassword.Password;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
