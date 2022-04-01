using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel
{
    public class Contact
    {
        public int Id { get; set; }

        public string HotLine { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }
    }
}
