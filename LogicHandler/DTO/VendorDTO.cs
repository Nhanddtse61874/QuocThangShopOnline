using Persistence.EnitityModel;

namespace LogicHandler.DTO
{
    public class VendorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
