namespace QuocThangShopOnline.Areas.Admin.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double CurrentPrice { get; set; }

        public int ProductDetailId { get; set; }

        public int OrderId { get; set; }

        public ProductDetailViewModel ProductDetail { get; set; }
    }
}
