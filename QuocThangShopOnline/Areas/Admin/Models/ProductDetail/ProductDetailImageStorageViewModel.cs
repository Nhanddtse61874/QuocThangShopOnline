using QuocThangShopOnline.Areas.Admin.Models
{
    public class ProductDetailImageStorageViewModel
    {
        public int Id { get; set; }

        public int ProductDetailId { get; set; }

        public int ImageStorageId { get; set; }

        public ProductDetailViewModel ProductDetail { get; set; }

        public ImageStorageViewModel ImageStorage { get; set; }
    }

}
