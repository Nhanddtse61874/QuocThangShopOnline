using Persistence.EnitityModel;

namespace LogicHandler.EnitityModel
{
    public class Vendor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
