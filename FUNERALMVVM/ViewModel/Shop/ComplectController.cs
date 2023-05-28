using FUNERAL_MVVM.Utility;
using FuneralClient.Commands.Complect;
using FUNERALMVVM.View.Pages;
using FUNERALMVVM.View.Windows;
using Infrastructure.Model.Storage;
using Shop.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Worker.EF;

namespace FUNERALMVVM.ViewModel
{
    public class ComplectController : ViewModelBase
    {
        private KomplektWindow _komplektWindow;
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
            var user = WorkerConnector.GetLastLoginWorker().Worker;
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
            _komplektWindow._orderPage._orderController.ComplectPrice = price;

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
