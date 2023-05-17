using BossInstruments;
using ClassLibrary;
using Domain.Dord;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Model.Storage;
using Shop.EF;
using System;
using System.Collections.ObjectModel;

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
            PickManager pickManager = new PickManager();
            _dORDController.LinkToFolder = pickManager.OpenManagerDir();
            if (_dORDController.LinkToFolder == string.Empty)
            {
                _dORDController.LinkToFolder = "Укажите ссылку на папку";
                return;
            }
            pickManager = new PickManager();

            var bossFolder = _dORDController.LinkToFolder;
            var dordFile = pickManager.OpenManagerFileNameDord();
            var result = BossProvider.GetFiles(dordFile, bossFolder);

            foreach (var item in result.iord.ShopItems)
            {
                StorageEntity storageEntity = new();
                storageEntity.Name = ShopConnector.GetUserStorage(result.meta.ManagerName);
                _dORDController.Items.Add(
                    new()
                    {
                        Name = item.Name,
                        Price = item.Price,
                        ZakupPrice = item.Price * item.Count,
                        Count = item.Count,
                        Procent = item.Procent,
                        ShopName = storageEntity
                    }) ;
            }

            foreach (var item in result.ord)
            {
                _dORDController.Order.Add(new()
                {
                    CategoryFuneral = item.Order.Base.CategoryFuneral,
                    ModelFuneral = item.Order.Base.ModelFuneral,
                    Rock = item.Order.Base.Rock,
                    Looks = item.Order.Base.Looks,
                    Price = item.Order.Price,
                    Prepayment = item.Order.Prepayment,
                    Remainder = item.Order.Remainder,
                });
            }
            int salary = SalaryCount(_dORDController.Items, _dORDController.Order);
            int money = MoneyCount(_dORDController.Items, _dORDController.Order);
            _dORDController.WorkerEntities.Add(new()
            {
                ManagerName = result.meta.ManagerName,
                EndWorkTime = result.meta.EndWorkTime,
                StartWorkTime = result.meta.StartWorkTime,
                Money = money.ToString(),
                Salary = salary.ToString(),
                Oklad = "1000",
            });
        }

        private int SalaryCount(ObservableCollection<StorageItemEntity> items,
            ObservableCollection<OrderDord> order)
        {
            int money = 0;
            foreach (var item in items)
            {
                money += item.Price / 100 * item.Procent;
            }
            foreach (var item in order)
            {
                //30 процентов тут это чистый хардкод
                money += Convert.ToInt32(item.Price) / 100 * 30;
            }
            //тут ещё плюсуем оклад
            return money + 1000;
        }

        private int MoneyCount(ObservableCollection<StorageItemEntity> items,
            ObservableCollection<OrderDord> order)
        {
            int money = 0;
            foreach (var item in items)
            {
                money += item.Price;
            }
            foreach (var item in order)
            {
                money += Convert.ToInt32(item.Price);
            }

            return money;
        }
    }
}
