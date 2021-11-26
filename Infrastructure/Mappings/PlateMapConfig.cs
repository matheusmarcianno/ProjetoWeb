using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    internal class PlateMapConfig : IEntityTypeConfiguration<Plate>
    {
        public void Configure(EntityTypeBuilder<Plate> builder)
        {
            builder.Property(p => p.Name).IsRequired().IsUnicode(false).HasMaxLength(45);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Property(p => p.Price).IsRequired();
        }
    }
}
