
namespace QuocThangShopOnline.Models
{
    public class ClientCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public IList<ClientProductViewModel>? Products { get; set; }
    }
}
