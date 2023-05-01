namespace Model.Order
{
    public class OrderCreator
    {
        //order
        private readonly string _FIO;
        private readonly string _DateBirth;
        private readonly string _DateDie;
        private readonly string _FuneralSize;
        private readonly string _Design;
        private readonly string _Epitafia;
        private readonly string _Funeral;
        private readonly string _Service;
        //client
        private readonly string _ClientFIO;
        private readonly string _ClientAdress;
        private readonly string _ClientNumber;
        private readonly string _ClientFuneral;
        private readonly string _ClientSocial;
        //price
        private readonly string _Price;
        private readonly string _Prepayment;
        //services
        private readonly string _Services;
        public OrderCreator(string fIO,
                            string dateBirth,
                            string dateDie,
                            string funeralSize,
                            string design,
                            string epitafia,
                            string funeral,
                            string service,
                            string clientFIO,
                            string clientAdress,
                            string clientNumber,
                            string clientFuneral,
                            string clientSocial,
                            string price,
                            string prepayment,
                            string services)
        {
            _FIO = fIO;
            _DateBirth = dateBirth;
            _DateDie = dateDie;
            _FuneralSize = funeralSize;
            _Design = design;
            _Epitafia = epitafia;
            _Funeral = funeral;
            _Service = service;
            _ClientFIO = clientFIO;
            _ClientAdress = clientAdress;
            _ClientNumber = clientNumber;
            _ClientFuneral = clientFuneral;
            _ClientSocial = clientSocial;
            _Price = price;
            _Prepayment = prepayment;
            _Services = services;
        }
        public string CreateOrder()
        {
            return
                "Ф.И.О умершего: " + _FIO + "\n" +
                "Число, месяц, год рождения: " + _DateBirth + "\n" +
                "Число, месяц, год смерти: " + _DateDie + "\n" +
                "Размер памятника: " + _FuneralSize + "\n" +
                "Оформление: " + _Design + "\n" +
                "Эпитафия: " + _Epitafia + "\n" +
                "Памятник: " + _Funeral + "\n" +
                "Услуги: " + _Service + "\n" +
                "Ф.И.О: " + _ClientFIO + "\n" +
                "Адрес: " + _ClientAdress + "\n" +
                "Телефон: " + _ClientNumber + "\n" +
                "Наименование кладбища (Адрес): " + _ClientFuneral + "\n" +
                "What's Up/Telegram: " + _ClientSocial + "\n";
        }
    }
}
