namespace QuocThangShopOnline.Areas.Admin.Models
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public bool IsActived { get; set; }

        public ICollection<ProductImageStorageViewModel> Images { get; set; }

    }
}
