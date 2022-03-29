namespace LogicHandler.DTO
{
    public class ProductDetailDTO
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public bool IsActived { get; set; }

        public ProductDTO Product { get; set; }

        public ICollection<ProductDetailImageStorageDTO> Images { get; set; }

        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}