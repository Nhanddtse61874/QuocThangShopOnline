using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel.Config
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("ProductDetail").HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.ProductId)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(255);

            builder.Property(x => x.Color)
                .HasMaxLength(255);

            builder.Property(x => x.Size)
                .HasMaxLength(255);

            builder.Property(x => x.IsActived)
                .HasDefaultValue(true);

            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.ProductDetail)
                .HasForeignKey(x => x.ProductDetailId);

        }
    }
}
