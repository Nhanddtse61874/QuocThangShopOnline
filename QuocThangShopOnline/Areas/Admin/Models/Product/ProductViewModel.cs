
using QuocThangShopOnline.Areas.Admin.Models.Vendor;

namespace QuocThangShopOnline.Areas.Admin.Models
{
#pragma warning disable CS8618
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double CurrentPrice { get; set; }

        public double OriginPrice { get; set; }

        public string Description { get; set; }

        public int VendorId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public bool IsActived { get; set; }

        public int CategoryId { get; set; }

        public ICollection<ProductImageStorageViewModel> Images { get; set; }

        public ICollection<ProductDetailViewModel> ProductDetails { get; set; }

        public CategoryViewModel Category { get; set; }

        public VendorViewModel Vendor { get; set; }
    }
}