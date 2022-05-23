namespace Persistence.EnitityModel
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public  double CurrentPrice { get; set; }

        public int ProductDetailId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public ProductDetail ProductDetail { get; set; }
    }
}
