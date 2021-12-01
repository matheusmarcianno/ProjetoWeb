using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class CategoryMapConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.).IsRequired().HasMaxLength(50);
            builder.HasMany(c => c.Plates).WithOne(p => p.Category);
        }
    }
}
