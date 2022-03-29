namespace LogicHandler.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public ICollection<OrderDTO> Orders { get; set; }
    }
}