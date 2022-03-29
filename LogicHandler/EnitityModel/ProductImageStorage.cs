﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel
{
    public class ProductImageStorage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ImageStorageId { get; set; }

        public Product Product { get; set; }

        public ImageStorage ImageStorage { get; set; }
    }
}
