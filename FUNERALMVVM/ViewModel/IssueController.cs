using ClassLibrary;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Issue;
using LegacyInfrastructure.Worker;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class IssueController : ViewModelBase
    {
        /// <summary>
        /// Состав ордера:
        /// Какой конкретно товар
        /// Сколько товара
        /// Кто продал
        /// Предоплата
        /// Оплата
        /// </summary>
        public string Payment { get; set; } = string.Empty;
        public string Prepayment { get; set; } = string.Empty;

        private string _response = string.Empty;
        public string Response 
        { 
            get => _response;
            set 
            {
                _response = value;
                OnPropertyChanged(nameof(Response));
            } 
        }
        public ICommand GetDock => new GetDocumentCommand(this);
        public ICommand GetDock2 => new GetSecondDocumentCommand(this);
        public ICommand GetScan => new GetScanCommand(this);
        public ICommand GetOrd => new GetOrdCommand(this);
        public ICommand Send => new SendIssueCommand(this, new WorkerRepos());

        public string _scanLink = string.Empty;
        public string _dockLink = string.Empty;
        public string _dock2Link = string.Empty;
        public string _ord = string.Empty;
    }

    #region Docs & Scan
    public class GetDocumentCommand : BaseCommands
    {
        private readonly IssueController _controller;
        public GetDocumentCommand(IssueController context)
        {
            _controller = context;
        }

        public override void Execute(object parameter)
        {
            PickManager pickManager = new();
            _controller._dockLink = pickManager.OpenManagerFileName();
        }
    }
    public class GetSecondDocumentCommand : BaseCommands
    {
        private readonly IssueController _controller;
        public GetSecondDocumentCommand(IssueController context)
        {
            _controller = context;
        }

        public override void Execute(object parameter)
        {
            PickManager pickManager = new();
            _controller._dock2Link = pickManager.OpenManagerFileName();
        }
    }
    public class GetScanCommand : BaseCommands
    {
        private readonly IssueController _controller;
        public GetScanCommand(IssueController context)
        {
            _controller = context;
        }

        public override void Execute(object parameter)
        {
            PickManager pickManager = new();
            _controller._scanLink = pickManager.OpenManagerFileName();
        }
    }
    public class GetOrdCommand : BaseCommands
    {
        private readonly IssueController _controller;
        public GetOrdCommand(IssueController context)
        {
            _controller = context;
        }

        public override void Execute(object parameter)
        {
            PickManager pickManager = new();
            _controller._ord = pickManager.OpenManagerFileNameOrd();
        }
    }
    #endregion
}
