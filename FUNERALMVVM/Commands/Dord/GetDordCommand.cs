using BossInstruments;
using ClassLibrary;
using Domain.Dord;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Storage;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace FUNERALMVVM.Commands.Dord
{
    public class GetDordCommand : BaseCommands
    {
        private readonly DORDController _dORDController;

        public GetDordCommand(DORDController dORDController)
        {
            _dORDController = dORDController;
        }

        public override void Execute(object parameter)
        {

            if (Directory.Exists(ConfigurationManager.AppSettings["ProgramWorkspaceDord"]))
            {
                Directory.Delete(ConfigurationManager.AppSettings["ProgramWorkspaceDord"], true);
                Directory.CreateDirectory(ConfigurationManager.AppSettings["ProgramWorkspaceDord"]);
            }

            var pickManager = new PickManager();

            var bossFolder = _dORDController.LinkToFolder;
            var dordFile = pickManager.OpenManagerFileNameDord();

            if (dordFile == string.Empty)
            {
                _dORDController.LinkToFolder = "Укажите ссылку на dord файл";
                return;
            }
            try
            {
                FinalOrderManager.GetDord(bossFolder, dordFile);
                List<StorageItemEntity> items = FinalOrderManager.GetJsonItems();
                List<StateEntity> orders = FinalOrderManager.GetJsonOrders();
                List<StorageItemEntity> orderItems = new();

                foreach (StateEntity item in orders)
                {
                    OrderDord orderDord = new OrderDord()
                    {
                        CategoryFuneral = item.Order.Base.CategoryFuneral,
                        ModelFuneral = item.Order.Base.ModelFuneral,
                        Rock = item.Order.Base.Rock,
                        Price = item.Order.Price,
                        Prepayment = item.Order.Prepayment,
                        Remainder = item.Order.Remainder,
                    };
                    _dORDController.Order.Add(orderDord);

                    foreach (var itemComplect in item.Complect.Complect)
                    {
                        orderItems.Add(itemComplect);
                    }
                }
                orderItems.AddRange(items);
                _dORDController.Items = new(orderItems);

                var orderMoney = _dORDController.Order.Select(x => x.Price);

                foreach (var item in _dORDController.Items)
                {
                    item.ZakupPrice += item.Price * item.Count;
                }



                //Read the JSON file into a string
                string jsonString = File.ReadAllText(ConfigurationManager.AppSettings["Settings"] + "\\WorkerSettings.json");

                // Deserialize the JSON string to a C# object
                WorkerConfig workerConfig = JsonSerializer.Deserialize<WorkerConfig>(jsonString);

                int itemsMoney = 0;

                foreach (var item in _dORDController.Items)
                {
                    itemsMoney += item.Price / 100 * item.Procent * item.Count;
                }

                foreach (var item in orderMoney)
                {
                    workerConfig.HisMoney += Convert.ToInt32(item);
                    workerConfig.MoneyGet += Convert.ToInt32(item);
                }
                workerConfig.HisMoney += itemsMoney;

                var zakupPrice = _dORDController.Items.Select(x => x.ZakupPrice);
                foreach(var item in zakupPrice)
                {
                    workerConfig.MoneyGet += item;
                }

                //оклад на зп
                workerConfig.HisMoney += Convert.ToInt32(workerConfig.Oklad);

                _dORDController.WorkerEntities.Add(new DordEntity()
                {
                    ManagerName = orders.Select(x => x.ManagerName).First(),
                    Money = workerConfig.MoneyGet.ToString(),
                    Oklad = workerConfig.Oklad,
                    Salary = workerConfig.HisMoney.ToString(),
                });
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }

        }
    }

    public class WorkerConfig
    {
        public int FuneralProcent { get; set; }
        public string Oklad { get; set; }

        public int MoneyGet { get; set; }
        public int HisMoney { get; set; }
    }
}
