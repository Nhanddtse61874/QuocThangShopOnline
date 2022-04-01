using LogicHandler.EnitityModel;

namespace Persistence.EnitityModel
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double  CurrentPrice { get; set; }

        public double  OriginPrice { get; set; }

        public string Description { get; set; }

        public int VendorId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public bool IsActived { get; set; }

        public int CategoryId { get; set; }

        public ICollection<ProductImageStorage> Images { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

        public Category Category { get; set; }

        public Vendor Vendor { get; set; }

    }
}