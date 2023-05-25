using BossInstruments;
using Domain.Dord;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Dord;
using Infrastructure.Model.Salary;
using Infrastructure.Model.Storage;
using IssueProvider;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class DORDController : ViewModelBase
    {
        private string _linkToFolder = string.Empty;
        private ObservableCollection<StorageItemEntity> _items = new();
        private ObservableCollection<DordEntity> _workerEntities = new();
        private ObservableCollection<OrderDord> _order = new();
        private string _response = string.Empty;
        private ObservableCollection<SalaryEntity> _issues;

        public DORDController()
        {
            Issues = new ObservableCollection<SalaryEntity>(IssueCenter.GetAllFromDB());
        }

        public ObservableCollection<DordEntity> WorkerEntities
        {
            get => _workerEntities;
            set
            {
                _workerEntities = value;
                OnPropertyChanged(nameof(WorkerEntities));
            }
        }
        public ObservableCollection<StorageItemEntity> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        public ObservableCollection<OrderDord> Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        public ObservableCollection<SalaryEntity> Issues
        {
            get => _issues;
            set { _issues = value; OnPropertyChanged(nameof(Issues)); }
        }

        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
            }
        }
        public string LinkToFolder
        {
            get => _linkToFolder;
            set
            {
                _linkToFolder = value;
                OnPropertyChanged(nameof(LinkToFolder));
            }
        }
        public ICommand GetDord => new GetDordCommand(this);
        public ICommand GetOrder => new GetUserOrder(this);

        public string ShopName { get; set; } = string.Empty;
        public void DeleteItem(string itemName)
        {
            var item = Items.Where(x => x.Name == itemName).ToList().Last();
            Items.Remove(item);
        }

        public void DeleteDord(string itemName)
        {
            var newItems = WorkerEntities.Where(x => x.ManagerName == itemName)
                                         .Last();
            WorkerEntities.Remove(newItems);
        }

        public void DeleteOrder(string itemName)
        {
            var newItems = Order.Where(x => x.ModelFuneral == itemName).Last();
            Order.Remove(newItems);
        }
    }

    public class GetUserOrder : BaseCommands
    {
        private readonly DORDController _dORDController;

        public GetUserOrder(DORDController dORDController)
        {
            _dORDController = dORDController;
        }

        public override void Execute(object parameter)
        {
            try
            {
                DordMetaFormalizer.UpdateWithDord(
                _dORDController.WorkerEntities.ToList(),
                _dORDController.Items.ToList(),
                //_dORDController.Order.ToList(),
                _dORDController.Issues.ToList()
                );

                _dORDController.Response = "Принято";
            }
            catch
            {
                _dORDController.Response = "Ошибка";
            }
        }
    }
}
