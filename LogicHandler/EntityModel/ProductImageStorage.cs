namespace Persistence.EnitityModel
{
    public class ProductImageStorage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ImageStorageId { get; set; }

        public Product Product { get; set; }

        public ImageStorage ImageStorage { get; set; }
    }
}
