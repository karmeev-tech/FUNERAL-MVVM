using Domain.Order;
using Domain.Services;
using FUNERAL_MVVM.Utility;
using FUNERALMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Documents;

namespace FUNERALMVVM.Commands.Orders
{
    public class GetDeadsCommand : BaseCommands
    {
        private readonly OrderController _orderController;
        private int modif = 0;
        public GetDeadsCommand(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override void Execute(object parameter)
        {
            _orderController.Deadbody = "";

            List <DeadEntity> entities = new();

            string json = "";
            using (StreamReader r = new StreamReader(".docs\\deadbody1.json"))
            {
                json = r.ReadToEnd();
            }
            var result = Check(Deser(json));
            if(result != null)
            {
                entities.Add(result);
                _orderController.Deadbody +=
                    "ФИО умершего " + result.DeadFIO + "\n" +
                    "Число, месяц, год рождения " + result.DeadBirth + "\n" +
                    "Число, месяц, год смерти " + result.DeadDie+ "\n" + "\n";
            }

            string json2 = "";
            using (StreamReader r = new StreamReader(".docs\\deadbody2.json"))
            {
                json2 = r.ReadToEnd();
            }
            var result2 = Check(Deser(json2));
            if(result2 != null)
            {
                entities.Add(result2);
                _orderController.Deadbody +=
                "ФИО умершего " + result2.DeadFIO + "\n" +
                "Число, месяц, год рождения " + result2.DeadBirth + "\n" +
                "Число, месяц, год смерти " + result2.DeadDie + "\n" + "\n";
            }

            string json3 = "";
            using (StreamReader r = new StreamReader(".docs\\deadbody3.json"))
            {
                json3 = r.ReadToEnd();
            }
            var result3 = Check(Deser(json3));
            if(result3 != null)
            {
                entities.Add(result3);
                _orderController.Deadbody +=
                "ФИО умершего " + result3.DeadFIO + "\n" +
                "Число, месяц, год рождения " + result3.DeadBirth + "\n" +
                "Число, месяц, год смерти " + result3.DeadDie + "\n" + "\n";
            }

            string json4 = "";
            using (StreamReader r = new StreamReader(".docs\\deadbody4.json"))
            {
                json4 = r.ReadToEnd();
            }
            var result4 = Check(Deser(json4));
            if(result4 != null)
            {
                entities.Add(result4);
                _orderController.Deadbody +=
                "ФИО умершего " + result4.DeadFIO + "\n" +
                "Число, месяц, год рождения " + result4.DeadBirth + "\n" +
                "Число, месяц, год смерти " + result4.DeadDie + "\n" + "\n";
            }


            _orderController._deadEntities = entities;
        }

        private DeadEntity Deser(string json)
        {
            DeadEntity deServ =
                JsonSerializer.Deserialize<DeadEntity>(json);
            return deServ;
        }

        private DeadEntity Check(DeadEntity deadEntity)
        {
            if(deadEntity.DeadDie == string.Empty ||  
                deadEntity.DeadBirth == string.Empty || 
                deadEntity.DeadFIO == string.Empty)
            {
                return null;
            }
            else
            {
                modif++;
                return deadEntity;
            }
        }
    }
}
