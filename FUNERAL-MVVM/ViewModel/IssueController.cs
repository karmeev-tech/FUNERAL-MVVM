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
        /// Какой конкретно товар (могилка)
        /// Сколько таких могилок (изменения вносятся в другом месте, тут смотрим чисто в скане)
        /// Кто продал
        /// Предоплата
        /// Оплата
        /// 
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
        public ICommand GetDock => new GetDocumentCommand(this,2);
        public ICommand GetScan => new GetDocumentCommand(this,1);
        public ICommand Send => new SendIssueCommand(this, new WorkerRepos());

        public string _scanLink = string.Empty;
        public string _dockLink = string.Empty;
    }
}
