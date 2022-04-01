using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel
{
    public class Order
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Total { get; set; }

        public DateTime CreateDate { get; set; }

        public int Status { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
