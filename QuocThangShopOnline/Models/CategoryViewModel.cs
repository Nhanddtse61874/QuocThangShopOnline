
namespace QuocThangShopOnline.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public IList<ProductViewModel> Products { get; set; }
    }
}
