using Domain.Services;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System;
using System.IO;
using System.Text.Json;

namespace FUNERALMVVM.Commands.Services
{
    public class AddComplectCommand : BaseCommands
    {
        private readonly ComplectController _complectController;

        public AddComplectCommand(ComplectController servicesController)
        {
            _complectController = servicesController;
        }

        public override void Execute(object parameter)
        {
            try
            {
                string floralSection;
                if(_complectController.FloralSectionOptional != string.Empty)
                {
                    floralSection = _complectController.FloralSectionOptional;
                }
                else
                {
                    floralSection = _complectController.FloralSection;
                }

                var complectList = new ComplectList
                {
                    Stela = Counter("Стела " + "Размер: " + _complectController.StelaSize + " Сечение:" + _complectController.StelaSection + " " + _complectController.s1 + " руб.\n",
                    _complectController.s1),
                    Podstavka = Counter("Подставка " + "Размер: " + _complectController.StandSize + " Сечение:" + _complectController.StelaSection + " " + _complectController.s2 + " руб.\n", _complectController.s2),
                    Cvetnik = Counter("Цветник " + "Размер: " + _complectController.FloralSize + " Сечение: " + floralSection + " " + _complectController.s3 + " руб.\n", _complectController.s3),
                    Polish = Counter("Полировка "  + _complectController.Polishing + " " + _complectController.s4 + " руб.\n", _complectController.s4),
                    Gravity = Counter("Гравировка ФИО, др,дс, крестик, портрет " + _complectController.Portrait + " " + _complectController.s5 + " руб.\n", _complectController.s5),
                    Ograda = Counter("Ограда литьевая 205х205 со столбами и шарами " + _complectController.s6 + " руб.\n", _complectController.s6),
                    Lavka = Counter("Лавка литьевая (черная) " + _complectController.s7 + " руб.\n", _complectController.s7),
                    Vaza = Counter("Ваза Н-30 (Ц3) " + _complectController.s8 + " руб.\n", _complectController.s8),
                    Flowers = Counter("Цветы " + _complectController.s9 + " руб.\n", _complectController.s9),
                    Krestick = Counter("Крестик латунный " + _complectController.s10 + " руб.\n", _complectController.s10),
                    Metrick = Counter("Метрика глубокая " + _complectController.s11 + " руб.\n", _complectController.s11),
                    Coloring = Counter("Покраска букв " + _complectController.LetterColor + " " + _complectController.s12 + " руб.\n", _complectController.s12),
                    Gazon = Counter("Газон искусственный " + _complectController.s13 + " руб.\n", _complectController.s13),
                    Mramor = Counter("Мраморная крошка " + _complectController.s14 + " руб.\n", _complectController.s14),
                    Money =
                    Convert.ToInt32(_complectController.s1) + Convert.ToInt32(_complectController.s2) +
                    Convert.ToInt32(value: _complectController.s3) + Convert.ToInt32(_complectController.s4) +
                    Convert.ToInt32(_complectController.s5) + Convert.ToInt32(_complectController.s6) +
                    Convert.ToInt32(_complectController.s7) + Convert.ToInt32(_complectController.s8) +
                    Convert.ToInt32(_complectController.s9) + Convert.ToInt32(_complectController.s10) +
                    Convert.ToInt32(_complectController.s11) + Convert.ToInt32(_complectController.s12) +
                    Convert.ToInt32(_complectController.s13) + Convert.ToInt32(_complectController.s14)
                };

                if(_complectController.DeliverTo != string.Empty)
                {
                    complectList.DeliverTo = "Доставка до: " + _complectController.DeliverTo;
                }

                string fileName = ".docs\\ServFuneralDoc.json";
                AddDocument(complectList, fileName);

                _complectController.Response = "Выполнено";
            }
            catch (Exception ex)
            {
                _complectController.Response = "Ошибка";
            }
        }

        private static string Counter(string final, string money)
        {
            try
            {
                if (Convert.ToInt32(money)>0)
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

        public async void AddDocument(ComplectList serv, string fileName)
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
