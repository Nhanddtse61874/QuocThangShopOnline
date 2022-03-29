namespace LogicHandler.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Total { get; set; }

        public DateTime CreateDate { get; set; }

        public int Status { get; set; }

        public int CustomerId { get; set; }

        public CustomerDTO Customer { get; set; }

        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}