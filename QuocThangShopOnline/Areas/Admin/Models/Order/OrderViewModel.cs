namespace QuocThangShopOnline.Areas.Admin.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Total { get; set; }

        public DateTime CreateDate { get; set; }

        public int Status { get; set; }

        public int CustomerId { get; set; }

        public CustomerViewModel Customer { get; set; }

        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
