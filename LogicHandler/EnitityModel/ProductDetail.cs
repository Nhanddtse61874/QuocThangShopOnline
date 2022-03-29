using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel
{
    public class ProductDetail
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public bool IsActived { get; set; }

        public Product Product { get; set; }

        public ICollection<ImageStorage> Images { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
