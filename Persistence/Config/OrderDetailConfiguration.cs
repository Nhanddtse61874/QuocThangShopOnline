using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel.Config
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail").HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.ProductDetailId)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasDefaultValueSql();

            builder.Property(x => x.CurrentPrice)
                .HasDefaultValueSql();
        }
    }
}
