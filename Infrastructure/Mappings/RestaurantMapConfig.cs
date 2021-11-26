using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class RestaurantMapConfig : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(r => r.Name).IsUnicode(false).HasMaxLength(70);
            builder.Property(r => r.PhoneNumber).IsRequired().HasMaxLength(13);
            builder.Property(r => r.Cnpj).IsRequired().IsUnicode(false).IsFixedLength().HasMaxLength(14);
            builder.HasIndex(r => r.Cnpj).IsUnique();
        }
    }
}
    