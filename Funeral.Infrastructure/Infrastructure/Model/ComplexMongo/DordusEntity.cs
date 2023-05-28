using Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.ComplexMongo
{
    public class DordusEntity
    {
        public string Time { get; set; }
        public string TimeEnd { get; set; }
        public string ManagerName { get; set; }
        public List<OrderEntity> AllOrders { get; set; }
        public ItemsEntity Complect { get; set; }
        public List<ComplexServiceEntity> AllServices { get; set; }
    }
}
