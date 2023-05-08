using Domain.Order.Config;
using Domain.Order.Stela;

namespace Domain.Order
{
    public class OrderEntity
    {
        public FuneralBaseEntity Base { get; set; }
        public StelaEntity Stela { get; set; }
        public StandEntity Stand { get; set; }
        public FlowershedEntity Flowershed { get; set; }
        public string Polishing { get; set; }    
        public string Deadass { get; set; }
        public int DeadassCount { get; set; }
        public InstalEntity Instal { get; set; }
        public FuneralEntity Funeral { get; set; }
        public ClientOrderEntity ClientOrder { get; set; }
        public string Price { get; set; }
        public string Prepayment { get; set; }
        public string Remainder { get; set; }
    }
}
