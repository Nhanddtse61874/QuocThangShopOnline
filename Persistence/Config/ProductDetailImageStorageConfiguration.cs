using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel.Config
{
    public class ProductDetailImageStorageConfiguration : IEntityTypeConfiguration<ProductDetailImageStorage>
    {
        public void Configure(EntityTypeBuilder<ProductDetailImageStorage> builder)
        {
            builder.ToTable("ProductDetailImageStorage").HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.ImageStorageId)
                .IsRequired();

            builder.Property(x => x.ProductDetailId)
                .IsRequired();
        }
    }
}
