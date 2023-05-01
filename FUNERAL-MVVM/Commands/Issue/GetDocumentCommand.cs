using ClassLibrary;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System.Security.Policy;

namespace FUNERALMVVM.Commands.Issue
{
    public class GetDocumentCommand : BaseCommands
    {
        private readonly IssueController _controller;
        private readonly int _modifier;
        public GetDocumentCommand(IssueController context, int modifier)
        {
            _controller = context;
            _modifier = modifier;
        }

        public override void Execute(object parameter)
        {
            if( _modifier == 1 )
            {
                PickManager pickManager = new();
                _controller._scanLink = pickManager.OpenManagerFileName(_modifier);
            }
            else
            {
                PickManager pickManager = new();
                _controller._dockLink = pickManager.OpenManagerFileName(_modifier);
            }
        }
    }
}
