using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel
{
    public class ProductDetailImageStorage
    {
        public int Id { get; set; }

        public int ProductDetailId { get; set; }

        public int ImageStorageId { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public ImageStorage ImageStorage { get; set; }
    }
}
