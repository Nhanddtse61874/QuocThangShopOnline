using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel.Config
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact").HasKey(x => x.Id);

            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Address)
                .IsRequired();

            builder.Property(x => x.HotLine)
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
