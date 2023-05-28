using Infrastructure.Context.Services;
using Infrastructure.Model.Services;

namespace Shop.EF
{
    public class ServicesConnector
    {
        public static List<ServiceEntity> GetServices()
        {
            List<ServiceEntity> materials = new List<ServiceEntity>();

            using (var db = new MaterialsContext())
            {
                var query = from b in db.Materials
                            select b;

                foreach (var item in query)
                {
                    materials.Add(item);
                }
            }
            return materials;
        }
        public static List<string> GetServicesNames()
        {
            List<string> materials = new List<string>();

            using (var db = new MaterialsContext())
            {
                var query = from b in db.Materials
                            select b;

                foreach (var item in query)
                {
                    materials.Add(item.Name);
                }
            }
            return materials;
        }

        public static void UpdateServices(List<ServiceEntity> materials)
        {
            using (var db = new MaterialsContext())
            {
                var query = from b in db.Materials
                            select b;

                var nowItems = query.ToList();
                db.Materials.RemoveRange(nowItems);
                db.SaveChanges();
                if(materials.Count > 0)
                {
                    db.Materials.AddRange(materials);
                    db.SaveChanges();
                }
            }
        }
    }
}
