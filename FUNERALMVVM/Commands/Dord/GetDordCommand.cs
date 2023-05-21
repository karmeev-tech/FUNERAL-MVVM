using BossInstruments;
using ClassLibrary;
using Domain.Dord;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.ComplexMongo;
using Infrastructure.Model.Storage;
using MongoDB.Driver.Linq;
using Shop.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            var pickManager = new PickManager();

            var bossFolder = _dORDController.LinkToFolder;
            var dordFile = pickManager.OpenManagerFileNameDord();

            if(dordFile == string.Empty )
            {
                _dORDController.LinkToFolder = "Укажите ссылку на dord файл";
                return;
            }

            FinalOrderManager.GetDord(bossFolder, dordFile);
            List<StorageItemEntity> items = FinalOrderManager.GetJsonItems();
            List<StateEntity> orders = FinalOrderManager.GetJsonOrders();

            foreach(StateEntity item in orders)
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
            }

            _dORDController.Items = new(items);

            // zp
            int money = 0;
            int allMoney = 0;
            var orderMoney = _dORDController.Order.Select(x => x.Price);

            foreach (var item in _dORDController.Items)
            {
                item.ZakupPrice = item.Price * item.Count;
            }
            //_dORDController.Items = new(sie);
            var itemsMoney = _dORDController.Items.Select(x => x.Price / 100 * x.Procent * x.Count);

            foreach(var item in orderMoney)
            {
                money += Convert.ToInt32(item);
                allMoney += Convert.ToInt32(item);
            }
            foreach (var item in itemsMoney)
            {
                money += item;
            }

            itemsMoney = _dORDController.Items.Select(x => x.ZakupPrice);
            foreach (var item in itemsMoney)
            {
                allMoney += item;
            }

            //оклад на зп
            money += 1000;

            _dORDController.WorkerEntities.Add(new DordEntity()
            {
                ManagerName = orders.Select(x => x.ManagerName).First(),
                Money = allMoney.ToString(),
                Oklad = "1000",
                Salary = money.ToString(),
            });
        }
    }
}
