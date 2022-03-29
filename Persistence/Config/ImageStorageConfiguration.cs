using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EnitityModel.Config
{
    public class ImageStorageConfiguration : IEntityTypeConfiguration<ImageStorage>
    {
        public void Configure(EntityTypeBuilder<ImageStorage> builder)
        {
            builder.ToTable("ImageStorage").HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Path)
                .HasMaxLength(int.MaxValue)
                .IsRequired();
        }
    }
}
