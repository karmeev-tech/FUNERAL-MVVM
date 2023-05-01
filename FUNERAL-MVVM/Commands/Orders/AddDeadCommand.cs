using Domain.Order;
using Domain.Services;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System.IO;
using System.Text.Json;

namespace FUNERALMVVM.Commands.Orders
{
    public class AddDeadCommand : BaseCommands
    {
        private readonly DeadbodyController _controller;

        public AddDeadCommand(DeadbodyController controller)
        {
            _controller = controller;
        }

        public override void Execute(object parameter)
        {
            File.Delete(".docs\\deadbody1.json");
            File.Delete(".docs\\deadbody2.json");
            File.Delete(".docs\\deadbody3.json");
            File.Delete(".docs\\deadbody4.json");

            SendEntities(_controller.DeadFIO, _controller.DeadBirth, _controller.DeadDie, 1.ToString());
            SendEntities(_controller.DeadFIO2, _controller.DeadBirth2, _controller.DeadDie2, 2.ToString());
            SendEntities(_controller.DeadFIO3, _controller.DeadBirth3, _controller.DeadDie3, 3.ToString());
            SendEntities(_controller.DeadFIO4, _controller.DeadBirth4, _controller.DeadDie4, 4.ToString());
            _controller.ViewClosed();
        }

        private void SendEntities(string FIO, string birth, string die,string number)
        {
            var result = new DeadEntity()
            {
                DeadFIO = FIO,
                DeadBirth = birth,
                DeadDie = die
            };
            AddDocument(result, ".docs\\deadbody"+number+".json");
        }

        public async void AddDocument(DeadEntity serv, string fileName)
        {
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, serv, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await createStream.DisposeAsync();
        }
    }
}
