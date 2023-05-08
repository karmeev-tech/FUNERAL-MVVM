namespace ORDCreator
{
    public class OrdTransfer
    {
        public void CreateTransfer()
        {
            string complect = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\complect.json";
            string order = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\order.json";
            string services = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет\\services.json";

            File.Copy(Directory.GetCurrentDirectory() + @"\.docs\json\ComplectFuneralDoc.json", complect);
            File.Copy(Directory.GetCurrentDirectory() + @"\.docs\json\OrderDoc.json", order);
            File.Copy(Directory.GetCurrentDirectory() + @"\.docs\json\ServicesDoc.json", services);
            string[] pack = new[] {complect, order, services};

            Zipper zipper = new Zipper();
            zipper.CreateOrdFile(pack, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Пакет");

            File.Delete(complect);
            File.Delete(order);
            File.Delete(services);
        }
    }
}
