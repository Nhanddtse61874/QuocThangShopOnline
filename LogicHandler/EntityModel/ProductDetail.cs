namespace Persistence.EnitityModel
{
    public class ProductDetail
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public bool IsActived { get; set; }

        public Product Product { get; set; }

        public ICollection<ProductDetailImageStorage> Images { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
