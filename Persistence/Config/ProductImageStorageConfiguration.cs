using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel.Config
{
    public class ProductImageStorageConfiguration : IEntityTypeConfiguration<ProductImageStorage>
    {
        public void Configure(EntityTypeBuilder<ProductImageStorage> builder)
        {
            builder.ToTable("ProductImageStorage").HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.ImageStorageId)
                .IsRequired();

            builder.Property(x => x.ProductId)
                .IsRequired();
        }
    }
}
