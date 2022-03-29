using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicHandler.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double CurrentPrice { get; set; }

        public double OriginPrice { get; set; }

        public string Description { get; set; }

        public int VendorId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public bool IsActived { get; set; }

        public int CategoryId { get; set; }

        public ICollection<ProductImageStorageDTO> Images { get; set; }

        public ICollection<ProductDetailDTO> ProductDetails { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
