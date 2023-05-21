using Domain.Complect;
using FUNERAL_MVVM.Utility;
using FuneralClient.Commands.Complect;
using FUNERALMVVM.View.Pages;
using FUNERALMVVM.View.Windows;
using Infrastructure.Model.Storage;
using LegacyInfrastructure.Complect;
using LegacyInfrastructure.Worker;
using Shop.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FUNERALMVVM.ViewModel
{
    public class ComplectController : ViewModelBase
    {
        private KomplektWindow _komplektWindow;

        private readonly ShopConnector _shopConnector = new();

        private ObservableCollection<string> _itemFromComplect = new();
        public List<StorageItemEntity> ComplectStorage { get; set; }
        private OrderPage _orderPage;
        public ObservableCollection<string> ItemFromComplect 
        { 
            get => _itemFromComplect;
            set
            {
                _itemFromComplect = value;
                OnPropertyChanged(nameof(ItemFromComplect));
            } 
        }

        private ObservableCollection<StorageItemEntity> _items = new();
        public ObservableCollection<StorageItemEntity> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public string SelectItem { get; set; }

        public ComplectController(KomplektWindow complectWindow, OrderPage orderPage)
        {
            _komplektWindow = complectWindow;
            var user = new WorkerRepos().GetLastFromJournal();
            var shop = ShopConnector.GetUserStorage(user);
            var items = ShopConnector.GetStorageItems(shop);
            ComplectStorage = items;

            foreach (var item in items)
            {
                _itemFromComplect.Add(item.Name);
            }
            _orderPage = orderPage;
        }

        public ICommand AddComplectCommand => new AddComplectCommand(this);
        public ICommand AddItemCommand => new AddItemCommand(this);

        private string _response = string.Empty;
        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                if (Response != "Ошибка")
                {
                    ViewClosed();
                }

                OnPropertyChanged(Response);
            }
        }

        private void ViewClosed()
        {
            var price = 0;
            foreach (var item in Items)
            {
                price += item.Price * item.Count;
            }
            var result = Convert.ToInt32(_orderPage.tb13.Text) + price;
            _komplektWindow._orderPage._orderController.FuneralPrice = result;
            _orderPage.tb13.Text = result.ToString();
            _komplektWindow.Opacity = 0;
            _komplektWindow.Close();
        }

        public void DeleteItem(string itemName, int count)
        {
            var newItems = Items.Where(x => x.Name == itemName && x.Count == count).Last();
            Items.Remove(newItems);
        }
    }
}
