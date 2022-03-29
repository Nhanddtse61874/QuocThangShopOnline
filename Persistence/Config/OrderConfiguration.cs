using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order").HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.CustomerId)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(255);

            builder.Property(x => x.CreateDate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Status)
                .HasDefaultValue(1);

            builder.Property(x => x.Total)
                .IsRequired();

            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
