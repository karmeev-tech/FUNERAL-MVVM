using FUNERAL_MVVM.Utility;
using FUNERALMVVM.Commands.Orders;
using FUNERALMVVM.Commands.Services;
using FUNERALMVVM.View.Windows;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class DeadbodyController : ViewModelBase
    {
        private readonly DeadbodyWindow _window;

        public DeadbodyController(DeadbodyWindow window)
        {
            _window = window;
        }

        public string DeadFIO { get; set; } = string.Empty;
        public string DeadBirth{ get; set; } = string.Empty;
        public string DeadDie { get; set; } = string.Empty;

        public string DeadFIO2 { get; set; } = string.Empty;
        public string DeadBirth2 { get; set; } = string.Empty;
        public string DeadDie2 { get; set; } = string.Empty;

        public string DeadFIO3 { get; set; } = string.Empty;
        public string DeadBirth3 { get; set; } = string.Empty;
        public string DeadDie3 { get; set; } = string.Empty;

        public string DeadFIO4 { get; set; } = string.Empty;
        public string DeadBirth4 { get; set; } = string.Empty;
        public string DeadDie4 { get; set; } = string.Empty;

        public ICommand AddDead => new AddDeadCommand(this);

        public void ViewClosed()
        {
            _window.Opacity = 0;
            _window.Close();
        }
    }
}
