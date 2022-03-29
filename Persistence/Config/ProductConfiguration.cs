using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product").HasKey(x => x.Id);
            
            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Description)
                .HasMaxLength(256);

            builder.Property(x => x.OriginPrice)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.CurrentPrice)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Quantity)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.VendorId)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.LastUpdate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.IsActived)
                .HasDefaultValue(true);

            builder.HasMany(x => x.Images)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductDetails)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

        }
    }
}

