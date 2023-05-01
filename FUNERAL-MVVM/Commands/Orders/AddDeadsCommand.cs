using FUNERAL_MVVM.Utility;
using FUNERALMVVM.View.Windows;
using System;

namespace FUNERALMVVM.Commands.Orders
{
    public class AddDeadsCommand : BaseCommands
    {
        public override void Execute(object parameter)
        {
            DeadbodyWindow window = new();
            window.Show();
        }
    }
}
