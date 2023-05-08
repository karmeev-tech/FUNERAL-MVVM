using Domain.Complect;
using Domain.Order;
using Domain.Services.Entity;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using LegacyInfrastructure.Order;
using OrderManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FUNERALMVVM.Commands.Orders
{
    public class AddOrderCommand : BaseCommands
    {
        private readonly OrderController _orderController;

        public AddOrderCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            DateTime dateTime = DateTime.Now;
            OrderEntity orderEntity = new()
            {
                Base = new Domain.Order.Config.FuneralBaseEntity()
                {
                    CategoryFuneral = _orderController.FuneralCategory,
                    ModelFuneral = _orderController.FuneralModel,
                    Rock = _orderController.FuneralRock,
                    Looks = _orderController.Looks
                },
                Stela = new Domain.Order.Stela.StelaEntity()
                {
                    Section = _orderController.StelaSection,
                    Size = _orderController.StelaSize,
                },
                Stand = new Domain.Order.Config.StandEntity()
                {
                    Size = _orderController.StandSize,
                    Section = _orderController.StandSection,
                },
                Flowershed = new Domain.Order.Config.FlowershedEntity()
                {
                    Size = _orderController.FlowerSize,
                    Section = _orderController.FlowerSection,
                    NoInstal = _orderController.FlowerIndicate
                },
                Polishing = _orderController.PolishingColor,
                Deadass = _orderController.Deadbody,
                DeadassCount = _orderController._deadboydCount,
                Instal = new Domain.Order.Config.InstalEntity()
                {
                    Idicate = _orderController.InstalIndicate,
                    InstalPrice = _orderController.InstalPrice,
                },
                Funeral = new Domain.Order.Config.FuneralEntity()
                {
                    Size = _orderController.FuneralSize,
                    UpPart = _orderController.UpDesign,
                    DownPart = _orderController.DownDesign,
                    Other = _orderController.OtherDesign,
                    Epitafia = _orderController.Epitafia,
                },
                ClientOrder = new Domain.Order.Config.ClientOrderEntity()
                {
                    FIO = _orderController.ClientFIO,
                    Adress = _orderController.ClientAdress,
                    Passport = _orderController.ClientPassport,
                    Phone = _orderController.ClientNumber,
                    Cemetry = _orderController.ClientFuneral,
                    Telegram = _orderController.ClientSocial
                },
                Price = _orderController.Price,
                Prepayment = _orderController.Prepayment,
                Remainder = _orderController.Remainder,
            };
            string fileName = ".docs\\json\\OrderDoc.json";
            AddJson(orderEntity, fileName);
            AddDocs();
        }
        public async void AddDocs()
        {
            await Task.Run(() =>
            {
                Provider prod = new();
                Provider.CreateOrder();
            });
        }

        public async void AddJson(OrderEntity order, string fileName)
        {
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, order, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await createStream.DisposeAsync();
        }
    }
}
