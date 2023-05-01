using Domain.Services;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System;
using System.IO;
using System.Text.Json;

namespace FUNERALMVVM.Commands.Services
{
    public class AddServCommand : BaseCommands
    {
        private ServicesController _complectController;

        public AddServCommand(ServicesController servicesController)
        {
            _complectController = servicesController;
        }

        public override void Execute(object parameter)
        {
            int money = 0;
            try
            {
                money =
                    Convert.ToInt32(_complectController.s1) + Convert.ToInt32(_complectController.s2) +
                    Convert.ToInt32(value: _complectController.s4) + Convert.ToInt32(_complectController.s5) +
                    Convert.ToInt32(_complectController.s6) + Convert.ToInt32(_complectController.s7) +
                    Convert.ToInt32(_complectController.s8) + Convert.ToInt32(_complectController.s9) +
                    Convert.ToInt32(_complectController.s10) + Convert.ToInt32(_complectController.s11) +
                    Convert.ToInt32(_complectController.s12) + Convert.ToInt32(_complectController.s15) +
                    Convert.ToInt32(_complectController.s16) + Convert.ToInt32(_complectController.s17);
            }
            catch(Exception)
            {
                _complectController.Exception = "Ошибка";
            }

            string plitka = string.Empty;
            if(_complectController.Plitka != string.Empty)
            {
                plitka = _complectController.Plitka;
            }
            else
            {
                plitka = _complectController.PlitkaOther;
            }

            var serv = new ServiceList()
            {
                Cokol = Counter("Цоколь из блоков гранит габро-диабаз (Карелия) цвет черный " + _complectController.s1 + " руб\n", _complectController.s1),
                Found = Counter("Дополнительный фундамент под памятники " + _complectController.s2 + " руб\n", _complectController.s2),
                Bord = Counter("Бордюр " + _complectController.Bord + " " + _complectController.s4 + " руб\n", _complectController.s4),
                Plitka = Counter("Плитка" + _complectController.Plitka + " Размеры: " + plitka + " " + _complectController.s5 + " руб\n", _complectController.s5),
                Funeral = Counter(_complectController.Funeral + " памятника " + " " + _complectController.s6 + " руб\n", _complectController.s6),
                Ograda = Counter(_complectController.Fences + " ограды " + " " + _complectController.s7 + " руб\n", _complectController.s7),
                Lavochka = Counter(_complectController.Tables + " лавочки и стола " + " " + _complectController.s8 + " руб\n", _complectController.s8),
                Svarka = Counter("Сварные работы + покраска " + _complectController.s9 + " руб\n", _complectController.s9),
                Paroizol = Counter("Пароизол " + _complectController.s10 + " руб\n", _complectController.s10),
                Sand = Counter("Песок " + _complectController.s11 + " руб\n", _complectController.s11),
                Grunt = Counter("Грунт " + _complectController.s12 + " руб\n", _complectController.s12),
                Granit = Counter("Гранитная щебень " + _complectController.s15 + " руб\n", _complectController.s15),
                Oformlenie = Counter("Памятник комплект +оформление " + _complectController.s16 + " руб\n", _complectController.s16),
                Stolb = Counter("Столб " + _complectController.s17 + " руб\n", _complectController.s17),
                Money = money
            };

            string fileName = ".docs\\ServDoc.json";
            AddDocument(serv, fileName);
        }
        public async void AddDocument(ServiceList serv, string fileName)
        {
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, serv, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            await createStream.DisposeAsync();
        }

        private static string Counter(string final, string money)
        {
            try
            {
                if (Convert.ToInt32(money) > 0)
                {
                    return final;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
