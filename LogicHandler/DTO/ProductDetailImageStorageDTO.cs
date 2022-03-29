namespace LogicHandler.DTO
{
    public class ProductDetailImageStorageDTO
    {
        public int Id { get; set; }

        public int ProductDetailId { get; set; }

        public int ImageStorageId { get; set; }

        public ProductDetailDTO ProductDetail { get; set; }

        public ImageStorageDTO ImageStorage { get; set; }
    }
}