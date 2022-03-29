using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicHandler.DTO
{
    public class ProductImageStorageDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ImageStorageId { get; set; }

        public ProductDTO Product { get; set; }

        public ImageStorageDTO ImageStorage { get; set; }
    }
}
