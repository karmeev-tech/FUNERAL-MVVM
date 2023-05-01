using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using Infrastructure.Storage;
using Model.Storage;
using System;
using System.Threading.Tasks;

namespace FUNERALMVVM.Commands.Storage
{
    internal class AddItemCommand : BaseCommands
    {
        public AddItemCommand(StorageController storageController)
        {
            StorageController = storageController;
        }

        public StorageController StorageController { get; }

        public override void Execute(object parameter)
        {
            try
            {
                var price = Convert.ToInt32(StorageController.Price);
                var zakupPrice = Convert.ToInt32(StorageController.ZakupPrice);
                if (price > 0)
                {
                    if (NameTypeCheck(StorageController.Name, StorageController.Type) != "bad")
                    {
                        StorageController.Error = "";
                        AddItem(new ShopItem() { 
                            Name = StorageController.Name, 
                            Price = price, 
                            Type = StorageController.Type,
                            ZakupPrice = zakupPrice,
                            OForm = StorageController.OForm,
                            TForm = StorageController.TForm,
                            GForm = StorageController.GForm,
                            Margin = StorageController.Margin,
                            Color = StorageController.Color,
                            Polishing = StorageController.Polishing,
                            Other = StorageController.Other
                        });
                    }
                    else
                    {
                        StorageController.Error = "Ошибка. Проверьте название(без пробелов в начале)";
                    }
                }
                else
                {
                    StorageController.Error = "Ошибка. Проверьте цену (не может быть нулём)";
                }
            }
            catch(Exception) 
            {
                StorageController.Error = "Цена указана с ошибкой. Введите число (в рублях; без указания валюты)";
            }
        }

        public async void AddItem(ShopItem item)
        {
            await Task.Run(() =>
            {
                ItemManager itemManager = new(item, new ShopRepos());
                if(itemManager.IdentityCheck() == "Уже существует")
                {
                    StorageController.Error = "Данный товар/услуга уже есть";
                }
                else
                {
                    var result = itemManager.AddItemToDB();
                    if(result == "bad")
                    {
                        StorageController.Error = "Ошибка выбора изображения";
                    }
                }
            });
        }
        private static string NameTypeCheck(string name, string type)
        {
            if(name == null || type == null)
            {
                return "bad";
            }
            if(name == "" || type == "")
            { 
                return "bad";
            }
            if (name[0] == Convert.ToChar(" ") || type[0] == Convert.ToChar(" "))
            {
                return "bad";
            }
            return "good";
        }
    }
}
