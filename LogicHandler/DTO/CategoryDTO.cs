namespace LogicHandler.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public CategoryDTO? Parent { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }
    }
}