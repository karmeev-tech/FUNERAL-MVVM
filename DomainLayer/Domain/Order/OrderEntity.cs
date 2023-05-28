using Domain.Order.Config;
using Domain.Order.Stela;

namespace Domain.Order
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public FuneralBaseEntity Base { get; set; }
        public StelaEntity Stela { get; set; }
        public StandEntity Stand { get; set; }
        public FlowershedEntity Flowershed { get; set; }
        public string Polishing { get; set; }
        public List<DeadModel> Deadass { get; set; }
        public int DeadassCount { get; set; }
        public InstalEntity Instal { get; set; }
        public FuneralEntity Funeral { get; set; }
        public ClientOrderEntity ClientOrder { get; set; }
        public string Price { get; set; }
        public string FuneralPrice { get; set; }
        public string ComplectPrice { get; set; }
        public string ServsPrice { get; set; }
        public string Prepayment { get; set; }
        public string Remainder { get; set; }
    }
}
