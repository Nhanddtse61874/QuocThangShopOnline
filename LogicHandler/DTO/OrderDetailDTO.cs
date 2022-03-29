namespace LogicHandler.DTO
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double CurrentPrice { get; set; }

        public int ProductDetailId { get; set; }

        public int OrderId { get; set; }

        public OrderDTO Order { get; set; }

        public ProductDetailDTO ProductDetail { get; set; }
    }
}